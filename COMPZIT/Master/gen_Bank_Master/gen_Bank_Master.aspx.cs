using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;
using EL_Compzit;
using CL_Compzit;
using BL_Compzit;

using System.Web.Services;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusinessLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
//using BL
// CREATED BY:WEM-0006
// CREATED DATE:26/10/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class AWMS_AWMS_Master_gen_Bank_Master_gen_Bank_Master : System.Web.UI.Page
{

    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    if (Request.QueryString["RFGP"] != null)
    //    {
    //        this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";
    //    }
    //    else
    //    {
    //        this.MasterPageFile = "~/MasterPage/MasterPageCompzit.master";
    //    }
    //}
    int SaleAcntGrpId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Assigning  Key actions 

        txtLedgrCode.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtLedgrCode.Attributes.Add("onkeydown", "return DisableEnter(event)");
        
        //txtName.Attributes.Add("onkeypress", "return isTag(event)");
        txtBankName.Attributes.Add("onkeypress", "return isTag(event)");
        txtBankName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtBankSwiftCode.Attributes.Add("onkeypress", "return isTag(event)");
        txtBankSwiftCode.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAccNo.Attributes.Add("onkeypress", "return isTag(event)");
        txtAccNo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtIfscCode.Attributes.Add("onkeypress", "return isTag(event)");
        txtIfscCode.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtIBan.Attributes.Add("onkeypress", "return isTag(event)");
        txtIBan.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAddress.Attributes.Add("onkeypress", "return isTagEnter(event)");
        txtAddress.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        //evm-0027 SEP 18
        chkHCM.Attributes.Add("onkeypress", "return DisableEnter(event)");
        chkHCM.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        //end

        LoadAccountGrp();
        if (!IsPostBack)
        {
            hiddenBankPostAdd.Value = "0";
            LoadCostGroup();
            LoadTCS();
            LoadTDS();
            HiddenTaxEnable.Value = "0";
            HiddenAcntGrpChngSts.Value = "0";
          //  clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {    clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED,
                                                            clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                            clsCommonLibrary.CORP_GLOBAL.FMS_VIEW_CODE_STS,
                                                            clsCommonLibrary.CORP_GLOBAL.FMS_CODE_FORMATE,
                                                           clsCommonLibrary.CORP_GLOBAL.FMS_CODE_NUMBER_FORMAT,
                                                           
                                                              };
            DataTable dtCorpDetail = new DataTable();

            int intCorpId = 0, intOrgid = 0;


            int intUserId = 0, intUsrRolMstrId, intEnableAdd = 0;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }

       
           // int intCorpId = 0;
            if (Session["CORPOFFICEID"] != null)
            {

                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());


            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }



            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
            }

            if (dtCorpDetail.Rows.Count > 0)
            {
                int intDfltCurrencyMstrId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"]);
                clsEntityCommon objEntityCommon = new clsEntityCommon();

                objEntityCommon.CurrencyId = intDfltCurrencyMstrId;
                DataTable dtCurrencyDetail = new DataTable();
                dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
                if (dtCurrencyDetail.Rows.Count > 0)
                {
                    hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();

                }
                if (dtCorpDetail.Rows[0]["GN_TAX_ENABLED"] != DBNull.Value)
                {
                    //value 1 means commodity maintained corporate 
                    if (Convert.ToInt32(dtCorpDetail.Rows[0]["GN_TAX_ENABLED"]) == 1)
                    {
                        //divTdsTcs.Attributes["style"] = "display:block;";
                        HiddenTaxEnable.Value = "1";
                     
                    }
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

            }





            if (HiddenCodeFormate.Value == "1")
            {

                //  txtLedgrCode.Enabled = true;
                // txtCostCntrCode.Enabled = true;

            }
            else
            {
                txtLedgrCode.Disabled = true;
                txtCostCntrCode.Disabled = true;


            }



            if (HiddenCodeSts.Value == "1")
            {
                //divCodeSts.Attributes["style"] = "display: block;";

                divCode.Attributes["style"] = "display: block;";
                divCode1.Attributes["style"] = "display: block;";
                
            }
            else
            {

                divCode.Attributes["style"] = "display: none;";
                divCode1.Attributes["style"] = "display: none;";

            }



            LoadChqTemplateDtl();

            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                btnClear.Visible = false;
                btnClearF.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Update(strId, intCorpId);
                lblEntry.InnerText = "Edit Bank";
                currPage.InnerText = "Edit Bank";
            }
            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                btnClear.Visible = false;
                btnClearF.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                HiddenViewSts.Value = "1";
                View(strId, intCorpId);
                currPage.InnerText = "View Bank";
                lblEntry.InnerText = "View Bank";
            }
            else
            {
                currPage.InnerText = "Add Bank";
                lblEntry.InnerText = "Add Bank";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnClear.Visible = true;

                btnUpdateF.Visible = false;
                btnUpdateCloseF.Visible = false;
                btnAddF.Visible = true;
                btnAddCloseF.Visible = true;
                btnClearF.Visible = true;

            }
            if (Request.QueryString["RFGP"] != null)
            {
                divList.Visible = false;

                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = false;
                btnAddClose.Visible = true;
                btnClear.Visible = false;
                btnCancel.Visible = false;

                btnUpdateF.Visible = false;
                btnUpdateCloseF.Visible = false;
                btnAddF.Visible = false;
                btnAddCloseF.Visible = true;
                btnClearF.Visible = false;
                btnCancelF.Visible = false;
                mySave.Visible = false;
                divLedgerBlock.Visible = false;
                if (Request.QueryString["Name"] != null)
                {
                    txtBankName.Value = Request.QueryString["Name"].ToString();
                }
                txtBankName.Disabled = true;
                hiddenBankPostAdd.Value = "1";
            }
            //Allocating child roles

            HiddenBusinessSpecific.Value = "0";
            HiddenAccountSpecific.Value = "0";
            int intBusinessSpecific = 0, intAccountSpecific = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Bank_Master);
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
                        //future

                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Approve).ToString())
                    {
                        //future

                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString())
                    {
                        HiddenBusinessSpecific.Value = "1";
                        intBusinessSpecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString())
                    {
                        HiddenAccountSpecific.Value = "1";
                        intAccountSpecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }


                }
            }

            if (intBusinessSpecific == 1 && intAccountSpecific == 0)
            {
                divLedgerBlock.Visible = false;
            }
            else if (intBusinessSpecific == 0 && intAccountSpecific == 1)
            {
                divLedgerBlock.Visible = true;
            }
            else if (intBusinessSpecific == 1 && intAccountSpecific == 1)
            {

            }


            if (intEnableAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {


            }
            else
            {

                btnUpdate.Visible = false;
                btnUpdateF.Visible = false;
            }
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
            }

        }
        txtBankName.Focus();
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


    [WebMethod]
    public static string LoadLedgerCode(string strUserID, string ActGrpId, string strOrgIdID, string strCorpID)
    {
        string sts = "";
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();

        int intCorpId = 0;
        if (strCorpID != null)
        {

            intCorpId = Convert.ToInt32(strCorpID);
            objEntityCommon.CorporateID = Convert.ToInt32(strCorpID);
            objEntityLedger.Corp_Id = Convert.ToInt32(strCorpID);
        }

        if (strOrgIdID != null)
        {

            objEntityCommon.Organisation_Id = Convert.ToInt32(strOrgIdID);
            objEntityLedger.Org_Id = Convert.ToInt32(strOrgIdID);
        }

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_LEDGER_MASTER);
        DataTable dtFormate = objBusinessLayer.ReadCodeFormate(objEntityCommon);
        string refFormatByDiv = "";
        string strRealFormat = "";

        DataTable dt = new DataTable();


        if (ActGrpId != "")
        {
            objEntityLedger.LedgerId = Convert.ToInt32(ActGrpId);
        }

        objEntityLedger.LedgerAcntGrpSts = 0;
        dt = objBusinessLedger.ReadAccountGrp_Of_Ledgr(objEntityLedger);





        if (dtFormate.Rows.Count > 0)
        {
            if (dt.Rows.Count > 0)
            {
                string StrAcntGrpId = "";


                int NaureCode = 0;
                string CodeFormate = "";
                int intNature = Convert.ToInt32(dt.Rows[0]["ACNT_NATURE_STS"].ToString());
                StrAcntGrpId = dt.Rows[0]["ACNT_GRP_ID"].ToString();

                if (intNature == 0)
                {
                    NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Asset);
                }
                else if (intNature == 1)
                {
                    NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Liability);
                }
                else if (intNature == 2)
                {
                    NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Expense);
                }
                else if (intNature == 3)
                {
                    NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Income);
                }



                CodeFormate = NaureCode.ToString();

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
                    if (strRealFormat.Contains("#NAT#"))
                    {
                        strRealFormat = strRealFormat.Replace("#NAT#", NaureCode.ToString());


                    }
                    if (strRealFormat.Contains("#NUM#"))
                    {
                        string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);


                        strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);


                    }
                    if (strRealFormat.Contains("#ACNTGRP#"))
                    {
                        string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);


                        strRealFormat = strRealFormat.Replace("#ACNTGRP#", StrAcntGrpId);


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
        }

        return sts.ToString();
    }
    //---evm 0044
    [WebMethod]
    public static string LoadLedgerCode1(string strUserID, string ActGrpId, string strOrgIdID, string ldgrsts, string strCorpID)
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
        }

        if (strOrgIdID != null)
        {

            objEntityCommon.Organisation_Id = Convert.ToInt32(strOrgIdID);
            objEntityLedger.Org_Id = Convert.ToInt32(strOrgIdID);
        }

     
        string strRealFormat = "";
        if (ldgrsts == "0")
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
                        objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.LEDGER_START_REF); ;
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
                        objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.SUB_LEDGER_START_REf); ;
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
    }
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
        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER_START_REf);
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

                objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER_START_REf); ;
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
    //evm 0044
    public void createCodeByLevel(int orgId, int corpId)
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (cbxLedgerSts.Checked == true)
        {
            clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
            clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();

            objEntityAccountGroup.CorpId = corpId;
            objEntityAccountGroup.OrgId = orgId;
            objEntityAccountGroup.AccountGrpId = Convert.ToInt32(HiddenDefaultAcntGrpId.Value) ;
           

            int subldgrnum = 0;
            DataTable dtledger = objBusinessAcountGrp.LoadAccountGroupBYId(objEntityAccountGroup);
            if (dtledger.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtledger.Rows[0]["ACNT_NEXTID_LEDGER"].ToString()) == 0)
                {
                    objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.LEDGER_START_REF); ;
                    objEntityCommon.CorporateID = corpId;
                    objEntityCommon.Organisation_Id = orgId;
                    DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
                    if (dtDefaltModData.Rows.Count > 0)
                    {
                        subldgrnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"].ToString());
                        txtLedgrCode.Value = dtledger.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subldgrnum);
                    }
                }
                else
                {
                    subldgrnum = Convert.ToInt32(dtledger.Rows[0]["ACNT_NEXTID_LEDGER"].ToString());
                    txtLedgrCode.Value = dtledger.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subldgrnum);
                }
            }
        }
        //if (chkSubLedger.Checked == true)
        //{
        //    clsEntityLedger objEntityLedger = new clsEntityLedger();
        //    clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();

        //    objEntityLedger.Corp_Id = corpId;
        //    objEntityLedger.Org_Id = orgId;
        //    objEntityLedger.SubLedgerStatus = 1;
        //    objEntityLedger.SubLedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
        //    objEntityLedger.LedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);

        //    int subldgrnextnum = 0;
        //    DataTable dtactgroup = objBusinessLedger.LoadLedgerBYId(objEntityLedger);
        //    if (dtactgroup.Rows.Count > 0)
        //    {
        //        if (Convert.ToInt32(dtactgroup.Rows[0]["LDGR_NEXTID_LEDGER"].ToString()) == 0)
        //        {
        //            objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.SUB_LEDGER_START_REf); ;
        //            objEntityCommon.CorporateID = objEntityLedger.Corp_Id;
        //            objEntityCommon.Organisation_Id = objEntityLedger.Org_Id;
        //            DataTable dtDefaltModData = objBusinessLayer.ReadDefaultModValues(objEntityCommon);
        //            if (dtDefaltModData.Rows.Count > 0)
        //            {
        //                subldgrnextnum = Convert.ToInt32(dtDefaltModData.Rows[0]["MOD_DFLT_VALUE"].ToString());
        //                txtLedgrCode.Text = dtactgroup.Rows[0]["LDGR_CODE"].ToString() + Convert.ToString(subldgrnextnum);
        //            }
        //        }
        //        else
        //        {
        //            subldgrnextnum = Convert.ToInt32(dtactgroup.Rows[0]["LDGR_NEXTID_LEDGER"].ToString());
        //            txtLedgrCode.Text = dtactgroup.Rows[0]["LDGR_CODE"].ToString() + Convert.ToString(subldgrnextnum);
        //        }
        //    }
        //}
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
        objEntity.CostId = Convert.ToInt32(ddlCC.Value);
        int costcntrnextnum = 0;
        DataTable dtcostgrp = new DataTable();
        dtcostgrp = objBusinessCOST.ReadCOSTById(objEntity);
        if (dtcostgrp.Rows.Count > 0)
        {
            costcntrnextnum = Convert.ToInt32(dtcostgrp.Rows[0]["COSTGRP_NEXTID_COSTCNTR"]);
            if (costcntrnextnum == 0)
            {

                objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER_START_REf); ;
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

        txtCostCntrCode.Value = strRealFormat;
    }
    //---------
    //-------------------

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
        //DataTable dtdiv = objBusinessLedger.ReadTCS(objEntityLedger);
        //if (dtdiv.Rows.Count > 0)
        //{
        //    ddlTCS.DataSource = dtdiv;
        //    ddlTCS.DataTextField = "TX_CLTN_NAME";
        //    ddlTCS.DataValueField = "TX_CLTN_ID";
        //    ddlTCS.DataBind();
        //}
        //ddlTCS.Items.Insert(0, "--SELECT TCS--");

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
        //DataTable dtdiv = objBusinessLedger.ReadTDS(objEntityLedger);
        //if (dtdiv.Rows.Count > 0)
        //{
        //    ddlTDS.DataSource = dtdiv;
        //    ddlTDS.DataTextField = "TX_DDCTN_NAME";
        //    ddlTDS.DataValueField = "TX_DDCTN_ID";
        //    ddlTDS.DataBind();
        //}
        //ddlTDS.Items.Insert(0, "--SELECT TDS--");

    }
    public void LoadChqTemplateDtl()
    {

      
        clsEntityLayerBank objEntityBank = new clsEntityLayerBank();
        clsBusinessLayerBank objBusinessbank = new clsBusinessLayerBank();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityBank.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityBank.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


     
        //END
        if (Session["USERID"] != null)
        {
            objEntityBank.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dt = objBusinessbank.ReadChequeTemplateDtl(objEntityBank);

        ddlChqTempDtls.ClearSelection();

        if (dt.Rows.Count > 0)
        {
            ddlChqTempDtls.DataSource = dt;
            ddlChqTempDtls.DataTextField = "CHKTEMPLT_NAME";
            ddlChqTempDtls.DataValueField = "CHKTEMPLT_ID";
            ddlChqTempDtls.DataBind();

        }
        //ddlCurrency.Items.Insert(0, "--SELECT--");
        ddlChqTempDtls.Items.Insert(0, "--SELECT TEMPLATE--");


    }
    private void SortDDL(ref DropDownList objDDL)
    {
        ArrayList textList = new ArrayList();
        ArrayList valueList = new ArrayList();


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

    public void Update(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;

        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = true;
        btnUpdateCloseF.Visible = true;
        clsEntityLayerBank objEntityBank = new clsEntityLayerBank();
        clsBusinessLayerBank objBusinessbank = new clsBusinessLayerBank();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityBank.BankId = Convert.ToInt32(strP_Id);
        objEntityBank.Corporate_id = intCorpId;
        objEntityCommon.CorporateID = intCorpId;
        DataTable dtBankById = objBusinessbank.ReadBankById(objEntityBank);
        if (dtBankById.Rows.Count > 0)
        {
            txtBankName.Value = dtBankById.Rows[0]["BANK_NAME"].ToString();
            txtAddress.Value = dtBankById.Rows[0]["BANK_ADDRESS"].ToString();
            txtAccNo.Value = dtBankById.Rows[0]["BANK_ACC_NO"].ToString();
            txtBankSwiftCode.Value = dtBankById.Rows[0]["BANK_SWIFT_CODE"].ToString();
            txtIBan.Value = dtBankById.Rows[0]["BANK_I_BAN_NO"].ToString();
            txtIfscCode.Value = dtBankById.Rows[0]["BANK_IFSC_CODE"].ToString();
            //BANK_SHORT_NAME
            //EVM-0027
            txtBankShortName.Value = dtBankById.Rows[0]["BANK_SHORT_NAME"].ToString();
            //END
            int intBankStatus = Convert.ToInt32(dtBankById.Rows[0]["BANK_STATUS"]);
            if (intBankStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            //EVM-0027 sep18
            int intBankHCMStatus = Convert.ToInt32(dtBankById.Rows[0]["BANK_HCM"]);
            if (intBankHCMStatus == 1)
            {
                chkHCM.Checked = true;
            }
            else
            {
                chkHCM.Checked = false;
            }





            if (dtBankById.Rows[0]["BANK_AS_LDGER"].ToString() == "1")
            {
                cbxLedgerSts.Checked = true;
                if (dtBankById.Rows[0]["LDGR_TTLCNT"].ToString() != "0")
                {
                    cbxLedgerSts.Disabled = true;
                    HiddenAcntGrpChngSts.Value = "1";
                }

                if (dtBankById.Rows[0]["LDGR_CODE"].ToString() != "")
                {
                    txtLedgrCode.Value = dtBankById.Rows[0]["LDGR_CODE"].ToString();
                }
            }
            else
            {
                cbxLedgerSts.Checked = false;
            }
            HiddenFieldLedgerId.Value = dtBankById.Rows[0]["LDGR_ID"].ToString();
            if (HiddenFieldLedgerId.Value != "")
            {
             //   txtBankName.Enabled = false;
              //  ddlCustomerType.Focus();
            }
            if (dtBankById.Rows[0]["COSTCNTR_CNCL_USR_ID"].ToString() != "0")
            {
                HiddenCostCntrCnclId.Value = dtBankById.Rows[0]["COSTCNTR_CNCL_USR_ID"].ToString();


            }
            if (dtBankById.Rows[0]["COSTCNTR_ID"].ToString() != "")
            {
                hiddenCostCntrId.Value = dtBankById.Rows[0]["COSTCNTR_ID"].ToString();

                clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
                clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();
                int  intOrgId = 0, intUserId = 0;
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
                    //ddlCC.ClearSelection();
                    if (ddlCC.Items.FindByValue(dt.Rows[0]["COSTGRP_ID"].ToString()) != null)
                    {
                        ddlCC.Items.FindByValue(dt.Rows[0]["COSTGRP_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dt.Rows[0]["COSTGRP_NAME"].ToString(), dt.Rows[0]["COSTGRP_ID"].ToString());
                        ddlCC.Items.Insert(1, lstGrp);
                        //SortDDL(ref this.ddlCC);
                        ddlCC.Items.FindByValue(dt.Rows[0]["COSTGRP_ID"].ToString()).Selected = true;
                    }
                }
            }
            else
            {
                hiddenCostCntrId.Value = "";
            }


            if (dtBankById.Rows[0]["BANK_AS_LDGER"].ToString() == "1")
            {


               


                //if (dtBankById.Rows[0]["LDGR_TDS"].ToString() == "0")
                //{
                //    radioTDSyes.Checked = true;
                //}
                //else
                //{
                //    radioTDSno.Checked = true;
                //}
                //if (dtBankById.Rows[0]["LDGR_TCS"].ToString() == "0")
                //{
                //    radioTCSyes.Checked = true;
                //}
                //else
                //{
                //    radioTCSno.Checked = true;
                //}
                if (dtBankById.Rows[0]["LDGR_COST_CNTR"].ToString() == "0")
                {
                    cbxCsCntrSts.Checked = true;
                    if (dtBankById.Rows[0]["CSCNTR_TTLCNT"].ToString() != "0")
                    {
                        cbxCsCntrSts.Disabled = true;
                        cbxLedgerSts.Disabled = true;
                    }
                   

                    if (dtBankById.Rows[0]["COSTCNTR_CODE"].ToString() != "")
                    {
                        txtCostCntrCode.Value = dtBankById.Rows[0]["COSTCNTR_CODE"].ToString();
                    }

                }
                else
                {
                    cbxCsCntrSts.Checked = false;
                }
                //if (dtBankById.Rows[0]["TX_DDCTN_ID"].ToString() != "" && dtBankById.Rows[0]["TX_DDCTN_ID"].ToString() != null)
                //{

                //    if (ddlTDS.Items.FindByValue(dtBankById.Rows[0]["TX_DDCTN_ID"].ToString()) != null)
                //    {
                //        ddlTDS.Items.FindByValue(dtBankById.Rows[0]["TX_DDCTN_ID"].ToString()).Selected = true;
                //    }
                //    else
                //    {
                //        ListItem lstGrp = new ListItem(dtBankById.Rows[0]["TX_DDCTN_NAME"].ToString(), dtBankById.Rows[0]["TX_DDCTN_ID"].ToString());
                //        ddlTDS.Items.Insert(1, lstGrp);
                //        SortDDL(ref this.ddlTDS);
                //        ddlTDS.Items.FindByValue(dtBankById.Rows[0]["TX_DDCTN_ID"].ToString()).Selected = true;
                //    }
                //}
                //if (dtBankById.Rows[0]["TX_CLTN_ID"].ToString() != "" && dtBankById.Rows[0]["TX_CLTN_ID"].ToString() != null)
                //{
                //    if (ddlTCS.Items.FindByValue(dtBankById.Rows[0]["TX_CLTN_ID"].ToString()) != null)
                //    {
                //        ddlTCS.Items.FindByValue(dtBankById.Rows[0]["TX_CLTN_ID"].ToString()).Selected = true;
                //    }
                //    else
                //    {
                //        ListItem lstGrp = new ListItem(dtBankById.Rows[0]["TX_CLTN_NAME"].ToString(), dtBankById.Rows[0]["TX_CLTN_ID"].ToString());
                //        ddlTCS.Items.Insert(1, lstGrp);
                //        SortDDL(ref this.ddlTCS);
                //        ddlTCS.Items.FindByValue(dtBankById.Rows[0]["TX_CLTN_ID"].ToString()).Selected = true;
                //    }
                //}
                //if (ddlCurrency.Items.FindByValue(dtBankById.Rows[0]["CRNCMST_ID"].ToString()) != null)
                //{
                //    ddlCurrency.Items.FindByValue(dtBankById.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                //}
                //else
                //{
                //    ListItem lstGrp = new ListItem(dtBankById.Rows[0]["CRNCMST_NAME"].ToString(), dtBankById.Rows[0]["CRNCMST_ID"].ToString());
                //    ddlCurrency.Items.Insert(1, lstGrp);
                //    SortDDL(ref this.ddlCurrency);
                //    ddlCurrency.Items.FindByValue(dtBankById.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                //}

                int DC_STS = 0;
                if (dtBankById.Rows[0]["LDGR_MODE"].ToString() == "")
                {
                    txtOpenBalanceDeb.Value = null;
                    txtOpenBalanceDeb.Attributes["style"] = "display:none;";
                }
                if (dtBankById.Rows[0]["LDGR_MODE"].ToString() != "")
                {
                    DC_STS = Convert.ToInt32(dtBankById.Rows[0]["LDGR_MODE"].ToString());


                    string openingBal = dtBankById.Rows[0]["LDGR_OPEN_BAL"].ToString();

                    string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(openingBal.ToString(), objEntityCommon);
                    if (DC_STS == 0)
                    {
                        txtOpenBalanceDeb.Value = openingBal;

                        DandC.Attributes["style"] = " display: block;";
                        typdebit.Checked = true;
                    }
                    else if (DC_STS == 1)
                    {
                        txtOpenBalanceDeb.Value = openingBal;

                        DandC.Attributes["style"] = " display: block;";
                        typecredit.Checked = true;
                    }
                }
              
            }
            //END
        }









        DataTable dtChkBk = objBusinessbank.ReadChkBookDtlsById(objEntityBank);
       

        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("ChkBklId", typeof(string));
        dtDetail.Columns.Add("ChkBkName", typeof(string));
      //  dtDetail.Columns.Add("CatgoryId", typeof(int));
        dtDetail.Columns.Add("ChLfNumFrom", typeof(string));
        dtDetail.Columns.Add("ChLfNumTo", typeof(string));
        dtDetail.Columns.Add("ChkStatus", typeof(string));
        dtDetail.Columns.Add("ChkTemp", typeof(string));
         dtDetail.Columns.Add("CnclCkLeaf", typeof(string));


        for (int intcnt = 0; intcnt < dtChkBk.Rows.Count; intcnt++)
        {
            DataRow drDtl = dtDetail.NewRow();
            drDtl["ChkBklId"] = dtChkBk.Rows[intcnt]["CHKBK_ID"].ToString();
            drDtl["ChkBkName"] = dtChkBk.Rows[intcnt]["CHKBK_NAME"].ToString();
            drDtl["ChLfNumFrom"] = dtChkBk.Rows[intcnt]["CHKBK_NUM_FROM"].ToString();
            drDtl["ChLfNumTo"] = dtChkBk.Rows[intcnt]["CHKBK_NUM_TO"].ToString();
            drDtl["ChkStatus"] = dtChkBk.Rows[intcnt]["CHKBK_STS"].ToString();
            drDtl["ChkTemp"] = dtChkBk.Rows[intcnt]["CHKTEMPLT_ID"].ToString();
            drDtl["CnclCkLeaf"] = dtChkBk.Rows[intcnt]["CNCLLEAF"].ToString();
            // drDtl["Amount"] = Convert.ToDecimal(dtIntervw.Rows[intcnt]["RCPT_AMNT"].ToString());INTWCTGRY_STATUS

            dtDetail.Rows.Add(drDtl);

        }

        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        //if (intEditOrView == 1)
        //{
      //  btnAdd.Visible = false;
      //  btnAddClose.Visible = false;
        //  btnReOpen.Visible = false;
        hiddenEdit.Value = strJson;


    }
    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
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

    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id, int intCorpId)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;

        btnAddF.Visible = false;
        btnAddCloseF.Visible = false;
        btnUpdateF.Visible = false;
        btnUpdateCloseF.Visible = false;
        clsEntityLayerBank objEntityBank = new clsEntityLayerBank();
        clsBusinessLayerBank objBusinessbank = new clsBusinessLayerBank();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        objEntityBank.BankId = Convert.ToInt32(strP_Id);
        objEntityBank.Corporate_id = intCorpId;
        DataTable dtBankById = objBusinessbank.ReadBankById(objEntityBank);
        if (dtBankById.Rows.Count > 0)
        {
            txtBankName.Value = dtBankById.Rows[0]["BANK_NAME"].ToString();
            txtAddress.Value = dtBankById.Rows[0]["BANK_ADDRESS"].ToString();
            txtAccNo.Value = dtBankById.Rows[0]["BANK_ACC_NO"].ToString();
            txtBankSwiftCode.Value = dtBankById.Rows[0]["BANK_SWIFT_CODE"].ToString();
            txtIBan.Value = dtBankById.Rows[0]["BANK_I_BAN_NO"].ToString();
            txtIfscCode.Value = dtBankById.Rows[0]["BANK_IFSC_CODE"].ToString();
            //EVM-0027
            txtBankShortName.Value = dtBankById.Rows[0]["BANK_SHORT_NAME"].ToString();
            //END
           
            int intBankStatus = Convert.ToInt32(dtBankById.Rows[0]["BANK_STATUS"]);
            if (intBankStatus == 1)
            {
                cbxStatus.Checked = true;
            }
            else
            {
                cbxStatus.Checked = false;
            }
            //EVM-0027 sep18
            int intBankHCMStatus = Convert.ToInt32(dtBankById.Rows[0]["BANK_HCM"]);
            if (intBankHCMStatus == 1)
            {
                chkHCM.Checked = true;
            }
            else
            {
                chkHCM.Checked = false;
            }


            if (dtBankById.Rows[0]["BANK_AS_LDGER"].ToString() == "1")
            {
                cbxLedgerSts.Checked = true;
                if (dtBankById.Rows[0]["LDGR_TTLCNT"].ToString() != "0")
                {
                    cbxLedgerSts.Disabled = true;
                }


                if (dtBankById.Rows[0]["LDGR_CODE"].ToString() != "")
                {
                    txtLedgrCode.Value = dtBankById.Rows[0]["LDGR_CODE"].ToString();
                }
            }
            else
            {
                cbxLedgerSts.Checked = false;
            }
            HiddenFieldLedgerId.Value = dtBankById.Rows[0]["LDGR_ID"].ToString();
            if (HiddenFieldLedgerId.Value != "")
            {
                //   txtBankName.Enabled = false;
                //  ddlCustomerType.Focus();
            }
            if (dtBankById.Rows[0]["COSTCNTR_CNCL_USR_ID"].ToString() != "0")
            {
                HiddenCostCntrCnclId.Value = dtBankById.Rows[0]["COSTCNTR_CNCL_USR_ID"].ToString();
            }

            if (dtBankById.Rows[0]["BANK_AS_LDGER"].ToString() == "1")
            {


                if (dtBankById.Rows[0]["COSTCNTR_ID"].ToString() != "")
                {
                    hiddenCostCntrId.Value = dtBankById.Rows[0]["COSTCNTR_ID"].ToString();


                    clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
                    clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();
                    int  intOrgId = 0, intUserId = 0;
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
                        //ddlCC.ClearSelection();
                        if (ddlCC.Items.FindByValue(dt.Rows[0]["COSTGRP_ID"].ToString()) != null)
                        {
                            ddlCC.Items.FindByValue(dt.Rows[0]["COSTGRP_ID"].ToString()).Selected = true;
                        }
                        else
                        {
                            ListItem lstGrp = new ListItem(dt.Rows[0]["COSTGRP_NAME"].ToString(), dt.Rows[0]["COSTGRP_ID"].ToString());
                            ddlCC.Items.Insert(1, lstGrp);
                            //SortDDL(ref this.ddlCC);
                            ddlCC.Items.FindByValue(dt.Rows[0]["COSTGRP_ID"].ToString()).Selected = true;
                        }
                    }



                }
                else
                {
                    hiddenCostCntrId.Value = "";
                }


                //if (dtBankById.Rows[0]["LDGR_TDS"].ToString() == "0")
                //{
                //    radioTDSyes.Checked = true;
                //}
                //else
                //{
                //    radioTDSno.Checked = true;
                //}
                //if (dtBankById.Rows[0]["LDGR_TCS"].ToString() == "0")
                //{
                //    radioTCSyes.Checked = true;
                //}
                //else
                //{
                //    radioTCSno.Checked = true;
                //}
                if (dtBankById.Rows[0]["LDGR_COST_CNTR"].ToString() == "0")
                {
                    cbxCsCntrSts.Checked = true;
                    if (dtBankById.Rows[0]["CSCNTR_TTLCNT"].ToString() != "0")
                    {
                        cbxCsCntrSts.Disabled = true;
                        cbxLedgerSts.Disabled = true;
                    }

                    if (dtBankById.Rows[0]["COSTCNTR_CODE"].ToString() != "")
                    {
                        txtCostCntrCode.Value = dtBankById.Rows[0]["COSTCNTR_CODE"].ToString();
                    }
                }
                else
                {
                    cbxCsCntrSts.Checked = false;
                }
                //if (dtBankById.Rows[0]["TX_DDCTN_ID"].ToString() != "" && dtBankById.Rows[0]["TX_DDCTN_ID"].ToString() != null)
                //{

                //    if (ddlTDS.Items.FindByValue(dtBankById.Rows[0]["TX_DDCTN_ID"].ToString()) != null)
                //    {
                //        ddlTDS.Items.FindByValue(dtBankById.Rows[0]["TX_DDCTN_ID"].ToString()).Selected = true;
                //    }
                //    else
                //    {
                //        ListItem lstGrp = new ListItem(dtBankById.Rows[0]["TX_DDCTN_NAME"].ToString(), dtBankById.Rows[0]["TX_DDCTN_ID"].ToString());
                //        ddlTDS.Items.Insert(1, lstGrp);
                //        SortDDL(ref this.ddlTDS);
                //        ddlTDS.Items.FindByValue(dtBankById.Rows[0]["TX_DDCTN_ID"].ToString()).Selected = true;
                //    }
                //}
                //if (dtBankById.Rows[0]["TX_CLTN_ID"].ToString() != "" && dtBankById.Rows[0]["TX_CLTN_ID"].ToString() != null)
                //{
                //    if (ddlTCS.Items.FindByValue(dtBankById.Rows[0]["TX_CLTN_ID"].ToString()) != null)
                //    {
                //        ddlTCS.Items.FindByValue(dtBankById.Rows[0]["TX_CLTN_ID"].ToString()).Selected = true;
                //    }
                //    else
                //    {
                //        ListItem lstGrp = new ListItem(dtBankById.Rows[0]["TX_CLTN_NAME"].ToString(), dtBankById.Rows[0]["TX_CLTN_ID"].ToString());
                //        ddlTCS.Items.Insert(1, lstGrp);
                //        SortDDL(ref this.ddlTCS);
                //        ddlTCS.Items.FindByValue(dtBankById.Rows[0]["TX_CLTN_ID"].ToString()).Selected = true;
                //    }
                //}
                //if (ddlCurrency.Items.FindByValue(dtBankById.Rows[0]["CRNCMST_ID"].ToString()) != null)
                //{
                //    ddlCurrency.Items.FindByValue(dtBankById.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                //}
                //else
                //{
                //    ListItem lstGrp = new ListItem(dtBankById.Rows[0]["CRNCMST_NAME"].ToString(), dtBankById.Rows[0]["CRNCMST_ID"].ToString());
                //    ddlCurrency.Items.Insert(1, lstGrp);
                //    SortDDL(ref this.ddlCurrency);
                //    ddlCurrency.Items.FindByValue(dtBankById.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                //}

                int DC_STS = 0;
                if (dtBankById.Rows[0]["LDGR_MODE"].ToString() == "")
                {
                    txtOpenBalanceDeb.Value = null;
                    txtOpenBalanceDeb.Attributes["style"] = "display:none;";
                }
                if (dtBankById.Rows[0]["LDGR_MODE"].ToString() != "")
                {
                    DC_STS = Convert.ToInt32(dtBankById.Rows[0]["LDGR_MODE"].ToString());


                    string openingBal = dtBankById.Rows[0]["LDGR_OPEN_BAL"].ToString();

                    string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(openingBal.ToString(), objEntityCommon);
                    if (DC_STS == 0)
                    {
                        txtOpenBalanceDeb.Value = openingBal;

                        DandC.Attributes["style"] = "  display: block;";
                        typdebit.Checked = true;
                    }
                    else if (DC_STS == 1)
                    {
                        txtOpenBalanceDeb.Value = openingBal;

                        DandC.Attributes["style"] = " display: block;";
                        typecredit.Checked = true;
                    }
                }

            }
            //END
            //END
        }
        txtBankName.Disabled = true;
        txtIfscCode.Disabled = true;
        txtIBan.Disabled = true;
        txtBankSwiftCode.Disabled = true;
        txtAddress.Disabled = true;
        txtAccNo.Disabled = true;
        txtBankShortName.Disabled = true;
        cbxStatus.Disabled = true;
        chkHCM.Disabled = true;
        cbxCsCntrSts.Disabled = true;
        cbxLedgerSts.Disabled = true;
        cbxCsCntrSts.Disabled = true;
        txtOpenBalanceDeb.Disabled = true;
        typdebit.Disabled = true;
        typecredit.Disabled = true;
        txtLedgrCode.Disabled = true;
        txtCostCntrCode.Disabled = true;
        if (HiddenTaxEnable.Value == "1")
        {
            //ddlTCS.Enabled = false;
            //ddlTDS.Enabled = false;
            //radioTCSyes.Disabled = true;
            //radioTCSno.Disabled = true;
            //radioTDSyes.Disabled = true;
            //radioTDSno.Disabled = true;
            ddlCC.Disabled = true;
            rdExpense.Disabled = true;
            rdIncome.Disabled = true;
        }
    }




    public void LoadAccountGrp()
    {
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        clsBusinessLayer objBusinessCommon = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
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
      //  objEntityLedger.ActModeId = Convert.ToInt32(clsCommonLibrary.ASMOD_ID.bank);
       objEntityLedger.ActModeId = 5;
     //   DataTable dtdiv = objBusinessLedger.ReadAccountGrps(objEntityLedger);
        objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.BANK));
        //  DataTable dtdiv = objBusinessLedger.ReadAccountGrps(objEntityLedger);
        DataTable dtdiv = objBusinessCommon.ReadAccountGrps(objEntityCommon);
        if (dtdiv.Rows.Count > 0)
        {
            SaleAcntGrpId = Convert.ToInt32(dtdiv.Rows[0]["ACNT_GRP_ID"].ToString());
            HiddenAcntGrpSts.Value = "0";

            HiddenDefaultAcntGrpId.Value = dtdiv.Rows[0]["ACNT_GRP_ID"].ToString();
        }
        else
        {

            HiddenAcntGrpSts.Value = "1";
           // ScriptManager.RegisterStartupScript(this, GetType(), "AcntGrpErrMsg", "AcntGrpErrMsg();", true);
        }
        if (dtdiv.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SundryDebtorSelect", "SundryDebtorSelect();", true);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityLayerBank objEntityBank = new clsEntityLayerBank();
        clsBusinessLayerBank objBusinessbank = new clsBusinessLayerBank();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityBank.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityBank.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (cbxStatus.Checked == true)
        {
            objEntityBank.Status = 1;
        }
       
        else
        {
            objEntityBank.Status = 0;
        }
        //EVM-0027 Sep 18
        if (chkHCM.Checked == true)
        {
            objEntityBank.HCMStatus = 1;
        }

        else
        {
            objEntityBank.HCMStatus = 0;
        }
        //END
        if (Session["USERID"] != null)
        {
            objEntityBank.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityBank.BankDate = System.DateTime.Now;
        objEntityBank.BankName = txtBankName.Value.Trim();
        objEntityBank.AccNo = txtAccNo.Value.Trim();
        objEntityBank.BankAddrs = txtAddress.Value.Trim();
        objEntityBank.IfscCode = txtIfscCode.Value.Trim();
        objEntityBank.SwiftCode = txtBankSwiftCode.Value.Trim();
        objEntityBank.IBank = txtIBan.Value.Trim();
        //EVM-0027
        objEntityBank.BankShortName = txtBankShortName.Value.Trim();
        //END


        List<clsEntityLayerBank> objEntityPerfomList = new List<clsEntityLayerBank>();
     
        if (HiddenAddChkBook.Value != "" && HiddenAddChkBook.Value != null && HiddenAddChkBook.Value != "[]")
        {
            string jsonDataDltAttch = HiddenAddChkBook.Value;
            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
            string strAtt2 = strAtt1.Replace("\\", "");
            string strAtt3 = strAtt2.Replace("}\"]", "}]");
            string strAtt4 = strAtt3.Replace("}\",", "},");
            List<clsGrpDetails> objVideoDataDltAttList = new List<clsGrpDetails>();
            //   UserData  data
            objVideoDataDltAttList = JsonConvert.DeserializeObject<List<clsGrpDetails>>(strAtt4);

            foreach (clsGrpDetails objClsVideoAddAttData in objVideoDataDltAttList)
            {
             


                string str=objClsVideoAddAttData.ROWNUM.ToString();

                clsEntityLayerBank objSubEntity = new clsEntityLayerBank();
                objSubEntity.ChequeBk = Request.Form["ddlProduct_" + str];
                objSubEntity.ChkNumFrm = Convert.ToInt32(Request.Form["txtChqFrom" + str]);
                objSubEntity.ChkNumTo = Convert.ToInt32(Request.Form["txtChqTo" + str]);
                objSubEntity.ChkStatus = Convert.ToInt32(Request.Form["tdChkSts" + str]);
                objSubEntity.ChkTemp = Convert.ToInt32(Request.Form["tdChkTemp" + str]);
                objSubEntity.UpdOrIns = Request.Form["tdEvt" + str];


                if (objSubEntity.ChkStatus != 0)
                {
                    if (Request.Form["tdCanclLeaf" + str] != "")
                    {

                        objSubEntity.CancelChqSts = 1;
                    }
                    else
                    {
                        objSubEntity.CancelChqSts = 0;
                    }
                    objSubEntity.ChqCnclRsn = Request.Form["tdCanclLeaf" + str];
                    objSubEntity.ChequeLfNums = Request.Form["tdCanclReas" + str];

                }
                    //  string s= Request.Form["tdEvtQstn" + str];

                    objEntityPerfomList.Add(objSubEntity);
                




             

            }
        }

        string strNameCount = objBusinessbank.CheckBankName(objEntityBank);


        if (strNameCount == "0")
        {

            if (cbxLedgerSts.Checked == true)
            {
                objEntityBank.LedgerSts = 1;
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
                createCodeByLevel(objEntityLedger.Org_Id, objEntityLedger.Corp_Id);//evm 0044
                objEntityLedger.LdgrCode = txtLedgrCode.Value.Trim();


                objEntityLedger.LedgerName = txtBankName.Value.Trim();
                objEntityLedger.AccountGrpId = SaleAcntGrpId;
                // objEntityLedger.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                objEntityLedger.LedgerAddess = txtAddress.Value.Trim();
                if (HiddenTaxEnable.Value == "0")
                {
                    objEntityLedger.TxEnabledSts = 0;
                }
                else
                {
                    if (HiddenAccountSpecific.Value == "1")
                    {
                        objEntityLedger.TxEnabledSts = 1;
                        //if (radioTDSno.Checked == true)
                        //{
                        objEntityLedger.TDSstatus = 1;
                        //}
                        //else
                        //{
                        //    objEntityLedger.TDSid = Convert.ToInt32(ddlTDS.SelectedItem.Value);
                        //}
                        //if (radioTCSno.Checked == true)
                        //{
                        objEntityLedger.TCSstatus = 1;
                        //}
                        //else
                        //{
                        //    objEntityLedger.TCSid = Convert.ToInt32(ddlTCS.SelectedItem.Value);
                        //}
                    }
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

                if (txtOpenBalanceDeb.Value.Trim() != "")
                {
                    decimal OpenBalance = 0;
                    OpenBalance = objEntityLedger.DebitBalance;
                    if (typdebit.Checked)
                    {
                        objEntityLedger.DebitBalance = Convert.ToDecimal(txtOpenBalanceDeb.Value.Trim());
                        //   objEntityLedger.CreditBalance = (objEntityLedger.CreditBalance - OpenBalance) + Convert.ToDecimal(txtblnce.Text.Trim());
                        objEntityLedger.LedgerStatus = 0;
                    }
                    else
                    {
                        objEntityLedger.DebitBalance = Convert.ToDecimal(txtOpenBalanceDeb.Value.Trim());
                        //  objEntityLedger.CreditBalance = (objEntityLedger.CreditBalance - OpenBalance) - Convert.ToDecimal(txtblnce.Text.Trim());
                        objEntityLedger.LedgerStatus = 1;

                    }
                }


                objEntityLedger.PageSts = 2;

                List<clsEntityLedger> objEntitySubLedgerList = new List<clsEntityLedger>();


                DataTable dt = objBusinessLedger.CheckDupName(objEntityLedger);
                string strCodeCount = objBusinessLedger.CheckCodeDuplicatn(objEntityLedger);


                if (dt.Rows.Count == 0 && strNameCount == "0" && strCodeCount=="0")
                {

                    //Start:-Cost Center insert
                    string strNameCostCount = "0";
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
                        objEntity.grpId = Convert.ToInt32(ddlCC.Value.ToString());
                        if (rdExpense.Checked == true)
                        {
                            objEntity.Nature = 1;
                        }
                        objEntity.Name = txtBankName.Value.Trim();
                        objEntity.Status = 1;

                        if (HiddenCodeSts.Value != "")
                        {
                            objEntity.CodePrsntSts = Convert.ToInt32(HiddenCodeSts.Value);
                        }

                        if (HiddenCodeFormate.Value != "")
                        {
                            objEntity.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
                        }
                        CreateCostCntrCode();//evm 0044
                        objEntity.GrpCode = txtCostCntrCode.Value.Trim();



                        if (txtOpenBalanceDeb.Value != "" && txtOpenBalanceDeb.Value != null)
                        {
                            objEntity.Balance = Convert.ToDecimal(txtOpenBalanceDeb.Value.ToString());
                            if (typdebit.Checked == true)
                            {
                                objEntity.DCStatus = 0;
                            }
                            else
                            {
                                objEntity.DCStatus = 1;
                            }

                        }

                        strNameCostCount = objBusinessCostCenter.CheckCostName(objEntity);
                        strCstCodeCount = objBusinessCostCenter.CheckCodeDuplicatn(objEntity);

                        if (strNameCostCount == "0" && strCstCodeCount=="0")
                        {
                            string costID = objBusinessCostCenter.InsertCostCenter(objEntity);
                            objBusinessCostCenter.UpdateCostGroupNextId(objEntity);//evm 0044
                            objEntityLedger.CostCenterID = Convert.ToInt32(costID);
                        }
                        else
                        {
                            if (strNameCostCount != "0"  )
                            strNameCount = "1";

                            else if (strCstCodeCount != "0")
                            {
                                strNameCount = "5";
                            }
                        }
                    }
                    //End:-Cost Center insert

                    if (strNameCount == "0")
                    {

                        objBusinessLedger.AddLedger(objEntityLedger, objEntitySubLedgerList);
                        if (objEntityLedger.LedgerId > 0)//evm 0044
                        {
                            objBusinessLedger.UpdateLedgerId(objEntityLedger.LedgerId);
                        }
                        objEntityBank.LedgerId = objEntityLedger.LedgerId;
                    }
                }
                else
                {
                    if (dt.Rows.Count != 0)
                    {
                        strNameCount = "2";
                    }
                    else if (strCodeCount != "0")
                    {
                        strNameCount = "4";
                    }
                }
                //End:-Save to ledger table
            }
        }
        else
        {
            strNameCount = "3";
        }

        //Checking is there table have any name like this
     
        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            objBusinessbank.AddBankName(objEntityBank, objEntityPerfomList);
            if (Request.QueryString["RFGP"] == "RFG")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedBankToRFG", "PassSavedBankToRFG(" + objEntityBank.BankId + ");", true);
            }
            else
            {
                if (clickedButton.ID == "btnAdd" || clickedButton.ID == "btnAddF")
                {
                    Response.Redirect("gen_Bank_Master.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose" || clickedButton.ID == "btnAddCloseF")
                {
                    Response.Redirect("gen_Bank_Master_List.aspx?InsUpd=Ins");
                }
            }
        }
        //If have
        else
        {

            if (strNameCount == "5")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCstCntrCodeMsg", "DuplicationCstCntrCodeMsg();", true);
                txtCostCntrCode.Focus();
            }

            if (strNameCount == "4")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationLedgrCodeMsg", "DuplicationLedgrCodeMsg();", true);
                txtLedgrCode.Focus();
            }

            if (strNameCount == "3")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtBankName.Focus();
            }
            if (strNameCount == "2")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationNameLedgr", "DuplicationNameLedgr();", true);
                txtBankName.Focus();
            }
            if (strNameCount == "1")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationNameCostCntr", "DuplicationNameCostCntr();", true);
                txtBankName.Focus();
            }
        }
       
    }

    public class clsGrpDetails
    {
        public string ROWNUM { get; set; }
     



    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityLayerBank objEntityBank = new clsEntityLayerBank();
            clsBusinessLayerBank objBusinessbank = new clsBusinessLayerBank();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityBank.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityBank.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            //EVM-0027 Sep 18
            if (chkHCM.Checked == true)
            {
                objEntityBank.HCMStatus = 1;
            }

            else
            {
                objEntityBank.HCMStatus = 0;
            }
            //END

            if (cbxStatus.Checked == true)
            {
                objEntityBank.Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityBank.Status = 0;
            }
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityBank.BankId = Convert.ToInt32(strId);
         
            if (Session["USERID"] != null)
            {
                objEntityBank.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            objEntityBank.BankDate = System.DateTime.Now;
            objEntityBank.BankName = txtBankName.Value.Trim();
            objEntityBank.AccNo = txtAccNo.Value.Trim();
            objEntityBank.BankAddrs = txtAddress.Value.Trim();
            objEntityBank.IfscCode = txtIfscCode.Value.Trim();
            objEntityBank.SwiftCode = txtBankSwiftCode.Value.Trim();
            objEntityBank.IBank = txtIBan.Value.Trim();
            //EVM-0027
            objEntityBank.BankShortName = txtBankShortName.Value.Trim();
            //END



            List<clsEntityLayerBank> objEntityPerfomList = new List<clsEntityLayerBank>();

            if (HiddenAddChkBook.Value != "" && HiddenAddChkBook.Value != null && HiddenAddChkBook.Value != "[]")
            {
                string jsonDataDltAttch = HiddenAddChkBook.Value;
                string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
                string strAtt2 = strAtt1.Replace("\\", "");
                string strAtt3 = strAtt2.Replace("}\"]", "}]");
                string strAtt4 = strAtt3.Replace("}\",", "},");
                List<clsGrpDetails> objVideoDataDltAttList = new List<clsGrpDetails>();
                //   UserData  data
                objVideoDataDltAttList = JsonConvert.DeserializeObject<List<clsGrpDetails>>(strAtt4);

                foreach (clsGrpDetails objClsVideoAddAttData in objVideoDataDltAttList)
                {



                    string str = objClsVideoAddAttData.ROWNUM.ToString();

                    clsEntityLayerBank objSubEntity = new clsEntityLayerBank();
                    objSubEntity.ChequeBk = Request.Form["ddlProduct_" + str];
                    objSubEntity.ChkNumFrm = Convert.ToInt32(Request.Form["txtChqFrom" + str]);
                    objSubEntity.ChkNumTo = Convert.ToInt32(Request.Form["txtChqTo" + str]);
                    objSubEntity.ChkStatus = Convert.ToInt32(Request.Form["tdChkSts" + str]);
                    objSubEntity.ChkTemp = Convert.ToInt32(Request.Form["tdChkTemp" + str]);
                    objSubEntity.UpdOrIns = Request.Form["tdEvt" + str];
                    if (Request.Form["tdEvt" + str].ToString() == "UPD")
                    {
                        objSubEntity.ChkBookId = Convert.ToInt32(Request.Form["tdDtlId" + str]);
                    }
                    //  string s= Request.Form["tdEvtQstn" + str];
                    if (objSubEntity.ChkStatus != 0)
                    {
                        if (Request.Form["tdCanclLeaf" + str] != "")
                        {

                            objSubEntity.CancelChqSts = 1;
                        }
                        else
                        {
                            objSubEntity.CancelChqSts = 0;
                        }
                        objSubEntity.ChqCnclRsn = Request.Form["tdCanclLeaf" + str];
                        objSubEntity.ChequeLfNums = Request.Form["tdCanclReas" + str];

                    }

                    objEntityPerfomList.Add(objSubEntity);


                }
            }

            string strCanclDtlId = "";
            string[] strarrCancldtlIds = strCanclDtlId.Split(',');
            if (hiddenCkBookCanclDtlId.Value != "" && hiddenCkBookCanclDtlId.Value != null)
            {
                strCanclDtlId = hiddenCkBookCanclDtlId.Value;
                strarrCancldtlIds = strCanclDtlId.Split(',');

            }





            objEntityBank.BankId = Convert.ToInt32(strId);
            string strNameCount = objBusinessbank.CheckBankName(objEntityBank);
            if (HiddenFieldLedgerId.Value != "")
            {
                objEntityBank.LedgerId = Convert.ToInt32(HiddenFieldLedgerId.Value);
            }
            if (strNameCount == "0")
            {


                if (cbxLedgerSts.Checked == true)
                {
                    objEntityBank.LedgerSts = 1;
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
                    if (hiddenCostCntrId.Value != "")
                    {
                        //  objEntityLedger.CostId = Convert.ToInt32(hiddenCostCntrId.Value);
                        objEntityLedger.CostCenterID = Convert.ToInt32(hiddenCostCntrId.Value);
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
                    objEntityLedger.LedgerName = txtBankName.Value.Trim();
                    objEntityLedger.AccountGrpId = SaleAcntGrpId;
                    DataTable dtBankById = objBusinessbank.ReadBankById(objEntityBank);
                    //evm 0044
                    int updatests=0;
                    int updcostcntrstatus=0;
                    if (dtBankById.Rows.Count > 0)
                    {
                        int ldgrid = 0;
                        if (dtBankById.Rows[0]["LDGR_CODE"].ToString() == "")
                        {
                            ldgrid = 0;
                        }
                        else
                        {
                            ldgrid = Convert.ToInt32(dtBankById.Rows[0]["LDGR_CODE"].ToString());
                        }
                        if (txtLedgrCode.Value.Trim() != "")
                        {
                            if (ldgrid != Convert.ToInt32(txtLedgrCode.Value.Trim()))
                            {
                                createCodeByLevel(objEntityLedger.Org_Id, objEntityLedger.Corp_Id);
                                updatests = 1;
                            }
                        }
                    }
                            
                                
                      //------------------

                    objEntityLedger.LdgrCode = txtLedgrCode.Value.Trim();
                    if (dtBankById.Rows.Count > 0)
                    {
                        if(dtBankById.Rows[0]["ACNT_GRP_ID"].ToString()!="")
                        objEntityLedger.AccountGrpId = Convert.ToInt32(dtBankById.Rows[0]["ACNT_GRP_ID"].ToString());
                    }
                    //  objEntityLedger.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                    objEntityLedger.LedgerAddess = txtAddress.Value.Trim();
                    if (HiddenTaxEnable.Value == "0")
                    {
                        objEntityLedger.TxEnabledSts = 0;
                    }
                    else
                    {
                        if (HiddenAccountSpecific.Value == "1")
                        {
                            objEntityLedger.TxEnabledSts = 1;
                            //if (radioTDSno.Checked == true)
                            //{
                            objEntityLedger.TDSstatus = 1;
                            //}
                            //else
                            //{
                            //    objEntityLedger.TDSid = Convert.ToInt32(ddlTDS.SelectedItem.Value);
                            //}
                            //if (radioTCSno.Checked == true)
                            //{
                            objEntityLedger.TCSstatus = 1;
                            //}
                            //else
                            //{
                            //    objEntityLedger.TCSid = Convert.ToInt32(ddlTCS.SelectedItem.Value);
                            //}
                        }
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

                    if (txtOpenBalanceDeb.Value.Trim() != "")
                    {
                        decimal OpenBalance = 0;
                        OpenBalance = objEntityLedger.DebitBalance;
                        objEntityLedger.DebitBalance = Convert.ToDecimal(txtOpenBalanceDeb.Value.Trim());
                        if (typdebit.Checked)
                        {

                            //   objEntityLedger.CreditBalance = (objEntityLedger.CreditBalance - OpenBalance) + Convert.ToDecimal(txtblnce.Text.Trim());
                            objEntityLedger.LedgerStatus = 0;
                        }
                        else
                        {

                            //  objEntityLedger.CreditBalance = (objEntityLedger.CreditBalance - OpenBalance) - Convert.ToDecimal(txtblnce.Text.Trim());
                            objEntityLedger.LedgerStatus = 1;

                        }
                    }


                    objEntityLedger.PageSts = 2;


                    if (HiddenFieldLedgerId.Value != "")
                    {
                        objEntityLedger.LedgerId = Convert.ToInt32(HiddenFieldLedgerId.Value);
                    }

                    List<clsEntityLedger> objEntitySubLedgerList = new List<clsEntityLedger>();

                    DataTable dt = objBusinessLedger.CheckDupName(objEntityLedger);
                    string strCodeCount = objBusinessLedger.CheckCodeDuplicatn(objEntityLedger);

                    if (dt.Rows.Count == 0 && strNameCount == "0" && strCodeCount == "0")
                    {

                        //Start:-Cost Center insert
                        string strNameCostCount = "0";
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
                            if (hiddenCostCntrId.Value != "")
                            {
                                objEntity.CostId = Convert.ToInt32(hiddenCostCntrId.Value);
                            }


                            if (txtOpenBalanceDeb.Value != "" && txtOpenBalanceDeb.Value != null)
                            {
                                objEntity.Balance = Convert.ToDecimal(txtOpenBalanceDeb.Value.ToString());
                                if (typdebit.Checked == true)
                                {
                                    objEntity.DCStatus = 0;
                                }
                                else
                                {
                                    objEntity.DCStatus = 1;
                                }

                            }

                            if (HiddenCodeSts.Value != "")
                            {
                                objEntity.CodePrsntSts = Convert.ToInt32(HiddenCodeSts.Value);
                            }

                            if (HiddenCodeFormate.Value != "")
                            {
                                objEntity.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
                            }
                            //evm 0044
                            if (dt.Rows.Count > 0)
                            {
                                  if (Convert.ToInt32(dt.Rows[0]["COSTGRP_ID"].ToString()) != Convert.ToInt32(ddlCC.Value))
                                  {
                                      CreateCostCntrCode();
                                      updcostcntrstatus = 1;
                                  }
                   
                            }


                            objEntity.GrpCode = txtCostCntrCode.Value.Trim();



                            objEntity.grpId = Convert.ToInt32(ddlCC.Value.ToString());
                            if (rdExpense.Checked == true)
                            {
                                objEntity.Nature = 1;
                            }
                            objEntity.Name = txtBankName.Value.Trim();
                            objEntity.Status = 1;
                            strNameCostCount = objBusinessCostCenter.CheckCostName(objEntity);

                            strCstCodeCount = objBusinessCostCenter.CheckCodeDuplicatn(objEntity);

                            if (strNameCostCount != "0")
                            {
                                strNameCount = "3";
                            }
                            else if (strCstCodeCount != "0")
                            {
                                strNameCount = "5";
                            }
                            if (strNameCount == "0" && hiddenCostCntrId.Value == "")
                            {
                                string costID = objBusinessCostCenter.InsertCostCenter(objEntity);
                                objBusinessCostCenter.UpdateCostGroupNextId(objEntity);// evm 0044
                                objEntityLedger.CostCenterID = Convert.ToInt32(costID);
                                hiddenCostCntrId.Value = costID;

                            }
                            else if (strNameCount == "0")
                            {
                                objBusinessCostCenter.UpdateCostCenter(objEntity);
                                 //evm 0044
                                if (updcostcntrstatus  == 1)
                                {
                                    objBusinessCostCenter.UpdateCostGroupNextId(objEntity);// evm 0044
                                }


                                //  strNameCount = "1";
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
                            if (hiddenCostCntrId.Value != "" && HiddenCostCntrCnclId.Value == "")
                            {
                                objBusinessCostCenter.DeleteCostCenter(objEntity);
                            }
                        }
                        //End:-Cost Center insert


                        if (strNameCount == "0")
                        {
                            if (HiddenFieldLedgerId.Value != "")
                            {
                                if (hiddenCostCntrId.Value != "")
                                {
                                    objEntityLedger.CostCenterID = Convert.ToInt32(hiddenCostCntrId.Value);
                                }

                                objEntityLedger.LedgerId = Convert.ToInt32(HiddenFieldLedgerId.Value);
                                if (updatests == 1)//evm 0044
                                {
                                    objBusinessLedger.UpdateLedgerId(objEntityLedger.LedgerId);
                                }
                                objBusinessLedger.UpdateLedger(objEntityLedger, objEntitySubLedgerList);
                                objBusinessLedger.UpdateLedgerId(objEntityLedger.LedgerId);//evm 0044
                            }
                            else
                            {
                                objBusinessLedger.AddLedger(objEntityLedger, objEntitySubLedgerList);

                                objEntityBank.LedgerId = objEntityLedger.LedgerId;
                            }
                        }

                    }
                    else
                    {
                        if (dt.Rows.Count != 0)
                        {
                            strNameCount = "2";
                        }
                        else if (strCodeCount != "0")
                        {
                            strNameCount = "4";

                        }
                    }
                    //End:-Save to ledger table
                }
                else if (HiddenFieldLedgerId.Value != "")
                {
                    clsEntitySupplier objEntitySupplier = new clsEntitySupplier();
                    clsBusinessLayerSupplier objBusinessSupplier = new clsBusinessLayerSupplier();
                    if (Session["USERID"] != null)
                    {

                        objEntitySupplier.User_Id = Convert.ToInt32(Session["USERID"]);
                    }
                    else if (Session["USERID"] == null)
                    {
                        Response.Redirect("/Default.aspx");
                    }

                    objEntitySupplier.LedgerId = Convert.ToInt32(HiddenFieldLedgerId.Value);
                    objBusinessSupplier.UpdateLedgerSts(objEntitySupplier);

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
                    if (hiddenCostCntrId.Value != "" && HiddenCostCntrCnclId.Value == "")
                    {
                        objBusinessCostCenter.DeleteCostCenter(objEntity);
                    }

                }
            }
            else
            {
                strNameCount = "1";
            }
            //Checking is there table have any name like this
          //  string strNameCount = objBusinessbank.CheckBankName(objEntityBank);
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                objBusinessbank.UpdateBankName(objEntityBank, objEntityPerfomList, strarrCancldtlIds);
                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnUpdateF")
                {
                    Response.Redirect("gen_Bank_Master.aspx?Id=" + Request.QueryString["Id"]+"&InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnUpdateCloseF")
                {
                    Response.Redirect("gen_Bank_Master_List.aspx?InsUpd=Upd");
                }

            }
            //If have

            else
            {
                if (strNameCount == "1")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                    txtBankName.Focus();
                }
                if (strNameCount == "2")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationNameLedgr", "DuplicationNameLedgr();", true);
                    txtBankName.Focus();
                }
                if (strNameCount == "3")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationNameCostCntr", "DuplicationNameCostCntr();", true);
                    txtBankName.Focus();
                }

                if (strNameCount == "5")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCstCntrCodeMsg", "DuplicationCstCntrCodeMsg();", true);
                    txtCostCntrCode.Focus();
                }

                if (strNameCount == "4")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationLedgrCodeMsg", "DuplicationLedgrCodeMsg();", true);
                    txtLedgrCode.Focus();
                }


            }
        }

    }
   
}