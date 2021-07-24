using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using EL_Compzit;
using BL_Compzit;
using EL_Compzit.EntityLayer_GMS;
using BL_Compzit.BusinessLayer_GMS;
using CL_Compzit;


public partial class GMS_GMS_Master_gen_Insurance_Master_gen_Modify_Insurance_Master_List : System.Web.UI.Page
{
  
   clsBusinessLayerInsuranceMaster objBusinessInsurance = new clsBusinessLayerInsuranceMaster();

    private enum Button_type
    {
        Previous = 1,
        Next = 2
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divtile.InnerHtml = "Insurance";

            LoadInsuranceProvider();


            LoadInsuranceTypeMaster();

            // END EVM-0031 //

            HiddenCurrentDate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;
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
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Insurance_Master);
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

                if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                {
                    divAdd.Visible = true;
                }
                else
                {
                    divAdd.Visible = false;
                }
            }

            clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();


            //Creating objects for business layer

            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

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
                intUserId = Convert.ToInt32(Session["USERID"]);
                objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);

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
                string strInsuranceTyp = strSearchFields[2];
                string EspireDate = strSearchFields[3];
                string strCbxStatus = strSearchFields[4];
                string strInsurncPrvdr = strSearchFields[5];
                string strGuartSts = strSearchFields[6];

                if (strFromDate != null && strFromDate != "")
                {
                    txtFromDate.Text = strFromDate;
                }
                if (strToDate != null && strToDate != "")
                {
                    txtToDate.Text = strToDate;
                }

                if (strInsuranceTyp != null && strInsuranceTyp != "")
                {
                    if (ddlInsuranceTyp.Items.FindByValue(strInsuranceTyp) != null)
                    {
                        ddlInsuranceTyp.ClearSelection();
                        ddlInsuranceTyp.Items.FindByValue(strInsuranceTyp).Selected = true;
                    }
                }

                if (EspireDate != null && EspireDate != "")
                {
                    ExpiryDate.Text = EspireDate;
                }

                if (strCbxStatus == "1")
                {
                    cbxCnclStatus.Checked = true;
                }
                else
                {
                    cbxCnclStatus.Checked = false;
                }

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


                if (strGuartSts != null && strGuartSts != "")
                {
                    if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                    {
                        ddlGuaranteeStatus.ClearSelection();

                        ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;

                    }
                }

            }

            clsCommonLibrary.CORP_GLOBAL[] arrEnumerr = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetails = new DataTable();
            dtCorpDetails = objBusinessLayer.LoadGlobalDetail(arrEnumerr, intCorpId);
            if (dtCorpDetails.Rows.Count > 0)
            {
                hiddenDfltCurrencyMstrId.Value = dtCorpDetails.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
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

            if (Request.QueryString["Id"] != null)
            {//when Canceled

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                objEntityInsurance.InsuranceId = Convert.ToInt32(strId);
                objEntityInsurance.User_Id = intUserId;

                objEntityInsurance.D_Date = System.DateTime.Now;

                if (dtCorpDetail.Rows.Count > 0)
                {
                    string CnclrsnMust = dtCorpDetail.Rows[0]["CNCL_REASN_MUST"].ToString();
                    if (CnclrsnMust == "0")
                    {
                        objEntityInsurance.Cancel_reason = objCommon.CancelReason();

                        objBusinessInsurance.CancelInsurance(objEntityInsurance);
                        if (HiddenSearchField.Value == "")
                        {
                            Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Cncl");
                        }
                        else
                        {
                            Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
                        }

                    }
                    else
                    {
                        if (HiddenSearchField.Value == "")
                        {
                            objEntityInsurance.OpenDate = DateTime.MinValue;
                            objEntityInsurance.ToDate = DateTime.MinValue;
                            objEntityInsurance.InsuranceTyp = 0;
                            objEntityInsurance.ExpireDate = DateTime.MinValue;
                            objEntityInsurance.Cancel_Status = 0;
                            objEntityInsurance.InsuranceProvider = 0;
                            objEntityInsurance.StatusSrch = 1;
                        }
                        else
                        {
                            string strHidden = "";
                            strHidden = HiddenSearchField.Value;


                            string[] strSearchFields = strHidden.Split(',');
                            string strFromDate = strSearchFields[0];
                            string strToDate = strSearchFields[1];
                            string strInsuranceTyp = strSearchFields[2];
                            string EspireDate = strSearchFields[3];
                            string strCbxStatus = strSearchFields[4];
                            string strInsurncPrvdr = strSearchFields[5];
                            string strGuartSts = strSearchFields[6];

                            if (strFromDate != null && strFromDate != "")
                            {

                                txtFromDate.Text = strFromDate;
                                objEntityInsurance.OpenDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                            }
                            else
                            {
                                objEntityInsurance.OpenDate = DateTime.MinValue;
                            }
                            if (strToDate != null && strToDate != "")
                            {
                                txtToDate.Text = strToDate;
                                objEntityInsurance.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
                            }
                            else
                            {
                                objEntityInsurance.ToDate = DateTime.MinValue;
                            }

                            if (strInsuranceTyp != null && strInsuranceTyp != "")
                            {
                                if (ddlInsuranceTyp.Items.FindByValue(strInsuranceTyp) != null)
                                {
                                    ddlInsuranceTyp.ClearSelection();
                                    ddlInsuranceTyp.Items.FindByValue(strInsuranceTyp).Selected = true;
                                    objEntityInsurance.InsuranceTyp = Convert.ToInt32(strInsuranceTyp);
                                }
                            }

                            if (EspireDate != null && EspireDate != "")
                            {
                                ExpiryDate.Text = EspireDate;
                                objEntityInsurance.ExpireDate = objCommon.textToDateTime(ExpiryDate.Text.Trim());
                            }
                            if (strInsurncPrvdr != null && strInsurncPrvdr != "")
                            {
                                if (ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr) != null)
                                {
                                    if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                                    {
                                        ddlInsurncPrvdr.ClearSelection();
                                        ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr).Selected = true;
                                        objEntityInsurance.InsuranceProvider = Convert.ToInt32(strInsurncPrvdr);
                                    }
                                }
                            }
                            if (strGuartSts != null && strGuartSts != "")
                            {
                                if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                                {
                                    ddlGuaranteeStatus.ClearSelection();

                                    ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;
                                    objEntityInsurance.StatusSrch = Convert.ToInt32(strGuartSts);

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

                            objEntityInsurance.Cancel_Status = Convert.ToInt32(strCbxStatus);
                        }

                        DataTable dtInsurance = objBusinessInsurance.ReadInsuranceList(objEntityInsurance);

                        string strHtm = ConvertDataTableToHTML(dtInsurance, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
                        //Write to divReport
                        divReport.InnerHtml = strHtm;
                        string strPrintReport = ConvertDataTableForPrint(dtInsurance);
                        divPrintReport.InnerHtml = strPrintReport;

                        hiddenRsnid.Value = strId;

                    }

                }
            }
            else if (Request.QueryString["ReId"] != null)
            {//when recalled
                string strRandomMixedId = Request.QueryString["ReId"].ToString();
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
                        Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Recl");
                    }
                    else
                    {
                        Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Recl&Srch=" + this.HiddenSearchField.Value);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Duplication", "Duplication();", true);
                }
            }
            else if (Request.QueryString["CONF"] != null)
            {//when confirmed
                string strRandomMixedId = Request.QueryString["CONF"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                objEntityInsurance.InsuranceId = Convert.ToInt32(strId);
                objEntityInsurance.D_Date = System.DateTime.Now;

                DataTable GuarantStatus = objBusinessInsurance.ReadInsuranceStatus(objEntityInsurance);
                string strchckStatus = "";
                if (GuarantStatus.Rows.Count > 0)
                {
                    strchckStatus = GuarantStatus.Rows[0]["INSURANCE_STATUS"].ToString();
                }

                if (strchckStatus != "2")
                {
                    objBusinessInsurance.ConfirmInsurance(objEntityInsurance);
                    Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=CONF");
                }
                else
                {
                    Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=CONFCHK");
                }
            }
            else if (Request.QueryString["Close"] != null)
            {//when closed

                string strRandomMixedId = Request.QueryString["Close"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                objEntityInsurance.InsuranceId = Convert.ToInt32(strId);
                objEntityInsurance.User_Id = intUserId;

                objEntityInsurance.D_Date = System.DateTime.Now;



                if (HiddenSearchField.Value == "")
                {
                    objEntityInsurance.OpenDate = DateTime.MinValue;
                    objEntityInsurance.ToDate = DateTime.MinValue;
                    objEntityInsurance.InsuranceTyp = 0;
                    objEntityInsurance.ExpireDate = DateTime.MinValue;
                    objEntityInsurance.Cancel_Status = 0;
                    objEntityInsurance.InsuranceProvider = 0;
                    objEntityInsurance.StatusSrch = 1;
                }
                else
                {
                    string strHidden = "";
                    strHidden = HiddenSearchField.Value;


                    string[] strSearchFields = strHidden.Split(',');
                    string strFromDate = strSearchFields[0];
                    string strToDate = strSearchFields[1];
                    string strInsuranceTyp = strSearchFields[2];
                    string EspireDate = strSearchFields[3];
                    string strCbxStatus = strSearchFields[4];
                    string strInsurncPrvdr = strSearchFields[5];
                    string strGuartSts = strSearchFields[6];

                    if (strFromDate != null && strFromDate != "")
                    {
                        txtFromDate.Text = strFromDate;
                        objEntityInsurance.OpenDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                    }
                    else
                    {
                        objEntityInsurance.OpenDate = DateTime.MinValue;
                    }
                    if (strToDate != null && strToDate != "")
                    {
                        txtToDate.Text = strToDate;
                        objEntityInsurance.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
                    }
                    else
                    {
                        objEntityInsurance.ToDate = DateTime.MinValue;
                    }

                    if (strInsuranceTyp != null && strInsuranceTyp != "")
                    {
                        if (ddlInsuranceTyp.Items.FindByValue(strInsuranceTyp) != null)
                        {
                            ddlInsuranceTyp.ClearSelection();
                            ddlInsuranceTyp.Items.FindByValue(strInsuranceTyp).Selected = true;
                            objEntityInsurance.InsuranceTyp = Convert.ToInt32(strInsuranceTyp);
                        }
                    }

                    if (EspireDate != null && EspireDate != "")
                    {
                        ExpiryDate.Text = EspireDate;
                        objEntityInsurance.ExpireDate = objCommon.textToDateTime(ExpiryDate.Text.Trim());
                    }
                    if (strInsurncPrvdr != null && strInsurncPrvdr != "")
                    {
                        if (ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr) != null)
                        {
                            if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                            {
                                ddlInsurncPrvdr.ClearSelection();
                                ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr).Selected = true;
                                objEntityInsurance.InsuranceProvider = Convert.ToInt32(strInsurncPrvdr);
                            }
                        }
                    }
                    if (strGuartSts != null && strGuartSts != "")
                    {
                        if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                        {
                            ddlGuaranteeStatus.ClearSelection();

                            ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;
                            objEntityInsurance.StatusSrch = Convert.ToInt32(strGuartSts);

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

                    objEntityInsurance.Cancel_Status = Convert.ToInt32(strCbxStatus);
                }

                DataTable dtInsurance = objBusinessInsurance.ReadInsuranceList(objEntityInsurance);

                string strHtm = ConvertDataTableToHTML(dtInsurance, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
                //Write to divReport
                divReport.InnerHtml = strHtm;

                string strPrintReport = ConvertDataTableForPrint(dtInsurance);
                divPrintReport.InnerHtml = strPrintReport;

                hiddenRsnidclose.Value = strId;
            }

            else
            {
                //to view
                if (HiddenSearchField.Value == "")
                {
                    if (HiddenSearchField.Value == "")
                    {
                        objEntityInsurance.OpenDate = DateTime.MinValue;
                        objEntityInsurance.ToDate = DateTime.MinValue;
                        objEntityInsurance.InsuranceTyp = 0;
                        objEntityInsurance.ExpireDate = DateTime.MinValue;
                        objEntityInsurance.Cancel_Status = 0;
                        objEntityInsurance.InsuranceProvider = 0;
                        objEntityInsurance.StatusSrch = 0;
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
                    string strInsuranceTyp = strSearchFields[2];
                    string EspireDate = strSearchFields[3];
                    string strCbxStatus = strSearchFields[4];
                    string strInsurncPrvdr = strSearchFields[5];
                    string strGuartSts = strSearchFields[6];

                    if (strFromDate != null && strFromDate != "")
                    {
                        txtFromDate.Text = strFromDate;
                        objEntityInsurance.OpenDate = objCommon.textToDateTime(txtFromDate.Text.Trim());
                    }
                    else
                    {
                        objEntityInsurance.OpenDate = DateTime.MinValue;
                    }
                    if (strToDate != null && strToDate != "")
                    {
                        txtToDate.Text = strToDate;

                        objEntityInsurance.ToDate = objCommon.textToDateTime(txtToDate.Text.Trim());
                    }
                    else
                    {
                        objEntityInsurance.ToDate = DateTime.MinValue;
                    }

                    if (strInsuranceTyp != null && strInsuranceTyp != "")
                    {
                        if (ddlInsuranceTyp.Items.FindByValue(strInsuranceTyp) != null)
                        {
                            ddlInsuranceTyp.ClearSelection();
                            ddlInsuranceTyp.Items.FindByValue(strInsuranceTyp).Selected = true;
                            objEntityInsurance.InsuranceTyp = Convert.ToInt32(strInsuranceTyp);
                        }
                    }

                    if (EspireDate != null && EspireDate != "")
                    {

                        ExpiryDate.Text = EspireDate;
                        objEntityInsurance.ExpireDate = objCommon.textToDateTime(ExpiryDate.Text.Trim());
                    }
                    if (strInsurncPrvdr != null && strInsurncPrvdr != "")
                    {
                        if (ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr) != null)
                        {
                            if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                            {
                                ddlInsurncPrvdr.ClearSelection();
                                ddlInsurncPrvdr.Items.FindByValue(strInsurncPrvdr).Selected = true;
                                objEntityInsurance.InsuranceProvider = Convert.ToInt32(strInsurncPrvdr);
                            }
                        }
                    }
                    if (strGuartSts != null && strGuartSts != "")
                    {
                        if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                        {
                            ddlGuaranteeStatus.ClearSelection();

                            ddlGuaranteeStatus.Items.FindByValue(strGuartSts).Selected = true;
                            objEntityInsurance.StatusSrch = Convert.ToInt32(strGuartSts);

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
                    objEntityInsurance.Cancel_Status = Convert.ToInt32(strCbxStatus);
                }

                DataTable dtInsurance = objBusinessInsurance.ReadInsuranceList(objEntityInsurance);

                string strHtm = ConvertDataTableToHTML(dtInsurance, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
                string strPrintReport = ConvertDataTableForPrint(dtInsurance);
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


    public void LoadInsuranceProvider()
    {
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
            ddlInsurncPrvdr.DataSource = dtInsurancePrvdrs;
            ddlInsurncPrvdr.DataTextField = "INSURPRVDR_NAME";
            ddlInsurncPrvdr.DataValueField = "INSURPRVDR_ID";
            ddlInsurncPrvdr.DataBind();
        }
        ddlInsurncPrvdr.Items.Insert(0, "--SELECT INSURANCE PROVIDER--");
    }

    public string ConvertDataTableToHTML(DataTable dt, int intEnableModify, int intEnableCancel, int intEnableRecall, int intEnableClose, int intEnableRenew, int intEnableConfirm)
    {
        intEnableModify = Convert.ToInt32(clsCommonLibrary.StatusAll.InActive);
        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.InActive);
        intEnableRecall = Convert.ToInt32(clsCommonLibrary.StatusAll.InActive);
        intEnableClose = Convert.ToInt32(clsCommonLibrary.StatusAll.InActive);
        intEnableRenew = Convert.ToInt32(clsCommonLibrary.StatusAll.InActive);
        intEnableConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.InActive);

        hiddenRowCount.Value = dt.Rows.Count.ToString();

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

        StringBuilder sb = new StringBuilder();
        string strHtml = "<table id=\"ReportTable\" class=\"main_table\" cellspacing=\"0\" cellpadding=\"2px\" >";
        //add header row
        strHtml += "<thead>";
        strHtml += "<tr class=\"main_table_head\">";
        strHtml += "<th class=\"thT\" style=\"width:3%;text-align: left; word-wrap:break-word;\"><input type=\"checkbox\" Id=\"cbxSelectAll\" OnkeyPress=\"return DisableEnter(event)\" style=\"margin-left: 8%;\" onchange=\"selectAllGuarantee()\"></th>";

        for (int intColumnHeaderCount = 0; intColumnHeaderCount < dt.Columns.Count; intColumnHeaderCount++)
        {
            if (intColumnHeaderCount == 1)
            {
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%; word-wrap:break-word; text-align: center;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
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
                        int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["INSURANCE_CNCL_USR_ID"].ToString());
                        int intCancTransaction = 0;
                        string InsrncStatus = dt.Rows[intRowBodyCount]["INSURANCE_STATUS"].ToString();

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
                        strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblguaranteelist" + intRowBodyCount + "\"true\" onchange=\"IncrmntConfrmCounter()\" OnkeyPress=\"return DisableEnter(event)\" value=\"" + dt.Rows[intRowBodyCount][0].ToString() + " \"></td>";

                     
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
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 4)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 5)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 6)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                            }
                            else if (intColumnBodyCount == 7)
                            {
                                strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
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
                            }
                        }

                        string strId = dt.Rows[intRowBodyCount][0].ToString();
                        int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;

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
                                                  " href=\"gen_Insurance_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                             " href=\"gen_Insurance_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                        }
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                 " href=\"gen_Insurance_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                    }
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                             " href=\"gen_Insurance_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                }
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                                 " href=\"gen_Insurance_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                            }

                            //confirm

                            if (intCnclUsrId == 0)
                            {
                                if (intEnableConfirm == 1)
                                {
                                    if (intnew == 1)
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1% ;\" title=\"Confirm\"    onclick='return ConfirmGtee(this.href," + intExpiredSts + ");' " +
                                                              " href=\"gen_Insurance_Master_List.aspx?CONF=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
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
                                                         " href=\"gen_Insurance_Master_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                    }
                                                    else
                                                    {
                                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                                         " href=\"gen_Insurance_Master_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
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
                                         " href=\"gen_Insurance_Master_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: 1%;\" title=\"Recall\"   onclick='return ReCallAlert(this.href);' " +
                                         " href=\"gen_Insurance_Master_List.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
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
                                                             " href=\"gen_Insurance_Master_List.aspx?Close=" + Id + "\">" + "<img  src='/Images/Icons/close.png' /> " + "</a> </td>";
                                        }
                                        else
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: .5%;\"  title=\"Close\"  onclick='return ConfirmClose(this.href);' " +
                                                           " href=\"gen_Insurance_Master_List.aspx?Close=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/close.png' /> " + "</a> </td>";
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
                                                                " href=\"gen_Insurance_Master.aspx?Renew=" + Id + "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        if (intConfirmed == 1)
                                        {
                                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Renew\"   " +
                                                                " href=\"gen_Insurance_Master.aspx?Renew=" + Id + "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
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
                    int intCnclUsrId = Convert.ToInt32(dt.Rows[intRowBodyCount]["INSURANCE_CNCL_USR_ID"].ToString());
                    int intCancTransaction = 0;

                    string InsrncStatus = dt.Rows[intRowBodyCount]["INSURANCE_STATUS"].ToString();

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
                    strHtml += "<td class=\"tdT\" style=\" width:3%;word-break: break-all; word-wrap:break-word;text-align: left;\" ><input type=\"checkbox\" Id=\"cblguaranteelist" + intRowBodyCount + "\"true\" onchange=\"IncrmntConfrmCounter()\" OnkeyPress=\"return DisableEnter(event)\" value=\"" + dt.Rows[intRowBodyCount][0].ToString() + " \"></td>";

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
                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 4)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 5)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 6)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                        else if (intColumnBodyCount == 7)
                        {
                            strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
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
                        }
                    }

                    string strId = dt.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dt.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;


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
                                              " href=\"gen_Insurance_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/edit.png' /> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                         " href=\"gen_Insurance_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                    }
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                             " href=\"gen_Insurance_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                                }
                            }
                            else
                            {
                                strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                         " href=\"gen_Insurance_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                            }
                        }
                        else
                        {
                            strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; \" title=\"View\"  onclick='return getdetails(this.href);' " +
                                             " href=\"gen_Insurance_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/view.png' />  " + "</a> </td>";
                        }

                        //confirm

                        if (intCnclUsrId == 0)
                        {
                            if (intEnableConfirm == 1)
                            {
                                if (intnew == 1)
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align:center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left:1% ;\" title=\"Confirm\"    onclick='return ConfirmGtee(this.href," + intExpiredSts + ");' " +
                                                          " href=\"gen_Insurance_Master_List.aspx?CONF=" + Id + "\">" + "<img  style=\"\" src='/Images/Icons/confirm.png' /> " + "</a> </td>";
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
                                                     " href=\"gen_Insurance_Master_List.aspx?Id=" + Id + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
                                                }
                                                else
                                                {
                                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Cancel\"  onclick='return CancelAlert(this.href);' " +
                                                     " href=\"gen_Insurance_Master_List.aspx?Id=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/delete.png' /> " + "</a> </td>";
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
                                     " href=\"gen_Insurance_Master_List.aspx?ReId=" + Id + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
                                }
                                else
                                {
                                    strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: 1%;\" title=\"Recall\"   onclick='return ReCallAlert(this.href);' " +
                                     " href=\"gen_Insurance_Master_List.aspx?ReId=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/recover.png' /> " + "</a> </td>";
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
                                                         " href=\"gen_Insurance_Master_List.aspx?Close=" + Id + "\">" + "<img  src='/Images/Icons/close.png' /> " + "</a> </td>";
                                    }
                                    else
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%; margin-left: .5%;\"  title=\"Close\"  onclick='return ConfirmClose(this.href);' " +
                                                       " href=\"gen_Insurance_Master_List.aspx?Close=" + Id + "&Srch=" + this.HiddenSearchField.Value + "\">" + "<img  src='/Images/Icons/close.png' /> " + "</a> </td>";
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
                                                            " href=\"gen_Insurance_Master.aspx?Renew=" + Id + "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
                                }
                                else
                                {
                                    if (intConfirmed == 1)
                                    {
                                        strHtml += "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  class=\"tooltip\" style=\"z-index: 99;opacity:1;margin-top:-1%;margin-left:1%; \"  title=\"Renew\"   " +
                                                            " href=\"gen_Insurance_Master.aspx?Renew=" + Id + "\">" + "<img  src='/Images/Icons/Renewal.png'/> " + "</a> </td>";
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

        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Insurance_Master);
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

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible = true;
            }
            else
            {
                divAdd.Visible = false;
            }
        }
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

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
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumerr = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
        DataTable dtCorpDetails = new DataTable();
        dtCorpDetails = objBusinessLayer.LoadGlobalDetail(arrEnumerr, intCorpId);
        if (dtCorpDetails.Rows.Count > 0)
        {
            hiddenDfltCurrencyMstrId.Value = dtCorpDetails.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
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

        if (HiddenSearchField.Value == "")
        {
            objEntityInsurance.OpenDate = DateTime.MinValue;
            objEntityInsurance.ToDate = DateTime.MinValue;
            objEntityInsurance.InsuranceTyp = 0;
            objEntityInsurance.ExpireDate = DateTime.MinValue;
            objEntityInsurance.Cancel_Status = 0;
            objEntityInsurance.InsuranceProvider = 0;
            objEntityInsurance.StatusSrch = 0;
            objEntityInsurance.InsuranceTypMstr = 0;
        }
        else
        {
            string strHidden = HiddenSearchField.Value;
            string[] strSearchFields = strHidden.Split(',');
            string strFromDate = strSearchFields[0];
            string strToDate = strSearchFields[1];
            string strInsuranceTyp = strSearchFields[2];
            string EspireDate = strSearchFields[3];
            string strCbxStatus = strSearchFields[4];
            string strInsurncPrvdr = strSearchFields[5];
            string strGuartSts = strSearchFields[6];
            string strInsTypMstr = strSearchFields[7];

            if (strFromDate != null && strFromDate != "")
            {
                objEntityInsurance.ExpiryFromDate = objCommon.textToDateTime(strFromDate);
            }
            if (strToDate != null && strToDate != "")
            {
                objEntityInsurance.ToDate = objCommon.textToDateTime(strToDate);
            }

            if (strInsuranceTyp != null && strInsuranceTyp != "")
            {
                objEntityInsurance.InsuranceTyp = Convert.ToInt32(ddlInsuranceTyp.SelectedItem.Value);
            }

            if (EspireDate != null && EspireDate != "")
            {
                objEntityInsurance.ExpireDate = objCommon.textToDateTime(EspireDate);
            }

            if (strCbxStatus == "1")
            {
                cbxCnclStatus.Checked = true;
            }
            else
            {
                cbxCnclStatus.Checked = false;
            }

            if (strInsurncPrvdr != null && strInsurncPrvdr != "")
            {
                if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                {
                    objEntityInsurance.InsuranceProvider = Convert.ToInt32(ddlInsurncPrvdr.SelectedItem.Value);
                }
            }

            if (strInsTypMstr != null && strInsTypMstr != "")
            {
                if (ddlsearch.SelectedItem.Value != "--SELECT INSURANCE TYPE--")
                {
                    objEntityInsurance.InsuranceTypMstr = Convert.ToInt32(ddlsearch.SelectedItem.Value);
                }
            }

            if (strGuartSts != null && strGuartSts != "")
            {
                objEntityInsurance.StatusSrch = Convert.ToInt32(strGuartSts);
            }
            if (strCbxStatus == "1")
            {
                cbxCnclStatus.Checked = true;
            }
            else
            {
                cbxCnclStatus.Checked = false;
            }

            objEntityInsurance.Cancel_Status = Convert.ToInt32(strCbxStatus);
        }

        DataTable dtInsurance = objBusinessInsurance.ReadInsuranceList(objEntityInsurance);
        string strHtm = ConvertDataTableToHTML(dtInsurance, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
        //Write to divReport
        divReport.InnerHtml = strHtm;
        string strPrintReport = ConvertDataTableForPrint(dtInsurance);
        divPrintReport.InnerHtml = strPrintReport;
    }

    protected void btnRsnSave_Click(object sender, EventArgs e)
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (hiddenRsnid.Value != null && hiddenRsnid.Value != "")
        {
            objEntityInsurance.InsuranceId = Convert.ToInt32(hiddenRsnid.Value);

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
                Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Cncl");
            }
            else
            {
                Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Cncl&Srch=" + this.HiddenSearchField.Value);
            }
        }
    }

    protected void BtnCloseSave_Click(object sender, EventArgs e)
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

        if (hiddenRsnidclose.Value != null && hiddenRsnidclose.Value != "")
        {
            objEntityInsurance.InsuranceId = Convert.ToInt32(hiddenRsnidclose.Value);

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
                Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Cls");
            }
            else
            {
                Response.Redirect("gen_Insurance_Master_List.aspx?InsUpd=Cls&Srch=" + this.HiddenSearchField.Value);
            }
        }
    }

    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Previous));
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Set_Table(Convert.ToInt32(Button_type.Previous));
    }

    public void Set_Table(int intButtonId)
    {
        clsEntityLayerInsuranceMaster objEntityInsurance = new clsEntityLayerInsuranceMaster();

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
        intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Insurance_Master);
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

            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                divAdd.Visible = true;
            }
            else
            {
                divAdd.Visible = false;
            }
        }
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityInsurance.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

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
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityInsurance.User_Id = Convert.ToInt32(Session["USERID"]);

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsCommonLibrary.CORP_GLOBAL[] arrEnumerr = {   clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE,
                                                               clsCommonLibrary.CORP_GLOBAL.LISTING_MODE_SIZE,
                                                                clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
        DataTable dtCorpDetails = new DataTable();
        dtCorpDetails = objBusinessLayer.LoadGlobalDetail(arrEnumerr, intCorpId);
        if (dtCorpDetails.Rows.Count > 0)
        {
            hiddenDfltCurrencyMstrId.Value = dtCorpDetails.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
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

        if (HiddenSearchField.Value == "")
        {
            objEntityInsurance.OpenDate = DateTime.MinValue;
            objEntityInsurance.ToDate = DateTime.MinValue;
            objEntityInsurance.InsuranceTyp = 0;
            objEntityInsurance.ExpireDate = DateTime.MinValue;
            objEntityInsurance.Cancel_Status = 0;
            objEntityInsurance.InsuranceProvider = 0;
            objEntityInsurance.StatusSrch = 0;
        }
        else
        {
            string strHidden = HiddenSearchField.Value;
            string[] strSearchFields = strHidden.Split(',');
            string strFromDate = strSearchFields[0];
            string strToDate = strSearchFields[1];
            string strInsuranceTyp = strSearchFields[2];
            string EspireDate = strSearchFields[3];
            string strCbxStatus = strSearchFields[4];
            string strInsurncPrvdr = strSearchFields[5];
            string strGuartSts = strSearchFields[6];

            if (strFromDate != null && strFromDate != "")
            {
                objEntityInsurance.ExpiryFromDate = objCommon.textToDateTime(strFromDate);
            }
            if (strToDate != null && strToDate != "")
            {
                objEntityInsurance.ToDate = objCommon.textToDateTime(strToDate);
            }

            if (strInsuranceTyp != null && strInsuranceTyp != "")
            {
                objEntityInsurance.InsuranceTyp = Convert.ToInt32(ddlInsuranceTyp.SelectedItem.Value);
            }

            if (EspireDate != null && EspireDate != "")
            {
                objEntityInsurance.ExpireDate = objCommon.textToDateTime(EspireDate);
            }

            if (strCbxStatus == "1")
            {
                cbxCnclStatus.Checked = true;
            }
            else
            {
                cbxCnclStatus.Checked = false;
            }

            if (strInsurncPrvdr != null && strInsurncPrvdr != "")
            {
                if (ddlInsurncPrvdr.SelectedItem.Value != "--SELECT INSURANCE PROVIDER--")
                {
                    objEntityInsurance.InsuranceProvider = Convert.ToInt32(ddlInsurncPrvdr.SelectedItem.Value);
                }
            }

            if (strGuartSts != null && strGuartSts != "")
            {
                objEntityInsurance.StatusSrch = Convert.ToInt32(strGuartSts);
            }
            if (strCbxStatus == "1")
            {
                cbxCnclStatus.Checked = true;
            }
            else
            {
                cbxCnclStatus.Checked = false;
            }

            objEntityInsurance.Cancel_Status = Convert.ToInt32(strCbxStatus);
        }



        DataTable dtInsurance = objBusinessInsurance.ReadInsuranceList(objEntityInsurance);

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
        if (last < dtInsurance.Rows.Count)
        {

            btnNext.Enabled = true;
        }
        else
        {
            btnNext.Enabled = false;
        }

        string strHtm = ConvertDataTableToHTML(dtInsurance, intEnableModify, intEnableCancel, intEnableRecall, intEnableClose, intEnableRenew, intEnableConfirm);
        //Write to divReport
        divReport.InnerHtml = strHtm;
        string strPrintReport = ConvertDataTableForPrint(dtInsurance);
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
        string strTitle = "";
        strTitle = "Insurance List";
        DateTime datetm = DateTime.Now;
        string dat = "<B>Report Date: </B>" + datetm.ToString("R");
        string strHidden = "", FromDate = "", ToDate = "", ExpireDate = "", DeleteSts = "", InsrncPrvdr = "", GuranteSts = "", GuaranteType = "";


        if (HiddenSearchField.Value.ToString() != "")
        {

            strHidden = HiddenSearchField.Value;
            string[] strSearchFields = strHidden.Split(',');
            string strFromDate = strSearchFields[0];
            string strToDate = strSearchFields[1];
            string strInsuranceTyp = strSearchFields[2];
            string EspireDate = strSearchFields[3];
            string strCbxStatus = strSearchFields[4];
            string strInsurncPrvdr = strSearchFields[5];
            string strGuartSts = strSearchFields[6];

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
            if (strInsuranceTyp != null && strInsuranceTyp != "")
            {
                if (ddlInsuranceTyp.Items.FindByValue(strInsuranceTyp) != null)
                {
                    GuaranteType = "<B>Insurance Type : </B>" + ddlInsuranceTyp.SelectedItem.Text;
                }
            }

            if (strGuartSts != null && strGuartSts != "")
            {
                if (ddlGuaranteeStatus.Items.FindByValue(strGuartSts) != null)
                {
                    GuranteSts = "<B>Insurance Status : </B>" + ddlGuaranteeStatus.SelectedItem.Text;

                }
            }
        }
        else
        {
            GuranteSts = "<B>Insurance Status : </B>" + ddlGuaranteeStatus.SelectedItem.Text;
            GuaranteType = "<B>Insurance Type : </B>" + ddlInsuranceTyp.SelectedItem.Text;
        }
        clsCommonLibrary objClsCommon = new clsCommonLibrary();

        StringBuilder sbCap = new StringBuilder();

        string strCaptionTabstart = "<table class=\"PrintCaptionTable\" >";
        string strCaptionTabRprtDate = "", strCaptionTabTitle = "", strFromDteTitle = "", strToDateTitle = "", strGuaranteTypeTitle = "", strGuaranteMdeTitle = "", strBidingTitle = "",
            strCustOrSuplTitle = "", strExpireDateTitle = "", strInsrncPrvdrTitle = "", strGuranteStsTitle = "";
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

        string strCaptionTabstop = "</table>";
        string strPrintCaptionTable = strCaptionTabstart + strCaptionTabRprtDate + strCaptionTabTitle + strFromDteTitle + strToDateTitle + strGuaranteTypeTitle + strGuaranteMdeTitle + strBidingTitle + strCustOrSuplTitle + strExpireDateTitle + strInsrncPrvdrTitle + strGuranteStsTitle + strCaptionTabstop;

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
                strHtml += "<th class=\"thT\" style=\"width:10%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 2)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%; word-wrap:break-word; text-align: center;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 3)
            {
                strHtml += "<th class=\"thT\" style=\"width:12%;text-align: right; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 4)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: left; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 5)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 6)
            {
                strHtml += "<th class=\"thT\" style=\"width:8%;text-align: center; word-wrap:break-word;\">" + dt.Columns[intColumnHeaderCount].ColumnName + "</th>";
            }
            else if (intColumnHeaderCount == 7)
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
                    //string strNetAmount = dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();
                    //string strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);

                    //strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: right;\"  >" + strNetAmountWithComma.ToString() + "</td>";
                }
                else if (intColumnBodyCount == 4)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:12%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 5)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:9%;word-break: break-all; word-wrap:break-word;text-align: left;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 6)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:4%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
                else if (intColumnBodyCount == 7)
                {
                    strHtml += "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align: center;\"  >" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                }
            }
            strHtml += "</tr>";
        }

        strHtml += "</tbody>";

        strHtml += "</table>";

        sb.Append(strHtml);
        return sb.ToString();
    }


    protected void btnmodify_Click(object sender, EventArgs e)
    {

    }


    // START EVM-0031 //
    public void LoadInsuranceTypeMaster()
    {
        clsEntityLayerInsuranceMaster objEntityBnkGuarnte = new clsEntityLayerInsuranceMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityBnkGuarnte.CorpOffice_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            objEntityBnkGuarnte.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dt = new DataTable();
        dt = objBusinessInsurance.ReadInsuranceTypes(objEntityBnkGuarnte);
        if (dt.Rows.Count > 0)
        {
            ddlsearch.Items.Clear();
            ddlsearch.DataSource = dt;
            ddlsearch.DataTextField = "INSRC_TYPMSTR_NAME";
            ddlsearch.DataValueField = "INSRC_TYPMSTR_ID";
            ddlsearch.DataBind();
        }
        ddlsearch.Items.Insert(0, "--SELECT INSURANCE TYPE--");
    }
    // END EVM-0031 //


}