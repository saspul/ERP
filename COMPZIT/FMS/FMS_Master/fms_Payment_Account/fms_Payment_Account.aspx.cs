using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using System.Data;
using System.Text;
using System.Web.Services;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
//using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;

public partial class FMS_FMS_Master_fms_Payment_Account_fms_Payment_Account : System.Web.UI.Page
{
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
        ddlAccontLed.Focus();
        if (!IsPostBack)
        {
            hiddenLedgerddl.Value = "0";
            hiddenCostCenterddl.Value = "0";
            HiddenCostGroup1ddl.Value = "0";
            HiddenCostGroup2ddl.Value = "0";
            AccountLedgerLoad();
            CostCenterLoad();
            CostGroup1Load();
            CostGroup2Load();
            LeadgerLoad();
            CurrencyLoad();
            HiddenView.Value = "";
            HiddenFieldTaxId.Value = "";
            //   Hiddentxtefctvedate.Value = DateTime.Now.ToString("dd-MM-yyyy");

            //txtFromdate
            btnPRintCheque.Visible = false;
            btnFloatPRintCheque.Visible = false;

            HiddenChkSts.Value = "1";
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;
            btnFloatUpdate.Visible = false;
            btnFloatUpdateCls.Visible = false;
            HiddenRefAccountCls.Value = "0";
            btnReopen.Visible = false;
            btnFloatReopen.Visible = false;
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
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
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            HiddenPresentDate.Value = objBusiness.LoadCurrentDate().ToString("dd-MM-yyyy");
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();
            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PAYMENT_ACCOUNT);
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                              clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS,
                                                              clsCommonLibrary.CORP_GLOBAL.GN_REMOVE_RESTRCTNS_STS,
                                                              clsCommonLibrary.CORP_GLOBAL.FMS_LDGR_DUPLICATION
                                                       };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                HiddenRefAccountCls.Value = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
                HiddenRestritionStatus.Value = dtCorpDetail.Rows[0]["GN_REMOVE_RESTRCTNS_STS"].ToString();
                HiddenLedgrDupSts.Value = dtCorpDetail.Rows[0]["FMS_LDGR_DUPLICATION"].ToString();
            }
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                HiddenCurrencyAbrv.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_PAYMENT);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);
            DataTable dtFormate = objBussinessPayment.readRefFormate(objEntityCommon);
            string CurrentDate = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
            DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
            int DtYear = dtCurrentDate.Year;
            int DtMonth = dtCurrentDate.Month;
            string dtyy = dtCurrentDate.ToString("yy");

            if (Session["FINCYRID"] != null)
            {
                objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }

            DataTable dtCurrentFiscalYr = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
            DateTime dtFinStartDate = new DateTime();
            DateTime dtFinEndDate = new DateTime();
            if (dtCurrentFiscalYr.Rows.Count > 0)
            {
                dtFinStartDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_START_DT"].ToString());
                dtFinEndDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_END_DT"].ToString());
            }

            string refFormatByDiv = "";
            string strRealFormat = "";
            if (dtFormate.Rows.Count > 0)
            {
                if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                {
                    refFormatByDiv = dtFormate.Rows[0]["REF_FORMATE"].ToString();
                    string strReferenceFormat = "";
                    strReferenceFormat = refFormatByDiv;
                    int flag = 0;
                    string[] arrReferenceSplit = strReferenceFormat.Split('*');
                    int intArrayRowCount = arrReferenceSplit.Length;
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

                    //2019
                    if (strRealFormat.Contains("#YER#"))
                    {
                        strRealFormat = strRealFormat.Replace("#YER#", DtYear.ToString());
                    }
                    if (strRealFormat.Contains("#FYERS#"))
                    {
                        strRealFormat = strRealFormat.Replace("#FYERS#", dtFinStartDate.Year.ToString());
                    }
                    if (strRealFormat.Contains("#FYERE#"))
                    {
                        strRealFormat = strRealFormat.Replace("#FYERE#", dtFinEndDate.Year.ToString());
                    }

                    //19
                    if (strRealFormat.Contains("#YY#"))
                    {
                        strRealFormat = strRealFormat.Replace("#YY#", dtyy.ToString());
                    }
                    if (strRealFormat.Contains("#FYYS#"))
                    {
                        strRealFormat = strRealFormat.Replace("#FYYS#", dtFinStartDate.ToString("yy"));
                    }
                    if (strRealFormat.Contains("#FYYE#"))
                    {
                        strRealFormat = strRealFormat.Replace("#FYYE#", dtFinEndDate.ToString("yy"));
                    }

                    if (strRealFormat.Contains("#MON#"))
                    {
                        strRealFormat = strRealFormat.Replace("#MON#", DtMonth.ToString());
                    }
                    if (strRealFormat.Contains("#NUM#"))
                    {
                        strRealFormat = strRealFormat.Replace("#NUM#", strNextId);
                    }
                    else
                    {
                        strRealFormat = strRealFormat + "/" + strNextId;
                    }
                    strRealFormat = strRealFormat.Replace("#", "");
                    strRealFormat = strRealFormat.Replace("*", "");
                    strRealFormat = strRealFormat.Replace("%", "");
                }
                TxtRef.Value = strRealFormat;
            }
            else
            {
                TxtRef.Value = strNextId;
            }

            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PAYMENT_ACCOUNT);
            int confirm = 0, intAccntCloseReopen = 0;
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenReOpenStatus.Value = "0";
            HiddenFieldAcntCloseReopenSts.Value = "0";
            HiddenAuditProvisionStatus.Value = "0";
            HiddenConfirmProvisionStatus.Value = "0";
            divRecur.Visible = false;
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {

                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        confirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenConfirmProvisionStatus.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldAcntCloseReopenSts.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        HiddenReOpenStatus.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        HiddenAuditProvisionStatus.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString())
                    {
                        divRecur.Visible = true;
                    }
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

            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
            DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objEntityCommon);
            DataTable dtAuditClsDate = objBusinessLayer.ReadLastAuditClose(objEntityCommon);

            int YearEndCls = 0;

            if (Session["FINCYRID"] != null)
            {
                objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            DataTable dtYearEndClsDate = objBusinessLayer.ReadYearEndCloseDate(objEntityCommon);
            if (dtYearEndClsDate.Rows.Count > 0)
            {
                YearEndCls = 1;
            }

            if (dtfinaclYear.Rows.Count > 0)
            {
                if (dtfinaclYear.Rows[0]["FINCYR_ID"].ToString() != "")
                {
                    HiddenFinancialYearId.Value = dtfinaclYear.Rows[0]["FINCYR_ID"].ToString();
                }
                if (dtAuditClsDate.Rows.Count > 0 && dtAcntClsDate.Rows.Count > 0)
                {
                    HiddenAuditClsDate.Value = dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString();
                    HiddenAcntClsDate.Value = dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString();

                    if (HiddenAuditProvisionStatus.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                    {
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenFinancialYrStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    }
                    else
                    {

                        DateTime startDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());

                        DateTime startDate1 = objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());

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
                            if (HiddenAuditProvisionStatus.Value != "1")
                            {
                                startDate = startDate1;
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
                    DateTime curdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    if (curdate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        if (HiddenStartDate.Value != "")
                        {
                            DateTime startDate = objCommon.textToDateTime(HiddenStartDate.Value);
                            if (HiddenAuditProvisionStatus.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                            }
                            else
                            {
                                if (dtAuditClsDate.Rows.Count > 0 && dtAcntClsDate.Rows.Count > 0)
                                {
                                    if (startDate <= curdate)
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
                        string Ref = "";

                        if (curdate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {

                            DateTime startDate = objCommon.textToDateTime(HiddenStartDate.Value);
                            if (HiddenAuditProvisionStatus.Value == "1")
                            {
                                if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                {
                                    txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                                    objEntityAudit.FromDate = objCommon.textToDateTime(txtdate.Value);
                                    clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
                                    clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                                    clsEntityPaymentAccount objEntity = new clsEntityPaymentAccount();
                                    clsBusiness_PaymentAccount objBussinesspayment = new clsBusiness_PaymentAccount();
                                    objEntity.FromDate = objCommon.textToDateTime(txtdate.Value);
                                    objEntityAccnt.FromDate = objCommon.textToDateTime(txtdate.Value);
                                    objEntityAudit.Corporate_id = intCorpId;
                                    objEntityAccnt.Corporate_id = intCorpId;
                                    objEntity.Corporate_id = intCorpId;
                                    objEntityAccnt.Organisation_id = intOrgId;
                                    objEntityAudit.Organisation_id = intOrgId;
                                    objEntity.Organisation_id = intOrgId;
                                    int SubRef = 1;
                                    DataTable dtAuditCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);
                                    DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                    if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                                    {
                                        DataTable dtRefFormat = objBussinesspayment.ReadRefNumberByDate(objEntity);
                                        DataTable dtRefFormat1 = objBussinesspayment.ReadRefNumberByDate(objEntity);
                                        string strRef = "";

                                        if (dtRefFormat1.Rows.Count > 0)
                                        {
                                            if (dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "")
                                            {
                                                if (dtRefFormat1.Rows.Count > 0)
                                                {
                                                    if (Convert.ToInt32(dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString()) != 1)
                                                    {
                                                        strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                                                        strRef = strRef.TrimEnd('/');
                                                        strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                                    }
                                                    else
                                                    {
                                                        strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                                                    }
                                                }
                                                else
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                                                }
                                            }
                                            objEntity.RefNum = strRef;
                                            if (dtRefFormat.Rows.Count > 0)
                                            {
                                                Ref = dtRefFormat.Rows[0]["PAYMNT_REF"].ToString();
                                                if (dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != null)
                                                {
                                                    SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString());
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
                                                TxtRef.Value = Ref;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (dtAuditClsDate.Rows.Count > 0 || dtAcntClsDate.Rows.Count > 0)
                                {
                                    if (startDate <= curdate)
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
                }
                else if (dtAuditClsDate.Rows.Count > 0)
                {
                    HiddenAuditClsDate.Value = dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString();
                    if (HiddenAuditProvisionStatus.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                    {
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();

                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    }
                    else
                    {

                        DateTime startDate = objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());
                        if (startDate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {
                            txtdate.Disabled = true;
                            HiddenAcntClsSts.Value = "1";
                        }
                        else
                        {
                            HiddenStartDate.Value = startDate.AddDays(1).ToString("dd-MM-yyyy");
                            HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                        }
                    }
                    DateTime curdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    if (curdate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        if (dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString() != "")
                        {
                            DateTime startDate = objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());
                            if (HiddenAuditProvisionStatus.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                            }
                            else
                            {
                                if (dtAuditClsDate.Rows.Count > 0)
                                {
                                    if (startDate <= curdate)
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
                    string Ref = "";

                    if (curdate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {

                        DateTime startDate = objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());
                        if (HiddenAuditProvisionStatus.Value == "1")
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                                objEntityAudit.FromDate = objCommon.textToDateTime(txtdate.Value);

                                clsEntityPaymentAccount objEntity = new clsEntityPaymentAccount();
                                clsBusiness_PaymentAccount objBussinesspayment = new clsBusiness_PaymentAccount();
                                objEntity.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAudit.Corporate_id = intCorpId;
                                objEntity.Corporate_id = intCorpId;
                                objEntityAudit.Organisation_id = intOrgId;
                                objEntity.Organisation_id = intOrgId;
                                int SubRef = 1;
                                DataTable dtAccntCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);
                                if (dtAccntCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat = objBussinesspayment.ReadRefNumberByDate(objEntity);
                                    DataTable dtRefFormat1 = objBussinesspayment.ReadRefNumberByDate(objEntity);
                                    string strRef = "";

                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        if (dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "")
                                        {
                                            if (dtRefFormat1.Rows.Count > 0)
                                            {
                                                if (Convert.ToInt32(dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString()) != 1)
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                                                    strRef = strRef.TrimEnd('/');
                                                    strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                                }
                                                else
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                                                }
                                            }
                                            else
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                                            }
                                        }
                                        objEntity.RefNum = strRef;
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["PAYMNT_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString());
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
                                            TxtRef.Value = Ref;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (dtAuditClsDate.Rows.Count > 0)
                            {
                                if (startDate <= curdate)
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
                else if (dtAcntClsDate.Rows.Count > 0)
                {
                    HiddenAcntClsDate.Value = dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString();
                    if (HiddenFieldAcntCloseReopenSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                    {
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    }
                    else
                    {

                        DateTime startDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());

                        if (startDate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {

                            txtdate.Disabled = true;
                            HiddenAcntClsSts.Value = "1";


                        }
                        else
                        {
                            HiddenStartDate.Value = startDate.AddDays(1).ToString("dd-MM-yyyy");
                            HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                        }
                    }
                    DateTime curdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    if (curdate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "")
                        {
                            DateTime startDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                            if (HiddenFieldAcntCloseReopenSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {
                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                            }
                            else
                            {
                                if (dtAcntClsDate.Rows.Count > 0)
                                {
                                    if (startDate <= curdate)
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

                    DateTime curntdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    string Ref = "";

                    if (curntdate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curntdate < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {

                        DateTime startDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                        if (HiddenFieldAcntCloseReopenSts.Value == "1")
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {

                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                                clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
                                clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                                objEntityAccnt.FromDate = objCommon.textToDateTime(txtdate.Value);

                                clsEntityPaymentAccount objEntity = new clsEntityPaymentAccount();
                                clsBusiness_PaymentAccount objBussinesspayment = new clsBusiness_PaymentAccount();
                                objEntity.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntity.Corporate_id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntity.Organisation_id = intOrgId;
                                int SubRef = 1;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                if (dtAccntCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat = objBussinesspayment.ReadRefNumberByDate(objEntity);
                                    DataTable dtRefFormat1 = objBussinesspayment.ReadRefNumberByDate(objEntity);
                                    string strRef = "";

                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        if (dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "")
                                        {
                                            if (dtRefFormat1.Rows.Count > 0)
                                            {
                                                if (Convert.ToInt32(dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString()) != 1)
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                                                    strRef = strRef.TrimEnd('/');
                                                    strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                                }
                                                else
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                                                }
                                            }
                                            else
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                                            }
                                        }
                                        objEntity.RefNum = strRef;
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["PAYMNT_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString());
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
                                            TxtRef.Value = Ref;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (dtAcntClsDate.Rows.Count > 0)
                            {
                                if (startDate <= curdate)
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
                    if (dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString() != "" && dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString() != "")
                    {
                        DateTime curntdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());

                        if (curntdate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curntdate < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {
                            txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                        }
                    }
                    HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    HiddenFinancialYrStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                }




            }

            btnPRint.Visible = false;
            btnFloatPrint.Visible = false;
            lblEntry.Text = "Add Payment";
            btnConfirm.Visible = false;
            btnFloatConfirm.Visible = false;



            if (Request.QueryString["Rid"] != null)
            {
                string strRandomMixedId = Request.QueryString["Rid"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                clsEntityCommon objEntityCommon1 = new clsEntityCommon();
                clsBusinessLayerFinanceHome objBusinessLayer1 = new clsBusinessLayerFinanceHome();
                objEntityCommon1.RecurSubId = Convert.ToInt32(strId);
                objEntityCommon1.CorporateID = Convert.ToInt32(intCorpId);
                DataTable dt = objBusinessLayer1.ReadOrderDtls(objEntityCommon1);//dr
                if (dt.Rows.Count > 0)
                {
                    Update(dt.Rows[0]["RECPT_ID"].ToString(), "UPDATE", confirm, YearEndCls);
                    txtdate.Value = dt.Rows[0]["REPARECSUB_DATE"].ToString();
                    //btnConfirm.Visible = false;
                    //HiddenFieldTaxId.Value = dt.Rows[0]["RECPT_ID"].ToString();
                }
            }


            else if (Request.QueryString["Id"] != null)
            {
                btnPRint.Visible = false;
                btnFloatPrint.Visible = false;
                lblEntry.Text = "Edit Payment";
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenFieldTaxId.Value = strId;
                bttnsave.Visible = false;
                btnSaveCls.Visible = false;
                btnUpdateClose.Visible = true;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
                ButtnFloatClear.Visible = false;
                ButtnClose.Visible = false;

                bttnsave.Visible = false;
                btnFloatSaveCls.Visible = false;
                btnFloatUpdateCls.Visible = true;
                btnFloatUpdate.Visible = true;
                btnFloatCancel.Visible = true;

                Update(strId, "UPDATE", confirm, YearEndCls);

            }
            else if (Request.QueryString["ViewId"] != null)
            {

                HiddenView.Value = "1";
                lblEntry.Text = "View Payment";
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenFieldTaxId.Value = strId;
                bttnsave.Visible = false;
                btnSaveCls.Visible = false;
                btnUpdateClose.Visible = true;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
                btnConfirm.Visible = false;
                ButtnFloatClear.Visible = false;
                ButtnClose.Visible = false;
                btnFloatSave.Visible = false;
                btnFloatSaveCls.Visible = false;
                btnFloatUpdateCls.Visible = true;
                btnFloatUpdate.Visible = true;
                btnFloatCancel.Visible = true;
                btnFloatConfirm.Visible = false;
                Update(strId, "VIEW", confirm, YearEndCls);
                txtDescription.Disabled = true;
                ddlAccontLed.Enabled = false;
                ddlCurrency.Enabled = false;
            }

            if (Request.QueryString["VId"] != null)
            {
                string strVId = Request.QueryString["VId"].ToString();
                btnReopen.Visible = false;
                btnCancel.Visible = false;
                btnFloatReopen.Visible = false;
                btnFloatCancel.Visible = false;
                divLinkSection.Visible = false;
                divList.Visible = false;
                btnConfirm.Visible = false;
                btnFloatSave.Visible = false;
                btnUpdateClose.Visible = false;
                btnFloatUpdateCls.Visible = false;
                if (hiddenPostdated.Value == "1")
                {
                    if (strVId == "1")
                    {
                        btnUpdate.Visible = true;
                        btnFloatUpdate.Visible = true;
                        btnConfirm.Visible = true;
                        btnFloatConfirm.Visible = true;
                        //btnCancel.Visible = true;
                        //btnFloatCancel.Visible = true;
                    }
                }
            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessInsertion", "SuccessInsertion();", true);
                }
                else if (strInsUpd == "Upd")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdation", "SuccessUpdation();", true);
                }
                else if (strInsUpd == "UpdCancl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CanclUpdMsg", "CanclUpdMsg();", true);
                }
                else if (strInsUpd == "Reop")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopMsg", "SuccessReopMsg();", true);
                }
                else if (strInsUpd == "PrchsAmountExceeded")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PurchaseAmountExceeded", "PurchaseAmountExceeded();", true);
                }
                else if (strInsUpd == "PrchsAmtFullySettld")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PrchsAmtFullySettld", "PrchsAmtFullySettld();", true);
                }
                else if (strInsUpd == "Confrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                    //0039
                else if (strInsUpd == "AlreadyCnfm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyConfirm", "AlreadyConfirm();", true);
                }
                    //end
                else if (strInsUpd == "alrdyreopened")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alreadyreopened", "Alreadyreopened();", true);
                }
                else if (strInsUpd == "ChqDup")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ChequeNoDuplicate", "ChequeNoDuplicate();", true);
                }
            }

        }
    }

    public void Update(string strP_Id, string mode, int confirm, int YearEndCls)
    {
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();
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

        ObjEntityRequest.PaymentId = Convert.ToInt32(strP_Id);
        HiddenPaymentID.Value = strP_Id;

        int acntGrpId = 0;
        DataTable dt = objBussinessPayment.Read_PayemntByID(ObjEntityRequest);
        if (dt.Rows.Count > 0)
        {

            if (Request.QueryString["Rid"] == null)
            {
                HiddenFieldRecurrencyPeriod.Value = dt.Rows[0]["REPAREC_PERIOD"].ToString();
                HiddenFieldRemindDays.Value = dt.Rows[0]["REPAREC_REM_DAYS"].ToString();
                if (dt.Rows[0]["REPAREC_PERIOD"].ToString() != "")
                {
                    btnRecurrSave.InnerText = "Update";
                }
            }


            if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
            {
                hiddenDfltCurrencyMstrId.Value = dt.Rows[0]["CRNCMST_ID"].ToString();
            }
            if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
            {
                HiddenCurrencyAbrv.Value = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
            }

            if (dt.Rows[0][1].ToString() != "")
            {
                acntGrpId = Convert.ToInt32(dt.Rows[0][1].ToString());
                //  ChequeBookLoad(acntGrpId);
            }

            if (Request.QueryString["Rid"] == null)
            {
                if (dt.Rows[0]["PAYMNT_REF"].ToString() != "")
                {
                    TxtRef.Value = dt.Rows[0]["PAYMNT_REF"].ToString();
                    HiddenUpdRefNum.Value = dt.Rows[0]["PAYMNT_REF"].ToString();
                }
            }
            ddlAccontLed.ClearSelection();
            if (dt.Rows[0]["LDGR_NAME"].ToString() != "")
            {
                if (ddlAccontLed.Items.FindByValue(dt.Rows[0][1].ToString()) != null)
                {
                    ddlAccontLed.Items.FindByValue(dt.Rows[0][1].ToString()).Selected = true;
                }
                else
                {
                    ListItem lstGrp = new ListItem(dt.Rows[0]["LDGR_NAME"].ToString(), dt.Rows[0][1].ToString());
                    ddlAccontLed.Items.Insert(1, lstGrp);
                    SortDDL(ref this.ddlAccontLed);
                    ddlAccontLed.Items.FindByValue(dt.Rows[0][1].ToString()).Selected = true;
                }
            }
            if (Request.QueryString["Rid"] == null)
            {
                if (dt.Rows[0]["PAYMNT_DATE"].ToString() != "")
                {
                    txtdate.Value = dt.Rows[0]["PAYMNT_DATE"].ToString();
                    HiddenUpdatedDate.Value = dt.Rows[0]["PAYMNT_DATE"].ToString();
                }
            }
            ddlCurrency.ClearSelection();
            if (dt.Rows[0]["CRNCMST_NAME"].ToString() != "")
            {
                if (ddlCurrency.Items.FindByText(dt.Rows[0]["CRNCMST_NAME"].ToString()) != null)
                {
                    ddlCurrency.Items.FindByText(dt.Rows[0]["CRNCMST_NAME"].ToString()).Selected = true;
                }
            }

            if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
            {
                if (dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() != "")
                {
                    txtGrantTotal.Value = dt.Rows[0]["PURCHS_NET_TOTAL"].ToString() + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                    HiddenGrdTotl.Value = dt.Rows[0]["PURCHS_NET_TOTAL"].ToString();
                }

            }

            hiddenInsUser.Value = dt.Rows[0]["PAYMNT_EXCHANGE_RATE"].ToString();

            if (dt.Rows[0]["PAYMNT_EXCHANGE_RATE"].ToString() != "")
            {
                txtExchangeRate.Value = dt.Rows[0]["PAYMNT_EXCHANGE_RATE"].ToString();
            }
            if (dt.Rows[0]["PAYMNT_DSCRPTN"].ToString() != "")
            {
                txtDescription.Value = dt.Rows[0]["PAYMNT_DSCRPTN"].ToString();

            }
            if (dt.Rows[0]["PAYMNT_REF_SEQNUM"].ToString() != "")
            {
                HiddenSequenceRef.Value = dt.Rows[0]["PAYMNT_REF_SEQNUM"].ToString();
            }
            if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "1")
            {
                HiddenPrevTab.Value = "Cheque";
                ddlChequeBook_Cheque.ClearSelection();
                if (dt.Rows[0]["CHKBK_ID"].ToString() != "")
                {
                    //  ddlChequeBook_Cheque.Items.FindByValue(dt.Rows[0]["CHKBK_ID"].ToString()).Selected = true;
                    HiddenChequeBookId.Value = dt.Rows[0]["CHKBK_ID"].ToString();
                }
                if (Request.QueryString["Rid"] == null)
                {
                    if (dt.Rows[0]["PAYMNT_CHQ_NUMBER"].ToString() != "")
                    {
                        HiddenupdCheckNumber.Value = dt.Rows[0]["PAYMNT_CHQ_NUMBER"].ToString();
                    }
                }
                if (dt.Rows[0]["PAYMNT_ISSUE"].ToString() == "0")
                {
                    ChkStatus_Cheque.Checked = false;
                }
                else if (dt.Rows[0]["PAYMNT_ISSUE"].ToString() == "1")
                {
                    ChkStatus_Cheque.Checked = true;
                    if (Request.QueryString["Rid"] == null)
                    {
                        if (dt.Rows[0]["PAYMNT_CHQ_ISSUE_DATE"].ToString() != "")
                        {
                            txtIssueDate_Cheque.Value = dt.Rows[0]["PAYMNT_CHQ_ISSUE_DATE"].ToString();
                        }
                    }
                }
                else
                {
                    ChkStatus_Cheque.Checked = false;
                }
                if (Request.QueryString["Rid"] == null)
                {
                    if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
                    {
                        txtDate_Cheque.Value = dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString();
                    }
                }
                if (dt.Rows[0]["PAYMNT_CHQ_PAYEE"].ToString() != "")
                {
                    txtPayee.Value = dt.Rows[0]["PAYMNT_CHQ_PAYEE"].ToString();
                }
                clsBusinessLayer objBusiness = new clsBusinessLayer();
                DataTable dtLDGRdTLSaa = objBussinessPayment.Read_PayemntLedgerByID(ObjEntityRequest);
                if (dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() == "1" && dtLDGRdTLSaa.Rows.Count == 1)
                {
                    btnPRintCheque.Visible = true;
                    btnFloatPRintCheque.Visible = true;
                    if (dt.Rows[0]["CHKBK_ID"].ToString() != "")
                    {
                        ObjEntityRequest.ChequeBookId = Convert.ToInt32(dt.Rows[0]["CHKBK_ID"].ToString());
                    }
                    DataTable dtList = objBussinessPayment.ReadChequeTemId(ObjEntityRequest);
                    if (dtList.Rows.Count > 0)
                    {

                        PlblHeight.Value = dtList.Rows[0]["CHKTEMPLT_HEIGHT"].ToString();
                        PlblWidth.Value = dtList.Rows[0]["CHKTEMPLT_WIDTH"].ToString();
                        PlblPayeeLeft.Value = dtList.Rows[0]["CHKTEMPLT_PAYEE_LEFT"].ToString();
                        PlblPayeeTop.Value = dtList.Rows[0]["CHKTEMPLT_PAYEE_TOP"].ToString();
                        PlblDateLeft.Value = dtList.Rows[0]["CHKTEMPLT_DATE_LEFT"].ToString();
                        PlblDateTop.Value = dtList.Rows[0]["CHKTEMPLT_DATE_TOP"].ToString();
                        PlblAmntWordLeft.Value = dtList.Rows[0]["CHKTEMPLT_AMNTWORD1_LEFT"].ToString();
                        PlblAmntWordTop.Value = dtList.Rows[0]["CHKTEMPLT_AMNTWORD1_TOP"].ToString();
                        PlblAmntWordLeft1.Value = dtList.Rows[0]["CHKTEMPLT_AMNTWORD2_LEFT"].ToString();
                        PlblAmntWordTop1.Value = dtList.Rows[0]["CHKTEMPLT_AMNTWORD2_TOP"].ToString();
                        PlblAmntNumTop.Value = dtList.Rows[0]["CHKTEMPLT_AMNTNUM_TOP"].ToString();
                        PlblAmntNumLeft.Value = dtList.Rows[0]["CHKTEMPLT_AMNTNUM_LEFT"].ToString();
                        txtPrintPos.Value = dtList.Rows[0]["CHKTEMPLT_PRINT_POS"].ToString();

                        string str = dtList.Rows[0]["CHKTEMPLT_DATE"].ToString();
                        string str2 = dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString();
                        str2 = Regex.Replace(str2, @"-+", "");
                        string result = "";
                        for (int i = 0; i < str.Length; i++)
                        {
                            char a = str[i];
                            if (("DMY0123456789").IndexOf(str[i]) >= 0)
                            {
                                a = str2[0];
                                str2 = str2.Remove(0, 1);
                            }
                            result += a;
                        }

                        clsEntityCommon objEntityCommon = new clsEntityCommon();
                        if (hiddenDfltCurrencyMstrId.Value != "")
                        {
                            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                        }
                        string strcurrenWord = objBusiness.ConvertCurrencyToWordsWithoutCurrency(objEntityCommon, dtLDGRdTLSaa.Rows[0]["PAYMNT_LD_AMT"].ToString());

                        if (dtList.Rows[0]["CHKTEMPLT_WORDAMT_LEN"].ToString() != "")
                        {
                            int WordCount = Convert.ToInt32(dtList.Rows[0]["CHKTEMPLT_WORDAMT_LEN"].ToString());
                            if (strcurrenWord.Length > WordCount)
                            {
                                TextBox3.Value = strcurrenWord.Remove(WordCount);
                                TextBox5.Value = strcurrenWord.Substring(WordCount);
                            }
                            else
                            {
                                TextBox3.Value = strcurrenWord;
                            }
                        }
                        else
                        {
                            TextBox3.Value = strcurrenWord;
                        }

                        TextBox1.Value = dtLDGRdTLSaa.Rows[0]["PAYMNT_CHQ_PAYEE"].ToString();
                        TextBox2.Value = result;
                        //TextBox3.Value = strcurrenWord;
                        //TextBox5.Value = "";
                      TextBox4.Value=  objBusiness.AddCommasForNumberSeperation(dtLDGRdTLSaa.Rows[0]["PAYMNT_LD_AMT"].ToString(), objEntityCommon) +" " + HiddenCurrencyAbrv.Value;
                  //      TextBox4.Value = dtLDGRdTLSaa.Rows[0]["PAYMNT_LD_AMT"].ToString();
                    }
                }


            }
            else if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "2")
            {
                HiddenPrevTab.Value = "DD";
                if (Request.QueryString["Rid"] == null)
                {
                    if (dt.Rows[0]["PAYMNT_DD_NUMBER"].ToString() != "")
                    {
                        txtDD_DD.Value = dt.Rows[0]["PAYMNT_DD_NUMBER"].ToString();
                    }
                    if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
                    {
                        txtDate_DD.Value = dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString();
                    }
                }
            }
            else if (dt.Rows[0]["PAYMNT_MODE"].ToString() == "3")
            {
                HiddenPrevTab.Value = "BankTransfer";
                ddlMode_BankTransfer.ClearSelection();
                if (dt.Rows[0]["PAYMNT_BK_MODE"].ToString() != "")
                {
                    if (ddlMode_BankTransfer.Items.FindByValue(dt.Rows[0]["PAYMNT_BK_MODE"].ToString()) != null)
                    {
                        ddlMode_BankTransfer.Items.FindByValue(dt.Rows[0]["PAYMNT_BK_MODE"].ToString()).Selected = true;
                    }
                }
                if (Request.QueryString["Rid"] == null)
                {
                    if (dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString() != "")
                    {
                        txtDate_BankTransfer.Value = dt.Rows[0]["PAYMNT_CHQ_DATE"].ToString();
                    }
                }
                if (dt.Rows[0]["PAYMNT_BK_BANK"].ToString() != "")
                {
                    Bank_BankTransfer.Value = dt.Rows[0]["PAYMNT_BK_BANK"].ToString();
                }
                if (dt.Rows[0]["PAYMNT_BK_IBAN"].ToString() != "")
                {
                    IBAN_BankTransfer.Value = dt.Rows[0]["PAYMNT_BK_IBAN"].ToString();
                }
            }

        }
        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("PYMNT_ID", typeof(int));
        dtDetail.Columns.Add("PYMNT_LDGR_ID", typeof(int));
        dtDetail.Columns.Add("LDGR_ID", typeof(int));
        dtDetail.Columns.Add("LDGR_AMT", typeof(string));
        dtDetail.Columns.Add("LDGR_NAME", typeof(string));

        dtDetail.Columns.Add("PYMNT_CST_ID", typeof(int));
        dtDetail.Columns.Add("COSTCNTR_ID", typeof(string));
        dtDetail.Columns.Add("PAYMNT_LD_REMARK", typeof(string));
        dtDetail.Columns.Add("PYMNT_CST_AMT", typeof(string));
        dtDetail.Columns.Add("PURCHS_ID", typeof(string));
        dtDetail.Columns.Add("RECPT_PURCHS_REF", typeof(string));
        dtDetail.Columns.Add("COST_LD", typeof(int));
        dtDetail.Columns.Add("CHK_ID", typeof(int));
        dtDetail.Columns.Add("OB_PAID", typeof(string));
        dtDetail.Columns.Add("EXPNS_DTLS", typeof(string));

        string NewRev = "";
        DataTable dtLDGRdTLS = objBussinessPayment.Read_PayemntLedgerByID(ObjEntityRequest);
        int first = 0; int firstExp = 0;

        decimal value = 0;
        int precision = Convert.ToInt32(hiddenDecimalCount.Value);
        string format = String.Format("{{0:N{0}}}", precision);
        string valuestring = String.Format(format, value);

        for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
        {
            string searchExpression = "";
            DataRow drDtl = dtDetail.NewRow();
            drDtl["PYMNT_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PAYMNT_ID"].ToString());
            drDtl["PYMNT_LDGR_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_ID"].ToString());

            int revflg = 0;
            string[] newRev1 = NewRev.Split(',');
            for (int i = 0; i < newRev1.Length; i++)
            {
                if (newRev1[i] != dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_ID"].ToString())
                {
                    revflg = 0;
                }
                else
                {
                    revflg = 1;
                }
            }

            if (revflg == 0)
            {
                drDtl["LDGR_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                NewRev = NewRev + "," + dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_ID"].ToString();
                first = 1;
                firstExp = 1;
                for (int intCountinn = 0; intCountinn < dtLDGRdTLS.Rows.Count; intCountinn++)
                {
                    if (dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_ID"].ToString() == dtLDGRdTLS.Rows[intCountinn]["PAYMNT_LD_ID"].ToString())
                    {
                        if (dtLDGRdTLS.Rows[intCountinn]["OBPAIDAMT"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["OBBAL_AMT"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["OBBAL_AMT"].ToString() != valuestring)
                        {
                            drDtl["OB_PAID"] = dtLDGRdTLS.Rows[intCountinn]["OBPAIDAMT"].ToString() + "#" + dtLDGRdTLS.Rows[intCountinn]["OBBAL_AMT"].ToString();
                        }

                        if (first == 1)
                        {
                            //Costcentre
                            if (dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_AMT"].ToString() != "")
                            {
                                if (dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_AMT"].ToString() != "")
                                {
                                    drDtl["PYMNT_CST_AMT"] = dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_AMT"].ToString();
                                }
                                if (dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() != "")
                                {
                                    drDtl["COSTCNTR_ID"] = dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() + "%" + drDtl["PYMNT_CST_AMT"] + "%" + dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString();
                                }

                                first++;
                            }
                            //Settlemnt
                            if ((dtLDGRdTLS.Rows[intCountinn]["PURCHS_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_AMT"].ToString() != "") || (dtLDGRdTLS.Rows[intCountinn]["PURCHS_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_DEBIT_STATUS"].ToString() == "1") || (dtLDGRdTLS.Rows[intCountinn]["EXPENSE_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["EXPENSE_AMT"].ToString() != ""))
                            {
                                if (dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_AMT"].ToString() != "")
                                {
                                    drDtl["PYMNT_CST_AMT"] = dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_AMT"].ToString();
                                }
                                //if (dtLDGRdTLS.Rows[intCountinn]["PURCHS_ID"].ToString() != "")
                                //{
                                //    drDtl["PURCHS_ID"] = dtLDGRdTLS.Rows[intCountinn]["PURCHS_ID"].ToString() + "%" + drDtl["PYMNT_CST_AMT"];
                                //}
                                if (dtLDGRdTLS.Rows[intCountinn]["PURCHS_ID"].ToString() != "")
                                {
                                    drDtl["PURCHS_ID"] = dtLDGRdTLS.Rows[intCountinn]["PURCHS_ID"].ToString() + "%" + drDtl["PYMNT_CST_AMT"] + "%" + dtLDGRdTLS.Rows[intCountinn]["PURCHS_BAL_AMT"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_DEBIT_STATUS"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["DEBIT_NOTE_ID"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_DEBIT_AMT"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["LDGR_DR_REMAIN_SETTLE_AMT"].ToString() + "%1%";
                                }
                                //evm-0043 start 20-03
                                //expense settlement
                                if (dtLDGRdTLS.Rows[intCountinn]["EXPENSE_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["EXPENSE_AMT"].ToString() != "")
                                {
                                    if (dtLDGRdTLS.Rows[intCountinn]["EXPENSE_ID"].ToString() != "")
                                    {
                                        drDtl["PURCHS_ID"] = dtLDGRdTLS.Rows[intCountinn]["EXPENSE_ID"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["EXPENSE_AMT"] + "%" + dtLDGRdTLS.Rows[intCountinn]["EXPENSE_DTL_BALNC_AMT"] + "%0%" + "%%" + "%%" + "%%" + "%0%";
                                    }
                                }
                                first++;
                            }
                        }
                        else
                        {
                            if (dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_AMT"].ToString() != "")
                            {
                                if (Convert.ToDecimal(dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_AMT"].ToString()) > 0)
                                    drDtl["PYMNT_CST_AMT"] = dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_AMT"].ToString();
                                else
                                    drDtl["PYMNT_CST_AMT"] = "";
                            }

                            //Costcentre
                            if (dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() != "")
                            {
                                drDtl["COSTCNTR_ID"] = drDtl["COSTCNTR_ID"] + "$" + dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() + "%" + drDtl["PYMNT_CST_AMT"] + "%" + dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString(); ;
                            }

                            //Settlemnt
                            if (dtLDGRdTLS.Rows[intCountinn]["PURCHS_ID"].ToString() != "")
                            {
                                drDtl["PURCHS_ID"] = drDtl["PURCHS_ID"] + "$" + dtLDGRdTLS.Rows[intCountinn]["PURCHS_ID"].ToString() + "%" + drDtl["PYMNT_CST_AMT"] + "%" + dtLDGRdTLS.Rows[intCountinn]["PURCHS_BAL_AMT"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_DEBIT_STATUS"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["DEBIT_NOTE_ID"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["PAYMNT_CST_DEBIT_AMT"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["LDGR_DR_REMAIN_SETTLE_AMT"].ToString() + "%1%";
                            }
                           //Expense settlement
                            if (dtLDGRdTLS.Rows[intCountinn]["EXPENSE_ID"].ToString() != "")
                            {
                                drDtl["PURCHS_ID"] = drDtl["PURCHS_ID"] + "$" + dtLDGRdTLS.Rows[intCountinn]["EXPENSE_ID"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["EXPENSE_AMT"] + "%" + dtLDGRdTLS.Rows[intCountinn]["EXPENSE_DTL_BALNC_AMT"] + "%0%" + "%%" + "%%" + "%%" + "%0%";
                            }
                        }

                        ////0043
                        ////Expense settlement
                        //if (firstExp == 1)
                        //{
                        //    if (dtLDGRdTLS.Rows[intCountinn]["EXPENSE_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["EXPENSE_AMT"].ToString() != "")
                        //    {
                        //        if (dtLDGRdTLS.Rows[intCountinn]["EXPENSE_ID"].ToString() != "")
                        //        {
                        //            drDtl["EXPNS_DTLS"] = dtLDGRdTLS.Rows[intCountinn]["EXPENSE_ID"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["EXPENSE_AMT"] + "%" + dtLDGRdTLS.Rows[intCountinn]["EXPENSE_DTL_BALNC_AMT"];
                        //        }

                        //        firstExp++;
                        //    }
                        //}
                        //else
                        //{
                        //    if (dtLDGRdTLS.Rows[intCountinn]["EXPENSE_ID"].ToString() != "")
                        //    {
                        //        drDtl["EXPNS_DTLS"] = drDtl["EXPNS_DTLS"] + "$" + dtLDGRdTLS.Rows[intCountinn]["EXPENSE_ID"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["EXPENSE_AMT"] + "%" + dtLDGRdTLS.Rows[intCountinn]["EXPENSE_DTL_BALNC_AMT"];
                        //    }
                        //}


                    }
                }
            }
            else
            {
                drDtl["LDGR_ID"] = 0;
            }
            drDtl["LDGR_AMT"] = dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_AMT"].ToString();

            if (dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_REMARK"].ToString() != "")
            {
                drDtl["PAYMNT_LD_REMARK"] = dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_REMARK"].ToString();
            }
            if (dtLDGRdTLS.Rows[intCount]["LDGR_NAME"].ToString() != "")
            {
                drDtl["LDGR_NAME"] = dtLDGRdTLS.Rows[intCount]["LDGR_NAME"].ToString();
            }
            else
            {
                drDtl["LDGR_NAME"] = "";
            }
            if (dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_ID"].ToString() != "")
            {
                drDtl["PYMNT_CST_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_ID"].ToString());
            }
            if (HiddenChequeBookId.Value != "")
            {
                drDtl["CHK_ID"] = Convert.ToInt32(HiddenChequeBookId.Value);
            }

            dtDetail.Rows.Add(drDtl);
        }
        int AcntCloseSts = AccountCloseCheck(dt.Rows[0]["PAYMNT_DATE"].ToString());
        int AuditCloseSts = AuditCloseCheck(dt.Rows[0]["PAYMNT_DATE"].ToString());

        if (Request.QueryString["Rid"] != null)
        {
            AcntCloseSts = AccountCloseCheck(txtdate.Value);
            AuditCloseSts = AuditCloseCheck(txtdate.Value);
        }

        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenEdit.Value = strJson;

        if (Request.QueryString["Rid"] == null)
        {

            btnPRint.Visible = true;
            btnFloatPrint.Visible = true;


            if (dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() != "1")
            {
                btnPRint.Text = "Draft Print";
                btnFloatPrint.Text = "Draft Print";
            }


            if (dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() == "1")
            {

                if (HiddenReOpenStatus.Value == "1")
                {
                    if (AuditCloseSts == 1 && HiddenAuditProvisionStatus.Value == "1")
                    {
                        btnReopen.Visible = true;
                        btnFloatReopen.Visible = true;
                    }
                    else if (AuditCloseSts == 1 && HiddenAuditProvisionStatus.Value != "1")
                    {
                        btnReopen.Visible = false;
                        btnFloatReopen.Visible = false;
                    }
                    else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value == "1")
                    {
                        btnReopen.Visible = true;
                        btnFloatReopen.Visible = true;
                    }
                    else if (AuditCloseSts == 0 && AcntCloseSts == 0)
                    {
                        btnReopen.Visible = true;
                        btnFloatReopen.Visible = true;
                    }
                    else
                    {
                        btnReopen.Visible = false;
                        btnFloatReopen.Visible = false;
                    }
                }
                else
                {
                    btnReopen.Visible = false;
                    btnFloatReopen.Visible = false;

                }
            }
            else //if (dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() == "0")
            {
                //  btnPRint.Visible = true;
                if (HiddenConfirmProvisionStatus.Value == "1")
                {

                    if (AuditCloseSts == 1 && HiddenAuditProvisionStatus.Value == "1")
                    {
                        btnConfirm.Visible = true;
                        btnFloatConfirm.Visible = true;
                    }
                    else if (AuditCloseSts == 1 && HiddenAuditProvisionStatus.Value != "1")
                    {
                        btnConfirm.Visible = false;
                        btnFloatConfirm.Visible = false;
                    }
                    else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value == "1")
                    {
                        btnConfirm.Visible = true;
                        btnFloatConfirm.Visible = true;
                    }
                    else if (AuditCloseSts == 0 && AcntCloseSts == 0)
                    {
                        btnConfirm.Visible = true;
                        btnFloatConfirm.Visible = true;
                    }
                    else
                    {
                        btnConfirm.Visible = false;
                        btnFloatConfirm.Visible = false;
                    }
                }
                else
                {
                    btnConfirm.Visible = false;
                    btnFloatConfirm.Visible = false;
                }
            }


            if (mode == "VIEW" || dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() == "1" || HiddenAcntClsSts.Value == "1")
            {


                btnRecurMinus.Disabled = true;
                btnRecurPlus.Disabled = true;
                btnRecurrSave.Visible = false;
                ddlRecurPeriod.Disabled = true;
                txtRemindDays.Disabled = true;

                if (dt.Rows[0]["REPAREC_PERIOD"].ToString() == "")
                {
                    divRecur.Visible = false;
                }

                btnPRint.Text = "Print";
                btnFloatPrint.Text = "Print";


                btnConfirm.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;

                btnFloatConfirm.Visible = false;
                btnFloatUpdate.Visible = false;
                btnFloatUpdateCls.Visible = false;
                HiddenView.Value = "1";
                txtDescription.Disabled = true;
                ddlAccontLed.Enabled = false;
                txtdate.Disabled = true;

                PaymentDatePikrSpan.Disabled = true;
                PaymentDatePikrSpan.Attributes.Add("style", "pointer-events:none");
                ChequeDatePikrSpan.Disabled = true;
                ChequeDatePikrSpan.Attributes.Add("style", "pointer-events:none");
                ChequeIssueDatePikrSpan.Disabled = true;
                ChequeIssueDatePikrSpan.Attributes.Add("style", "pointer-events:none");
                DD_DatePikrSpan.Disabled = true;
                DD_DatePikrSpan.Attributes.Add("style", "pointer-events:none");
                Transfer_DatePikrSpan.Disabled = true;
                Transfer_DatePikrSpan.Attributes.Add("style", "pointer-events:none");

            }
            else
            {
                btnUpdate.Visible = true;
                bttnsave.Visible = false;
                btnSaveCls.Visible = false;
                btnUpdateClose.Visible = true;
                btnPRint.Text = "Draft Print";
                btnFloatPrint.Text = "Draft Print";
                btnFloatUpdate.Visible = true;
                btnFloatSave.Visible = false;
                btnFloatSaveCls.Visible = false;
                btnFloatUpdateCls.Visible = true;
                HiddenView.Value = "0";


            }
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["PAYMNT_POSTDATED_CHEQUE_STATUS"].ToString() == "1")
                {
                    hiddenPostdated.Value = "1";
                    ddlAccontLed.Enabled = false;
                    txtdate.Disabled = true;
                    ddlChequeBook_Cheque.Enabled = false;
                    ddlChequeNum_Cheque.Enabled = false;
                    txtPayee.Disabled = true;
                    ChkStatus_Cheque.Disabled = true;
                    txtDate_Cheque.Disabled = true;
                    PaymentDatePikrSpan.Disabled = true;
                    PaymentDatePikrSpan.Attributes.Add("style", "pointer-events:none");
                    ChequeDatePikrSpan.Disabled = true;
                    ChequeDatePikrSpan.Attributes.Add("style", "pointer-events:none");
                    txtIssueDate_Cheque.Disabled = true;
                    ChequeIssueDatePikrSpan.Disabled = true;
                    ChequeIssueDatePikrSpan.Attributes.Add("style", "pointer-events:none");
                    divRecur.Visible = false;
                }

                if (dt.Rows[0]["PAYMNT_CNCL_USR_ID"].ToString() != "")
                {

                    btnPRint.Visible = false;
                    btnFloatPrint.Visible = false;
                }

            }
        }

        if (YearEndCls == 1)
        {
            btnReopen.Visible = false;
            btnFloatReopen.Visible = false;
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


    public void LeadgerLoad()
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
        DataTable dtLedger = objBussiness.ReadLeadgerReceipt(ObjEntityRequest);
        if (dtLedger.Rows.Count > 0)
        {
            dtLedger.TableName = "dtTableLedger";
            string result;
            using (StringWriter sw = new StringWriter())
            {
                dtLedger.WriteXml(sw);
                result = sw.ToString();
            }
            hiddenLedgerddl.Value = result;
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

    public void CurrencyLoad()
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
        DataTable dtSubConrt = objBussiness.ReadCurrency(ObjEntityRequest);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtSubConrt;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();

        }
        DataTable dtDefaultcurc = objBussiness.ReadDefualtCurrency(ObjEntityRequest);
        string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
        //ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");
        if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
            ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
    }

    public void AccountLedgerLoad()
    {

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
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

        objEntityCommon.PrimaryGrpIds = Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.BANK) + "," + Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.CASHINHND);

        //DataTable dtSubConrt = objBussiness.ReadAccountLedger(ObjEntityRequest);
        DataTable dtSubConrt = objBusiness.ReadLedgers(objEntityCommon);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlAccontLed.DataSource = dtSubConrt;
            ddlAccontLed.DataTextField = "LDGR_NAME";
            ddlAccontLed.DataValueField = "LDGR_ID";
            ddlAccontLed.DataBind();

        }
        ddlAccontLed.Items.Insert(0, "--SELECT--");
        if (dtSubConrt.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SundryDebtorSelect", "SundryDebtorSelect();", true);
        }
    }


   
    public class clsAccntDetails
    {
        public string LEDGERID { get; set; }
        public string LEDGERSTATUS { get; set; }
        public string COSTCENTERID { get; set; }
        public string COSTCENTERAMT { get; set; }
        public string PURCHASEID { get; set; }
        public string PURCHASEAMT { get; set; }
        public string LEDGERPYMTID { get; set; }
    }


    [WebMethod]
    public static string[] LoadSalesForLedger(string intLedgerId, string intuserid, string intorgid, string intcorpid, string mode, string x, string strCrncyAbrv, string paymentID, string View, string LedgerDtlId, string expenceID)
    {
        string[] result = new string[8];
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        ObjEntityRequest.LedgerId = Convert.ToInt32(intLedgerId);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(intcorpid);
        if (paymentID != "")
        {
            ObjEntityRequest.PaymentId = Convert.ToInt32(paymentID);
        }
        if (LedgerDtlId != "")
        {
            ObjEntityRequest.Payment_Ledgr_Id = Convert.ToInt32(LedgerDtlId);
        }
        //--0043
        if (expenceID != "")
        {
            ObjEntityRequest.ExpenceId = Convert.ToInt32(expenceID);
        }

        DataTable dtExpense = objBussiness.ReadExpensebyId(ObjEntityRequest);//expense
        DataTable dtSales = objBussiness.ReadSalesbyId(ObjEntityRequest);//Purchase
        DataTable dtDebitBoteList = objBussiness.ReadCreditNoteDtls(ObjEntityRequest);//Credit note
        DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);//Opening balance
        DataTable dtSalesReturn = objBussiness.ReadSalesReturnbyId(ObjEntityRequest);//Sales return

        StringBuilder sb = new StringBuilder();
        StringBuilder sbGrp = new StringBuilder();
        string Groupid = "";
        string SettldFully = "";
        int SettledCnt = 0;
        string strDebCr = "";
        int intOBSts = 0;
        if (dtForOB.Rows.Count > 0)
        {
            if (Convert.ToDecimal(dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString()) != 0)
            {
                intOBSts = 1;
                sb.Append("<tr class=\"tr_opn\">");
                sb.Append("<td>Opening Balance</td>");
                sb.Append("<td></td>");
                decimal decBalnceAmt = Convert.ToDecimal(dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString());
                if (dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                {
                    if (Convert.ToDecimal(dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString()) > 0)
                    {
                        strDebCr = "DR";
                    }
                    else
                    {
                        //decBalnceAmt = -1 * decBalnceAmt;
                        strDebCr = "CR";
                    }
                }
                sb.Append("<td class=\"tr_r\" id=\"tdOpeningBalnc" + x + "\"  name=\"tdOpeningBalnc" + x + "\" >" + decBalnceAmt + " " + strDebCr + "</td>");
                sb.Append("<td style=\"display:none;\" id=\"tdDupOBAmnt" + x + "\" >" + dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString() + "</td>");//evm-0020

                sb.Append("<td>");
                sb.Append("<div class=\"input-group in1\">");

                if (dtForOB.Rows[0]["OBPAID_AMT"].ToString() != "0")
                    sb.Append("<input type=\"text\" autocomplete=\'off\'  class=\"form-control fg2_inp2 tr_r\" value=\"" + dtForOB.Rows[0]["OBPAID_AMT"].ToString() + "\"  id=\"txtOpeningBalnc" + x + "\"  name=\"txtOpeningBalnc" + x + "\"   onchange=\"return AmountCalculationForOB(" + x + ");\" onkeydown=\"return isDecimalNumber(event,this.id)\" onkeypress=\"return isDecimalNumber(event,this.id)\"  >");
                else
                    sb.Append("<input type=\"text\" autocomplete=\'off\'  class=\"form-control fg2_inp2 tr_r\" value=\"\"  id=\"txtOpeningBalnc" + x + "\"  name=\"txtOpeningBalnc" + x + "\"   onchange=\"return AmountCalculationForOB(" + x + ");\" onkeydown=\"return isDecimalNumber(event,this.id)\" onkeypress=\"return isDecimalNumber(event,this.id)\"  >");
                sb.Append("</div>");
               
                if (dtForOB.Rows[0]["OBPAID_AMT"].ToString() != "")
                {
                    decBalnceAmt = decBalnceAmt + Convert.ToDecimal(dtForOB.Rows[0]["OBPAID_AMT"].ToString());
                }
                sb.Append("<span class=\"input-group-addon cur2 flt_r\" id=\"SpanOpeningBalance" + x + "\" name=\"SpanOpeningBalance" + x + "\">" + decBalnceAmt.ToString() + " " + strCrncyAbrv + "</span>");
                sb.Append("</td>");
                sb.Append("<td colspan=\"4\"></td>");
                sb.Append("</tr>");
            }
        }


        if (dtSales.Rows.Count > 0)
        {
            //----------------------------Purchase master------------------------------

            for (int row1 = 0; row1 < dtSales.Rows.Count; row1++)
            {
                decimal decTotal = 0;
                if (dtSales.Rows[row1]["PURCHS_NET_TOTAL"].ToString() != "")
                {
                    decTotal = Convert.ToDecimal(dtSales.Rows[row1]["PURCHS_NET_TOTAL"].ToString());
                }
                else if (dtSales.Rows[row1]["PURCHS_BAL_AMT"].ToString() != "")
                {
                    decTotal = Convert.ToDecimal(dtSales.Rows[row1]["PURCHS_BAL_AMT"].ToString());
                }

                if (row1 % 2 == 1)
                {

                    sb.Append("<tr class=\"tr1\" id=\"SelectRow" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" >");
                }
                else
                {

                    sb.Append("<tr class=\"tr\" id=\"SelectRow" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" >");
                
                }
                
                
                sb.Append("<td style=\"display:none;\" id=\"tdSaleID" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "</td>");
                sb.Append("<td style=\"display:none;\" > <label class=\"checkbox \" ><input type=\"checkbox\"  onkeypress=\"return DisableEnter(event);\"  value=\"" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" id=\"cbMandatory" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\"><i></i></label></td>");
                sb.Append("<td style=\"display:none;\" id=\"tdLedgerRow" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + x + "</td>");
                sb.Append("<td style=\"display:none;\" id=\"tdStatus" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + 1 + "</td>");
                sb.Append("<td style=\"display:none;\" id=\"tdLedgerName" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\">" + dtSales.Rows[row1]["LDGR_NAME"].ToString() + "</td>");
                sb.Append("<td style=\"display:none;\" id=\"tdDupAmnt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + decTotal + "</td>");//evm-0020

                sb.Append("<td class=\"td1\" id=\"tdRef" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + dtSales.Rows[row1]["PURCHS_REF"].ToString() + "</td>");
                sb.Append("<td id=\"tdDate" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + dtSales.Rows[row1]["PURCHS_DATE"].ToString() + "</td>");
                sb.Append("<td></td>");
                sb.Append("<td class=\" td1 tr_r\" id=\"tdAmnt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + decTotal + "</td>");


                if (decTotal == 0)//Settlements present when already settled
                {
                    sb.Append("<td disabled class=\"td1 tr_r\" id=\"tdtxtAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\">");
                    sb.Append("<div class=\"input-group\"><div class=\"input-group ma_at flt_l\">");
                    sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                    sb.Append("<input disabled autocomplete=\"off\"  type=\"text\" class=\"form-control fg2_inp2 tr_r\" maxlength=\"10\" onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + ");\"  id=\"txtPurchaseAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\"    />");
                    sb.Append("</div><span id=\"AccntBalancePrchs" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                    sb.Append("</td>");
                    sb.Append("<td style=\"display: none;\"><input type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" id=\"tdSettld" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" value=\"" + dtSales.Rows[row1]["PAYMNT_CST_ID"].ToString() + "\" /></td>");

                    sb.Append("<td id=\"tdDebitNote_Status" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" ");

                    sb.Append("<div><label class=\"switch\" >");
                    sb.Append("<input disabled type=\"checkbox\" id=\"DebitNoteSettle_Status" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" />");
                    sb.Append("<span class=\"slider_tog round\"></span>");
                    sb.Append("</label></div>");

                    sb.Append("</td>");
                    sb.Append("<td id=\"tdDebitNote_Ref" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\">");
                    sb.Append("<select disabled onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" id=\"ddlDebitNote" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\"  onchange=\"ShowDebitNoteBalance(" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + ");\"  onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                    sb.Append("<option  value=\"0\">-Select </option>");
                    for (int i = 0; i < dtDebitBoteList.Rows.Count; i++)
                    {
                        sb.Append("<option value=\"" + dtDebitBoteList.Rows[i]["DEBIT_NOTE_ID"].ToString() + "\">" + dtDebitBoteList.Rows[i]["DR_NOTE_REF"].ToString() + "</option>");
                    }
                    sb.Append("</select>");
                    sb.Append("<span id=\"DebitNoteBalance" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\"  class=\"input-group-addon cur2 c1_d\" ></span>");
                    sb.Append("</td>");

                    sb.Append("<td  id=\"tdDebitNotetxtAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\">");
                    sb.Append("<div class=\"input-group\">");
                    sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                    sb.Append("<input disabled autocomplete=\"off\"  maxlength=\"10\"  type=\"text\" class=\"form-control fg2_inp2 tr_r fgs2\"  onkeydown=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + ");\"  id=\"txtDebitNotetxtAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\"    />");
                    sb.Append("</div><span id=\"AccntBalanceDebitNote" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                    sb.Append("</td>");
                    SettledCnt++;
                }
                else
                {

                    sb.Append("<td class=\"td1 tr_r\"  id=\"tdtxtAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\">");
                    sb.Append("<div class=\"input-group\"><div class=\"input-group ma_at flt_l\">");
                    sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                    sb.Append("<input  autocomplete=\"off\"  type=\"text\" class=\"form-control fg2_inp2 tr_r\" maxlength=\"10\" onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + ");\"  id=\"txtPurchaseAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\"    />");
                    sb.Append("</div><span id=\"AccntBalancePrchs" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                    sb.Append("</td>");
                    sb.Append("<td style=\"display: none;\"><input type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" id=\"tdSettld" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" value=\"0\" /></td>");

                    sb.Append("<td id=\"tdDebitNote_Status" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" ");
                    sb.Append("<div><label class=\"switch\" >");
                    sb.Append("<input disabled type=\"checkbox\" id=\"DebitNoteSettle_Status" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" />");
                    sb.Append("<span class=\"slider_tog round\"></span>");
                    sb.Append("</label></div>");

                    sb.Append("</td>");
                    sb.Append("<td id=\"tdDebitNote_Ref" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\">");
                    sb.Append("<select disabled onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" id=\"ddlDebitNote" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                    sb.Append("<option  value=\"0\">-Select </option>");
                    for (int i = 0; i < dtDebitBoteList.Rows.Count; i++)
                    {
                        sb.Append("<option value=\"" + dtDebitBoteList.Rows[i]["DEBIT_NOTE_ID"].ToString() + "\">" + dtDebitBoteList.Rows[i]["DR_NOTE_REF"].ToString() + "</option>");
                    }
                    sb.Append("</select>");
                    sb.Append("<span id=\"DebitNoteBalance" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\"  class=\"input-group-addon cur2 c1_d\" ></span>");
                    sb.Append("</td>");

                    sb.Append("<td  id=\"tdDebitNotetxtAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\">");
                    sb.Append("<div class=\"input-group\">");
                    sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                    sb.Append("<input disabled autocomplete=\"off\"  maxlength=\"10\"  type=\"text\" class=\"form-control fg2_inp2 tr_r fgs2\" onkeydown=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + ");\"  id=\"txtDebitNotetxtAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\"    />");
                    sb.Append("</div><span id=\"AccntBalanceDebitNote" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                    sb.Append("</td>");
                }

                sb.Append("<td style=\"display:none;\" id=\"tdDebitBalanceAmt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" ></td>");
                sb.Append("<td style=\"display:none;\" class=\" td1 tr_r\" id=\"tdDebitAmnt" + dtSales.Rows[row1]["PURCHS_ID"].ToString() + "\" ></td>");

                sb.Append("</tr>");
                result[3] = dtSales.Rows[row1]["LDGR_NAME"].ToString();
                if (row1 == 0)
                {
                    Groupid = dtSales.Rows[row1]["PURCHS_ID"].ToString();
                }

            }

        }
        else if (dtSalesReturn.Rows.Count > 0)
        {
            //----------------------------Sales return------------------------------

            if ((dtDebitBoteList.Rows.Count > 0) || (dtDebitBoteList.Rows.Count == 0 && View == "1"))
            {

                for (int row1 = 0; row1 < dtSalesReturn.Rows.Count; row1++)
                {
                    decimal decTotal = 0;
                    if (dtSalesReturn.Rows[row1]["SALES_RETURN_AMNT"].ToString() != "")
                    {
                        decTotal = Convert.ToDecimal(dtSalesReturn.Rows[row1]["SALES_RETURN_AMNT"].ToString());
                    }
                    if (dtSalesReturn.Rows[row1]["VOCHR_BFR_SETL_AMT"].ToString() != "")
                    {
                        decTotal = Convert.ToDecimal(dtSalesReturn.Rows[row1]["VOCHR_BFR_SETL_AMT"].ToString());
                    }

                    if (row1 % 2 == 1)
                    {
                        sb.Append("<tr class=\"tr1\" id=\"SelectRow" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" >");
                    }
                    else {

                        sb.Append("<tr class=\"tr\" id=\"SelectRow" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" >");
                    }

                   
                    
                    sb.Append("<td style=\"display:none;\" id=\"tdSaleID" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "</td>");
                    sb.Append("<td style=\"display:none;\" > <label class=\"checkbox \" ><input type=\"checkbox\"  onkeypress=\"return DisableEnter(event);\"  value=\"" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" id=\"cbMandatory" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\"><i></i></label></td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdLedgerRow" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + x + "</td>");
                    //evm-0043



                    sb.Append("<td style=\"display:none;\" id=\"tdStatus" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + 1 + "</td>");
                        sb.Append("<td style=\"display:none;\" id=\"tdLedgerName" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\">" + dtSalesReturn.Rows[row1]["LDGR_NAME"].ToString() + "</td>");
                        sb.Append("<td style=\"display:none;\" id=\"tdDupAmnt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + decTotal + "</td>");//evm-0020

                        sb.Append("<td class=\"td1\" id=\"tdRef" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + dtSalesReturn.Rows[row1]["PURCHS_REF"].ToString() + "</td>");
                        sb.Append("<td id=\"tdDate" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + dtSalesReturn.Rows[row1]["PURCHS_DATE"].ToString() + "</td>");
                        sb.Append("<td></td>");
                        sb.Append("<td class=\" td1 tr_r\" id=\"tdAmnt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" >" + decTotal + "</td>");

                    
                    if (decTotal == 0)
                    {
                        sb.Append("<td disabled class=\"td1 tr_r\" id=\"tdtxtAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\">");
                        sb.Append("<div class=\"input-group\"><div class=\"input-group ma_at flt_l\">");
                        sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                        sb.Append("<input disabled autocomplete=\"off\"  type=\"text\" class=\"form-control fg2_inp2 tr_r\" maxlength=\"10\" onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + ");\"  id=\"txtPurchaseAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\"    />");
                        sb.Append("</div><span id=\"AccntBalancePrchs" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                        sb.Append("</td>");
                        sb.Append("<td style=\"display: none;\"><input disabled type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" id=\"tdSettld" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" value=\"" + dtSalesReturn.Rows[row1]["PAYMNT_CST_ID"].ToString() + "\" /></td>");

                        sb.Append("<td id=\"tdDebitNote_Status" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" ");

                        sb.Append("<div><label class=\"switch\" >");
                        sb.Append("<input disabled type=\"checkbox\" id=\"DebitNoteSettle_Status" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" onclick=\"suply1(" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + ")\" />");
                        sb.Append("<span class=\"slider_tog round\"></span>");
                        sb.Append("</label></div>");

                        sb.Append("</td>");
                        sb.Append("<td id=\"tdDebitNote_Ref" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\">");
                        sb.Append("<select disabled onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" id=\"ddlDebitNote" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\"  onchange=\"ShowDebitNoteBalance(" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + ");\"  onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                        sb.Append("<option  value=\"0\">-Select </option>");
                        for (int i = 0; i < dtDebitBoteList.Rows.Count; i++)
                        {
                            sb.Append("<option value=\"" + dtDebitBoteList.Rows[i]["DEBIT_NOTE_ID"].ToString() + "\">" + dtDebitBoteList.Rows[i]["DR_NOTE_REF"].ToString() + "</option>");
                        }
                        sb.Append("</select>");
                        sb.Append("<span id=\"DebitNoteBalance" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\"  class=\"input-group-addon cur2 c1_d\" ></span>");
                        sb.Append("</td>");

                        sb.Append("<td  id=\"tdDebitNotetxtAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\">");
                        sb.Append("<div class=\"input-group\">");
                        sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                        sb.Append("<input disabled autocomplete=\"off\"  maxlength=\"10\"  type=\"text\" class=\"form-control fg2_inp2 tr_r fgs2\"  onkeydown=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + ");\"  id=\"txtDebitNotetxtAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\"    />");
                        sb.Append("</div><span id=\"AccntBalanceDebitNote" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                        sb.Append("</td>");
                        SettledCnt++;
                    }
                    else
                    {

                        sb.Append("<td class=\"td1 tr_r\"  id=\"tdtxtAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\">");
                        sb.Append("<div class=\"input-group\"><div class=\"input-group ma_at flt_l\">");
                        sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                        sb.Append("<input disabled autocomplete=\"off\"  type=\"text\" class=\"form-control fg2_inp2 tr_r\" maxlength=\"10\" onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + ");\"  id=\"txtPurchaseAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\"    />");
                        sb.Append("</div><span id=\"AccntBalancePrchs" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                        sb.Append("</td>");
                        sb.Append("<td style=\"display: none;\"><input type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" id=\"tdSettld" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" value=\"0\" /></td>");

                        sb.Append("<td id=\"tdDebitNote_Status" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" ");
                        sb.Append("<div><label class=\"switch\" >");
                        sb.Append("<input type=\"checkbox\" id=\"DebitNoteSettle_Status" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" onclick=\"suply1(" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + ")\" />");
                        sb.Append("<span class=\"slider_tog round\"></span>");
                        sb.Append("</label></div>");

                        sb.Append("</td>");
                        sb.Append("<td id=\"tdDebitNote_Ref" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\">");
                        sb.Append("<select disabled onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" id=\"ddlDebitNote" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\"  onchange=\"ShowDebitNoteBalance(" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + ");\"  onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                        sb.Append("<option  value=\"0\">-Select </option>");
                        for (int i = 0; i < dtDebitBoteList.Rows.Count; i++)
                        {
                            sb.Append("<option value=\"" + dtDebitBoteList.Rows[i]["DEBIT_NOTE_ID"].ToString() + "\">" + dtDebitBoteList.Rows[i]["DR_NOTE_REF"].ToString() + "</option>");
                        }
                        sb.Append("</select>");
                        sb.Append("<span id=\"DebitNoteBalance" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\"  class=\"input-group-addon cur2 c1_d\" ></span>");
                        sb.Append("</td>");

                        sb.Append("<td  id=\"tdDebitNotetxtAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\">");
                        sb.Append("<div class=\"input-group\">");
                        sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                        sb.Append("<input disabled autocomplete=\"off\"  maxlength=\"10\"  type=\"text\" class=\"form-control fg2_inp2 tr_r fgs2\" onkeydown=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + ");\"  id=\"txtDebitNotetxtAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\"    />");
                        sb.Append("</div><span id=\"AccntBalanceDebitNote" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                        sb.Append("</td>");
                    }

                    sb.Append("<td style=\"display:none;\" id=\"tdDebitBalanceAmt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" ></td>");
                    sb.Append("<td style=\"display:none;\" class=\" td1 tr_r\" id=\"tdDebitAmnt" + dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString() + "\" ></td>");

                    sb.Append("</tr>");
                    result[3] = dtSalesReturn.Rows[row1]["LDGR_NAME"].ToString();
                    if (row1 == 0)
                    {
                        Groupid = dtSalesReturn.Rows[row1]["PURCHS_ID"].ToString();
                    }
                }

            }
        }
        if (dtExpense.Rows.Count > 0)//Expense Mster
        {

            for (int row1 = 0; row1 < dtExpense.Rows.Count; row1++)
            {
                decimal decTotal = 0;
                if (dtExpense.Rows[row1]["EXPENSE_DTL_AMT"].ToString() != "")
                {
                    decTotal = Convert.ToDecimal(dtExpense.Rows[row1]["EXPENSE_DTL_AMT"].ToString());
                }
                else if (dtExpense.Rows[row1]["EXPENS_BAL_AMT"].ToString() != "")
                {
                    decTotal = Convert.ToDecimal(dtExpense.Rows[row1]["EXPENS_BAL_AMT"].ToString());
                }
                if (row1 % 2 == 1)
                {

                    sb.Append("<tr class=\"tr\" id=\"SelectRow" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >");
                }
                else {

                    sb.Append("<tr class=\"tr1\" id=\"SelectRow" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >");
                
                }
                    
                sb.Append("<td style=\"display:none;\" id=\"tdSaleID" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "</td>");
                sb.Append("<td style=\"display:none;\" > <label class=\"checkbox \" ><input type=\"checkbox\"  onkeypress=\"return DisableEnter(event);\"  value=\"" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" id=\"cbMandatory" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"><i></i></label></td>");
                sb.Append("<td style=\"display:none;\" id=\"tdLedgerRow" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >" + x + "</td>");
                //evm-0043 start
                sb.Append("<td style=\"display:none;\" id=\"tdStatus" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">" + 0 + "</td>");
                sb.Append("<td style=\"display:none;\" id=\"tdLedgerName" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">" + dtExpense.Rows[row1]["LDGR_NAME"].ToString() + "</td>");
                sb.Append("<td style=\"display:none;\" id=\"tdDupAmnt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >" + decTotal + "</td>");//evm-0020
                sb.Append("<td class=\"th_b8 td1\" id=\"tdRef" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >" + dtExpense.Rows[row1]["SALES_REF"].ToString() + "</td>");
                sb.Append("<td class=\"th_b6 \"  id=\"tdDate" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >" + dtExpense.Rows[row1]["SALES_DATE"].ToString() + "</td>");
                sb.Append("<td class=\"th_b6 \" id=\"tdRef" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >" + dtExpense.Rows[row1]["EXPENSE_REF"].ToString() + "</td>");


                sb.Append("<td class=\" th_b2 tr_r\" id=\"tdAmnt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >" + decTotal + "</td>");

                if (decTotal == 0)//Settlements present when already settled
                {
                    sb.Append("<td disabled class=\"th_b11\" id=\"tdtxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">");
                    sb.Append("<div class=\"input-group\"><div class=\"input-group ma_at flt_l\">");
                    sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                    sb.Append("<input   type=\"text\" class=\"form-control fg2_inp2 tr_r\" maxlength=\"10\" onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + ");\"  id=\"txtPurchaseAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"    />");

                    sb.Append("</div><span id=\"AccntBalancePrchs" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                    sb.Append("</td>");
                    sb.Append("<td style=\"display: none;\"><input type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" id=\"tdSettld" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" value=\"0\" /></td>");

                    sb.Append("<td id=\"tdDebitNote_Status" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >");
                    sb.Append("<div><label class=\"switch\" >");
                    sb.Append("<input disabled type=\"checkbox\" id=\"DebitNoteSettle_Status" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" />");
                    sb.Append("<span class=\"slider_tog round\"></span>");
                    sb.Append("</label></div>");
                    sb.Append("</td>");

                    sb.Append("<td id=\"tdDebitNote_Ref" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">");
                    sb.Append("<select disabled onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" id=\"ddlDebitNote" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  onchange=\"ShowDebitNoteBalance(" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + ");\"  onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                    sb.Append("<option  value=\"0\">-Select</option>");
                    sb.Append("</select>");
                    sb.Append("<span id=\"DebitNoteBalance" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  class=\"input-group-addon cur2 c1_d\" ></span>");
                    sb.Append("</td>");

                    sb.Append("<td  id=\"tdDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">");
                    sb.Append("<div class=\"input-group\">");
                    sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                    sb.Append("<input disabled autocomplete=\"off\"  maxlength=\"10\"  type=\"text\" class=\"form-control fg2_inp2 tr_r fgs2\"  onkeydown=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + ");\"  id=\"txtDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"    />");
                    sb.Append("</div><span id=\"AccntBalanceDebitNote" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                    sb.Append("</td>");
                    SettledCnt++;
                }
                else
                {

                    sb.Append("<td class=\"th_b11\"  id=\"tdtxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">");
                    sb.Append("<div class=\"input-group\"><div class=\"input-group ma_at flt_l\">");
                    sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");

                    sb.Append("<input  autocomplete=\"off\"  type=\"text\" class=\"form-control fg2_inp2 tr_r\" maxlength=\"10\" onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + ");\"  id=\"txtPurchaseAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"    />");

                    sb.Append("</div><span id=\"AccntBalancePrchs" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                    sb.Append("</td>");

                    sb.Append("<td style=\"display: none;\"><input type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" id=\"tdSettld" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" value=\"0\" /></td>");

                    sb.Append("<td id=\"tdDebitNote_Status" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >");
                    sb.Append("<div><label class=\"switch\" >");
                    sb.Append("<input disabled type=\"checkbox\" id=\"DebitNoteSettle_Status" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" />");
                    sb.Append("<span class=\"slider_tog round\"></span>");
                    sb.Append("</label></div>");
                    sb.Append("</td>");

                    sb.Append("<td id=\"tdDebitNote_Ref" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">");
                    sb.Append("<select disabled onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" id=\"ddlDebitNote" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                    sb.Append("<option  value=\"0\">-Select </option>");
                    sb.Append("</select>");
                    sb.Append("<span id=\"DebitNoteBalance" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  class=\"input-group-addon cur2 c1_d\" ></span>");
                    sb.Append("</td>");

                    sb.Append("<td  id=\"tdDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">");
                    sb.Append("<div class=\"input-group\">");
                    sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                    sb.Append("<input disabled autocomplete=\"off\"  maxlength=\"10\"  type=\"text\" class=\"form-control fg2_inp2 tr_r fgs2\" onkeydown=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + ");\"  id=\"txtDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"    />");
                    sb.Append("</div><span id=\"AccntBalanceDebitNote" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                    sb.Append("</td>");
                }

                sb.Append("<td style=\"display:none;\" id=\"tdDebitBalanceAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" ></td>");
                sb.Append("<td style=\"display:none;\" class=\" td1 tr_r\" id=\"tdDebitAmnt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" ></td>");

                sb.Append("</tr>"); result[3] = dtExpense.Rows[row1]["LDGR_NAME"].ToString();
                if (row1 == 0)
                {
                    Groupid = dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString();
                }

            }

        }

        DataTable dtacntblnc = objBussiness.AccntBalancebyId(ObjEntityRequest);
        decimal DecDebAmnt = 0, DecCredAmnt = 0, DBalance = 0, Openbalance = 0;
        int intLedgerMode;
        string CrOrDr = "CR";
        string Nature = "";

        if (dtacntblnc.Rows.Count > 0)
        {
            if (dtacntblnc.Rows[0]["LDGR_MODE"].ToString() == "1")
            {
                if (dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString() != "")
                    DecCredAmnt = Convert.ToDecimal(dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString());
                //if (dtacntblnc.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                //    Openbalance = Convert.ToDecimal(dtacntblnc.Rows[0]["LDGR_OPEN_BAL"].ToString());
                DBalance = DecCredAmnt - Openbalance;

            }
            else if (dtacntblnc.Rows[0]["LDGR_MODE"].ToString() == "0")
            {
                if (dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString() != "")
                    DecDebAmnt = Convert.ToDecimal(dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString());
               // if (dtacntblnc.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                //    Openbalance = Convert.ToDecimal(dtacntblnc.Rows[0]["LDGR_OPEN_BAL"].ToString());
                DBalance = DecDebAmnt + Openbalance;
            }
            if (DBalance < 0)
            {
            }
            else
            {
                CrOrDr = "DR";
            }

            Nature = dtacntblnc.Rows[0]["ACNT_NATURE_STS"].ToString();
        }
        if (mode == "upd")
        {
            result[0] = "";
        }
        else
        {
            result[0] = sb.ToString();
        }
        result[1] = DBalance.ToString();
        result[2] = CrOrDr;
        result[4] = Groupid;
        result[5] = Nature;
        result[6] = intOBSts.ToString();
        result[7] = strDebCr;

        return result;

    }




    [WebMethod]
    public static string[] AccntBalanceLedger(string intLedgerId, string intuserid, string intorgid, string intcorpid, string ChqBkId)
    {
        string[] result = new string[4];
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();

        ObjEntityRequest.LedgerId = Convert.ToInt32(intLedgerId);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(intcorpid);
        DataTable dtSales = objBussiness.AccntBalancebyId(ObjEntityRequest);
        decimal DecDebAmnt = 0, DecCredAmnt = 0, DBalance = 0, Openbalance = 0;
        string CrOrDr = "CR";
        string AccGrp = "";



        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        objEntityCommon.CorporateID = Convert.ToInt32(intcorpid);
        objEntityCommon.Organisation_Id = Convert.ToInt32(intorgid);
        objEntityCommon.PrimaryGrpIds = Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.BANK) + "";
        DataTable dtSubConrt = objBusiness.ReadLedgers(objEntityCommon);
        bool exists = dtSubConrt.Select().ToList().Exists(row => row["LDGR_ID"].ToString() == intLedgerId);

        if (dtSales.Rows.Count > 0)
        {

            if (dtSales.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != "" && dtSales.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString() != null)
                AccGrp = dtSales.Rows[0]["ACNT_GRP_PREDFNED_TYP"].ToString();
            else if (dtSales.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != "" && dtSales.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString() != null)
                AccGrp = dtSales.Rows[0]["ACNT_GRP_PRIMARY_STATUS"].ToString();
            //if (dtSales.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
            //{
            //    Openbalance = Convert.ToDecimal(dtSales.Rows[0]["LDGR_OPEN_BAL"].ToString());
            //}
            if (dtSales.Rows[0]["LDGR_MODE"].ToString() == "1")
            {
                if (dtSales.Rows[0]["LDGR_CURRENT_BAL"].ToString() != "")
                    DecCredAmnt = Convert.ToDecimal(dtSales.Rows[0]["LDGR_CURRENT_BAL"].ToString());
                DBalance = DecCredAmnt - Openbalance;
            }
            else if (dtSales.Rows[0]["LDGR_MODE"].ToString() == "0")
            {
                if (dtSales.Rows[0]["LDGR_CURRENT_BAL"].ToString() != "")
                    DBalance = Convert.ToDecimal(dtSales.Rows[0]["LDGR_CURRENT_BAL"].ToString());
                DBalance = DBalance + Openbalance;
            }
            if (DBalance < 0)
            {
                //  CrOrDr = "DR";
                string srDBalance = Convert.ToString(DBalance);
                srDBalance = srDBalance.Substring(1);
                DBalance = Convert.ToDecimal(srDBalance);
            }
            else
            {
                CrOrDr = "DR";
            }
        }
        if (ChqBkId != "")
        {
            ObjEntityRequest.ChequeBookId = Convert.ToInt32(ChqBkId);
        }
        DataTable dtChequeBook = objBussiness.ReadChequeBooks(ObjEntityRequest);
        string result1 = "";
        if (dtChequeBook.Rows.Count > 0)
        {
            dtChequeBook.TableName = "dtTableChequeBook";
            using (StringWriter sw = new StringWriter())
            {
                dtChequeBook.WriteXml(sw);
                result1 = sw.ToString();
            }
        }
        result[0] = DBalance.ToString();
        result[1] = CrOrDr;
        result[2] = exists.ToString();
        result[3] = result1;
        return result;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objcommon = new clsCommonLibrary();

        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            ObjEntityRequest.User_Id = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            ObjEntityRequest.Corporate_id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityRequest.Organisation_id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Request.QueryString["Id"] != null)
        {

            string strRandomMixedId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            ObjEntityRequest.PaymentId = Convert.ToInt32(strId);
        }
        ObjEntityRequest.LedgerId = Convert.ToInt32(ddlAccontLed.SelectedItem.Value);
        ObjEntityRequest.RefNum = TxtRef.Value;
        if (HiddenUpdatedDate.Value != "")
        {
            ObjEntityRequest.UpdPaymentDate = objcommon.textToDateTime(HiddenUpdatedDate.Value);
        }
        ObjEntityRequest.FromDate = objcommon.textToDateTime(txtdate.Value);
        ObjEntityRequest.CurrcyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        if (ObjEntityRequest.CurrcyId != Convert.ToInt32(hiddenDfltCurrencyMstrId.Value))
        {
            if (txtExchangeRate.Value != "")
            {
                string ExchangeRate = txtExchangeRate.Value;
                ExchangeRate = ExchangeRate.Replace(",", "");
                ObjEntityRequest.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Value);
            }
        }
        if (txtDescription.Value != "")
        {
            ObjEntityRequest.Description = txtDescription.Value;
        }
        ObjEntityRequest.TotalAmnt = Convert.ToDecimal(txtGrantTotal.Value);
        ObjEntityRequest.AccntNameId = Convert.ToInt32(ddlAccontLed.SelectedItem.Value);
        if (HiddenSequenceRef.Value != "")
        {
            //PAYMNT_REF_SEQNUM
            ObjEntityRequest.SequenceRef = Convert.ToInt32(HiddenSequenceRef.Value);
        }

        int DupChqNos = 0;

        if (HiddenPrevTab.Value == "Cheque")
        {
            ObjEntityRequest.PayemntMode = 1;
            if (HiddenChequeBookId.Value != "")
                ObjEntityRequest.ChequeBookId = Convert.ToInt32(HiddenChequeBookId.Value);
            ObjEntityRequest.ChequeBookNumber = Convert.ToInt32(HiddenupdCheckNumber.Value);
            ObjEntityRequest.ToDate = objcommon.textToDateTime(txtDate_Cheque.Value);
            ObjEntityRequest.Payee = txtPayee.Value;
            if (ChkStatus_Cheque.Checked)
            {
                if (HiddenPrevTab.Value == "Cheque")
                {
                    ObjEntityRequest.ChequeIssue = 1;
                    ObjEntityRequest.ChequeIssueDate = objcommon.textToDateTime(txtIssueDate_Cheque.Value);
                }
            }
            else
            {
                ObjEntityRequest.ChequeIssue = 0;
            }

            DataTable dtCheqDup = objBussinessPayment.CheckChequeNumbersAdded(ObjEntityRequest);

            if (dtCheqDup.Rows.Count > 0 && Convert.ToInt32(dtCheqDup.Rows[0]["CNT_CHQNO"].ToString()) > 0)
            {
                DupChqNos++;
            }
        }
        else if (HiddenPrevTab.Value == "DD")
        {
            ObjEntityRequest.PayemntMode = 2;
            ObjEntityRequest.DD_Number = txtDD_DD.Value;
            ObjEntityRequest.ToDate = objcommon.textToDateTime(txtDate_DD.Value);
        }
        else if (HiddenPrevTab.Value == "BankTransfer")
        {
            ObjEntityRequest.PayemntMode = 3;
            ObjEntityRequest.BankTransfer_Mode = Convert.ToInt32(ddlMode_BankTransfer.SelectedValue);
            ObjEntityRequest.ToDate = objcommon.textToDateTime(txtDate_BankTransfer.Value);
            ObjEntityRequest.Bank_BankTransfer = Bank_BankTransfer.Value;
            ObjEntityRequest.IBAN_BankTransfer = IBAN_BankTransfer.Value;
        }



        //Start:-Recurrence
        if (HiddenFieldRecurrencyPeriod.Value != "")
        {
            ObjEntityRequest.RecurPeriodId = Convert.ToInt32(HiddenFieldRecurrencyPeriod.Value);
            ObjEntityRequest.RecurRemindDays = Convert.ToInt32(HiddenFieldRemindDays.Value);
        }
        //End:-Recurrence

        List<clsEntityPaymentAccount> objEntityCostCenterIns = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityCostCenterUpd = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityCostCenterDel = new List<clsEntityPaymentAccount>();

        List<clsEntityPaymentAccount> objEntityLedgerIns = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityLedgerUpd = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityLedgerDel = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityDelete = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityInsertToVT = new List<clsEntityPaymentAccount>();//EVM-0027
        string strRets = "successConfirm";

        if (HiddenFieldSaveAccount.Value != "" && HiddenFieldSaveAccount.Value != null && HiddenFieldSaveAccount.Value != "[]")
        {
            string jsonDataDltAttch = HiddenFieldSaveAccount.Value;
            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
            string strAtt2 = strAtt1.Replace("\\", "");
            string strAtt3 = strAtt2.Replace("}\"]", "}]");
            string strAtt4 = strAtt3.Replace("}\",", "},");
            List<clsAccntDetails> objVideoDataDltAttList = new List<clsAccntDetails>();
            //   UserData  data
            objVideoDataDltAttList = JsonConvert.DeserializeObject<List<clsAccntDetails>>(strAtt4);

            foreach (clsAccntDetails objClsVideoAddAttData in objVideoDataDltAttList)
            {
                clsEntityPaymentAccount objSubEntityLedgerINS = new clsEntityPaymentAccount();
                clsEntityPaymentAccount objSubEntityLedgerUPD = new clsEntityPaymentAccount();

                if (Request.Form["tdEvtGrp" + objClsVideoAddAttData.LEDGERID] == "INS")
                {
                    objSubEntityLedgerINS.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                    objSubEntityLedgerINS.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                    if (Request.Form["txtAmntVal" + objClsVideoAddAttData.LEDGERID] != "")
                    {
                        objSubEntityLedgerINS.LedgerAmnt = Convert.ToDecimal(Request.Form["txtAmntVal" + objClsVideoAddAttData.LEDGERID]);
                    }
                    if (Request.Form["TxtRemark" + objClsVideoAddAttData.LEDGERID] != "")
                    {
                        objSubEntityLedgerINS.Remarks = Request.Form["TxtRemark" + objClsVideoAddAttData.LEDGERID];
                    }

                    string OBtoVT = Request.Form["tdLedgrPaid" + objClsVideoAddAttData.LEDGERID];
                    if (OBtoVT != "" && OBtoVT != "null" && OBtoVT != null)
                    {
                        string[] OBvalues = OBtoVT.Split('#');
                        objSubEntityLedgerINS.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                        objSubEntityLedgerINS.FromDate = ObjEntityRequest.FromDate;
                        objSubEntityLedgerINS.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                        objSubEntityLedgerINS.Status = 1;
                        objSubEntityLedgerINS.PaidAmt = Convert.ToDecimal(OBvalues[0]);
                        objSubEntityLedgerINS.BalnceAmt = Convert.ToDecimal(OBvalues[1]);
                        objSubEntityLedgerINS.Organisation_id = ObjEntityRequest.Organisation_id;
                        objSubEntityLedgerINS.Corporate_id = ObjEntityRequest.Corporate_id;
                        if (objSubEntityLedgerINS.PaidAmt != 0)
                        {
                            objSubEntityLedgerINS.VoucherCategory = 1;
                            ObjEntityRequest.VoucherCategory = 1;
                        }
                        objEntityInsertToVT.Add(objSubEntityLedgerINS);
                        objEntityCostCenterIns.Add(objSubEntityLedgerINS);
                    }


                    objEntityLedgerIns.Add(objSubEntityLedgerINS);
                }

                if (Request.Form["tdEvtGrp" + objClsVideoAddAttData.LEDGERID] == "UPD")
                {
                    objSubEntityLedgerUPD.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                    objSubEntityLedgerUPD.Payment_Ledgr_Id = Convert.ToInt32(objClsVideoAddAttData.LEDGERPYMTID);
                    objSubEntityLedgerUPD.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                    if (Request.Form["txtAmntVal" + objClsVideoAddAttData.LEDGERID] != "")
                    {
                        objSubEntityLedgerUPD.LedgerAmnt = Convert.ToDecimal(Request.Form["txtAmntVal" + objClsVideoAddAttData.LEDGERID]);
                    }
                    if (Request.Form["TxtRemark" + objClsVideoAddAttData.LEDGERID] != "")
                    {
                        objSubEntityLedgerUPD.Remarks = Request.Form["TxtRemark" + objClsVideoAddAttData.LEDGERID];
                    }

                    string OBtoVT = Request.Form["tdLedgrPaid" + objClsVideoAddAttData.LEDGERID];
                    if (OBtoVT != "" && OBtoVT != "null" && OBtoVT != null)
                    {
                        string[] OBvalues = OBtoVT.Split('#');
                        objSubEntityLedgerUPD.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                        objSubEntityLedgerUPD.FromDate = ObjEntityRequest.FromDate;
                        objSubEntityLedgerUPD.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                        objSubEntityLedgerUPD.Status = 1;
                        objSubEntityLedgerUPD.PaidAmt = Convert.ToDecimal(OBvalues[0]);
                        objSubEntityLedgerUPD.BalnceAmt = Convert.ToDecimal(OBvalues[1]);
                        objSubEntityLedgerUPD.Organisation_id = ObjEntityRequest.Organisation_id;
                        objSubEntityLedgerUPD.Corporate_id = ObjEntityRequest.Corporate_id;
                        if (objSubEntityLedgerUPD.PaidAmt != 0)
                        {
                            objSubEntityLedgerUPD.VoucherCategory = 1;
                            ObjEntityRequest.VoucherCategory = 1;
                        }
                        objEntityInsertToVT.Add(objSubEntityLedgerUPD);
                        objEntityCostCenterIns.Add(objSubEntityLedgerUPD);
                    }


                    objEntityLedgerUpd.Add(objSubEntityLedgerUPD);
                }


              
                string CostCenterDtl = Request.Form["tdCostCenterDtls" + objClsVideoAddAttData.LEDGERID];
                if (CostCenterDtl != "")
                {
                    string[] CostCenterDtlvalues = CostCenterDtl.Split('$');
                    for (int i = 0; i < CostCenterDtlvalues.Length; i++)
                    {
                        clsEntityPaymentAccount objSubEntity = new clsEntityPaymentAccount();

                        objSubEntity.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                        objSubEntity.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                        if (CostCenterDtlvalues[i] != "")
                        {
                            string[] valSplit = CostCenterDtlvalues[i].Split('%');
                            objSubEntity.CostCtrId = Convert.ToInt32(valSplit[0]);
                            valSplit[1] = valSplit[1].Replace(",", "");
                            if (valSplit[1] != "")

                            objSubEntity.CstCntrAmnt = Convert.ToDecimal(valSplit[1]);
                            if (valSplit[2] != "" && valSplit[2] != null)
                            {
                                objSubEntity.CostGrp1Id = Convert.ToInt32(valSplit[2]);
                            }
                            if (valSplit[3] != "" && valSplit[3] != null)
                            {
                                objSubEntity.CostGrp2Id = Convert.ToInt32(valSplit[3]);
                            }

                            objEntityCostCenterIns.Add(objSubEntity);
                        }
                    }
                }

                //evm-0043 start 20-03

                string PurchaseDtl = Request.Form["tdPurchaseDtls" + objClsVideoAddAttData.LEDGERID];
                string TableSts = Request.Form["tdStatus" + objClsVideoAddAttData.LEDGERID];
                if (PurchaseDtl != "")
                {
                    string[] values = PurchaseDtl.Split('$');
                    for (int i = 0; i < values.Length; i++)
                    {
                        clsEntityPaymentAccount objSubEntity = new clsEntityPaymentAccount();
                        clsEntityPaymentAccount objSubEntityDEL = new clsEntityPaymentAccount();

                        objSubEntity.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                        objSubEntity.Organisation_id = ObjEntityRequest.Organisation_id;
                        objSubEntity.Corporate_id = ObjEntityRequest.Corporate_id;
                        objSubEntity.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                     
                        if (values[i] != "")
                        {
                            string[] valSplit = values[i].Split('%');
                            if (valSplit[7] == "1")
                            {
                                objSubEntity.PurchaseId = Convert.ToInt32(valSplit[0]);
                                valSplit[1] = valSplit[1].Replace(",", "");
                                if (valSplit[1] != "")
                                    objSubEntity.CstCntrAmnt = Convert.ToDecimal(valSplit[1]);
                                valSplit[2] = valSplit[2].Replace(",", "");
                                objSubEntity.PurchaseActAmount = Convert.ToDecimal(valSplit[2]);
                                valSplit[3] = valSplit[3].Replace(",", "");

                                int intCreditNoteSettleSts = Convert.ToInt32(valSplit[3]);

                                if (valSplit[3] != "0")
                                {
                                    objSubEntity.DebitNoteStatus = Convert.ToInt32(valSplit[3]);
                                    valSplit[4] = valSplit[4].Replace(",", "");
                                    if (valSplit[4] != "0")
                                        objSubEntity.DebitNoteId = Convert.ToInt32(valSplit[4]);
                                    valSplit[5] = valSplit[5].Replace(",", "");
                                    if (valSplit[5] != "0")
                                        objSubEntity.DebitNoteAmount = Convert.ToDecimal(valSplit[5]);
                                    if (valSplit[6] != "0" && valSplit[6] != "")
                                        objSubEntity.DebitNoteRemainingAmount = Convert.ToDecimal(valSplit[6]);
                                }

                                if (clickedButton.ID == "btnConfirm1")
                                {
                                    DataTable dtSalesBalance = objBussinessPayment.ReadPurchaseBalance(objSubEntity);

                                    if (intCreditNoteSettleSts == 1)
                                    {
                                        dtSalesBalance = objBussinessPayment.ReadSalesReturnBalance(objSubEntity);
                                    }

                                    decimal decSalesRemainAmt = 0;
                                    if (dtSalesBalance.Rows.Count > 0)
                                    {
                                        if (dtSalesBalance.Rows[0][1].ToString() != "")
                                            decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                                    }
                                    if (decSalesRemainAmt != 0)
                                    {
                                        if (decSalesRemainAmt < (objSubEntity.CstCntrAmnt + objSubEntity.DebitNoteAmount))
                                        {
                                            strRets = "PrchsAmountExceeded";
                                        }
                                    }
                                    else
                                    {
                                        strRets = "PrchsAmtFullySettld";
                                        objSubEntityDEL.PaymentCostCntrId = Convert.ToInt32(Request.Form["tdSettld" + objSubEntity.PurchaseId]);
                                        objEntityDelete.Add(objSubEntityDEL);
                                    }

                                    if (decSalesRemainAmt != 0)//insert not fully settled
                                    {
                                        objEntityCostCenterIns.Add(objSubEntity);
                                    }
                                }
                                else
                                {
                                    objEntityCostCenterIns.Add(objSubEntity);
                                }

                            }
                            else
                            {

                                clsEntityPaymentAccount objSubEntity1 = new clsEntityPaymentAccount();

                                objSubEntity1.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                                objSubEntity1.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                              
                                objSubEntity1.ExpenceId = Convert.ToInt32(valSplit[0]);
                                valSplit[1] = valSplit[1].Replace(",", "");
                                if (valSplit[1] != "")

                                    objSubEntity1.ExpnsAmnt = Convert.ToDecimal(valSplit[1]);
                                valSplit[2] = valSplit[2].Replace(",", "");
                                objSubEntity1.TotalExpnsAmnt = Convert.ToDecimal(valSplit[2]);


                                objEntityCostCenterIns.Add(objSubEntity1);

                                DataTable dtLDGRdTLS = objBussinessPayment.Read_PayemntLedgerByID(ObjEntityRequest);

                                //kik
                                for (int p = 0; p < dtLDGRdTLS.Rows.Count; p++)
                                {
                                    if (dtLDGRdTLS.Rows[p]["EXPENSE_ID"].ToString() != "")
                                    {
                                        int ExpenceId = Convert.ToInt32(dtLDGRdTLS.Rows[p]["EXPENSE_ID"].ToString());
                                        decimal ExpnAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[p]["EXPENSE_AMT"].ToString());
                                        decimal TotalExpnAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[p]["EXPENSE_DTL_BALNC_AMT"].ToString());


                                        if (TotalExpnAmnt < ExpnAmnt)
                                        {

                                            
                                            Response.Redirect("fms_Payment_Account.aspx?InsUpd=PrchsAmountExceeded&Id=" + Request.QueryString["Id"].ToString());

                                        }
                                    }

                                }

                            }
                        }
                       

                    }
                }


                //0043
                //string ExpnsDtl = Request.Form["tdExpenseDtls" + objClsVideoAddAttData.LEDGERID];
                //if (ExpnsDtl != "" && ExpnsDtl != "null" && ExpnsDtl != null)
                //{
                //    string[] values = ExpnsDtl.Split('$');
                //    for (int i = 0; i < values.Length; i++)
                //    {
                //        clsEntityPaymentAccount objSubEntity = new clsEntityPaymentAccount();

                //        objSubEntity.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                //        objSubEntity.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                //        string[] valSplit = values[i].Split('%');
                //        objSubEntity.ExpenceId = Convert.ToInt32(valSplit[0]);
                //        valSplit[1] = valSplit[1].Replace(",", "");
                //        if (valSplit[1] != "")

                //            objSubEntity.ExpnsAmnt = Convert.ToDecimal(valSplit[1]);
                //        valSplit[2] = valSplit[2].Replace(",", "");
                //        objSubEntity.TotalExpnsAmnt = Convert.ToDecimal(valSplit[2]);
                //        objEntityCostCenterIns.Add(objSubEntity);
                //    }
                //}
                //end



                if (objEntityDelete.Count > 0)//delete fully settld saved sales and purchs
                {
                    objBussinessPayment.DeletePurchaseLedgers(objEntityDelete);
                    strRets = "successConfirm";
                }


                string strCanclDtlId = "";
                string[] strarrCancldtlIdsGrp = strCanclDtlId.Split(',');
                if (hiddenLedgerCanclDtlId.Value != "" && hiddenLedgerCanclDtlId.Value != null)
                {
                    strCanclDtlId = hiddenLedgerCanclDtlId.Value;
                    strarrCancldtlIdsGrp = strCanclDtlId.Split(',');

                }
                foreach (string strDtlId in strarrCancldtlIdsGrp)
                {
                    if (strDtlId != "" && strDtlId != null)
                    {
                        int intDtlId = Convert.ToInt32(strDtlId);
                        clsEntityPaymentAccount objSubEntityLedgerDEL = new clsEntityPaymentAccount();
                        objSubEntityLedgerDEL.Payment_Ledgr_Id = Convert.ToInt32(strDtlId);
                        objEntityLedgerDel.Add(objSubEntityLedgerDEL);

                    }
                }



                string strCanclDtlIdQst = "";
                string[] strarrCancldtlIdsQst = strCanclDtlIdQst.Split(',');
                if (hiddenQstnCanclDtlId.Value != "" && hiddenQstnCanclDtlId.Value != null)
                {
                    strCanclDtlIdQst = hiddenQstnCanclDtlId.Value;
                    strarrCancldtlIdsQst = strCanclDtlIdQst.Split(',');

                }
                foreach (string strDtlId1 in strarrCancldtlIdsQst)
                {
                    if (strDtlId1 != "" && strDtlId1 != null)
                    {
                        int intDtlId = Convert.ToInt32(strDtlId1);
                        clsEntityPaymentAccount objEntityCostCenterDEL = new clsEntityPaymentAccount();
                        objEntityCostCenterDEL.PaymentCostCntrId = Convert.ToInt32(strDtlId1);
                        objEntityCostCenterDEL.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                        objEntityCostCenterDel.Add(objEntityCostCenterDEL);

                    }
                }


            }
            if (clickedButton.ID == "btnConfirm1")
            {
                ObjEntityRequest.ConfirmStatus = 1;
            }

            if (Session["FINCYRID"] != "" && Session["FINCYRID"] != null)
                ObjEntityRequest.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);

            int flag = 0;
            int AcntCloseSts = AccountCloseCheck(txtdate.Value);

            int AuditCloseSts = AuditCloseCheck(txtdate.Value);


            if (AuditCloseSts == 1 && HiddenAuditProvisionStatus.Value != "1")
            {
                flag++;
                Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=AuditClosed");
            }
            else if (AuditCloseSts == 1 && HiddenAuditProvisionStatus.Value == "1")
            {

            }

            else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
            {
                flag++;
                Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=AcntClosed");
            }



            DataTable dtPCancel = objBussinessPayment.ChkPaymentMasterIsCancel(ObjEntityRequest);
            if (dtPCancel.Rows.Count > 0)
            {
                int intCancel = 0;
                intCancel = Convert.ToInt32(dtPCancel.Rows[0][0].ToString());
                if (intCancel > 0)
                {
                    flag++;
                    // ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancel", "SuccessCancel();", true);
                    Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=AlCancl");
                }
            }
            DataTable dtPConfrm = objBussinessPayment.ChkPaymentMasterIsCnfrm(ObjEntityRequest);
            if (dtPConfrm.Rows.Count > 0)
            {
                int intConfrm = 0;
                intConfrm = Convert.ToInt32(dtPConfrm.Rows[0][0].ToString());
                if (intConfrm > 0)
                {
                    flag++;
                    //       ScriptManager.RegisterStartupScript(this, GetType(), "SuccessNotConfirmation", "SuccessNotConfirmation();", true);
                    Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=CnfrmCncl");

                }
            }

       


            int PostdateChqSts = 0;
            DataTable dt = objBussinessPayment.Read_PayemntByID(ObjEntityRequest);
            if (dt.Rows.Count > 0)
            {
                PostdateChqSts = Convert.ToInt32(dt.Rows[0]["PAYMNT_POSTDATED_CHEQUE_STATUS"].ToString());
            }


            int intUsedIds = 0;
            if (PostdateChqSts == 1)
            {
                ObjEntityRequest.ChequeBookNumber = Convert.ToInt32(dt.Rows[0]["PAYMNT_CHQ_NUMBER"].ToString());

                //DataTable DtACI1 = objBussinessPayment.ReadChequeBook_UsedIds(ObjEntityRequest);
                //for (int i = 0; i < DtACI1.Rows.Count; i++)
                //{
                //    if (DtACI1.Rows[i]["PAYMNT_CHQ_NUMBER"].ToString() != "")
                //    {
                //        if (HiddenupdCheckNumber.Value != "")
                //        {
                //            if (Convert.ToInt32(HiddenupdCheckNumber.Value) == Convert.ToInt32(DtACI1.Rows[i]["PAYMNT_CHQ_NUMBER"].ToString()))
                //            {
                //                intUsedIds++;
                //                flag++;
                //                Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=ChkNo");
                //            }
                //        }
                //    }
                //}

                ObjEntityRequest.ChequeBookNumber = Convert.ToInt32(HiddenupdCheckNumber.Value);
            }
            if (strRets == "PrchsAmountExceeded")
            {
                flag++;
                Response.Redirect("fms_Payment_Account.aspx?InsUpd=PrchsAmountExceeded&Id=" + Request.QueryString["Id"].ToString());
            }
            else if (strRets == "PrchsAmtFullySettld")
            {
                flag++;
                Response.Redirect("fms_Payment_Account.aspx?InsUpd=PrchsAmtFullySettld&Id=" + Request.QueryString["Id"].ToString());
            }


            if (flag == 0)
            {

                if (DupChqNos > 0)
                {
                    Response.Redirect("fms_Payment_Account.aspx?Id=" + Request.QueryString["Id"].ToString() + "&InsUpd=ChqDup");
                }
                else
                {

                    objBussinessPayment.UpdatePaymentLedgerCostCenter(ObjEntityRequest, objEntityLedgerIns, objEntityLedgerUpd, objEntityLedgerDel, objEntityCostCenterIns, objEntityCostCenterUpd, objEntityCostCenterDel);


                    if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnFloatUpdate")
                    {
                        if (PostdateChqSts == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedValue", "PassSavedValue(0);", true);
                            if (Request.QueryString["VId"] != null)
                            {
                                Response.Redirect("fms_Payment_Account.aspx?Id=" + Request.QueryString["Id"].ToString() + "&InsUpd=Upd&VId=1");
                            }
                            else
                            {
                                Response.Redirect("fms_Payment_Account.aspx?Id=" + Request.QueryString["Id"].ToString() + "&InsUpd=Upd");
                            }
                        }
                        else
                        {
                            Response.Redirect("fms_Payment_Account.aspx?Id=" + Request.QueryString["Id"].ToString() + "&InsUpd=Upd");
                        }
                    }
                    else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnFloatUpdateCls")
                    {
                        Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnConfirm1")
                    {
                        if (PostdateChqSts == 1)
                        {
                            clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
                            clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();

                            objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_ID"].ToString());
                            objEntity_Cheque.ChequeBookId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_DTLS_ID"].ToString());
                            objEntity_Cheque.User_Id = ObjEntityRequest.User_Id;
                            //update paid status
                            objEntity_Cheque.Status = 1;
                            objBusiness_Cheque.UpdateChequePaidRejectStatus(objEntity_Cheque);

                            ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedValue", "PassSavedValue(1);", true);
                            if (Request.QueryString["VId"] != null)
                            {

                            }
                            else
                            {
                                Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=Confrm");
                            }
                        }
                        else
                        {
                            Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=Confrm");
                        }
                    }

                    //0039
                    //DataTable dt = objBussinessPayment.Read_PayemntByID(ObjEntityRequest);
                    if (dt.Rows[0]["PAYMNT_CNFRM_STS"].ToString() != "0")
                    {
                        Response.Redirect("fms_Payment_Account_List.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=AlreadyCnfm");
                        //strRets = "alrdyreopened";
                    }
                    //end
                    else if (clickedButton.ID == "btnFloatConfirm")
                    {
                        Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=Confrm");
                    }

                }

            }
        }

        //  objEmpPerfomance.InsertPerfomanceTemplate(objEntity, objEntityPerfomList, objEntityPerfomListGrps);
        if (clickedButton.ID == "bttnsave")
        {
            Response.Redirect("fms_Payment_Account.aspx?InsUpd=Ins");
        }
    }

    public void ChequeBookLoad(int AcntGrpId)
    {
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        ObjEntityRequest.LedgerId = AcntGrpId;
        if (Session["CORPOFFICEID"] != null)
        {
            int intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            ObjEntityRequest.Corporate_id = intCorpId;
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            int intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityRequest.Organisation_id = intOrgId;
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtChequeBook = objBussiness.ReadChequeBooks(ObjEntityRequest);
        if (dtChequeBook.Rows.Count > 0)
        {
            ddlChequeBook_Cheque.DataSource = dtChequeBook;
            ddlChequeBook_Cheque.DataTextField = "CHKBK_NAME";
            ddlChequeBook_Cheque.DataValueField = "CHKBK_ID";
            ddlChequeBook_Cheque.DataBind();
        }
        ddlChequeBook_Cheque.Items.Insert(0, "--SELECT--");
        //   ddlChequeNum_Cheque.Items.Insert(0, "--SELECT--");
    }
    [WebMethod]
    public static string LoadChequeBookNumber(string ChequeBook, string status, string CorpId, string OrgId, string BankId, string EditId)
    {
        string result = "";
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        if (ChequeBook != "" && ChequeBook != "--SELECT--")
        {
            ObjEntityRequest.Organisation_id = Convert.ToInt32(OrgId);
            ObjEntityRequest.Corporate_id = Convert.ToInt32(CorpId);
            ObjEntityRequest.AccntNameId = Convert.ToInt32(BankId);
            ObjEntityRequest.ChequeBookId = Convert.ToInt32(ChequeBook);
            if (EditId != "")
            {
                ObjEntityRequest.PaymentId = Convert.ToInt32(EditId);
            }

            DataTable dtChqNumber = objBussiness.ReadChqNoByChqbkId(ObjEntityRequest);

            DataTable dtChqCancel = objBussiness.ReadChequeBook_CancelIds(ObjEntityRequest);

            dtChqCancel.TableName = "dtTableACIPackage";
            string strTotalChqNos = "";
            string strCancelIds = "";

            if (dtChqCancel.Rows.Count > 0)
            {
                strCancelIds = dtChqCancel.Rows[0]["CHKBK_CNCL_NUM"].ToString().TrimEnd(',',' ');
            }

            foreach (DataRow dtRow in dtChqNumber.Rows)
            {
                if (!(strCancelIds.Contains(Convert.ToString(dtRow["chqnum"].ToString()))))
                {
                    if (strTotalChqNos == "")
                    {
                        strTotalChqNos = Convert.ToString(dtRow["chqnum"].ToString());
                    }
                    else
                    {
                        strTotalChqNos = strTotalChqNos + "," + Convert.ToString(dtRow["chqnum"].ToString());
                    }
                }
            }

            result = strTotalChqNos;

           
        }
        return result;
    }
    [WebMethod]
    public static string CheckRefNumber(string jrnlDate, string orgID, string corptID, string UserID, string RefNum, string PaymentId)
    {
        string Ref = "";

        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(jrnlDate);
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();


        cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();

        objEntityAudit.FromDate = objCommon.textToDateTime(jrnlDate);


        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_PAYMENT);
        objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
        ObjEntityRequest.FromDate = objCommon.textToDateTime(jrnlDate);

        if (corptID != null && corptID != "")
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(corptID);
            ObjEntityRequest.Corporate_id = Convert.ToInt32(corptID);
            objEntityAudit.Corporate_id = Convert.ToInt32(corptID);

        }
        if (orgID != null && orgID != "")
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(orgID);
            ObjEntityRequest.Organisation_id = Convert.ToInt32(orgID);
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
            DataTable dtRefFormat1 = objBussiness.ReadRefNumberByDate(ObjEntityRequest);
            string strRef = "";
            if (dtRefFormat1.Rows.Count > 0)
            {

                if (dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "")
                {
                    if (Convert.ToInt32(dtRefFormat1.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString()) != 1)
                    {
                        strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                        strRef = strRef.TrimEnd('/');
                        strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                    }
                    else
                    {
                        strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                    }
                }
                else
                {
                    strRef = dtRefFormat1.Rows[0]["PAYMNT_REF"].ToString();
                }
                ObjEntityRequest.RefNum = strRef;
                DataTable dtRefFormat = objBussiness.ReadRefNumberByDateLast(ObjEntityRequest);
                if (dtRefFormat.Rows.Count > 0)
                {
                    // if (Convert.ToInt32(PaymentId) != Convert.ToInt32(dtRefFormat.Rows[0]["PAYMNT_ID"].ToString()))
                    //  {
                    Ref = dtRefFormat.Rows[0]["PAYMNT_REF"].ToString();
                    if (dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != null)
                    {
                        SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString());
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
                    //}
                }
            }
        }
        else
        {
            if (PaymentId == "")
            {

                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_PAYMENT);
                objEntityCommon.CorporateID = Convert.ToInt32(corptID);
                objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
                string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);
                DataTable dtFormate = objBussiness.readRefFormate(objEntityCommon);
                string CurrentDate = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
                DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                int DtYear = dtCurrentDate.Year;
                int DtMonth = dtCurrentDate.Month;
                string dtyy = dtCurrentDate.ToString("yy");

                if (HttpContext.Current.Session["FINCYRID"] != null)
                {
                    objEntityCommon.FinancialYrId = Convert.ToInt32(HttpContext.Current.Session["FINCYRID"]);
                }

                DataTable dtCurrentFiscalYr = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
                DateTime dtFinStartDate = new DateTime();
                DateTime dtFinEndDate = new DateTime();
                if (dtCurrentFiscalYr.Rows.Count > 0)
                {
                    dtFinStartDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_START_DT"].ToString());
                    dtFinEndDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_END_DT"].ToString());
                }

                string refFormatByDiv = "";
                string strRealFormat = "";
                if (dtFormate.Rows.Count > 0)
                {
                    if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                    {
                        refFormatByDiv = dtFormate.Rows[0]["REF_FORMATE"].ToString();
                        string strReferenceFormat = "";
                        strReferenceFormat = refFormatByDiv;
                        int flag = 0;
                        string[] arrReferenceSplit = strReferenceFormat.Split('*');
                        int intArrayRowCount = arrReferenceSplit.Length;
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
                            strRealFormat = strRealFormat.Replace("#USR#", UserID);
                        }

                        //2019
                        if (strRealFormat.Contains("#YER#"))
                        {
                            strRealFormat = strRealFormat.Replace("#YER#", DtYear.ToString());
                        }
                        if (strRealFormat.Contains("#FYERS#"))
                        {
                            strRealFormat = strRealFormat.Replace("#FYERS#", dtFinStartDate.Year.ToString());
                        }
                        if (strRealFormat.Contains("#FYERE#"))
                        {
                            strRealFormat = strRealFormat.Replace("#FYERE#", dtFinEndDate.Year.ToString());
                        }

                        //19
                        if (strRealFormat.Contains("#YY#"))
                        {
                            strRealFormat = strRealFormat.Replace("#YY#", dtyy.ToString());
                        }
                        if (strRealFormat.Contains("#FYYS#"))
                        {
                            strRealFormat = strRealFormat.Replace("#FYYS#", dtFinStartDate.ToString("yy"));
                        }
                        if (strRealFormat.Contains("#FYYE#"))
                        {
                            strRealFormat = strRealFormat.Replace("#FYYE#", dtFinEndDate.ToString("yy"));
                        }

                        if (strRealFormat.Contains("#MON#"))
                        {
                            strRealFormat = strRealFormat.Replace("#MON#", DtMonth.ToString());
                        }
                        if (strRealFormat.Contains("#NUM#"))
                        {
                            strRealFormat = strRealFormat.Replace("#NUM#", strNextId);
                        }
                        else
                        {
                            strRealFormat = strRealFormat + "/" + strNextId;
                        }
                        strRealFormat = strRealFormat.Replace("#", "");
                        strRealFormat = strRealFormat.Replace("*", "");
                        strRealFormat = strRealFormat.Replace("%", "");
                    }
                    Ref = strRealFormat;
                }
                else
                {
                    Ref = strNextId;
                }
            }
        }

        return Ref;
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

    //protected void btnPRint_Click(object sender, EventArgs e)
    //{
    //    string strId = "";
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
    //        string PreparedBy = "";
    //        string CheckedBy = "";

    //        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
    //        clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();

    //        clsCommonLibrary objCommn = new clsCommonLibrary();

    //        if (Session["CORPOFFICEID"] != null)
    //        {
    //            ObjEntityRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //        }
    //        else if (Session["CORPOFFICEID"] == null)
    //        {
    //            Response.Redirect("~/Default.aspx");
    //        }
    //        if (Session["ORGID"] != null)
    //        {
    //            ObjEntityRequest.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
    //        }
    //        else if (Session["ORGID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        if (Session["USERID"] != null)
    //        {
    //            //intUserId = Convert.ToInt32(Session["USERID"]);
    //            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
    //        }
    //        else if (Session["USERID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }

    //        ObjEntityRequest.PaymentId = Convert.ToInt32(strId);




    //        if (Session["USERFULLNAME"] != null)
    //        {
    //            PreparedBy = Session["USERFULLNAME"].ToString();
    //        }


    //        DataTable dt = objBussinessPayment.Read_PayemntByID(ObjEntityRequest);

    //        if (dt.Rows.Count > 0)
    //        {
    //            if (dt.Rows[0]["USR_NAME"].ToString() != "")
    //            {
    //                CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
    //            }
    //        }
    //        DataTable dtProduct = objBussinessPayment.Read_PayemntLedgerByIDForPrint(ObjEntityRequest);



    //        DataTable dtCorp = objBussinessPayment.ReadCorpDtls(ObjEntityRequest);
    //        PdfPrint(strId, dt, dtProduct, dtCorp, ObjEntityRequest, PreparedBy, CheckedBy);
    //    }
    //}
   protected void btnReopen_Click(object sender, EventArgs e)
    {
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        List<clsEntityPaymentAccount> objEntityLedger = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityLedgerCostCenter = new List<clsEntityPaymentAccount>();

        clsCommonLibrary objCommon = new clsCommonLibrary();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
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
            //intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntityRequest.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        string strRets = "successReopen";
        string NewRev = "";

        string strId = "";
        if (Request.QueryString["ViewId"] != null)
        {
            string strRandomMixedId = Request.QueryString["ViewId"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            strId = strRandomMixedId.Substring(2, intLenghtofId);
        }


        ObjEntityRequest.PaymentId = Convert.ToInt32(strId);

        try
        {
            DataTable dt = objBussiness.Read_PayemntByID(ObjEntityRequest);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["PAYMNT_ACCNT_LDGR_ID"].ToString() != "")
                {
                    if (dt.Rows[i]["PAYMNT_ACCNT_LDGR_ID"].ToString() != "")
                    {
                        ObjEntityRequest.LedgerId = Convert.ToInt32(dt.Rows[i]["PAYMNT_ACCNT_LDGR_ID"].ToString());
                    }
                    if (dt.Rows[i]["PURCHS_NET_TOTAL"].ToString() != "")
                    {
                        ObjEntityRequest.LedgerAmnt = Convert.ToDecimal(dt.Rows[i]["PURCHS_NET_TOTAL"].ToString());
                    }
                    // objEntityLedger.Add(ObjSubEntityRequest);
                }

            }
            DataTable dtLDGRdTLS = objBussiness.Read_PayemntLedgerByID(ObjEntityRequest);

            for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
            {
                clsEntityPaymentAccount ObjSubEntityRequestCostAndPurchase = new clsEntityPaymentAccount();
                clsEntityPaymentAccount ObjSubEntityRequest = new clsEntityPaymentAccount();
                if (!(NewRev.Contains(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString())) && dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_AMT"].ToString() != "")
                {
                    if (!(NewRev.Contains(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString())))
                    {
                        ObjSubEntityRequest.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                        NewRev = NewRev + "," + dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString();
                    }
                    if (dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_AMT"].ToString() != "")
                    {
                        ObjSubEntityRequest.LedgerAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_AMT"].ToString());
                    }
                    objEntityLedger.Add(ObjSubEntityRequest);

                    //EVM-0027 Aug 09
                    ObjSubEntityRequest.Organisation_id = ObjEntityRequest.Organisation_id;
                    ObjSubEntityRequest.Corporate_id = ObjEntityRequest.Corporate_id;
                    ObjSubEntityRequest.PaymentId = ObjEntityRequest.PaymentId;
                    ObjSubEntityRequest.Payment_Ledgr_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PAYMNT_LD_ID"].ToString());
                    DataTable dtForOB = objBussiness.ReadOepningBalById(ObjSubEntityRequest);
                    if (dtForOB.Rows.Count > 0)
                    {
                        ObjSubEntityRequest.VoucherCategory = 1;
                        decimal decOpeningBal = 0;
                        if (dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                        {
                            decOpeningBal = Convert.ToDecimal(dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString());
                        }
                        decimal decPaidAmt = 0;
                        if (dtForOB.Rows[0]["OBPAID_AMT"].ToString() != "")
                        {
                            decPaidAmt = Convert.ToDecimal(dtForOB.Rows[0]["OBPAID_AMT"].ToString());
                        }
                        ObjSubEntityRequest.BalnceAmt = decOpeningBal - decPaidAmt;
                    }
                    //END
                }
                if (dtLDGRdTLS.Rows[intCount]["COSTCNTR_ID"].ToString() != "" || dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString() != "" || dtLDGRdTLS.Rows[intCount]["DEBIT_NOTE_ID"].ToString() != "" || dtLDGRdTLS.Rows[intCount]["EXPENSE_ID"].ToString() != "")
                {
                    if (dtLDGRdTLS.Rows[intCount]["COSTCNTR_ID"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.CostCtrId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["COSTCNTR_ID"].ToString());
                    }
                    else
                    {
                        ObjSubEntityRequestCostAndPurchase.CostCtrId = 0;
                    }
                    if (dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.PurchaseId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PURCHS_ID"].ToString());
                    }
                    else
                    {
                        ObjSubEntityRequestCostAndPurchase.PurchaseId = 0;
                    }
                    if (dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_AMT"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.CstCntrAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_AMT"].ToString());
                    }
                    if (dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString() != "")
                        ObjSubEntityRequestCostAndPurchase.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                    if (dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_DEBIT_STATUS"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.DebitNoteStatus = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_DEBIT_STATUS"].ToString());
                    }
                    if (dtLDGRdTLS.Rows[intCount]["DEBIT_NOTE_ID"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.DebitNoteId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["DEBIT_NOTE_ID"].ToString());
                    }
                    if (dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_DEBIT_AMT"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.DebitNoteAmount = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["PAYMNT_CST_DEBIT_AMT"].ToString());
                    }
                    if (dtLDGRdTLS.Rows[intCount]["LDGR_DR_REMAIN_SETTLE_AMT"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.DebitNoteRemainingAmount = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["LDGR_DR_REMAIN_SETTLE_AMT"].ToString());
                    }

                    if (dtLDGRdTLS.Rows[intCount]["EXPENSE_ID"].ToString() != "")
                    {
                        ObjSubEntityRequestCostAndPurchase.ExpenceId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["EXPENSE_ID"].ToString());
                        ObjSubEntityRequestCostAndPurchase.ExpnsAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["EXPENSE_AMT"].ToString());
                        ObjSubEntityRequestCostAndPurchase.TotalExpnsAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["EXPENSE_DTL_BALNC_AMT"].ToString());
                    }

                    objEntityLedgerCostCenter.Add(ObjSubEntityRequestCostAndPurchase);
                }
            }

            DataTable dtCHK = objBussiness.CheckPaymentCnclSts(ObjEntityRequest);
            int AcntCloseSts = AccountCloseCheck(txtdate.Value);

            int AuditCloseSts = AuditCloseCheck(txtdate.Value);


            if (AuditCloseSts == 1 && HiddenAuditProvisionStatus.Value != "1")
            {

                Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=AuditClosed");
            }
            else if (AuditCloseSts == 1 && HiddenAuditProvisionStatus.Value == "1")
            {

            }

            else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
            {

                Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=AcntClosed");
            }
            else if (dtCHK.Rows[0]["PAYMNT_REOPEN_USRID"].ToString() != "" && dtCHK.Rows[0]["PAYMNT_CNFRM_STS"].ToString() == "0")
            {
                Response.Redirect("fms_Payment_Account.aspx?Id=" + Request.QueryString["ViewId"] + "&InsUpd=alrdyreopened");
                //strRets = "alrdyreopened";
            }


            if (dtCHK.Rows[0][0].ToString() == "")
            {
                objBussiness.PayemntReOpenById(ObjEntityRequest, objEntityLedger, objEntityLedgerCostCenter);
                Response.Redirect("fms_Payment_Account.aspx?Id=" + Request.QueryString["ViewId"] + "&InsUpd=Reop");
            }
            else if (dtCHK.Rows[0][0].ToString() != "")
            {
                Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=UpdCancl");
            }




            //  objBussiness.PayemntReOpenById(ObjEntityRequest, objEntityLedger, objEntityLedgerCostCenter);
        }
        catch
        {
            strRets = "failed";
        }

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

    [WebMethod]
    public static string PrintPDF(string saleId, string orgID, string corptID, string currency, string currencyId)
    {

        string strId = saleId;
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsEntityPaymentAccount ObjEntityPayment = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (corptID != null)
        {
            ObjEntityPayment.Corporate_id = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        }
        if (orgID != null)
        {
            ObjEntityPayment.Organisation_id = Convert.ToInt32(orgID);
        }
        if (currencyId != null)
        {
            ObjEntityPayment.CurrcyId = Convert.ToInt32(currencyId);
        }
        ObjEntityPayment.PaymentId = Convert.ToInt32(strId);
        FMS_FMS_Master_fms_Payment_Account_fms_Payment_Account objPage = new FMS_FMS_Master_fms_Payment_Account_fms_Payment_Account();
        DataTable dt = objBussinessPayment.Read_PayemntByID(ObjEntityPayment);
        DataTable dtProduct = objBussinessPayment.Read_PayemntLedgerByIDForPrint(ObjEntityPayment);
        DataTable dtCost = new DataTable();

        if (dtProduct.Rows[0]["PAYMNT_LD_ID"].ToString() != "")
        {
            ObjEntityPayment.Payment_Ledgr_Id = Convert.ToInt32(dtProduct.Rows[0]["PAYMNT_LD_ID"].ToString());
        }

        if (dtProduct.Rows.Count == 1)
        {
            ObjEntityPayment.LedgerId = Convert.ToInt32(dtProduct.Rows[0]["PAYMNT_LD_ID"].ToString());
            dtCost = objBussinessPayment.Read_PayemntCostByID(ObjEntityPayment);

        }
        DataTable dtCorp = objBussinessPayment.ReadCorpDtls(ObjEntityPayment);
        if (dt.Rows[0]["PAYMNT_ACCNT_LDGR_ID"].ToString() != "")
        {
            ObjEntityPayment.LedgerId = Convert.ToInt32(dt.Rows[0]["PAYMNT_ACCNT_LDGR_ID"].ToString());
        }
        DataTable dtPayment = objBussinessPayment.AccntBalancebyId(ObjEntityPayment);
        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.PAYMENT);
        string strReturn = "";
        DataTable dtVersion = objBusiness.ReadPrintVersion(objEntityCommon);
        if (dtVersion.Rows.Count > 0)
        {
            if (dtVersion.Rows[0][0].ToString() == "1")
            {
                // strReturn = objPage.PdfPrintVersion1(dt, dtProduct, dtCorp, ObjEntityPayment);
                strReturn = objBussinessPayment.PdfPrintVersion1(dt, dtProduct, dtCorp, ObjEntityPayment);
            }
            else if (dtVersion.Rows[0][0].ToString() == "2")
            {
                //   strReturn = objPage.PdfPrintVersion2(dt, dtProduct, dtCorp, ObjEntityPayment, 2, dtPayment, currency, dtCost);
                strReturn = objBussinessPayment.PdfPrintVersion2And3(dt, dtProduct, dtCorp, ObjEntityPayment, 2, dtPayment, currency, dtCost);
            }
            else if (dtVersion.Rows[0][0].ToString() == "3")
            {
                //  strReturn = objPage.PdfPrintVersion2(dt, dtProduct, dtCorp, ObjEntityPayment, 3, dtPayment, currency, dtCost);

                strReturn = objBussinessPayment.PdfPrintVersion2And3(dt, dtProduct, dtCorp, ObjEntityPayment, 3, dtPayment, currency, dtCost);
            }
        }
        return strReturn;

    }


    protected void bttnsave_Click(object sender, EventArgs e)
     {
        Button clickedButton = sender as Button;
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objcommon = new clsCommonLibrary();


        if (Request.QueryString["Rid"] != null)
        {
            string strRandomMixedId = Request.QueryString["Rid"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            ObjEntityRequest.RecurSubId = Convert.ToInt32(strId);
        }


        int intCorpId = 0, intOrgId = 0, intUserId = 0;
        if (Session["USERID"] != null)
        {
            intUserId = Convert.ToInt32(Session["USERID"]);

            ObjEntityRequest.User_Id = intUserId;

        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }


        if (Session["CORPOFFICEID"] != null)
        {
            intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());

            ObjEntityRequest.Corporate_id = intCorpId;
            // HiddenCorpId.Value = Session["CORPOFFICEID"].ToString();

        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            ObjEntityRequest.Organisation_id = intOrgId;

        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["FINCYRID"] != null)
        {
            ObjEntityRequest.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        ObjEntityRequest.LedgerId = Convert.ToInt32(ddlAccontLed.SelectedItem.Value);
        ObjEntityRequest.RefNum = TxtRef.Value;
        ObjEntityRequest.FromDate = objcommon.textToDateTime(txtdate.Value);
        ObjEntityRequest.CurrcyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
        if (ObjEntityRequest.CurrcyId != Convert.ToInt32(hiddenDfltCurrencyMstrId.Value))
        {
            if (txtExchangeRate.Value != "")
            {
                string ExchangeRate = txtExchangeRate.Value;
                ExchangeRate = ExchangeRate.Replace(",", "");
                ObjEntityRequest.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Value);
            }
        }
        if (txtDescription.Value != "")
        {
            ObjEntityRequest.Description = txtDescription.Value;
        }
        ObjEntityRequest.TotalAmnt = Convert.ToDecimal(txtGrantTotal.Value);
        ObjEntityRequest.AccntNameId = Convert.ToInt32(ddlAccontLed.SelectedItem.Value);

        int DupChqNos = 0;

        if (HiddenPrevTab.Value == "Cheque")
        {
            ObjEntityRequest.PayemntMode = 1;
            if (HiddenChequeBookId.Value != "")
                ObjEntityRequest.ChequeBookId = Convert.ToInt32(HiddenChequeBookId.Value);
            ObjEntityRequest.ChequeBookNumber = Convert.ToInt32(HiddenupdCheckNumber.Value);
            ObjEntityRequest.ToDate = objcommon.textToDateTime(txtDate_Cheque.Value);
            ObjEntityRequest.Payee = txtPayee.Value;
            if (ChkStatus_Cheque.Checked)
            {
                if (HiddenPrevTab.Value == "Cheque")
                {
                    ObjEntityRequest.ChequeIssue = 1;
                    ObjEntityRequest.ChequeIssueDate = objcommon.textToDateTime(txtIssueDate_Cheque.Value);
                }
            }
            else
            {
                ObjEntityRequest.ChequeIssue = 0;
            }

            DataTable dtCheqDup = objBussinessPayment.CheckChequeNumbersAdded(ObjEntityRequest);

            if (dtCheqDup.Rows.Count > 0 && Convert.ToInt32(dtCheqDup.Rows[0]["CNT_CHQNO"].ToString()) > 0)
            {
                DupChqNos++;
            }
        }
        else if (HiddenPrevTab.Value == "DD")
        {
            ObjEntityRequest.PayemntMode = 2;
            ObjEntityRequest.DD_Number = txtDD_DD.Value;
            ObjEntityRequest.ToDate = objcommon.textToDateTime(txtDate_DD.Value);
        }
        else if (HiddenPrevTab.Value == "BankTransfer")
        {
            ObjEntityRequest.PayemntMode = 3;
            ObjEntityRequest.BankTransfer_Mode = Convert.ToInt32(ddlMode_BankTransfer.SelectedValue);
            ObjEntityRequest.ToDate = objcommon.textToDateTime(txtDate_BankTransfer.Value);
            ObjEntityRequest.Bank_BankTransfer = Bank_BankTransfer.Value;
            ObjEntityRequest.IBAN_BankTransfer = IBAN_BankTransfer.Value;
        }


        int AcntCloseSts = AccountCloseCheck(txtdate.Value);
        int AuditCloseSts = AuditCloseCheck(txtdate.Value);


        if (AuditCloseSts == 1 && HiddenAuditProvisionStatus.Value != "1")
        {
            Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=AuditClosed");
        }
        else if (AuditCloseSts == 1 && HiddenAuditProvisionStatus.Value == "1")
        {

        }

        else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
        {
            Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=AcntClosed");
        }


        //Start:-Recurrence
        if (HiddenFieldRecurrencyPeriod.Value != "")
        {
            ObjEntityRequest.RecurPeriodId = Convert.ToInt32(HiddenFieldRecurrencyPeriod.Value);
            ObjEntityRequest.RecurRemindDays = Convert.ToInt32(HiddenFieldRemindDays.Value);
        }
        //End:-Recurrence

        //if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
        //{
        //    Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=AcntClosed");
        //}




        int intUsedIds = 0;

        List<clsEntityPaymentAccount> objEntityPerfomList = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityPerfomListGrps = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityInsertToVT = new List<clsEntityPaymentAccount>();//EVM-0027
        if (HiddenFieldSaveAccount.Value != "" && HiddenFieldSaveAccount.Value != null && HiddenFieldSaveAccount.Value != "[]")
        {
            string jsonDataDltAttch = HiddenFieldSaveAccount.Value;
            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
            string strAtt2 = strAtt1.Replace("\\", "");
            string strAtt3 = strAtt2.Replace("}\"]", "}]");
            string strAtt4 = strAtt3.Replace("}\",", "},");
            List<clsAccntDetails> objVideoDataDltAttList = new List<clsAccntDetails>();
            //   UserData  data
            objVideoDataDltAttList = JsonConvert.DeserializeObject<List<clsAccntDetails>>(strAtt4);

            foreach (clsAccntDetails objClsVideoAddAttData in objVideoDataDltAttList)
            {
                clsEntityPaymentAccount objSubEntityGrp = new clsEntityPaymentAccount();


                objSubEntityGrp.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                objSubEntityGrp.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                if (Request.Form["txtAmntVal" + objClsVideoAddAttData.LEDGERID] != "")
                {
                    objSubEntityGrp.LedgerAmnt = Convert.ToDecimal(Request.Form["txtAmntVal" + objClsVideoAddAttData.LEDGERID]);
                }
                if (Request.Form["TxtRemark" + objClsVideoAddAttData.LEDGERID] != "")
                {
                    objSubEntityGrp.Remarks = Request.Form["TxtRemark" + objClsVideoAddAttData.LEDGERID];
                }
                string CostCenterDtl = Request.Form["tdCostCenterDtls" + objClsVideoAddAttData.LEDGERID];
                if (CostCenterDtl != "" && CostCenterDtl != "null" && CostCenterDtl != null)
                {
                    string[] CostCenterDtlvalues = CostCenterDtl.Split('$');
                    for (int i = 0; i < CostCenterDtlvalues.Length; i++)
                    {
                        clsEntityPaymentAccount objSubEntity = new clsEntityPaymentAccount();
                        objSubEntity.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                        objSubEntity.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                        string[] valSplit = CostCenterDtlvalues[i].Split('%');
                        objSubEntity.CostCtrId = Convert.ToInt32(valSplit[0]);
                        valSplit[1] = valSplit[1].Replace(",", "");
                        if (valSplit[1] != "")
                        {
                            objSubEntity.CstCntrAmnt = Convert.ToDecimal(valSplit[1]);
                        }
                        if (valSplit[2] != "" && valSplit[2] != null)
                        {
                            objSubEntity.CostGrp1Id = Convert.ToInt32(valSplit[2]);
                        }
                        if (valSplit[3] != "" && valSplit[3] != null)
                        {
                            objSubEntity.CostGrp2Id = Convert.ToInt32(valSplit[3]);
                        }

                        objEntityPerfomList.Add(objSubEntity);

                    }
                }

                string OBtoVT = Request.Form["tdLedgrPaid" + objClsVideoAddAttData.LEDGERID];

                clsEntityPaymentAccount objSubEntityOB = new clsEntityPaymentAccount();
                if (OBtoVT != "" && OBtoVT != "null" && OBtoVT != null)
                {
                    string[] OBvalues = OBtoVT.Split('#');
                    //   objSubEntityOB.ReceiptId = Convert.ToInt32(HiddenFieldTaxId.Value);
                    objSubEntityOB.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                    objSubEntityOB.FromDate = ObjEntityRequest.FromDate;
                    objSubEntityOB.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                    objSubEntityOB.Status = 1;
                    objSubEntityOB.PaidAmt = Convert.ToDecimal(OBvalues[0]);
                    objSubEntityOB.BalnceAmt = Convert.ToDecimal(OBvalues[1]);
                    objSubEntityOB.Organisation_id = ObjEntityRequest.Organisation_id;
                    objSubEntityOB.Corporate_id = ObjEntityRequest.Corporate_id;
                    //objSubEntityOB.ReceiptLedgrId = objSubEntityLedgeri.ReceiptLedgrId;
                    objEntityInsertToVT.Add(objSubEntityOB);
                    objEntityPerfomList.Add(objSubEntityOB);
                }


                //evm-0043 20-03 start

                string PurchaseDtl = Request.Form["tdPurchaseDtls" + objClsVideoAddAttData.LEDGERID];
                string TableSts = Request.Form["tdStatus" + objClsVideoAddAttData.LEDGERID];
                if (PurchaseDtl != "" && PurchaseDtl != "null" && PurchaseDtl != null)
                {
                    string[] values = PurchaseDtl.Split('$');
                   // string[] valSplit = values[i].Split('%');
                  
                        for (int i = 0; i < values.Length; i++)
                        {
                            clsEntityPaymentAccount objSubEntity = new clsEntityPaymentAccount();

                            objSubEntity.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                            objSubEntity.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                            string[] valSplit = values[i].Split('%');
                            if (valSplit[7] == "1")
                            {

                                objSubEntity.PurchaseId = Convert.ToInt32(valSplit[0]);
                                valSplit[1] = valSplit[1].Replace(",", "");
                                if (valSplit[1] != "")

                                    objSubEntity.CstCntrAmnt = Convert.ToDecimal(valSplit[1]);
                                valSplit[2] = valSplit[2].Replace(",", "");
                                objSubEntity.PurchaseActAmount = Convert.ToDecimal(valSplit[2]);
                                valSplit[3] = valSplit[3].Replace(",", "");
                                if (valSplit[3] != "0")
                                {
                                    objSubEntity.DebitNoteStatus = Convert.ToInt32(valSplit[3]);
                                    valSplit[4] = valSplit[4].Replace(",", "");
                                    if (valSplit[4] != "0")
                                        objSubEntity.DebitNoteId = Convert.ToInt32(valSplit[4]);
                                    valSplit[5] = valSplit[5].Replace(",", "");
                                    if (valSplit[5] != "0")
                                        objSubEntity.DebitNoteAmount = Convert.ToDecimal(valSplit[5]);
                                    if (valSplit[6] != "0")
                                        objSubEntity.DebitNoteRemainingAmount = Convert.ToDecimal(valSplit[6]);
                                }
                                objEntityPerfomList.Add(objSubEntity);

                            }
                              else
                              {
                                 
                                      clsEntityPaymentAccount objSubEntity1 = new clsEntityPaymentAccount();

                                      objSubEntity1.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                                      objSubEntity1.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                                      objSubEntity1.ExpenceId = Convert.ToInt32(valSplit[0]);
                                      valSplit[1] = valSplit[1].Replace(",", "");
                                      if (valSplit[1] != "")

                                          objSubEntity1.ExpnsAmnt = Convert.ToDecimal(valSplit[1]);
                                      valSplit[2] = valSplit[2].Replace(",", "");
                                      objSubEntity1.TotalExpnsAmnt = Convert.ToDecimal(valSplit[2]);
                                      objEntityPerfomList.Add(objSubEntity1);
                              }
                        }
                }
                   
              //end

                //0043
                //string ExpnsDtl = Request.Form["tdExpenseDtls" + objClsVideoAddAttData.LEDGERID];
                //if (ExpnsDtl != "" && ExpnsDtl != "null" && ExpnsDtl != null)
                //{
                //    string[] values = ExpnsDtl.Split('$');
                //    for (int i = 0; i < values.Length; i++)
                //    {
                //        clsEntityPaymentAccount objSubEntity = new clsEntityPaymentAccount();

                //        objSubEntity.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                //        objSubEntity.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                //        string[] valSplit = values[i].Split('%');
                //        objSubEntity.ExpenceId = Convert.ToInt32(valSplit[0]);
                //        valSplit[1] = valSplit[1].Replace(",", "");
                //        if (valSplit[1] != "")

                //            objSubEntity.ExpnsAmnt = Convert.ToDecimal(valSplit[1]);
                //        valSplit[2] = valSplit[2].Replace(",", "");
                //        objSubEntity.TotalExpnsAmnt = Convert.ToDecimal(valSplit[2]);
                //        objEntityPerfomList.Add(objSubEntity);
                //    }
                //}
                //end



                objEntityPerfomListGrps.Add(objSubEntityGrp);
            }

            //DataTable DtACI1 = objBussinessPayment.ReadChequeBook_UsedIds(ObjEntityRequest);
            //for (int i = 0; i < DtACI1.Rows.Count; i++)
            //{
            //    if (DtACI1.Rows[i]["PAYMNT_CHQ_NUMBER"].ToString() != "")
            //    {
            //        if (HiddenupdCheckNumber.Value != "")
            //        {
            //            if (Convert.ToInt32(HiddenupdCheckNumber.Value) == Convert.ToInt32(DtACI1.Rows[i]["PAYMNT_CHQ_NUMBER"].ToString()))
            //            {
            //                intUsedIds++;
            //            }
            //        }
            //    }
            //}
            if (intUsedIds == 0)
            {
                if (DupChqNos > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ChequeNoDuplicate", "ChequeNoDuplicate();", true);
                }
                else
                {
                    objBussinessPayment.InsertPaymentMaster(ObjEntityRequest, objEntityPerfomList, objEntityPerfomListGrps);
                }
            }
        }
        if (intUsedIds == 0 && DupChqNos == 0)
        {
            if (clickedButton.ID == "bttnsave")
            {
                Response.Redirect("fms_Payment_Account.aspx?InsUpd=Ins");
            }
            else if(clickedButton.ID == "btnSaveCls")
            {
                Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnFloatSave")
            {
                Response.Redirect("fms_Payment_Account.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnFloatSaveCls")
            {
                Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=Ins");
            }
        }
        else if (intUsedIds == 1)
        {
            Response.Redirect("fms_Payment_Account_List.aspx?InsUpd=ChkNo");
        }
    }

    [WebMethod]
    public static string LoadDebitNoteBalance(string DebitNoteId, string corpid, string orgid, string LedgerId)
    {
        string DebitBalance = "";
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        if (LedgerId != "")
            ObjEntityRequest.LedgerId = Convert.ToInt32(LedgerId);
        if (corpid != "")
            ObjEntityRequest.Corporate_id = Convert.ToInt32(corpid);
        if (orgid != "")
            ObjEntityRequest.Organisation_id = Convert.ToInt32(orgid);
        if (DebitNoteId != "")
            ObjEntityRequest.DebitNoteId = Convert.ToInt32(DebitNoteId);
        DataTable dtBalance = objBussiness.ReadPurchaseDebitNoteBalanceDtls(ObjEntityRequest);
        if (dtBalance.Rows.Count > 0)
        {
            if (dtBalance.Rows[0]["LDGR_DR_REMAIN_SETTLE_AMT"].ToString() != "" && Convert.ToDecimal(dtBalance.Rows[0]["LDGR_DR_REMAIN_SETTLE_AMT"].ToString()) > 0)
                DebitBalance = dtBalance.Rows[0]["LDGR_DR_REMAIN_SETTLE_AMT"].ToString();
            else if (dtBalance.Rows[0]["LDGR_DR_AMT"].ToString() != "")
                DebitBalance = dtBalance.Rows[0]["LDGR_DR_AMT"].ToString();
        }
        return DebitBalance;
    }

    [WebMethod]
    public static string CheckSaleSettlement(string strSalePurchaseDtls, string strOrgIdID, string strCorpID, string strTotalAmnt, string strPurchaseId)
    {
        string ret = "successConfirm";//evm-0020

        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();

        string SalePurchaseDtl = strSalePurchaseDtls;
        if (SalePurchaseDtl != "" && SalePurchaseDtl != "null" && SalePurchaseDtl != null)
        {
            string[] values = SalePurchaseDtl.Split('$');
            for (int i = 0; i < values.Length; i++)
            {
                clsEntityPaymentAccount objSubEntity = new clsEntityPaymentAccount();

                ObjEntityRequest.Organisation_id = Convert.ToInt32(strOrgIdID);
                ObjEntityRequest.Corporate_id = Convert.ToInt32(strCorpID);
                if (values[i] != "")
                {
                    string[] valSplit = values[i].Split('%');

                    if (valSplit[7] != "0")
                    {

                        objSubEntity.PurchaseId = Convert.ToInt32(valSplit[0]);

                        int intCreditNoteSettleSts = Convert.ToInt32(valSplit[3]);

                        valSplit[1] = valSplit[1].Replace(",", "");
                        if (valSplit[1] != "")
                        {
                            objSubEntity.CstCntrAmnt = Convert.ToDecimal(valSplit[1]);
                        }
                        if (valSplit[3] == "1")
                        {
                            objSubEntity.DebitNoteAmount = Convert.ToDecimal(valSplit[5]);
                        }

                        objSubEntity.DebitNoteRemainingAmount = Convert.ToDecimal(valSplit[6]);


                        objSubEntity.Organisation_id = ObjEntityRequest.Organisation_id;
                        objSubEntity.Corporate_id = ObjEntityRequest.Corporate_id;

                        DataTable dtSalesBalance = objBussinessPayment.ReadPurchaseBalance(objSubEntity);

                        if (intCreditNoteSettleSts == 1)
                        {
                            dtSalesBalance = objBussinessPayment.ReadSalesReturnBalance(objSubEntity);
                        }

                        decimal decCheckAmnt = objSubEntity.CstCntrAmnt;
                        if (intCreditNoteSettleSts == 1)
                        {
                            decCheckAmnt = objSubEntity.LedgerAmnt;
                        }

                        decimal decSalesRemainAmt = 0;
                        if (dtSalesBalance.Rows.Count > 0)
                        {
                            if (dtSalesBalance.Rows[0][1].ToString() != "")
                                decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                        }

                        if (decSalesRemainAmt != 0)
                        {
                            if (decSalesRemainAmt < decCheckAmnt)
                            {
                                ret = "PrchsAmountExceeded";
                                break;
                            }
                            else
                            {
                                if (strPurchaseId == objSubEntity.PurchaseId.ToString() && decSalesRemainAmt < Convert.ToDecimal(strTotalAmnt))
                                {
                                    ret = "PrchsAmountExceeded";
                                    break;
                                }
                            }
                        }
                        else
                        {
                            ret = "PrchsAmtFullySettld";
                        }
                    }

                }
            }

        }

        return ret;
    }


    //evm-0043 start
    [WebMethod]
    public static string[] LoadExpenceForLedger(string intLedgerId, string intuserid, string intorgid, string intcorpid, string mode, string x, string strCrncyAbrv, string paymentID, string View, string LedgerDtlId, string expenceID)
    {
        string[] result = new string[8];
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        ObjEntityRequest.LedgerId = Convert.ToInt32(intLedgerId);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(intcorpid);
        if (paymentID != "")
        {
            ObjEntityRequest.PaymentId = Convert.ToInt32(paymentID);
        }
        if (LedgerDtlId != "")
        {
            ObjEntityRequest.Payment_Ledgr_Id = Convert.ToInt32(LedgerDtlId);
        }
        if (expenceID != "")
        {
            ObjEntityRequest.ExpenceId = Convert.ToInt32(expenceID);
        }

        DataTable dtExpense = objBussiness.ReadExpensebyId(ObjEntityRequest);//expense


        StringBuilder sb = new StringBuilder();
        StringBuilder sbGrp = new StringBuilder();
        string Groupid = "";
        string SettldFully = "";
        int SettledCnt = 0;
        string strDebCr = "";
        int intOBSts = 0;


        if (dtExpense.Rows.Count > 0)
        {

            for (int row1 = 0; row1 < dtExpense.Rows.Count; row1++)
            {
                decimal decTotal = 0;
                if (dtExpense.Rows[row1]["EXPENSE_DTL_AMT"].ToString() != "")
                {
                    decTotal = Convert.ToDecimal(dtExpense.Rows[row1]["EXPENSE_DTL_AMT"].ToString());
                }
                else if (dtExpense.Rows[row1]["EXPENS_BAL_AMT"].ToString() != "")
                {
                    decTotal = Convert.ToDecimal(dtExpense.Rows[row1]["EXPENS_BAL_AMT"].ToString());
                }

                if (row1 % 2 == 1)
                {

                    sb.Append("<tr class=\"tr\" id=\"SelectRow" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >");
                }
                else
                {
                    sb.Append("<tr class=\"tr1\" id=\"SelectRow" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >");
                }
                    sb.Append("<td style=\"display:none;\" id=\"tdExpenseID" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "</td>");
                sb.Append("<td style=\"display:none;\" > <label class=\"checkbox \" ><input type=\"checkbox\"  onkeypress=\"return DisableEnter(event);\"  value=\"" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" id=\"cbMandatory" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"><i></i></label></td>");
                sb.Append("<td style=\"display:none;\" id=\"tdLedgerRow" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >" + x + "</td>");
                sb.Append("<td style=\"display:none;\" id=\"tdLedgerName" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">" + dtExpense.Rows[row1]["LDGR_NAME"].ToString() + "</td>");
                sb.Append("<td style=\"display:none;\" id=\"tdDupAmnt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >" + decTotal + "</td>");//evm-0020

                sb.Append("<td class=\"td1\" id=\"tdRef" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >" + dtExpense.Rows[row1]["EXPENSE_REF"].ToString() + "</td>");
                sb.Append("<td id=\"tdRef1" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">" + dtExpense.Rows[row1]["SALES_REF"].ToString() + "</td>");
                sb.Append("<td id=\"tdDate" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >" + dtExpense.Rows[row1]["SALES_DATE"].ToString() + "</td>");
                sb.Append("<td class=\" tr_r\" id=\"tdAmnt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >" + decTotal + "</td>");

                if (decTotal == 0)//Settlements present when already settled
                {
                    sb.Append("<td disabled class=\"td1 tr_r\" id=\"tdtxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">");
                    sb.Append("<div class=\"input-group in1\">");
                    sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                    sb.Append("<input   type=\"text\" class=\"form-control fg2_inp2 tr_r\" maxlength=\"10\" onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + ");\"  id=\"txtPurchaseAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"    />");

                    sb.Append("</div><span id=\"AccntBalanceExpns" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                    sb.Append("</td>");
                    sb.Append("<td style=\"display: none;\"><input type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" id=\"tdSettld" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" value=\"0\" /></td>");

                    sb.Append("<td id=\"tdDebitNote_Status" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >");
                    sb.Append("<div><label class=\"switch\" >");
                    sb.Append("<input disabled type=\"checkbox\" id=\"DebitNoteSettle_Status" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" />");
                    sb.Append("<span class=\"slider_tog round\"></span>");
                    sb.Append("</label></div>");
                    sb.Append("</td>");

                    sb.Append("<td id=\"tdDebitNote_Ref" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">");
                    sb.Append("<select disabled onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" id=\"ddlDebitNote" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  onchange=\"ShowDebitNoteBalance(" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + ");\"  onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                    sb.Append("<option  value=\"0\">-Select </option>");
                    sb.Append("</select>");
                    sb.Append("<span id=\"DebitNoteBalance" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  class=\"input-group-addon cur2 c1_d\" ></span>");
                    sb.Append("</td>");

                    sb.Append("<td  id=\"tdDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">");
                    sb.Append("<div class=\"input-group\">");
                    //  sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                    sb.Append("<input disabled autocomplete=\"off\"  maxlength=\"10\"  type=\"text\" class=\"form-control fg2_inp2 tr_r fgs2\"  onkeydown=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + ");\"  id=\"txtDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"    />");
                    sb.Append("</div><span id=\"AccntBalanceDebitNote" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                    sb.Append("</td>");
                    SettledCnt++;
                }
                else
                {

                    sb.Append("<td class=\"td1 tr_r\"  id=\"tdtxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">");
                    sb.Append("<div class=\"input-group in1\">");
                    sb.Append("<span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");

                    sb.Append("<input  autocomplete=\"off\"  type=\"text\" class=\"form-control fg2_inp2 tr_r\" maxlength=\"10\" onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + ");\"  id=\"txtPurchaseAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"    />");

                    sb.Append("</div><span id=\"AccntBalanceExpns" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                    sb.Append("</td>");

                    sb.Append("<td style=\"display: none;\"><input type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" id=\"tdSettld" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" value=\"0\" /></td>");

                    sb.Append("<td id=\"tdDebitNote_Status" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" >");
                    sb.Append("<div><label class=\"switch\" >");
                    sb.Append("<input disabled type=\"checkbox\" id=\"DebitNoteSettle_Status" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" />");
                    sb.Append("<span class=\"slider_tog round\"></span>");
                    sb.Append("</label></div>");
                    sb.Append("</td>");

                    sb.Append("<td id=\"tdDebitNote_Ref" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">");
                    sb.Append("<select disabled onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" id=\"ddlDebitNote" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                    sb.Append("<option  value=\"0\">-Select </option>");
                    sb.Append("</select>");
                    sb.Append("<span id=\"DebitNoteBalance" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  class=\"input-group-addon cur2 c1_d\" ></span>");
                    sb.Append("</td>");

                    sb.Append("<td  id=\"tdDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\">");
                    sb.Append("<div class=\"input-group\">");
                    sb.Append("<input disabled autocomplete=\"off\"  maxlength=\"10\"  type=\"text\" class=\"form-control fg2_inp2 tr_r fgs2\" onkeydown=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "')\"  onchange=\"return AmountCalculation(" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + ");\"  id=\"txtDebitNotetxtAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"    />");
                    sb.Append("</div><span id=\"AccntBalanceDebitNote" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\"  class=\"input-group-addon cur2\" ></span>");
                    sb.Append("</td>");
                }

                sb.Append("<td style=\"display:none;\" id=\"tdDebitBalanceAmt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" ></td>");
                sb.Append("<td style=\"display:none;\" class=\" td1 tr_r\" id=\"tdDebitAmnt" + dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString() + "\" ></td>");

                sb.Append("</tr>"); result[3] = dtExpense.Rows[row1]["LDGR_NAME"].ToString();
                if (row1 == 0)
                {
                    Groupid = dtExpense.Rows[row1]["EXPENSE_DTL_ID"].ToString();
                }

            }

        }

        DataTable dtacntblnc = objBussiness.AccntBalancebyId(ObjEntityRequest);
        decimal DecDebAmnt = 0, DecCredAmnt = 0, DBalance = 0, Openbalance = 0;
        int intLedgerMode;
        string CrOrDr = "CR";
        string Nature = "";

        if (dtacntblnc.Rows.Count > 0)
        {
            if (dtacntblnc.Rows[0]["LDGR_MODE"].ToString() == "1")
            {
                if (dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString() != "")
                    DecCredAmnt = Convert.ToDecimal(dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString());
                DBalance = DecCredAmnt - Openbalance;

            }
            else if (dtacntblnc.Rows[0]["LDGR_MODE"].ToString() == "0")
            {
                if (dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString() != "")
                    DecDebAmnt = Convert.ToDecimal(dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString());
                DBalance = DecDebAmnt + Openbalance;
            }
            if (DBalance < 0)
            {
            }
            else
            {
                CrOrDr = "DR";
            }

            Nature = dtacntblnc.Rows[0]["ACNT_NATURE_STS"].ToString();
        }
        if (mode == "upd")
        {
            result[0] = "";
        }
        else
        {
            result[0] = sb.ToString();
        }
        result[1] = DBalance.ToString();
        result[2] = CrOrDr;
        result[4] = Groupid;
        result[5] = Nature;
        result[6] = intOBSts.ToString();
        result[7] = strDebCr;

        return result;

    }



}