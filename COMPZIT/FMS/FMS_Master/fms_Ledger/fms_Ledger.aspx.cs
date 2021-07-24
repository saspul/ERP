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

public partial class FMS_FMS_Master_fms_Ledger_fms_Ledger : System.Web.UI.Page
{
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

        txtCode.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtCode.Attributes.Add("onkeydown", "return DisableEnter(event)");

        if (!IsPostBack)
        {
            clsEntityLedger objEntityLedger = new clsEntityLedger();
            clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();

            LoadCurrencies();
            LoadAccountGrp();
            LoadCostGroup();
            LoadTCS();
            LoadLedgers("0");
            LoadTDS();
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
                objEntityLedger.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString()); ;
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
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST,
                                                          clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                          clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                          clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED   ,
                                                          clsCommonLibrary.CORP_GLOBAL.FMS_VIEW_CODE_STS ,
                                                          clsCommonLibrary.CORP_GLOBAL.FMS_CODE_FORMATE,
                                                          clsCommonLibrary.CORP_GLOBAL.FMS_CODE_NUMBER_FORMAT,
    
                                                       };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenCodeStatus.Value = dtCorpDetail.Rows[0]["FMS_VIEW_CODE_STS"].ToString();
                HiddenFieldDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
                if (dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString() != "")
                {
                    hiddenTaxEnabled.Value = dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString();
                }
                if (dtCorpDetail.Rows[0]["FMS_CODE_FORMATE"].ToString() != "")
                {
                    HiddenCodeFormate.Value = dtCorpDetail.Rows[0]["FMS_CODE_FORMATE"].ToString();
                }

                if (dtCorpDetail.Rows[0]["FMS_CODE_NUMBER_FORMAT"].ToString() != "")
                {
                    if (dtCorpDetail.Rows[0]["FMS_CODE_NUMBER_FORMAT"].ToString() == "1")
                    {
                        txtCode.Attributes.Add("onkeypress", "return isNumber(event)");
                        txtCode.Attributes.Add("onkeydown", "return isNumber(event)");
                        txtCode.Attributes.Add("onblur", "RemoveNaN_OnBlur('cphMain_txtCode')");
                    }
                    hiddenCodeNumberFrmt.Value = dtCorpDetail.Rows[0]["FMS_CODE_NUMBER_FORMAT"].ToString();
                }

            }
            if (hiddenTaxEnabled.Value == "0")//tax not enabled
            {
                DivTdcTcs.Visible = false;
            }
            else
            {
                DivTdcTcs.Visible = true;//tax  enabled

            }
            if (HiddenCodeFormate.Value == "1")
            {

                txtCode.Enabled = true;
              


            }
            else
            {
               
                txtCode.Enabled = false;
                
                divCostCntrCode.Disabled = true;
            }


            if (HiddenCodeStatus.Value == "1")
            {
                DivLedgerCode.Visible = true;
                divCostCntrCode.Visible = true;
            }
            else
            {
                DivLedgerCode.Visible = false;
                divCostCntrCode.Visible = false;
            }


            DataTable dtTaxationSystem = objBusinessLedger.ReadLedgerTaxationSystem(objEntityLedger);

            if (dtTaxationSystem.Rows.Count > 0)
            {
                lblTaxSystem.InnerText = dtTaxationSystem.Rows[0]["TAXATION_SYSTEM"].ToString();
            }


            DataTable dtCurrencyDetail = new DataTable();


            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
            }
            if (Request.QueryString["Id"] != null)
            {
                pathCurr.InnerText = "Edit Ledger";
                lblEntry.InnerText = "Edit Ledger";
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                LoadLedgers(strId);

                bttnsave.Visible = false;
                btnSaveAndClose.Visible = false;
                btnUpdate.Visible = true;
                btnUpdateAndClose.Visible = true;
                btnCancel.Visible = true;
                ButnClear.Visible = false;
                Update(strId, 0);

                HiddenMode.Value = "0";
            }
            else if (Request.QueryString["ViewId"] != null)
            {
                pathCurr.InnerText = "View Ledger";
                lblEntry.InnerText = "View Ledger";
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                LoadLedgers(strId);

                spanFromDate.Attributes["style"] = "pointer-events:none;";
                bttnsave.Visible = false;
                btnSaveAndClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                btnUpdateAndClose.Visible = false;
                btnCancel.Visible = true;
                ButnClear.Visible = false;
                Update(strId, 1);
                HiddenMode.Value = "1";
            }


            else
            {
                pathCurr.InnerText = "Add Ledger";
                lblEntry.InnerText = "Add Ledger";
                btnUpdate.Visible = false;
                btnUpdateAndClose.Visible = false;
                //  DivLedgerCode.Visible = false;
                HiddenMode.Value = "2";
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
            txtName.Focus();
        }

    }

    [WebMethod]
    public static string CrateCodeFormateCostCntr(string orgID, string corptID, string CstGrpId)
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

        string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);

        if (dtFormate.Rows.Count > 0)
        {
            if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
            {
                refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
                string strReferenceFormat = "";
                strReferenceFormat = refFormatByDiv;
                string[] arrReferenceSplit = strReferenceFormat.Split('*');
                int intArrayRowCount = arrReferenceSplit.Length;
                int Codecount = 0;
                strRealFormat = refFormatByDiv.ToString();

                if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
                {
                    Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
                }

                if (strRealFormat.Contains("#NUM#"))
                {
                    strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);
                }
                if (strRealFormat.Contains("#CSTGRP#"))
                {
                    strRealFormat = strRealFormat.Replace("#CSTGRP#", CstGrpId);
                }

                int k = strRealFormat.Length;
                if (k < Codecount)
                {
                    int Difrnce = Codecount - k;
                    k = k + Difrnce;
                    //  hello.PadLeft(50, '#');
                    strRealFormat = strRealFormat.PadLeft(k, '0');
                }
               
            }
        }
        else
        {
            strRealFormat = dtNextNumber;
        }

        sts = strRealFormat;

        return sts.ToString();
    }
    //----evm 0044
    [WebMethod]
    public static string CreateCodeFormateCostCntr(string orgID, string corptID, string CstGrpId)
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

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.COST_CENTER);
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

        txtCostCntrCode .Text = strRealFormat;
    }
    //---------


    [WebMethod]
    public static string CrateCodeFormate(string orgID, string corptID, string AcntGrpId, string ldsts, string CodeNumberFormat)
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
        if (corptID != null)
        {
            intCorpId = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);
            objEntityLedger.Corp_Id = Convert.ToInt32(corptID);
            objEntityAccountGroup.CorpId = Convert.ToInt32(corptID);
        }

        if (orgID != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
            objEntityLedger.Org_Id = Convert.ToInt32(orgID);
            objEntityAccountGroup.OrgId = Convert.ToInt32(orgID);
        }

        //objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_LEDGER_MASTER);
        //DataTable dtFormate = objBusinessLayer.ReadCodeFormate(objEntityCommon);
        //string refFormatByDiv = "";
        string strRealFormat = "";

        DataTable dt = new DataTable();
        if (ldsts == "0")
        {
            if (AcntGrpId != "" && AcntGrpId != "--SELECT ACCOUNT GROUP--")
            {
                objEntityLedger.LedgerId = Convert.ToInt32(AcntGrpId);
            }
            else
            {
                if (AcntGrpId != "")
                {
                    objEntityLedger.LedgerId = Convert.ToInt32(AcntGrpId);
                    objEntityLedger.LedgerAcntGrpSts = 1;
                    dt = objBusinessLedger.ReadAccountGrp_Of_Ledgr(objEntityLedger);


                }


            }
                  
            //objEntityLedger.LedgerAcntGrpSts = 0;
            //dt = objBusinessLedger.ReadAccountGrp_Of_Ledgr(objEntityLedger);
            objEntityLedger.SubLedgerStatus = 0;
            objEntityLedger.AccountGrpId = Convert.ToInt32(AcntGrpId);
            objEntityAccountGroup.AccountGrpId = Convert.ToInt32(AcntGrpId);
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
            else
            {
                  //evm 0044------
              
                int subldgrnextnum = 0;
                objEntityLedger.SubLedgerId  = Convert.ToInt32(AcntGrpId);
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
                            strRealFormat  = dtactgroup.Rows[0]["LDGR_CODE"].ToString() + Convert.ToString(subldgrnextnum);
                        }
                    }
                    else
                    {
                        subldgrnextnum = Convert.ToInt32(dtactgroup.Rows[0]["LDGR_NEXTID_LEDGER"].ToString());
                        strRealFormat = dtactgroup.Rows[0]["LDGR_CODE"].ToString() + Convert.ToString(subldgrnextnum);
                    }
                }

            }

        

        
        objEntityLedger.LdgrCode = strRealFormat;
        

        //string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);

        //if (dtFormate.Rows.Count > 0)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        if (CodeNumberFormat == "0")
        //        {
        //            string StrAcntGrpId = "";
        //            int NaureCode = 0;
        //            int intNature = Convert.ToInt32(dt.Rows[0]["ACNT_NATURE_STS"].ToString());
        //            StrAcntGrpId = dt.Rows[0]["ACNT_GRP_ID"].ToString();

        //            if (intNature == 0)
        //            {
        //                NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Asset);
        //            }
        //            else if (intNature == 1)
        //            {
        //                NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Liability);
        //            }
        //            else if (intNature == 2)
        //            {
        //                NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Expense);
        //            }
        //            else if (intNature == 3)
        //            {
        //                NaureCode = Convert.ToInt32(clsCommonLibrary.Acnt_Nature.Income);
        //            }

        //            if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
        //            {
        //                refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
        //                string strReferenceFormat = "";
        //                strReferenceFormat = refFormatByDiv;
        //                string[] arrReferenceSplit = strReferenceFormat.Split('*');
        //                int intArrayRowCount = arrReferenceSplit.Length;
        //                int Codecount = 0;
        //                strRealFormat = refFormatByDiv.ToString();

        //                if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
        //                {
        //                    Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
        //                }

        //                if (strRealFormat.Contains("#NAT#"))
        //                {
        //                    strRealFormat = strRealFormat.Replace("#NAT#", NaureCode.ToString());
        //                }
        //                if (strRealFormat.Contains("#NUM#"))
        //                {
        //                    strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);
        //                }
        //                if (strRealFormat.Contains("#ACNTGRP#"))
        //                {
        //                    strRealFormat = strRealFormat.Replace("#ACNTGRP#", StrAcntGrpId);
        //                }

        //                int k = strRealFormat.Length;
        //                if (k < Codecount)
        //                {
        //                    int Difrnce = Codecount - k;
        //                    k = k + Difrnce;
        //                    //  hello.PadLeft(50, '#');
        //                    strRealFormat = strRealFormat.PadLeft(k, '0');
        //                }
        //            }
        //            else
        //            {
        //                strRealFormat = dtNextNumber;
        //            }
        //        }
        //        else
        //        {
        //            strRealFormat = dtNextNumber;
        //        }
        //    }
        //}
        //else
        //{
        //    strRealFormat = dtNextNumber;
        //}

        sts = strRealFormat;

        return sts.ToString();
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

    public void LoadLedgers(string Id)
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
        objEntityLedger.LedgerId = Convert.ToInt32(Id);

        DataTable dtdiv = objBusinessLedger.ReadLedgers(objEntityLedger);
        if (dtdiv.Rows.Count > 0)
        {
            ddlLedger.DataSource = dtdiv;
            ddlLedger.DataTextField = "LDGR_NAME";
            ddlLedger.DataValueField = "LDGR_ID";
            ddlLedger.DataBind();
        }
        ddlLedger.Items.Insert(0, "--SELECT LEDGER--");
    }

    public void LoadAccountGrp()
    {
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
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
        // DataTable dtdiv = objBusinessLedger.ReadAccountGrpsLedgr(objEntityLedger);
        DataTable dtdiv = objBusiness.ReadAccountGrps(objEntityCommon);
        if (dtdiv.Rows.Count > 0)
        {
            ddlAccountGrp.DataSource = dtdiv;
            ddlAccountGrp.DataTextField = "ACNT_GRP_NAME";
            ddlAccountGrp.DataValueField = "ACNT_GRP_ID";
            ddlAccountGrp.DataBind();
        }
        ddlAccountGrp.Items.Insert(0, "--SELECT ACCOUNT GROUP--");
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


    protected void bttnsave_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsEntityLedger objEntityLedger = new clsEntityLedger();
            clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
            //evm 0044
            clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
            clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLedger.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
                objEntityAccountGroup.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]); ;//evm 004
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLedger.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityAccountGroup.OrgId = Convert.ToInt32(Session["ORGID"].ToString());//evm 0044
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityLedger.User_Id = Convert.ToInt32(Session["USERID"]);
                objEntityAccountGroup.UserId = Convert.ToInt32(Session["USERID"]);//evm 0044
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objEntityLedger.LedgerName = txtName.Text.Trim();
            if (cbxSubLedger.Checked)
            {
                objEntityLedger.SubLedgerStatus = 1;
                objEntityLedger.SubLedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
                //evm 0044------
                createCodeByLevel(objEntityLedger.Org_Id, objEntityLedger.Corp_Id);
                
            }
            else
            {
               objEntityLedger.SubLedgerStatus = 0;
               objEntityLedger.AccountGrpId = Convert.ToInt32(ddlAccountGrp.SelectedItem.Value);
               objEntityAccountGroup.AccountGrpId = Convert.ToInt32(ddlAccountGrp.SelectedItem.Value); ;
               //evm 0044------
               createCodeByLevel(objEntityLedger.Org_Id, objEntityLedger.Corp_Id);
            }
            objEntityLedger.LdgrCode = txtCode.Text.Trim();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            //if (ddlAccountGrp.SelectedItem.Text == "BANK")
            //{
            //    objEntityLedger.EffectiveDate = objCommon.textToDateTime(txtDateFrom.Value);
            //}

            objEntityLedger.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            objEntityLedger.ContactName = txtCommName.Text.Trim();
            if (txtPinCode.Text.Trim() != "")
            {
                objEntityLedger.LedgerZIP = Convert.ToInt32(txtPinCode.Text.Trim());
            }
            objEntityLedger.LedgerTax = txtTAXno.Text.Trim();
            objEntityLedger.LedgerAddess = txtAddress.Text.Trim();

            if (hiddenTaxEnabled.Value == "1")
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

            if (Chksts.Checked == true)
            {
                objEntityLedger.Status = 1;
            }

            if (txtCreditLimit.Text != "" && txtCreditLimit.Text != null)
                objEntityLedger.CreditLimit = Convert.ToDecimal(txtCreditLimit.Text);

            if (txtCreditPeriod.Text != "" && txtCreditPeriod.Text != null)
                objEntityLedger.CreditPeriod = Convert.ToInt32(txtCreditPeriod.Text);

            if (cbxCrdtLmtRestrict.Checked == true)
            {
                objEntityLedger.CreditLimitRestrict = 1;
            }
            if (cbxCrdtLmtWarn.Checked == true)
            {
                objEntityLedger.CreditLimitWarn = 1;
            }
            if (cbxCrdtPeriodRestrict.Checked == true)
            {
                objEntityLedger.CreditPeriodRestrict = 1;
            }
            if (cbxCrdtPeriodWarn.Checked == true)
            {
                objEntityLedger.CreditPeriodWarn = 1;
            }

            if (HiddenCodeStatus.Value != "")
            {
                objEntityLedger.CodePrsntSts = Convert.ToInt32(HiddenCodeStatus.Value);
            }

            if (HiddenCodeFormate.Value != "")
            {
                objEntityLedger.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
            }
            if (hiddenCodeNumberFrmt.Value != "")
            {
                objEntityLedger.CodeFormatNumber = Convert.ToInt32(hiddenCodeNumberFrmt.Value);
            }


           
            if (txtOpenBalanceDeb.Text.Trim() != "")
            {
                if (typdebit.Checked)
                {
                    objEntityLedger.DebitBalance = Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                    //objEntityLedger.CreditBalance = objEntityLedger.CreditBalance + Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                    objEntityLedger.LedgerStatus = 0;
                }
                else
                {
                    objEntityLedger.DebitBalance = Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                    //objEntityLedger.CreditBalance = objEntityLedger.CreditBalance - Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                    objEntityLedger.LedgerStatus = 1;

                }
            }

            List<clsEntityLedger> objEntitySubLedgerList = new List<clsEntityLedger>();
            
            if (cbxSubLedger.Checked == true)
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

            DataTable dt = objBusinessLedger.CheckDupName(objEntityLedger);

            string strCodeCount = objBusinessLedger.CheckCodeDuplicatn(objEntityLedger);

            string strNameCountss = "0";
            objEntityLedger.PrimaryGrp = Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.BANK);
            DataTable dtChkDiv = objBusinessLedger.CheckAccountGroup(objEntityLedger);
            if (dtChkDiv.Rows.Count > 0)
            {
                if (dtChkDiv.Rows[0]["CNT_LDGR"].ToString() == "1")
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
                    objEntityBank.BankName = txtName.Text.Trim();
                    if (hiddenPostBankId.Value != "")
                    {
                        objEntityBank.BankId = Convert.ToInt32(hiddenPostBankId.Value);
                    }
                    strNameCountss = objBusinessbank.CheckBankName(objEntityBank);


                }
            }


            if (dt.Rows.Count == 0 && strCodeCount == "0" && strNameCountss == "0")
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

                    if (HiddenCodeStatus.Value != "")
                    {
                        objEntity.CodePrsntSts = Convert.ToInt32(HiddenCodeStatus.Value);
                    }

                    if (HiddenCodeFormate.Value != "")
                    {
                        objEntity.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
                    }
                    CreateCostCntrCode();//evm 0044
                    objEntity.GrpCode = txtCostCntrCode.Text.Trim();

                    if (txtOpenBalanceDeb.Text != "" && txtOpenBalanceDeb.Text != null)
                    {
                        objEntity.Balance = Convert.ToDecimal(txtOpenBalanceDeb.Text.ToString());
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
                    if (rdExpense.Checked == true)
                    {
                        objEntity.Nature = 1;
                    }
                    objEntity.Name = txtName.Text.Trim();
                    objEntity.Status = 1;




                    strNameCount = objBusinessCostCenter.CheckCostName(objEntity);

                    strCstCodeCount = objBusinessCostCenter.CheckCodeDuplicatn(objEntity);




                    if (strNameCount == "0" && strCstCodeCount == "0")
                    {
                        string costID = objBusinessCostCenter.InsertCostCenter(objEntity);
                        objBusinessCostCenter.UpdateCostGroupNextId(objEntity);// evm 0044
                        
                        objEntityLedger.CostCenterID = Convert.ToInt32(costID);
                    }
                }

                if (hiddenPostBankId.Value != "")
                {
                    objEntityLedger.BankId = Convert.ToInt32(hiddenPostBankId.Value);
                }

                if (hiddenCustmrSupplierMode.Value == "1")
                {
                    if (cbxCustomer.Checked == true)
                    {
                        objEntityLedger.CustmrSupplierSts = 1;
                    }
                }
                else if (hiddenCustmrSupplierMode.Value == "2")
                {
                    if (cbxSupplier.Checked == true)
                    {
                        objEntityLedger.CustmrSupplierSts = 2;
                    }
                }


                //End:-Cost Center insert
                if (strNameCount == "0" && strCstCodeCount == "0")
                {
                   objBusinessLedger.AddLedger(objEntityLedger, objEntitySubLedgerList);
                    if (objEntityLedger .LedgerId>0 )
                    {
                        objBusinessLedger.UpdateLedgerId(objEntityLedger.LedgerId);
                    }
                    if (clickedButton.ID == "bttnsave")
                    {
                        Response.Redirect("fms_Ledger.aspx?InsUpd=Ins");
                    }
                    else if (clickedButton.ID == "btnSaveAndClose")
                    {
                        Response.Redirect("fms_Ledger_List.aspx?InsUpd=Ins");
                    }
                }
                else
                {
                    if (strNameCount != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DupNameCost", "DupNameCost();", true);
                    }
                    else if (strCstCodeCount != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCstCntrCodeMsg", "DuplicationCstCntrCodeMsg();", true);

                    }

                }
            }
            else
            {
                if (dt.Rows.Count != 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DupName", "DupName();", true);
                }

                else if (strCodeCount != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationLedgrCodeMsg", "DuplicationLedgrCodeMsg();", true);
                    txtCode.Focus();
                }
                else if (strNameCountss != "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationBank", "DuplicationBank();", true);
                }
                // ScriptManager.RegisterStartupScript(this, GetType(), "DupName", "DupName();", true);
            }
        }
        catch (Exception)
        {
        }
    }
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
            objEntityAccountGroup.AccountGrpId = Convert.ToInt32(ddlAccountGrp.SelectedItem.Value);

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
                        txtCode .Text = dtledger.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subldgrnum);
                    }
                }
                else
                {
                    subldgrnum = Convert.ToInt32(dtledger.Rows[0]["ACNT_NEXTID_LEDGER"].ToString());
                    txtCode.Text = dtledger.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subldgrnum);
                }
            }
        }
        else if (cbxSubLedger .Checked == true)
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
                        txtCode.Text = dtactgroup.Rows[0]["LDGR_CODE"].ToString() + Convert.ToString(subldgrnextnum);
                    }
                }
                else
                {
                    subldgrnextnum = Convert.ToInt32(dtactgroup.Rows[0]["LDGR_NEXTID_LEDGER"].ToString());
                    txtCode.Text = dtactgroup.Rows[0]["LDGR_CODE"].ToString() + Convert.ToString(subldgrnextnum);
                }
            }
        }
    }
    public void Update(string strP_Id, int mode)
    {
        try
        {
            clsEntityLedger objEntityLedger = new clsEntityLedger();
            clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
            if (Session["USERID"] != null)
            {
                objEntityLedger.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLedger.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
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
            objEntityLedger.LedgerId = Convert.ToInt32(strP_Id);
            DataTable dt = objBusinessLedger.ReadLedgerDtlsById(objEntityLedger);
            if (dt.Rows.Count > 0)
            {

                hiddenPostBankId.Value = dt.Rows[0]["BANK_ID"].ToString();

                txtName.Text = dt.Rows[0]["LDGR_NAME"].ToString();

                if (dt.Rows[0]["LDGR_SUB_LDER"].ToString() == "1")
                {
                    ddlLedger.ClearSelection();

                    if (ddlLedger.Items.FindByValue(dt.Rows[0]["SUBLEDGERID"].ToString()) != null)
                    {
                        ddlLedger.Items.FindByValue(dt.Rows[0]["SUBLEDGERID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dt.Rows[0]["SUBLEDGER"].ToString(), dt.Rows[0]["SUBLEDGERID"].ToString());
                        ddlLedger.Items.Insert(1, lstGrp);
                        SortDDL(ref this.ddlAccountGrp);
                        ddlLedger.Items.FindByValue(dt.Rows[0]["SUBLEDGERID"].ToString()).Selected = true;
                    }
                    cbxSubLedger.Checked = true;

                    objEntityLedger.AccountGrpId = Convert.ToInt32(dt.Rows[0]["SUBLEDGERID"].ToString());
                }
                else
                {
                    ddlAccountGrp.ClearSelection();

                    if (ddlAccountGrp.Items.FindByValue(dt.Rows[0]["ACNT_GRP_ID"].ToString()) != null)
                    {
                        ddlAccountGrp.Items.FindByValue(dt.Rows[0]["ACNT_GRP_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dt.Rows[0]["ACNT_GRP_NAME"].ToString(), dt.Rows[0]["ACNT_GRP_ID"].ToString());
                        ddlAccountGrp.Items.Insert(1, lstGrp);
                        SortDDL(ref this.ddlAccountGrp);
                        ddlAccountGrp.Items.FindByValue(dt.Rows[0]["ACNT_GRP_ID"].ToString()).Selected = true;
                    }
                    cbxSubLedger.Checked = false;
                    if (dt.Rows[0]["ACNT_GRP_ADRES_STS"].ToString() == "1")
                    {
                        divDisplayCommunication.Attributes["style"] = "display:block;";
                    }
                    else
                    {
                        divDisplayCommunication.Attributes["style"] = "display:none;";
                    }

                    objEntityLedger.AccountGrpId = Convert.ToInt32(dt.Rows[0]["ACNT_GRP_ID"].ToString());
                }

                //ddlCurrency.ClearSelection();
                //if (ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()) != null)
                //{
                //    ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                //}
                //else
                //{
                //    ListItem lstGrp = new ListItem(dt.Rows[0]["CRNCMST_NAME"].ToString(), dt.Rows[0]["CRNCMST_ID"].ToString());
                //    ddlCurrency.Items.Insert(1, lstGrp);
                //    SortDDL(ref this.ddlCurrency);
                //    ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                //}
                int DC_STS = 0;
                if (dt.Rows[0]["LDGR_MODE"].ToString() == "")
                {
                    txtOpenBalanceDeb.Text = null;
                    //DandC.Attributes["style"] = "float: right; margin-top: 2.2%; width: 85%;display:none;";
                }
                if (dt.Rows[0]["LDGR_MODE"].ToString() != "")
                {
                    DC_STS = Convert.ToInt32(dt.Rows[0]["LDGR_MODE"].ToString());
                    if (DC_STS == 0)
                    {


                        if (dt.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                        {
                            txtOpenBalanceDeb.Text = dt.Rows[0]["LDGR_OPEN_BAL"].ToString();
                            objEntityLedger.DebitBalance = Convert.ToDecimal(dt.Rows[0]["LDGR_OPEN_BAL"].ToString());
                        }
                        //DandC.Attributes["style"] = "display:block;float: right; margin-top: 2.2%; width: 85%;";
                        typdebit.Checked = true;
                    }
                    else if (DC_STS == 1)
                    {
                        if (dt.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                        {
                            txtOpenBalanceDeb.Text = dt.Rows[0]["LDGR_OPEN_BAL"].ToString();

                            objEntityLedger.DebitBalance = Convert.ToDecimal(dt.Rows[0]["LDGR_OPEN_BAL"].ToString());
                        }
                        //DandC.Attributes["style"] = "float: right; width: 85%;display:block;";
                        typecredit.Checked = true;
                    }
                }
                if (dt.Rows[0]["LDGR_CURRENT_BAL"].ToString() != "")
                {
                    objEntityLedger.CreditBalance = Convert.ToDecimal(dt.Rows[0]["LDGR_CURRENT_BAL"].ToString());
                }
                if (dt.Rows[0]["LDGR_TDS"].ToString() == "0")
                {
                    radioTDSyes.Checked = true;
                }
                else
                {
                    radioTDSyes.Checked = false;
                }
                if (dt.Rows[0]["LDGR_TCS"].ToString() == "0")
                {
                    radioTCSyes.Checked = true;
                }
                else
                {
                    radioTCSyes.Checked = false;
                }
                if (dt.Rows[0]["LDGR_COST_CNTR"].ToString() == "0")
                {
                    cbxCsCntrSts.Checked = true;


                    if (dt.Rows[0]["COSTCNTR_CODE"].ToString() != "")
                    {
                        txtCostCntrCode.Text = dt.Rows[0]["COSTCNTR_CODE"].ToString();
                    }



                    if (dt.Rows[0]["CSCNTR_TTLCNT"].ToString() != "0")
                    {
                        cbxCsCntrSts.Disabled = true;
                        //cbxLedgerSts.Enabled = false;
                    }
                }
                else
                {
                    cbxCsCntrSts.Checked = false;
                }
                if (dt.Rows[0]["LDGR_STATUS"].ToString() == "1")
                {
                    Chksts.Checked = true;
                }
                else
                {
                    Chksts.Checked = false;
                }

                if (dt.Rows[0]["LDGR_CRDT_LMT"].ToString() != "0")
                    txtCreditLimit.Text = dt.Rows[0]["LDGR_CRDT_LMT"].ToString();
                if (dt.Rows[0]["LDGR_CRDT_PERIOD"].ToString() != "0")
                    txtCreditPeriod.Text = dt.Rows[0]["LDGR_CRDT_PERIOD"].ToString();

                cbxCrdtLmtRestrict.Checked = false;
                cbxCrdtLmtWarn.Checked = false;
                cbxCrdtPeriodRestrict.Checked = false;
                cbxCrdtPeriodWarn.Checked = false;
                if (dt.Rows[0]["LDGR_CRDT_LMT_RESTRICT"].ToString() == "1")
                {
                    cbxCrdtLmtRestrict.Checked = true;
                }
                if (dt.Rows[0]["LDGR_CRDT_LMT_WARN"].ToString() == "1")
                {
                    cbxCrdtLmtWarn.Checked = true;
                }
                if (dt.Rows[0]["LDGR_CRDT_PERIDO_RESTRICT"].ToString() == "1")
                {
                    cbxCrdtPeriodRestrict.Checked = true;
                }
                if (dt.Rows[0]["LDGR_CRDT_PERIOD_WARN"].ToString() == "1")
                {
                    cbxCrdtPeriodWarn.Checked = true;
                }


                if (dt.Rows[0]["LDGR_CODE"].ToString() != "" && dt.Rows[0]["LDGR_CODE"].ToString() != null)
                    txtCode.Text = dt.Rows[0]["LDGR_CODE"].ToString();

                txtCommName.Text = dt.Rows[0]["LDGR_COMTN_NAME"].ToString();
                txtPinCode.Text = dt.Rows[0]["LDGR_PINCODE"].ToString();
                txtTAXno.Text = dt.Rows[0]["LDGR_TAXNO"].ToString();
                txtAddress.Text = dt.Rows[0]["LDGR_ADDRESS"].ToString();
                if (dt.Rows[0]["TX_DDCTN_ID"].ToString() != "" && dt.Rows[0]["TX_DDCTN_ID"].ToString() != null)
                {
                    ddlTDS.ClearSelection();
                    if (ddlTDS.Items.FindByValue(dt.Rows[0]["TX_DDCTN_ID"].ToString()) != null)
                    {
                        ddlTDS.Enabled = true;
                        ddlTDS.Items.FindByValue(dt.Rows[0]["TX_DDCTN_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dt.Rows[0]["TX_DDCTN_NAME"].ToString(), dt.Rows[0]["TX_DDCTN_ID"].ToString());
                        ddlTDS.Items.Insert(1, lstGrp);
                        SortDDL(ref this.ddlTDS);
                        ddlTDS.Items.FindByValue(dt.Rows[0]["TX_DDCTN_ID"].ToString()).Selected = true;
                    }
                }
                if (dt.Rows[0]["TX_CLTN_ID"].ToString() != "" && dt.Rows[0]["TX_CLTN_ID"].ToString() != null)
                {
                    ddlTCS.ClearSelection();
                    if (ddlTCS.Items.FindByValue(dt.Rows[0]["TX_CLTN_ID"].ToString()) != null)
                    {
                        ddlTCS.Enabled = true;
                        ddlTCS.Items.FindByValue(dt.Rows[0]["TX_CLTN_ID"].ToString()).Selected = true;
                    }
                    else
                    {
                        ListItem lstGrp = new ListItem(dt.Rows[0]["TX_CLTN_NAME"].ToString(), dt.Rows[0]["TX_CLTN_ID"].ToString());
                        ddlTCS.Items.Insert(1, lstGrp);
                        SortDDL(ref this.ddlTCS);
                        ddlTCS.Items.FindByValue(dt.Rows[0]["TX_CLTN_ID"].ToString()).Selected = true;
                    }
                }

                if (dt.Rows[0]["COSTCNTR_ID"].ToString() != "")
                {
                    hiddenCostCntrId.Value = dt.Rows[0]["COSTCNTR_ID"].ToString();
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
                    DataTable dts = objBusinessCostCenter.ReadCostCenterById(objEntity);
                    if (dts.Rows.Count > 0)
                    {
                        if (dts.Rows[0]["COSTCNTR_NATURE"].ToString() == "0")
                        {
                            rdIncome.Checked = true;
                        }
                        else
                        {
                            rdExpense.Checked = true;
                        }
                        ddlCC.ClearSelection();
                        if (ddlCC.Items.FindByValue(dts.Rows[0]["COSTGRP_ID"].ToString()) != null)
                        {
                            ddlCC.Items.FindByValue(dts.Rows[0]["COSTGRP_ID"].ToString()).Selected = true;
                        }
                        else
                        {
                            ListItem lstGrp = new ListItem(dts.Rows[0]["COSTGRP_NAME"].ToString(), dts.Rows[0]["COSTGRP_ID"].ToString());
                            ddlCC.Items.Insert(1, lstGrp);
                            SortDDL(ref this.ddlCC);
                            ddlCC.Items.FindByValue(dts.Rows[0]["COSTGRP_ID"].ToString()).Selected = true;
                        }
                    }

                }
                if (dt.Rows[0]["COSTCNTR_CNCL_USR_ID"].ToString() != "0")
                {
                    HiddenCostCntrCnclId.Value = dt.Rows[0]["COSTCNTR_CNCL_USR_ID"].ToString();
                }

                //   txtOpenBalanceDeb.Text = dt.Rows[0]["LDGR_BALANCE_DEBIT"].ToString();
                //  txtOpenBalanceCre.Text = dt.Rows[0]["LDGR_BALANCE_CREDIT"].ToString();

                if (dt.Rows[0]["LDGER_SUPPLIER_STS"].ToString() != "0" || dt.Rows[0]["BNK_STS"].ToString() != "0" || dt.Rows[0]["CUS_STS"].ToString() != "0" || dt.Rows[0]["SUP_STS"].ToString() != "0")
                {
                    txtName.Enabled = false;
                    ddlAccountGrp.Enabled = false;
                    ddlCurrency.Focus();
                    HiddenAccntSts.Value = "1";
                    cbxSubLedger.Disabled = true;
                }
                else if (dt.Rows[0]["COSTCNTR_ID"].ToString() != "")
                {
                    //hiddenCostCntrId.Value = dt.Rows[0]["COSTCNTR_ID"].ToString();
                    //   txtName.Enabled = false;
                    ddlAccountGrp.Focus();
                }
                txtDateFrom.Value = dt.Rows[0]["LDGR_EFFCTV_DATE"].ToString();

                string PredfndId = "";
                if (dt.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != "" && dt.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != null)
                {
                    PredfndId = dt.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString();
                }
                else if (dt.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != "" && dt.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != null)
                {
                    PredfndId = dt.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString();
                }
                hiddenCustmrSupplierMode.Value = "0";

                if (PredfndId == "5" || PredfndId == "6")
                {
                    divSupplier.Attributes.Add("style", "display:block");
                    if (dt.Rows[0]["LDGR_SUPPLIER_CSTMR_STS"].ToString() == "2")
                    {
                        cbxSupplier.Checked = true;
                    }
                    else
                    {
                        cbxSupplier.Checked = false;
                    }
                    hiddenCustmrSupplierMode.Value = "2";
                }
                else if (PredfndId == "7" || PredfndId == "8")
                {
                    divCustomer.Attributes.Add("style", "display:block");
                    if (dt.Rows[0]["LDGR_SUPPLIER_CSTMR_STS"].ToString() == "1")
                    {
                        cbxCustomer.Checked = true;
                    }
                    else
                    {
                        cbxCustomer.Checked = false;
                    }
                    hiddenCustmrSupplierMode.Value = "1";
                }
                decimal decOB = 0;
                decimal decLA = 0;
                decLA = Convert.ToDecimal(dt.Rows[0]["LEDGER_AMOUNT"].ToString());
                decOB = Convert.ToDecimal(dt.Rows[0]["VOCHR_OB"].ToString());
                if (DC_STS == 1)
                {
                    //debit
                    decOB = -1 * decOB;
                }

                if (decOB != decLA)
                {
                    typdebit.Disabled = true;
                    typecredit.Disabled = true;
                }
                hiddenOBBalncAmnt.Value = dt.Rows[0]["VOCHR_OB"].ToString();
                hiddenVBAmount.Value = dt.Rows[0]["LEDGER_AMOUNT"].ToString();

                objEntityLedger.PrimaryGrp = Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYDEBTR);

                DataTable dtChkDivCust = objBusinessLedger.CheckAccountGroup(objEntityLedger);
                if (dtChkDivCust.Rows.Count > 0)
                {
                    divCreditDtls.Attributes.Add("style", "display:block");
                }
                else
                {
                    divCreditDtls.Attributes.Add("style", "display:none");
                }

                objEntityLedger.PrimaryGrp = Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYCREDITR);

                DataTable dtChkDivSup = objBusinessLedger.CheckAccountGroup(objEntityLedger);
                if (dtChkDivSup.Rows.Count > 0)
                {
                    divCreditDtls.Attributes.Add("style", "display:block");
                }
                else
                {
                    divCreditDtls.Attributes.Add("style", "display:none");
                }


            }


            if (mode == 1)
            {
                txtName.Enabled = false;
                ddlAccountGrp.Enabled = false;
                ddlCurrency.Enabled = false;
                radioCostNo.Disabled = true;
                radioCostYes.Disabled = true;
                //radioTCSno.Disabled = true;
                radioTCSyes.Disabled = true;
                //radioTDSno.Disabled = true;
                radioTDSyes.Disabled = true;
                Chksts.Disabled = true;
                txtAddress.Enabled = false;
                txtCommName.Enabled = false;
                txtPinCode.Enabled = false;
                txtTAXno.Enabled = false;
                ddlTCS.Enabled = false;
                ddlTDS.Enabled = false;
                txtOpenBalanceCre.Enabled = false;
                txtOpenBalanceDeb.Enabled = false;
                txtDateFrom.Disabled = true;
                cbxCsCntrSts.Disabled = true;
                typdebit.Disabled = true;
                typecredit.Disabled = true;
                ddlCC.Enabled = false;
                rdExpense.Disabled = true;
                rdIncome.Disabled = true;
                txtCode.Enabled = false;
            
                txtCostCntrCode.Enabled = false;

            }
        }
        catch (Exception)
        {
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["Id"] != null)
            {
                Button clickedButton = sender as Button;
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
                objEntityLedger.LedgerName = txtName.Text.Trim();
                //evm 0044----------
                int updatests = 0;
                string strRandomMixedId1 = Request.QueryString["Id"].ToString();
                string strLenghtofId1 = strRandomMixedId1.Substring(0, 2);
                int intLenghtofId1 = Convert.ToInt16(strLenghtofId1);
                string strId1 = strRandomMixedId1.Substring(2, intLenghtofId1);
                objEntityLedger.LedgerId = Convert.ToInt32(strId1 );
                DataTable dtdata = objBusinessLedger.ReadLedgerDtlsById(objEntityLedger);
               //-----------
                if (cbxSubLedger.Checked)
                {
                    objEntityLedger.SubLedgerStatus = 1;
                    objEntityLedger.SubLedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
                    if (dtdata.Rows.Count > 0)
                    {
                        int subldgrid = 0;
                        if (dtdata.Rows[0]["SUBLEDGERID"].ToString() == "")
                        {
                            subldgrid = 0;
                        }
                        else
                        {
                            subldgrid =Convert.ToInt32(dtdata.Rows[0]["SUBLEDGERID"].ToString());
                        }
                        if (subldgrid  != Convert.ToInt32(ddlLedger.SelectedItem.Value))
                        {
                            createCodeByLevel(objEntityLedger.Org_Id, objEntityLedger.Corp_Id);
                            updatests = 1;
                          
                        }

                    }
                   

                }
                else
                {
                    objEntityLedger.SubLedgerStatus = 0;
                    objEntityLedger.AccountGrpId = Convert.ToInt32(ddlAccountGrp.SelectedItem.Value);
                    //---evm 0044--
                    if (dtdata.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dtdata.Rows[0]["ACNT_GRP_ID"].ToString()) != Convert.ToInt32(ddlAccountGrp.SelectedItem.Value))
                        {
                            createCodeByLevel(objEntityLedger.Org_Id, objEntityLedger.Corp_Id);
                            updatests = 1;
                           
                        }

                    }
                  
                   
                }
                objEntityLedger.LdgrCode = txtCode.Text.Trim();

                clsCommonLibrary objCommon = new clsCommonLibrary();
                //if (ddlAccountGrp.SelectedItem.Text == "BANK")
                //{
                //    objEntityLedger.EffectiveDate = objCommon.textToDateTime(txtDateFrom.Value);
                //}
                objEntityLedger.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                objEntityLedger.ContactName = txtCommName.Text.Trim();
                if (txtPinCode.Text.Trim() != "")
                {
                    objEntityLedger.LedgerZIP = Convert.ToInt32(txtPinCode.Text.Trim());
                }
                objEntityLedger.LedgerTax = txtTAXno.Text.Trim();
                objEntityLedger.LedgerAddess = txtAddress.Text.Trim();
                if (hiddenTaxEnabled.Value == "1")
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
                if (Chksts.Checked == true)
                {
                    objEntityLedger.Status = 1;
                }

                if (txtCreditLimit.Text != "" && txtCreditLimit.Text != null)
                    objEntityLedger.CreditLimit = Convert.ToDecimal(txtCreditLimit.Text);

                if (txtCreditPeriod.Text != "" && txtCreditPeriod.Text != null)
                    objEntityLedger.CreditPeriod = Convert.ToInt32(txtCreditPeriod.Text);

                if (cbxCrdtLmtRestrict.Checked == true)
                {
                    objEntityLedger.CreditLimitRestrict = 1;
                }
                if (cbxCrdtLmtWarn.Checked == true)
                {
                    objEntityLedger.CreditLimitWarn = 1;
                }
                if (cbxCrdtPeriodRestrict.Checked == true)
                {
                    objEntityLedger.CreditPeriodRestrict = 1;
                }
                if (cbxCrdtPeriodWarn.Checked == true)
                {
                    objEntityLedger.CreditPeriodWarn = 1;
                }

               

                if (HiddenCodeStatus.Value != "")
                {
                    objEntityLedger.CodePrsntSts = Convert.ToInt32(HiddenCodeStatus.Value);
                }

                if (HiddenCodeFormate.Value != "")
                {
                    objEntityLedger.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
                }
                if (hiddenCodeNumberFrmt.Value != "")
                {
                    objEntityLedger.CodeFormatNumber = Convert.ToInt32(hiddenCodeNumberFrmt.Value);
                }

                if (txtOpenBalanceDeb.Text.Trim() != "")
                {
                    decimal OpenBalance = 0;
                    OpenBalance = objEntityLedger.DebitBalance;
                    if (typdebit.Checked)
                    {

                        objEntityLedger.LedgerStatus = 0;
                        objEntityLedger.DebitBalance = Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                    }
                    else
                    {

                        objEntityLedger.LedgerStatus = 1;
                        objEntityLedger.DebitBalance = Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                    }
                }

                if (hiddenVouchrId.Value != "")
                {
                    objEntityLedger.VouchrId = Convert.ToInt32(hiddenVouchrId.Value);
                }



                //if (txtOpenBalanceDeb.Text.Trim() != "")
                //{
                //    decimal OpenBalance = 0;
                //    OpenBalance = objEntityLedger.DebitBalance;
                //    if (typdebit.Checked)
                //    {
                //        objEntityLedger.DebitBalance = Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                //        objEntityLedger.CreditBalance = (objEntityLedger.CreditBalance - OpenBalance) + Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                //        objEntityLedger.LedgerStatus = 0;
                //    }
                //    else
                //    {
                //        objEntityLedger.DebitBalance = Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                //        objEntityLedger.CreditBalance = (objEntityLedger.CreditBalance - OpenBalance) - Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                //        objEntityLedger.LedgerStatus = 1;

                //    }
                //}

                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                objEntityLedger.LedgerId = Convert.ToInt32(strRandomMixedId.Substring(2, intLenghtofId));


                List<clsEntityLedger> objEntitySubLedgerList = new List<clsEntityLedger>();

                if (cbxSubLedger.Checked == true)
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

                objEntityLedger.LedgerId = Convert.ToInt32(strRandomMixedId.Substring(2, intLenghtofId));

                DataTable dt = objBusinessLedger.CheckLedgerCnclSts(objEntityLedger);
                DataTable dtDup = objBusinessLedger.CheckDupName(objEntityLedger);

                string strCodeCount = objBusinessLedger.CheckCodeDuplicatn(objEntityLedger);

                if (strCodeCount != "0")
                {
                    strCodeCount = "1";
                }

                string strNameCountss = "0";
                objEntityLedger.PrimaryGrp = Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.BANK);
                DataTable dtChkDiv = objBusinessLedger.CheckAccountGroup(objEntityLedger);
                if (dtChkDiv.Rows.Count > 0)
                {
                    if (dtChkDiv.Rows[0]["CNT_LDGR"].ToString() == "1")
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
                        objEntityBank.BankName = txtName.Text.Trim();
                        if (hiddenPostBankId.Value != "")
                        {
                            objEntityBank.BankId = Convert.ToInt32(hiddenPostBankId.Value);
                        }
                        strNameCountss = objBusinessbank.CheckBankName(objEntityBank);


                    }
                }



                if (dtDup.Rows.Count == 0 && dt.Rows.Count == 0 && strCodeCount == "0" && strNameCountss == "0")
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


                        if (HiddenCodeStatus.Value != "")
                        {
                            objEntity.CodePrsntSts = Convert.ToInt32(HiddenCodeStatus.Value);
                        }

                        if (HiddenCodeFormate.Value != "")
                        {
                            objEntity.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
                        }
                        //evm 0044-----
                        int updcostcntrstatus = 0;
                        if (dtdata.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(dtdata.Rows[0]["COSTGRP_ID"].ToString()) != Convert.ToInt32(ddlCC .SelectedItem.Value))
                            {
                                CreateCostCntrCode();
                                updcostcntrstatus = 1;
                            }
                        }
                        //--------------------------
                        objEntity.GrpCode = txtCostCntrCode.Text.Trim();


                        if (txtOpenBalanceDeb.Text != "" && txtOpenBalanceDeb.Text != null)
                        {
                            objEntity.Balance = Convert.ToDecimal(txtOpenBalanceDeb.Text.ToString());
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
                        if (rdExpense.Checked == true)
                        {
                            objEntity.Nature = 1;
                        }
                        objEntity.Name = txtName.Text.Trim();
                        objEntity.Status = 1;
                        if (hiddenCostCntrId.Value != "")
                        {
                            objEntity.CostId = Convert.ToInt32(hiddenCostCntrId.Value);
                        }
                        strNameCount = objBusinessCostCenter.CheckCostName(objEntity);
                        strCstCodeCount = objBusinessCostCenter.CheckCodeDuplicatn(objEntity);

                        //End:-Cost Center insert
                        if (strNameCount == "0" && strCstCodeCount == "0")
                        {

                            if (hiddenCostCntrId.Value == "")
                            {
                                string costID = objBusinessCostCenter.InsertCostCenter(objEntity);
                                objEntityLedger.CostCenterID = Convert.ToInt32(costID);
                                hiddenCostCntrId.Value = costID;
                            }
                            else
                            {
                                objEntity.CostId = Convert.ToInt32(hiddenCostCntrId.Value);
                                objBusinessCostCenter.UpdateCostCenter(objEntity);
                                if (updcostcntrstatus == 1)
                                {
                                    objBusinessCostCenter.UpdateCostGroupNextId(objEntity);// evm 0044
                                }
                          
                            }
                        }
                        else
                        {
                            if (strNameCount != "0")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "DupNameCost", "DupNameCost();", true);
                                txtName.Focus();
                            }
                            else if (strCstCodeCount != "0")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationCstCntrCodeMsg", "DuplicationCstCntrCodeMsg();", true);
                                strCodeCount = "2";
                                txtCostCntrCode.Focus();
                            }
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


                        strNameCount = objBusinessCostCenter.CheckCostName(objEntity);

                        if (strNameCount == "0")
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
                }
                else
                {
                    if (dtDup.Rows.Count != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DupName", "DupName();", true);
                    }
                    else if (strCodeCount == "1")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationLedgrCodeMsg", "DuplicationLedgrCodeMsg();", true);

                    }
                    else if (strNameCountss != "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationBank", "DuplicationBank();", true);
                    }
                    // ScriptManager.RegisterStartupScript(this, GetType(), "DupName", "DupName();", true);
                }





                if (dt.Rows.Count == 0 && dtDup.Rows.Count == 0 && strCodeCount == "0" && strNameCountss == "0")
                {

                    if (hiddenCostCntrId.Value != "")
                    {
                        objEntityLedger.CostCenterID = Convert.ToInt32(hiddenCostCntrId.Value);
                    }

                    if (hiddenPostBankId.Value != "")
                    {
                        objEntityLedger.BankId = Convert.ToInt32(hiddenPostBankId.Value);
                    }

                    if (hiddenCustmrSupplierMode.Value == "1")
                    {
                        if (cbxCustomer.Checked == true)
                        {
                            objEntityLedger.CustmrSupplierSts = 1;
                        }
                    }
                    else if (hiddenCustmrSupplierMode.Value == "2")
                    {
                        if (cbxSupplier.Checked == true)
                        {
                            objEntityLedger.CustmrSupplierSts = 2;
                        }
                    }

                    objBusinessLedger.UpdateLedger(objEntityLedger, objEntitySubLedgerList);
                    //evm 0044
                    if (updatests ==1)
                    {
                        objBusinessLedger.UpdateLedgerId(objEntityLedger.LedgerId);
                    }

                    if (clickedButton.ID == "btnUpdate")
                    {
                        Response.Redirect("fms_Ledger.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnUpdateAndClose")
                    {
                        Response.Redirect("fms_Ledger_List.aspx?InsUpd=Upd");
                    }
                }
                else
                {
                    if (dt.Rows.Count > 0)
                    {

                        //Response.Redirect("fms_Ledger_List.aspx?InsUpd=UpdCancl");
                        Session["CANCEL_STS"] = "UpdCancl";
                        Response.Redirect("fms_Ledger_List.aspx");

                    }
                    else if (dtDup.Rows.Count > 0)
                    {


                        //  ScriptManager.RegisterStartupScript(this, GetType(), "DupName", "DupName();", true);
                    }
                }
            }
        }
        catch (Exception ex)
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

    [WebMethod]
    public static string ChkDisplayCommunicationDtl(string orgid, string corpid, string AcntGrpId)
    {
        string ret = "";
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        // decimal ret=0;
        objEntityLedger.Org_Id = Convert.ToInt32(orgid);
        objEntityLedger.Corp_Id = Convert.ToInt32(corpid);

        if (AcntGrpId != "--SELECT ACCOUNT GROUP--")
        {
            objEntityLedger.AccountGrpId = Convert.ToInt32(AcntGrpId);
            DataTable dtChkDiv = objBusinessLedger.ReadAddressApplicable(objEntityLedger);
            if (dtChkDiv.Rows.Count > 0)
            {
                if (dtChkDiv.Rows[0]["ACNT_GRP_ADRES_STS"].ToString() != "")
                {
                    ret = dtChkDiv.Rows[0]["ACNT_GRP_ADRES_STS"].ToString();

                }
            }
        }



        return ret;
    }

    [WebMethod]
    public static string[] LoadCheckAccountGroup(string AcntGrpId, string orgid, string corpid, string SubLedgerId)
    {
        string[] ret = new string[3];
        clsEntityLedger objEntityLedger = new clsEntityLedger();
        clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();
        ret[0] = "";
        ret[1] = "";

        objEntityLedger.Org_Id = Convert.ToInt32(orgid);
        objEntityLedger.Corp_Id = Convert.ToInt32(corpid);
        objEntityLedger.AccountGrpId = Convert.ToInt32(AcntGrpId);
        objEntityLedger.SubLedgerId = Convert.ToInt32(SubLedgerId);

        objEntityLedger.PrimaryGrp = Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.BANK);

        DataTable dtChkDivBank = objBusinessLedger.CheckAccountGroup(objEntityLedger);
        if (dtChkDivBank.Rows.Count > 0)
        {
            ret[0] = dtChkDivBank.Rows[0]["CNT_LDGR"].ToString();
        }

        objEntityLedger.PrimaryGrp = Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYDEBTR);

        DataTable dtChkDivCust = objBusinessLedger.CheckAccountGroup(objEntityLedger);
        if (dtChkDivCust.Rows.Count > 0)
        {
            ret[1] = dtChkDivCust.Rows[0]["CNT_LDGR"].ToString();
        }

        objEntityLedger.PrimaryGrp = Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYCREDITR);

        DataTable dtChkDivSup = objBusinessLedger.CheckAccountGroup(objEntityLedger);
        if (dtChkDivSup.Rows.Count > 0)
        {
            ret[2] = dtChkDivSup.Rows[0]["CNT_LDGR"].ToString();
        }


        return ret;
    }
}