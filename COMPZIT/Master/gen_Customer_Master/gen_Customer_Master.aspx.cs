using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using System.Data;
using CL_Compzit;
using System.Text;
using System.Collections;
using EL_Compzit;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Web.Services;
using BL_Compzit.BusinessLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
// CREATED BY:EVM-0002
// CREATED DATE:15/03/2016
// REVIEWED BY:
// REVIEW DATE:

public partial class Master_gen_Customer_Master_gen_Customer_Master : System.Web.UI.Page
{
    int SaleAcntGrpId = 0;
    //enumeration for category type
    private enum Category_Type
    {
        Main_Category = 1,
        Sub_Category = 2,
        Small_Category = 3,
        Least_Category = 4
    }

    //Creating objects for businesslayer

    clsBusinessLayerCustomer objBusinessLayerCustomer = new clsBusinessLayerCustomer();
    DataTable dtMedia = new DataTable();


    //protected void Page_PreInit(object sender, EventArgs e)
    //{
    //    if (Request.QueryString["CFAM"] != null || Request.QueryString["RFGP"] != null)
    //    {
    //        this.MasterPageFile = "~/MasterPage/MasterPage_Modal.master";

    //    }

    //    else
    //    {

    //        this.MasterPageFile = "~/MasterPage/MasterPageCompzit_Sales.master";
    //    }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {

        //Assigning  Key actions  .

        txtLedgrCode.Attributes.Add("onkeypress", "return DisableEnter(event)");
        txtLedgrCode.Attributes.Add("onkeydown", "return DisableEnter(event)");

        txtCustomerName.Attributes.Add("onkeypress", "return isTag(event)");
        txtCustomerName.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAddress1.Attributes.Add("onkeypress", "return isTag(event)");
        txtAddress1.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAddress2.Attributes.Add("onkeypress", "return isTag(event)");
        txtAddress2.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAddress3.Attributes.Add("onkeypress", "return isTag(event)");
        txtAddress3.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtZipCode.Attributes.Add("onkeypress", "return isTag(event)");
        txtZipCode.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtTinNumber.Attributes.Add("onkeypress", "return isTag(event)");
        txtTinNumber.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPhone.Attributes.Add("onkeypress", "return isTag(event)");
        txtPhone.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtEmail.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmail.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtWebSite.Attributes.Add("onkeypress", "return isTag(event)");
        txtWebSite.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtNameOne.Attributes.Add("onkeypress", "return isTag(event)");
        txtNameOne.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtNameTwo.Attributes.Add("onkeypress", "return isTag(event)");
        txtNameTwo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtNameThree.Attributes.Add("onkeypress", "return isTag(event)");
        txtNameThree.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtAddressOne.Attributes.Add("onkeypress", "return isTag(event)");
        txtAddressOne.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAddressTwo.Attributes.Add("onkeypress", "return isTag(event)");
        txtAddressTwo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtAddressThree.Attributes.Add("onkeypress", "return isTag(event)");
        txtAddressThree.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtPhoneOne.Attributes.Add("onkeypress", "return isTag(event)");
        txtPhoneOne.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPhoneTwo.Attributes.Add("onkeypress", "return isTag(event)");
        txtPhoneTwo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtPhoneThree.Attributes.Add("onkeypress", "return isTag(event)");
        txtPhoneThree.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtEmailOne.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmailOne.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtEmailTwo.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmailTwo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtEmailThree.Attributes.Add("onkeypress", "return isTag(event)");
        txtEmailThree.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        txtWebsiteOne.Attributes.Add("onkeypress", "return isTag(event)");
        txtWebsiteOne.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtWebsiteTwo.Attributes.Add("onkeypress", "return isTag(event)");
        txtWebsiteTwo.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        txtWebsiteThree.Attributes.Add("onkeypress", "return isTag(event)");
        txtWebsiteThree.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        ddlCustomerType.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlCustomerType.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCustomerGroup.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlCustomerGroup.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCountry.Attributes.Add("onkeypress", "return DisableEnter(event)");
        //ddlCountry.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlState.Attributes.Add("onkeypress", "return DisableEnter(event)");
        //ddlState.Attributes.Add("onchange", "IncrmntConfrmCounter()");
        ddlCity.Attributes.Add("onkeypress", "return DisableEnter(event)");
        ddlCity.Attributes.Add("onchange", "IncrmntConfrmCounter()");

        //cbxStatus.Attributes.Add("onkeypress", "return DisableEnter(event)");
        //cbxStatus.Attributes.Add("onchange", "IncrmntConfrmCounter()");


        LoadAccountGrp();
        if (!IsPostBack)
        {
            LoadCostGroup();
            LoadCurrencies();
            //EVM-0027 Aug 21
            LoadLedgers("0");
            //EVM-0027 Aug 21 END
            LoadTCS();
            LoadTDS();
            LoadDDLAccountGrp();
            HiddenTaxEnable.Value = "0";
            HiddenAcntGrpChngSts.Value = "0";
            cbxLedgerSts.Checked = false;
            //ddlLedger.Enabled = false;

            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED,
                                                            clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                            clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                            clsCommonLibrary.CORP_GLOBAL.FMS_VIEW_CODE_STS,
                                                               clsCommonLibrary.CORP_GLOBAL.FMS_CODE_FORMATE,
                                                               clsCommonLibrary.CORP_GLOBAL.FMS_CODE_NUMBER_FORMAT,
                                                           
                                                              };
            DataTable dtCorpDetail = new DataTable();

            int intCorpId = 0, intOrgid = 0, intUserId = 0, intUsrRolMstrId = 0;
            int intBusinessSpecific = 0, intAccountSpecific = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
                hiddenCorporateId.Value = Session["CORPOFFICEID"].ToString();
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgid = Convert.ToInt32(Session["ORGID"]);

                hiddenOrganisationId.Value = Session["ORGID"].ToString();

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            PaymentTermsLoad();
            PriceTermsLoad();
            DeliveryTermsLoad();
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Customer_Master);
            HiddenBusinessSpecific.Value = "0";
            HiddenAccountSpecific.Value = "0";
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.BUSINESS_SPECIFIC).ToString())
                    {
                        intBusinessSpecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenBusinessSpecific.Value = "1";
                    }

                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString())
                    {
                        intAccountSpecific = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenAccountSpecific.Value = "1";
                    }

                }
            }
            if (intBusinessSpecific == 1 && intAccountSpecific == 0)
            {
                Accounts.Visible = false;
            }
            else if (intBusinessSpecific == 0 && intAccountSpecific == 1)
            {
                Accounts.Visible = true;
            }
            else if (intBusinessSpecific == 1 && intAccountSpecific == 1)
            {

            }

            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenFieldDecimalCnt.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
            }

            if (dtCorpDetail.Rows.Count > 0)
            {
                int intDfltCurrencyMstrId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"]);
                HiddenCustomerCode.Value = dtCorpDetail.Rows[0]["FMS_VIEW_CODE_STS"].ToString();
                clsEntityCommon objEntityCommon = new clsEntityCommon();

                objEntityCommon.CurrencyId = intDfltCurrencyMstrId;
                DataTable dtCurrencyDetail = new DataTable();
                dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
                if (dtCurrencyDetail.Rows.Count > 0)
                {
                    hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                    hiddenCurrencyAbbrv.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
                }
                if (dtCorpDetail.Rows[0]["GN_TAX_ENABLED"] != DBNull.Value)
                {
                    //value 1 means commodity maintained corporate 
                    if (Convert.ToInt32(dtCorpDetail.Rows[0]["GN_TAX_ENABLED"]) == 1)
                    {
                        divTdsTcs.Attributes["style"] = "display:block;";
                        HiddenTaxEnable.Value = "1";
                        ScriptManager.RegisterStartupScript(this, GetType(), "VisibleTinNumber", "VisibleTinNumber();", true);
                    }
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
                txtLedgrCode.Enabled = false;
                txtCostCntrCode.Enabled = false;


            }



            if (HiddenCustomerCode.Value == "1")
            {
                //divCodeSts.Attributes["style"] = "display: block;";


            }
            else
            {
                //  divCodeSts.Attributes["style"] = "display: none;";
                divCode.Attributes["style"] = "display: none;";


            }


            dtMedia = objBusinessLayerCustomer.Read_Media_Master();
            if (dtMedia.Rows.Count == 0)
            {
            }
            else
            {
                string strMediaHtml = "";
                int intRowIdentity = 0;
                //automatically generate media controls based on media master
                for (int intRow = 0; intRow < dtMedia.Rows.Count; intRow++)
                {
                    string strTextboxName = dtMedia.Rows[intRow]["MEDIA_ID"].ToString();
                    if (intRowIdentity == 0)
                        strMediaHtml = strMediaHtml + " <div id=\"div7\" class=\"form-group fg2 fg2_mr sa_fg3 sa_640\">";
                    else
                        strMediaHtml = strMediaHtml + " <div id=\"div7\" class=\"form-group fg2 fg2_mr sa_fg3 sa_640\" >";
                    strMediaHtml = strMediaHtml + "<label for=\"email\" class=\"fg2_la1\"> " + dtMedia.Rows[intRow]["MEDIA_NAME"] + " <span class=\"spn1\"></span></label>";
                    if (intRowIdentity == 0)
                        strMediaHtml = strMediaHtml + "<input type=text ID=" + strTextboxName + "  class=\"form-control fg2_inp1\" onblur=\"AssignMediaValues(this)\" onkeypress=\"return textRemoveSpecial(event)\" runat=\"server\" MaxLength=\"150\" >";
                    else
                        strMediaHtml = strMediaHtml + "<input type=text ID=" + strTextboxName + " class=\"form-control fg2_inp1\" onblur=\"AssignMediaValues(this)\" onkeypress=\"return textRemoveSpecial(event)\" runat=\"server\" MaxLength=\"150\" >";
                    strMediaHtml = strMediaHtml + "</div>";

                    if (intRowIdentity == 0)
                        intRowIdentity = 1;
                    else
                        intRowIdentity = 0;
                }



                divMedia.InnerHtml = strMediaHtml;
            }

            txtCustomerName.Focus();
            if (HiddenCustomerCode.Value == "1")
            {
                DivCustomerCode.Visible = true;
            }
            else
            {
                DivCustomerCode.Visible = false;
            }
            //when editing 
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                Customer_Type_Load();
                Customer_Group_Load();
                Country_Load();

                Update(strId);
                lblEntry.InnerText = "Edit Customer Master";

            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                View(strId);

                lblEntry.InnerText = "View Customer Master";
                HiddenViewSts.Value = "1";
            }

            else
            {
                clsEntityCommon objCommon = new clsEntityCommon();
                objCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CUSTOMER);
                objCommon.CorporateID = intCorpId;
                objCommon.Organisation_Id = intOrgid;
                string strNextId = objBusinessLayer.ReadNextNumberWebForUI(objCommon);
                //objEntityCustomer.Customer_Id = Convert.ToInt32(strNextId);
                string year = DateTime.Today.Year.ToString();
                //  Txtemplyid.Text = "EMP/" + year + "/" + strNextId;
                txtRefNum.Text = "REF/" + year + "/" + strNextId;
                //  txtRefNum.Text = strNextId;
                HiddenNextId.Value = strNextId;
                lblEntry.InnerText = "Add Customer Master";
                DivCustomerCode.Visible = false;
                Customer_Type_Load();
                Customer_Group_Load();
                Country_Load();
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnUpdatef.Visible = false;
                btnUpdateClosef.Visible = false;
                btnAddf.Visible = true;
                btnAddClosef.Visible = true;
                if (Request.QueryString["CFAM"] != null)
                {
                    txtCustomerName.Text = Request.QueryString["CFAM"].ToString().Trim();
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

            if (Request.QueryString["CFAM"] != null)
            {
                divList.Visible = false;
                btnAdd.Visible = false;
                btnCancel.Visible = false;
                btnClose.Visible = true;
                btnAddf.Visible = false;
                btnCancelf.Visible = false;
                btnClosef.Visible = true;
            }
            else
            {
                btnClose.Visible = false;
                btnClosef.Visible = false;
                divList.Visible = true;
            }



            if (Request.QueryString["RFGP"] != null)
            {
                cbxLedgerSts.Checked = true;
                cbxLedgerSts.Enabled = false;
                divList.Visible = false;
                HiddenCheckMode.Value = "1";
                btnCancel.Visible = false;
                btnCancelf.Visible = false;
            }
        }

    }

    //EVM-0027 Aug 21
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
        objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYDEBTR));

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
        ddlLedger.Items.Insert(0, "--SELECT CUSTOMER--");
        if (dtlCstmrLedger.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SundryDebtorSelect", "SundryDebtorSelect();", true);
        }

    }

    //EVM-0027 Aug 21 END
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
    //evm 0044
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
    //[WebMethod]
    //public static string LoadLedgerCode(string strUserID, string ActGrpId, string strOrgIdID, string strCorpID)
    //{
    //    string sts = "";
    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    clsEntityLedger objEntityLedger = new clsEntityLedger();
    //    clsBusinessLayerLedger objBusinessLedger = new clsBusinessLayerLedger();

    //    int intCorpId = 0;
    //    if (strCorpID != null)
    //    {

    //        intCorpId = Convert.ToInt32(strCorpID);
    //        objEntityCommon.CorporateID = Convert.ToInt32(strCorpID);
    //        objEntityLedger.Corp_Id = Convert.ToInt32(strCorpID);
    //    }

    //    if (strOrgIdID != null)
    //    {

    //        objEntityCommon.Organisation_Id = Convert.ToInt32(strOrgIdID);
    //        objEntityLedger.Org_Id = Convert.ToInt32(strOrgIdID);
    //    }

    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_LEDGER_MASTER);
    //    DataTable dtFormate = objBusinessLayer.ReadCodeFormate(objEntityCommon);
    //    string refFormatByDiv = "";
    //    string strRealFormat = "";

    //    DataTable dt = new DataTable();


    //    if (ActGrpId != "")
    //    {
    //        objEntityLedger.LedgerId = Convert.ToInt32(ActGrpId);
    //    }

    //    objEntityLedger.LedgerAcntGrpSts = 0;
    //    dt = objBusinessLedger.ReadAccountGrp_Of_Ledgr(objEntityLedger);





    //    if (dtFormate.Rows.Count > 0)
    //    {
    //        if (dt.Rows.Count > 0)
    //        {
    //            string StrAcntGrpId = "";


    //            int NaureCode = 0;
    //            string CodeFormate = "";
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



    //            CodeFormate = NaureCode.ToString();

    //            // CodeFormate = NaureCode.ToString() + dtNextNumber;
    //            if (dtFormate.Rows[0]["CODE_FORMATE"].ToString() != "")
    //            {
    //                refFormatByDiv = dtFormate.Rows[0]["CODE_FORMATE"].ToString();
    //                string strReferenceFormat = "";
    //                strReferenceFormat = refFormatByDiv;
    //                string[] arrReferenceSplit = strReferenceFormat.Split('*');
    //                int intArrayRowCount = arrReferenceSplit.Length;
    //                int Codecount = 0;
    //                strRealFormat = refFormatByDiv.ToString();
    //                if (strRealFormat.Contains("#NAT#"))
    //                {
    //                    strRealFormat = strRealFormat.Replace("#NAT#", NaureCode.ToString());


    //                }
    //                if (strRealFormat.Contains("#NUM#"))
    //                {
    //                    string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);


    //                    strRealFormat = strRealFormat.Replace("#NUM#", dtNextNumber);


    //                }
    //                if (strRealFormat.Contains("#ACNTGRP#"))
    //                {
    //                   // string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);


    //                    strRealFormat = strRealFormat.Replace("#ACNTGRP#", StrAcntGrpId);


    //                }
    //                if (dtFormate.Rows[0]["CODE_COUNT"].ToString() != "")
    //                {
    //                    Codecount = Convert.ToInt32(dtFormate.Rows[0]["CODE_COUNT"].ToString());
    //                }

    //                int k = strRealFormat.Length;
    //                if (k < Codecount)
    //                {
    //                    int Difrnce = Codecount - k;
    //                    k = k + Difrnce;
    //                    //  hello.PadLeft(50, '#');
    //                    strRealFormat = strRealFormat.PadLeft(k, '0');
    //                }


    //                sts = strRealFormat;
    //            }
    //        }
    //    }

    //    return sts.ToString();
    //}

    [WebMethod]
    public static string LoadLedgerCode(string strUserID, string ActGrpId, string strOrgIdID, string ldgrsts, string strCorpID)
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

        //objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_LEDGER_MASTER);
        //DataTable dtFormate = objBusinessLayer.ReadCodeFormate(objEntityCommon);
        //string refFormatByDiv = "";
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
        //DataTable dt = new DataTable();


        //if (ActGrpId != "")
        //{
        //    objEntityLedger.LedgerId = Convert.ToInt32(ActGrpId);
        //}

        //objEntityLedger.LedgerAcntGrpSts = 0;
        //dt = objBusinessLedger.ReadAccountGrp_Of_Ledgr(objEntityLedger);





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
        //                // string dtNextNumber = objBusinessLayer.ReadNextSequence(objEntityCommon);


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


        sts = strRealFormat;
        //        }
        //    }
        //}

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
    public void LoadDDLAccountGrp()
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
        ddlAccountGrp.Items.Clear();
        //   objEntityLedger.ActModeId = Convert.ToInt32(clsCommonLibrary.ASMOD_ID.customer);
        //  DataTable dtdiv = objBusinessLedger.ReadAccountGrpsLedgr(objEntityLedger);
        objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYDEBTR));
        DataTable dtdiv = objBusinessCommon.ReadAccountGrps(objEntityCommon);
        if (dtdiv.Rows.Count > 0)
        {
            ddlAccountGrp.DataSource = dtdiv;
            ddlAccountGrp.DataTextField = "ACNT_GRP_NAME";
            ddlAccountGrp.DataValueField = "ACNT_GRP_ID";
            ddlAccountGrp.DataBind();
        }
        ddlAccountGrp.Items.Insert(0, "--SELECT ACCOUNT GROUP--");
        if (dtdiv.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SundryDebtorSelect", "SundryDebtorSelect();", true);
        }
    }
    //Method for assigning category types to drop down list
    public void Customer_Type_Load()
    {
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        if (Request.QueryString["CFAM"] != null)
        {
            if (Request.QueryString["CFTYP"] != null)
            {
                objEntityCustomer.Customer_Type_Id = 1;
            }
            else
            {
                objEntityCustomer.Customer_Type_Id = 2;
            }
            if (Request.QueryString["CFTYP"] == "CUSTR")
            {
                objEntityCustomer.Customer_Type_Id = 2;
            }

            DataTable dtType = objBusinessLayerCustomer.Read_Customer_Type(objEntityCustomer);
            ddlCustomerType.Items.Clear();
            ddlCustomerType.ClearSelection();
            if (dtType.Rows.Count > 0)
            {
                ddlCustomerType.DataSource = dtType;

                ddlCustomerType.DataTextField = "CSTMRTYP_NAME";
                ddlCustomerType.DataValueField = "CSTMRTYP_ID";
                ddlCustomerType.DataBind();
            }
            else
            {
                ddlCustomerType.Items.Insert(0, "--SELECT TYPE--");

            }
        }
        //  ddlCustomerType.Items.Clear();
        else
        {
            DataTable dtType = objBusinessLayerCustomer.Read_Customer_Type(objEntityCustomer);
            ddlCustomerType.Items.Clear();
            ddlCustomerType.DataSource = dtType;

            ddlCustomerType.DataTextField = "CSTMRTYP_NAME";
            ddlCustomerType.DataValueField = "CSTMRTYP_ID";
            ddlCustomerType.DataBind();
            ddlCustomerType.Items.Insert(0, "--SELECT TYPE--");
        }

    }
    //Method for assigning parent category
    public void Customer_Group_Load()
    {
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        DataTable dtGroup = objBusinessLayerCustomer.Read_Customer_Group(objEntityCustomer);

        ddlCustomerGroup.Items.Clear();
        ddlCustomerGroup.ClearSelection();
        ddlCustomerGroup.DataSource = dtGroup;

        ddlCustomerGroup.DataTextField = "CSTMRGP_NAME";
        ddlCustomerGroup.DataValueField = "CSTMRGP_ID";
        ddlCustomerGroup.DataBind();

        ddlCustomerGroup.Items.Insert(0, "--SELECT GROUP--");
    }
    //methode for loading the country
    public void Country_Load()
    {
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        ddlCountry.ClearSelection();
        DataTable dtCountry = objBusinessLayerCustomer.Read_Country();

        ddlCountry.Items.Clear();

        ddlCountry.DataSource = dtCountry;

        ddlCountry.DataTextField = "CNTRY_NAME";
        ddlCountry.DataValueField = "CNTRY_ID";
        ddlCountry.DataBind();

        ddlCountry.Items.Insert(0, "--SELECT COUNTRY--");




    }

    //methode for load state based on country
    public void State_Load()
    {
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (ddlCountry.SelectedItem.Value == "--SELECT COUNTRY--")
        {
            ddlState.Items.Clear();
            ddlCity.Items.Clear();
        }
        else
        {
            objEntityCustomer.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            ddlState.ClearSelection();
            DataTable dtState = objBusinessLayerCustomer.Read_State(objEntityCustomer);

            ddlCity.Items.Clear();
            ddlState.Items.Clear();

            ddlState.DataSource = dtState;

            ddlState.DataTextField = "STATE_NAME";
            ddlState.DataValueField = "STATE_ID";
            ddlState.DataBind();

            ddlState.Items.Insert(0, "--SELECT STATE--");
        }

    }

    //fetch city on the basis of state
    public void City_Load()
    {
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        if (ddlState.SelectedItem.Value == "--SELECT STATE--")
        {
            ddlCity.Items.Clear();
        }
        else
        {
            objEntityCustomer.StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
            ddlCity.ClearSelection();
            DataTable dtState = objBusinessLayerCustomer.Read_City(objEntityCustomer);

            ddlCity.Items.Clear();

            ddlCity.DataSource = dtState;

            ddlCity.DataTextField = "CITY_NAME";
            ddlCity.DataValueField = "CITY_ID";
            ddlCity.DataBind();

            ddlCity.Items.Insert(0, "--SELECT CITY--");
        }

    }

    //when submit button is clicked
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        List<clsEntityCustomer> objEntityContactList = new List<clsEntityCustomer>();
        List<clsEntityCustomer> objEntityMediaList = new List<clsEntityCustomer>();
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }

        //Status checkbox checked
        if (cbxStatus.Checked == true)
        {
            objEntityCustomer.Customer_Status = 1;
        }
        //Status checkbox not checked
        else
        {
            objEntityCustomer.Customer_Status = 0;
        }
        if (Session["USERID"] != null)
        {
            objEntityCustomer.UserId = Convert.ToInt32(Session["USERID"].ToString());
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        objEntityCustomer.Customer_Id = Convert.ToInt32(HiddenNextId.Value);
        objEntityCustomer.Date = System.DateTime.Now;
        txtCustomerName.Text = txtCustomerName.Text.Trim();
        objEntityCustomer.Customer_Name = txtCustomerName.Text;

        objEntityCustomer.Customer_Group_Id = Convert.ToInt32(ddlCustomerGroup.SelectedItem.Value);




        objEntityCustomer.Customer_Type_Id = Convert.ToInt32(ddlCustomerType.SelectedItem.Value);

        if (txtCreditLimit.Text != "" && txtCreditLimit.Text != null)


            objEntityCustomer.Customer_Credit_Limit = Convert.ToDecimal(txtCreditLimit.Text);

        if (txtCreditPeriod.Text != "" && txtCreditPeriod.Text != null)
            objEntityCustomer.Customer_Credit_Period = Convert.ToInt32(txtCreditPeriod.Text);

        objEntityCustomer.Address1 = txtAddress1.Text;

        if (txtAddress2.Text != "" && txtAddress2.Text != null)
            objEntityCustomer.Address2 = txtAddress2.Text;

        if (txtAddress3.Text != "" && txtAddress3.Text != null)
            objEntityCustomer.Address3 = txtAddress3.Text;

        objEntityCustomer.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);

        if (ddlState.SelectedItem != null)
        {
            if (ddlState.SelectedItem.Value != "--SELECT STATE--" && ddlState.SelectedItem.Value != null)
                objEntityCustomer.StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
        }
        if (ddlCity.SelectedItem != null)
        {
            if (ddlCity.SelectedItem.Value != "--SELECT CITY--" && ddlCity.SelectedItem.Value != null)
                objEntityCustomer.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value);
        }
        objEntityCustomer.CustomerRefnumber = txtRefNum.Text;
        objEntityCustomer.ZipCode = txtZipCode.Text;
        objEntityCustomer.Phone_Number = txtPhone.Text;
        objEntityCustomer.Mobile_Number = txtMobile.Text;
        objEntityCustomer.Web_Address = txtWebSite.Text;
        objEntityCustomer.Email_Address = txtEmail.Text.Trim();
        objEntityCustomer.TIN_Number = txtTinNumber.Text;
        objEntityCustomer.Payment_Terms = txtPaymentTerm.Text;
        objEntityCustomer.Price_Terms = txtPriceTerm.Text;
        objEntityCustomer.Delivery_Terms = txtDeliveryTerm.Text;

        if (cbxCrdtLmtRestrict.Checked == true)
        {
            objEntityCustomer.CreditLimitRestrict = 1;
        }
        if (cbxCrdtLmtWarn.Checked == true)
        {
            objEntityCustomer.CreditLimitWarn = 1;
        }
        if (cbxCrdtPeriodRestrict.Checked == true)
        {
            objEntityCustomer.CreditPeriodRestrict = 1;
        }
        if (cbxCrdtPeriodWarn.Checked == true)
        {
            objEntityCustomer.CreditPeriodWarn = 1;
        }

        //Checking is there table have any name like this
        string strNameCount = objBusinessLayerCustomer.CheckCustomerName(objEntityCustomer);

        if (txtNameOne.Text != "" && txtNameOne.Text != null)
        {
            clsEntityCustomer objEntityCustomerOne = new clsEntityCustomer();
            objEntityCustomerOne.Customer_Name = txtNameOne.Text;
            objEntityCustomerOne.Address1 = txtAddressOne.Text;
            objEntityCustomerOne.Address2 = txtAddressOne2.Text;
            objEntityCustomerOne.Address3 = txtAddressOne3.Text;
            objEntityCustomerOne.Mobile_Number = txtMobileOne.Text;
            objEntityCustomerOne.Phone_Number = txtPhoneOne.Text;
            objEntityCustomerOne.Email_Address = txtEmailOne.Text.Trim();
            if (cbxAllowOtherMailOne.Checked == true)
            {
                objEntityCustomerOne.MailAllowed = 1;
            }
            objEntityCustomerOne.Web_Address = txtWebsiteOne.Text;
            objEntityContactList.Add(objEntityCustomerOne);
        }

        if (txtNameTwo.Text != "" && txtNameTwo.Text != null)
        {
            clsEntityCustomer objEntityCustomerTwo = new clsEntityCustomer();
            objEntityCustomerTwo.Customer_Name = txtNameTwo.Text;
            objEntityCustomerTwo.Address1 = txtAddressTwo.Text;
            objEntityCustomerTwo.Address2 = txtAddressTwo2.Text;
            objEntityCustomerTwo.Address3 = txtAddressTwo3.Text;
            objEntityCustomerTwo.Mobile_Number = txtMobileTwo.Text;
            objEntityCustomerTwo.Phone_Number = txtPhoneTwo.Text;
            objEntityCustomerTwo.Email_Address = txtEmailTwo.Text.Trim();
            if (cbxAllowOtherMailTwo.Checked == true)
            {
                objEntityCustomerTwo.MailAllowed = 1;
            }
            objEntityCustomerTwo.Web_Address = txtWebsiteTwo.Text;
            objEntityContactList.Add(objEntityCustomerTwo);
        }

        if (txtNameThree.Text != "" && txtNameThree.Text != null)
        {
            clsEntityCustomer objEntityCustomerThree = new clsEntityCustomer();
            objEntityCustomerThree.Customer_Name = txtNameThree.Text;
            objEntityCustomerThree.Address1 = txtAddressThree.Text;
            objEntityCustomerThree.Mobile_Number = txtMobileThree.Text;
            objEntityCustomerThree.Phone_Number = txtPhoneThree.Text;
            objEntityCustomerThree.Email_Address = txtEmailThree.Text.Trim();
            if (cbxAllowOtherMailThree.Checked == true)
            {
                objEntityCustomerThree.MailAllowed = 1;
            }
            objEntityCustomerThree.Web_Address = txtWebsiteThree.Text;
            objEntityContactList.Add(objEntityCustomerThree);
        }
        dtMedia = objBusinessLayerCustomer.Read_Media_Master();
        if (dtMedia.Rows.Count == 0)
        {
        }
        else
        {

            //convert media values that placed in jason
            string jsonData = hiddenMedia.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string g = c.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");

            List<clsEntityCustomer> objMediaList = new List<clsEntityCustomer>();

            objMediaList = JsonConvert.DeserializeObject<List<clsEntityCustomer>>(i);

            for (int intRowCount = 0; intRowCount < dtMedia.Rows.Count; intRowCount++)
            {
                clsEntityCustomer objEntityMedia = new clsEntityCustomer();
                objEntityMedia.Media_Id = Convert.ToInt32(dtMedia.Rows[intRowCount]["MEDIA_ID"]);
                objEntityMediaList.Add(objEntityMedia);
            }

            //add media details
            if (objMediaList != null)
            {
                foreach (clsEntityCustomer MediaCust in objMediaList)
                {
                    if (MediaCust != null)
                    {
                        foreach (clsEntityCustomer CustMedia in objEntityMediaList)
                        {
                            if (MediaCust.Media_Id == CustMedia.Media_Id)
                                CustMedia.Media_Description = MediaCust.Media_Description;
                        }
                    }
                }
            }

        }

        if (strNameCount == "0")
        {
            if (cbxLedgerSts.Checked == true)
            {
                objEntityCustomer.LedgerSts = 1;
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
                objEntityLedger.LedgerName = txtCustomerName.Text.Trim();
                //   objEntityLedger.AccountGrpId = SaleAcntGrpId;
                //EVM-0027 Aug 21
                createCodeByLevel(objEntityLedger.Org_Id, objEntityLedger.Corp_Id);
                if (chkSubLedger.Checked == true)
                {
                    if (ddlLedger.SelectedItem.Text != "--SELECT CUSTOMER--")
                    {
                        objEntityLedger.SubLedgerStatus = 1;
                        objEntityLedger.SubLedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
                        objEntityLedger.LedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
                        createCodeByLevel(objEntityLedger.Org_Id, objEntityLedger.Corp_Id);

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
                        objEntityLedger.AccountGrpId = SaleAcntGrpId;
                    }
                }

                //EVM-0027 Aug 21 END

                objEntityLedger.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
                objEntityLedger.LedgerAddess = txtAddress1.Text.Trim();
                if (HiddenTaxEnable.Value == "0")
                {
                    objEntityLedger.TxEnabledSts = 0;
                }
                else
                {
                    if (HiddenAccountSpecific.Value == "1")
                    {
                        objEntityLedger.TxEnabledSts = 1;
                        if (radioTDSno.Checked == true)
                        {
                            objEntityLedger.TDSstatus = 1;
                        }
                        else
                        {
                            objEntityLedger.TDSid = Convert.ToInt32(ddlTDS.SelectedItem.Value);
                        }
                        if (radioTCSno.Checked == true)
                        {
                            objEntityLedger.TCSstatus = 1;
                        }
                        else
                        {
                            objEntityLedger.TCSid = Convert.ToInt32(ddlTCS.SelectedItem.Value);
                        }
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

                if (txtOpenBalanceDeb.Text.Trim() != "")
                {
                    decimal OpenBalance = 0;
                    OpenBalance = objEntityLedger.DebitBalance;
                    if (typdebit.Checked)
                    {
                        objEntityLedger.DebitBalance = Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                        //   objEntityLedger.CreditBalance = (objEntityLedger.CreditBalance - OpenBalance) + Convert.ToDecimal(txtblnce.Text.Trim());
                        objEntityLedger.LedgerStatus = 0;
                    }
                    else
                    {
                        objEntityLedger.DebitBalance = Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                        //  objEntityLedger.CreditBalance = (objEntityLedger.CreditBalance - OpenBalance) - Convert.ToDecimal(txtblnce.Text.Trim());
                        objEntityLedger.LedgerStatus = 1;

                    }
                }


                objEntityLedger.PageSts = 2;
                DataTable dt = objBusinessLedger.CheckDupName(objEntityLedger);
                createCodeByLevel(objEntityLedger.Org_Id, objEntityLedger.Corp_Id);//evm 0044
                objEntityLedger.LdgrCode = txtLedgrCode.Text.Trim();

                List<clsEntityLedger> objEntitySubLedgerList = new List<clsEntityLedger>();

                //EVM-0027 AUG 21
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
                //EVM-0027 AUG 21 END

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
                        objEntity.Name = txtCustomerName.Text.Trim();
                        objEntity.Status = 1;
                        CreateCostCntrCode();
                        objEntity.GrpCode = txtCostCntrCode.Text.Trim();
                        strNameCostCount = objBusinessCostCenter.CheckCostName(objEntity);
                        strCstCodeCount = objBusinessCostCenter.CheckCodeDuplicatn(objEntity);


                        if (HiddenCustomerCode.Value != "")
                        {
                            objEntity.CodePrsntSts = Convert.ToInt32(HiddenCustomerCode.Value);
                        }

                        if (HiddenCodeFormate.Value != "")
                        {
                            objEntity.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
                        }

                        if (strNameCostCount == "0" && strCstCodeCount == "0")
                        {
                            string costID = objBusinessCostCenter.InsertCostCenter(objEntity);
                            objBusinessCostCenter.UpdateCostGroupNextId(objEntity);//evm 0044
                            objEntityLedger.CostCenterID = Convert.ToInt32(costID);
                        }
                        else
                        {
                            if (strNameCostCount != "0")
                                strNameCount = "3";
                            else if (strCstCodeCount != "0")
                            {
                                strNameCount = "5";
                            }
                        }
                    }
                    //End:-Cost Center insert

                    if (HiddenCustomerCode.Value != "")
                    {
                        objEntityLedger.CodePrsntSts = Convert.ToInt32(HiddenCustomerCode.Value);
                    }

                    if (HiddenCodeFormate.Value != "")
                    {
                        objEntityLedger.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
                    }
                    if (hiddenCodeNumberFrmt.Value != "")
                    {
                        objEntityLedger.CodeFormatNumber = Convert.ToInt32(hiddenCodeNumberFrmt.Value);
                    }

                    if (strNameCount == "0")
                    {

                        objBusinessLedger.AddLedger(objEntityLedger, objEntitySubLedgerList);

                        objEntityCustomer.LedgerId = objEntityLedger.LedgerId;
                        if (objEntityLedger.LedgerId > 0)
                        {
                            objBusinessLedger.UpdateLedgerId(objEntityLedger.LedgerId);
                        }
                    }
                }

                else
                {
                    if (dt.Rows.Count != 0)
                    {
                        strNameCount = "2";
                    }
                    if (strCodeCount != "0")
                    {
                        strNameCount = "4";
                    }
                }
                //End:-Save to ledger table
            }

        }
        else
        {
            strNameCount = "1";
        }


        //If there is no name like this on table.    
        if (strNameCount == "0")
        {
            int intCustomerId = objBusinessLayerCustomer.AddCustomer(objEntityCustomer, objEntityMediaList, objEntityContactList);

            if (Request.QueryString["CFAM"] != null)
            {
                if (Request.QueryString["CFTYP"] == "CUSTR")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedCustomerToRFG", "PassSavedCustomerToRFG(" + intCustomerId + ");", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedCustomerToLead", "PassSavedCustomerToLead(" + intCustomerId + ");", true);
                }
            }
            else if (Request.QueryString["RFGP"] == "CUST")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedCustomer", "PassSavedCustomer(" + objEntityCustomer.LedgerId + ");", true);
            }


            else
            {

                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("gen_Customer_Master.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("gen_Customer_MasterList.aspx?InsUpd=Ins");
                }

                else if (clickedButton.ID == "btnAddf")
                {
                    Response.Redirect("gen_Customer_Master.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClosef")
                {
                    Response.Redirect("gen_Customer_MasterList.aspx?InsUpd=Ins");
                }

            }

        }
        //If have
        else
        {
            if (strNameCount == "1")
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                txtCustomerName.Focus();
            }
            else if (strNameCount == "2")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationNameLdgr", "DuplicationNameLdgr();", true);
                txtCustomerName.Focus();
            }
            else if (strNameCount == "3")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationNameCstcnr", "DuplicationNameCstcnr();", true);
                txtCustomerName.Focus();
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
            if (ddlAccountGrp.SelectedItem.Text != "--SELECT ACCOUNT GROUP--")
            {
                objEntityAccountGroup.AccountGrpId = Convert.ToInt32(ddlAccountGrp.SelectedItem.Value);
            }
            else
            {
                objEntityAccountGroup.AccountGrpId = SaleAcntGrpId;
            }

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
                        txtLedgrCode.Text = dtledger.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subldgrnum);
                    }
                }
                else
                {
                    subldgrnum = Convert.ToInt32(dtledger.Rows[0]["ACNT_NEXTID_LEDGER"].ToString());
                    txtLedgrCode.Text = dtledger.Rows[0]["ACNT_CODE"].ToString() + Convert.ToString(subldgrnum);
                }
            }
        }
        if (chkSubLedger.Checked == true)
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
                    objEntityCommon.DefaultModId = Convert.ToInt32(clsCommonLibrary.Section.SUB_LEDGER_START_REf); ;
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

        txtCostCntrCode.Text = strRealFormat;
    }
    //-----------------------------

    //When Update Button is clicked
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (Request.QueryString["Id"] != null)
        {
            List<clsEntityCustomer> objEntityContactList = new List<clsEntityCustomer>();
            List<clsEntityCustomer> objEntityMediaList = new List<clsEntityCustomer>();
            clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            //set a variable for category code count

            //fetch id category id from qu ery string
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityCustomer.Customer_Id = Convert.ToInt32(strId);


            //Status checkbox checked
            if (cbxStatus.Checked == true)
            {
                objEntityCustomer.Customer_Status = 1;
            }
            //Status checkbox not checked
            else
            {
                objEntityCustomer.Customer_Status = 0;
            }
            if (Session["USERID"] != null)
            {
                objEntityCustomer.UserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            objEntityCustomer.Date = System.DateTime.Now;
            txtCustomerName.Text = txtCustomerName.Text.Trim();
            objEntityCustomer.Customer_Name = txtCustomerName.Text;

            objEntityCustomer.Customer_Group_Id = Convert.ToInt32(ddlCustomerGroup.SelectedItem.Value);
            objEntityCustomer.Customer_Type_Id = Convert.ToInt32(ddlCustomerType.SelectedItem.Value);

            if (txtCreditLimit.Text != "" && txtCreditLimit.Text != null)
                objEntityCustomer.Customer_Credit_Limit = Convert.ToDecimal(txtCreditLimit.Text);

            if (txtCreditPeriod.Text != "" && txtCreditPeriod.Text != null)
                objEntityCustomer.Customer_Credit_Period = Convert.ToInt32(txtCreditPeriod.Text);

            objEntityCustomer.Address1 = txtAddress1.Text;

            if (txtAddress2.Text != "" && txtAddress2.Text != null)
                objEntityCustomer.Address2 = txtAddress2.Text;

            if (txtAddress3.Text != "" && txtAddress3.Text != null)
                objEntityCustomer.Address3 = txtAddress3.Text;

            if (ddlCountry.SelectedItem.Value != "--SELECT COUNTRY--" && ddlCountry.SelectedItem.Value != null)
                objEntityCustomer.CountryId = Convert.ToInt32(ddlCountry.SelectedItem.Value);
            if (ddlState.SelectedItem != null)
            {
                if (ddlState.SelectedItem.Value != "--SELECT STATE--" && ddlState.SelectedItem.Value != null)
                    objEntityCustomer.StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
            }
            if (ddlCity.SelectedItem != null)
            {
                if (ddlCity.SelectedItem.Value != "--SELECT CITY--" && ddlCity.SelectedItem.Value != null)
                    objEntityCustomer.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value);
            }

            objEntityCustomer.ZipCode = txtZipCode.Text;
            objEntityCustomer.Phone_Number = txtPhone.Text;
            objEntityCustomer.Mobile_Number = txtMobile.Text;
            objEntityCustomer.Web_Address = txtWebSite.Text;
            objEntityCustomer.Email_Address = txtEmail.Text.Trim();
            objEntityCustomer.TIN_Number = txtTinNumber.Text;
            objEntityCustomer.Payment_Terms = txtPaymentTerm.Text;
            objEntityCustomer.Price_Terms = txtPriceTerm.Text;
            objEntityCustomer.Delivery_Terms = txtDeliveryTerm.Text;

            if (cbxCrdtLmtRestrict.Checked == true)
            {
                objEntityCustomer.CreditLimitRestrict = 1;
            }
            if (cbxCrdtLmtWarn.Checked == true)
            {
                objEntityCustomer.CreditLimitWarn = 1;
            }
            if (cbxCrdtPeriodRestrict.Checked == true)
            {
                objEntityCustomer.CreditPeriodRestrict = 1;
            }
            if (cbxCrdtPeriodWarn.Checked == true)
            {
                objEntityCustomer.CreditPeriodWarn = 1;
            }

            if (txtNameOne.Text != "" && txtNameOne.Text != null)
            {
                clsEntityCustomer objEntityCustomerOne = new clsEntityCustomer();
                objEntityCustomerOne.Customer_Name = txtNameOne.Text;
                objEntityCustomerOne.Address1 = txtAddressOne.Text;
                objEntityCustomerOne.Address2 = txtAddressOne2.Text;
                objEntityCustomerOne.Address3 = txtAddressOne3.Text;
                objEntityCustomerOne.Mobile_Number = txtMobileOne.Text;
                objEntityCustomerOne.Phone_Number = txtPhoneOne.Text;
                objEntityCustomerOne.Email_Address = txtEmailOne.Text.Trim();
                if (cbxAllowOtherMailOne.Checked == true)
                {
                    objEntityCustomerOne.MailAllowed = 1;
                }
                objEntityCustomerOne.Web_Address = txtWebsiteOne.Text;
                objEntityContactList.Add(objEntityCustomerOne);
            }

            if (txtNameTwo.Text != "" && txtNameTwo.Text != null)
            {
                clsEntityCustomer objEntityCustomerTwo = new clsEntityCustomer();
                objEntityCustomerTwo.Customer_Name = txtNameTwo.Text;
                objEntityCustomerTwo.Address1 = txtAddressTwo.Text;
                objEntityCustomerTwo.Address2 = txtAddressTwo2.Text;
                objEntityCustomerTwo.Address3 = txtAddressTwo3.Text;
                objEntityCustomerTwo.Mobile_Number = txtMobileTwo.Text;
                objEntityCustomerTwo.Phone_Number = txtPhoneTwo.Text;
                objEntityCustomerTwo.Email_Address = txtEmailTwo.Text.Trim();
                if (cbxAllowOtherMailTwo.Checked == true)
                {
                    objEntityCustomerTwo.MailAllowed = 1;
                }
                objEntityCustomerTwo.Web_Address = txtWebsiteTwo.Text;
                objEntityContactList.Add(objEntityCustomerTwo);
            }

            if (txtNameThree.Text != "" && txtNameThree.Text != null)
            {
                clsEntityCustomer objEntityCustomerThree = new clsEntityCustomer();
                objEntityCustomerThree.Customer_Name = txtNameThree.Text;
                objEntityCustomerThree.Address1 = txtAddressThree.Text;
                objEntityCustomerThree.Mobile_Number = txtMobileThree.Text;
                objEntityCustomerThree.Phone_Number = txtPhoneThree.Text;
                objEntityCustomerThree.Email_Address = txtEmailThree.Text.Trim();
                if (cbxAllowOtherMailThree.Checked == true)
                {
                    objEntityCustomerThree.MailAllowed = 1;
                }
                objEntityCustomerThree.Web_Address = txtWebsiteThree.Text;
                objEntityContactList.Add(objEntityCustomerThree);
            }

            //Checking is there table have any name like this
            string strNameCount = objBusinessLayerCustomer.CheckCustomerName(objEntityCustomer);


            dtMedia = objBusinessLayerCustomer.Read_Media_Master();
            if (dtMedia.Rows.Count == 0)
            {
            }
            else
            {

                //convert media values that placed in jason
                string jsonData = hiddenMedia.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string g = c.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");

                List<clsEntityCustomer> objMediaList = new List<clsEntityCustomer>();

                objMediaList = JsonConvert.DeserializeObject<List<clsEntityCustomer>>(i);

                for (int intRowCount = 0; intRowCount < dtMedia.Rows.Count; intRowCount++)
                {
                    clsEntityCustomer objEntityMedia = new clsEntityCustomer();
                    objEntityMedia.Media_Id = Convert.ToInt32(dtMedia.Rows[intRowCount]["MEDIA_ID"]);
                    objEntityMediaList.Add(objEntityMedia);
                }


                foreach (clsEntityCustomer MediaCust in objMediaList)
                {
                    if (MediaCust != null)
                    {
                        foreach (clsEntityCustomer CustMedia in objEntityMediaList)
                        {
                            if (MediaCust.Media_Id == CustMedia.Media_Id)
                                CustMedia.Media_Description = MediaCust.Media_Description;
                        }
                    }
                }

            }
            if (HiddenFieldLedgerId.Value != "")
            {
                objEntityCustomer.LedgerId = Convert.ToInt32(HiddenFieldLedgerId.Value);
            }
            if (strNameCount == "0")
            {
                if (cbxLedgerSts.Checked == true)
                {
                    objEntityCustomer.LedgerSts = 1;
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
                    objEntityLedger.LedgerName = txtCustomerName.Text.Trim();
                    //evm 0044----------
                    int updatests = 0;
                    int updcostcntrstatus = 0;
                    string strRandomMixedId1 = Request.QueryString["Id"].ToString();
                    string strLenghtofId1 = strRandomMixedId1.Substring(0, 2);
                    int intLenghtofId1 = Convert.ToInt16(strLenghtofId1);
                    string strId1 = strRandomMixedId1.Substring(2, intLenghtofId1);
                    objEntityLedger.LedgerId = Convert.ToInt32(strId1);
                    DataTable dtdata = objBusinessLayerCustomer.ReadCustomerById(objEntityCustomer);
                    //EVM-0027 Aug 21
                    if (chkSubLedger.Checked == true)
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

                                //objEntityLedger.LedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
                                //objEntityCustomer.LedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
                            }
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
                            objEntityLedger.AccountGrpId = SaleAcntGrpId;
                        }
                    }

                    //EVM-0027 Aug 21 END
                    //if (ddlAccountGrp.SelectedItem.Text != "--SELECT ACCOUNT GROUP--")
                    //{
                    //    objEntityLedger.AccountGrpId = Convert.ToInt32(ddlAccountGrp.SelectedItem.Value);
                    //}
                    //else
                    //{
                    //    objEntityLedger.AccountGrpId = SaleAcntGrpId;
                    //}
                    //// objEntityLedger.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);

                    objEntityLedger.LedgerAddess = txtAddress1.Text.Trim();

                    if (HiddenTaxEnable.Value == "0")
                    {
                        objEntityLedger.TxEnabledSts = 0;
                    }
                    else
                    {
                        if (HiddenAccountSpecific.Value == "1")
                        {
                            objEntityLedger.TxEnabledSts = 1;
                            if (radioTDSno.Checked == true)
                            {
                                objEntityLedger.TDSstatus = 1;
                            }
                            else
                            {
                                objEntityLedger.TDSid = Convert.ToInt32(ddlTDS.SelectedItem.Value);
                            }
                            if (radioTCSno.Checked == true)
                            {
                                objEntityLedger.TCSstatus = 1;
                            }
                            else
                            {
                                objEntityLedger.TCSid = Convert.ToInt32(ddlTCS.SelectedItem.Value);
                            }
                        }
                    }

                    if (HiddenCustomerCode.Value != "")
                    {
                        objEntityLedger.CodePrsntSts = Convert.ToInt32(HiddenCustomerCode.Value);
                    }

                    if (HiddenCodeFormate.Value != "")
                    {
                        objEntityLedger.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
                    }

                    objEntityLedger.LdgrCode = txtLedgrCode.Text.Trim();



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


                    if (txtOpenBalanceDeb.Text.Trim() != "")
                    {
                        decimal OpenBalance = 0;
                        OpenBalance = objEntityLedger.DebitBalance;
                        if (typdebit.Checked)
                        {
                            objEntityLedger.DebitBalance = Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                            //   objEntityLedger.CreditBalance = (objEntityLedger.CreditBalance - OpenBalance) + Convert.ToDecimal(txtblnce.Text.Trim());
                            objEntityLedger.LedgerStatus = 0;
                        }
                        else
                        {
                            objEntityLedger.DebitBalance = Convert.ToDecimal(txtOpenBalanceDeb.Text.Trim());
                            //  objEntityLedger.CreditBalance = (objEntityLedger.CreditBalance - OpenBalance) - Convert.ToDecimal(txtblnce.Text.Trim());
                            objEntityLedger.LedgerStatus = 1;

                        }
                    }
                    //if (txtOpenBalanceCre.Text.Trim() != "")
                    //{
                    //    objEntityLedger.CreditBalance = Convert.ToDecimal(txtOpenBalanceCre.Text.Trim());
                    //}
                    objEntityLedger.PageSts = 2;

                    List<clsEntityLedger> objEntitySubLedgerList = new List<clsEntityLedger>();
                    //EVM-0027 AUG 21
                    if (cbxLedgerSts.Checked == true)
                    {
                        if (chkSubLedger.Checked == true)
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
                    //EVM-0027 AUG 21 END

                    if (HiddenFieldLedgerId.Value != "")
                    {
                        objEntityLedger.LedgerId = Convert.ToInt32(HiddenFieldLedgerId.Value);
                    }

                    DataTable dtDupLed = objBusinessLedger.CheckDupName(objEntityLedger);
                    string strCodeCount = objBusinessLedger.CheckCodeDuplicatn(objEntityLedger);

                    if (dtDupLed.Rows.Count == 0 && strNameCount == "0" && strCodeCount == "0")
                    {

                        string strNameCstCount = "0";
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
                                objEntityLedger.CostCenterID = Convert.ToInt32(hiddenCostCntrId.Value);
                            }
                            DataTable dt = objBusinessCostCenter.ReadCostCenterById(objEntity);//evm 0044


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
                            objEntity.Name = txtCustomerName.Text.Trim();
                            objEntity.Status = 1;



                            if (HiddenCustomerCode.Value != "")
                            {
                                objEntity.CodePrsntSts = Convert.ToInt32(HiddenCustomerCode.Value);
                            }

                            if (HiddenCodeFormate.Value != "")
                            {
                                objEntity.CodeSts = Convert.ToInt32(HiddenCodeFormate.Value);
                            }
                            if (hiddenCodeNumberFrmt.Value != "")
                            {
                                objEntityLedger.CodeFormatNumber = Convert.ToInt32(hiddenCodeNumberFrmt.Value);
                            }
                            if (dt.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dt.Rows[0]["COSTGRP_ID"].ToString()) != Convert.ToInt32(ddlCC.SelectedItem.Value))
                                {
                                    CreateCostCntrCode();
                                    updcostcntrstatus = 1;
                                }
                            }
                            //--------------------------

                            objEntity.GrpCode = txtCostCntrCode.Text.Trim();

                            strNameCstCount = objBusinessCostCenter.CheckCostName(objEntity);
                            strCstCodeCount = objBusinessCostCenter.CheckCodeDuplicatn(objEntity);

                            if (strNameCstCount == "0" && hiddenCostCntrId.Value == "" && strCstCodeCount == "0")
                            {
                                string costID = objBusinessCostCenter.InsertCostCenter(objEntity);
                                objBusinessCostCenter.UpdateCostGroupNextId(objEntity);// evm 0044
                                objEntityLedger.CostCenterID = Convert.ToInt32(costID);

                            }
                            else if (strNameCstCount == "0" && strCstCodeCount == "0")
                            {
                                objBusinessCostCenter.UpdateCostCenter(objEntity);
                                //evm 0044
                                if (updcostcntrstatus == 1)
                                {
                                    objBusinessCostCenter.UpdateCostGroupNextId(objEntity);// evm 0044
                                }
                            }
                            else
                            {
                                if (strNameCstCount != "0")
                                {
                                    strNameCount = "3";
                                }
                                else if (strCstCodeCount != "0")
                                {
                                    strNameCount = "5";
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
                            if (hiddenCostCntrId.Value != "" && HiddenCostCntrCnclId.Value == "")
                            {
                                objBusinessCostCenter.DeleteCostCenter(objEntity);
                            }
                        }



                        if (strNameCount == "0")
                        {

                            if (HiddenFieldLedgerId.Value != "")
                            {
                                objEntityCustomer.LedgerId = Convert.ToInt32(HiddenFieldLedgerId.Value);
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
                                objEntityCustomer.LedgerId = objEntityLedger.LedgerId;
                            }
                        }
                    }
                    else
                    {
                        if (dtDupLed.Rows.Count != 0)
                            strNameCount = "2";
                        else if (strCodeCount != "0")
                            strNameCount = "4";

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
            //If there is no name like this on table.    
            if (strNameCount == "0")
            {
                objBusinessLayerCustomer.UpdateCustomer(objEntityCustomer, objEntityMediaList, objEntityContactList);

                if (clickedButton.ID == "btnUpdate")
                {
                    Response.Redirect("gen_Customer_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose")
                {
                    Response.Redirect("gen_Customer_MasterList.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdatef")
                {
                    Response.Redirect("gen_Customer_Master.aspx?InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClosef")
                {
                    Response.Redirect("gen_Customer_MasterList.aspx?InsUpd=Upd");
                }
            }
            //If have
            else
            {
                if (strNameCount == "1")
                {

                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationName", "DuplicationName();", true);
                    txtCustomerName.Focus();
                }
                else if (strNameCount == "2")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationNameLdgr", "DuplicationNameLdgr();", true);
                    txtCustomerName.Focus();
                }
                else if (strNameCount == "3")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationNameCstcnr", "DuplicationNameCstcnr();", true);
                    txtCustomerName.Focus();
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
    //Fetch the datatable from businesslayer and set separately in each field. 
    public void View(string strP_Id)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = false;
        btnUpdateClose.Visible = false;
        btnAddf.Visible = false;
        btnAddClosef.Visible = false;
        btnUpdatef.Visible = false;
        btnUpdateClosef.Visible = false;
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (Session["CORPOFFICEID"] != null)
        {
            // intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityCustomer.Customer_Id = Convert.ToInt32(strP_Id);
        DataTable dtCustomer = objBusinessLayerCustomer.ReadCustomerById(objEntityCustomer);
        DataTable dtContact = objBusinessLayerCustomer.Read_Contact_ById(objEntityCustomer);
        DataTable dtCustomerMedia = objBusinessLayerCustomer.Read_Media_ById(objEntityCustomer);


        //Start:-Display ledger details
        if (dtCustomer.Rows[0]["CSTMR_AS_LDGER"].ToString() == "1")
        {
            cbxLedgerSts.Checked = true;
            if (dtCustomer.Rows[0]["LDGR_CODE"].ToString() != "")
            {
                txtLedgrCode.Text = dtCustomer.Rows[0]["LDGR_CODE"].ToString();
            }

        }
        else
        {
            cbxLedgerSts.Checked = false;
        }

        if (dtCustomer.Rows[0]["LDGR_ID"].ToString() != "")
        {

            HiddenFieldLedgerId.Value = dtCustomer.Rows[0]["LDGR_ID"].ToString();

            LoadLedgers(HiddenFieldLedgerId.Value);
        }


        if (dtCustomer.Rows[0]["COSTCNTR_ID"].ToString() != "")
        {
            hiddenCostCntrId.Value = dtCustomer.Rows[0]["COSTCNTR_ID"].ToString();

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

        if (dtCustomer.Rows[0]["COSTCNTR_CNCL_USR_ID"].ToString() != "0")
        {
            HiddenCostCntrCnclId.Value = dtCustomer.Rows[0]["COSTCNTR_CNCL_USR_ID"].ToString();
        }
        if (dtCustomer.Rows[0]["CSTMR_AS_LDGER"].ToString() == "1")
        {

            //EVM-0027 Aug 21
            if (dtCustomer.Rows[0]["LDGR_SUB_LDER"].ToString() == "1")
            {
                ddlAccountGrp.Enabled = false;
                ddlLedger.Enabled = true;
                chkSubLedger.Checked = true;
                ddlLedger.ClearSelection();
                if (ddlLedger.Items.FindByValue(dtCustomer.Rows[0]["SUBLEDGERID"].ToString()) != null)
                {
                    ddlLedger.Items.FindByValue(dtCustomer.Rows[0]["SUBLEDGERID"].ToString()).Selected = true;
                }

            }
            else
            {
                ddlAccountGrp.Enabled = true;
                ddlLedger.Enabled = false;
                ddlAccountGrp.ClearSelection();
                chkSubLedger.Checked = false;

                if (ddlAccountGrp.Items.FindByValue(dtCustomer.Rows[0]["ACNT_GRP_ID"].ToString()) != null)
                {

                    ddlAccountGrp.Items.FindByValue(dtCustomer.Rows[0]["ACNT_GRP_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtCustomer.Rows[0]["ACNT_GRP_NAME"].ToString(), dtCustomer.Rows[0]["ACNT_GRP_ID"].ToString());
                    ddlAccountGrp.Items.Insert(1, lstGrp);
                    SortDDL(ref this.ddlAccountGrp);
                    ddlAccountGrp.Items.FindByValue(dtCustomer.Rows[0]["ACNT_GRP_ID"].ToString()).Selected = true;
                }
            }
            //EVM-0027 Aug 21 END


            if (dtCustomer.Rows[0]["LDGR_TDS"].ToString() == "0")
            {
                radioTDSyes.Checked = true;
            }
            else
            {
                radioTDSno.Checked = true;
            }
            if (dtCustomer.Rows[0]["LDGR_TCS"].ToString() == "0")
            {
                radioTCSyes.Checked = true;
            }
            else
            {
                radioTCSno.Checked = true;
            }
            if (dtCustomer.Rows[0]["LDGR_COST_CNTR"].ToString() == "0")
            {
                cbxCsCntrSts.Checked = true;


                if (dtCustomer.Rows[0]["COSTCNTR_CODE"].ToString() != "")
                {
                    txtCostCntrCode.Text = dtCustomer.Rows[0]["COSTCNTR_CODE"].ToString();
                }


                if (dtCustomer.Rows[0]["CSCNTR_TTLCNT"].ToString() != "0")
                {
                    cbxCsCntrSts.Enabled = false;
                    cbxLedgerSts.Enabled = false;
                }
            }
            else
            {
                cbxCsCntrSts.Checked = false;


            }



            if (dtCustomer.Rows[0]["TX_DDCTN_ID"].ToString() != "" && dtCustomer.Rows[0]["TX_DDCTN_ID"].ToString() != null)
            {
                if (ddlTDS.Items.FindByValue(dtCustomer.Rows[0]["TX_DDCTN_ID"].ToString()) != null)
                {
                    ddlTDS.Items.FindByValue(dtCustomer.Rows[0]["TX_DDCTN_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtCustomer.Rows[0]["TX_DDCTN_NAME"].ToString(), dtCustomer.Rows[0]["TX_DDCTN_ID"].ToString());
                    ddlTDS.Items.Insert(1, lstGrp);
                    SortDDL(ref this.ddlTDS);
                    ddlTDS.Items.FindByValue(dtCustomer.Rows[0]["TX_DDCTN_ID"].ToString()).Selected = true;
                }
            }
            if (dtCustomer.Rows[0]["TX_CLTN_ID"].ToString() != "" && dtCustomer.Rows[0]["TX_CLTN_ID"].ToString() != null)
            {
                if (ddlTCS.Items.FindByValue(dtCustomer.Rows[0]["TX_CLTN_ID"].ToString()) != null)
                {
                    ddlTCS.Items.FindByValue(dtCustomer.Rows[0]["TX_CLTN_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtCustomer.Rows[0]["TX_CLTN_NAME"].ToString(), dtCustomer.Rows[0]["TX_CLTN_ID"].ToString());
                    ddlTCS.Items.Insert(1, lstGrp);
                    SortDDL(ref this.ddlTCS);
                    ddlTCS.Items.FindByValue(dtCustomer.Rows[0]["TX_CLTN_ID"].ToString()).Selected = true;
                }
            }
            if (ddlCurrency.Items.FindByValue(dtCustomer.Rows[0]["CRNCMST_ID"].ToString()) != null)
            {
                ddlCurrency.Items.FindByValue(dtCustomer.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtCustomer.Rows[0]["CRNCMST_NAME"].ToString(), dtCustomer.Rows[0]["CRNCMST_ID"].ToString());
                ddlCurrency.Items.Insert(1, lstGrp);
                SortDDL(ref this.ddlCurrency);
                ddlCurrency.Items.FindByValue(dtCustomer.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }

            int DC_STS = 0;
            if (dtCustomer.Rows[0]["LDGR_MODE"].ToString() == "")
            {
                txtOpenBalanceDeb.Text = null;
                txtOpenBalanceDeb.Attributes["style"] = "float: right; margin-top: 2.2%; width: 89%;display:none;";
            }
            string openingBal = "";
            if (dtCustomer.Rows[0]["LDGR_MODE"].ToString() != "")
            {
                DC_STS = Convert.ToInt32(dtCustomer.Rows[0]["LDGR_MODE"].ToString());


                if (dtCustomer.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                {
                    openingBal = dtCustomer.Rows[0]["LDGR_OPEN_BAL"].ToString();
                    string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(openingBal.ToString(), objEntityCommon);
                }
                if (DC_STS == 0)
                {
                    txtOpenBalanceDeb.Text = openingBal;
                    // objEntityLedger.DebitBalance = Convert.ToDecimal(dtSup.Rows[0]["LDGR_OPEN_BAL"].ToString());
                    //DandC.Attributes["style"] = "display:block;float: right; margin-top: 2.2%; width: 89%;";
                    typdebit.Checked = true;
                }
                else if (DC_STS == 1)
                {
                    txtOpenBalanceDeb.Text = openingBal;
                    //   objEntityLedger.DebitBalance = Convert.ToDecimal(dtSup.Rows[0]["LDGR_OPEN_BAL"].ToString());
                   // DandC.Attributes["style"] = "float: right; width: 89%;display:block;";
                    typecredit.Checked = true;
                }
            }
            //  txtOpenBalanceDeb.Text = dtCustomer.Rows[0]["LDGR_BALANCE_DEBIT"].ToString();
            // txtOpenBalanceCre.Text = dtCustomer.Rows[0]["LDGR_BALANCE_CREDIT"].ToString();
        }
        ddlCurrency.Enabled = false;
        radioCostNo.Disabled = true;



        txtLedgrCode.Enabled = false;
        txtCostCntrCode.Enabled = false;
        if (HiddenTaxEnable.Value == "1")
        {
            radioCostYes.Disabled = true;
            radioTCSno.Disabled = true;
            radioTCSyes.Disabled = true;
            radioTDSno.Disabled = true;
            radioTDSyes.Disabled = true;
            ddlTCS.Enabled = false;
            ddlTDS.Enabled = false;
        }
        rdExpense.Disabled = true;
        rdIncome.Disabled = true;
        ddlCC.Enabled = false;
        typdebit.Disabled = true;
        typecredit.Disabled = true;
        cbxLedgerSts.Enabled = false;
        // txtOpenBalanceCre.Enabled = false;
        txtOpenBalanceDeb.Enabled = false;
        //End:-Display ledger details

        cbxCsCntrSts.Enabled = false;

        txtCustomerName.Text = dtCustomer.Rows[0]["CSTMR_NAME"].ToString();
        txtCustomerName.Enabled = false;

        ddlCustomerType.Items.Clear();
        ListItem lstCustomerType = new ListItem(dtCustomer.Rows[0]["CSTMRTYP_NAME"].ToString(), dtCustomer.Rows[0]["CSTMRTYP_ID"].ToString());
        ddlCustomerType.Items.Insert(0, lstCustomerType);
        ddlCustomerType.Enabled = false;

        ddlCustomerGroup.Items.Clear();
        ListItem lstCustomerGroup = new ListItem(dtCustomer.Rows[0]["CSTMRGP_NAME"].ToString(), dtCustomer.Rows[0]["CSTMRGP_ID"].ToString());
        ddlCustomerGroup.Items.Insert(0, lstCustomerGroup);
        ddlCustomerGroup.Enabled = false;

        if (dtCustomer.Rows[0]["CSTMR_CODE"].ToString() != "" && dtCustomer.Rows[0]["CSTMR_CODE"].ToString() != null)
        {
            txtCode.Text = dtCustomer.Rows[0]["CSTMR_CODE"].ToString();
        }
        txtCreditLimit.Text = dtCustomer.Rows[0]["CSTMR_CRD_LMT"].ToString();
        txtCreditLimit.Enabled = false;
        txtCreditPeriod.Text = dtCustomer.Rows[0]["CSTMR_CRD_PERIOD"].ToString();
        txtCreditPeriod.Enabled = false;
        txtAddress1.Text = dtCustomer.Rows[0]["CSTMR_ADDRESS1"].ToString();
        txtAddress1.Enabled = false;
        txtAddress2.Text = dtCustomer.Rows[0]["CSTMR_ADDRESS2"].ToString();
        txtAddress2.Enabled = false;
        txtAddress3.Text = dtCustomer.Rows[0]["CSTMR_ADDRESS3"].ToString();
        txtAddress3.Enabled = false;
        txtZipCode.Text = dtCustomer.Rows[0]["CSTMR_ZIPCODE"].ToString();
        txtZipCode.Enabled = false;
        txtPaymentTerm.Text = dtCustomer.Rows[0]["CSTMR_PMNT_TERMS"].ToString();
        txtPaymentTerm.Enabled = false;
        txtPriceTerm.Text = dtCustomer.Rows[0]["CSTMR_PRICE_TERMS"].ToString();
        txtPriceTerm.Enabled = false;
        txtDeliveryTerm.Text = dtCustomer.Rows[0]["CSTMR_DLVRY_TERMS"].ToString();
        txtDeliveryTerm.Enabled = false;
        txtTinNumber.Text = dtCustomer.Rows[0]["CSTMR_TIN_NUMBER"].ToString();
        txtTinNumber.Enabled = false;
        txtMobile.Text = dtCustomer.Rows[0]["CSTMR_MOBILE"].ToString();
        txtMobile.Enabled = false;
        txtPhone.Text = dtCustomer.Rows[0]["CSTMR_PHONE"].ToString();
        txtPhone.Enabled = false;
        txtEmail.Text = dtCustomer.Rows[0]["CSTMR_EMAIL"].ToString();
        txtEmail.Enabled = false;
        txtWebSite.Text = dtCustomer.Rows[0]["CSTMR_WEBSITE"].ToString();
        txtWebSite.Enabled = false;

        ddlPriceTerm.Enabled = false;
        ddlPaymentTerm.Enabled = false;
        ddlDeliveryTerm.Enabled = false;

        ddlCountry.Items.Clear();
        ListItem lstCountry = new ListItem(dtCustomer.Rows[0]["CNTRY_NAME"].ToString(), dtCustomer.Rows[0]["CNTRY_ID"].ToString());
        ddlCountry.Items.Insert(0, lstCountry);
        ddlCountry.Enabled = false;

        ddlState.Items.Clear();
        if (dtCustomer.Rows[0]["STATE_ID"] != DBNull.Value)
        {
            ListItem lstState = new ListItem(dtCustomer.Rows[0]["STATE_NAME"].ToString(), dtCustomer.Rows[0]["STATE_ID"].ToString());
            ddlState.Items.Insert(0, lstState);
        }
        ddlState.Enabled = false;


        ddlCity.Items.Clear();
        if (dtCustomer.Rows[0]["CITY_ID"] != DBNull.Value)
        {
            ListItem lstCity = new ListItem(dtCustomer.Rows[0]["CITY_NAME"].ToString(), dtCustomer.Rows[0]["CITY_ID"].ToString());
            ddlCity.Items.Insert(0, lstCity);
        }
        ddlCity.Enabled = false;

        int intStatus = Convert.ToInt32(dtCustomer.Rows[0]["CSTMR_STATUS"]);
        if (intStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }
        cbxStatus.Enabled = false;


        if (dtCustomer.Rows[0]["CSTMR_CRD_LMT_RESTRICT"].ToString() == "1")
        {
            cbxCrdtLmtRestrict.Checked = true;
        }
        if (dtCustomer.Rows[0]["CSTMR_CRD_LMT_WARN"].ToString() == "1")
        {
            cbxCrdtLmtWarn.Checked = true;
        }
        if (dtCustomer.Rows[0]["CSTMR_CRD_PRD_RESTRICT"].ToString() == "1")
        {
            cbxCrdtPeriodRestrict.Checked = true;
        }
        if (dtCustomer.Rows[0]["CSTMR_CRD_PRD_WARN"].ToString() == "1")
        {
            cbxCrdtPeriodWarn.Checked = true;
        }

        //filling extra contact details
        if (dtContact.Rows.Count == 0) { }
        else
        {
            if (dtContact.Rows.Count >= 1)
            {
                txtNameOne.Text = dtContact.Rows[0]["CSTMRCNT_NAME"].ToString();
                txtAddressOne.Text = dtContact.Rows[0]["CSTMRCNT_ADDRESS"].ToString();
                txtAddressOne2.Text = dtContact.Rows[0]["CSTMRCNT_ADDRESS2"].ToString();
                txtAddressOne3.Text = dtContact.Rows[0]["CSTMRCNT_ADDRESS3"].ToString();
                txtMobileOne.Text = dtContact.Rows[0]["CSTMRCNT_MOBILE"].ToString();
                txtPhoneOne.Text = dtContact.Rows[0]["CSTMRCNT_PHONE"].ToString();
                txtEmailOne.Text = dtContact.Rows[0]["CSTMRCNT_EMAIL"].ToString();
                txtWebsiteOne.Text = dtContact.Rows[0]["CSTMRCNT_WEBSITE"].ToString();
                if (dtContact.Rows[0]["CSTMRCNT_MAIL_ALWD"].ToString() == "1")
                {
                    cbxAllowOtherMailOne.Checked = true;
                }
                else
                {
                    cbxAllowOtherMailOne.Checked = false;
                }

            }
            if (dtContact.Rows.Count >= 2)
            {
                txtNameTwo.Text = dtContact.Rows[1]["CSTMRCNT_NAME"].ToString();
                txtAddressTwo.Text = dtContact.Rows[1]["CSTMRCNT_ADDRESS"].ToString();
                txtAddressTwo2.Text = dtContact.Rows[1]["CSTMRCNT_ADDRESS2"].ToString();
                txtAddressTwo3.Text = dtContact.Rows[1]["CSTMRCNT_ADDRESS3"].ToString();
                txtMobileTwo.Text = dtContact.Rows[1]["CSTMRCNT_MOBILE"].ToString();
                txtPhoneTwo.Text = dtContact.Rows[1]["CSTMRCNT_PHONE"].ToString();
                txtEmailTwo.Text = dtContact.Rows[1]["CSTMRCNT_EMAIL"].ToString();
                txtWebsiteTwo.Text = dtContact.Rows[1]["CSTMRCNT_WEBSITE"].ToString();
                if (dtContact.Rows[0]["CSTMRCNT_MAIL_ALWD"].ToString() == "1")
                {
                    cbxAllowOtherMailTwo.Checked = true;
                }
                else
                {
                    cbxAllowOtherMailTwo.Checked = false;
                }
            }
            if (dtContact.Rows.Count >= 3)
            {
                txtNameThree.Text = dtContact.Rows[2]["CSTMRCNT_NAME"].ToString();
                txtAddressThree.Text = dtContact.Rows[2]["CSTMRCNT_ADDRESS"].ToString();
                txtMobileThree.Text = dtContact.Rows[2]["CSTMRCNT_MOBILE"].ToString();
                txtPhoneThree.Text = dtContact.Rows[2]["CSTMRCNT_PHONE"].ToString();
                txtEmailThree.Text = dtContact.Rows[2]["CSTMRCNT_EMAIL"].ToString();
                txtWebsiteThree.Text = dtContact.Rows[2]["CSTMRCNT_WEBSITE"].ToString();
                if (dtContact.Rows[0]["CSTMRCNT_MAIL_ALWD"].ToString() == "1")
                {
                    cbxAllowOtherMailThree.Checked = true;
                }
                else
                {
                    cbxAllowOtherMailThree.Checked = false;
                }
            }
        }

        if (dtCustomerMedia.Rows.Count == 0) { }
        else
        {
            string strMediaValue = DataTableToJSONWithJavaScriptSerializer(dtCustomerMedia);
            hiddenMedia.Value = strMediaValue;
        }

        string strMediaHtml = "";
        int intRowIdentity = 0;
        //automatically generate media controls based on media master
        for (int intRow = 0; intRow < dtCustomerMedia.Rows.Count; intRow++)
        {



            string strTextboxName = dtCustomerMedia.Rows[intRow]["MEDIA_ID"].ToString();

            string strValue = "";
            strValue = dtCustomerMedia.Rows[intRow]["MEDIA_DESCRIPTION"].ToString();
            if (intRowIdentity == 0)
                strMediaHtml = strMediaHtml + " <div id=\"div7\" class=\"form-group fg2 fg2_mr sa_fg3 sa_640\">";
            else
                strMediaHtml = strMediaHtml + " <div id=\"div7\" class=\"form-group fg2 fg2_mr sa_fg3 sa_640\" >";
            strMediaHtml = strMediaHtml + "<label for=\"email\" class=\"fg2_la1\"> " + dtMedia.Rows[intRow]["MEDIA_NAME"] + " <span class=\"spn1\"></span></label>";

            if (intRowIdentity == 0)
                strMediaHtml = strMediaHtml + "<input type=text ID=" + strTextboxName + "  class=\"form-control fg2_inp1\" onblur=\"AssignMediaValues(this)\" onkeypress=\"return textRemoveSpecial(event)\" runat=\"server\" MaxLength=\"150\"  value=" + strValue + "  >";
            else
                strMediaHtml = strMediaHtml + "<input type=text ID=" + strTextboxName + " class=\"form-control fg2_inp1\" onblur=\"AssignMediaValues(this)\" onkeypress=\"return textRemoveSpecial(event)\" runat=\"server\" MaxLength=\"150\"  value=" + strValue + "  >";
            strMediaHtml = strMediaHtml + "</div>";

            if (intRowIdentity == 0)
                intRowIdentity = 1;
            else
                intRowIdentity = 0;
        }



        divMedia.InnerHtml = strMediaHtml;


        //disable the controls on cancelled entries
        txtNameOne.Enabled = false;
        txtAddressOne.Enabled = false;
        txtMobileOne.Enabled = false;
        txtPhoneOne.Enabled = false;
        txtEmailOne.Enabled = false;
        txtWebsiteOne.Enabled = false;

        txtNameTwo.Enabled = false;
        txtAddressTwo.Enabled = false;
        txtMobileTwo.Enabled = false;
        txtPhoneTwo.Enabled = false;
        txtEmailTwo.Enabled = false;
        txtWebsiteTwo.Enabled = false;

        txtNameThree.Enabled = false;
        txtAddressThree.Enabled = false;
        txtMobileThree.Enabled = false;
        txtPhoneThree.Enabled = false;
        txtEmailThree.Enabled = false;
        txtWebsiteThree.Enabled = false;
    }

    //Fetching the table from business layer and assign them in our fields.
    public void Update(string strP_Id)
    {
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        int intCorpId = 0;
        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }


        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnUpdate.Visible = true;
        btnUpdateClose.Visible = true;
        btnAddf.Visible = false;
        btnAddClosef.Visible = false;
        btnUpdatef.Visible = true;
        btnUpdateClosef.Visible = true;
        objEntityCustomer.Customer_Id = Convert.ToInt32(strP_Id);
        DataTable dtCustomer = objBusinessLayerCustomer.ReadCustomerById(objEntityCustomer);
        DataTable dtContact = objBusinessLayerCustomer.Read_Contact_ById(objEntityCustomer);
        DataTable dtCustomerMedia = objBusinessLayerCustomer.Read_Media_ById(objEntityCustomer);
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        //Start:-Display ledger details
        if (dtCustomer.Rows[0]["CSTMR_AS_LDGER"].ToString() == "1")
        {
            cbxLedgerSts.Checked = true;

            if (dtCustomer.Rows[0]["LDGR_TTLCNT"].ToString() != "0")
            {
                cbxLedgerSts.Enabled = false;
                chkSubLedger.Enabled = false;
                HiddenAcntGrpChngSts.Value = "1";
            }
        }
        else
        {
            cbxLedgerSts.Checked = false;
        }

        if (dtCustomer.Rows[0]["LDGR_ID"].ToString() != "")
        {

            HiddenFieldLedgerId.Value = dtCustomer.Rows[0]["LDGR_ID"].ToString();

            LoadLedgers(HiddenFieldLedgerId.Value);
        }
        if (HiddenFieldLedgerId.Value != "")
        {
            //   txtCustomerName.Enabled = false;
            ddlCustomerType.Focus();
        }
        if (dtCustomer.Rows[0]["COSTCNTR_ID"].ToString() != "")
        {
            hiddenCostCntrId.Value = dtCustomer.Rows[0]["COSTCNTR_ID"].ToString();
            clsBusinessLayer_Cost_Center objBusinessCostCenter = new clsBusinessLayer_Cost_Center();
            clsEntityLayer_Cost_Center objEntity = new clsEntityLayer_Cost_Center();
            int intOrgId = 0, intUserId = 0;
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

        ddlAccountGrp.ClearSelection();
        if (ddlAccountGrp.Items.FindByValue(dtCustomer.Rows[0]["ACNT_GRP_ID"].ToString()) != null)
        {

            ddlAccountGrp.Items.FindByValue(dtCustomer.Rows[0]["ACNT_GRP_ID"].ToString()).Selected = true;
        }
        else
        {
            ListItem lstGrp = new ListItem(dtCustomer.Rows[0]["ACNT_GRP_NAME"].ToString(), dtCustomer.Rows[0]["ACNT_GRP_ID"].ToString());
            ddlAccountGrp.Items.Insert(1, lstGrp);
           // SortDDL(ref this.ddlAccountGrp);
           // ddlAccountGrp.Items.FindByValue(dtCustomer.Rows[0]["ACNT_GRP_ID"].ToString()).Selected = true;
        //    ddlAccountGrp.Items.Insert(0, "--SELECT ACCOUNT GROUP--");
        }
        if (dtCustomer.Rows[0]["COSTCNTR_CNCL_USR_ID"].ToString() != "0")
        {
            HiddenCostCntrCnclId.Value = dtCustomer.Rows[0]["COSTCNTR_CNCL_USR_ID"].ToString();
        }


        if (dtCustomer.Rows[0]["CSTMR_AS_LDGER"].ToString() == "1")
        {


            //EVM-0027 Aug 21

            if (dtCustomer.Rows[0]["LDGR_SUB_LDER"].ToString() == "1")
            {
                ddlLedger.Enabled = true;
                ddlAccountGrp.Enabled = false;
                chkSubLedger.Checked = true;
                ddlLedger.ClearSelection();

                if (ddlLedger.Items.FindByValue(dtCustomer.Rows[0]["SUBLEDGERID"].ToString()) != null)
                {
                    ddlLedger.Items.FindByValue(dtCustomer.Rows[0]["SUBLEDGERID"].ToString()).Selected = true;
                }
            }
            else
            {
                ddlAccountGrp.Enabled = true;
                ddlLedger.Enabled = false;



                ddlAccountGrp.ClearSelection();
                chkSubLedger.Checked = false;

                if (ddlAccountGrp.Items.FindByValue(dtCustomer.Rows[0]["ACNT_GRP_ID"].ToString()) != null)
                {

                    ddlAccountGrp.Items.FindByValue(dtCustomer.Rows[0]["ACNT_GRP_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtCustomer.Rows[0]["ACNT_GRP_NAME"].ToString(), dtCustomer.Rows[0]["ACNT_GRP_ID"].ToString());
                    ddlAccountGrp.Items.Insert(1, lstGrp);
                    SortDDL(ref this.ddlAccountGrp);
                    ddlAccountGrp.Items.FindByValue(dtCustomer.Rows[0]["ACNT_GRP_ID"].ToString()).Selected = true;
                }
            }
            //EVM-0027 Aug 21 END

            if (dtCustomer.Rows[0]["LDGR_TDS"].ToString() == "0")
            {
                radioTDSyes.Checked = true;
            }
            else
            {
                radioTDSno.Checked = true;
            }
            if (dtCustomer.Rows[0]["LDGR_TCS"].ToString() == "0")
            {
                radioTCSyes.Checked = true;
            }
            else
            {
                radioTCSno.Checked = true;
            }
            if (dtCustomer.Rows[0]["LDGR_COST_CNTR"].ToString() == "0")
            {
                cbxCsCntrSts.Checked = true;

                if (dtCustomer.Rows[0]["COSTCNTR_CODE"].ToString() != "")
                {
                    txtCostCntrCode.Text = dtCustomer.Rows[0]["COSTCNTR_CODE"].ToString();
                }



                if (dtCustomer.Rows[0]["CSCNTR_TTLCNT"].ToString() != "0")
                {
                    cbxCsCntrSts.Enabled = false;
                    cbxLedgerSts.Enabled = false;
                    chkSubLedger.Enabled = false;
                }
            }
            else
            {
                cbxCsCntrSts.Checked = false;


            }

            ddlTDS.ClearSelection();
            if (dtCustomer.Rows[0]["TX_DDCTN_ID"].ToString() != "" && dtCustomer.Rows[0]["TX_DDCTN_ID"].ToString() != null)
            {
                if (ddlTDS.Items.FindByValue(dtCustomer.Rows[0]["TX_DDCTN_ID"].ToString()) != null)
                {

                    ddlTDS.Items.FindByValue(dtCustomer.Rows[0]["TX_DDCTN_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtCustomer.Rows[0]["TX_DDCTN_NAME"].ToString(), dtCustomer.Rows[0]["TX_DDCTN_ID"].ToString());
                    ddlTDS.Items.Insert(1, lstGrp);
                    SortDDL(ref this.ddlTDS);
                    ddlTDS.Items.FindByValue(dtCustomer.Rows[0]["TX_DDCTN_ID"].ToString()).Selected = true;
                }
            }
            ddlTCS.ClearSelection();
            if (dtCustomer.Rows[0]["TX_CLTN_ID"].ToString() != "" && dtCustomer.Rows[0]["TX_CLTN_ID"].ToString() != null)
            {
                if (ddlTCS.Items.FindByValue(dtCustomer.Rows[0]["TX_CLTN_ID"].ToString()) != null)
                {

                    ddlTCS.Items.FindByValue(dtCustomer.Rows[0]["TX_CLTN_ID"].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dtCustomer.Rows[0]["TX_CLTN_NAME"].ToString(), dtCustomer.Rows[0]["TX_CLTN_ID"].ToString());
                    ddlTCS.Items.Insert(1, lstGrp);
                    SortDDL(ref this.ddlTCS);
                    ddlTCS.Items.FindByValue(dtCustomer.Rows[0]["TX_CLTN_ID"].ToString()).Selected = true;
                }
            }
            ddlCurrency.ClearSelection();

            if (ddlCurrency.Items.FindByValue(dtCustomer.Rows[0]["CRNCMST_ID"].ToString()) != null)
            {
                ddlCurrency.Items.FindByValue(dtCustomer.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstGrp = new ListItem(dtCustomer.Rows[0]["CRNCMST_NAME"].ToString(), dtCustomer.Rows[0]["CRNCMST_ID"].ToString());
                ddlCurrency.Items.Insert(1, lstGrp);
                SortDDL(ref this.ddlCurrency);
                ddlCurrency.Items.FindByValue(dtCustomer.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }

            int DC_STS = 0;
            if (dtCustomer.Rows[0]["LDGR_MODE"].ToString() == "")
            {
                txtOpenBalanceDeb.Text = null;
                txtOpenBalanceDeb.Attributes["style"] = "float: right; margin-top: 2.2%; width: 89%;display:none;";
            }
            string openingBal = "";
            if (dtCustomer.Rows[0]["LDGR_MODE"].ToString() != "")
            {
                DC_STS = Convert.ToInt32(dtCustomer.Rows[0]["LDGR_MODE"].ToString());


                if (dtCustomer.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                {
                    openingBal = dtCustomer.Rows[0]["LDGR_OPEN_BAL"].ToString();
                    string NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(openingBal.ToString(), objEntityCommon);
                }
                if (DC_STS == 0)
                {
                    txtOpenBalanceDeb.Text = openingBal;
                    // objEntityLedger.DebitBalance = Convert.ToDecimal(dtSup.Rows[0]["LDGR_OPEN_BAL"].ToString());
                //    DandC.Attributes["style"] = "display:block;float: right; margin-top: 2.2%; width: 89%;";
                    typdebit.Checked = true;
                }
                else if (DC_STS == 1)
                {
                    txtOpenBalanceDeb.Text = openingBal;
                    //   objEntityLedger.DebitBalance = Convert.ToDecimal(dtSup.Rows[0]["LDGR_OPEN_BAL"].ToString());
                  //  DandC.Attributes["style"] = "float: right; width: 89%;display:block;";
                    typecredit.Checked = true;
                }
            }
            //  txtOpenBalanceDeb.Text = dtCustomer.Rows[0]["LDGR_BALANCE_DEBIT"].ToString();
            // txtOpenBalanceCre.Text = dtCustomer.Rows[0]["LDGR_BALANCE_CREDIT"].ToString();




            if (dtCustomer.Rows[0]["LDGR_CODE"].ToString() != "")
            {
                txtLedgrCode.Text = dtCustomer.Rows[0]["LDGR_CODE"].ToString();
            }
        }
        //End:-Display ledger details


        txtCustomerName.Text = dtCustomer.Rows[0]["CSTMR_NAME"].ToString();
        ddlCustomerType.ClearSelection();
        if (dtCustomer.Rows[0]["CSTMRTYP_STATUS"].ToString() == "1")
        {

            ddlCustomerType.Items.FindByText(dtCustomer.Rows[0]["CSTMRTYP_NAME"].ToString()).Selected = true;
        }
        else
        {
            ListItem lstCusromerGroup = new ListItem(dtCustomer.Rows[0]["CSTMRTYP_NAME"].ToString(), dtCustomer.Rows[0]["CSTMRTYP_ID"].ToString());
            ddlCustomerType.Items.Insert(1, lstCusromerGroup);
            SortDDL(ref this.ddlCustomerType);
            ddlCustomerType.Items.FindByText(dtCustomer.Rows[0]["CSTMRTYP_NAME"].ToString()).Selected = true;
        }

        ddlCustomerGroup.ClearSelection();
        if (dtCustomer.Rows[0]["CSTMRGP_STATUS"].ToString() == "1" && dtCustomer.Rows[0]["CSTMRGP_CNCL_USR_ID"].ToString() == "")
        {

            ddlCustomerGroup.Items.FindByText(dtCustomer.Rows[0]["CSTMRGP_NAME"].ToString()).Selected = true;
        }
        else
        {
            ListItem lstCusromerGroup = new ListItem(dtCustomer.Rows[0]["CSTMRGP_NAME"].ToString(), dtCustomer.Rows[0]["CSTMRGP_ID"].ToString());
            ddlCustomerGroup.Items.Insert(1, lstCusromerGroup);
            SortDDL(ref this.ddlCustomerGroup);
            ddlCustomerGroup.Items.FindByText(dtCustomer.Rows[0]["CSTMRGP_NAME"].ToString()).Selected = true;
        }
        txtRefNum.Text = dtCustomer.Rows[0]["CSTMR_REFNUM"].ToString();

        if (dtCustomer.Rows[0]["CSTMR_CRD_LMT"].ToString() != "0")
            txtCreditLimit.Text = dtCustomer.Rows[0]["CSTMR_CRD_LMT"].ToString(); ;
        if (dtCustomer.Rows[0]["CSTMR_CRD_PERIOD"].ToString() != "0")
            txtCreditPeriod.Text = dtCustomer.Rows[0]["CSTMR_CRD_PERIOD"].ToString();
        txtAddress1.Text = dtCustomer.Rows[0]["CSTMR_ADDRESS1"].ToString();
        txtAddress2.Text = dtCustomer.Rows[0]["CSTMR_ADDRESS2"].ToString();
        txtAddress3.Text = dtCustomer.Rows[0]["CSTMR_ADDRESS3"].ToString();
        txtZipCode.Text = dtCustomer.Rows[0]["CSTMR_ZIPCODE"].ToString();
        txtPaymentTerm.Text = dtCustomer.Rows[0]["CSTMR_PMNT_TERMS"].ToString();
        txtPriceTerm.Text = dtCustomer.Rows[0]["CSTMR_PRICE_TERMS"].ToString();
        txtDeliveryTerm.Text = dtCustomer.Rows[0]["CSTMR_DLVRY_TERMS"].ToString();
        txtTinNumber.Text = dtCustomer.Rows[0]["CSTMR_TIN_NUMBER"].ToString();
        txtMobile.Text = dtCustomer.Rows[0]["CSTMR_MOBILE"].ToString();
        txtPhone.Text = dtCustomer.Rows[0]["CSTMR_PHONE"].ToString();
        txtEmail.Text = dtCustomer.Rows[0]["CSTMR_EMAIL"].ToString();
        txtWebSite.Text = dtCustomer.Rows[0]["CSTMR_WEBSITE"].ToString();
        ddlCountry.ClearSelection();
        if (dtCustomer.Rows[0]["CSTMR_CODE"].ToString() != "" && dtCustomer.Rows[0]["CSTMR_CODE"].ToString() != null)
        {
            txtCode.Text = dtCustomer.Rows[0]["CSTMR_CODE"].ToString();
        }
        if (dtCustomer.Rows[0]["CNTRY_STATUS"].ToString() == "1" && dtCustomer.Rows[0]["CNTRY_CNCL_USR_ID"].ToString() == "")
        {

            ddlCountry.Items.FindByText(dtCustomer.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
        }
        else
        {
            ListItem lstCountry = new ListItem(dtCustomer.Rows[0]["CNTRY_NAME"].ToString(), dtCustomer.Rows[0]["CNTRY_ID"].ToString());
            ddlCountry.Items.Insert(1, lstCountry);
            SortDDL(ref this.ddlCustomerGroup);
            ddlCountry.Items.FindByText(dtCustomer.Rows[0]["CNTRY_NAME"].ToString()).Selected = true;
        }

        State_Load();


        if (dtCustomer.Rows[0]["STATE_ID"] != DBNull.Value)
        {
            // ddlState.ClearSelection();
            if (dtCustomer.Rows[0]["STATE_STATUS"].ToString() == "1" && dtCustomer.Rows[0]["STATE_CNCL_USR_ID"].ToString() == "")
            {
                //ddlState.Items.Clear();
                ddlState.Items.FindByText(dtCustomer.Rows[0]["STATE_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstState = new ListItem(dtCustomer.Rows[0]["STATE_NAME"].ToString(), dtCustomer.Rows[0]["STATE_ID"].ToString());
                ddlState.Items.Insert(1, lstState);
                SortDDL(ref this.ddlCustomerGroup);
                ddlState.Items.FindByText(dtCustomer.Rows[0]["STATE_NAME"].ToString()).Selected = true;
            }
            City_Load();
        }

        if (dtCustomer.Rows[0]["CITY_ID"] != DBNull.Value)
        {
            // ddlCity.ClearSelection();
            if (dtCustomer.Rows[0]["CITY_STATUS"].ToString() == "1" && dtCustomer.Rows[0]["CITY_CNCL_USR_ID"].ToString() == "")
            {

                // ddlCity.Items.Clear();
                ddlCity.Items.FindByText(dtCustomer.Rows[0]["CITY_NAME"].ToString()).Selected = true;
            }
            else
            {
                ListItem lstCity = new ListItem(dtCustomer.Rows[0]["CITY_NAME"].ToString(), dtCustomer.Rows[0]["CITY_ID"].ToString());
                ddlCity.Items.Insert(1, lstCity);
                SortDDL(ref this.ddlCustomerGroup);
                ddlCity.Items.FindByText(dtCustomer.Rows[0]["CITY_NAME"].ToString()).Selected = true;
            }
        }

        int intStatus = Convert.ToInt32(dtCustomer.Rows[0]["CSTMR_STATUS"]);
        if (intStatus == 1)
        {
            cbxStatus.Checked = true;
        }
        else
        {
            cbxStatus.Checked = false;
        }

        cbxCrdtLmtRestrict.Checked = false;
        cbxCrdtLmtWarn.Checked = false;
        cbxCrdtPeriodRestrict.Checked = false;
        cbxCrdtPeriodWarn.Checked = false;
        if (dtCustomer.Rows[0]["CSTMR_CRD_LMT_RESTRICT"].ToString() == "1")
        {
            cbxCrdtLmtRestrict.Checked = true;
        }
        if (dtCustomer.Rows[0]["CSTMR_CRD_LMT_WARN"].ToString() == "1")
        {
            cbxCrdtLmtWarn.Checked = true;
        }
        if (dtCustomer.Rows[0]["CSTMR_CRD_PRD_RESTRICT"].ToString() == "1")
        {
            cbxCrdtPeriodRestrict.Checked = true;
        }
        if (dtCustomer.Rows[0]["CSTMR_CRD_PRD_WARN"].ToString() == "1")
        {
            cbxCrdtPeriodWarn.Checked = true;
        }

        //filling extra contact details
        if (dtContact.Rows.Count == 0) { }
        else
        {
            if (dtContact.Rows.Count >= 1)
            {
                txtNameOne.Text = dtContact.Rows[0]["CSTMRCNT_NAME"].ToString();
                txtAddressOne.Text = dtContact.Rows[0]["CSTMRCNT_ADDRESS"].ToString();
                txtAddressOne2.Text = dtContact.Rows[0]["CSTMRCNT_ADDRESS2"].ToString();
                txtAddressOne3.Text = dtContact.Rows[0]["CSTMRCNT_ADDRESS3"].ToString();
                txtMobileOne.Text = dtContact.Rows[0]["CSTMRCNT_MOBILE"].ToString();
                txtPhoneOne.Text = dtContact.Rows[0]["CSTMRCNT_PHONE"].ToString();
                txtEmailOne.Text = dtContact.Rows[0]["CSTMRCNT_EMAIL"].ToString();
                txtWebsiteOne.Text = dtContact.Rows[0]["CSTMRCNT_WEBSITE"].ToString();
                if (dtContact.Rows[0]["CSTMRCNT_MAIL_ALWD"].ToString() == "1")
                {
                    cbxAllowOtherMailOne.Checked = true;
                }
                else
                {
                    cbxAllowOtherMailOne.Checked = false;
                }
            }
            if (dtContact.Rows.Count >= 2)
            {
                txtNameTwo.Text = dtContact.Rows[1]["CSTMRCNT_NAME"].ToString();
                txtAddressTwo.Text = dtContact.Rows[1]["CSTMRCNT_ADDRESS"].ToString();
                txtAddressTwo2.Text = dtContact.Rows[1]["CSTMRCNT_ADDRESS2"].ToString();
                txtAddressTwo3.Text = dtContact.Rows[1]["CSTMRCNT_ADDRESS3"].ToString();
                txtMobileTwo.Text = dtContact.Rows[1]["CSTMRCNT_MOBILE"].ToString();
                txtPhoneTwo.Text = dtContact.Rows[1]["CSTMRCNT_PHONE"].ToString();
                txtEmailTwo.Text = dtContact.Rows[1]["CSTMRCNT_EMAIL"].ToString();
                txtWebsiteTwo.Text = dtContact.Rows[1]["CSTMRCNT_WEBSITE"].ToString();
                if (dtContact.Rows[1]["CSTMRCNT_MAIL_ALWD"].ToString() == "1")
                {
                    cbxAllowOtherMailTwo.Checked = true;
                }
                else
                {
                    cbxAllowOtherMailTwo.Checked = false;
                }
            }
            if (dtContact.Rows.Count >= 3)
            {
                txtNameThree.Text = dtContact.Rows[2]["CSTMRCNT_NAME"].ToString();
                txtAddressThree.Text = dtContact.Rows[2]["CSTMRCNT_ADDRESS"].ToString();
                txtMobileThree.Text = dtContact.Rows[2]["CSTMRCNT_MOBILE"].ToString();
                txtPhoneThree.Text = dtContact.Rows[2]["CSTMRCNT_PHONE"].ToString();
                txtEmailThree.Text = dtContact.Rows[2]["CSTMRCNT_EMAIL"].ToString();
                txtWebsiteThree.Text = dtContact.Rows[2]["CSTMRCNT_WEBSITE"].ToString();
                if (dtContact.Rows[2]["CSTMRCNT_MAIL_ALWD"].ToString() == "1")
                {
                    cbxAllowOtherMailThree.Checked = true;
                }
                else
                {
                    cbxAllowOtherMailThree.Checked = false;
                }
            }
        }
        if (dtCustomerMedia.Rows.Count == 0) { }
        else
        {
            string strMediaValue = DataTableToJSONWithJavaScriptSerializer(dtCustomerMedia);
            hiddenMedia.Value = strMediaValue;
        }

        string strMediaHtml = "";
        int intRowIdentity = 0;
        //automatically generate media controls based on media master
        for (int intRow = 0; intRow < dtCustomerMedia.Rows.Count; intRow++)
        {
            string strTextboxName = dtCustomerMedia.Rows[intRow]["MEDIA_ID"].ToString();

            string strValue = "";
            strValue = dtCustomerMedia.Rows[intRow]["MEDIA_DESCRIPTION"].ToString();
            if (intRowIdentity == 0)
                strMediaHtml = strMediaHtml + " <div id=\"div7\" class=\"form-group fg2 fg2_mr sa_fg3 sa_640\">";
            else
                strMediaHtml = strMediaHtml + " <div id=\"div7\" class=\"form-group fg2 fg2_mr sa_fg3 sa_640\" >";
            strMediaHtml = strMediaHtml + "<label for=\"email\" class=\"fg2_la1\" > " + dtMedia.Rows[intRow]["MEDIA_NAME"] + " <span class=\"spn1\"></span></label>";
            if (intRowIdentity == 0)
                strMediaHtml = strMediaHtml + "<input type=text ID=" + strTextboxName + "  class=\"form-control fg2_inp1\" onblur=\"AssignMediaValues(this)\" onkeypress=\"return textRemoveSpecial(event)\" runat=\"server\" MaxLength=\"150\"  value=" + strValue + " >";
            else
                strMediaHtml = strMediaHtml + "<input type=text ID=" + strTextboxName + " class=\"form-control fg2_inp1\" onblur=\"AssignMediaValues(this)\" onkeypress=\"return textRemoveSpecial(event)\" runat=\"server\" MaxLength=\"150\"  value=" + strValue + " >";
            strMediaHtml = strMediaHtml + "</div>";

            if (intRowIdentity == 0)
                intRowIdentity = 1;
            else
                intRowIdentity = 0;
        }



        divMedia.InnerHtml = strMediaHtml;
        if (dtCustomer.Rows[0]["COUNT_TRANSACTION"].ToString() != "0")
        {
            ddlCustomerType.Enabled = false;
        }
    }


    //for sorting drop down
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

    //at country changed then load state
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {

        State_Load();
        ScriptManager.RegisterStartupScript(this, GetType(), "CountryFocus", "CountryFocus();", true);
    }

    //at state changed then load city
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

        City_Load();
        ScriptManager.RegisterStartupScript(this, GetType(), "StateFocus", "StateFocus();", true);
    }

    //convert datatable to json format
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

    //start 005
    public void PriceTermsLoad()
    {
        ddlPriceTerm.Items.Clear();
        clsBusinessLayerCustomer objBusinessLayerCustomer = new clsBusinessLayerCustomer();
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityCustomer.CorpId = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityCustomer.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        objEntityCustomer.TemplateTypeId = Convert.ToInt32(clsCommonLibrary.TERMS_TEMPLATE.Price_Term);
        ddlPriceTerm.ClearSelection();
        DataTable dtTerms = objBusinessLayerCustomer.ReadTermTemplate(objEntityCustomer);

        ddlPriceTerm.DataSource = dtTerms;
        ddlPriceTerm.DataTextField = "TRTEMP_NAME";
        ddlPriceTerm.DataValueField = "TRTEMP_ID";
        ddlPriceTerm.DataBind();
        ddlPriceTerm.Items.Insert(0, "--SELECT PRICE TERMS--");
    }
    public void PaymentTermsLoad()
    {
        ddlPaymentTerm.Items.Clear();
        clsBusinessLayerCustomer objBusinessLayerCustomer = new clsBusinessLayerCustomer();
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityCustomer.CorpId = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityCustomer.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        objEntityCustomer.TemplateTypeId = Convert.ToInt32(clsCommonLibrary.TERMS_TEMPLATE.Payment_Term);
        ddlPaymentTerm.ClearSelection();
        DataTable dtTerms = objBusinessLayerCustomer.ReadTermTemplate(objEntityCustomer);

        ddlPaymentTerm.DataSource = dtTerms;
        ddlPaymentTerm.DataTextField = "TRTEMP_NAME";
        ddlPaymentTerm.DataValueField = "TRTEMP_ID";
        ddlPaymentTerm.DataBind();
        ddlPaymentTerm.Items.Insert(0, "--SELECT PAYMENT TERMS--");
    }
    public void DeliveryTermsLoad()
    {
        ddlDeliveryTerm.Items.Clear();
        clsBusinessLayerCustomer objBusinessLayerCustomer = new clsBusinessLayerCustomer();
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        if (hiddenCorporateId.Value == "")
        {
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityCustomer.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {

            objEntityCustomer.CorpId = Convert.ToInt32(hiddenCorporateId.Value);
        }
        if (hiddenOrganisationId.Value == "")
        {
            if (Session["ORGID"] != null)
            {
                objEntityCustomer.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        else
        {
            objEntityCustomer.Organisation_Id = Convert.ToInt32(hiddenOrganisationId.Value);
        }
        objEntityCustomer.TemplateTypeId = Convert.ToInt32(clsCommonLibrary.TERMS_TEMPLATE.Delivery_Term);
        ddlDeliveryTerm.ClearSelection();
        DataTable dtTerms = objBusinessLayerCustomer.ReadTermTemplate(objEntityCustomer);

        ddlDeliveryTerm.DataSource = dtTerms;
        ddlDeliveryTerm.DataTextField = "TRTEMP_NAME";
        ddlDeliveryTerm.DataValueField = "TRTEMP_ID";
        ddlDeliveryTerm.DataBind();
        ddlDeliveryTerm.Items.Insert(0, "--SELECT DELIVERY TERMS--");
    }
    public class QuotationTerms
    {
        public string strTermDescription;

    }

    [WebMethod]
    public static QuotationTerms TermDetails(string corporateId, string organisationId, string TermId)
    {
        QuotationTerms objQtnTerms = new QuotationTerms();     // CREATE AN OBJECT.

        //Creating objects for business layer
        clsBusinessLayerCustomer objBusinessLayerCustomer = new clsBusinessLayerCustomer();
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();


        if (corporateId != null && corporateId != "" && corporateId != "undefined" && organisationId != null && organisationId != "" && organisationId != "undefined" && TermId != null && TermId != "" && TermId != "undefined")
        {
            objEntityCustomer.CorpId = Convert.ToInt32(corporateId);
            objEntityCustomer.Organisation_Id = Convert.ToInt32(organisationId);
            objEntityCustomer.TermTemplateId = Convert.ToInt32(TermId);
        }

        DataTable dtTermDtl = new DataTable();

        dtTermDtl = objBusinessLayerCustomer.ReadSelectedTermDtl(objEntityCustomer);
        if (dtTermDtl.Rows.Count > 0)
        {
            objQtnTerms.strTermDescription = dtTermDtl.Rows[0]["TRTEMP_DESCRIPTION"].ToString();

        }
        return objQtnTerms;
    }
    public void LoadAccountGrp()
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
        objEntityLedger.ActModeId = Convert.ToInt32(clsCommonLibrary.ASMOD_ID.customer);
        //  objEntityLedger.ActModeId = 5;
        DataTable dtdiv = objBusinessLedger.ReadAccountGrps(objEntityLedger);
        // for (int i = 0; i < dtdiv.Rows.Count; i++)
        // {
        //if (dtdiv.Rows[i]["ACNT_GRP_NAME"].ToString().Trim() == "SALE")
        // {
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
        //}
        // }
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
        ddlTDS.Items.Clear();
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


        ddlTCS.Items.Clear();
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

        ddlCurrency.Items.Clear();
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
}