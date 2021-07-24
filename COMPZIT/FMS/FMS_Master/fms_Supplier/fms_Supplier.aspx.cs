using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit.BusineesLayer_FMS;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit;
using System.Data;
using System.Web.Services;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Globalization;
using BL_Compzit.BusinessLayer_FMS;

public partial class FMS_FMS_Master_fms_Supplier_fms_Supplier : System.Web.UI.Page
{
    int PurchaseAcntGrpId = 0;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["RFGP"] != null)
        {
            this.MasterPageFile = "~/MasterPage/MasterPageCompzitModal.master";

        }
        else
        {

            this.MasterPageFile = "~/MasterPage/MasterPageCompzit.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["FRMWRK_ID"] != null && Session["FRMWRK_ID"].ToString() == "2")
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
        }
        else
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }
        LoadAccountGrp();

        txtLedgrCode.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtLedgrCode.Attributes.Add("onkeydown", "return DisableEnter(event)");


        if (!IsPostBack)
        {
            hiddenContactDtls.Value = "";
            txtName.Focus();
            LoadCurrencies();
            LoadTCS();
            LoadTDS();
            LoadDDLAccountGrp();
            LoadCostGroup();
            LoadVendorCatgry();
            LoadLedgers("0");

            int intUserId = 0;
            HiddenAcntGrpChngSts.Value = "0";
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
           
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                             clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID , 
                                                               clsCommonLibrary.CORP_GLOBAL.FMS_VIEW_CODE_STS,
                                                               clsCommonLibrary.CORP_GLOBAL.FMS_CODE_FORMATE,
                                                               clsCommonLibrary.CORP_GLOBAL.FMS_CODE_NUMBER_FORMAT,
                                                               clsCommonLibrary.CORP_GLOBAL.PMS_CONTROLS_DISPLAY_STS,

                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                if (dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString() != "")
                {
                    hiddenTaxEnabled.Value = dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString();
                }
                if (dtCorpDetail.Rows[0]["FMS_VIEW_CODE_STS"].ToString() != "")
                {
                    HiddenCodeSts.Value = dtCorpDetail.Rows[0]["FMS_VIEW_CODE_STS"].ToString();
                }
                 if (dtCorpDetail.Rows[0]["FMS_CODE_FORMATE"].ToString() != "")
                 {
                     HiddenCodeFormate.Value = dtCorpDetail.Rows[0]["FMS_CODE_FORMATE"].ToString();
                 }
                 if (dtCorpDetail.Rows[0]["FMS_CODE_NUMBER_FORMAT"].ToString() != "")
                 {
                     if (dtCorpDetail.Rows[0]["FMS_CODE_NUMBER_FORMAT"].ToString() == "1")
                     {
                         txtLedgrCode.Attributes.Add("onkeypress", "return isNumber(event)");
                         txtLedgrCode.Attributes.Add("onkeydown", "return isNumber(event)");
                         txtLedgrCode.Attributes.Add("onblur", "RemoveNaN_OnBlur('cphMain_txtLedgrCode')");
                     }
                     hiddenCodeNumberFrmt.Value = dtCorpDetail.Rows[0]["FMS_CODE_NUMBER_FORMAT"].ToString();
                 }
                 if (dtCorpDetail.Rows[0]["PMS_CONTROLS_DISPLAY_STS"].ToString() != "")
                 {
                     hiddenPMSDisplaySts.Value = dtCorpDetail.Rows[0]["PMS_CONTROLS_DISPLAY_STS"].ToString();
                 }

            }

            if (HiddenCodeFormate.Value == "1")
            {

              //  txtLedgrCode.Enabled = true;
               // txtCostCntrCode.Enabled = true;

            }
            else
            {
                txtLedgrCode.Enabled = false;
                //txtCostCntrCode.Enabled = false;
                txtCostCntrCode.ReadOnly = true;


            }



            if (HiddenCodeSts.Value == "1")
            {
                //divCodeSts.Attributes["style"] = "display: block;";


            }
            else
            {
                divCodeSts.Attributes["style"] = "display: none;";
                divCode.Attributes["style"] = "display: none;";
                

            }

         

            if (hiddenTaxEnabled.Value == "0")//tax not enabled
            {
                DivTdcTcs.Visible = false;
            }
            else
            {
                DivTdcTcs.Visible = true;//tax  enabled

            }




            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumerR = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetailL = new DataTable();
            dtCorpDetailL = objBusiness.LoadGlobalDetail(arrEnumerR, intCorpId);
            if (dtCorpDetailL.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetailL.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetailL.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }


            if (Request.QueryString["Id"] != null)
            {

                lblEntry.Text = "Edit Supplier";
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                bttnsave.Visible = false;
                btnSaveAndClose.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
                btnUpdateAndClose.Visible = true;
                btnClear.Visible = false;

                LoadLedgers(strId);

                Update(strId, 0);


            }
            else if (Request.QueryString["ViewId"] != null)
            {
                HiddenViewSts.Value = "1";
                lblEntry.Text = "View Supplier";
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                bttnsave.Visible = false;
                btnUpdate.Visible = false;
                btnCancel.Visible = true;
                btnSaveAndClose.Visible = false;
                btnUpdateAndClose.Visible = false;
                btnClear.Visible = false;
              //  cbxLedgerSts.Disabled = true;

                LoadLedgers(strId);

                Update(strId, 1);
                txtLedgrCode.Enabled = false;
                //txtCostCntrCode.Enabled = false;
                txtCostCntrCode.ReadOnly = true;
            }

            else
            {
                divCodeSts.Attributes["style"] = "display: none;";

                lblEntry.Text = "Add Supplier";
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
            }
            if (Request.QueryString["RFGP"] != null)
            {
                HiddenPurchaseMode.Value = "1";

                divList.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                btnSaveAndClose.Visible = false;
                bttnsave.Visible = true;
                btnClear.Visible = false;
                btnCancel.Visible = false;
                cbxLedgerSts.Checked = true;
                cbxLedgerSts.Disabled = true;
                DivConsdrLdgr.Disabled = true;
                divLinkSection.Visible = false;
                DivContainer.Attributes["style"] = "padding-top:18px;padding-bottom: 33px;width: 1024px;";
                if (Request.QueryString["SULMSTR"] != null)
                {
                    txtName.Text = Request.QueryString["SULMSTR"].ToString();
                }
                if (Request.QueryString["RFGP"] == "SUPID")
                {
                    cbxLedgerSts.Checked = false;
                    cbxLedgerSts.Disabled = false;
                }
            }
            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdMsg", "SuccessUpdMsg();", true);
                }
                else if (strInsUpd == "UpdCancl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CanclUpdMsg", "CanclUpdMsg();", true);
                }
            }


          
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Supplier);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

              HiddenBusinessSpecific.Value = "0";
               HiddenAccountSpecific.Value = "0";
                HiddenAccountGrp.Value = "0";
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString())
                    {
                        HiddenBusinessSpecific.Value = "1";
                    }
                      if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString())
                    {
                        HiddenAccountSpecific.Value = "1";
                    }

                    
                }
            }


            if (HiddenBusinessSpecific.Value == "1" && HiddenAccountSpecific.Value == "0")
            {
                
                divAccountSpecific.Visible = false;
            }
            else if (HiddenBusinessSpecific.Value == "1" && HiddenAccountSpecific.Value == "1")
            {
                
                divAccountSpecific.Visible = true;
            }
            else if (HiddenBusinessSpecific.Value == "0" && HiddenAccountSpecific.Value == "1")
            {
                
                divAccountSpecific.Visible = true;
            }
            else if (HiddenBusinessSpecific.Value == "0" && HiddenAccountSpecific.Value == "0")
            {
                
                divAccountSpecific.Visible = true;
            }

        }
 
    }

    public void LoadVendorCatgry()
    {
        clsEntitySupplier objEntitySupplier = new clsEntitySupplier();
        clsBusinessLayerSupplier objBusinessSupplier = new clsBusinessLayerSupplier();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntitySupplier.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntitySupplier.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdiv = objBusinessSupplier.ReadVendorCatgry(objEntitySupplier);
        if (dtdiv.Rows.Count > 0)
        {
            ddlVendorCategory.DataSource = dtdiv;
            ddlVendorCategory.DataTextField = "VNDRCTGRY_NAME";
            ddlVendorCategory.DataValueField = "VNDRCTGRY_ID";
            ddlVendorCategory.DataBind();
        }
        ddlVendorCategory.Items.Insert(0, "--SELECT VENDOR CATEGORY--");

    }

    public void LoadCostGroup()
    {
        clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();
        clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            objEntity.UserId = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            objEntity.Corp_Id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Org_Id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdiv = objBusinessCostCenter.ReadCostGroup(objEntity);
        if (dtdiv.Rows.Count > 0)
        {
            ddlCC.DataSource = dtdiv;
            ddlCC.DataTextField = "COSTGRP_NAME";

            ddlCC.DataValueField = "COSTGRP_ID";
            ddlCC.DataBind();
        }
        ddlCC.Items.Insert(0, "--SELECT COST GROUP--");

    }
    public void LoadDDLAccountGrp()
    {
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLedger.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLedger.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLedger.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityLedger.ActModeId = Convert.ToInt32(clsCommonLibrary.ASMOD_ID.supplier);
        DataTable dtdiv = objBusinessLedger.ReadAccountGrpsLedgr(objEntityLedger);
        if (dtdiv.Rows.Count > 0)
        {
            ddlAccountGrp.DataSource = dtdiv;
            ddlAccountGrp.DataTextField = "ACNT_GRP_NAME";
            ddlAccountGrp.DataValueField = "ACNT_GRP_ID";
            ddlAccountGrp.DataBind();
        }
        ddlAccountGrp.Items.Insert(0, "--SELECT ACCOUNT GROUP--");

    }
    public void LoadAccountGrp()
    {
        clsBusinessLayer objBusinessCommon = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLedger.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLedger.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLedger.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityLedger.ActModeId = Convert.ToInt32(clsCommonLibrary.ASMOD_ID.supplier);
        objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYCREDITR));
        DataTable dtdiv = objBusinessLedger.ReadAccountGrps(objEntityLedger);
       // DataTable dtdiv = objBusinessCommon.ReadAccountGrps(objEntityCommon);
        if (dtdiv.Rows.Count > 0)
        {
            PurchaseAcntGrpId = Convert.ToInt32(dtdiv.Rows[0]["ACNT_GRP_ID"].ToString());
            HiddenAcntGrpSts.Value = "0";
            HiddenDefaultAcntGrpId.Value = dtdiv.Rows[0]["ACNT_GRP_ID"].ToString();
        }
        else
        {
            HiddenAcntGrpSts.Value = "1";
        }
        if (dtdiv.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SundryDebtorSelect", "SundryDebtorSelect();", true);
        }
    }

    public void LoadLedgers(string Id)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

        clsEntitySales ObjEntitySales = new clsEntitySales();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySales.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySales.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntitySales.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntitySales.LedgerType = "SALE";
        objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYCREDITR));

        DataTable dtlCstmrLedger = objBusiness.ReadLedgers(objEntityCommon);

        foreach (DataRow dtRow in dtlCstmrLedger.Rows)
        {
            if (Id != "" && dtRow["LDGR_ID"].ToString() == Id)
            {
                dtRow.Delete();
            }
        }

        dtlCstmrLedger.AcceptChanges();

        ddlLedger.Items.Clear();
        if (dtlCstmrLedger.Rows.Count > 0)
        {
            ddlLedger.Items.Clear();
            ddlLedger.DataSource = dtlCstmrLedger;
            ddlLedger.DataTextField = "LDGR_NAME";
            ddlLedger.DataValueField = "LDGR_ID";
            ddlLedger.DataBind();
        }
        ddlLedger.Items.Insert(0, "--SELECT SUPPLIER--");
        if (dtlCstmrLedger.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SundryCreditorSelect", "SundryCreditorSelect();", true);
        }

    }
       [WebMethod]
    public static string CrateCodeFormate(string orgID, string corptID, string CstGrpId)
    {
        string sts = "";
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();



        int intCorpId = 0;
        if (corptID != null)
        {

            intCorpId = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);

        }

        if (orgID != null)
        {

            objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);

        }

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER);
        DataTable dtFormate = objBusinessLayer.ReadCodeFormate(objEntityCommon);
        string refFormatByDiv = "";
        string strRealFormat = "";

        DataTable dt = new DataTable();




        if (dtFormate.Rows.Count > 0)
        {



            // CodeFormate = NaureCode.ToString() + dtNextNumber;
            if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
            {
                refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
                string strReferenceFormat = "";
                strReferenceFormat = refFormatByDiv;
                string[] arrReferenceSplit = strReferenceFormat.Split('*');
                int intArrayRowCount = arrReferenceSplit.Length;
                int Codecount = 0;
                strRealFormat = refFormatByDiv.ToString();

                if (strRealFormat.Contains("#NUM#"))
                {
                    string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);


                    strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);


                }
                if (strRealFormat.Contains("#CSTGRP#"))
                {
                    string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);


                    strRealFormat = strRealFormat.Replace("#CSTGRP#", CstGrpId);


                }
                if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
                {
                    Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
                }

                int k = strRealFormat.Length;
                if (k < Codecount)
                {
                    int Difrnce = Codecount - k;
                    k = k + Difrnce;
                    //  hello.PadLeft(50, '#');
                    strRealFormat = strRealFormat.PadLeft(k, '0');
                }


                sts = strRealFormat;
            }

        }

        return sts.ToString();
    }

    //---------evm 004
       [WebMethod]
       public static string CreateCodeFormate(string orgID, string corptID, string CstGrpId)
       {
           string sts = "";
           clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
           clsCommonLibrary objCommon = new clsCommonLibrary();
           clsEntityCommon objEntityCommon = new clsEntityCommon();
           clsBusinessLyer_Cost_Group objBusinessCOST = new clsBusinessLyer_Cost_Group();
           clsEntityLayer_Cost_Group objEntity = new clsEntityLayer_Cost_Group();

           int intCorpId = 0;
           if (corptID != null)
           {
               intCorpId = Convert.ToInt32(corptID);
               objEntityCommon.CorporateID = Convert.ToInt32(corptID);
               objEntity.Corp_Id = Convert.ToInt32(corptID);
           }
           if (orgID != null)
           {
               objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
               objEntity.Org_Id = Convert.ToInt32(orgID);
           }

           objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER_START_REf );
           string strRealFormat = "";
           objEntity.CostId = Convert.ToInt32(CstGrpId);
           int costcntrnextnum = 0;
           DataTable dtcostgrp = new DataTable();
           dtcostgrp = objBusinessCOST.ReadCOSTById(objEntity);
           if (dtcostgrp.Rows.Count > 0)
           {
               costcntrnextnum = Convert.ToInt32(dtcostgrp.Rows[0]["COSTGRP_NEXTID_COSTCNTR"]);
               if (costcntrnextnum == 0)
               {

                   objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER_START_REf ); ;
                   DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
                   if (dtDefaltModData.Rows.Count > 0)
                   {
                       costcntrnextnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"]);
                       strRealFormat = dtcostgrp.Rows[0]["COSTGRP_CODE"].ToString() + Convert.ToString(costcntrnextnum);

                   }

               }
               else
               {
                   strRealFormat = dtcostgrp.Rows[0]["COSTGRP_CODE"].ToString() + Convert.ToString(costcntrnextnum);
               }
           }

           sts = strRealFormat;
           return sts.ToString();
       }
       public void CreateCostCntrCode()
       {
           clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
           clsEntityCommon objEntityCommon = new clsEntityCommon();
           clsBusinessLyer_Cost_Group objBusinessCOST = new clsBusinessLyer_Cost_Group();
           clsEntityLayer_Cost_Group objEntity = new clsEntityLayer_Cost_Group();
           if (Session["USERID"] != null)
           {

           }
           else if (Session["USERID"] == null)
           {
               Response.Redirect("/Default.aspx");
           }
           int intCorpId = 0;
           if (Session["CORPOFFICEID"] != null)
           {

               intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
               objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
               objEntity.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
           }


           else if (Session["CORPOFFICEID"] == null)
           {
               Response.Redirect("/Default.aspx");
           }
           if (Session["ORGID"] != null)
           {

               objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
               objEntity.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
           }
           else if (Session["ORGID"] == null)
           {
               Response.Redirect("/Default.aspx");
           }
           objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER);
           string strRealFormat = "";
           objEntity.CostId = Convert.ToInt32(ddlCC.SelectedItem.Value);
           int costcntrnextnum = 0;
           DataTable dtcostgrp = new DataTable();
           dtcostgrp = objBusinessCOST.ReadCOSTById(objEntity);
           if (dtcostgrp.Rows.Count > 0)
           {
               costcntrnextnum = Convert.ToInt32(dtcostgrp.Rows[0]["COSTGRP_NEXTID_COSTCNTR"]);
               if (costcntrnextnum == 0)
               {

                   objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER_START_REf ); ;
                   DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
                   if (dtDefaltModData.Rows.Count > 0)
                   {
                       costcntrnextnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"]);
                       strRealFormat = dtcostgrp.Rows[0]["COSTGRP_CODE"].ToString() + Convert.ToString(costcntrnextnum);

                   }

               }
               else
               {

                   strRealFormat = dtcostgrp.Rows[0]["COSTGRP_CODE"].ToString() + Convert.ToString(costcntrnextnum);
               }
           }

           txtCostCntrCode.Text = strRealFormat;
       }
    //---------------
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string LoadLedgerCode(string  strUserID,string  ActGrpId,string  strOrgIdID,string ldgrsts,string  strCorpID)
    {
        string sts = "";
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();//evm 0044
        clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
        int intCorpId = 0;
        if (strCorpID != null)
        {

            intCorpId = Convert.ToInt32(strCorpID);
            objEntityCommon.CorporateID = Convert.ToInt32(strCorpID);
            objEntityLedger.Corp_Id = Convert.ToInt32(strCorpID);
            objEntityAccountGroup.CorpId = Convert.ToInt32(strCorpID); ;
        }

        if (strOrgIdID != null)
        {

            objEntityCommon.Organisation_Id = Convert.ToInt32(strOrgIdID);
            objEntityLedger.Org_Id = Convert.ToInt32(strOrgIdID);
            objEntityAccountGroup.OrgId = Convert.ToInt32(strOrgIdID);
        }
         
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_LEDGER_MASTER);
        string strRealFormat = "";
                
            //evm 0044------

        if (ldgrsts == "1")
        {
            if (ActGrpId != "" && ActGrpId != "--SELECT ACCOUNT GROUP--")
            {
                objEntityLedger.SubLedgerStatus = 0;
                objEntityLedger.AccountGrpId = Convert.ToInt32(ActGrpId);
                objEntityAccountGroup.AccountGrpId = Convert.ToInt32(ActGrpId);
                //evm 0044------

                int subldgrnum = 0;
                DataTable dtledger = objBusinessAcountGrp.LoadAccountGroupBYId(objEntityAccountGroup);
                if (dtledger.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtledger.Rows[0]["ACNT_NEXTID_LEDGER"].ToString()) == 0)
                    {
                        objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.LEDGER_START_REF ); ;
                        objEntityCommon.CorporateID = objEntityLedger.Corp_Id;
                        objEntityCommon.Organisation_Id = objEntityLedger.Org_Id;
                        DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
                        if (dtDefaltModData.Rows.Count > 0)
                        {
                            subldgrnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"].ToString());
                            strRealFormat = dtledger.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subldgrnum);
                        }
                    }
                    else
                    {
                        subldgrnum = Convert.ToInt32(dtledger.Rows[0]["ACNT_NEXTID_LEDGER"].ToString());
                        strRealFormat = dtledger.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subldgrnum);
                    }
                }
            }
        }
        else  //evm 0044------
        {
            if (ActGrpId != "0")
            {
                int subldgrnextnum = 0;
                objEntityLedger.SubLedgerId = Convert.ToInt32(ActGrpId);
                DataTable dtactgroup = objBusinessLedger.LoadLedgerBYId(objEntityLedger);
                if (dtactgroup.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dtactgroup.Rows[0]["LDGR_NEXTID_LEDGER"].ToString()) == 0)
                    {
                        objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.SUB_LEDGER_START_REf ); ;
                        objEntityCommon.CorporateID = objEntityLedger.Corp_Id;
                        objEntityCommon.Organisation_Id = objEntityLedger.Org_Id;
                        DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
                        if (dtDefaltModData.Rows.Count > 0)
                        {
                            subldgrnextnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"].ToString());
                            strRealFormat = dtactgroup.Rows[0]["LDGR_CODE"].ToString() + Convert.ToString(subldgrnextnum);
                        }
                    }
                    else
                    {
                        subldgrnextnum = Convert.ToInt32(dtactgroup.Rows[0]["LDGR_NEXTID_LEDGER"].ToString());
                        strRealFormat = dtactgroup.Rows[0]["LDGR_CODE"].ToString() + Convert.ToString(subldgrnextnum);
                    }
                }
            }
        }

                  objEntityLedger.LdgrCode = strRealFormat;
                  sts = strRealFormat;
                  return sts.ToString();
    

        //if (dtFormate.Rows.Count > 0)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        string StrAcntGrpId = "";


        //        int NaureCode = 0;
        //        string CodeFormate = "";
        //        int intNature = Convert.ToInt32(dt.Rows[0]["ACNT_NATURE_STS"].ToString());
        //        StrAcntGrpId = dt.Rows[0]["ACNT_GRP_ID"].ToString();

        //        if (intNature == 0)
        //        {
        //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Asset);
        //        }
        //        else if (intNature == 1)
        //        {
        //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Liability);
        //        }
        //        else if (intNature == 2)
        //        {
        //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Expense);
        //        }
        //        else if (intNature == 3)
        //        {
        //            NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Income);
        //        }



        //        CodeFormate = NaureCode.ToString();

        //        // CodeFormate = NaureCode.ToString() + dtNextNumber;
        //        if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
        //        {
        //            refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
        //            string strReferenceFormat = "";
        //            strReferenceFormat = refFormatByDiv;
        //            string[] arrReferenceSplit = strReferenceFormat.Split('*');
        //            int intArrayRowCount = arrReferenceSplit.Length;
        //            int Codecount = 0;
        //            strRealFormat = refFormatByDiv.ToString();
        //            if (strRealFormat.Contains("#NAT#"))
        //            {
        //                strRealFormat = strRealFormat.Replace("#NAT#", NaureCode.ToString());


        //            }
        //            if (strRealFormat.Contains("#NUM#"))
        //            {
        //                string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);


        //                strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);


        //            }
        //            if (strRealFormat.Contains("#ACNTGRP#"))
        //            {
        //                string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);


        //                strRealFormat = strRealFormat.Replace("#ACNTGRP#", StrAcntGrpId);


        //            }
        //            if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
        //            {
        //                Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
        //            }

        //            int k = strRealFormat.Length;
        //            if (k < Codecount)
        //            {
        //                int Difrnce = Codecount - k;
        //                k = k + Difrnce;
        //                //  hello.PadLeft(50, '#');
        //                strRealFormat = strRealFormat.PadLeft(k, '0');
        //            }


                   
            //    }
            //}
        //}

        
    }



    public void LoadTDS()
    {
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLedger.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLedger.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLedger.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdiv = objBusinessLedger.ReadTDS(objEntityLedger);
        if (dtdiv.Rows.Count > 0)
        {
            ddlTDS.DataSource = dtdiv;
            ddlTDS.DataTextField = "TX_DDCTN_NAME";
            ddlTDS.DataValueField = "TX_DDCTN_ID";
            ddlTDS.DataBind();
        }
        ddlTDS.Items.Insert(0, "--SELECT TDS--");

    }
    public void LoadTCS()
    {
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLedger.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLedger.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLedger.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdiv = objBusinessLedger.ReadTCS(objEntityLedger);
        if (dtdiv.Rows.Count > 0)
        {
            ddlTCS.DataSource = dtdiv;
            ddlTCS.DataTextField = "TX_CLTN_NAME";
            ddlTCS.DataValueField = "TX_CLTN_ID";
            ddlTCS.DataBind();
        }
        ddlTCS.Items.Insert(0, "--SELECT TCS--");

    }

    public void LoadCurrencies()
    {
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLedger.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLedger.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLedger.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdiv = objBusinessLedger.ReadCurrencies(objEntityLedger);
        if (dtdiv.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtdiv;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();
            ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
            ddlCurrency.ClearSelection();
            ddlCurrency.Items.FindByValue(dtdiv.Rows[0][2].ToString()).Selected = true;
        }

    }
    //evm 0044
    public void createCodeByLevel(int orgId, int corpId)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (cbxSubLedger.Checked == false)
        {

            clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
            clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();

            objEntityAccountGroup.CorpId = corpId;
            objEntityAccountGroup.OrgId = orgId;
            if (ddlAccountGrp.SelectedItem.Text != "--SELECT ACCOUNT GROUP--")
            {
                objEntityAccountGroup.AccountGrpId = Convert.ToInt32(ddlAccountGrp.SelectedItem.Value);
            }
            else
            {
                objEntityAccountGroup.AccountGrpId = PurchaseAcntGrpId;
            }
            int subldgrnum = 0;
            DataTable dtledger = objBusinessAcountGrp.LoadAccountGroupBYId(objEntityAccountGroup);
            if (dtledger.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtledger.Rows[0]["ACNT_NEXTID_LEDGER"].ToString()) == 0)
                {
                    objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.LEDGER_START_REF ); ;
                    objEntityCommon.CorporateID = corpId;
                    objEntityCommon.Organisation_Id = orgId;
                    DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
                    if (dtDefaltModData.Rows.Count > 0)
                    {
                        subldgrnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"].ToString());
                        txtLedgrCode .Text = dtledger.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subldgrnum);
                    }
                }
                else
                {
                    subldgrnum = Convert.ToInt32(dtledger.Rows[0]["ACNT_NEXTID_LEDGER"].ToString());
                    txtLedgrCode.Text = dtledger.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subldgrnum);
                }
            }
        }
        else if (cbxSubLedger.Checked == true)
        {
            clsEntityLedger objEntityLedger = new clsEntityLedger();
            clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();

            objEntityLedger.Corp_Id = corpId;
            objEntityLedger.Org_Id = orgId;
            objEntityLedger.SubLedgerStatus = 1;
            objEntityLedger.SubLedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
            objEntityLedger.LedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);

            int subldgrnextnum = 0;
            DataTable dtactgroup = objBusinessLedger.LoadLedgerBYId(objEntityLedger);
            if (dtactgroup.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtactgroup.Rows[0]["LDGR_NEXTID_LEDGER"].ToString()) == 0)
                {
                    objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.SUB_LEDGER_START_REf ); ;
                    objEntityCommon.CorporateID = objEntityLedger.Corp_Id;
                    objEntityCommon.Organisation_Id = objEntityLedger.Org_Id;
                    DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
                    if (dtDefaltModData.Rows.Count > 0)
                    {
                        subldgrnextnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"].ToString());
                        txtLedgrCode.Text = dtactgroup.Rows[0]["LDGR_CODE"].ToString() + Convert.ToString(subldgrnextnum);
                    }
                }
                else
                {
                    subldgrnextnum = Convert.ToInt32(dtactgroup.Rows[0]["LDGR_NEXTID_LEDGER"].ToString());
                    txtLedgrCode.Text = dtactgroup.Rows[0]["LDGR_CODE"].ToString() + Convert.ToString(subldgrnextnum);
                }
            }
        }
    }
    protected void bttnsave_Click(object sender, EventArgs e)
    {
        try
        {
            int f = 0;
            Button clickedButton = sender as Button;
            clsEntitySupplier objEntitySupplier = new clsEntitySupplier();
            clsBusinessLayerSupplier objBusinessSupplier = new clsBusinessLayerSupplier();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntitySupplier.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntitySupplier.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntitySupplier.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objEntitySupplier.SupplierName = txtName.Text.Trim();
            objEntitySupplier.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            objEntitySupplier.Addess = txtAddress.Text.Trim();
            if (txtAddress2.Text.Trim() != "")
            {
                objEntitySupplier.AddessTwo = txtAddress2.Text.Trim();
            }
            if (txtAddress3.Text.Trim() != "")
            {
                objEntitySupplier.AddessThree = txtAddress3.Text.Trim();
            }
            if (txtCreditLimit.Text.Trim() != "")
            {
                objEntitySupplier.CreditLimit = Convert.ToDecimal(txtCreditLimit.Text.Trim());
            }
            if (txtCreditPeriod.Text.Trim() != "")
            {
                objEntitySupplier.Days = Convert.ToInt32(txtCreditPeriod.Text.Trim());
            }
            if (cbxStatus.Checked == true)
            {
                objEntitySupplier.Status = 1;
            }
            if (ddlVendorCategory.SelectedItem.Value != "" && ddlVendorCategory.SelectedItem.Value != "--SELECT VENDOR CATEGORY--")
            {
                objEntitySupplier.VendorCatgry = Convert.ToInt32(ddlVendorCategory.SelectedItem.Value);
            }
            if (txtRating.Text != "")
            {
                objEntitySupplier.Rating = Convert.ToDecimal(txtRating.Text);
            }

            List<clsEntitySupplierContact> objEntitySupplierCntctList = new List<clsEntitySupplierContact>();

            int Rows = 0;
            if (hiddenContactRows.Value != "")
            {
                Rows = Convert.ToInt32(hiddenContactRows.Value);
            }

            if (Rows > 0)
            {
                for (int i = 0; i <= Rows; i++)
                {
                    clsEntitySupplierContact objEntityContact = new clsEntitySupplierContact();

                    if (Request.Form["txtCntctName" + i] != null && Request.Form["txtCntctAddress" + i] != null)
                    {
                        if (Request.Form["txtCntctName" + i] != null)
                        {
                            objEntityContact.ContactName = Request.Form["txtCntctName" + i];
                        }
                        if (Request.Form["txtCntctAddress" + i] != null)
                        {
                            objEntityContact.ContactAddress = Request.Form["txtCntctAddress" + i];
                        }
                        if (Request.Form["txtCntctMobile" + i] != null)
                        {
                            objEntityContact.ContactMobile = Request.Form["txtCntctMobile" + i];
                        }
                        if (Request.Form["txtCntctPhone" + i] != null)
                        {
                            objEntityContact.ContactPhone = Request.Form["txtCntctPhone" + i];
                        }
                        if (Request.Form["txtCntctWebsite" + i] != null)
                        {
                            objEntityContact.ContactWebsite = Request.Form["txtCntctWebsite" + i];
                        }
                        if (Request.Form["txtCntctEmail" + i] != null)
                        {
                            objEntityContact.ContactEmail = Request.Form["txtCntctEmail" + i];
                        }

                        objEntitySupplierCntctList.Add(objEntityContact);
                    }
                }
            }

            DataTable dtSup = objBusinessSupplier.CheckDupName(objEntitySupplier);
            if (dtSup.Rows.Count > 0)
            {
                f = 1;
            }
            if (cbxLedgerSts.Checked == true)
            {
                objEntitySupplier.LedgerSts = 1;

                //Start:-Save to ledger table
                clsEntityLedger objEntityLedger = new clsEntityLedger();
                clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLedger.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityLedger.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["USERID"] != null)
                {
                    objEntityLedger.User_Id = Convert.ToInt32(Session["USERID"]);
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                objEntityLedger.LedgerName = txtName.Text;


                //evm 0044
                createCodeByLevel(objEntityLedger.Org_Id, objEntityLedger.Corp_Id);
                objEntityLedger.LdgrCode = txtLedgrCode.Text.Trim();
                if (cbxSubLedger.Checked == true)
                {
                    if (ddlLedger.SelectedItem.Text != "--SELECT SUPPLIER--")
                    {
                        objEntityLedger.SubLedgerStatus = 1;
                        objEntityLedger.SubLedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
                        objEntityLedger.LedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
                        createCodeByLevel(objEntityLedger.Org_Id, objEntityLedger.Corp_Id);//evm 0044
                        objEntityLedger.LdgrCode = txtLedgrCode.Text.Trim();
                    }

                }


                else
                {
                    if (ddlAccountGrp.SelectedItem.Text != "--SELECT ACCOUNT GROUP--")
                    {
                        objEntityLedger.AccountGrpId = Convert.ToInt32(ddlAccountGrp.SelectedItem.Value);
                    }
                    else
                    {
                        objEntityLedger.AccountGrpId = PurchaseAcntGrpId;
                    }
                }



                if (HiddenCodeSts.Value != "")
                {
                    objEntityLedger.CodePrsntSts = Convert.ToInt32(HiddenCodeSts.Value);
                }

                if (HiddenCodeFormate.Value != "")
                {
                    objEntityLedger.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
                }
                if (hiddenCodeNumberFrmt.Value != "")
                {
                    objEntityLedger.CodeFormatNumber = Convert.ToInt32(hiddenCodeNumberFrmt.Value);
                }

             


                // objEntityLedger.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                objEntityLedger.LedgerAddess = txtAddress.Text.Trim();
                if (hiddenTaxEnabled.Value == "1")
                {
                    if (HiddenAccountSpecific.Value == "1")
                    {
                        objEntityLedger.TxEnabledSts = 1;
                        if (radioTDSyes.Checked == false)
                        {
                            objEntityLedger.TDSstatus = 1;
                        }
                        else
                        {
                            objEntityLedger.TDSid = Convert.ToInt32(ddlTDS.SelectedItem.Value);
                        }
                        if (radioTCSyes.Checked == false)
                        {
                            objEntityLedger.TCSstatus = 1;
                        }
                        else
                        {
                            objEntityLedger.TCSid = Convert.ToInt32(ddlTCS.SelectedItem.Value);
                        }
                    }

                }
                else
                {
                    objEntityLedger.TxEnabledSts = 0;
                }

                if (cbxCsCntrSts.Checked == true)
                {
                    objEntityLedger.CostCenterSts = 0;
                }
                else
                {
                    objEntityLedger.CostCenterSts = 1;
                }

                if (cbxStatus.Checked == true)
                {
                    objEntityLedger.Status = 1;
                }
                if (txtblnce.Text.Trim() != "")
                {
                    if (typdebit.Checked)
                    {
                        objEntityLedger.DebitBalance = Convert.ToDecimal(txtblnce.Text.Trim());
                        //  objEntityLedger.CreditBalance = objEntityLedger.CreditBalance + Convert.ToDecimal(txtblnce.Text.Trim());
                        objEntityLedger.LedgerStatus = 0;
                    }
                    else
                    {
                        objEntityLedger.DebitBalance = Convert.ToDecimal(txtblnce.Text.Trim());
                        //  objEntityLedger.CreditBalance = objEntityLedger.CreditBalance - Convert.ToDecimal(txtblnce.Text.Trim());
                        objEntityLedger.LedgerStatus = 1;

                    }
                }
                //evm 0044 12/02
                if (txtCreditLimit.Text != "" && txtCreditLimit.Text != null)
                    objEntityLedger.CreditLimit = Convert.ToDecimal(txtCreditLimit.Text);

                if (txtCreditPeriod.Text != "" && txtCreditPeriod.Text != null)
                    objEntityLedger.CreditPeriod = Convert.ToInt32(txtCreditPeriod.Text);

              //---------------

                List<clsEntityLedger> objEntitySubLedgerList = new List<clsEntityLedger>();

                if (cbxLedgerSts.Checked == true)
                {
                    objEntityLedger.LedgerId = objEntityLedger.SubLedgerId;

                    DataTable dtSubLdgr = objBusinessLedger.ReadSubLedgers(objEntityLedger);
                    if (dtSubLdgr.Rows.Count > 0)
                    {
                        foreach (DataRow dtSubRow in dtSubLdgr.Rows)
                        {
                            clsEntityLedger objEntitySubLdgr = new clsEntityLedger();
                            objEntitySubLdgr.SubLedgerId = Convert.ToInt32(dtSubRow["LDGR_ID"].ToString());
                            objEntitySubLdgr.Level = Convert.ToInt32(dtSubRow["LEVEL"].ToString());
                            objEntityLedger.Level = objEntitySubLdgr.Level;
                            objEntitySubLedgerList.Add(objEntitySubLdgr);
                        }
                    }
                }

                objEntityLedger.PageSts = 1;
                DataTable dt = objBusinessLedger.CheckDupName(objEntityLedger);
                string strCodeCount = objBusinessLedger.CheckCodeDuplicatn(objEntityLedger);




                if (dt.Rows.Count == 0 && f == 0 && strCodeCount == "0")
                {

                    //Start:-Cost Center insert
                    string strNameCount = "0";
                    string strCstCodeCount = "0";
                    if (objEntityLedger.CostCenterSts == 0)
                    {
                        clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
                        clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();
                        int intCorpId = 0, intOrgId = 0, intUserId = 0;
                        if (Session["USERID"] != null)
                        {
                            intUserId = Convert.ToInt32(Session["USERID"]);
                            objEntity.UserId = intUserId;
                        }
                        else if (Session["USERID"] == null)
                        {
                            Response.Redirect("/Default.aspx");
                        }
                        if (Session["CORPOFFICEID"] != null)
                        {
                            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                            objEntity.Corp_Id = intCorpId;
                        }
                        else if (Session["CORPOFFICEID"] == null)
                        {
                            Response.Redirect("/Default.aspx");
                        }
                        if (Session["ORGID"] != null)
                        {
                            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                            objEntity.Org_Id = intOrgId;
                        }
                        else if (Session["ORGID"] == null)
                        {
                            Response.Redirect("/Default.aspx");
                        }

                        if (HiddenCodeSts.Value != "")
                        {
                            objEntity.CodePrsntSts = Convert.ToInt32(HiddenCodeSts.Value);
                        }

                        if (HiddenCodeFormate.Value != "")
                        {
                            objEntity.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
                        }
                        CreateCostCntrCode();//evm 0044
                        objEntity.GrpCode = txtCostCntrCode.Text.Trim();



                        objEntity.grpId = Convert.ToInt32(ddlCC.SelectedItem.Value.ToString());
                        objEntity.Name = txtName.Text.Trim();
                        objEntity.Status = 1;
                        if (rdExpense.Checked == true)
                        {
                            objEntity.Nature = 1;
                        }

                        if (txtblnce.Text != "" && txtblnce.Text != null)
                        {
                            objEntity.Balance = Convert.ToDecimal(txtblnce.Text.ToString());
                            if (typdebit.Checked == true)
                            {
                                objEntity.DCStatus = 0;
                            }
                            else
                            {
                                objEntity.DCStatus = 1;
                            }

                        }
                        strNameCount = objBusinessCostCenter.CheckCostName(objEntity);


                        strCstCodeCount = objBusinessCostCenter.CheckCodeDuplicatn(objEntity);

                        if (strNameCount == "0" && strCstCodeCount == "0")
                        {
                            string costID = objBusinessCostCenter.InsertCostCenter(objEntity);
                            objBusinessCostCenter.UpdateCostGroupNextId(objEntity);//evm 0044
                            objEntityLedger.CostCenterID = Convert.ToInt32(costID);
                        }
                        else
                        {
                            if (strNameCount != "0")
                            {
                                f = 2;
                            }

                            else if (strCstCodeCount != "0")
                            {
                                f = 5;
                            }
                        }
                    }
                    //End:-Cost Center insert

                    if (strNameCount == "0" && f == 0)
                    {
                        objBusinessLedger.AddLedger(objEntityLedger, objEntitySubLedgerList);

                        objEntitySupplier.LedgerId = objEntityLedger.LedgerId;
                        if (objEntityLedger.LedgerId > 0)
                        {
                            objBusinessLedger.UpdateLedgerId(objEntityLedger.LedgerId);
                        }
                    }
                }
                else if (dt.Rows.Count > 0)
                {
                    f = 3;
                    ScriptManager.RegisterStartupScript(this, GetType(), "DupLedgrName", "DupLedgrName();", true);

                }
                else if (strCodeCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationLedgrCodeMsg", "DuplicationLedgrCodeMsg();", true);
                    f = 4;

                }
                //End:-Save to ledger table
            }

            objEntitySupplier.ContactNo = txtContact.Text;


            if (f == 0)
            {
                objBusinessSupplier.AddSupplier(objEntitySupplier, objEntitySupplierCntctList);
                if (Request.QueryString["RFGP"] == "SUL")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedSupplier", "PassSavedSupplier(" + objEntitySupplier.LedgerId + ");", true);
                }
                else if (Request.QueryString["RFGP"] == "SUPID")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedSupplierId", "PassSavedSupplierId('" + objEntitySupplier.SupplierId + "','" + objEntitySupplier.SupplierName + "');", true);
                }
                else
                {
                    if (clickedButton.ID == "bttnsave")
                    {
                        Response.Redirect("fms_Supplier.aspx?InsUpd=Ins");
                    }
                    else if (clickedButton.ID == "btnSaveAndClose")
                    {
                        Response.Redirect("fms_Supplier_List.aspx?InsUpd=Ins");
                    }
                }
            }
            else if (f == 1)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DupName", "DupName();", true);
            }
            else if (f == 5)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCstCntrCodeMsg", "DuplicationCstCntrCodeMsg();", true);

            }

        }
        catch (Exception)
        {
            //throw;
        }
    }

    public class clsData
    {
        public string ROWID { get; set; }
        public string DTLID { get; set; }
    }


    public void Update(string strP_Id, int mode)
    {
        try
        {
            clsEntitySupplier objEntitySupplier = new clsEntitySupplier();
            clsBusinessLayerSupplier objBusinessSupplier = new clsBusinessLayerSupplier();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsCommonLibrary objCommn = new clsCommonLibrary();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntitySupplier.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntitySupplier.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntitySupplier.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objEntitySupplier.SupplierId = Convert.ToInt32(strP_Id);
            DataTable dtSup = objBusinessSupplier.ReadSupplierDtlsById(objEntitySupplier);
           // ddlCurrency.ClearSelection();
            if (dtSup.Rows.Count > 0)
            {
                //Display supplier details
                txtName.Text = dtSup.Rows[0]["SUPLIR_NAME"].ToString();
                //ddlCurrency.Focus();
                //if (ddlCurrency.Items.FindByValue(dtSup.Rows[0]["CRNCMST_ID"].ToString()) != null)
                //{
                //    ddlCurrency.Items.FindByValue(dtSup.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                //}
                //else
                //{
                //    ListItem lstGrp = new ListItem(dtSup.Rows[0]["CRNCMST_NAME"].ToString(), dtSup.Rows[0]["CRNCMST_ID"].ToString());
                //    ddlCurrency.Items.Insert(1, lstGrp);
                //    SortDDL(ref this.ddlCurrency);
                //    ddlCurrency.Items.FindByValue(dtSup.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                //}
                if (dtSup.Rows[0]["SUPLIR_STS"].ToString() == "1")
                {
                    cbxStatus.Checked = true;
                }
                else
                {
                    cbxStatus.Checked = false;
                }
                if (dtSup.Rows[0]["SUPLIR_AS_LDGER"].ToString() == "1")
                {

                    if (dtSup.Rows[0]["LDGR_SUB_LDER"].ToString() == "1")
                    {
                        ddlAccountGrp.Enabled = false;
                        ddlLedger.Enabled = true;
                        cbxSubLedger.Checked = true;
                        ddlLedger.ClearSelection();
                        if (ddlLedger.Items.FindByValue(dtSup.Rows[0]["SUBLEDGERID"].ToString()) != null)
                        {
                            ddlLedger.Items.FindByValue(dtSup.Rows[0]["SUBLEDGERID"].ToString()).Selected = true;
                        }

                    }
                    else
                    {

                        ddlAccountGrp.Focus();
                        if (ddlAccountGrp.Items.FindByValue(dtSup.Rows[0]["ACNT_GRP_ID"].ToString()) != null)
                        {
                            ddlAccountGrp.Items.FindByValue(dtSup.Rows[0]["ACNT_GRP_ID"].ToString()).Selected = true;
                        }
                        else
                        {
                            ListItem lstGrp = new ListItem(dtSup.Rows[0]["ACNT_GRP_NAME"].ToString(), dtSup.Rows[0]["ACNT_GRP_ID"].ToString());
                            ddlAccountGrp.Items.Insert(1, lstGrp);
                            SortDDL(ref this.ddlAccountGrp);
                            ddlAccountGrp.Items.FindByValue(dtSup.Rows[0]["ACNT_GRP_ID"].ToString()).Selected = true;
                        }
                    }

                    cbxLedgerSts.Checked = true;
                    if (dtSup.Rows[0]["LDGR_TTLCNT"].ToString() != "0")
                    {
                        cbxLedgerSts.Disabled = true;
                        HiddenAcntGrpChngSts.Value = "1";
                    }

                    if (dtSup.Rows[0]["LDGR_CODE"].ToString() != "")
                    {
                        txtLedgrCode.Text = dtSup.Rows[0]["LDGR_CODE"].ToString();
                    }

                }
                else
                {
                    cbxLedgerSts.Checked = false;
                }
                txtAddress.Text = dtSup.Rows[0]["SUPLIR_ADDRESS"].ToString();
                txtAddress2.Text = dtSup.Rows[0]["SUPLIR_ADDRESS2"].ToString();
                txtAddress3.Text = dtSup.Rows[0]["SUPLIR_ADDRESS3"].ToString();

                if (dtSup.Rows[0]["SUPLIR_CR_LIMIT"].ToString() != "")
                {
                    string NetAmountWithCommaFrm = "";
                    NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(dtSup.Rows[0]["SUPLIR_CR_LIMIT"].ToString(), objEntityCommon);


                    txtCreditLimit.Text = NetAmountWithCommaFrm;
                }
                txtCreditPeriod.Text = dtSup.Rows[0]["SUPLIR_CR_PRD"].ToString();
                if (dtSup.Rows[0]["LDGR_ID"].ToString() != "")
                {
                    HiddenFieldLedgerId.Value = dtSup.Rows[0]["LDGR_ID"].ToString();
                }
                    txtName.Enabled = true;
                

                    if (dtSup.Rows[0]["COSTCNTR_ID"].ToString() != "")
                    {
                        hiddenCostCntrId.Value = dtSup.Rows[0]["COSTCNTR_ID"].ToString();

        clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
        clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();
        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);
            objEntity.UserId = intUserId;
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntity.Corp_Id = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntity.Org_Id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntity.CostId = Convert.ToInt32(hiddenCostCntrId.Value);
        DataTable dt = objBusinessCostCenter.ReadCostCenterById(objEntity);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["COSTCNTR_NATURE"].ToString() == "0")
            {
                rdIncome.Checked = true;
            }
            else
            {
                rdExpense.Checked = true;
            }
            ddlCC.ClearSelection();
            if (ddlCC.Items.FindByValue(dt.Rows[0]["COSTGRP_ID"].ToString()) != null)
            {
                ddlCC.Items.FindByValue(dt.Rows[0]["COSTGRP_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dt.Rows[0]["COSTGRP_NAME"].ToString(), dt.Rows[0]["COSTGRP_ID"].ToString());
                ddlCC.Items.Insert(1, lstGrp);
                SortDDL(ref this.ddlCC);
                ddlCC.Items.FindByValue(dt.Rows[0]["COSTGRP_ID"].ToString()).Selected = true;
            }
        }
                    }
                    else
                    {
                        hiddenCostCntrId.Value = "";
                    }
                    if (dtSup.Rows[0]["COSTCNTR_CNCL_USR_ID"].ToString() != "0")
                    {
                        HiddenCostCntrCnclId.Value = dtSup.Rows[0]["COSTCNTR_CNCL_USR_ID"].ToString();
                    }
                if (dtSup.Rows[0]["SUPLIR_AS_LDGER"].ToString() == "1")
                {

                   
                    if (dtSup.Rows[0]["LDGR_COST_CNTR"].ToString() == "0")
                    {
                        cbxCsCntrSts.Checked = true;

                        if (dtSup.Rows[0]["CSCNTR_TTLCNT"].ToString() != "0")
                        {
                            cbxCsCntrSts.Disabled = true;
                            cbxLedgerSts.Disabled = true;
                        }




                        if (dtSup.Rows[0]["COSTCNTR_CODE"].ToString() != "")
                        {
                            txtCostCntrCode.Text = dtSup.Rows[0]["COSTCNTR_CODE"].ToString();
                        }


                        
                    }
                    else
                    {
                        cbxCsCntrSts.Checked = false;
                    }



                    if (dtSup.Rows[0]["LDGR_TDS"].ToString() == "0")
                    {
                        radioTDSyes.Checked = true;
                    }
                    else
                    {
                        radioTDSyes.Checked = false;
                        ddlTDS.Enabled = false;
                    }
                    if (dtSup.Rows[0]["LDGR_TCS"].ToString() == "0")
                    {
                        radioTCSyes.Checked = true;
                    }
                    else
                    {
                        radioTCSyes.Checked = false;
                        ddlTCS.Enabled = false;
                    }
                   
                    if (dtSup.Rows[0]["TX_DDCTN_ID"].ToString() != "" && dtSup.Rows[0]["TX_DDCTN_ID"].ToString() != null)
                    {
                        if (ddlTDS.Items.FindByValue(dtSup.Rows[0]["TX_DDCTN_ID"].ToString()) != null)
                        {
                            ddlTDS.Items.FindByValue(dtSup.Rows[0]["TX_DDCTN_ID"].ToString()).Selected = true;
                        }
                        else
                        {
                            ListItem lstGrp = new ListItem(dtSup.Rows[0]["TX_DDCTN_NAME"].ToString(), dtSup.Rows[0]["TX_DDCTN_ID"].ToString());
                            ddlTDS.Items.Insert(1, lstGrp);
                            SortDDL(ref this.ddlTDS);
                            ddlTDS.Items.FindByValue(dtSup.Rows[0]["TX_DDCTN_ID"].ToString()).Selected = true;
                        }
                    }
                    if (dtSup.Rows[0]["TX_CLTN_ID"].ToString() != "" && dtSup.Rows[0]["TX_CLTN_ID"].ToString() != null)
                    {
                        if (ddlTCS.Items.FindByValue(dtSup.Rows[0]["TX_CLTN_ID"].ToString()) != null)
                        {
                            ddlTCS.Items.FindByValue(dtSup.Rows[0]["TX_CLTN_ID"].ToString()).Selected = true;
                        }
                        else
                        {
                            ListItem lstGrp = new ListItem(dtSup.Rows[0]["TX_CLTN_NAME"].ToString(), dtSup.Rows[0]["TX_CLTN_ID"].ToString());
                            ddlTCS.Items.Insert(1, lstGrp);
                            SortDDL(ref this.ddlTCS);
                            ddlTCS.Items.FindByValue(dtSup.Rows[0]["TX_CLTN_ID"].ToString()).Selected = true;
                        }
                    }
                   // txtblnce.Text = dtSup.Rows[0]["LDGR_OPEN_BAL"].ToString();
                    int DC_STS = 0;
                    if (dtSup.Rows[0]["LDGR_MODE"].ToString() == "")
                    {
                        txtblnce.Text = null;
                        DandC.Attributes["style"] = "float: right; margin-top: 2.2%; width: 85%;display:none;";
                    }



                    string NetAmountWithCommaOpenblnc = "";
                    if (dtSup.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                    {
                        NetAmountWithCommaOpenblnc = objBusiness.AddCommasForNumberSeperation(dtSup.Rows[0]["LDGR_OPEN_BAL"].ToString(), objEntityCommon);

                    }

                    if (dtSup.Rows[0]["LDGR_MODE"].ToString() != "")
                    {
                        DC_STS = Convert.ToInt32(dtSup.Rows[0]["LDGR_MODE"].ToString());
                        if (DC_STS == 0)
                        {
                            txtblnce.Text = NetAmountWithCommaOpenblnc;

                          //  objEntityLedger.DebitBalance = Convert.ToDecimal(dtSup.Rows[0]["LDGR_OPEN_BAL"].ToString());
                            DandC.Attributes["style"] = "display:block;float: right; margin-top: 2.2%; width: 89%;";
                            typdebit.Checked = true;
                        }
                        else if (DC_STS == 1)
                        {
                            txtblnce.Text = NetAmountWithCommaOpenblnc;
                       //   objEntityLedger.DebitBalance = Convert.ToDecimal(dtSup.Rows[0]["LDGR_OPEN_BAL"].ToString());
                            DandC.Attributes["style"] = "float: right; width: 89%;display:block;";
                            typecredit.Checked = true;
                        }
                    }


                
                }

                if (dtSup.Rows[0]["VNDRCTGRY_ID"].ToString() != "")
                {
                    if (ddlVendorCategory.Items.FindByValue(dtSup.Rows[0]["VNDRCTGRY_ID"].ToString()) != null)
                    {
                        ddlVendorCategory.Items.FindByValue(dtSup.Rows[0]["VNDRCTGRY_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dtSup.Rows[0]["VNDRCTGRY_NAME"].ToString(), dtSup.Rows[0]["VNDRCTGRY_ID"].ToString());
                        ddlVendorCategory.Items.Insert(0, lstGrp);
                        ddlVendorCategory.Items.FindByValue(dtSup.Rows[0]["VNDRCTGRY_ID"].ToString()).Selected = true;
                    }
                }
                if (dtSup.Rows[0]["SUPLIR_RATING"].ToString() != "")
                {
                    txtRating.Text = dtSup.Rows[0]["SUPLIR_RATING"].ToString();
                }
               
            }

            if (dtSup.Rows[0]["SUPLIR_CODE"].ToString() != "")
            {
                TxtSuplrCode.Text = dtSup.Rows[0]["SUPLIR_CODE"].ToString();
            }

            if (dtSup.Rows[0]["SUPLIR_CONTACTNO"].ToString() != "")
            {
                txtContact.Text = dtSup.Rows[0]["SUPLIR_CONTACTNO"].ToString();
            }

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("CNTCT_NAME", typeof(string));
            dtDetail.Columns.Add("CNTCT_ADDRESS", typeof(string));
            dtDetail.Columns.Add("CNTCT_MOBILE", typeof(string));
            dtDetail.Columns.Add("CNTCT_PHONE", typeof(string));
            dtDetail.Columns.Add("CNTCT_WEBSITE", typeof(string));
            dtDetail.Columns.Add("CNTCT_EMAIL", typeof(string));
            dtDetail.Columns.Add("CNTCT_ID", typeof(string));

            DataTable dtSupCntct = objBusinessSupplier.ReadContactDtls(objEntitySupplier);
            if (dtSupCntct.Rows.Count > 0)
            {
                for (int intCount = 0; intCount < dtSupCntct.Rows.Count; intCount++)
                {
                    DataRow drDtl = dtDetail.NewRow();
                    drDtl["CNTCT_NAME"] = dtSupCntct.Rows[intCount]["SUPLIR_CNTCT_NAME"].ToString();
                    drDtl["CNTCT_ADDRESS"] = dtSupCntct.Rows[intCount]["SUPLIR_CNTCT_ADDRESS"].ToString();
                    drDtl["CNTCT_MOBILE"] = dtSupCntct.Rows[intCount]["SUPLIR_CNTCT_MOBILE"].ToString();
                    drDtl["CNTCT_PHONE"] = dtSupCntct.Rows[intCount]["SUPLIR_CNTCT_PHONE"].ToString();
                    drDtl["CNTCT_WEBSITE"] = dtSupCntct.Rows[intCount]["SUPLIR_CNTCT_WEBSITE"].ToString();
                    drDtl["CNTCT_EMAIL"] = dtSupCntct.Rows[intCount]["SUPLIR_CNTCT_EMAIL"].ToString();
                    drDtl["CNTCT_ID"] = dtSupCntct.Rows[intCount]["SUPLIR_CNTCT_ID"].ToString();
                    dtDetail.Rows.Add(drDtl);
                }
            }
            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
            hiddenContactDtls.Value = strJson;
            hiddenContactRows.Value = dtSupCntct.Rows.Count.ToString();


            if (mode == 1)
            {
                txtName.Enabled = false;
                ddlCurrency.Enabled = false;
                //radioCostNo.Disabled = true;
                //radioCostYes.Disabled = true;
               
                if (hiddenTaxEnabled.Value =="1")
                {
                    //radioTCSno.Disabled = true;
                    //radioTCSyes.Disabled = true;
                    //radioTDSno.Disabled = true;
                    //radioTDSyes.Disabled = true;
                  
                    ddlTCS.Enabled = false;
                    ddlTDS.Enabled = false;
                }
                ddlAccountGrp.Enabled = false;
                ddlCC.Enabled = false;
                rdExpense.Disabled = true;
                rdIncome.Disabled = true;
              //  cbxLedgerSts.Disabled = false;
                txtCreditLimit.Enabled = false;
                txtCreditPeriod.Enabled = false;
                txtblnce.Enabled = false;
                //txtOpenBalanceDeb.Enabled = false;
                cbxStatus.Disabled = true;
                cbxLedgerSts.Disabled = true;
                txtAddress.Enabled = false;
                txtAddress2.Enabled = false;
                txtAddress3.Enabled = false;
                cbxCsCntrSts.Disabled = true;
                typdebit.Disabled = true;
                typecredit.Disabled = true;
                txtContact.Enabled = false;
            }
        }
        catch (Exception)
        {
        }
    }

    public static string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);

            }

            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["Id"] != null)
            {
                int f = 0;
                  Button clickedButton = sender as Button;
                clsEntitySupplier objEntitySupplier = new clsEntitySupplier();
                clsBusinessLayerSupplier objBusinessSupplier = new clsBusinessLayerSupplier();
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntitySupplier.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntitySupplier.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["USERID"] != null)
                {
                    objEntitySupplier.User_Id = Convert.ToInt32(Session["USERID"]);
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                objEntitySupplier.SupplierName = txtName.Text.Trim();
              //  objEntitySupplier.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                objEntitySupplier.Addess = txtAddress.Text.Trim();
                if (txtAddress2.Text.Trim() != "")
                {
                    objEntitySupplier.AddessTwo = txtAddress2.Text.Trim();
                }
                if (txtAddress3.Text.Trim() != "")
                {
                    objEntitySupplier.AddessThree = txtAddress3.Text.Trim();
                }
                if (txtCreditLimit.Text.Trim() != "")
                {
                    objEntitySupplier.CreditLimit = Convert.ToDecimal(txtCreditLimit.Text.Trim());
                }
                if (txtCreditPeriod.Text.Trim() != "")
                {
                    objEntitySupplier.Days = Convert.ToInt32(txtCreditPeriod.Text.Trim());
                }
                if (cbxStatus.Checked == true)
                {
                    objEntitySupplier.Status = 1;
                }

                if (ddlVendorCategory.SelectedItem.Value != "" && ddlVendorCategory.SelectedItem.Value != "--SELECT VENDOR CATEGORY--")
                {
                    objEntitySupplier.VendorCatgry = Convert.ToInt32(ddlVendorCategory.SelectedItem.Value);
                }
                if (txtRating.Text != "")
                {
                    objEntitySupplier.Rating = Convert.ToDecimal(txtRating.Text);
                }

                List<clsEntitySupplierContact> objEntitySupplierCntctList = new List<clsEntitySupplierContact>();

                int Rows = 0;
                if (hiddenContactRows.Value != "")
                {
                    Rows = Convert.ToInt32(hiddenContactRows.Value);
                }

                if (Rows > 0)
                {
                    for (int i = 0; i <= Rows; i++)
                    {
                        clsEntitySupplierContact objEntityContact = new clsEntitySupplierContact();

                        if (Request.Form["txtCntctName" + i] != null && Request.Form["txtCntctAddress" + i] != null)
                        {
                            if (Request.Form["txtCntctName" + i] != null)
                            {
                                objEntityContact.ContactName = Request.Form["txtCntctName" + i];
                            }
                            if (Request.Form["txtCntctAddress" + i] != null)
                            {
                                objEntityContact.ContactAddress = Request.Form["txtCntctAddress" + i];
                            }
                            if (Request.Form["txtCntctMobile" + i] != null)
                            {
                                objEntityContact.ContactMobile = Request.Form["txtCntctMobile" + i];
                            }
                            if (Request.Form["txtCntctPhone" + i] != null)
                            {
                                objEntityContact.ContactPhone = Request.Form["txtCntctPhone" + i];
                            }
                            if (Request.Form["txtCntctWebsite" + i] != null)
                            {
                                objEntityContact.ContactWebsite = Request.Form["txtCntctWebsite" + i];
                            }
                            if (Request.Form["txtCntctEmail" + i] != null)
                            {
                                objEntityContact.ContactEmail = Request.Form["txtCntctEmail" + i];
                            }

                            objEntitySupplierCntctList.Add(objEntityContact);
                        }
                    }
                }

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                objEntitySupplier.SupplierId = Convert.ToInt32(strRandomMixedId.Substring(2, intLenghtofId));
                DataTable dtSup = objBusinessSupplier.CheckDupName(objEntitySupplier);
                DataTable dt = objBusinessSupplier.CheckSupplierCnclSts(objEntitySupplier);
                if (dt.Rows.Count > 0)
                {
                    Response.Redirect("fms_Supplier_List.aspx?InsUpd=UpdCancl");
                }

                if (dtSup.Rows.Count > 0 && dt.Rows.Count > 0)
                {
                    f = 1;
                }
                if (cbxLedgerSts.Checked == true && f==0)
                {
                    objEntitySupplier.LedgerSts = 1;
                    //Start:-Save to ledger table
                    clsEntityLedger objEntityLedger = new clsEntityLedger();
                    clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
                    if (Session["CORPOFFICEID"] != null)
                    {
                        objEntityLedger.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("/Default.aspx");
                    }
                    if (Session["ORGID"] != null)
                    {
                        objEntityLedger.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("/Default.aspx");
                    }
                    if (Session["USERID"] != null)
                    {
                        objEntityLedger.User_Id = Convert.ToInt32(Session["USERID"]);
                    }
                    else if (Session["USERID"] == null)
                    {
                        Response.Redirect("/Default.aspx");
                    }
                    objEntityLedger.LedgerName = txtName.Text;
                        
                       // txtName.Text;

                    if (HiddenCodeSts.Value != "")
                    {
                        objEntityLedger.CodePrsntSts = Convert.ToInt32(HiddenCodeSts.Value);
                    }

                    if (HiddenCodeFormate.Value != "")
                    {
                        objEntityLedger.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
                    }
                    //evm 0044----------
                    int updatests = 0;
                    int updcostcntrstatus = 0;
                    string strRandomMixedId1 = Request.QueryString["Id"].ToString();
                    string strLenghtofId1 = strRandomMixedId1.Substring(0, 2);
                    int intLenghtofId1 = Convert.ToInt16(strLenghtofId1);
                    string strId1 = strRandomMixedId1.Substring(2, intLenghtofId1);
                    objEntityLedger.LedgerId = Convert.ToInt32(strId1);
                    DataTable dtdata = objBusinessLedger.ReadLedgerDtlsById(objEntityLedger);
                   
                    if (cbxSubLedger.Checked == true)
                    {
                        ddlLedger.Enabled = true;
                        if (ddlLedger.SelectedItem.Text != "--SELECT LEDGER--")
                        {
                            objEntityLedger.SubLedgerStatus = 1;
                            objEntityLedger.SubLedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
                          //evm 0044
                            if (dtdata.Rows.Count > 0)
                            {
                                int subldgrid = 0;
                                if (dtdata.Rows[0]["SUBLEDGERID"].ToString() == "")
                                {
                                    subldgrid = 0;
                                }
                                else
                                {
                                    subldgrid = Convert.ToInt32(dtdata.Rows[0]["SUBLEDGERID"].ToString());
                                }
                                if (subldgrid != Convert.ToInt32(ddlLedger.SelectedItem.Value))
                                {
                                    createCodeByLevel(objEntityLedger.Org_Id, objEntityLedger.Corp_Id);
                                    updatests = 1;
                                }

                            }
                            //---------
                        
                            //objEntityLedger.LedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
                            //objEntitySupplier.LedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
                        }
                    }
                    else
                    {
                        if (ddlAccountGrp.SelectedItem.Text != "--SELECT ACCOUNT GROUP--")
                        {
                            objEntityLedger.AccountGrpId = Convert.ToInt32(ddlAccountGrp.SelectedItem.Value);
                        }
                        else
                        {
                            objEntityLedger.AccountGrpId = PurchaseAcntGrpId;
                        }
                      
                    }
                    objEntityLedger.LdgrCode = txtLedgrCode.Text.Trim();

                    //objEntityLedger.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                    objEntityLedger.LedgerAddess = txtAddress.Text.Trim();

                    if (hiddenTaxEnabled.Value == "1")
                    {
                        if (HiddenAccountSpecific.Value == "1")
                        {
                            objEntityLedger.TxEnabledSts = 1;
                            if (radioTDSyes.Checked == false)
                            {
                                objEntityLedger.TDSstatus = 1;
                            }
                            else
                            {
                                objEntityLedger.TDSid = Convert.ToInt32(ddlTDS.SelectedItem.Value);
                            }
                            if (radioTCSyes.Checked == false)
                            {
                                objEntityLedger.TCSstatus = 1;
                            }
                            else
                            {
                                objEntityLedger.TCSid = Convert.ToInt32(ddlTCS.SelectedItem.Value);
                            }
                        }
                    }
                    else
                    {
                        objEntityLedger.TxEnabledSts = 0;
                    }
                    if (cbxCsCntrSts.Checked == true)
                    {
                        objEntityLedger.CostCenterSts = 0;
                    }
                    else
                    {
                        objEntityLedger.CostCenterSts = 1;
                    }
                    if (cbxStatus.Checked == true)
                    {
                        objEntityLedger.Status = 1;
                    }
                    //if (txtblnce.Text.Trim() != "")
                    //{
                    //    objEntityLedger.DebitBalance = Convert.ToDecimal(txtblnce.Text.Trim());
                    //}

                    //evm 0044 12/02
                    if (txtCreditLimit.Text != "" && txtCreditLimit.Text != null)
                        objEntityLedger.CreditLimit = Convert.ToDecimal(txtCreditLimit.Text);

                    if (txtCreditPeriod.Text != "" && txtCreditPeriod.Text != null)
                        objEntityLedger.CreditPeriod = Convert.ToInt32(txtCreditPeriod.Text);

                    //---------------

                    if (txtblnce.Text.Trim() != "")
                    {
                        decimal OpenBalance = 0;
                        OpenBalance = objEntityLedger.DebitBalance;
                        if (typdebit.Checked)
                        {
                            objEntityLedger.DebitBalance = Convert.ToDecimal(txtblnce.Text.Trim());
                         //   objEntityLedger.CreditBalance = (objEntityLedger.CreditBalance - OpenBalance) + Convert.ToDecimal(txtblnce.Text.Trim());
                            objEntityLedger.LedgerStatus = 0;
                        }
                        else
                        {
                            objEntityLedger.DebitBalance = Convert.ToDecimal(txtblnce.Text.Trim());
                          //  objEntityLedger.CreditBalance = (objEntityLedger.CreditBalance - OpenBalance) - Convert.ToDecimal(txtblnce.Text.Trim());
                            objEntityLedger.LedgerStatus = 1;

                        }
                    }

                    //if (txtOpenBalanceCre.Text.Trim() != "")
                    //{
                    //    objEntityLedger.CreditBalance = Convert.ToDecimal(txtOpenBalanceCre.Text.Trim());
                    //}
                    objEntityLedger.PageSts = 1;


                    List<clsEntityLedger> objEntitySubLedgerList = new List<clsEntityLedger>();

                    if (cbxLedgerSts.Checked == true)
                    {
                        if (cbxSubLedger.Checked == true)
                        {
                            objEntityLedger.LedgerId = objEntityLedger.SubLedgerId;
                        }

                        DataTable dtSubLdgr = objBusinessLedger.ReadSubLedgers(objEntityLedger);
                        if (dtSubLdgr.Rows.Count > 0)
                        {
                            foreach (DataRow dtSubRow in dtSubLdgr.Rows)
                            {
                                clsEntityLedger objEntitySubLdgr = new clsEntityLedger();
                                objEntitySubLdgr.SubLedgerId = Convert.ToInt32(dtSubRow["LDGR_ID"].ToString());
                                objEntitySubLdgr.Level = Convert.ToInt32(dtSubRow["LEVEL"].ToString());
                                objEntityLedger.Level = objEntitySubLdgr.Level;
                                objEntitySubLedgerList.Add(objEntitySubLdgr);
                            }
                        }
                    }

                    if (HiddenFieldLedgerId.Value != "")
                    {
                        objEntityLedger.LedgerId = Convert.ToInt32(HiddenFieldLedgerId.Value);
                    }


                    DataTable dtDupLed = objBusinessLedger.CheckDupName(objEntityLedger);
                    string strCodeCount = objBusinessLedger.CheckCodeDuplicatn(objEntityLedger);



                    if (dtDupLed.Rows.Count == 0 && f == 0 && strCodeCount=="0")
                    {

                        string strNameCstCount = "0";
                        string strCstCodeCount = "0";
                        int cstflg = 0;
                        if (objEntityLedger.CostCenterSts == 0)
                        {
                            clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
                            clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();
                            int intCorpId = 0, intOrgId = 0, intUserId = 0;
                            if (Session["USERID"] != null)
                            {
                                intUserId = Convert.ToInt32(Session["USERID"]);
                                objEntity.UserId = intUserId;
                            }
                            else if (Session["USERID"] == null)
                            {
                                Response.Redirect("/Default.aspx");
                            }
                            if (Session["CORPOFFICEID"] != null)
                            {
                                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                                objEntity.Corp_Id = intCorpId;
                            }
                            else if (Session["CORPOFFICEID"] == null)
                            {
                                Response.Redirect("/Default.aspx");
                            }
                            if (Session["ORGID"] != null)
                            {
                                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                                objEntity.Org_Id = intOrgId;
                            }
                            else if (Session["ORGID"] == null)
                            {
                                Response.Redirect("/Default.aspx");
                            }
                            if (hiddenCostCntrId.Value != "")
                            {
                                objEntity.CostId = Convert.ToInt32(hiddenCostCntrId.Value);
                                objEntityLedger.CostCenterID = Convert.ToInt32(hiddenCostCntrId.Value);
                            }

                            if (HiddenCodeSts.Value != "")
                            {
                                objEntity.CodePrsntSts = Convert.ToInt32(HiddenCodeSts.Value);
                            }

                            if (HiddenCodeFormate.Value != "")
                            {
                                objEntity.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
                            }
                            if (hiddenCodeNumberFrmt.Value != "")
                            {
                                objEntityLedger.CodeFormatNumber = Convert.ToInt32(hiddenCodeNumberFrmt.Value);
                            }
                            //evm 0044-----
                        
                            if (dtdata.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtdata.Rows[0]["COSTGRP_ID"].ToString()) != Convert.ToInt32(ddlCC.SelectedItem.Value))
                                {
                                    CreateCostCntrCode();
                                    updcostcntrstatus = 1;
                                }
                            }
                            //--------------------------

                            objEntity.GrpCode = txtCostCntrCode.Text.Trim();



                            if (txtblnce.Text != "" && txtblnce.Text != null)
                            {
                                objEntity.Balance = Convert.ToDecimal(txtblnce.Text.ToString());
                                if (typdebit.Checked == true)
                                {
                                    objEntity.DCStatus = 0;
                                }
                                else
                                {
                                    objEntity.DCStatus = 1;
                                }

                            }
                            objEntity.grpId = Convert.ToInt32(ddlCC.SelectedItem.Value.ToString());
                            objEntity.Name = txtName.Text.Trim();
                            objEntity.Status = 1;
                            if (rdExpense.Checked == true)
                            {
                                objEntity.Nature = 1;
                            }
                            strNameCstCount = objBusinessCostCenter.CheckCostName(objEntity);

                            strCstCodeCount = objBusinessCostCenter.CheckCodeDuplicatn(objEntity);
                            

                            if (strNameCstCount == "0" && hiddenCostCntrId.Value == "" && strCstCodeCount=="0")
                            {
                                // objEntity.led
                                string costID = objBusinessCostCenter.InsertCostCenter(objEntity);
                                objBusinessCostCenter.UpdateCostGroupNextId(objEntity);// evm 0044
                                objEntityLedger.CostCenterID = Convert.ToInt32(costID);
                                hiddenCostCntrId.Value = costID;
                            }
                            else if (strNameCstCount == "0" && hiddenCostCntrId.Value != "" && strCstCodeCount == "0")
                            {
                                objBusinessCostCenter.UpdateCostCenter(objEntity);
                                //evm 0044
                                if (updcostcntrstatus  == 1)
                                {
                                    objBusinessCostCenter.UpdateCostGroupNextId(objEntity);// evm 0044
                                }
                              
                            }
                            else if (strNameCstCount != "0")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "DupNameCost", "DupNameCost();", true);
                                cstflg = 1;
                                f = 3;
                            }
                            else if (strCstCodeCount != "0")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCstCntrCodeMsg", "DuplicationCstCntrCodeMsg();", true);
                                f =4;
                                cstflg = 1;
                            }
                        }

                        else
                        {
                             clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
                            clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();

                            int intCorpId = 0, intOrgId = 0, intUserId = 0;
                            if (Session["USERID"] != null)
                            {
                                intUserId = Convert.ToInt32(Session["USERID"]);
                                objEntity.UserId = intUserId;
                            }
                            else if (Session["USERID"] == null)
                            {
                                Response.Redirect("/Default.aspx");
                            }
                            if (Session["CORPOFFICEID"] != null)
                            {
                                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                                objEntity.Corp_Id = intCorpId;
                            }
                            else if (Session["CORPOFFICEID"] == null)
                            {
                                Response.Redirect("/Default.aspx");
                            }
                            if (Session["ORGID"] != null)
                            {
                                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                                objEntity.Org_Id = intOrgId;
                            }
                            else if (Session["ORGID"] == null)
                            {
                                Response.Redirect("/Default.aspx");
                            }
                            if (hiddenCostCntrId.Value != "")
                            {
                                objEntity.CostId = Convert.ToInt32(hiddenCostCntrId.Value);
                            }
                            strNameCstCount = objBusinessCostCenter.CheckCostName(objEntity);


                            if (strNameCstCount == "0")
                            {
                                if (hiddenCostCntrId.Value != "" && HiddenCostCntrCnclId.Value == "")
                                {
                                    objBusinessCostCenter.DeleteCostCenter(objEntity);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "DupNameCost", "DupNameCost();", true);
                            }
                        }

                        if (cstflg == 0)
                        {

                            if (HiddenFieldLedgerId.Value != "")
                            {
                                objEntitySupplier.LedgerId = Convert.ToInt32(HiddenFieldLedgerId.Value);
                                objBusinessLedger.UpdateLedger(objEntityLedger, objEntitySubLedgerList);
                                if (updatests == 1)//evm 0044
                                {
                                    objBusinessLedger.UpdateLedgerId(objEntityLedger.LedgerId);
                                }
                            }
                            else
                            {
                                objBusinessLedger.AddLedger(objEntityLedger, objEntitySubLedgerList);
                                objBusinessLedger.UpdateLedgerId(objEntityLedger.LedgerId);//evm 0044
                                objEntitySupplier.LedgerId = objEntityLedger.LedgerId;
                            }
                        }
                    }
                    else
                    {
                        if (dtDupLed.Rows.Count != 0)
                        {

                            f = 2;
                        }
                        else if (strCodeCount != "0")
                        {
                            f = 5;
                        }
                    }
                    //End:-Save to ledger table
                }
                else if (HiddenFieldLedgerId.Value != "" && f == 0)
                {
                    objEntitySupplier.LedgerId = Convert.ToInt32(HiddenFieldLedgerId.Value);
                    objBusinessSupplier.UpdateLedgerSts(objEntitySupplier);

                    clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
                    clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();
                    string strNameCstCount = "0";
                    int intCorpId = 0, intOrgId = 0, intUserId = 0;
                    if (Session["USERID"] != null)
                    {
                        intUserId = Convert.ToInt32(Session["USERID"]);
                        objEntity.UserId = intUserId;
                    }
                    else if (Session["USERID"] == null)
                    {
                        Response.Redirect("/Default.aspx");
                    }
                    if (Session["CORPOFFICEID"] != null)
                    {
                        intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                        objEntity.Corp_Id = intCorpId;
                    }
                    else if (Session["CORPOFFICEID"] == null)
                    {
                        Response.Redirect("/Default.aspx");
                    }
                    if (Session["ORGID"] != null)
                    {
                        intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                        objEntity.Org_Id = intOrgId;
                    }
                    else if (Session["ORGID"] == null)
                    {
                        Response.Redirect("/Default.aspx");
                    }
                    if (hiddenCostCntrId.Value!="")

                    objEntity.CostId = Convert.ToInt32(hiddenCostCntrId.Value);

                    strNameCstCount = objBusinessCostCenter.CheckCostName(objEntity);
                    if (strNameCstCount == "0")
                    {

                        if (hiddenCostCntrId.Value != "" && HiddenCostCntrCnclId.Value == "")
                        {
                            objBusinessCostCenter.DeleteCostCenter(objEntity);
                        }
                    }

                }

                objEntitySupplier.ContactNo = txtContact.Text;

                if (f == 0)
                {



                    objBusinessSupplier.UpdateSupplier(objEntitySupplier, objEntitySupplierCntctList);
                    if (clickedButton.ID == "btnUpdate")
                    {
                        Response.Redirect("fms_Supplier.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnUpdateAndClose")
                    {
                        Response.Redirect("fms_Supplier_List.aspx?&InsUpd=Upd");
                    }
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        Response.Redirect("fms_Supplier_List.aspx?InsUpd=UpdCancl");
                    }
                    else if(f==1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DupName", "DupName();", true);
                    }
                    else if (f == 2)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DupLedgrName", "DupLedgrName();", true);
                    }
                    else if(f==5)
                    {
                          ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationLedgrCodeMsg", "DuplicationLedgrCodeMsg();", true);
                  
                    }
                }
            }
        }
        catch (Exception)
        {
        }
    }
    private void SortDDL(ref DropDownList objDDL)
    {
        System.Collections.ArrayList textList = new System.Collections.ArrayList();
        System.Collections.ArrayList valueList = new System.Collections.ArrayList();
        foreach (ListItem li in objDDL.Items)
        {
            textList.Add(li.Text);
        }
        textList.Sort();
        foreach (object item in textList)
        {
            string value = objDDL.Items.FindByText(item.ToString()).Value;
            valueList.Add(value);
        }
        objDDL.Items.Clear();

        for (int i = 0; i < textList.Count; i++)
        {
            ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
            objDDL.Items.Add(objItem);
        }
    }
}