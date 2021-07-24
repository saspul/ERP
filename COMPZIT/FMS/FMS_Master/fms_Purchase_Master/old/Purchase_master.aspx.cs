using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit.BusineesLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using System.Data;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.IO;
using System.Web.Services;
using CL_Compzit;
using EL_Compzit;

using BL_Compzit;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using System.Web;

using System.Linq;


public partial class FMS_FMS_Master_Purchase_Matser_Purchase_master : System.Web.UI.Page
{
    public static int TaxEnable = 0;

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Request.QueryString["VId"] != null)
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
        cbxExtngSplr.Focus();
        if (!IsPostBack)
        {
            btnPRint.Visible = false;
            btnFloatPRint.Visible = false;
            HiddenDfltLdgr.Value = "0";
            HiddenDiscountEnableSts.Value = "0";
            int intUserId = 0, intUsrRolMstrId, intEnableDiscount = 0;
            clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
            clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            LoadCurrencies();
            CustomerLedgerLoad();
            CostCenterLoad();
            CostGroup1Load();
            CostGroup2Load();
            int intCorpId = 0;

            //  txtdate.Value =objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
            HiddenCurrentDate.Value = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
            LoadDfltLdgr();
            int intOrgId = 0;
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityPurchase.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityPurchase.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["USERID"] != null)
            {
                objEntityPurchase.UserId = Convert.ToInt32(Session["USERID"].ToString());
                intUserId = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_INVENTORY_FOREX_STATUS,
                                                           clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS,
                                                              clsCommonLibrary.CORP_GLOBAL.GN_REMOVE_RESTRCTNS_STS
                                                            ,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED,
                                                             clsCommonLibrary.CORP_GLOBAL.FMS_PRDT_DUPLICATION
                                                      
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);

            this.Form.Enctype = "multipart/form-data";
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                HiddenTaxEnable.Value = dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString();
                HiddenInventoryForex.Value = dtCorpDetail.Rows[0]["GN_INVENTORY_FOREX_STATUS"].ToString();
                HiddenCurrncyId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                HiddenRefAccountCls.Value = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
                HiddenRestritionStatus.Value = dtCorpDetail.Rows[0]["GN_REMOVE_RESTRCTNS_STS"].ToString();
                HiddenProductDupSts.Value = dtCorpDetail.Rows[0]["FMS_PRDT_DUPLICATION"].ToString();
                // 0-Duplication not allowed 1-Duplication allowed

            }

            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                if (dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString() != "")
                {
                    TaxEnable = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString());
                }
            }

            // for adding comma
            // clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                HiddenDefultCrncAbrvtn.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
            }


            //reference number
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_PURCHASE_MASTER);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);
           // objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PurchaseMaster);
            DataTable dtFormate = objBusinesspurchase.readRefFormate(objEntityCommon);

            string CurrentDate = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
            DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
            int DtYear = dtCurrentDate.Year;
            int DtMonth = dtCurrentDate.Month;
            string dtyy = dtCurrentDate.ToString("yy");
            string refFormatByDiv = "";
            string strRealFormat = "";
            if (dtFormate.Rows.Count > 0)
            {
                if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                {
                    refFormatByDiv = dtFormate.Rows[0]["REF_FORMATE"].ToString();
                    string strReferenceFormat = "";
                    strReferenceFormat = refFormatByDiv;


                    strRealFormat = refFormatByDiv.ToString();
                    if (strRealFormat.Contains("#ORG#"))
                    {
                        strRealFormat = strRealFormat.Replace("#ORG#", intOrgId.ToString());
                    }
                    if (strRealFormat.Contains("#COR#"))
                    {
                        strRealFormat = strRealFormat.Replace("#COR#", intCorpId.ToString());
                    }

                    if (strRealFormat.Contains("#USR#"))
                    {
                        strRealFormat = strRealFormat.Replace("#USR#", intUserId.ToString());
                    }
                    if (strRealFormat.Contains("#YER#"))
                    {
                        strRealFormat = strRealFormat.Replace("#YER#", DtYear.ToString());
                    }
                    if (strRealFormat.Contains("#YY#"))
                    {
                        strRealFormat = strRealFormat.Replace("#YY#", dtyy.ToString());
                    }
                    if (strRealFormat.Contains("#MON#"))
                    {
                        strRealFormat = strRealFormat.Replace("#MON#", DtMonth.ToString());

                    }
                    //strRealFormat = strRealFormat + "/" + strNextId;

                    if (strRealFormat.Contains("#NUM#"))
                    {
                        strRealFormat = strRealFormat.Replace("#NUM#", strNextId);
                    }
                    else
                    {
                        strRealFormat = strRealFormat + "/" + strNextId;
                    }
                    strRealFormat = strRealFormat.Replace("#", "");

                    txtRef.Text = strRealFormat;
                }
            }

            else
            {
                txtRef.Text = strNextId;
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
                else if (strInsUpd == "Reop")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopMsg", "SuccessReopMsg();", true);
                }
                    //0039
                else if (strInsUpd == "AlreadyReopen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyReopened", "AlreadyReopened();", true);
                }
                    //end


                else if (strInsUpd == "StsErr")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "StatusError", "StatusError();", true);
                }
                else if (strInsUpd == "ERROR")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
                }

            }

            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PurchaseMaster);
            int confirm = 0, intAccntCloseReopen = 0,intreopen=0;
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenAccountSpecificStatus.Value = "0";
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString())
                    {
                        intEnableDiscount = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenDiscountEnableSts.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        confirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldAcntCloseReopenSts.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intreopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                     //   HiddenReopenStatus.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        HiddenFieldAuditCloseReopenSts.Value = "1";
                    }
           
                }

            }
            //SUPPLIER
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Supplier);
            DataTable dtChildRol1 = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            if (dtChildRol1.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol1.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString())
                    {
                        HiddenAccountSpecificStatus.Value = "1";
                    }

                }
            }
            //END
            if (Session["FINCYRID"] != null)
            {
                objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntityCommon);

            int YearEndCls = 0;
            if (dtfinaclYear.Rows.Count > 0)
            {
                DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objEntityCommon);

                DataTable dtAuditClsDate = objBusinessLayer.ReadLastAuditClose(objEntityCommon);
                if (dtAuditClsDate.Rows.Count > 0 && dtAcntClsDate.Rows.Count > 0)
                {



                    HiddenAcntClsDate.Value = dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString();
                    YearEndCls = Convert.ToInt32(dtAcntClsDate.Rows[0]["ACCNT_CLS_YEAREND_STS"].ToString());

                    if (HiddenFieldAuditCloseReopenSts.Value == "1")
                    {
                        HiddenFincancialStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

                        if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            HiddenReopenStatus.Value = "1";
                        }
                        else
                        {
                            HiddenReopenStatus.Value = "0";

                        }
                    }
                    else
                    {
                        HiddenReopenStatus.Value = "0";
                        DateTime startDate =  DateTime.MinValue;
                        DateTime startDate1 = DateTime.MinValue;

                        if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "" && dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != null)
                        {
                            startDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                        }

                        if(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()!="")

                         startDate1 = objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());

                        if (startDate >= startDate1)
                        {


                            if (HiddenFieldAcntCloseReopenSts.Value != "1")
                            {
                                HiddenStartDate.Value = dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString();
                                HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                            }
                            else
                            {
                                HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                                HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                            }
                        }
                        else if (startDate < startDate1)
                        {
                            startDate = startDate1;
                            if (HiddenFieldAuditCloseReopenSts.Value != "1")
                            {

                                HiddenStartDate.Value = startDate1.AddDays(1).ToString("dd-MM-yyyy");
                                HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                            }
                            else
                            {
                                HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                                HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                            }
                        }

                        else if (startDate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {


                        }
                        else
                        {
                            HiddenStartDate.Value = startDate.AddDays(1).ToString("dd-MM-yyyy");
                            HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                        }
                    }

                    if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        HiddenReopenStatus.Value = "1";
                    }
                    else
                    {
                        HiddenReopenStatus.Value = "0";

                    }


                    DateTime curdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    string Ref = "";

                    if (curdate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        DateTime startDate = new DateTime();
                        
                            startDate = objCommon.textToDateTime(HiddenStartDate.Value);
                        
                        if (HiddenFieldAuditCloseReopenSts.Value=="1")
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {

                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                                clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
                                clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                                cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
                                clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                                objEntityAccnt.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAudit.FromDate = objCommon.textToDateTime(txtdate.Value);

                                objEntityPurchase.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityPurchase.CorpId = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntityPurchase.OrgId = intOrgId;
                                objEntityAudit.Corporate_id = intCorpId;
                                objEntityAudit.Organisation_id = intOrgId;
                                int SubRef = 1;

                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                                if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = objBusinesspurchase.ReadRefNumberByDate(objEntityPurchase);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != "" && dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != null)
                                        {
                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                                        }
                                        objEntityPurchase.AccountRef = strRef;
                                        DataTable dtRefFormat = objBusinesspurchase.ReadRefNumberByDateLast(objEntityPurchase);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["PURCHS_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != "" && dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString());
                                            }
                                            if (SubRef != 1)
                                            {
                                                Ref = Ref.TrimEnd('/');
                                                Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                            }
                                            else
                                            {
                                                Ref += "/";
                                            }
                                            Ref = Ref + "" + SubRef;
                                            txtRef.Text = Ref;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (dtAcntClsDate.Rows.Count > 0 && dtAuditClsDate.Rows.Count > 0)
                            {
                                if (objCommon.textToDateTime(HiddenStartDate.Value) < curdate)
                                {
                                    txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                                }
                                else
                                {
                                    txtdate.Value = HiddenStartDate.Value;
                                }
                            }


                            else
                            {
                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                            }



                           
                        }
                    }
                }

                else if (dtAuditClsDate.Rows.Count > 0)
                {



                  
                    if (HiddenFieldAuditCloseReopenSts.Value == "1")
                    {
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                        HiddenFincancialStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();

                        if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            HiddenReopenStatus.Value = "1";
                        }
                        else
                        {
                            HiddenReopenStatus.Value = "0";

                        }
                    }
                    else
                    {
                        HiddenReopenStatus.Value = "0";
                        DateTime startDate = DateTime.MinValue;
                        DateTime startDate1 = DateTime.MinValue;

                       
                        if (dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString() != "")

                            startDate = objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());

                        


                        if (startDate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {
                        }
                        else
                        {
                            HiddenStartDate.Value = startDate.AddDays(1).ToString("dd-MM-yyyy");
                            HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                        }
                    }

                    if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        HiddenReopenStatus.Value = "1";
                    }
                    else
                    {
                        HiddenReopenStatus.Value = "0";

                    }


                    DateTime curdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    string Ref = "";

                    if (curdate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        DateTime startDate = new DateTime();

                        startDate = objCommon.textToDateTime(HiddenStartDate.Value);

                        if (HiddenFieldAuditCloseReopenSts.Value == "1")
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {

                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                                clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
                                clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                                cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
                                clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                                objEntityAccnt.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAudit.FromDate = objCommon.textToDateTime(txtdate.Value);

                                objEntityPurchase.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityPurchase.CorpId = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntityPurchase.OrgId = intOrgId;
                                objEntityAudit.Corporate_id = intCorpId;
                                objEntityAudit.Organisation_id = intOrgId;
                                int SubRef = 1;

                               
                                DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                                if ( dtAuditCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = objBusinesspurchase.ReadRefNumberByDate(objEntityPurchase);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != "" && dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != null)
                                        {
                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                                        }
                                        objEntityPurchase.AccountRef = strRef;
                                        DataTable dtRefFormat = objBusinesspurchase.ReadRefNumberByDateLast(objEntityPurchase);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["PURCHS_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != "" && dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString());
                                            }
                                            if (SubRef != 1)
                                            {
                                                Ref = Ref.TrimEnd('/');
                                                Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                            }
                                            else
                                            {
                                                Ref += "/";
                                            }
                                            Ref = Ref + "" + SubRef;
                                            txtRef.Text = Ref;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if ( dtAuditClsDate.Rows.Count > 0)
                            {
                                if (objCommon.textToDateTime(HiddenStartDate.Value) < curdate)
                                {
                                    txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                                }
                                else
                                {
                                    txtdate.Value = HiddenStartDate.Value;
                                }
                            }


                            else
                            {
                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                            }




                        }
                    }
                }


                else  if (dtAcntClsDate.Rows.Count > 0)
                {


                    YearEndCls = Convert.ToInt32(dtAcntClsDate.Rows[0]["ACCNT_CLS_YEAREND_STS"].ToString());

                    if (YearEndCls == 1)
                    {
                        HiddenFieldAuditCloseReopenSts.Value = "0";
                        HiddenFieldAcntCloseReopenSts.Value = "0";
                    }

                    HiddenAcntClsDate.Value = dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString();
                    if (HiddenFieldAcntCloseReopenSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                    {
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                        HiddenFincancialStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();

                        if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            HiddenReopenStatus.Value = "1";
                        }
                        else
                        {
                            HiddenReopenStatus.Value = "0";

                        }
                    }
                    else
                    {
                        HiddenReopenStatus.Value = "0";
                        DateTime startDate = new DateTime();
                        if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "" && dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != null)
                        {
                            startDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                        }

                        if (startDate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {
                        }
                        else
                        {
                            HiddenStartDate.Value = startDate.AddDays(1).ToString("dd-MM-yyyy");
                            HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                        }
                    }

                    if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        HiddenReopenStatus.Value = "1";
                    }
                    else
                    {
                        HiddenReopenStatus.Value = "0";

                    }


                    DateTime curdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    string Ref = "";

                    if (curdate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        DateTime startDate = new DateTime();
                        if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "" && dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != null)
                        {
                            startDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                        }
                        if (HiddenFieldAcntCloseReopenSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {

                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                                clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
                                clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                                objEntityAccnt.FromDate = objCommon.textToDateTime(txtdate.Value);

                                objEntityPurchase.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityPurchase.CorpId = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntityPurchase.OrgId = intOrgId;
                                int SubRef = 1;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                if (dtAccntCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = objBusinesspurchase.ReadRefNumberByDate(objEntityPurchase);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != "" && dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != null)
                                        {
                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                                        }
                                        objEntityPurchase.AccountRef = strRef;
                                        DataTable dtRefFormat = objBusinesspurchase.ReadRefNumberByDateLast(objEntityPurchase);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["PURCHS_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != "" && dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString());
                                            }
                                            if (SubRef != 1)
                                            {
                                                Ref = Ref.TrimEnd('/');
                                                Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                            }
                                            else
                                            {
                                                Ref += "/";
                                            }
                                            Ref = Ref + "" + SubRef;
                                            txtRef.Text = Ref;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (dtAcntClsDate.Rows.Count > 0)
                            {
                                if (startDate < curdate)
                                {
                                    txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                                }
                            }
                            else
                            {
                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                            }
                        }
                    }
                }
                else
                {

                    if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        HiddenReopenStatus.Value = "1";
                    }
                    else
                    {
                        HiddenReopenStatus.Value = "0";

                    }

                    if (dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString() != "" && dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString() != "")
                    {
                        DateTime curntdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());

                        if (curntdate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curntdate < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {
                            txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                        }
                    }
                    HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    HiddenFincancialStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                }


            }

            if (confirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {
                btnConfirm.Visible = true;
                btnFloatConfirm.Visible = true;
            }
            else
            {
                btnConfirm.Visible = false;
                btnFloatConfirm.Visible = false;
            }

            btnClear.Visible = false;
            btnFloatClear.Visible = false;

            //when editing 
            if (Request.QueryString["Id"] != null && Request.QueryString["Id"] !="")
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                HiddenPurchaseId1.Value = strRandomMixedId;
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenPurchaseid.Value = strId;
                Update(strId, "UPDATE", confirm, intreopen, YearEndCls);
                lblEntry.Text = "Edit Purchase";
                btnClear.Visible = false;
                btnFloatClear.Visible = false;
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
            }

            //when  viewing
            else if (Request.QueryString["ViewId"] != null && Request.QueryString["ViewId"] != "")
            {
                spandate.Attributes["style"] = "pointer-events:none;";
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                HiddenPurchaseId1.Value = strRandomMixedId;
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
                HiddenPurchaseid.Value = strId;
                btnClear.Visible = false;
                btnFloatClear.Visible = false;
                Update(strId, "VIEW", confirm, intreopen, YearEndCls);
                lblEntry.Text = "View Purchase";
                
            }

            else
            {
                lblEntry.Text = "Add Purchase";
                HiddenPurchaseId1.Value = "";
                HiddenPurchaseid.Value = "";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnFloatUpdate.Visible = false;
                btnFloatUpdateClose.Visible = false;
                btnConfirm.Visible = false;
                btnFloatConfirm.Visible = false;
                btnAdd.Visible = true;
                btnAddClose.Visible = true;
                btnFloatAdd.Visible = true;
                btnFloatAddClose.Visible = true;
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
                btnClear.Visible = true;
                btnFloatClear.Visible = true;
            }

        }

    }


    public void LoadDfltLdgr()
    {
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPurchase.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPurchase.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntityPurchase.ActModeId = Convert.ToInt32(clsCommonLibrary.ASMOD_ID.supplier);
        DataTable dtdiv = objBusinesspurchase.ReadDefultLdgr(objEntityPurchase);
        if (dtdiv.Rows.Count > 0)
        {
            HiddenDfltLdgr.Value = dtdiv.Rows[0]["LDGR_ID"].ToString();
            HiddenDefaultLdgrSts.Value = "0";
        }
        else
        {
            HiddenDefaultLdgrSts.Value = "1";
        }
        objEntityPurchase.ActModeId = Convert.ToInt32(clsCommonLibrary.ASMOD_ID.purchase);
        DataTable dtProduct = objBusinesspurchase.ReadDefultLdgr(objEntityPurchase);
        if (dtProduct.Rows.Count > 0)
        {
            HiddenDfltProductLdgr.Value = dtProduct.Rows[0]["LDGR_ID"].ToString();
        }
    }

    public void CustomerLedgerLoad()
    {
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPurchase.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPurchase.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.SUNDRYCREDITR));
        DataTable dtDivision = objBusiness.ReadLedgers(objEntityCommon);
       // DataTable dtDivision = objBusinesspurchase.ReadCustomerLdger(objEntityPurchase);
        if (dtDivision.Rows.Count > 0)
        {
            ddlCustomerLdgr.Items.Clear();

            ddlCustomerLdgr.DataSource = dtDivision;
            ddlCustomerLdgr.DataTextField = "LDGR_NAME";
            ddlCustomerLdgr.DataValueField = "LDGR_ID";
            ddlCustomerLdgr.DataBind();

        }
        ddlCustomerLdgr.Items.Insert(0, "--SELECT SUPPLIER --");
        if (dtDivision.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SundryDebtorSelect", "SundryDebtorSelect();", true);
        }
    }


    [WebMethod]
    public static string DropdownTaxBind(string strOrgId, string strCorpId, string Product)
    {
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();

        if (strOrgId != "")
        {
            objEntityPurchase.OrgId = Convert.ToInt32(strOrgId);
        }
        if (strCorpId != "")
        {
            objEntityPurchase.CorpId = Convert.ToInt32(strCorpId);
        }
        if (Product != "" && Product !="--SELECT PRODUCT--")
        {
            objEntityPurchase.ProductId = Convert.ToInt32(Product);
        }
        DataTable dtSubConrt = objBusinesspurchase.ReadProductTax(objEntityPurchase);
        dtSubConrt.TableName = "dtTableLoadTax";

        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtSubConrt.WriteXml(sw);
            result = sw.ToString();
        }

        return result;
    }
    public void Update(string strId, string mode, int confirm, int reopen, int YearEndCls)
    {
        btnAdd.Visible = false;
        btnAddClose.Visible = false;
        btnFloatAdd.Visible = false;
        btnFloatAddClose.Visible = false;
        btnConfirm.Visible = true;
        btnFloatConfirm.Visible = true;
        CustomerLedgerLoad();
        LoadCurrencies();

     //   BankCachLedgerLoad();
        HiddenView.Value = "0";
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommn=new clsCommonLibrary();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        objEntityPurchase.PurchaseId = Convert.ToInt32(strId);

        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityPurchase.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityPurchase.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtPurchase = objBusinesspurchase.ReadPurchaseById(objEntityPurchase);
        if (dtPurchase.Rows.Count > 0)
        {
            if (dtPurchase.Rows[0]["PURCHS_CNCL_USR_ID"].ToString() != "")
            {
                btnPRint.Visible = false;
                btnFloatPRint.Visible = false;
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
            }
            else
            {

                txtRef.Text = dtPurchase.Rows[0]["PURCHS_REF"].ToString();
                HiddenUpdRefNum.Value = dtPurchase.Rows[0]["PURCHS_REF"].ToString();
                txtdate.Value = dtPurchase.Rows[0]["PURCHS_DATE"].ToString();
                HiddenUpdatedDate.Value = dtPurchase.Rows[0]["PURCHS_DATE"].ToString();
                ddlCurrency.ClearSelection();

                ddlCustomerLdgr.ClearSelection();

                if (dtPurchase.Rows[0]["PURCHS_ATTACHMNT_STATUS"].ToString() == "1")
                {
                    cbxAttachment.Checked = true;
                }
                else
                {
                    cbxAttachment.Checked = false;
                }
                if (dtPurchase.Rows[0]["PURCH_SUP_TYP"].ToString() == "0")
                {
                    cbxExtngSplr.Checked = true;

                    if (ddlCustomerLdgr.Items.FindByValue(dtPurchase.Rows[0]["LDGR_ID"].ToString()) != null)
                    {
                        ddlCustomerLdgr.Items.FindByValue(dtPurchase.Rows[0]["LDGR_ID"].ToString()).Selected = true;
                        objEntityPurchase.LedgerCustomer = Convert.ToInt32(dtPurchase.Rows[0]["LDGR_ID"].ToString());
                    }
                    else
                    {
                        System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dtPurchase.Rows[0]["SUPPLIER"].ToString(), dtPurchase.Rows[0]["LDGR_ID"].ToString());
                        ddlCustomerLdgr.Items.Insert(1, lstGrp);
                        SortDDL(ref this.ddlCustomerLdgr);
                        ddlCustomerLdgr.Items.FindByValue(dtPurchase.Rows[0]["LDGR_ID"].ToString()).Selected = true;
                        objEntityPurchase.LedgerCustomer = Convert.ToInt32(dtPurchase.Rows[0]["LDGR_ID"].ToString());
                    }

                }

                else
                {
                    cbxExtngSplr.Checked = false;
                    if (dtPurchase.Rows[0]["PURCH_SUP_NAME"].ToString() != "")
                    {
                        txtsplrName.Text = dtPurchase.Rows[0]["PURCH_SUP_NAME"].ToString();
                    }

                    if (dtPurchase.Rows[0]["PURCH_SUP_ADD_ONE"].ToString() != "")
                    {
                        txtAddress1.Text = dtPurchase.Rows[0]["PURCH_SUP_ADD_ONE"].ToString();
                    }
                    if (dtPurchase.Rows[0]["PURCH_SUP_ADD_TWO"].ToString() != "")
                    {
                        txtAddress2.Text = dtPurchase.Rows[0]["PURCH_SUP_ADD_TWO"].ToString();
                    }
                    if (dtPurchase.Rows[0]["PURCH_SUP_ADD_THREE"].ToString() != "")
                    {
                        txtAddress3.Text = dtPurchase.Rows[0]["PURCH_SUP_ADD_THREE"].ToString();
                    }
                    if (dtPurchase.Rows[0]["PURCH_SUP_CONTACT_NO"].ToString() != "")
                    {
                        txtContactNumber.Text = dtPurchase.Rows[0]["PURCH_SUP_CONTACT_NO"].ToString();
                    }
                }

                if (dtPurchase.Rows[0]["CRNCMST_ID"].ToString() != "")
                {
                    ddlCurrency.Items.FindByValue(dtPurchase.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }

                else
                {
                    System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dtPurchase.Rows[0]["CRNCMST_NAME"].ToString(), dtPurchase.Rows[0]["CRNCMST_ID"].ToString());
                    ddlCurrency.Items.Insert(1, lstGrp);
                    SortDDL(ref this.ddlCurrency);
                    ddlCurrency.Items.FindByValue(dtPurchase.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }
                if (dtPurchase.Rows[0]["PURCHS_EXCHNG_RATE"].ToString() != "")
                {
                    string NetAmountWithCommaFrm = "";
                    NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(dtPurchase.Rows[0]["PURCHS_EXCHNG_RATE"].ToString(), objEntityCommon);
                    txtExchangeRate.Text = NetAmountWithCommaFrm;
                }
                if (dtPurchase.Rows[0]["PURCHS_REF_SEQNUM"].ToString() != "")
                {
                    hiddenRefSequence.Value = dtPurchase.Rows[0]["PURCHS_REF_SEQNUM"].ToString();
                }
                if (dtPurchase.Rows[0]["PURCHS_RECEIPTNO"].ToString() != "")
                {
                    txtReceipt.Text = dtPurchase.Rows[0]["PURCHS_RECEIPTNO"].ToString();
                }
                if (dtPurchase.Rows[0]["PURCHS_ORDERNO"].ToString() != "")
                {
                    txtOrder.Text = dtPurchase.Rows[0]["PURCHS_ORDERNO"].ToString();
                }
                if (dtPurchase.Rows[0]["PURCHS_DESCRIPTION"].ToString() != "")
                {
                    txtDesc.Value = dtPurchase.Rows[0]["PURCHS_DESCRIPTION"].ToString();
                }
                if (dtPurchase.Rows[0]["PURCHS_TERMS"].ToString() != "")
                {
                    txtTerms.Value = dtPurchase.Rows[0]["PURCHS_TERMS"].ToString();
                }
                if (dtPurchase.Rows[0]["PURCHS_STATUS"].ToString() == "0")
                {
                    ChkStatus.Checked = false;
                    btnFloatConfirm.Visible = false;
                    btnConfirm.Visible = false;
                }
                else if (dtPurchase.Rows[0]["PURCHS_STATUS"].ToString() == "1")
                {
                    ChkStatus.Checked = true;
                }
                if (dtPurchase.Rows[0]["PURCHS_GROSS_TOTAL"].ToString() != "")
                {
                    txtGrossTotal.InnerHtml = dtPurchase.Rows[0]["PURCHS_GROSS_TOTAL"].ToString() + " " + dtPurchase.Rows[0]["CRNCMST_ABBRV"].ToString();
                    HiddenGrossAmt.Value = dtPurchase.Rows[0]["PURCHS_GROSS_TOTAL"].ToString();
                }
                if (dtPurchase.Rows[0]["PURCHS_TAX_TOTAL"].ToString() != "")
                {
                    txtTaxTotal.InnerHtml = dtPurchase.Rows[0]["PURCHS_TAX_TOTAL"].ToString() + " " + dtPurchase.Rows[0]["CRNCMST_ABBRV"].ToString();
                    HiddenTax.Value = dtPurchase.Rows[0]["PURCHS_TAX_TOTAL"].ToString();
                }

                if (dtPurchase.Rows[0]["PURCHS_TOTAL_EXCNG"].ToString() != "")
                {
                    string NetAmountWithCommaFrm = "";
                    NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(dtPurchase.Rows[0]["PURCHS_TOTAL_EXCNG"].ToString(), objEntityCommon);
                    txtTotalWithExchngRate.Text = NetAmountWithCommaFrm + " " + dtPurchase.Rows[0]["CRNCMST_ABBRV"].ToString();
                    HiddenTotal_Exchng.Value = dtPurchase.Rows[0]["PURCHS_TOTAL_EXCNG"].ToString();
                }
                if (dtPurchase.Rows[0]["PURCHS_DISCOUNT"].ToString() != "")
                {
                    txtDiscountTotal.Text = dtPurchase.Rows[0]["PURCHS_DISCOUNT"].ToString() + " " + dtPurchase.Rows[0]["CRNCMST_ABBRV"].ToString();

                    Hiddendiscount.Value = dtPurchase.Rows[0]["PURCHS_DISCOUNT"].ToString();
                }
                if (dtPurchase.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
                {
                    txtNetTotal.Text = dtPurchase.Rows[0]["PURCHS_NET_TOTAL"].ToString() + " " + dtPurchase.Rows[0]["CRNCMST_ABBRV"].ToString();
                    HiddenNetAmt.Value = dtPurchase.Rows[0]["PURCHS_NET_TOTAL"].ToString();
                }
                if (dtPurchase.Rows[0]["PURCHS_CNFRM_STS"].ToString() == "1")
                {
                    btnPRint.Visible = true;
                    btnFloatPRint.Visible = true;
                }

                else
                {
                    btnPRint.Text = "Draft Print";
                    btnFloatPRint.Text = "Draft Print";
                }
                int AcntCloseSts = AccountCloseCheck(dtPurchase.Rows[0]["PURCHS_DATE"].ToString());
                int AuditCloseSts = AuditCloseCheck(dtPurchase.Rows[0]["PURCHS_DATE"].ToString());
                btnPRint.Visible = true;
                btnFloatPRint.Visible = true;


                if (dtPurchase.Rows[0]["CNT_SETTLE"].ToString() == "0")
                {
                    if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
                    {
                        btnReopen.Visible = true;
                        btnFloatReopen.Visible = true;
                    }
                    else if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
                    {
                        btnReopen.Visible = false;
                        btnFloatReopen.Visible = false;
                    }
                    else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value == "1")
                    {
                        btnReopen.Visible = true;
                        btnFloatReopen.Visible = true;
                    }
                    else if (AcntCloseSts == 0 && AuditCloseSts == 0)
                    {
                        btnReopen.Visible = true;
                        btnFloatReopen.Visible = true;
                    }

                }
                else
                {
                    btnReopen.Visible = false;
                    btnFloatReopen.Visible = false;
                }

                if (dtPurchase.Rows[0]["PURCHS_CNFRM_STS"].ToString() == "1")
                {
                  
                    HiddenView.Value = "1";
                    btnConfirm.Visible = false;
                    btnFloatConfirm.Visible = false;
                    txtdate.Disabled = true;
                    ddlCurrency.Enabled = false;
                    txtExchangeRate.Enabled = false;
                    ddlCustomerLdgr.Enabled = false;
                    txtOrder.Enabled = false;
                    txtReceipt.Enabled = false;
                    txtRef.Enabled = false;
                    txtContactNumber.Enabled = false;
                    ChkStatus.Disabled = true;
                    cbxAttachment.Disabled = true;
                    btnUpdate.Visible = false;
                    btnUpdateClose.Visible = false;
                    btnFloatUpdate.Visible = false;
                    btnFloatUpdateClose.Visible = false;
                    divEmployeeTable.Disabled = true;
                    btnClear.Visible = false;
                    btnFloatClear.Visible = false;
                    decimal CreditPeriod = 0;
                    decimal CreditAmt = 0;
                    decimal PurchaseAmt = 0;
                    decimal PaymentAmt = 0;
                    cbxAttachment.Disabled = true;
                    cbxExtngSplr.Disabled = true;
                    txtsplrName.Enabled = false;
                    txtAddress1.Enabled = false;
                    txtAddress2.Enabled = false;
                    txtAddress3.Enabled = false;

                    txtTerms.Disabled = true;
                    txtDesc.Disabled = true;
                    DateTime DatePurchase = new DateTime();
                    string dtNowDate = objBusiness.LoadCurrentDate().ToString("dd-MM-yyyy");
                    DateTime dttoday = objCommn.textToDateTime(dtNowDate);
                    DataTable dtCredits = objBusinesspurchase.ReadSupplierCredits(objEntityPurchase);
                    if (dtCredits.Rows.Count > 0)
                    {
                        if (dtCredits.Rows[0]["SUPLIR_CR_LIMIT"].ToString() != "")
                        {
                            CreditAmt = Convert.ToDecimal(dtCredits.Rows[0]["SUPLIR_CR_LIMIT"].ToString());
                        }
                        if (dtCredits.Rows[0]["SUPLIR_CR_PRD"].ToString() != "")
                        {
                            CreditPeriod = Convert.ToDecimal(dtCredits.Rows[0]["SUPLIR_CR_PRD"].ToString());
                        }
                        if (dtCredits.Rows[0]["PURCHS_PAID_AMT"].ToString() != "")
                        {
                            PaymentAmt = Convert.ToDecimal(dtCredits.Rows[0]["PURCHS_PAID_AMT"].ToString());
                        }
                        if (dtCredits.Rows[0]["PURCHS_UPD_DATE"].ToString() != "")
                        {
                            DatePurchase = objCommn.textToDateTime(dtCredits.Rows[0]["PURCHS_UPD_DATE"].ToString());
                            objEntityPurchase.AccountDate = objCommn.textToDateTime(dtCredits.Rows[0]["PURCHS_UPD_DATE"].ToString());
                        }
                        int DiffDate = Convert.ToInt32((dttoday - DatePurchase).TotalDays);
                        if (dtPurchase.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
                        {
                            PurchaseAmt = Convert.ToDecimal(dtPurchase.Rows[0]["PURCHS_NET_TOTAL"].ToString());
                        }
                        if (CreditAmt < PurchaseAmt)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "CreditLimtAlert", "CreditLimtAlert();", true);
                        }
                        else if (DiffDate > CreditPeriod)
                        {
                            decimal balAmt = PaymentAmt - PurchaseAmt;
                            if (PaymentAmt < PurchaseAmt)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "CreditPeriodAlert", "CreditPeriodAlert();", true);
                            }
                        }
                    }


                }
            }
        }
    

        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("PURCHSE_ID", typeof(int));
        dtDetail.Columns.Add("PRODUCT_ID", typeof(int));
        dtDetail.Columns.Add("PRODUCTROW", typeof(string));
        dtDetail.Columns.Add("SLNO", typeof(int));
        dtDetail.Columns.Add("QUANTITY", typeof(string));
        dtDetail.Columns.Add("RATE", typeof(string));
        dtDetail.Columns.Add("DISPER", typeof(string));
        dtDetail.Columns.Add("DISAMT", typeof(string));
        dtDetail.Columns.Add("TAX", typeof(string));
        dtDetail.Columns.Add("TAXTEXT", typeof(string));
        dtDetail.Columns.Add("TAXAMT", typeof(string));
        dtDetail.Columns.Add("PRICE", typeof(string));
        dtDetail.Columns.Add("TAXPERCENTAGE", typeof(string));
        dtDetail.Columns.Add("PRODUCT_NAME", typeof(string));
        dtDetail.Columns.Add("PRDCT_CHCK", typeof(string));
        dtDetail.Columns.Add("PURCHS_PRDUCT_REMARK", typeof(string));
        dtDetail.Columns.Add("COSTCENTRE", typeof(string));

        DataTable dtProduct = objBusinesspurchase.ReadProductPurchaseById(objEntityPurchase);

        for (int intcnt = 0; intcnt < dtProduct.Rows.Count; intcnt++)
        {
            DataRow drDtl = dtDetail.NewRow();
            drDtl["PURCHSE_ID"] = Convert.ToInt32(dtProduct.Rows[intcnt]["PURCHS_ID"].ToString());
            drDtl["PRODUCT_ID"] = Convert.ToInt32(dtProduct.Rows[intcnt]["PRDT_ID"].ToString());
            drDtl["PRODUCTROW"] = dtProduct.Rows[intcnt]["PURCHS_PRDUCT_ID"].ToString();
            drDtl["SLNO"] = dtProduct.Rows[intcnt]["PURCHS_PRDUCT_SLNO"].ToString();
            objEntityPurchase.ProductId = Convert.ToInt32(dtProduct.Rows[intcnt]["PURCHS_PRDUCT_ID"].ToString());
            drDtl["COSTCENTRE"] = "";
            DataTable dtCCDtls = objBusinesspurchase.ReadPurchaseCCDetails(objEntityPurchase);
            for (int intCountinn = 0; intCountinn < dtCCDtls.Rows.Count; intCountinn++)
            {
                if (intCountinn == 0)
                {
                    if (dtCCDtls.Rows[0]["COSTCNTR_ID"].ToString() != "")
                        drDtl["COSTCENTRE"] = dtCCDtls.Rows[intCountinn]["COSTCNTR_ID"].ToString() + "%" + dtCCDtls.Rows[intCountinn]["CC_SALE_AMT"].ToString() + "%" + dtCCDtls.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString() + "%" + dtCCDtls.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString();
                }
                else
                    drDtl["COSTCENTRE"] = drDtl["COSTCENTRE"] + "$" + dtCCDtls.Rows[intCountinn]["COSTCNTR_ID"].ToString() + "%" + dtCCDtls.Rows[intCountinn]["CC_SALE_AMT"].ToString() + "%" + dtCCDtls.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString() + "%" + dtCCDtls.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString();
            }

            drDtl["QUANTITY"] = Convert.ToDecimal(dtProduct.Rows[intcnt]["PURCHS_PRDUCT_QTY"].ToString());
                if (dtProduct.Rows[intcnt]["PURCHS_PRDUCT_RATE"].ToString() != "")
                {
                    drDtl["RATE"] = dtProduct.Rows[intcnt]["PURCHS_PRDUCT_RATE"].ToString();
                }
                if (dtProduct.Rows[intcnt]["PURCHS_PRDUCT_DISCNT"].ToString() != "" && dtProduct.Rows[intcnt]["PURCHS_PRDUCT_DISCNT"].ToString() != null)
                {
                    drDtl["DISPER"] = dtProduct.Rows[intcnt]["PURCHS_PRDUCT_DISCNT"].ToString();
                }
                if (dtProduct.Rows[intcnt]["PURCHS_PRDUCT_RATE"].ToString() != "" && dtProduct.Rows[intcnt]["PURCHS_PRDUCT_RATE"].ToString() != null)
                {
                    drDtl["DISAMT"] = dtProduct.Rows[intcnt]["PURCHS_PRDUCT_DISCNT_AMT"].ToString();
                }
                if (dtProduct.Rows[intcnt]["PURCHS_PRDUCT_TAX_AMT"].ToString() != "" && dtProduct.Rows[intcnt]["PURCHS_PRDUCT_TAX_AMT"].ToString() != null)
                {
                    drDtl["TAXAMT"] = dtProduct.Rows[intcnt]["PURCHS_PRDUCT_TAX_AMT"].ToString();
                }
                drDtl["PRICE"] = dtProduct.Rows[intcnt]["PURCHS_PRDUCT_PRICE"].ToString();
                if (dtProduct.Rows[intcnt]["TAX_ID"].ToString() != "" && dtProduct.Rows[intcnt]["TAX_ID"].ToString() != null)
                {
                    drDtl["TAX"] = dtProduct.Rows[intcnt]["TAX_ID"].ToString();
                }

                if (dtProduct.Rows[intcnt]["TAX_NAME"].ToString() != "" && dtProduct.Rows[intcnt]["TAX_NAME"].ToString() != null)
                {
                    drDtl["TAXTEXT"] = dtProduct.Rows[intcnt]["TAX_NAME"].ToString();
                }
                if (dtProduct.Rows[intcnt]["TAX_PERCENTAGE"].ToString() != "")
                {
                    drDtl["TAXPERCENTAGE"] = dtProduct.Rows[intcnt]["TAX_PERCENTAGE"].ToString();
                }
                else
                {
                    drDtl["TAXPERCENTAGE"] = "";
                }
                if (dtProduct.Rows[intcnt]["PRDT_NAME"].ToString() != "")
                {
                    drDtl["PRODUCT_NAME"] = dtProduct.Rows[intcnt]["PRDT_NAME"].ToString();
                }
                else
                {
                    drDtl["PRODUCT_NAME"] = "";
                }
                if (dtProduct.Rows[intcnt]["PRDT_STATUS"].ToString() != "")
                {
                    drDtl["PRDCT_CHCK"] = dtProduct.Rows[intcnt]["PRDT_STATUS"].ToString();
                }
                if (dtProduct.Rows[intcnt]["PURCHS_PRDUCT_REMARK"].ToString() != "")
                {
                    drDtl["PURCHS_PRDUCT_REMARK"] = dtProduct.Rows[intcnt]["PURCHS_PRDUCT_REMARK"].ToString();
                }
            dtDetail.Rows.Add(drDtl);
        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenEdit.Value = strJson;

        DataTable dtDetail1 = new DataTable();
        dtDetail1.Columns.Add("PURCHSE_ID", typeof(int));
        dtDetail1.Columns.Add("ATTACH_ID", typeof(int));
        dtDetail1.Columns.Add("FIMENAME", typeof(string));
        dtDetail1.Columns.Add("ACT_FILENAME", typeof(string));

        DataTable dtAttahmentDtls=objBusinesspurchase.ReadAttachmentById(objEntityPurchase);
        for (int intcnt = 0; intcnt < dtAttahmentDtls.Rows.Count; intcnt++)
        {
            DataRow drDtl = dtDetail1.NewRow();
            drDtl["PURCHSE_ID"] = Convert.ToInt32(dtAttahmentDtls.Rows[intcnt]["PURCHS_ID"].ToString());
            drDtl["ATTACH_ID"] = Convert.ToInt32(dtAttahmentDtls.Rows[intcnt]["PURCHS_ATCHMNT_ID"].ToString());
            drDtl["FIMENAME"] = dtAttahmentDtls.Rows[intcnt]["PURCHS_FILE_NAME"].ToString();
            drDtl["ACT_FILENAME"] = dtAttahmentDtls.Rows[intcnt]["PURCHS_ACT_FILE_NAME"].ToString();
            dtDetail1.Rows.Add(drDtl);

        }
        hiddenFilePath.Value= objCommn.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_ATTACHMENT);
        string strJson1 = DataTableToJSONWithJavaScriptSerializer(dtDetail1);
        HiddenEditAttachment.Value = strJson1;
        if (mode == "VIEW")
        {
            txtContactNumber.Enabled = false;
            HiddenView.Value = "1";
           btnConfirm.Visible = false;
           btnFloatConfirm.Visible = false;
            txtdate.Disabled = true;
            ddlCustomerLdgr.Enabled = false;
            txtExchangeRate.Enabled = false;
            ddlCurrency.Enabled = false;
            txtOrder.Enabled = false;
            txtReceipt.Enabled = false;
            txtRef.Enabled = false;
            ChkStatus.Disabled = true;
            cbxAttachment.Disabled = true;
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;
            btnFloatUpdate.Visible = false;
            btnFloatUpdateClose.Visible = false;
            divEmployeeTable.Disabled = true;
            btnClear.Visible = false;
            btnFloatClear.Visible = false;
            cbxExtngSplr.Disabled = true;
            txtsplrName.Enabled = false;
            txtAddress1.Enabled = false;
            txtAddress2.Enabled = false;
            txtAddress3.Enabled = false;
            txtTerms.Disabled = true;
            txtDesc.Disabled = true;
             
        }

        if (Request.QueryString["VId"] != null)
        {
            divList.Visible = false;
            btnCancel.Visible = false;
            btnFloatCancel.Visible = false;
            btnReopen.Visible = false;
            btnFloatReopen.Visible = false;
        }

        if (YearEndCls == 1)
        {
            btnReopen.Visible = false;
            btnFloatReopen.Visible = false;
        }

    }
    public int AuditCloseCheck(string strDate)
    {
        int sts = 0;
        cls_Business_Audit_Closeing objEmpAccntCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAccnt = new clsEntityLayerAuditClosing();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(strDate);
        DataTable dtAccntCls = objEmpAccntCls.CheckAuditClosingDate(objEntityAccnt);
        if (dtAccntCls.Rows.Count > 0)
        {
            sts = 1;
        }
        return sts;
    }
    public int AccountCloseCheck(string strDate)
    {
        int sts = 0;
        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(strDate);
        DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
        if (dtAccntCls.Rows.Count > 0)
        {
            sts = 1;
        }
        return sts;
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        List<clsEntityPurchaseMaster_list> ObjEntityPurchaseList_Insert = new List<clsEntityPurchaseMaster_list>();
        List<clsEntityPurchaseMaster_list> ObjEntityPurchaseList_Update = new List<clsEntityPurchaseMaster_list>();
        List<clsEntityPurchaseMaster_list> ObjEntityPurchaseList_Delete = new List<clsEntityPurchaseMaster_list>();
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityPurchase.PurchaseId = Convert.ToInt32(strId);
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPurchase.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPurchase.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPurchase.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (txtRef.Text != "")
        {
            objEntityPurchase.AccountRef = txtRef.Text.Trim();
        }
        if (txtDesc.Value != "")
        {
            objEntityPurchase.Description = txtDesc.Value.Trim();
        }
        if (txtTerms.Value != "")
        {
            objEntityPurchase.Terms = txtTerms.Value.Trim();
        }
        if (hiddenRefSequence.Value != "")
        {
            objEntityPurchase.SequenceRef =Convert.ToInt32(hiddenRefSequence.Value);
        }
        objEntityPurchase.AccountDate = objCommon.textToDateTime(txtdate.Value);
        if (HiddenUpdatedDate.Value != "")
        {
            objEntityPurchase.PurchaseDateInUpd = objCommon.textToDateTime(HiddenUpdatedDate.Value);
        }
        if (cbxAttachment.Checked == true)
        {
            objEntityPurchase.AttachmentStatus = 1;
        }
        else
        {
            objEntityPurchase.AttachmentStatus = 0;
        }
        if (cbxExtngSplr.Checked == true)
        {
            objEntityPurchase.ExistingSplrsts = 0;
            if (ddlCustomerLdgr.SelectedItem.Value != "--SELECT SUPPLIER --")
            {
                objEntityPurchase.LedgerCustomer = Convert.ToInt32(ddlCustomerLdgr.SelectedItem.Value);
            }
        }
        else
        {
            objEntityPurchase.LedgerCustomer = Convert.ToInt32(HiddenDfltLdgr.Value);
            objEntityPurchase.ExistingSplrsts = 1;
            if (txtsplrName.Text.Trim() != "")
            {
                objEntityPurchase.SplrName = txtsplrName.Text;
            }
            if (txtAddress1.Text.Trim() != "")
            {
                objEntityPurchase.AddressOne = txtAddress1.Text;
            }
            if (txtAddress2.Text.Trim() != "")
            {
                objEntityPurchase.AddressTwo = txtAddress2.Text;
            }
            if (txtAddress3.Text.Trim() != "")
            {
                objEntityPurchase.AddressThree = txtAddress3.Text;
            }
            if (txtContactNumber.Text.Trim() != "")
            {
                objEntityPurchase.ContactNumber = txtContactNumber.Text;
            }
        }
        if (txtReceipt.Text != "")
        {
            objEntityPurchase.ReceiptNo = txtReceipt.Text.Trim();
        }
        if (txtOrder.Text != "")
        {
            objEntityPurchase.OrderNo = txtOrder.Text.Trim();
        }

        if (ChkStatus.Checked)
        {
            objEntityPurchase.AccountStatus = 1;
        }
        else
        {
            objEntityPurchase.AccountStatus = 0;

        }
        if (Hiddendiscount.Value != "")
        {
            string[] dis = Hiddendiscount.Value.Split(' ');
            objEntityPurchase.DiscountTotal = Convert.ToDecimal(dis[0]);
        }
        if (HiddenGrossAmt.Value != "")
        {
            string[] dis = HiddenGrossAmt.Value.Split(' ');
            objEntityPurchase.GrossAmount = Convert.ToDecimal(dis[0]);
        }
        //if (HiddenNetAmt.Value != "")
        //{
        //    string[] dis = HiddenNetAmt.Value.Split(' ');
        //    objEntityPurchase.NetAmount = Convert.ToDecimal(dis[0]);
        //    objEntityPurchase.BalanceAmount = Convert.ToDecimal(dis[0]);

        //}
        //if (HiddenTotal_Exchng.Value != "")
        //{
        //    string[] dis = HiddenTotal_Exchng.Value.Split(' ');
        //    objEntityPurchase.TotalExchangeRate = Convert.ToDecimal(dis[0]);
        //}

        if (HiddenCurrncyId.Value != ddlCurrency.SelectedItem.Value)
        {

            string[] dis = txtNetTotal.Text.Split(' ');
            //HiddenTotal_Exchng.Value.Split(' ');

            objEntityPurchase.TotalExchangeRate = Convert.ToDecimal(dis[0]);
            decimal exchangRt = Convert.ToDecimal(txtExchangeRate.Text);

            decimal Amt = Convert.ToDecimal(dis[0]);

            objEntityPurchase.NetAmount = Amt * exchangRt;
            objEntityPurchase.BalanceAmount = Amt * exchangRt;

        }
        else
        {
            string[] dis = txtNetTotal.Text.Split(' ');
            objEntityPurchase.NetAmount = Convert.ToDecimal(dis[0]);
            objEntityPurchase.BalanceAmount = Convert.ToDecimal(dis[0]);

        }
        if (HiddenTaxEnable.Value == "1")
        {
            if (HiddenTax.Value != "")
            {
                string[] dis = HiddenTax.Value.Split(' ');
                objEntityPurchase.TaxTotal = Convert.ToDecimal(dis[0]);
            }
        }
        if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
        {
            objEntityPurchase.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            if (objEntityPurchase.CurrencyId !=Convert.ToInt32( hiddenDfltCurrencyMstrId.Value))
            {
                if (txtExchangeRate.Text != "")
                {
                    string ExchangeRate = txtExchangeRate.Text;
                    ExchangeRate = ExchangeRate.Replace(",", "");
                    objEntityPurchase.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Text);
                }
            }
        }
        //start file upload
        List<clsEntityPurchaseMaster> objEntityDeleteAttchmntList = new List<clsEntityPurchaseMaster>();
        List<clsEntityPurchaseMaster> objEntityAttahmentList = new List<clsEntityPurchaseMaster>();

        if (cbxAttachment.Checked == true)
        {
            string jsonData1 = HiddenUploadInfo.Value;
            string c1 = jsonData1.Replace("\"{", "\\{");
            string d1 = c1.Replace("\\n", "\r\n");
            string g1 = d1.Replace("\\", "");
            string h1 = g1.Replace("}\"]", "}]");
            string i1 = h1.Replace("}\",", "},");

            List<clsFileUploadData> objTVDataList = new List<clsFileUploadData>();
            objTVDataList = JsonConvert.DeserializeObject<List<clsFileUploadData>>(i1);


            if (HiddenUploadInfo.Value != "" && HiddenUploadInfo.Value != null)
            {

                for (int count = 0; count < objTVDataList.Count; count++)
                {
                    string jsonFileid = "file" + objTVDataList[count].ROWID;
                    for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                    {

                        string fileId = Request.Files.AllKeys[intCount].ToString();
                        HttpPostedFile PostedFile = Request.Files[intCount];
                        if (fileId == jsonFileid)
                        {
                            if (PostedFile.ContentLength > 0)
                            {
                                clsEntityPurchaseMaster objEntityRnwlDetailsAttchmnt = new clsEntityPurchaseMaster();
                                string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                objEntityRnwlDetailsAttchmnt.ActualFileName = strFileName;
                                string strFileExt;

                                strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();


                                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_ATTACHMENT);
                                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_ATTACHMENT);
                                string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);

                                string strImageName = "PURCHASE_" + intImageSection.ToString() + "_" + count + "_" + strNextNumber + "." + strFileExt;
                                objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_ATTACHMENT);

                                PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);

                                objEntityAttahmentList.Add(objEntityRnwlDetailsAttchmnt);



                            }
                        }
                    }
                }
            }


            string strCanclDtlId1 = "";
            string[] strarrCancldtlIds1 = strCanclDtlId1.Split(',');
            if (hiddenFileCanclDtlId.Value != "" && hiddenFileCanclDtlId.Value != null)
            {
                strCanclDtlId1 = hiddenFileCanclDtlId.Value;
                strarrCancldtlIds1 = strCanclDtlId1.Split(',');

            }
            //Cancel the rows that have been cancelled when editing in Detail table
            foreach (string strDtlId in strarrCancldtlIds1)
            {
                if (strDtlId != "" && strDtlId != null)
                {
                    int intDtlId = Convert.ToInt32(strDtlId);
                    clsEntityPurchaseMaster objEntityRnwlDetailsAttchmnt = new clsEntityPurchaseMaster();
                    objEntityRnwlDetailsAttchmnt.AttachmentId = Convert.ToInt32(strDtlId);
                    objEntityDeleteAttchmntList.Add(objEntityRnwlDetailsAttchmnt);

                }
            }
        }
        List<clsEntityPurchaseMaster_list> objEntitySalesCCList = new List<clsEntityPurchaseMaster_list>();
        if (HiddenAdd.Value != "")
        {
            string jsonData = HiddenAdd.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string k = h.Replace("}\",", "},");
            List<clsWBData> objWBDataList = new List<clsWBData>();
            //   UserData  data
            objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(k);
            foreach (clsWBData objclsWBData in objWBDataList)
            {
                clsEntityPurchaseMaster_list objEntity_Purchase = new clsEntityPurchaseMaster_list();

                if (objclsWBData.EVTACTION == "INS")
                {
                    objEntity_Purchase.SlNo = Convert.ToInt32(objclsWBData.SLNO);
                    objEntity_Purchase.ProductId = Convert.ToInt32(objclsWBData.PRODUCT);
                    objEntity_Purchase.Quantity = Convert.ToDecimal(objclsWBData.QUANTITY);
                    objEntity_Purchase.Rate = Convert.ToDecimal(objclsWBData.RATE);
                    if (objclsWBData.DISPERCENTAGE != "" && objclsWBData.DISPERCENTAGE != null)
                    {
                        objEntity_Purchase.DiscountPercentage = Convert.ToDecimal(objclsWBData.DISPERCENTAGE);
                    }
                    if (objclsWBData.DISCOUNTAMT != "" && objclsWBData.DISCOUNTAMT != null)
                    {
                        objEntity_Purchase.DiscountAmount = Convert.ToDecimal(objclsWBData.DISCOUNTAMT);
                    }
                    if (objclsWBData.TAX != "" && objclsWBData.TAX != null)
                    {
                        objEntity_Purchase.Tax = Convert.ToDecimal(objclsWBData.TAX);
                    }
                    if (Request.Form["remarktxt" + objclsWBData.SLNO] != ""  && Request.Form["remarktxt" + objclsWBData.SLNO] != "null")
                    {
                        objEntity_Purchase.Remark = Request.Form["remarktxt" + objclsWBData.SLNO];
                    }
                    objEntity_Purchase.TaxAmount = Convert.ToDecimal(objclsWBData.TAXAMT);
                    objEntity_Purchase.Price = Convert.ToDecimal(objclsWBData.PRICE);
                    
                    ObjEntityPurchaseList_Insert.Add(objEntity_Purchase);
                }

                if (objclsWBData.EVTACTION == "UPD")
                {
                    objEntity_Purchase.SlNo = Convert.ToInt32(objclsWBData.SLNO);
                    objEntity_Purchase.ProductId = Convert.ToInt32(objclsWBData.PRODUCT);
                    objEntity_Purchase.Quantity = Convert.ToDecimal(objclsWBData.QUANTITY);
                    objEntity_Purchase.Rate = Convert.ToDecimal(objclsWBData.RATE);
                    if (objclsWBData.DISPERCENTAGE!= "" &&objclsWBData.DISPERCENTAGE!=null)
                    {
                        objEntity_Purchase.DiscountPercentage = Convert.ToDecimal(objclsWBData.DISPERCENTAGE);
                    }
                    if (objclsWBData.DISCOUNTAMT != "" && objclsWBData.DISCOUNTAMT != null)
                    {
                        objEntity_Purchase.DiscountAmount = Convert.ToDecimal(objclsWBData.DISCOUNTAMT);
                    }
                    if (objclsWBData.TAX != "" && objclsWBData.TAX!=null)
                    {
                        objEntity_Purchase.Tax = Convert.ToDecimal(objclsWBData.TAX);
                    }
                    objEntity_Purchase.TaxAmount = Convert.ToDecimal(objclsWBData.TAXAMT);
                    objEntity_Purchase.Price = Convert.ToDecimal(objclsWBData.PRICE);
                    objEntity_Purchase.PurchaseProductId = Convert.ToInt32(objclsWBData.DTLID);
                    if (Request.Form["remarktxt" + objclsWBData.SLNO] != "" && Request.Form["remarktxt" + objclsWBData.SLNO] != "null")
                    {
                        objEntity_Purchase.Remark = Request.Form["remarktxt" + objclsWBData.SLNO];
                    }
                    ObjEntityPurchaseList_Update.Add(objEntity_Purchase);
                }
                string CostCenterDtl = Request.Form["tdCostCenterDtls" + objclsWBData.ROWID];
                if (CostCenterDtl != "" && CostCenterDtl != null)
                {
                    string[] CostCenterDtlvalues = CostCenterDtl.Split('$');
                    for (int i = 0; i < CostCenterDtlvalues.Length; i++)
                    {
                        clsEntityPurchaseMaster_list objSubEntity = new clsEntityPurchaseMaster_list();

                        if (objclsWBData.SLNO != "")
                        {
                            objSubEntity.SlNo = Convert.ToInt32(objclsWBData.SLNO);
                        }
                        if (objclsWBData.PRODUCT != "")
                        {
                            objSubEntity.ProductId = Convert.ToInt32(objclsWBData.PRODUCT);
                        }
                        string[] valSplit = CostCenterDtlvalues[i].Split('%');
                        objSubEntity.CC_Id = Convert.ToInt32(valSplit[0]);
                        valSplit[1] = valSplit[1].Replace(",", "");

                        objSubEntity.CC_Amount = Convert.ToDecimal(valSplit[1]);
                        if (valSplit[2] != "" && valSplit[2] != null)
                        {
                            objSubEntity.CC_Grp1_Id = Convert.ToInt32(valSplit[2]);
                        }
                        if (valSplit[3] != "" && valSplit[3] != null)
                        {
                            objSubEntity.CC_Grp2_Id = Convert.ToInt32(valSplit[3]);
                        }
                        objEntitySalesCCList.Add(objSubEntity);

                    }
                }
            }
            string strCanclDtlId = "";
            string[] strarrCancldtlIds = strCanclDtlId.Split(',');
            if (hiddenCanclDtlId.Value != "" && hiddenCanclDtlId.Value != null)
            {
                strCanclDtlId = hiddenCanclDtlId.Value;
                strarrCancldtlIds = strCanclDtlId.Split(',');

            }
            //Cancel the rows that have been cancelled when editing in Detail table
            foreach (string strDtlId in strarrCancldtlIds)
            {
                if (strDtlId != "" && strDtlId != null)
                {
                    int intDtlId = Convert.ToInt32(strDtlId);
                    clsEntityPurchaseMaster_list objEntityPurchaseDelete = new clsEntityPurchaseMaster_list();
                    objEntityPurchaseDelete.PurchaseProductId = Convert.ToInt32(strDtlId);
                    ObjEntityPurchaseList_Delete.Add(objEntityPurchaseDelete);

                }
            }
            if (clickedButton.ID == "btnConfirm1")
            {
                objEntityPurchase.ConfirmStatus=1;
                if (Session["FINCYRID"] != null)
                    objEntityPurchase.FinancialYrID = Convert.ToInt32(Session["FINCYRID"]);
                objEntityPurchase.ConfirmDate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy"));

            }
     
            int flag = 0;
            DataTable dtPCancel = objBusinesspurchase.ChkProductMasterIsCancel(objEntityPurchase);
            if (dtPCancel.Rows.Count > 0)
            {
                int intCancel = 0;
                intCancel = Convert.ToInt32(dtPCancel.Rows[0][0].ToString());
                if (intCancel > 0)
                {
                    flag++;
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancel", "SuccessCancel();", true);

                }
            }
            DataTable dtPConfrm = objBusinesspurchase.ChkProductMasterIsCnfrm(objEntityPurchase);
            if (dtPConfrm.Rows.Count > 0)
            {
                int intConfrm = 0;
                intConfrm = Convert.ToInt32(dtPConfrm.Rows[0][0].ToString());
                if (intConfrm > 0)
                {
                    flag++;
                   // ScriptManager.RegisterStartupScript(this, GetType(), "SuccessNotConfirmation", "SuccessNotConfirmation();", true);             
                    Response.Redirect("Purchase_Master_List.aspx?InsUpd=AlreadyConfirm");
                }
            }
            if (flag == 0)
            {

                int AcntCloseSts = AccountCloseCheck(txtdate.Value);

                int AuditCloseSts = AuditCloseCheck(txtdate.Value); ;


                int retFlg = 0;



                if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
                {
                    retFlg = 1;
                    Response.Redirect("Purchase_Master_List.aspx?InsUpd=AuditClosed");
                }
                else if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
                {

                }
                else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
                {
                    retFlg = 1;
                    Response.Redirect("Purchase_Master_List.aspx?InsUpd=AcntClosed");
                }
                if (clickedButton.ID == "btnConfirm1")
                {
                    if (ChkStatus.Checked == false)
                    {
                        retFlg = 1;
                        Response.Redirect("Purchase_master.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=StsErr");
                    }
                }

                try{

                    if (retFlg == 0)
                    {

                        objBusinesspurchase.UpdatePurchaseMaster(objEntityPurchase, ObjEntityPurchaseList_Insert, ObjEntityPurchaseList_Update, ObjEntityPurchaseList_Delete, objEntityAttahmentList, objEntityDeleteAttchmntList, objEntitySalesCCList);

                        if (clickedButton.ID == "btnUpdate")
                        {
                            Response.Redirect("Purchase_master.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnUpdateClose")
                        {
                            Response.Redirect("Purchase_Master_List.aspx?InsUpd=Upd");
                        }
                        if (clickedButton.ID == "btnFloatUpdate")
                        {
                            Response.Redirect("Purchase_master.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnFloatUpdateClose")
                        {
                            Response.Redirect("Purchase_Master_List.aspx?InsUpd=Upd");
                        }
                        else if (clickedButton.ID == "btnConfirm1")
                        {
                            Response.Redirect("Purchase_Master_List.aspx?InsUpd=Confrm");
                        }
                        //0039 else if (clickedButton.ID == "btnConfirm1")
                        //{
                        //    Response.Redirect("Purchase_Master_List.aspx?InsUpd=AlreadyConfrm");
                        //}
                        //end

                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
    public class clsWBData
    {
        public string ROWID { get; set; }
        public string SLNO { get; set; }
        public string PRODUCT { get; set; }
        public string QUANTITY { get; set; }
        public string RATE { get; set; }
        public string DISPERCENTAGE { get; set; }
        public string DISCOUNTAMT { get; set; }
        public string TAX { get; set; }
        public string TAXAMT { get; set; }
        public string PRICE { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }
        public string REMARK { get; set; }
        public string XLOOP { get; set; }
    }
    public class clsFileUploadData
    {
        public string ROWID { get; set; }
        public string FILENAME { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        List<clsEntityPurchaseMaster_list> ObjEntityPurchaseList = new List<clsEntityPurchaseMaster_list>();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPurchase.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPurchase.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPurchase.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (txtRef.Text != "")
        {
            objEntityPurchase.AccountRef = txtRef.Text.Trim();
        }
        objEntityPurchase.AccountDate = objCommon.textToDateTime(txtdate.Value);
        //if (ddlAccountName.SelectedItem.Value != "-- SELECT ACCOUNT --")
        //{
        //    objEntityPurchase.LedgerBank = Convert.ToInt32(ddlAccountName.SelectedItem.Value);
        //}

        if (cbxAttachment.Checked == true)
        {
            objEntityPurchase.AttachmentStatus = 1;
        }
        else
        {
            objEntityPurchase.AttachmentStatus = 0;
        }
        if (cbxExtngSplr.Checked == true)
        {
            objEntityPurchase.ExistingSplrsts = 0;
            if (ddlCustomerLdgr.SelectedItem.Value != "--SELECT SUPPLIER --")
            {
                objEntityPurchase.LedgerCustomer = Convert.ToInt32(ddlCustomerLdgr.SelectedItem.Value);
            }
        }
        else
        {


            objEntityPurchase.LedgerCustomer = Convert.ToInt32(HiddenDfltLdgr.Value);
            objEntityPurchase.ExistingSplrsts = 1;
            if (txtsplrName.Text.Trim() != "")
            {
                objEntityPurchase.SplrName = txtsplrName.Text;
            }
            if (txtAddress1.Text.Trim() != "")
            {
                objEntityPurchase.AddressOne = txtAddress1.Text;
            }
            if (txtAddress2.Text.Trim() != "")
            {
                objEntityPurchase.AddressTwo = txtAddress2.Text;
            }
            if (txtAddress3.Text.Trim() != "")
            {
                objEntityPurchase.AddressThree = txtAddress3.Text;
            } if (txtContactNumber.Text.Trim() != "")
            {
                objEntityPurchase.ContactNumber = txtContactNumber.Text;
            }
        }
        if (txtReceipt.Text != "")
        {
            objEntityPurchase.ReceiptNo = txtReceipt.Text.Trim();
        }
        if (txtDesc.Value != "")
        {
            objEntityPurchase.Description = txtDesc.Value.Trim();
        }
        if (txtTerms.Value != "")
        {
            objEntityPurchase.Terms = txtTerms.Value.Trim();
        }
        if (txtOrder.Text != "")
        {
            objEntityPurchase.OrderNo = txtOrder.Text.Trim();
        }

        if (ChkStatus.Checked)
        {
            objEntityPurchase.AccountStatus = 1;
        }
        else
        {
            objEntityPurchase.AccountStatus = 0;

        }
        if (Hiddendiscount.Value != "")
        {
            string[] dis = Hiddendiscount.Value.Split(' ');
            objEntityPurchase.DiscountTotal = Convert.ToDecimal(dis[0]);
        }
        if (HiddenGrossAmt.Value != "")
        {
            string[] dis = HiddenGrossAmt.Value.Split(' ');
            objEntityPurchase.GrossAmount = Convert.ToDecimal(dis[0]);
        }



        if (HiddenCurrncyId.Value != ddlCurrency.SelectedItem.Value)
        {

            string[] dis = txtNetTotal.Text.Split(' ');
            //HiddenTotal_Exchng.Value.Split(' ');

            objEntityPurchase.TotalExchangeRate = Convert.ToDecimal(dis[0]);
            decimal exchangRt = Convert.ToDecimal(txtExchangeRate.Text);

            decimal Amt = Convert.ToDecimal(dis[0]);

            objEntityPurchase.NetAmount = Amt * exchangRt;
            objEntityPurchase.BalanceAmount = Amt * exchangRt;

        }
        else
        {
            string[] dis = txtNetTotal.Text.Split(' ');
            objEntityPurchase.NetAmount = Convert.ToDecimal(dis[0]);
            objEntityPurchase.BalanceAmount = Convert.ToDecimal(dis[0]);

        }

        if (HiddenTaxEnable.Value == "1")
        {
            if (HiddenTax.Value != "")
            {
                string[] dis = HiddenTax.Value.Split(' ');
                objEntityPurchase.TaxTotal = Convert.ToDecimal(dis[0]);
            }
        }
        if (ddlCurrency.SelectedItem.Value != "--SELECT CURRENCY--")
        {
            objEntityPurchase.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            if (objEntityPurchase.CurrencyId != Convert.ToInt32(hiddenDfltCurrencyMstrId.Value))
            {
                if (txtExchangeRate.Text != "")
                {
                    string ExchangeRate = txtExchangeRate.Text;
                    ExchangeRate = ExchangeRate.Replace(",", "");
                    objEntityPurchase.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Text);
                }
            }
        }
        List<clsEntityPurchaseMaster> objEntityAttahmentList = new List<clsEntityPurchaseMaster>();
        if (cbxAttachment.Checked == true)
        {
            //start file upload
            string jsonData1 = HiddenUploadInfo.Value;
            string c1 = jsonData1.Replace("\"{", "\\{");
            string d1 = c1.Replace("\\n", "\r\n");
            string g1 = d1.Replace("\\", "");
            string h1 = g1.Replace("}\"]", "}]");
            string i1 = h1.Replace("}\",", "},");

            List<clsFileUploadData> objTVDataList = new List<clsFileUploadData>();
            objTVDataList = JsonConvert.DeserializeObject<List<clsFileUploadData>>(i1);


            if (HiddenUploadInfo.Value != "" && HiddenUploadInfo.Value != null)
            {

                for (int count = 0; count < objTVDataList.Count; count++)
                {
                    string jsonFileid = "file" + objTVDataList[count].ROWID;
                    for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                    {

                        string fileId = Request.Files.AllKeys[intCount].ToString();
                        HttpPostedFile PostedFile = Request.Files[intCount];
                        if (fileId == jsonFileid)
                        {
                            if (PostedFile.ContentLength > 0)
                            {
                                clsEntityPurchaseMaster objEntityRnwlDetailsAttchmnt = new clsEntityPurchaseMaster();
                                string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                objEntityRnwlDetailsAttchmnt.ActualFileName = strFileName;
                                string strFileExt;

                                strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();


                                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_ATTACHMENT);
                                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_ATTACHMENT);
                                string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);

                                string strImageName = "PURCHASE_" + intImageSection.ToString() + "_" + count + "_" + strNextNumber + "." + strFileExt;
                                objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.PURCHASE_ATTACHMENT);

                                PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);

                                objEntityAttahmentList.Add(objEntityRnwlDetailsAttchmnt);



                            }
                        }
                    }
                }
            }
        }
        List<clsEntityPurchaseMaster_list> objEntitySalesCCList = new List<clsEntityPurchaseMaster_list>();

        if (HiddenAdd.Value != "")
        {
            string jsonData = HiddenAdd.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string k = h.Replace("}\",", "},");
            List<clsWBData> objWBDataList = new List<clsWBData>();
            //   UserData  data
            objWBDataList = JsonConvert.DeserializeObject<List<clsWBData>>(k);
            foreach (clsWBData objclsWBData in objWBDataList)
            {
                clsEntityPurchaseMaster_list objEntity_Purchase = new clsEntityPurchaseMaster_list();
                if (objclsWBData.SLNO != "")
                {
                    objEntity_Purchase.SlNo = Convert.ToInt32(objclsWBData.SLNO);
                }
                if (objclsWBData.PRODUCT != "")
                {
                    objEntity_Purchase.ProductId = Convert.ToInt32(objclsWBData.PRODUCT);
                }
                if (objclsWBData.QUANTITY != "")
                {
                    objEntity_Purchase.Quantity = Convert.ToDecimal(objclsWBData.QUANTITY);
                }
                if (objclsWBData.RATE != "")
                {
                    objEntity_Purchase.Rate = Convert.ToDecimal(objclsWBData.RATE);
                }
                if (objclsWBData.DISPERCENTAGE != "")
                {
                    objEntity_Purchase.DiscountPercentage = Convert.ToDecimal(objclsWBData.DISPERCENTAGE);
                }
                if (objclsWBData.DISCOUNTAMT != "")
                {
                    objEntity_Purchase.DiscountAmount = Convert.ToDecimal(objclsWBData.DISCOUNTAMT);
                }
                if (objclsWBData.TAX != "" && objclsWBData.TAX != null)
                {
                    objEntity_Purchase.Tax = Convert.ToDecimal(objclsWBData.TAX);
                }
                if (objclsWBData.TAXAMT != "" && objclsWBData.TAXAMT != null)
                {
                    objEntity_Purchase.TaxAmount = Convert.ToDecimal(objclsWBData.TAXAMT);
                }
                if (objclsWBData.REMARK != "" && objclsWBData.REMARK != null)
                    objEntity_Purchase.Remark = objclsWBData.REMARK;
                objEntity_Purchase.Price = Convert.ToDecimal(objclsWBData.PRICE);
                ObjEntityPurchaseList.Add(objEntity_Purchase);

                string CostCenterDtl = Request.Form["tdCostCenterDtls" + objclsWBData.ROWID];
                if (CostCenterDtl != "")
                {
                    string[] CostCenterDtlvalues = CostCenterDtl.Split('$');
                    for (int i = 0; i < CostCenterDtlvalues.Length; i++)
                    {
                        clsEntityPurchaseMaster_list objSubEntity = new clsEntityPurchaseMaster_list();

                        if (objclsWBData.SLNO != "")
                        {
                            objSubEntity.SlNo = Convert.ToInt32(objclsWBData.SLNO);
                        }
                        if (objclsWBData.PRODUCT != "")
                        {
                            objSubEntity.ProductId = Convert.ToInt32(objclsWBData.PRODUCT);
                        }
                        string[] valSplit = CostCenterDtlvalues[i].Split('%');
                        objSubEntity.CC_Id = Convert.ToInt32(valSplit[0]);
                        valSplit[1] = valSplit[1].Replace(",", "");

                        objSubEntity.CC_Amount = Convert.ToDecimal(valSplit[1]);
                        if (valSplit[2] != "" && valSplit[2] != null)
                        {
                            objSubEntity.CC_Grp1_Id = Convert.ToInt32(valSplit[2]);
                        }
                        if (valSplit[3] != "" && valSplit[3] != null)
                        {
                            objSubEntity.CC_Grp2_Id = Convert.ToInt32(valSplit[3]);
                        }
                        objEntitySalesCCList.Add(objSubEntity);

                    }
                }

            }

            try
            {

                objBusinesspurchase.InsertPurchaseMaster(objEntityPurchase, ObjEntityPurchaseList, objEntityAttahmentList, objEntitySalesCCList);

                if (clickedButton.ID == "btnAdd")
                {
                    Response.Redirect("Purchase_master.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnAddClose")
                {
                    Response.Redirect("Purchase_Master_List.aspx?InsUpd=Ins");
                }

                if (clickedButton.ID == "btnFloatAdd")
                {
                    Response.Redirect("Purchase_master.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnFloatAddClose")
                {
                    Response.Redirect("Purchase_Master_List.aspx?InsUpd=Ins");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
    protected void ddlCustomerLdgr_SelectedIndexChanged(object sender, EventArgs e)
    {
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPurchase.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPurchase.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtDivision = objBusinesspurchase.ReadCustomerLdger(objEntityPurchase);
        if (dtDivision.Rows.Count > 0)
        {
        }
        //ddlCustomerLdgr.Focus();
    }
    private void SortDDL(ref DropDownList objDDL)
    {
        System.Collections.ArrayList textList = new System.Collections.ArrayList();
        System.Collections.ArrayList valueList = new System.Collections.ArrayList();


        foreach (System.Web.UI.WebControls.ListItem li in objDDL.Items)
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
            System.Web.UI.WebControls.ListItem objItem = new System.Web.UI.WebControls.ListItem(textList[i].ToString(), valueList[i].ToString());
            objDDL.Items.Add(objItem);
        }
    }

    public void LoadCurrencies()
    {
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityPurchase.CorpId = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityPurchase.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityPurchase.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtdiv = objBusinesspurchase.ReadCurrencies(objEntityPurchase);
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

    [WebMethod]
    public static string[] getItems(string prefix, string strOrgId, string strCorpId)
    {
        List<string> customers = new List<string>();
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        objEntityPurchase.OrgId = Convert.ToInt32(strOrgId);
        objEntityPurchase.CorpId = Convert.ToInt32(strCorpId);
        objEntityPurchase.SearchString = prefix;
        DataTable dt = objBusinesspurchase.ReadProductLdger(objEntityPurchase);
        foreach (DataRow r in dt.Rows)
        {
            customers.Add(string.Format("{0}—{1}", r[1], r[0]));
        }
        return customers.ToArray();
    }
    [WebMethod]
    public static string RedCurencyAbrvtn(string intCrncyId, string intuserid, string intorgid, string intcorpid)
    {

        string result = "";
        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsEntitySales ObjEntitySales = new clsEntitySales();
        ObjEntitySales.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntitySales.Corporate_id = Convert.ToInt32(intcorpid);
        ObjEntitySales.CurrencyId = Convert.ToInt32(intCrncyId);
        DataTable dtSubConrt = objBusinessSales.ReadCrncyAbrvtn(ObjEntitySales);
        // dtSubConrt.TableName = "dtTableLoadProduct";
        //  string ABVRTN;
        if (dtSubConrt.Rows.Count > 0)
        {
            result = dtSubConrt.Rows[0][0].ToString();
        }


        return result;
    }
    [WebMethod]
    public static string CheckDuplication(string orderNo, string orgID, string corptID, string UserID, string purchaseId, string PurchaseDate)
    {

        string result = "true";
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityPurchase.OrgId = Convert.ToInt32(orgID);
        objEntityPurchase.CorpId = Convert.ToInt32(corptID);
        if (orderNo != "")
        {
            objEntityPurchase.OrderNo = orderNo;
        }
        if (purchaseId != "")
        {
            objEntityPurchase.PurchaseId = Convert.ToInt32(purchaseId);

        }
        if (PurchaseDate != "" )
        {
            objEntityPurchase.FromDate = objCommon.textToDateTime(PurchaseDate);
 
        }
        if (orderNo != "")
        {
            DataTable dtSubConrt = objBusinesspurchase.chkOrderNoDuplication(objEntityPurchase);

            // dtSubConrt.TableName = "dtTableLoadProduct";
            //  string ABVRTN;
            if (dtSubConrt.Rows.Count > 0)
            {
                result = "false";
            }
        }

        return result;
    }
    [WebMethod]
    public static string CheckAcntCloseSts(string jrnlDate, string orgID, string corptID, string AuditPrvsn, string AcntPrvsn)
    {
        int sts = 0;
        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();

        if (corptID != null && corptID != "")
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(corptID);
            objEntityAudit.Corporate_id = Convert.ToInt32(corptID);
        }
        if (orgID != null && orgID != "")
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(orgID);
            objEntityAudit.Organisation_id = Convert.ToInt32(orgID);
        }
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(jrnlDate);

        objEntityAudit.FromDate = objCommon.textToDateTime(jrnlDate);

        DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
        DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
        if (dtAuditCls.Rows.Count > 0 && AuditPrvsn != "1")
        {
            sts = 1;
        }
        else if (dtAuditCls.Rows.Count > 0 && AuditPrvsn == "1")
        {

        }
        else if (dtAccntCls.Rows.Count > 0 && AcntPrvsn != "1")
        {
            sts = 2;
        }
        else if (dtAccntCls.Rows.Count > 0 && AcntPrvsn == "1")
        {

        }
        return sts.ToString();
    }
 
    [WebMethod]
    public static string CheckRefNumber(string jrnlDate, string orgID, string corptID, string usrID, string RefNum, string Purchaseid)
    {
        string Ref = "";

        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(jrnlDate);
       
        clsBusiness_purchaseMaster objBusinessLayerStock = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityLayerStock = new clsEntityPurchaseMaster();


        cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();

        objEntityAudit.FromDate = objCommon.textToDateTime(jrnlDate);


        objEntityLayerStock.FromDate = objCommon.textToDateTime(jrnlDate);

        if (corptID != null && corptID != "")
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(corptID);
            objEntityLayerStock.CorpId = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);
            objEntityAudit.Corporate_id = Convert.ToInt32(corptID);

        }
        if (orgID != null && orgID != "")
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(orgID);
            objEntityLayerStock.OrgId = Convert.ToInt32(orgID);
            objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
            objEntityAudit.Organisation_id = Convert.ToInt32(orgID);

        }
        if (RefNum != "")
        {
            Ref = RefNum;
        }
        int SubRef = 1;

        DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
        DataTable dtAuditCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);
        if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
        {
            DataTable dtRefFormat1 = objBusinessLayerStock.ReadRefNumberByDate(objEntityLayerStock);
            if (dtRefFormat1.Rows.Count > 0)
            {
                string strRef = "";
                if (dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != "" && dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != null)
                {
                    if (Convert.ToInt32(dtRefFormat1.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString()) != 1)
                    {
                        strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                        strRef = strRef.TrimEnd('/');
                        strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                    }
                    else
                    {
                        strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                    }
                }
                else
                {
                    strRef = dtRefFormat1.Rows[0]["PURCHS_REF"].ToString();
                }
                objEntityLayerStock.AccountRef = strRef;
                DataTable dtRefFormat = objBusinessLayerStock.ReadRefNumberByDateLast(objEntityLayerStock);

                if (dtRefFormat.Rows.Count > 0)
                {
                    // if (Convert.ToInt32(Purchaseid) != Convert.ToInt32(dtRefFormat.Rows[0]["PURCHS_ID"].ToString()))
                    // {
                    Ref = dtRefFormat.Rows[0]["PURCHS_REF"].ToString();
                    if (dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != "" && dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString() != null)
                    {
                        SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PURCH_REF_NXT_SUMNUM"].ToString());
                    }
                    if (SubRef != 1)
                    {

                        Ref = Ref.TrimEnd('/');
                        Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                    }
                    else
                    {
                        Ref += "/";
                    }
                    Ref = Ref + "" + SubRef;
                    //  }
                }
            }
        }
        else
        {
            if (Purchaseid == "")
            {

                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_PURCHASE_MASTER);
                objEntityCommon.CorporateID = Convert.ToInt32(corptID); ;
                objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
                string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);
                // objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PurchaseMaster);
                DataTable dtFormate = objBusinessLayerStock.readRefFormate(objEntityCommon);

                string CurrentDate = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
                DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                int DtYear = dtCurrentDate.Year;
                int DtMonth = dtCurrentDate.Month;
                string dtyy = dtCurrentDate.ToString("yy");
                string refFormatByDiv = "";
                string strRealFormat = "";
                if (dtFormate.Rows.Count > 0)
                {
                    if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                    {
                        refFormatByDiv = dtFormate.Rows[0]["REF_FORMATE"].ToString();
                        string strReferenceFormat = "";
                        strReferenceFormat = refFormatByDiv;


                        strRealFormat = refFormatByDiv.ToString();
                        if (strRealFormat.Contains("#ORG#"))
                        {
                            strRealFormat = strRealFormat.Replace("#ORG#", orgID);
                        }
                        if (strRealFormat.Contains("#COR#"))
                        {
                            strRealFormat = strRealFormat.Replace("#COR#", corptID);
                        }

                        if (strRealFormat.Contains("#USR#"))
                        {
                            strRealFormat = strRealFormat.Replace("#USR#", usrID);
                        }
                        if (strRealFormat.Contains("#YER#"))
                        {
                            strRealFormat = strRealFormat.Replace("#YER#", DtYear.ToString());
                        }
                        if (strRealFormat.Contains("#YY#"))
                        {
                            strRealFormat = strRealFormat.Replace("#YY#", dtyy.ToString());
                        }
                        if (strRealFormat.Contains("#MON#"))
                        {
                            strRealFormat = strRealFormat.Replace("#MON#", DtMonth.ToString());

                        }
                        //strRealFormat = strRealFormat + "/" + strNextId;

                        if (strRealFormat.Contains("#NUM#"))
                        {
                            strRealFormat = strRealFormat.Replace("#NUM#", strNextId);
                        }
                        else
                        {
                            strRealFormat = strRealFormat + "/" + strNextId;
                        }
                        strRealFormat = strRealFormat.Replace("#", "");

                        Ref = strRealFormat;
                    }
                }

                else
                {
                    Ref = strNextId;
                }

            }
        }
        return Ref;
    }
    protected void btnReopen1_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        string PurchaseId = "";
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsBusiness_purchaseMaster objBusinessLayerStock = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityLayerStock = new clsEntityPurchaseMaster();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerStock.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLayerStock.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            //intUserId = Convert.ToInt32(Session["USERID"]);
            objEntityLayerStock.UserId = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Request.QueryString["ViewId"] != null)
        {
            string strRandomMixedId = Request.QueryString["ViewId"].ToString();
            PurchaseId = Request.QueryString["ViewId"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityLayerStock.PurchaseId = Convert.ToInt32(strId);
        }
        else if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            PurchaseId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            objEntityLayerStock.PurchaseId = Convert.ToInt32(strId);
        }
        int AcntCloseSts = 0;

        int AuditCloseSts = 0;

        DataTable dt = objBusinessLayerStock.ReadPurchaseById(objEntityLayerStock);
        if (dt.Rows.Count > 0)
        {
            AcntCloseSts = AccountCloseCheck(dt.Rows[0]["PURCHS_DATE"].ToString());
            AuditCloseSts = AuditCloseCheck(dt.Rows[0]["PURCHS_DATE"].ToString());
            if (dt.Rows[0]["LDGR_ID"].ToString() != null)
            {
                objEntityLayerStock.LedgerCustomer = Convert.ToInt32(dt.Rows[0]["LDGR_ID"].ToString());
            }
        }
        objEntityLayerStock.NetAmount = Convert.ToDecimal(HiddenNetAmt.Value);



        int retFlg = 0;

        if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
        {
            retFlg = 1;
            Response.Redirect("Purchase_Master_List.aspx?InsUpd=AuditClosed");
        }
        else if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
        {

        }
        //0039
        else if (dt.Rows[0]["PURCHS_REOPEN_USRID"].ToString() != "" && dt.Rows[0]["PURCHS_CNFRM_STS"].ToString() == "0")
        {
            Response.Redirect("Purchase_master.aspx?Id=" + Request.QueryString["ViewId"] + "&InsUpd=AlreadyReopen");
            //strRets = "alrdyreopened";
        }

            //end

        else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
        {
            retFlg = 1;
            Response.Redirect("Purchase_Master_List.aspx?InsUpd=AcntClosed");
        }
        if (retFlg == 0)
        {
            objBusinessLayerStock.ReopenPurchase(objEntityLayerStock);
            if (clickedButton.ID == "btnReopen1")
            {
                Response.Redirect("Purchase_master.aspx?Id=" + PurchaseId + "&InsUpd=Reop");
            }
        }
    }
    //protected void btnPRint_Click(object sender, EventArgs e)
    //{
    //    string strId = "";
    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    if (Request.QueryString["ViewId"] != null)
    //    {
    //        string strRandomMixedId = Request.QueryString["ViewId"].ToString();
    //        string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //        int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //        strId = strRandomMixedId.Substring(2, intLenghtofId);
    //    }
    //    else if (Request.QueryString["Id"] != null)
    //    {
    //        string strRandomMixedId = Request.QueryString["Id"].ToString();
    //        string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //        int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //        strId = strRandomMixedId.Substring(2, intLenghtofId);
    //    }
    //    if (strId != "")
    //    {
    //        clsCommonLibrary objCommn = new clsCommonLibrary();
        

    //        clsEntityPurchaseMaster ObjEntitySales = new clsEntityPurchaseMaster();

    //        if (Session["CORPOFFICEID"] != null)
    //        {
    //            ObjEntitySales.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //        }
    //        else if (Session["CORPOFFICEID"] == null)
    //        {
    //            Response.Redirect("~/Default.aspx");
    //        }
    //        if (Session["ORGID"] != null)
    //        {
    //            ObjEntitySales.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
    //        }
    //        else if (Session["ORGID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        if (Session["USERID"] != null)
    //        {
    //            //intUserId = Convert.ToInt32(Session["USERID"]);
    //            ObjEntitySales.UserId = Convert.ToInt32(Session["USERID"]);
    //        }
    //        else if (Session["USERID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }

    //        string PreparedBy = "";

    //        if (Session["USERFULLNAME"] != null)
    //        {
    //            PreparedBy = Session["USERFULLNAME"].ToString();
    //        }
    //        ObjEntitySales.PurchaseId = Convert.ToInt32(strId);

    //        clsBusiness_purchaseMaster objBusinessSales = new clsBusiness_purchaseMaster();
    //        DataTable dt = objBusinessSales.ReadPurchaseById(ObjEntitySales);
    //        DataTable dtProduct = objBusinessSales.ReadProductPurchaseById(ObjEntitySales);

    //        DataTable dtCorp = objBusinessSales.ReadCorpDtls(ObjEntitySales);
    //        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.PURCHASE);
    //        DataTable dtVersion = objBusiness.ReadPrintVersion(objEntityCommon);
    //        if (dtVersion.Rows.Count > 0)
    //        {
    //            if (dtVersion.Rows[0][0].ToString() == "1")
    //            {
    //                PdfPrintVersion1(dt, dtProduct,dtCorp, ObjEntitySales, PreparedBy);
    //            }
    //            else if (dtVersion.Rows[0][0].ToString() == "2")
    //            {
    //             //   PdfPrintVersion2(dt, dtProduct, dtCust, dtCorp, ObjEntitySales, PreparedBy);
    //            }
    //            else if (dtVersion.Rows[0][0].ToString() == "3")
    //            {
    //             //   PdfPrintVersion3(dt, dtProduct, dtCust, dtCorp, ObjEntitySales, PreparedBy);
    //            }
    //        }
    //        else
    //        {
    //            ScriptManager.RegisterStartupScript(this, GetType(), "PrintVersnError", "PrintVersnError();", true);
    //        }
    //        PdfPrintVersion1(dt, dtProduct, dtCorp, ObjEntitySales, PreparedBy);
    //    }
    //}
    [WebMethod]
    public static string PrintPDF(string saleId, string orgID, string corptID, string PreparedBy)
    {

        string strRandomMixedId = saleId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsBusiness_purchaseMaster objBusinessSales = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster ObjEntitySales = new clsEntityPurchaseMaster();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (corptID != null)
        {
            ObjEntitySales.CorpId = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        }
        if (orgID != null)
        {
            ObjEntitySales.OrgId = Convert.ToInt32(orgID);
        }
        ObjEntitySales.PurchaseId = Convert.ToInt32(strId);



        DataTable dt = objBusinessSales.ReadPurchaseById(ObjEntitySales);
        DataTable dtProduct = objBusinessSales.ReadProductPurchaseById(ObjEntitySales);

        DataTable dtCorp = objBusinessSales.ReadCorpDtls(ObjEntitySales);


        FMS_FMS_Master_Purchase_Matser_Purchase_master objPage = new FMS_FMS_Master_Purchase_Matser_Purchase_master();
        //    .ObjEntitySales.return objPage.PdfPrint(strId, dt, dtProduct, dtCorp, ObjEntitySales, PreparedBy);
        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.PURCHASE);
        string strReturn = "";
        DataTable dtVersion = objBusiness.ReadPrintVersion(objEntityCommon);
        if (dtVersion.Rows.Count > 0)
        {
            if (dtVersion.Rows[0][0].ToString() == "1")
            {
               // strReturn = objPage.PdfPrintVersion1(dt, dtProduct, dtCorp, ObjEntitySales, PreparedBy);
                strReturn = objBusinessSales.PdfPrintVersion1( dt, dtProduct, dtCorp, ObjEntitySales, PreparedBy);

            }
            else if (dtVersion.Rows[0][0].ToString() == "2")
            {
                strReturn = objBusinessSales.PdfPrintVersion2And3( dt, dtProduct, dtCorp, ObjEntitySales, PreparedBy,2);
            }
            else if (dtVersion.Rows[0][0].ToString() == "3")
            {
                strReturn = objBusinessSales.PdfPrintVersion2And3(dt, dtProduct, dtCorp, ObjEntitySales, PreparedBy, 3);
            }
        }
        return strReturn;

    }
    //public string PdfPrintVersion1(DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntityPurchaseMaster ObjEntitySales, string PreparedBy)
    //{


    //    string strRet = "true";

    //    string strId = "";

    //    strId = Convert.ToString(ObjEntitySales.PurchaseId);
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.PURCHASE_INVOICE);

    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();

    //    if (ObjEntitySales.CorpId != 0)
    //    {
    //        objEntityCommon.CorporateID = ObjEntitySales.CorpId;
    //    }
    //    if (ObjEntitySales.OrgId != 0)
    //    {
    //        objEntityCommon.Organisation_Id = ObjEntitySales.OrgId;
    //    }

    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_PRINT);
    //    string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);

    //    string strImageName = "Purchase_Invoice" + strId + "_" + strNextNumber + ".pdf";
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PURCHASE_INVOICE);

    //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {

    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {

    //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);

    //            PdfWriter writer = PdfWriter.GetInstance(document, file);
    //            document.Open();

    //            //  string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "corporate-logo.jpg";
    //            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);

    //            if (dtCorp.Rows.Count > 0)
    //            {
    //                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
    //                {
    //                    string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
    //                    string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();

    //                    strImageLogo = imaeposition + icon;
    //                    //objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + dtCorp.Rows[0]["CORPRT_ICON"].ToString();
    //                }
    //            }

    //            var FontBlue = new BaseColor(0, 174, 239);
    //            var FontBlueGrey = new BaseColor(79, 167, 206);

    //            PdfPTable headImg = new PdfPTable(2);

    //            if (strImageLogo != "")
    //            {


    //                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath(strImageLogo));

    //                image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //                image.ScaleToFit(100f, 80f);

    //                headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });


    //            }
    //            else
    //            {
    //                headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
    //            }
    //            if (dt.Rows[0]["PURCHS_CNFRM_STS"].ToString() == "1")
    //                headImg.AddCell(new PdfPCell(new Phrase(" PURCHASE REGISTER", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
    //            else
    //                headImg.AddCell(new PdfPCell(new Phrase("DRAFT PURCHASE REGISTER", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
    //            float[] headersHeading = { 60, 40 };
    //            headImg.SetWidths(headersHeading);
    //            headImg.WidthPercentage = 100;

    //            document.Add(headImg);



    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(3);
    //            float[] footrsBody = { 40, 30, 30 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;




    //            Font myFont = FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue);
    //            Font myNormalFont = FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK);

    //            string line1 = dtCorp.Rows[0][0].ToString() + "\n";

    //            string line2 = dtCorp.Rows[0][4].ToString() + "\n";
    //            string line3 = dtCorp.Rows[0][1].ToString() + "\n";
    //            string line4 = dtCorp.Rows[0][2].ToString() + "\n";
    //            string line5 = dtCorp.Rows[0][3].ToString() + "\n";
    //            string line6 = "   " + "\n";


    //            Paragraph p1 = new Paragraph();
    //            Phrase ph1 = new Phrase(line1, myFont);
    //            Phrase ph2 = new Phrase(line2, myNormalFont);
    //            Phrase ph3 = new Phrase(line3, myNormalFont);
    //            Phrase ph4 = new Phrase(line4, myNormalFont);
    //            Phrase ph5 = new Phrase(line5, myNormalFont);
    //            Phrase ph6 = new Phrase(line6, myNormalFont);
    //            p1.Add(ph1);
    //            p1.Add(ph2);
    //            p1.Add(ph3);
    //            p1.Add(ph4);
    //            p1.Add(ph5);
    //            p1.Add(ph6);
    //            PdfPCell mycell = new PdfPCell(p1);


    //            line1 = " Purchase No. :" + "\n";

    //            line2 = dt.Rows[0]["PURCHS_REF"].ToString() + "\n";
    //            line3 = "   " + "\n";
    //            p1 = new Paragraph();
    //            ph1 = new Phrase(line1, myFont);

    //            ph2 = new Phrase(line2, myNormalFont);
    //            ph3 = new Phrase(line3, myNormalFont);
    //            p1.Add(ph1);
    //            p1.Add(ph3);
    //            p1.Add(ph2);

    //            PdfPCell newInvoicecell = new PdfPCell(p1);

    //            line1 = " Date :" + "\n";

    //            line2 = dt.Rows[0]["PURCHS_DATE"].ToString() + "\n";
    //            line3 = "   " + "\n";
    //            p1 = new Paragraph();
    //            ph1 = new Phrase(line1, myFont);
    //            ph2 = new Phrase(line2, myNormalFont);
    //            ph3 = new Phrase(line3, myNormalFont);
    //            p1.Add(ph1);
    //            p1.Add(ph3);
    //            p1.Add(ph2);

    //            PdfPCell newDatecell = new PdfPCell(p1);


    //            line1 = "Order No. :" + "\n";

    //            line2 = dt.Rows[0]["PURCHS_ORDERNO"].ToString() + "\n";
    //            p1 = new Paragraph();
    //            ph1 = new Phrase(line1, myFont);
    //            ph2 = new Phrase(line2, myNormalFont);
    //            p1.Add(ph1);
    //            p1.Add(ph2);

    //            PdfPCell newSupplierDetailscell = new PdfPCell(p1);


    //            line1 = "To :" + "\n";
    //            if (dt.Rows[0]["PURCH_SUP_TYP"].ToString() == "1")
    //            {

    //                line2 = dt.Rows[0]["PURCH_SUP_NAME"].ToString() + "\n";
    //                line3 = dt.Rows[0]["PURCH_SUP_ADD_ONE"].ToString() + "\n";
    //                line4 = dt.Rows[0]["PURCH_SUP_ADD_TWO"].ToString() + "\n";
    //                line5 = dt.Rows[0]["PURCH_SUP_ADD_THREE"].ToString() + "\n";
    //                line6 = "   " + "\n";

    //                p1 = new Paragraph();
    //                ph1 = new Phrase(line1, myNormalFont);
    //                ph2 = new Phrase(line2, myNormalFont);
    //                ph3 = new Phrase(line3, myNormalFont);
    //                ph4 = new Phrase(line4, myNormalFont);
    //                ph5 = new Phrase(line5, myNormalFont);
    //                ph6 = new Phrase(line6, myNormalFont);
    //                p1.Add(ph1);
    //                p1.Add(ph6);
    //                p1.Add(ph2);
    //                p1.Add(ph3);
    //                p1.Add(ph4);
    //                p1.Add(ph5);

    //            }

    //            else
    //            {
    //                line2 = dt.Rows[0]["SUPLIR_NAME"].ToString() + "\n";
    //                if (dt.Rows[0]["SUPLIR_NAME"].ToString() != "")
    //                {
    //                    line2 = dt.Rows[0]["SUPLIR_NAME"].ToString() + "\n";
    //                }
    //                 else if (dt.Rows[0]["SUPPLIER"].ToString() != "")
    //                {
    //                    line2 = dt.Rows[0]["SUPPLIER"].ToString() + "\n";
    //                }
    //                line3 = dt.Rows[0]["SUPLIR_ADDRESS"].ToString() + "\n";
    //                line4 = dt.Rows[0]["SUPLIR_ADDRESS2"].ToString() + "\n";
    //                line5 = dt.Rows[0]["SUPLIR_ADDRESS3"].ToString() + "\n";
    //                line6 = "   " + "\n";

    //                p1 = new Paragraph();
    //                ph1 = new Phrase(line1, myNormalFont);
    //                ph2 = new Phrase(line2, myNormalFont);
    //                ph3 = new Phrase(line3, myNormalFont);
    //                ph4 = new Phrase(line4, myNormalFont);
    //                ph5 = new Phrase(line5, myNormalFont);
    //                ph6 = new Phrase(line6, myNormalFont);
    //                p1.Add(ph1);
    //                p1.Add(ph6);
    //                p1.Add(ph2);
    //                p1.Add(ph3);
    //                p1.Add(ph4);
    //                p1.Add(ph5);

    //            }
    //            PdfPCell newContactNocell = new PdfPCell(p1);


    //            line1 = "Contact Number :" + "\n";
    //            if (dt.Rows[0]["PURCH_SUP_TYP"].ToString() == "1")
    //            {

    //                line2 = dt.Rows[0]["PURCH_SUP_CONTACT_NO"].ToString() + "\n";

    //                line3 = "   " + "\n";
    //                p1 = new Paragraph();
    //                ph1 = new Phrase(line1, myNormalFont);
    //                ph2 = new Phrase(line2, myNormalFont);
    //                ph3 = new Phrase(line3, myNormalFont);
    //                p1.Add(ph1);
    //                p1.Add(ph3);
    //                p1.Add(ph2);


    //            }
    //            else
    //            {
    //                line2 = dt.Rows[0]["SUPLIR_CONTACTNO"].ToString() + "\n";

    //                line3 = "   " + "\n";
    //                p1 = new Paragraph();
    //                ph1 = new Phrase(line1, myNormalFont);
    //                ph2 = new Phrase(line2, myNormalFont);
    //                ph3 = new Phrase(line3, myNormalFont);
    //                p1.Add(ph1);
    //                p1.Add(ph3);
    //                p1.Add(ph2);
    //            }



    //            PdfPCell newOrdercell = new PdfPCell(p1);

    //            // footrtable.AddCell(mycell);
    //            footrtable.AddCell(new PdfPCell(mycell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Rowspan = 3 });
    //            footrtable.AddCell(new PdfPCell(newInvoicecell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            footrtable.AddCell(new PdfPCell(newDatecell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            footrtable.AddCell(new PdfPCell(newContactNocell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            footrtable.AddCell(new PdfPCell(newOrdercell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            footrtable.AddCell(new PdfPCell(newSupplierDetailscell) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            footrtable.AddCell(new PdfPCell() { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });

    //            document.Add(footrtable);
    //            string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "", ntttlWord = "";
    //            decimal grosttl = 0, taxttl = 0, discnt = 0, netTottl;

    //            var FontGrey = new BaseColor(134, 152, 160);
    //            var FontBordrGrey = new BaseColor(236, 236, 236);
    //            if (dtProduct.Rows.Count > 0)
    //            {

    //                if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() == "")
    //                {
    //                    if (dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString() != "")
    //                    {
    //                        grossTotal = dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString();
    //                        grosttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
    //                        grossTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString() != "")
    //                    {
    //                        taxTotal = dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString();
    //                        taxttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
    //                        taxTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["PURCHS_DISCOUNT"].ToString() != "")
    //                    {
    //                        discTotal = dt.Rows[0]["PURCHS_DISCOUNT"].ToString();
    //                        discnt = Convert.ToDecimal(dt.Rows[0]["PURCHS_DISCOUNT"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
    //                        discTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
    //                    {

    //                        netTottl = (grosttl + taxttl) - discnt;

    //                        // netTotal = dt.Rows[0]["PURCHS_NET_TOTAL"].ToString();
    //                        netTotal = netTottl.ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
    //                        netTotal = strNetAmountDebitComma;
    //                    }
    //                }
    //                else
    //                {
    //                    if (dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString() != "")
    //                    {
    //                        grossTotal = dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString();
    //                        grosttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
    //                        grossTotal = strNetAmountDebitComma ;
    //                    }



    //                    if (dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString() != "")
    //                    {

    //                        taxTotal = dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString();
    //                        taxttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
    //                        taxTotal = strNetAmountDebitComma ;

    //                    }
    //                    if (dt.Rows[0]["PURCHS_DISCOUNT"].ToString() != "")
    //                    {


    //                        discTotal = dt.Rows[0]["PURCHS_DISCOUNT"].ToString();
    //                        discnt = Convert.ToDecimal(dt.Rows[0]["PURCHS_DISCOUNT"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
    //                        discTotal = strNetAmountDebitComma ;
    //                    }
    //                    if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
    //                    {


    //                        netTottl = (grosttl + taxttl) - discnt;

    //                        netTotal = netTottl.ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
    //                        netTotal = strNetAmountDebitComma;
    //                    }
    //                }
    //                string strcurrenWord = "";
    //                if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
    //                {
    //                    clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
    //                    netTottl = (grosttl + taxttl) - discnt;

    //                    ntttlWord = netTottl.ToString();
    //                    strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, ntttlWord);

    //                }

    //                var FontRed = new BaseColor(202, 3, 20);
    //                var FontGreen = new BaseColor(46, 179, 51);
    //                var FontGray = new BaseColor(138, 138, 138);
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                if (TaxEnable == 1)
    //                {


    //                    PdfPTable table2 = new PdfPTable(6);
    //                    float[] tableBody2 = { 33, 10, 10, 12, 10, 15 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;

    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    // table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
    //                        table2.AddCell(new PdfPCell(new Phrase("TOTAL (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    else
    //                        table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {

    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";
    //                        string ProductTaxAmt = "";
    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_TAX_AMT"].ToString() != "")
    //                        {
    //                            ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_TAX_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
    //                            ProductTaxAmt = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }


    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        //     table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["TAX_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }




    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6 });
    //                    //  table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
    //                    table2.AddCell(new PdfPCell(new Phrase("Gross Total", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    table2.AddCell(new PdfPCell(new Phrase("Tax Amount", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontRed))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontRed))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    table2.AddCell(new PdfPCell(new Phrase("Net Total", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });


    //                    document.Add(table2);

    //                }
    //                else
    //                {
    //                    PdfPTable table2 = new PdfPTable(5);
    //                    float[] tableBody2 = { 36, 16, 16, 16, 16 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;

    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
    //                        table2.AddCell(new PdfPCell(new Phrase("TOTAL (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    else
    //                        table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {

    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";
    //                        string ProductTaxAmt = "";
    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }


    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }




    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    }
    //                    //table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    //table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    //table2.AddCell(new PdfPCell(new Phrase("Gross Total", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    //table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    //table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    //table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    //table2.AddCell(new PdfPCell(new Phrase("Net Total", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    //table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });

    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    //  table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2 });
    //                    table2.AddCell(new PdfPCell(new Phrase("Gross Total", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    table2.AddCell(new PdfPCell(new Phrase("Net Total", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });
    //                    table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });



    //                    document.Add(table2);
    //                }
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                PdfPTable tablettl = new PdfPTable(2);
    //                float[] tablettlBody = { 0, 100 };
    //                tablettl.SetWidths(tablettlBody);
    //                tablettl.WidthPercentage = 100;

    //                tablettl.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                tablettl.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontBlue });
    //                document.Add(tablettl);


    //            }


    //            string CheckedBy = "";
    //            if (dt.Rows[0]["PURCHS_CNFRM_STS"].ToString() == "1")
    //            {
    //                CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
    //            }

    //            var FontColourPrprd = new BaseColor(33, 150, 243);
    //            var FontColourChkd = new BaseColor(76, 175, 80);
    //            var FontColourAuthrsd = new BaseColor(255, 87, 34);
    //            PdfPTable table3 = new PdfPTable(3);
    //            float[] tableBody3 = { 33, 33, 33 };
    //            table3.SetWidths(tableBody3);
    //            table3.WidthPercentage = 100;
    //            table3.TotalWidth = 600F;

    //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourPrprd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourChkd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourAuthrsd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });

    //            table3.WriteSelectedRows(0, -1, 0, 80, writer.DirectContent);




    //            document.Close();
    //            strRet = strImagePath + strImageName;
    //        }
    //    }



    //    catch (Exception)
    //    {
    //        document.Close();
    //        strRet = "false";

    //    }

    //    return strRet;

    //}

    //public string PdfPrintVersion2(DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntityPurchaseMaster ObjEntitySales, string PreparedBy)
    //{


    //    string strRet = "true";

    //    string strId = "";
    //    strId = Convert.ToString(ObjEntitySales.PurchaseId);
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.PURCHASE_INVOICE);

    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();

    //    if (ObjEntitySales.CorpId != 0)
    //    {
    //        objEntityCommon.CorporateID = ObjEntitySales.CorpId;
    //    }
    //    if (ObjEntitySales.OrgId != 0)
    //    {
    //        objEntityCommon.Organisation_Id = ObjEntitySales.OrgId;
    //    }

    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_PRINT);
    //    string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);

    //    string strImageName = "Purchase_Invoice" + strId + "_" + strNextNumber + ".pdf";
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PURCHASE_INVOICE);

    //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {

    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {

    //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);

    //            PdfWriter writer = PdfWriter.GetInstance(document, file);
    //            document.Open();

    //            //  string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "corporate-logo.jpg";
    //            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);

    //            if (dtCorp.Rows.Count > 0)
    //            {
    //                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
    //                {
    //                    string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
    //                    string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();

    //                    strImageLogo = imaeposition + icon;
    //                    //objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + dtCorp.Rows[0]["CORPRT_ICON"].ToString();
    //                }
    //            }

    //            var FontBlue = new BaseColor(0, 174, 239);
    //            var FontBlueGrey = new BaseColor(79, 167, 206);

    //            PdfPTable headImg = new PdfPTable(2);

    //            if (strImageLogo != "")
    //            {


    //                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(System.Web.HttpContext.Current.Server.MapPath(strImageLogo));

    //                image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //                image.ScaleToFit(100f, 80f);

    //                headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });


    //            }
    //            else
    //            {
    //                headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
    //            }
    //                headImg.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
    //            float[] headersHeading = { 60, 40 };
    //            headImg.SetWidths(headersHeading);
    //            headImg.WidthPercentage = 100;

    //            document.Add(headImg);



    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;
    //            string SupName = "";
    //            string AddOne = "";
    //            string AddTwo = "";
    //            string AddThree = "";
    //            if (dt.Rows[0]["PURCH_SUP_TYP"].ToString() == "1")
    //            {
    //                if (dt.Rows[0]["PURCH_SUP_NAME"].ToString() !="")
    //                {
    //                    SupName=dt.Rows[0]["PURCH_SUP_NAME"].ToString();
    //                }
    //                if (dt.Rows[0]["PURCH_SUP_ADD_ONE"].ToString() !="")
    //                {
    //                    AddOne=dt.Rows[0]["PURCH_SUP_ADD_ONE"].ToString();
    //                }
    //                      if (dt.Rows[0]["PURCH_SUP_ADD_TWO"].ToString() !="")
    //                {
    //                    AddTwo=dt.Rows[0]["PURCH_SUP_ADD_TWO"].ToString();
    //                }
    //                      if (dt.Rows[0]["PURCH_SUP_ADD_THREE"].ToString() !="")
    //                {
    //                    AddThree=dt.Rows[0]["PURCH_SUP_ADD_THREE"].ToString();
    //                }
    //            }
    //            else
    //            {
    //                if (dt.Rows[0]["SUPLIR_NAME"].ToString() != "")
    //                {
    //                    SupName = dt.Rows[0]["SUPLIR_NAME"].ToString();
    //                }
    //                else if (dt.Rows[0]["SUPPLIER"].ToString() != "")
    //                {
    //                    SupName = dt.Rows[0]["SUPPLIER"].ToString();
    //                }
    //                if (dt.Rows[0]["SUPLIR_ADDRESS"].ToString() != "")
    //                {
    //                    AddOne = dt.Rows[0]["SUPLIR_ADDRESS"].ToString();
    //                }
    //                if (dt.Rows[0]["SUPLIR_ADDRESS2"].ToString() != "")
    //                {
    //                    AddTwo = dt.Rows[0]["SUPLIR_ADDRESS2"].ToString();
    //                }
    //                if (dt.Rows[0]["SUPLIR_ADDRESS3"].ToString() != "")
    //                {
    //                    AddThree = dt.Rows[0]["SUPLIR_ADDRESS3"].ToString();
    //                }

    //            }
    //            if (dt.Rows[0]["PURCHS_CNFRM_STS"].ToString() == "1")
    //                footrtable.AddCell(new PdfPCell(new Phrase("PURCHASE INVOICE", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 15 });

    //            else
    //                footrtable.AddCell(new PdfPCell(new Phrase("DRAFT PURCHASE INVOICE", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 15 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["PURCHS_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            footrtable.AddCell(new PdfPCell(new Phrase("To", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 20 });

    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            footrtable.AddCell(new PdfPCell(new Phrase(SupName.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(AddOne.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(AddTwo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(AddThree.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                
    //            document.Add(footrtable);
    //            string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "", ntttlWord = "";
    //            decimal grosttl = 0, taxttl = 0, discnt = 0, netTottl;

    //            var FontGrey = new BaseColor(134, 152, 160);
    //            var FontBordrGrey = new BaseColor(236, 236, 236);
    //            if (dtProduct.Rows.Count > 0)
    //            {

    //                if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() == "")
    //                {
    //                    if (dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString() != "")
    //                    {
    //                        grossTotal = dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString();
    //                        grosttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
    //                        grossTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString() != "")
    //                    {
    //                        taxTotal = dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString();
    //                        taxttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
    //                        taxTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["PURCHS_DISCOUNT"].ToString() != "")
    //                    {
    //                        discTotal = dt.Rows[0]["PURCHS_DISCOUNT"].ToString();
    //                        discnt = Convert.ToDecimal(dt.Rows[0]["PURCHS_DISCOUNT"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
    //                        discTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
    //                    {

    //                        netTottl = (grosttl + taxttl) - discnt;

    //                        // netTotal = dt.Rows[0]["PURCHS_NET_TOTAL"].ToString();
    //                        netTotal = netTottl.ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
    //                        netTotal = strNetAmountDebitComma;
    //                    }
    //                }
    //                else
    //                {
    //                    if (dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString() != "")
    //                    {
    //                        grossTotal = dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString();
    //                        grosttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
    //                        grossTotal = strNetAmountDebitComma ;
    //                    }



    //                    if (dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString() != "")
    //                    {

    //                        taxTotal = dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString();
    //                        taxttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
    //                        taxTotal = strNetAmountDebitComma ;

    //                    }
    //                    if (dt.Rows[0]["PURCHS_DISCOUNT"].ToString() != "")
    //                    {


    //                        discTotal = dt.Rows[0]["PURCHS_DISCOUNT"].ToString();
    //                        discnt = Convert.ToDecimal(dt.Rows[0]["PURCHS_DISCOUNT"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
    //                        discTotal = strNetAmountDebitComma ;
    //                    }
    //                    if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
    //                    {


    //                        netTottl = (grosttl + taxttl) - discnt;

    //                        netTotal = netTottl.ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
    //                        netTotal = strNetAmountDebitComma ;
    //                    }
    //                }
    //                string strcurrenWord = "";
    //                if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
    //                {
    //                    clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
    //                    netTottl = (grosttl + taxttl) - discnt;

    //                    ntttlWord = netTottl.ToString();
    //                    strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, ntttlWord);

    //                }

    //                var FontRed = new BaseColor(202, 3, 20);
    //                var FontGreen = new BaseColor(46, 179, 51);
    //                var FontGray = new BaseColor(138, 138, 138);
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                if (TaxEnable == 1)
    //                {


    //                    PdfPTable table2 = new PdfPTable(8);
    //                    float[] tableBody2 = { 5, 25, 9, 10, 7, 10, 20, 14 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("SL#", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString()+")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                   else
    //                       table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {

    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";
    //                        string ProductTaxAmt = "";
    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_TAX_AMT"].ToString() != "")
    //                        {
    //                            ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_TAX_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
    //                            ProductTaxAmt = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }

    //                        string strRemarks = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_REMARK"].ToString() != "")
    //                            strRemarks = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_REMARK"].ToString();
    //                        int SlNo = intRowBodyCount + 1;
    //                        table2.AddCell(new PdfPCell(new Phrase(SlNo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(strRemarks, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2,  BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6,BorderColor = FontGray, BorderWidthBottom = 0,BorderWidthRight=0 });

    //                    table2.AddCell(new PdfPCell(new Phrase("Total ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                       
    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthTop = 0,BorderWidthRight=0 });

    //                    table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                       
    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthTop = 0,BorderWidthRight=0 });

    //                    table2.AddCell(new PdfPCell(new Phrase("Tax", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthTop = 0, BorderWidthLeft = 0 });
    //                    table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                     

    //                    document.Add(table2);

    //                }
    //                else
    //                {
    //                    PdfPTable table2 = new PdfPTable(7);
    //                    float[] tableBody2 = { 5, 32, 10, 11, 12, 16, 14 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("Sl#", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
    //                        table2.AddCell(new PdfPCell(new Phrase("TOTAL (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    else
    //                        table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {

    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";
    //                        string ProductTaxAmt = "";
    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }


    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }
    //                        string strRemarks = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_REMARK"].ToString() != "")
    //                            strRemarks = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_REMARK"].ToString();
    //                        int SlNo = intRowBodyCount + 1;
    //                        table2.AddCell(new PdfPCell(new Phrase(SlNo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(strRemarks, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthRight = 0 });

    //                    table2.AddCell(new PdfPCell(new Phrase("Total ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });

    //                    table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });



    //                    document.Add(table2);
    //                }

    //                PdfPTable tablettl = new PdfPTable(2);
    //                float[] tablettlBody = { 86, 14 };
    //                tablettl.SetWidths(tablettlBody);
    //                tablettl.WidthPercentage = 100;
    //                tablettl.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                tablettl.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                document.Add(tablettl);

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                PdfPTable footrtables = new PdfPTable(2);
    //                float[] footrsBodys = { 30, 70 };
    //                footrtables.SetWidths(footrsBodys);
    //                footrtables.WidthPercentage = 100;
    //                string OrderNo = "";
    //                string strTerms = "";
    //                string strDescription = "";
    //                if (dt.Rows[0]["PURCHS_ORDERNO"].ToString() != "")
    //                    OrderNo = dt.Rows[0]["PURCHS_ORDERNO"].ToString();
    //                if (dt.Rows[0]["PURCHS_DESCRIPTION"].ToString() != "")
    //                    strDescription = dt.Rows[0]["PURCHS_DESCRIPTION"].ToString();
    //                if (dt.Rows[0]["PURCHS_TERMS"].ToString() != "")
    //                    strTerms = dt.Rows[0]["PURCHS_TERMS"].ToString();
    //                footrtables.AddCell(new PdfPCell(new Phrase("Purchase Order No.", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtables.AddCell(new PdfPCell(new Phrase(": " + OrderNo, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtables.AddCell(new PdfPCell(new Phrase("Reference No.", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["PURCHS_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtables.AddCell(new PdfPCell(new Phrase("Remarks", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtables.AddCell(new PdfPCell(new Phrase(": " + strDescription, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtables.AddCell(new PdfPCell(new Phrase("Terms", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtables.AddCell(new PdfPCell(new Phrase(": " + strTerms, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                   
    //                document.Add(footrtables);
    //            }


    //            string CheckedBy = "";
    //            if (dt.Rows[0]["PURCHS_CNFRM_STS"].ToString() == "1")
    //            {
    //                CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
    //            }

    //            var FontColourPrprd = new BaseColor(33, 150, 243);
    //            var FontColourChkd = new BaseColor(76, 175, 80);
    //            var FontColourAuthrsd = new BaseColor(255, 87, 34);
    //            PdfPTable table3 = new PdfPTable(3);
    //            float[] tableBody3 = { 33, 33, 33 };
    //            table3.SetWidths(tableBody3);
    //            table3.WidthPercentage = 100;
    //            table3.TotalWidth = 600F;

    //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //          //  table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE});
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE});
    //            table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE});
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE});
    //            table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
             
    //            table3.WriteSelectedRows(0, -1, 0, 160, writer.DirectContent);



    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            //PdfPTable pdfCorprt = new PdfPTable(2);
    //            //float[] CorprtBody = { 100, 0 };
    //            //pdfCorprt.SetWidths(CorprtBody);
    //            //pdfCorprt.WidthPercentage = 100;

    //            //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //document.Add(pdfCorprt);

    //            document.Close();
    //            strRet = strImagePath + strImageName;

    //        }
           
    //    }



    //    catch (Exception)
    //    {
    //        document.Close();
    //        strRet = "false";

    //    }

    //    return strRet;
    //}

    //public string PdfPrintVersion3(DataTable dt, DataTable dtProduct, DataTable dtCorp, clsEntityPurchaseMaster ObjEntitySales, string PreparedBy)
    //{


    //    string strRet = "true";

    //    string strId = "";
    //    strId = Convert.ToString(ObjEntitySales.PurchaseId);
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.PURCHASE_INVOICE);

    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();

    //    if (ObjEntitySales.CorpId != 0)
    //    {
    //        objEntityCommon.CorporateID = ObjEntitySales.CorpId;
    //    }
    //    if (ObjEntitySales.OrgId != 0)
    //    {
    //        objEntityCommon.Organisation_Id = ObjEntitySales.OrgId;
    //    }

    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.PURCHASE_PRINT);
    //    string strNextNumber = objBusiness.ReadNextNumberSequanceForUI(objEntityCommon);

    //    string strImageName = "Purchase_Invoice" + strId + "_" + strNextNumber + ".pdf";
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.PURCHASE_INVOICE);

    //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {

    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {

    //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);

    //            PdfWriter writer = PdfWriter.GetInstance(document, file);
    //            document.Open();

    //            //  string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.CORPORATE_LOGOS) + "corporate-logo.jpg";
    //            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);

    //            if (dtCorp.Rows.Count > 0)
    //            {
    //                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
    //                {
    //                    string imaeposition = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit);
    //                    string icon = dtCorp.Rows[0]["CORPRT_ICON"].ToString();

    //                    strImageLogo = imaeposition + icon;
    //                }
    //            }

    //            var FontBlue = new BaseColor(0, 174, 239);
    //            var FontBlueGrey = new BaseColor(79, 167, 206);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;
    //            string SupName = "";
    //            string AddOne = "";
    //            string AddTwo = "";
    //            string AddThree = "";
    //            if (dt.Rows[0]["PURCH_SUP_TYP"].ToString() == "1")
    //            {
    //                if (dt.Rows[0]["PURCH_SUP_NAME"].ToString() != "")
    //                {
    //                    SupName = dt.Rows[0]["PURCH_SUP_NAME"].ToString();
    //                }
    //                if (dt.Rows[0]["PURCH_SUP_ADD_ONE"].ToString() != "")
    //                {
    //                    AddOne = dt.Rows[0]["PURCH_SUP_ADD_ONE"].ToString();
    //                }
    //                if (dt.Rows[0]["PURCH_SUP_ADD_TWO"].ToString() != "")
    //                {
    //                    AddTwo = dt.Rows[0]["PURCH_SUP_ADD_TWO"].ToString();
    //                }
    //                if (dt.Rows[0]["PURCH_SUP_ADD_THREE"].ToString() != "")
    //                {
    //                    AddThree = dt.Rows[0]["PURCH_SUP_ADD_THREE"].ToString();
    //                }
    //            }
    //            else
    //            {
    //                if (dt.Rows[0]["SUPLIR_NAME"].ToString() != "")
    //                {
    //                    SupName = dt.Rows[0]["SUPLIR_NAME"].ToString();
    //                }
    //                else if (dt.Rows[0]["SUPPLIER"].ToString() != "")
    //                {
    //                    SupName = dt.Rows[0]["SUPPLIER"].ToString();
    //                }
    //                if (dt.Rows[0]["SUPLIR_ADDRESS"].ToString() != "")
    //                {
    //                    AddOne = dt.Rows[0]["SUPLIR_ADDRESS"].ToString();
    //                }
    //                if (dt.Rows[0]["SUPLIR_ADDRESS2"].ToString() != "")
    //                {
    //                    AddTwo = dt.Rows[0]["SUPLIR_ADDRESS2"].ToString();
    //                }
    //                if (dt.Rows[0]["SUPLIR_ADDRESS3"].ToString() != "")
    //                {
    //                    AddThree = dt.Rows[0]["SUPLIR_ADDRESS3"].ToString();
    //                }

    //            }

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            if (dt.Rows[0]["PURCHS_CNFRM_STS"].ToString() == "1")
    //                footrtable.AddCell(new PdfPCell(new Phrase("PURCHASE INVOICE", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 15 });

    //            else
    //                footrtable.AddCell(new PdfPCell(new Phrase("DRAFT PURCHASE INVOICE", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 15 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["PURCHS_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            footrtable.AddCell(new PdfPCell(new Phrase("To", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 20 });

    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            footrtable.AddCell(new PdfPCell(new Phrase(SupName.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(AddOne.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(AddTwo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(AddThree.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            document.Add(footrtable);
    //            string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "", ntttlWord = "";
    //            decimal grosttl = 0, taxttl = 0, discnt = 0, netTottl;

    //            var FontGrey = new BaseColor(134, 152, 160);
    //            var FontBordrGrey = new BaseColor(236, 236, 236);
    //            if (dtProduct.Rows.Count > 0)
    //            {

    //                if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() == "")
    //                {
    //                    if (dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString() != "")
    //                    {
    //                        grossTotal = dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString();
    //                        grosttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
    //                        grossTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString() != "")
    //                    {
    //                        taxTotal = dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString();
    //                        taxttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
    //                        taxTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["PURCHS_DISCOUNT"].ToString() != "")
    //                    {
    //                        discTotal = dt.Rows[0]["PURCHS_DISCOUNT"].ToString();
    //                        discnt = Convert.ToDecimal(dt.Rows[0]["PURCHS_DISCOUNT"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
    //                        discTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
    //                    {

    //                        netTottl = (grosttl + taxttl) - discnt;

    //                        // netTotal = dt.Rows[0]["PURCHS_NET_TOTAL"].ToString();
    //                        netTotal = netTottl.ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
    //                        netTotal = strNetAmountDebitComma;
    //                    }
    //                }
    //                else
    //                {
    //                    if (dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString() != "")
    //                    {
    //                        grossTotal = dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString();
    //                        grosttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_GROSS_TOTAL"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);
    //                        grossTotal = strNetAmountDebitComma;
    //                    }



    //                    if (dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString() != "")
    //                    {

    //                        taxTotal = dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString();
    //                        taxttl = Convert.ToDecimal(dt.Rows[0]["PURCHS_TAX_TOTAL"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);
    //                        taxTotal = strNetAmountDebitComma;

    //                    }
    //                    if (dt.Rows[0]["PURCHS_DISCOUNT"].ToString() != "")
    //                    {


    //                        discTotal = dt.Rows[0]["PURCHS_DISCOUNT"].ToString();
    //                        discnt = Convert.ToDecimal(dt.Rows[0]["PURCHS_DISCOUNT"].ToString());
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
    //                        discTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
    //                    {


    //                        netTottl = (grosttl + taxttl) - discnt;

    //                        netTotal = netTottl.ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
    //                        netTotal = strNetAmountDebitComma;
    //                    }
    //                }
    //                string strcurrenWord = "";
    //                if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
    //                {
    //                    clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
    //                    netTottl = (grosttl + taxttl) - discnt;

    //                    ntttlWord = netTottl.ToString();
    //                    strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, ntttlWord);

    //                }

    //                var FontRed = new BaseColor(202, 3, 20);
    //                var FontGreen = new BaseColor(46, 179, 51);
    //                var FontGray = new BaseColor(138, 138, 138);
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                if (TaxEnable == 1)
    //                {


    //                    PdfPTable table2 = new PdfPTable(8);
    //                    float[] tableBody2 = { 5, 25, 9, 10, 7, 10, 20, 14 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("SL#", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
    //                        table2.AddCell(new PdfPCell(new Phrase("TOTAL (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    else
    //                        table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {

    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";
    //                        string ProductTaxAmt = "";
    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_TAX_AMT"].ToString() != "")
    //                        {
    //                            ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_TAX_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
    //                            ProductTaxAmt = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }
    //                        string strRemarks = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_REMARK"].ToString() != "")
    //                            strRemarks = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_REMARK"].ToString();
    //                        int SlNo = intRowBodyCount + 1;
    //                        table2.AddCell(new PdfPCell(new Phrase(SlNo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(strRemarks, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthRight = 0 });

    //                    table2.AddCell(new PdfPCell(new Phrase("Total ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });

    //                    table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });

    //                    table2.AddCell(new PdfPCell(new Phrase("Tax", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthTop = 0, BorderWidthLeft = 0 });
    //                    table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                    document.Add(table2);

    //                }
    //                else
    //                {
    //                    PdfPTable table2 = new PdfPTable(7);
    //                    float[] tableBody2 = { 5, 32, 10, 11, 12, 16, 14 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("Sl#", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
    //                        table2.AddCell(new PdfPCell(new Phrase("TOTAL (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    else
    //                        table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {

    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";
    //                        string ProductTaxAmt = "";
    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_DISCNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }


    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }
    //                        string strRemarks = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_REMARK"].ToString() != "")
    //                            strRemarks = dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_REMARK"].ToString();
    //                        int SlNo = intRowBodyCount + 1;
    //                        table2.AddCell(new PdfPCell(new Phrase(SlNo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PURCHS_PRDUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(strRemarks, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan =5, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthRight = 0 });

    //                    table2.AddCell(new PdfPCell(new Phrase("Total ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5, BorderColor = FontGray, BorderWidthBottom = 0, BorderWidthTop = 0, BorderWidthRight = 0 });

    //                    table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray, BorderWidthTop = 0, BorderWidthBottom = 0, BorderWidthLeft = 0 });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });



    //                    document.Add(table2);
    //                }

    //                PdfPTable tablettl = new PdfPTable(2);
    //                float[] tablettlBody = { 86, 14 };
    //                tablettl.SetWidths(tablettlBody);
    //                tablettl.WidthPercentage = 100;
    //                tablettl.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                tablettl.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                document.Add(tablettl);

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            }


    //            string CheckedBy = "";
    //            if (dt.Rows[0]["PURCHS_CNFRM_STS"].ToString() == "1")
    //            {
    //                CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
    //            }

    //            var FontColourPrprd = new BaseColor(33, 150, 243);
    //            var FontColourChkd = new BaseColor(76, 175, 80);
    //            var FontColourAuthrsd = new BaseColor(255, 87, 34);
    //            PdfPTable table3 = new PdfPTable(3);
    //            float[] tableBody3 = { 33, 33, 33 };
    //            table3.SetWidths(tableBody3);
    //            table3.WidthPercentage = 100;
    //            table3.TotalWidth = 600F;

    //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //            //  table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //            table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            table3.WriteSelectedRows(0, -1, 0, 160, writer.DirectContent);

    //            document.Close();
    //            strRet = strImagePath + strImageName;

    //        }

    //    }



    //    catch (Exception)
    //    {
    //        document.Close();
    //        strRet = "false";

    //    }

    //    return strRet;
    //}
    
    protected void btnSupplier_Click(object sender, EventArgs e)
    {
        CustomerLedgerLoad();
        if (HiddenSupplierId.Value != "")
        {
            if (ddlCustomerLdgr.Items.FindByValue(HiddenSupplierId.Value.ToString()) != null)
            {
                ddlCustomerLdgr.Items.FindByValue(HiddenSupplierId.Value.ToString()).Selected = true;
            }

            else
            {
                //ListItem lstGrp = new ListItem(strProjectName, HiddenSupplierId.Value.ToString());
                //ddlCustomerLdgr.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCustomerLdgr);
                ddlCustomerLdgr.ClearSelection();
                if (ddlCustomerLdgr.Items.FindByValue(HiddenSupplierId.Value.ToString()) != null)
                {
                    ddlCustomerLdgr.Items.FindByValue(HiddenSupplierId.Value.ToString()).Selected = true;
                }
            }

        }

    }
    [WebMethod]
    public static string RedPrdtName(string intProductId, string intuserid, string intorgid, string intcorpid)
    {

        string result = "";
        clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
        clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
        objEntityPurchase.OrgId = Convert.ToInt32(intorgid);
        objEntityPurchase.ProductId = Convert.ToInt32(intProductId);
        objEntityPurchase.CorpId = Convert.ToInt32(intcorpid);
        if (intProductId != "")
        {
            DataTable dtSubConrt = objBusinesspurchase.ReadProductName(objEntityPurchase);
            if (dtSubConrt.Rows.Count > 0)
            {
                result = dtSubConrt.Rows[0][0].ToString();
            }

        }
        return result;
    }

    public void CostCenterLoad()
    {
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();

        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
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
        DataTable dtLedger = objBussiness.ReadCostCenter(ObjEntityRequest);


        if (dtLedger.Rows.Count > 0)
        {
            dtLedger.TableName = "dtTableCostCenter";
            string result;
            using (StringWriter sw = new StringWriter())
            {
                dtLedger.WriteXml(sw);
                result = sw.ToString();
            }
            hiddenCostCenterddl.Value = result;
        }
    }
    public void CostGroup1Load()
    {

        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();

        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();




        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
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
        DataTable dtLedger = objBussiness.ReadCostGroup1(ObjEntityRequest);

        if (dtLedger.Rows.Count > 0)
        {
            dtLedger.TableName = "dtTableCostCenter";
            string result;
            using (StringWriter sw = new StringWriter())
            {
                dtLedger.WriteXml(sw);
                result = sw.ToString();
            }
            HiddenCostGroup1ddl.Value = result;
        }
    }
    public void CostGroup2Load()
    {
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();

        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
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
        DataTable dtLedger = objBussiness.ReadCostGroup2(ObjEntityRequest);


        if (dtLedger.Rows.Count > 0)
        {
            dtLedger.TableName = "dtTableCostCenter";
            string result;
            using (StringWriter sw = new StringWriter())
            {
                dtLedger.WriteXml(sw);
                result = sw.ToString();
            }
            HiddenCostGroup2ddl.Value = result;
        }
    }


}

