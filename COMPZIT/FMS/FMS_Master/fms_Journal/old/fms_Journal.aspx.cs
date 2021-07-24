using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using BL_Compzit.BusineesLayer_HCM;
using BL_Compzit.BusinessLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using EL_Compzit.Entity_Layer_HCM;
using EL_Compzit.EntityLayer_HCM;
using System.Data;
using System.Text;
using System.Web.Services;
using System.Collections;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;


public partial class FMS_FMS_Master_fms_Journal_fms_Journal : System.Web.UI.Page
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

    int intAccntCloseReopen = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //  ddlAccontLed.Focus();
        if (!IsPostBack)
        {
            btnPRint.Visible = false;
            btnFloatPrint.Visible = false;

            clsCommonLibrary objCommon = new clsCommonLibrary();
            HiddenRowCount.Value = "0";
            hiddenLedgerddl.Value = "0";
            hiddenCostCenterddl.Value = "0";
            HiddenCostGroup1ddl.Value = "0";
            HiddenCostGroup2ddl.Value = "0";
            CostGroup1Load();
            CostGroup2Load();
            //   AccountLedgerLoad();
            CostCenterLoad();
            LeadgerLoad();
            CurrencyLoad();

            HiddenView.Value = "0";
            HiddenFieldTaxId.Value = "";
            HiddenChkSts.Value = "1";
            btnUpdate.Visible = false;
            btnFloatUpdate.Visible = false;
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            string strRefAccountCls = "0";
            HiddenRefAccountCls.Value = "0";
            clsCommonLibrary objcommon = new clsCommonLibrary();
            clsEntityCommon objentcommn = new clsEntityCommon();

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

                objentcommn.CorporateID = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objentcommn.Organisation_Id = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }


            if (Session["FINCYRID"] != null)
            {
                objentcommn.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS,
                                                           clsCommonLibrary.CORP_GLOBAL.FMS_SALE_PRCHS_VISBLE_STATUS,
                                                             clsCommonLibrary.CORP_GLOBAL.FMS_LDGR_DUPLICATION
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                strRefAccountCls = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
                HiddenRefAccountCls.Value = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
                HiddenPurchseSaleStatus.Value = dtCorpDetail.Rows[0]["FMS_SALE_PRCHS_VISBLE_STATUS"].ToString();
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

            int intConfirm = 0, intReopen = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenFieldAcntCloseReopenSts.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {

                        HiddenFieldAuditCloseReopenSts.Value = "1";
                    }
                }
            }
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            clsEntityJournal objEntityLayerStock = new clsEntityJournal();
            clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;


            string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);
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


                    string[] arrReferenceSplit = strReferenceFormat.Split('*');
                    int intArrayRowCount = arrReferenceSplit.Length;

                    if (refFormatByDiv == "" || refFormatByDiv == null)
                    {
                        strRealFormat = intCorpId + "/" + strNextId;
                    }
                    else
                    {
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

                        if (strRealFormat.Contains("#NUM#"))
                        {
                            strRealFormat = strRealFormat.Replace("#NUM#", strNextId);
                        }
                        else
                        {
                            strRealFormat = strRealFormat + "/" + strNextId;
                        }
                        strRealFormat = strRealFormat.Replace("#", "");
                    }
                    TxtRef.Value = strRealFormat;
                }
            }
            else
            {
                TxtRef.Value = strNextId;
            }

            int YearEndCls = 0;
            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objentcommn);

            if (dtfinaclYear.Rows.Count > 0)
            {
                if (dtfinaclYear.Rows[0]["FINCYR_ID"].ToString() != "")
                {
                    HiddenFinancialYearId.Value = dtfinaclYear.Rows[0]["FINCYR_ID"].ToString();
                }


                DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objentcommn);
                DataTable dtAuditClsDate = objBusinessLayer.ReadLastAuditClose(objentcommn);

                DateTime curdate1 = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());

                if ((dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString() != "" && dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString() != ""))
                {
                    if (curdate1 > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate1 < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        //   txtdate.Value = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");

                    }

                    HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

                }



                if (dtAcntClsDate.Rows.Count > 0 && dtAuditClsDate.Rows.Count > 0)
                {
                    HiddenAcntClsDate.Value = dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString();
                    YearEndCls = Convert.ToInt32(dtAcntClsDate.Rows[0]["ACCNT_CLS_YEAREND_STS"].ToString());

                    if (dtAuditClsDate.Rows.Count > 0 && HiddenFieldAuditCloseReopenSts.Value == "1")
                    {
                        txtdate.Value = objBusinessLayer.LoadCurrentDateInString();

                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    }
                    else if (dtAcntClsDate.Rows.Count > 0 && HiddenFieldAcntCloseReopenSts.Value == "1")
                    {
                        txtdate.Value = objBusinessLayer.LoadCurrentDateInString();

                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    }
                    else
                    {

                        if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                        {
                            DateTime startDate = objcommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());

                            DateTime startDate1 = objcommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());

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

                            else if (startDate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                            {


                            }
                            else
                            {
                                HiddenStartDate.Value = startDate.AddDays(1).ToString("dd-MM-yyyy");
                                HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                            }
                        }
                    }

                    DateTime curdate = objcommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    string Ref = "";

                    if (curdate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {

                        DateTime startDate = objcommon.textToDateTime(HiddenStartDate.Value);
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
                                clsEntityJournal objEntityLayerStock1 = new clsEntityJournal();
                                clsBusinessJournal objBusinessLayerStock1 = new clsBusinessJournal();
                                objEntityLayerStock1.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityLayerStock1.Corp_Id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntityLayerStock1.Org_Id = intOrgId;
                                objEntityAudit.Corporate_id = intCorpId;
                                objEntityAudit.Organisation_id = intOrgId;

                                int SubRef = 1;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                                if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = objBusinessLayerStock1.ReadRefNumberByDate(objEntityLayerStock1);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "")
                                        {
                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                        }
                                        objEntityLayerStock1.RefNum = strRef;
                                        DataTable dtRefFormat = objBusinessLayerStock1.ReadRefNumberByDateLast(objEntityLayerStock1);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["JURNL_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString());
                                            }
                                            if (SubRef != 1)
                                            {
                                                Ref = Ref.TrimEnd('/');
                                                Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                                Ref = Ref + "" + SubRef;
                                            }
                                            else
                                            {
                                                Ref = Ref + "/" + SubRef;
                                            }
                                            TxtRef.Value = Ref;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (dtAcntClsDate.Rows.Count > 0 && dtAuditClsDate.Rows.Count > 0)
                            {
                                if (objcommon.textToDateTime(HiddenStartDate.Value) < curdate)
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
                    HiddenAcntClsDate.Value = dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString();
                    if (HiddenFieldAuditCloseReopenSts.Value == "1")
                    {
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    }
                    else
                    {

                        if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                        {
                            DateTime startDate = objcommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());

                            if (startDate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                            {

                            }
                            else
                            {
                                HiddenStartDate.Value = startDate.AddDays(1).ToString("dd-MM-yyyy");
                                HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                            }
                        }
                    }
                    DateTime curdate = objcommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    string Ref = "";

                    if (curdate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        DateTime startDate = objcommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());
                        if (HiddenFieldAuditCloseReopenSts.Value == "1")
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {

                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();

                                cls_Business_Audit_Closeing objEmpAccntCls = new cls_Business_Audit_Closeing();
                                clsEntityLayerAuditClosing objEntityAccnt = new clsEntityLayerAuditClosing();


                                objEntityAccnt.FromDate = objCommon.textToDateTime(txtdate.Value);
                                clsEntityJournal objEntityLayerStock1 = new clsEntityJournal();
                                clsBusinessJournal objBusinessLayerStock1 = new clsBusinessJournal();
                                objEntityLayerStock1.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityLayerStock1.Corp_Id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntityLayerStock1.Org_Id = intOrgId;
                                int SubRef = 1;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAuditClosingDate(objEntityAccnt);


                                if (dtAccntCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = objBusinessLayerStock1.ReadRefNumberByDate(objEntityLayerStock1);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "")
                                        {
                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                        }
                                        objEntityLayerStock1.RefNum = strRef;
                                        DataTable dtRefFormat = objBusinessLayerStock1.ReadRefNumberByDateLast(objEntityLayerStock1);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["JURNL_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString());
                                            }
                                            if (SubRef != 1)
                                            {
                                                Ref = Ref.TrimEnd('/');
                                                Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                                Ref = Ref + "" + SubRef;
                                            }
                                            else
                                            {
                                                Ref = Ref + "/" + SubRef;
                                            }
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
                else if (dtAcntClsDate.Rows.Count > 0)
                {
                    YearEndCls = Convert.ToInt32(dtAcntClsDate.Rows[0]["ACCNT_CLS_YEAREND_STS"].ToString());
                    HiddenAcntClsDate.Value = dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString();
                    if (HiddenFieldAcntCloseReopenSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                    {
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    }
                    else
                    {
                        if (objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                        {
                            DateTime startDate = objcommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());

                            if (startDate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                            {

                                // txtdate.Disabled = true;
                                // HiddenAcntClsSts.Value = "1";


                            }
                            else
                            {
                                HiddenStartDate.Value = startDate.AddDays(1).ToString("dd-MM-yyyy");
                                HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                            }
                        }
                    }

                    DateTime curdate = objcommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    string Ref = "";

                    if (curdate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {

                        DateTime startDate = objcommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                        if (HiddenFieldAcntCloseReopenSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {

                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                                clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
                                clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                                objEntityAccnt.FromDate = objCommon.textToDateTime(txtdate.Value);
                                clsEntityJournal objEntityLayerStock1 = new clsEntityJournal();
                                clsBusinessJournal objBusinessLayerStock1 = new clsBusinessJournal();
                                objEntityLayerStock1.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityLayerStock1.Corp_Id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntityLayerStock1.Org_Id = intOrgId;
                                int SubRef = 1;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                if (dtAccntCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = objBusinessLayerStock1.ReadRefNumberByDate(objEntityLayerStock1);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "")
                                        {
                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                                        }
                                        objEntityLayerStock1.RefNum = strRef;
                                        DataTable dtRefFormat = objBusinessLayerStock1.ReadRefNumberByDateLast(objEntityLayerStock1);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["JURNL_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString());
                                            }
                                            if (SubRef != 1)
                                            {
                                                Ref = Ref.TrimEnd('/');
                                                Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                                                Ref = Ref + "" + SubRef;
                                            }
                                            else
                                            {
                                                Ref = Ref + "/" + SubRef;
                                            }
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

                    if (dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString() != "" && dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString() != "")
                    {
                        DateTime curdate = objcommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());


                        if (curdate >= objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate <= objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {
                            txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                        }
                    }
                    HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                }
            }


            if (Request.QueryString["Id"] != null)
            {

                lblEntry.InnerText = "Edit Journal";
                PathlblEntry.InnerText = "Edit Journal";                
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                bttnsave.Visible = false;
                btnSaveCls.Visible = false;
                btnFloatSave.Visible = false;
                btnFloatSaveCls.Visible = false;
                btnUpdate.Visible = true;
                btnUpdatecls.Visible = true;
                btnFloatUpdate.Visible = true;
                btnFloatUpdateCls.Visible = true;
                btnFloatCancel.Visible = true;
                btnCancel.Visible = true;
                HiddenJrnlId.Value = strId;
                ButtnClose.Visible = false;
                ButtnFloatClear.Visible = false;
                Update(strId, intConfirm, intReopen, YearEndCls);
                ClientScript.RegisterStartupScript(this.GetType(), "updDebitColor", "updDebitColor();", true);
            }
            else if (Request.QueryString["ViewId"] != null)
            {

                lblEntry.InnerText = "View Journal";
                PathlblEntry.InnerText = "View Journal";
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                bttnsave.Visible = false;
                btnFloatSave.Visible = false;
                btnUpdate.Visible = false;
                btnFloatUpdate.Visible = false;
                btnSaveCls.Visible = false;
                btnFloatSaveCls.Visible = false;
                btnUpdatecls.Visible = false;
                btnFloatUpdateCls.Visible = false;
                btnConfirm.Visible = false;
                btnFloatConfirm.Visible = false;
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
                btnCancel.Visible = true;
                btnFloatCancel.Visible = true;
                ButtnClose.Visible = false;
                ButtnFloatClear.Visible = false;
                HiddenJrnlId.Value = strId;
                HiddenView.Value = "1";
                View(strId, intConfirm, intReopen,YearEndCls);
                ClientScript.RegisterStartupScript(this.GetType(), "updDebitColor", "updDebitColor();", true);
            }
            else
            {
                PathlblEntry.InnerText = "Add Journal";
                lblEntry.InnerText = "Add Journal";
                btnUpdate.Visible = false;
                btnUpdatecls.Visible = false;
                btnConfirm.Visible = false;
                btnReopen.Visible = false;
                btnFloatUpdate.Visible = false;
                btnFloatUpdateCls.Visible = false;
                btnFloatConfirm.Visible = false;
                btnFloatReopen.Visible = false;
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
                else if (strInsUpd == "Cnf")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCnfMsg", "SuccessCnfMsg();", true);
                }
                else if (strInsUpd == "UpdCancl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CanclUpdMsg", "CanclUpdMsg();", true);
                }
                else if (strInsUpd == "UpdConfm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CanclCnfMsg", "CanclCnfMsg();", true);
                }
                else if (strInsUpd == "Reop")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopMsg", "SuccessReopMsg();", true);
                }
                else if (strInsUpd == "SalesAmountExceeded")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SalesAmountExceeded", "SalesAmountExceeded();", true);
                }
                else if (strInsUpd == "SalesAmountFullySettld")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SalesAmountFullySettld", "SalesAmountFullySettld();", true);
                }
                else if (strInsUpd == "PurchaseAmtExceed")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PurchaseAmountExceeded", "PurchaseAmountExceeded();", true);
                }
                else if (strInsUpd == "PrchsAmtFullySettld")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PrchsAmtFullySettld", "PrchsAmtFullySettld();", true);
                }

            }


            if (Request.QueryString["VId"] != null)
            {
                string strVId = Request.QueryString["VId"].ToString();
                divList.Visible = false;
                btnReopen.Visible = false;
                btnCancel.Visible = false;
                btnFloatReopen.Visible = false;
                btnFloatCancel.Visible = false;
                divLinkSection.Visible = false;

                if (hiddenPostdated.Value == "1")
                {
                    if (strVId == "1")
                    {
                        btnUpdate.Visible = true;
                        btnFloatUpdate.Visible = true;
                        btnConfirm.Visible = true;
                        btnFloatConfirm.Visible = true;
                        btnUpdatecls.Visible = false;
                        btnFloatUpdateCls.Visible = false;
                        //btnCancel.Visible = true;
                        //btnFloatCancel.Visible = true;
                    }
                }
            }


        }
    }

    protected void btnReopen_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["ViewId"] != null)
            {
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                clsEntityJournal objEntityLayerStock = new clsEntityJournal();
                clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                if (Session["USERID"] != null)
                {
                    objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                if (HiddenRefChange.Value != HiddenEditDate.Value)
                    objEntityLayerStock.ViewStatus = 1;
                objEntityLayerStock.RefNum = TxtRef.Value.ToUpper().Trim();
                objEntityLayerStock.JournalDate = objCommon.textToDateTime(txtdate.Value);
                objEntityLayerStock.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                objEntityLayerStock.Description = txtDescription.Value.Trim();
                objEntityLayerStock.JournalId = Convert.ToInt32(strId);
                objEntityLayerStock.ConfirmSts = 0;

                if (txtExchangeRate.Value.Trim() != "")
                    objEntityLayerStock.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Value.Trim());
                List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityJournalLedgerDtl>();
                List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityJournalCostCntrDtl>();

                string jsonData = HiddenFieldJornlDataLedgr.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
                objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);


                if (HiddenFieldJornlDataLedgr.Value != "" && HiddenFieldJornlDataLedgr.Value != null)
                {
                    foreach (clsLedgrData objclsTVData in objTVDataList5)
                    {
                        clsEntityJournalLedgerDtl objEntityDtl = new clsEntityJournalLedgerDtl();
                        objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                        objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                        objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                        objEntityDtl.LedgerId = Convert.ToInt32(objclsTVData.LEDGRID);
                        objEntityDtl.LedgerTotAmnt = Convert.ToDecimal(objclsTVData.LEDGRAMNT);

                        if (txtExchangeRate.Value.Trim() != "")
                        {
                            objEntityDtl.ExchangeRate = objEntityDtl.LedgerTotAmnt * objEntityLayerStock.ExchangeRate;
                        }
                        else
                        {
                            objEntityDtl.ExchangeRate = objEntityDtl.LedgerTotAmnt;
                        }

                        objEntityJrnlLedgrList.Add(objEntityDtl);
                    }
                }

                jsonData = HiddenFieldJornlDataCostCentr.Value;
                c = jsonData.Replace("\"{", "\\{");
                d = c.Replace("\\n", "\r\n");
                g = d.Replace("\\", "");
                h = g.Replace("}\"]", "}]");
                i = h.Replace("}\",", "},");
                List<clsCostCntrData> objTVDataList6 = new List<clsCostCntrData>();
                objTVDataList6 = JsonConvert.DeserializeObject<List<clsCostCntrData>>(i);


                if (HiddenFieldJornlDataCostCentr.Value != "" && HiddenFieldJornlDataCostCentr.Value != null)
                {
                    foreach (clsCostCntrData objclsTVData in objTVDataList6)
                    {
                        if (objclsTVData.COSTCENTRAMNT != "" && objclsTVData.COSTCENTRID != "" && objclsTVData.COSTCENTRID != "-Select Cost Center-")
                        {
                            clsEntityJournalCostCntrDtl objEntityDtl = new clsEntityJournalCostCntrDtl();
                            objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                            objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                            //objEntityDtl.SubTabId = Convert.ToInt32(objclsTVData.SUBTABID);
                            objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                            objEntityDtl.PurSaleRefNum = objclsTVData.PURSALESTS;
                            objEntityDtl.CostCenterId = Convert.ToInt32(objclsTVData.COSTCENTRID);
                            objEntityDtl.CostCntrAmnt = Convert.ToDecimal(objclsTVData.COSTCENTRAMNT);

                            if (txtExchangeRate.Value.Trim() != "")
                            {
                                objEntityDtl.ExchangeRate = objEntityDtl.CostCntrAmnt * objEntityLayerStock.ExchangeRate;
                            }
                            else
                            {
                                objEntityDtl.ExchangeRate = objEntityDtl.CostCntrAmnt;
                            }

                            objEntityJrnlCostcentrList.Add(objEntityDtl);
                        }
                    }
                }

           //     objEntityJrnlLedgrList.Reverse();
            //    objEntityJrnlCostcentrList.Reverse();
                DataTable dt = objBusinessLayerStock.CheckJournlCnclSts(objEntityLayerStock);
                int AcntCloseSts = AccountCloseCheck(txtdate.Value);

                int AuditCloseSts = AuditCloseCheck(txtdate.Value);
                if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=AuditClosed");
                }
                else if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
                {
                }
                else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=AcntClosed");
                }


               if (dt.Rows[0][0].ToString() == "")
                {
                    objBusinessLayerStock.ReopenJournalDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);
                    Response.Redirect("fms_Journal.aspx?Id=" + Request.QueryString["ViewId"] + "&InsUpd=Reop");
                }
                else if (dt.Rows[0][0].ToString() != "")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=UpdCancl");
                }
            }
        }
        catch (Exception)
        {
        }
    }
    public void Update(string strP_Id, int intConfirm, int intReopen, int YearEndCls)
    {
        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        clsCommonLibrary objCommn = new clsCommonLibrary();
        // ChequeBookLoad();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityLayerStock.JournalId = Convert.ToInt32(strP_Id);
        HiddenJournalID.Value = strP_Id;
        DataTable dtLedgerDeb = objBusinessLayerStock.ReadLedgerDdl(objEntityLayerStock);
        DataTable dt = objBusinessLayerStock.ReadJournalDtlsById(objEntityLayerStock);
        if (dt.Rows.Count > 0)
        {

            hiddenDfltCurrencyMstrId.Value = dt.Rows[0]["CRNCMST_ID"].ToString();
            HiddenCurrencyAbrv.Value = dt.Rows[0]["CRNCMST_ABBRV"].ToString();



            int AcntCloseSts = AccountCloseCheck(dt.Rows[0]["JURNL_DATE"].ToString());
            int AuditClsSts = AuditCloseCheck(dt.Rows[0]["JURNL_DATE"].ToString());
            btnReopen.Visible = false;
            btnFloatReopen.Visible = false;

            btnPRint.Visible = true;
            btnFloatPrint.Visible = true;

            int CnfrmFlg = 0;
            if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
            {

                btnConfirm.Visible = false;
                btnFloatConfirm.Visible = false;
                btnUpdate.Visible = false;
                btnFloatUpdate.Visible = false;
                CnfrmFlg = 1;
                View(strP_Id, intConfirm, intReopen, YearEndCls);
            }

            else if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "0" && AuditClsSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
            {
                CnfrmFlg = 1;

                // btnConfirm.Visible = false;
                //   btnUpdate.Visible = false;
                //  btnReopen.Visible = false;
                View(strP_Id, intConfirm, intReopen, YearEndCls);
            }

            else if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "0" && AuditClsSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
            {



            }
            else if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "0" && AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
            {
                CnfrmFlg = 1;

                //  btnConfirm.Visible = false;
                //   btnUpdate.Visible = false;
                //  btnReopen.Visible = false;
                View(strP_Id, intConfirm, intReopen, YearEndCls);
            }
            if (CnfrmFlg == 0)
            {
                HiddenEdit.Value = "1";
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
                if (dt.Rows[0]["JURNL_REF"].ToString() != "")
                {
                    TxtRef.Value = dt.Rows[0]["JURNL_REF"].ToString();
                    HiddenUpdRefNum.Value = dt.Rows[0]["JURNL_REF"].ToString();
                }


                if (dt.Rows[0]["JURNL_DATE"].ToString() != "")
                {
                    txtdate.Value = dt.Rows[0]["JURNL_DATE"].ToString();
                    HiddenRefChange.Value = dt.Rows[0]["JURNL_DATE"].ToString();
                    HiddenEditDate.Value = dt.Rows[0]["JURNL_DATE"].ToString();
                }

                int precision = Convert.ToInt32(hiddenDecimalCount.Value);
                string format = String.Format("{{0:N{0}}}", precision);
                if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                {
                    if (dt.Rows[0]["JURNL_TOTAL_AMT"].ToString() != "")
                    {
                        decimal DecAmntTot = 0;
                        if (dt.Rows[0]["JURNL_TOTAL_AMT"].ToString() != "")
                        {
                            DecAmntTot = Convert.ToDecimal(dt.Rows[0]["JURNL_TOTAL_AMT"].ToString());
                        }
                        string valuestringTot = String.Format(format, DecAmntTot);
                        lblTotDeb.Value = valuestringTot + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                        lblTotCrdt.Value = valuestringTot + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                        HiddenGrdTotl.Value = valuestringTot;
                    }

                }


                if (dt.Rows[0]["JURNL_DSCRPTN"].ToString() != "")
                {
                    txtDescription.Value = dt.Rows[0]["JURNL_DSCRPTN"].ToString();
                }

                string strDisabled = "";
                string strReadOnly = "";

                //Postdated
                if (dt.Rows[0]["PST_CHEQUE_DTLS_ID"].ToString() != "")
                {
                    hiddenPostdated.Value = "1";
                    txtdate.Disabled = true;
                    strDisabled = "disabled";
                    strReadOnly = "readonly";
                    txtdate.Disabled = true;
                    DateSpan.Disabled = true;
                    DateSpan.Attributes.Add("style", "pointer-events:none");
                }

                StringBuilder sb = new StringBuilder();
                DataTable dtLedgrdDebDtl = objBusinessLayerStock.ReadJrnlLedgrDtlsById(objEntityLayerStock);
                int rowSubCatagory = 0;
                for (int i = 0; i < dtLedgrdDebDtl.Rows.Count; i++)
                {
                    HiddenRowCount.Value = dtLedgrdDebDtl.Rows.Count.ToString();
                    sb.Append("<tr id=\"SubGrpRowId_" + i + "\" class=\"tr1\">");
                    sb.Append("<td   id=\"tdidGrpDtls" + i + "\" style=\"display: none\" >" + i + "</td>");
                    sb.Append("<div></div><div style=\"display:none\" id=\"groupSubCat" + i + "\">" + rowSubCatagory + "</div> <td style=\"display:none;\">" + dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString() + "</td>");
                    sb.Append("<td class=\"col-md-3\">");
                    sb.Append("<div id=\"divLedger" + i + "\"><select " + strDisabled + " onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 f_p3 ddl\" id=\"ddlRecptLedger" + i + "\" onchange=\"return PaymentLedger(" + i + ",'Deb');\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                    sb.Append("<option  value=\"0\">-Select Ledger-</option>");
                    int f = 0;
                    for (int intRowCount = 0; intRowCount < dtLedgerDeb.Rows.Count; intRowCount++)
                    {
                        if (dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() == dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString())
                        {
                            f = 1;
                            sb.Append("<option selected value=\"" + dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerDeb.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                        }
                        else
                        {
                            sb.Append("<option value=\"" + dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerDeb.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                        }
                    }
                    if (f == 0)
                    {
                        sb.Append("<option selected value=\"" + dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString() + "\">" + dtLedgrdDebDtl.Rows[i]["LDGR_NAME"].ToString() + "</option>");
                    }
                    sb.Append("</select></div>");

                    string strSym = "";
                    decimal decNetBal = 0;
                    if (dtLedgrdDebDtl.Rows[i]["LDGR_CURRENT_BAL"].ToString() != "")
                    {
                        decNetBal = Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LDGR_CURRENT_BAL"].ToString());
                    }
                    if (dtLedgrdDebDtl.Rows[i]["LDGR_OPEN_BAL"].ToString() != "" && dtLedgrdDebDtl.Rows[i]["LDGR_MODE"].ToString() != "")
                    {
                        if (dtLedgrdDebDtl.Rows[i]["LDGR_MODE"].ToString() == "0")
                        {
                            decNetBal = decNetBal + Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LDGR_OPEN_BAL"].ToString());
                        }
                        else
                        {
                            decNetBal = decNetBal - Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LDGR_OPEN_BAL"].ToString());
                        }
                    }
                    if (decNetBal > 0)
                    {
                        string valuestring = String.Format(format, decNetBal);

                        strSym = "<i  class=\"fa fa-money\"></i>  " + valuestring + " DR " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                        sb.Append("<span class=\"input-group-addon cur2 dr1\" id=\"AccntBalance_" + i + "\">" + strSym + "</span>");
                    }
                    else if (decNetBal < 0)
                    {
                        // decNetBal = decNetBal * (-1);
                        string valuestring = String.Format(format, decNetBal);
                        strSym = "<i  class=\"fa fa-money\"></i>  " + valuestring + " CR " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                        sb.Append("<span class=\"input-group-addon cur2 c1h\" id=\"AccntBalance_" + i + "\">" + strSym + "</span>");
                    }

                    sb.Append(" <input " + strDisabled + " class=\"form-control\" style=\"display:none\" name=\"ddlLedId" + i + "\"  value=\"" + dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString() + "\" id=\"ddlLedId" + i + "\" type=\"text\"></td>");
                    objEntityLayerStock.JournalId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString());
                    DataTable dtCostCntrDebDtl = objBusinessLayerStock.ReadJrnlCostCntrDtlsById(objEntityLayerStock);
                    string strCostDtl = "", strPurchaseDtl = "";
                    string sale = "";
                    string purchase = "";
                    for (int j = 0; j < dtCostCntrDebDtl.Rows.Count; j++)
                    {

                        decimal costAmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString());
                        string valuestringCost = String.Format(format, costAmnt);
                        if (dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() != "")
                        {
                            string costGrp1 = "0";
                            string costGrp2 = "0";


                            if (dtCostCntrDebDtl.Rows[j]["COSTGRP_ID_ONE"].ToString() != "")
                            {
                                costGrp1 = dtCostCntrDebDtl.Rows[j]["COSTGRP_ID_ONE"].ToString();
                            }
                            if (dtCostCntrDebDtl.Rows[j]["COSTGRP_ID_TWO"].ToString() != "")
                            {
                                costGrp2 = dtCostCntrDebDtl.Rows[j]["COSTGRP_ID_TWO"].ToString();
                            }
                            if (strCostDtl == "")
                            {


                                strCostDtl = dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() + "%" + valuestringCost + "%" + costGrp1 + "%" + costGrp2;
                            }
                            else
                            {
                                strCostDtl = strCostDtl + "$" + dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() + "%" + valuestringCost + "%" + costGrp1 + "%" + costGrp2;
                            }
                        }
                        else if (dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString() != "")
                        {
                            sale = dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString();
                            if (strPurchaseDtl == "")
                            {
                                strPurchaseDtl = dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString() + "%" + valuestringCost + "%" + dtCostCntrDebDtl.Rows[j]["BALNC_AMT"].ToString();
                            }
                            else
                            {
                                strPurchaseDtl = strPurchaseDtl + "$" + dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString() + "%" + valuestringCost + "%" + dtCostCntrDebDtl.Rows[j]["BALNC_AMT"].ToString();
                            }
                        }
                        else if (dtCostCntrDebDtl.Rows[j]["PURCHS_ID"].ToString() != "")
                        {
                            purchase = dtCostCntrDebDtl.Rows[j]["PURCHS_ID"].ToString();
                            if (strPurchaseDtl == "")
                            {
                                strPurchaseDtl = dtCostCntrDebDtl.Rows[j]["PURCHS_ID"].ToString() + "%" + valuestringCost + "%" + dtCostCntrDebDtl.Rows[j]["PURCHS_BAL_AMT"].ToString();
                            }
                            else
                            {
                                strPurchaseDtl = strPurchaseDtl + "$" + dtCostCntrDebDtl.Rows[j]["PURCHS_ID"].ToString() + "%" + valuestringCost + "%" + dtCostCntrDebDtl.Rows[j]["PURCHS_BAL_AMT"].ToString();
                            }
                        }
                    }
                    string PurOrsale = "";
                    decimal LedgrAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LD_JURNL_AMT"].ToString());
                    string valuestringLedg = String.Format(format, LedgrAmnt);
                    if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_STS"].ToString() == "0")
                    {
                        sb.Append("<td class=\"col-md-2 tr_r\">");

                        PurOrsale = "SAL";
                        sb.Append(" <div class=\"input-group\">  <span class=\"input-group-addon cur1\">" + HiddenCurrencyAbrv.Value + "</span><input " + strReadOnly + " type=\"text\" class=\"form-control fg2_inp2 tr_r\"  value=\"" + valuestringLedg + "\" id=\"TxtAmount_" + i + "\" onkeydown=\"return isDecimalNumber(event,'TxtAmount_" + i + "');\" onkeypress=\"return isDecimalNumber(event,'TxtAmount_" + i + "');\" name=\"TxtAmount_" + i + "\"  onblur=\"return PendingPurchase('TxtAmount_" + i + "','" + i + "','DBT');\"   id=\"TxtAmount_" + i + "\"  maxlength=10 >");
                        sb.Append("</div></td>");
                        sb.Append("<td class=\"col-md-2 tr_r\">");


                        sb.Append(" <div class=\"input-group\">  <span class=\"input-group-addon cur1\">" + HiddenCurrencyAbrv.Value + "</span><input " + strReadOnly + " type=\"text\" disabled class=\"form-control fg2_inp2 tr_r\"  id=\"TxtAmountCrdt" + i + "\" onkeydown=\"return isDecimalNumber(event,'TxtAmountCrdt" + i + "');\" onkeypress=\"return isDecimalNumber(event,'TxtAmountCrdt" + i + "');\" name=\"TxtAmountCrdt" + i + "\"  onblur=\"return PendingPurchase('TxtAmountCrdt" + i + "','" + i + "','CDT');\"   id=\"TxtAmountCrdt" + i + "\"  maxlength=10 >");
                        sb.Append("</div></td>");
                    }
                    else
                    {
                        sb.Append("<td class=\"col-md-2 tr_r\">");

                        PurOrsale = "PURCH";
                        sb.Append("<div class=\"input-group\">  <span class=\"input-group-addon cur1\">" + HiddenCurrencyAbrv.Value + "</span><input " + strReadOnly + " type=\"text\" class=\"form-control fg2_inp2 tr_r\" disabled id=\"TxtAmount_" + i + "\" onkeydown=\"return isDecimalNumber(event,'TxtAmount_" + i + "');\" onkeypress=\"return isDecimalNumber(event,'TxtAmount_" + i + "');\" name=\"TxtAmount_" + i + "\"  onblur=\"return PendingPurchase('TxtAmount_" + i + "','" + i + "','DBT');\"   id=\"TxtAmount_" + i + "\"  maxlength=10 >");
                        sb.Append("</div></td>");
                        sb.Append("<td class=\"col-md-2 tr_r\">");


                        sb.Append("<div class=\"input-group\">  <span class=\"input-group-addon cur1\">" + HiddenCurrencyAbrv.Value + "</span><input " + strReadOnly + " type=\"text\" class=\"form-control fg2_inp2 tr_r\" value=\"" + valuestringLedg + "\" id=\"TxtAmountCrdt" + i + "\" onkeydown=\"return isDecimalNumber(event,'TxtAmountCrdt" + i + "');\" onkeypress=\"return isDecimalNumber(event,'TxtAmountCrdt" + i + "');\" name=\"TxtAmountCrdt" + i + "\"  onblur=\"return PendingPurchase('TxtAmountCrdt" + i + "','" + i + "','CDT');\"   id=\"TxtAmountCrdt" + i + "\"  maxlength=10 >");
                        sb.Append("</div></td>");
                    }
                    sb.Append(" <td class=\"col-md-3\"> <textarea id=\"TxtRemark" + i + "\" name=\"TxtRemark" + i + "\" value=\"" + dtLedgrdDebDtl.Rows[i]["LD_JURNL_REMARK"].ToString() + "\"   rows=\"3\" cols=\"20\"  class=\"form-control\" style=\" resize: none;\" onkeydown=\"textCounter(TxtRemark" + i + ",450)\" onkeyup=\"textCounter(TxtRemark" + i + ",450)\">" + dtLedgrdDebDtl.Rows[i]["LD_JURNL_REMARK"].ToString() + "</textarea></td>");

                    sb.Append("<td class=\"td1 col-md-1\">");
                    sb.Append("<button disabled class=\"btn act_btn bn2\" title=\"Add\" id=\"journalADD" + i + "\"  onclick=\"return FuctionAddGroup('" + i + "')\">");
                    sb.Append("<i class=\"fa fa-plus-circle\" id=\"Span7\" style=\"display: block;\">&nbsp;</i>");
                    sb.Append("</button>");
                    sb.Append("<button " + strDisabled + " class=\"btn act_btn bn3\" title=\"Delete\"  id=\"bttnRemovGrp" + i + "\" onclick=\"return removeRowGrps(" + i + ",'Are you sure you want to delete this ledger?')\">");
                    sb.Append("<i class=\"fa fa-trash\" id=\"Span6\" style=\"display: block;\">&nbsp;</i>");
                    sb.Append("</button>");
                    sb.Append("</td>");
                    sb.Append("<td class=\"td1 col-md-1\">");
                    if (HiddenPurchseSaleStatus.Value == "1")
                    {
                        sb.Append("<a href=\"javascript:;\" id=\"ChkPurchase" + i + "\" title=\"PURCHASE\"  onclick=\"return ddlLedOnchange('" + i + "','ins','DBT');\" ><i id=\"ChkPurchaseITag" + i + "\" class=\"fa fa-shopping-cart ad_fa psc_p\"></i></a>");

                        sb.Append("<a href=\"javascript:;\" id=\"ChkSales" + i + "\" title=\"SALES\"  onclick=\"return ddlLedOnchange('" + i + "','ins','CDT');\" ><i id=\"ChkSalesITag" + i + "\" class=\"fa fa-balance-scale ad_fa psc_s\"></i></a>");
                    }
                    sb.Append("<a href=\"javascript:;\" id=\"ChkCostCenter" + i + "\" title=\"COST CENTRE\" onclick=\"MyModalCostCenter('" + i + "','" + i + "',null);\"><i class=\"fa fa-filter ad_fa psc_c\"></i></a>");
                    sb.Append("</td>");




                    sb.Append("<td  style=\"display:none;\"><input type=\"text\" class=\"form-control\" style=\"display:none;\" id=\"tdPurchaseDtls" + i + "\" name=\"tdPurchaseDtls" + i + "\" value='" + strPurchaseDtl + "'/></td>");
                    sb.Append("<td  style=\"display:none;\"><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"tdCostCenterDtls" + i + "\" name=\"tdCostCenterDtls" + i + "\" value='" + strCostDtl + "'/></td>");
                    sb.Append("<td  style=\"display: none;\"><input type=\"text\" value='" + PurOrsale + "' class=\"form-control\" style=\"display:none;\"  id=\"tdPurchOrSale" + i + "\" name=\"tdPurchOrSale" + i + "\" /></td>");



                    sb.Append("<td  style=\"display: none;\"><input type=\"text\" class=\"form-control\" value=\"UPD\" style=\"display:none;\"  id=\"tdEvtGrp" + i + "\" name=\"tdEvtGrp" + i + "\" /></td>");

                    sb.Append("<td  style=\"display: none;\"><input type=\"text\" class=\"form-control\"  value=\"" + dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString() + "\"  style=\"display:none;\"  id=\"tdDtlIdTempid" + i + "\" name=\"tdDtlIdTempid" + i + "\" /><input type=\"text\" class=\"form-control\"  style=\"display:none;\"  id=\"tdDtlIdGrp" + i + "\" name=\"tdDtlIdGrp" + i + "\" /></td>");

                    sb.Append("<td  style=\"display: none;\"><input type=\"text\" class=\"form-control\"  value=\"" + i + "\"  style=\"display:none;\"  id=\"tdInxGrp" + i + "\" name=\"tdInxGrp" + i + "\" /> </td>");



                    sb.Append("</tr>");
                    //   ClientScript.RegisterStartupScript(this.GetType(), "ddlLedOnchange", "ddlLedOnchange('" + i + "','ins','CDT');", true);
                    //    ClientScript.RegisterStartupScript(this.GetType(), "ddlLedOnchange", "ddlLedOnchange('" + i + "','ins','DBT');", true);
                }
                tabMainDebBody.InnerHtml = sb.ToString();
            }


            if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() != "1")
            {
                btnPRint.Text = "Draft Print";
                btnFloatPrint.Text = "Draft Print";
            }
        }

        if (YearEndCls == 1)
        {
            btnReopen.Visible = false;
            btnFloatReopen.Visible = false;
        }
    }

    public void View(string id, int intConfirm, int intReopen, int YearEndCls)
    {
        try
        {
            HiddenFieldViewMode.Value = "1";
            clsEntityJournal objEntityLayerStock = new clsEntityJournal();
            clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
            clsCommonLibrary objCommn = new clsCommonLibrary();
            // ChequeBookLoad();
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"]);
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["USERID"] != null)
            {
                objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"]);
            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            txtdate.Disabled = true;
            DateSpan.Disabled = true;
            DateSpan.Attributes.Add("style", "pointer-events:none");
            txtDescription.Disabled = true;


            objEntityLayerStock.JournalId = Convert.ToInt32(id);
            DataTable dtLedgerDeb = objBusinessLayerStock.ReadLedgerDdl(objEntityLayerStock);
            DataTable dt = objBusinessLayerStock.ReadJournalDtlsById(objEntityLayerStock);
            if (dt.Rows.Count > 0)
            {

                hiddenDfltCurrencyMstrId.Value = dt.Rows[0]["CRNCMST_ID"].ToString();
                HiddenCurrencyAbrv.Value = dt.Rows[0]["CRNCMST_ABBRV"].ToString();

                int AcntCloseSts = AccountCloseCheck(dt.Rows[0]["JURNL_DATE"].ToString());
                int AuditCloseSts = AuditCloseCheck(dt.Rows[0]["JURNL_DATE"].ToString());
                if (dt.Rows[0]["JURNL_CNCL_USR_ID"].ToString() == "" && dt.Rows[0]["JURNL_CNFRM_STS"].ToString() != "1")
                {
                    btnPRint.Text = "Draft Print";
                    btnFloatPrint.Text = "Draft Print";

                    btnPRint.Visible = true;
                    btnFloatPrint.Visible = true;
                }


                if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
                {
                    btnPRint.Visible = true;
                    btnFloatPrint.Visible = true;
                    btnConfirm.Visible = false;
                    btnFloatConfirm.Visible = false;
                    btnUpdate.Visible = false;
                    btnFloatUpdate.Visible = false;
                    btnReopen.Visible = false;
                    btnFloatReopen.Visible = false;
                    if (intReopen == 1)
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
                        else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
                        {
                            btnReopen.Visible = false;
                            btnFloatReopen.Visible = false;
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


                }

                if (dt.Rows[0]["JURNL_REF"].ToString() != "")
                {
                    TxtRef.Value = dt.Rows[0]["JURNL_REF"].ToString();
                }


                if (dt.Rows[0]["JURNL_DATE"].ToString() != "")
                {
                    txtdate.Value = dt.Rows[0]["JURNL_DATE"].ToString();
                }

                int precision = Convert.ToInt32(hiddenDecimalCount.Value);
                string format = String.Format("{{0:N{0}}}", precision);
                if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                {
                    if (dt.Rows[0]["JURNL_TOTAL_AMT"].ToString() != "")
                    {
                        decimal DecAmntTot = 0;
                        if (dt.Rows[0]["JURNL_TOTAL_AMT"].ToString() != "")
                        {
                            DecAmntTot = Convert.ToDecimal(dt.Rows[0]["JURNL_TOTAL_AMT"].ToString());
                        }
                        string valuestringTot = String.Format(format, DecAmntTot);
                        lblTotDeb.Value = valuestringTot + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                        lblTotCrdt.Value = valuestringTot + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                        HiddenGrdTotl.Value = valuestringTot;
                    }

                }


                if (dt.Rows[0]["JURNL_DSCRPTN"].ToString() != "")
                {
                    txtDescription.Value = dt.Rows[0]["JURNL_DSCRPTN"].ToString();

                }
                StringBuilder sb = new StringBuilder();
                DataTable dtLedgrdDebDtl = objBusinessLayerStock.ReadJrnlLedgrDtlsById(objEntityLayerStock);
                int rowSubCatagory = 0;
                for (int i = 0; i < dtLedgrdDebDtl.Rows.Count; i++)
                {
                    HiddenRowCount.Value = dtLedgrdDebDtl.Rows.Count.ToString();
                    sb.Append("<tr id=\"SubGrpRowId_" + i + "\" class=\"tr1\">");
                    sb.Append("<td   id=\"tdidGrpDtls" + i + "\" style=\"display: none\" >" + i + "</td>");
                    sb.Append("<div style=\"clear:both\"></div><div style=\"display:none\" id=\"groupSubCat" + i + "\">" + rowSubCatagory + "</div> <td style=\"display:none;\">" + dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString() + "</td>");
                    sb.Append("<td class=\"col-md-3\">");
                    sb.Append("<div id=\"divLedger" + i + "\"><select disabled onblur=\"IncrmntConfrmCounter();\" class=\"fg2_inp2 fg2_inp3 fg_chs1 f_p3 ddl\" id=\"ddlRecptLedger" + i + "\" onchange=\"return PaymentLedger(" + i + ",'Deb');\" onkeydown=\"return isTag(event);\" onkeypress=\"return isTag(event);\" >");
                    sb.Append("<option  value=\"0\">-Select Ledger-</option>");
                    int f = 0;
                    for (int intRowCount = 0; intRowCount < dtLedgerDeb.Rows.Count; intRowCount++)
                    {
                        if (dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() == dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString())
                        {
                            f = 1;
                            sb.Append("<option selected value=\"" + dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerDeb.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                        }
                        else
                        {
                            sb.Append("<option value=\"" + dtLedgerDeb.Rows[intRowCount]["LDGR_ID"].ToString() + "\">" + dtLedgerDeb.Rows[intRowCount]["LDGR_NAME"].ToString() + "</option>");
                        }
                    }
                    if (f == 0)
                    {
                        sb.Append("<option selected value=\"" + dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString() + "\">" + dtLedgrdDebDtl.Rows[i]["LDGR_NAME"].ToString() + "</option>");
                    }
                    sb.Append("</select></div>");

                    string strSym = "";
                    decimal decNetBal = 0;
                    if (dtLedgrdDebDtl.Rows[i]["LDGR_CURRENT_BAL"].ToString() != "")
                    {
                        decNetBal = Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LDGR_CURRENT_BAL"].ToString());
                    }
                    if (dtLedgrdDebDtl.Rows[i]["LDGR_OPEN_BAL"].ToString() != "" && dtLedgrdDebDtl.Rows[i]["LDGR_MODE"].ToString() != "")
                    {
                        if (dtLedgrdDebDtl.Rows[i]["LDGR_MODE"].ToString() == "0")
                        {
                            decNetBal = decNetBal + Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LDGR_OPEN_BAL"].ToString());
                        }
                        else
                        {
                            decNetBal = decNetBal - Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LDGR_OPEN_BAL"].ToString());
                        }
                    }
                    if (decNetBal > 0)
                    {
                        string valuestring = String.Format(format, decNetBal);
                        strSym = "<i  class=\"fa fa-money\"></i>  " + valuestring + " DR " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                        sb.Append("<span class=\"input-group-addon cur2 dr1\" id=\"AccntBalance_" + i + "\">" + strSym + "</span>");
                    }
                    else if (decNetBal < 0)
                    {
                        string valuestring = String.Format(format, decNetBal);
                        strSym = "<i  class=\"fa fa-money\"></i>  " + valuestring + " CR " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                        sb.Append("<span id=\"AccntBalance_" + i + "\" class=\"input-group-addon cur2 c1h\">" + strSym + "</span>");
                    }

                    sb.Append(" <input class=\"form-control\" style=\"display:none\" name=\"ddlLedId" + i + "\"  value=\"" + dtLedgrdDebDtl.Rows[i]["LDGR_ID"].ToString() + "\" id=\"ddlLedId" + i + "\" type=\"text\"></td>");
                    objEntityLayerStock.JournalId = Convert.ToInt32(dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString());
                    DataTable dtCostCntrDebDtl = objBusinessLayerStock.ReadJrnlCostCntrDtlsById(objEntityLayerStock);
                    string strCostDtl = "", strPurchaseDtl = "";
                    for (int j = 0; j < dtCostCntrDebDtl.Rows.Count; j++)
                    {
                        decimal costAmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString());
                        string valuestringCost = String.Format(format, costAmnt);
                        if (dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() != "")
                        {
                            string costGrp1 = "0";
                            string costGrp2 = "0";


                            if (dtCostCntrDebDtl.Rows[j]["COSTGRP_ID_ONE"].ToString() != "")
                            {
                                costGrp1 = dtCostCntrDebDtl.Rows[j]["COSTGRP_ID_ONE"].ToString();
                            }
                            if (dtCostCntrDebDtl.Rows[j]["COSTGRP_ID_TWO"].ToString() != "")
                            {
                                costGrp2 = dtCostCntrDebDtl.Rows[j]["COSTGRP_ID_TWO"].ToString();
                            }


                            if (strCostDtl == "")
                            {
                                strCostDtl = dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() + "%" + valuestringCost + "%" + costGrp1 + "%" + costGrp2;
                            }
                            else
                            {
                                strCostDtl = strCostDtl + "$" + dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() + "%" + valuestringCost + "%" + costGrp1 + "%" + costGrp2;
                            }
                        }
                        else if (dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString() != "")
                        {
                            if (strPurchaseDtl == "")
                            {
                                strPurchaseDtl = dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString() + "%" + valuestringCost;
                            }
                            else
                            {
                                strPurchaseDtl = strPurchaseDtl + "$" + dtCostCntrDebDtl.Rows[j]["SALES_ID"].ToString() + "%" + valuestringCost;
                            }
                        }
                        else if (dtCostCntrDebDtl.Rows[j]["PURCHS_ID"].ToString() != "")
                        {
                            if (strPurchaseDtl == "")
                            {
                                strPurchaseDtl = dtCostCntrDebDtl.Rows[j]["PURCHS_ID"].ToString() + "%" + valuestringCost;
                            }
                            else
                            {
                                strPurchaseDtl = strPurchaseDtl + "$" + dtCostCntrDebDtl.Rows[j]["PURCHS_ID"].ToString() + "%" + valuestringCost;
                            }
                        }
                    }
                    string PurOrsale = "";
                    decimal LedgrAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[i]["LD_JURNL_AMT"].ToString());
                    string valuestringLedg = String.Format(format, LedgrAmnt);
                    if (dtLedgrdDebDtl.Rows[i]["LD_JURNL_STS"].ToString() == "0")
                    {
                        sb.Append("<td class=\" tr_r col-md-2\">");

                        PurOrsale = "SAL";
                        sb.Append("<div class=\"input-group\">  <span class=\"input-group-addon cur1\">"+ HiddenCurrencyAbrv.Value+"</span><input type=\"text\" disabled class=\"form-control fg2_inp2 tr_r\"  value=\"" + valuestringLedg + "\" id=\"TxtAmount_" + i + "\" onkeydown=\"return isDecimalNumber(event,'TxtAmount_" + i + "');\" onkeypress=\"return isDecimalNumber(event,'TxtAmount_" + i + "');\" name=\"TxtAmount_" + i + "\"  onblur=\"return PendingPurchase('TxtAmount_" + i + "','" + i + "','DBT');\"   id=\"TxtAmount_" + i + "\"  maxlength=10 >");
                        sb.Append("</div></td>");
                        sb.Append("<td class=\" tr_r col-md-2\">");


                        sb.Append("<div class=\"input-group\">  <span class=\"input-group-addon cur1\">" + HiddenCurrencyAbrv.Value + "</span><input type=\"text\" disabled class=\"form-control fg2_inp2 tr_r\"  id=\"TxtAmountCrdt" + i + "\" onkeydown=\"return isDecimalNumber(event,'TxtAmountCrdt" + i + "');\" onkeypress=\"return isDecimalNumber(event,'TxtAmountCrdt" + i + "');\" name=\"TxtAmountCrdt" + i + "\"  onblur=\"return PendingPurchase('TxtAmountCrdt" + i + "','" + i + "','CDT');\"   id=\"TxtAmountCrdt" + i + "\"  maxlength=10 >");
                        sb.Append("</div></td>");
                    }
                    else
                    {
                        sb.Append("<td class=\" tr_r col-md-2\">");

                        PurOrsale = "PURCH";
                        sb.Append("<div class=\"input-group\">  <span class=\"input-group-addon cur1\">" + HiddenCurrencyAbrv.Value + "</span><input type=\"text\" disabled class=\"form-control fg2_inp2 tr_r\"  id=\"TxtAmount_" + i + "\" onkeydown=\"return isDecimalNumber(event,'TxtAmount_" + i + "');\" onkeypress=\"return isDecimalNumber(event,'TxtAmount_" + i + "');\" name=\"TxtAmount_" + i + "\"  onblur=\"return PendingPurchase('TxtAmount_" + i + "','" + i + "','DBT');\"   id=\"TxtAmount_" + i + "\"  maxlength=10 >");
                        sb.Append("</td>");
                        sb.Append("<td class=\" tr_r col-md-2\">");


                        sb.Append("<div class=\"input-group\">  <span class=\"input-group-addon cur1\">" + HiddenCurrencyAbrv.Value + "</span><input type=\"text\" disabled class=\"form-control fg2_inp2 tr_r\"  value=\"" + valuestringLedg + "\" id=\"TxtAmountCrdt" + i + "\" onkeydown=\"return isDecimalNumber(event,'TxtAmountCrdt" + i + "');\" onkeypress=\"return isDecimalNumber(event,'TxtAmountCrdt" + i + "');\" name=\"TxtAmountCrdt" + i + "\"  onblur=\"return PendingPurchase('TxtAmountCrdt" + i + "','" + i + "','CDT');\"   id=\"TxtAmountCrdt" + i + "\"  maxlength=10 >");
                        sb.Append("</td>");
                    }

                    sb.Append(" <td class=\"col-md-3\"> <textarea \"TxtRemark" + i + "\" disabled    value=\"" + dtLedgrdDebDtl.Rows[i]["LD_JURNL_REMARK"].ToString() + "\" id=\"TxtRemark" + i + "\"   rows=\"3\" cols=\"20\"  class=\"form-control\" style=\" resize: none;\" onkeydown=\"textCounter(TxtRemark" + i + ",450)\" onkeyup=\"textCounter(TxtRemark" + i + ",450)\">" + dtLedgrdDebDtl.Rows[i]["LD_JURNL_REMARK"].ToString() + "</textarea></td>");


                    sb.Append("<td class=\"td1 col-md-1\">");
                    //if (i == dtLedgrdDebDtl.Rows.Count - 1)
                    //{
                    //    sb.Append("<button class=\"btn btn-primary\" title=\"Add\" id=\"journalADD" + i + "\"  onclick=\"return FuctionAddGroup('" + i + "')\">");
                    //    sb.Append("<span class=\"fa fa-plus\" id=\"Span7\" style=\"display: block;\">&nbsp;</span>");
                    //    sb.Append("</button>");
                    //    sb.Append("<button class=\"btn btn-primary\" title=\"Delete\" style=\"margin-left:10%;\" id=\"bttnRemovGrp" + i + "\" onclick=\"return removeRowGrps(" + i + ",'Are you sure you want to delete this ledger?')\">");
                    //    sb.Append("<span class=\"fa fa-trash\" id=\"Span6\" style=\"display: block;\">&nbsp;</span>");
                    //    sb.Append("</button>");

                    //}
                    //else
                    //{
                    sb.Append("<button disabled class=\"btn act_btn bn2\" title=\"Add\" id=\"journalADD" + i + "\"  onclick=\"return FuctionAddGroup('" + i + "')\">");
                    sb.Append("<i class=\"fa fa-plus-circle\" id=\"Span7\" style=\"display: block;\">&nbsp;</i>");
                    sb.Append("</button>");
                    sb.Append("<button disabled  class=\"btn act_btn bn3\" title=\"Delete\"  id=\"bttnRemovGrp" + i + "\" onclick=\"return removeRowGrps(" + i + ",'Are you sure you want to delete this ledger?')\">");
                    sb.Append("<i class=\"fa fa-trash\" id=\"Span6\" style=\"display: block;\">&nbsp;</i>");
                    sb.Append("</button>");

                    //   }
                    sb.Append("</td>");

                    sb.Append("<td class=\"col-md-1\">");
                   

                    if (HiddenPurchseSaleStatus.Value == "1")
                    {
                        sb.Append("<a id=\"ChkPurchase" + i + "\" title=\"PURCHASE\"  onclick=\"return ddlLedOnchange('" + i + "','ins','DBT');\" ><i id=\"ChkPurchaseITag" + i + "\" class=\"fa fa-shopping-cart ad_fa psc_p\"></i></a>");

                        sb.Append("<a id=\"ChkSales" + i + "\" title=\"SALES\"  onclick=\"return ddlLedOnchange('" + i + "','ins','CDT');\" ><i id=\"ChkSalesITag" + i + "\" class=\"fa fa-balance-scale ad_fa psc_s\"></i></a>");
                    }


                    sb.Append("<a  id=\"ChkCostCenter" + i + "\"  title=\"COST CENTRE\"  onclick=\"MyModalCostCenter('" + i + "','" + i + "',null);\" ><i class=\"fa fa-filter ad_fa psc_c\"></i></a>");
                    sb.Append("</td>");




                    sb.Append("<td  style=\"display:none;\"><input  type=\"text\" class=\"form-control\" style=\"display:none;\" id=\"tdPurchaseDtls" + i + "\" name=\"tdPurchaseDtls" + i + "\" value='" + strPurchaseDtl + "'/></td>");
                    sb.Append("<td  style=\"display:none;\"><input type=\"text\" class=\"form-control\" style=\"display:none;\"  id=\"tdCostCenterDtls" + i + "\" name=\"tdCostCenterDtls" + i + "\" value='" + strCostDtl + "'/></td>");
                    sb.Append("<td  style=\"display: none;\"><input type=\"text\" value='" + PurOrsale + "' class=\"form-control\" style=\"display:none;\"  id=\"tdPurchOrSale" + i + "\" name=\"tdPurchOrSale" + i + "\" /></td>");


                    sb.Append("<td  style=\"display: none;\"><input type=\"text\" class=\"form-control\" value=\"UPD\" style=\"display:none;\"  id=\"tdEvtGrp" + i + "\" name=\"tdEvtGrp" + i + "\" /></td>");

                    sb.Append("<td  style=\"display: none;\"><input type=\"text\" class=\"form-control\"  value=\"" + dtLedgrdDebDtl.Rows[i]["LD_JURNL_ID"].ToString() + "\"  style=\"display:none;\"  id=\"tdDtlIdTempid" + i + "\" name=\"tdDtlIdTempid" + i + "\" /><input type=\"text\" class=\"form-control\"  style=\"display:none;\"  id=\"tdDtlIdGrp" + i + "\" name=\"tdDtlIdGrp" + i + "\" /></td>");

                    sb.Append("<td  style=\"display: none;\"><input type=\"text\" class=\"form-control\"  value=\"" + i + "\"  style=\"display:none;\"  id=\"tdInxGrp" + i + "\" name=\"tdInxGrp" + i + "\" /> </td>");



                    sb.Append("</tr>");
                }
                tabMainDebBody.InnerHtml = sb.ToString();
            }

            if (YearEndCls == 1)
            {
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
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
        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtLedger = objBusinessLayerStock.ReadLedgerDdl(objEntityLayerStock);



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
    public class clsLedgrData
    {
        public string TABMODE { get; set; }
        public string MAINTABID { get; set; }
        public string LEDGRTABID { get; set; }
        public string LEDGRID { get; set; }
        public string LEDGRAMNT { get; set; }
        public string REMARKS { get; set; }

    }
    public class clsCostCntrData
    {
        public string TABMODE { get; set; }
        public string MAINTABID { get; set; }
        public string SUBTABID { get; set; }
        public string COSTCENTRTABID { get; set; }
        public string COSTCENTRID { get; set; }
        public string COSTCENTRAMNT { get; set; }
        public string PURSALESTS { get; set; }
        public string COSTGRPID_ONE { get; set; }
        public string COSTGRPID_TWO { get; set; }
        public string SETTLMNT_AMT { get; set; }
    }

    protected void bttnsave_Click(object sender, EventArgs e)
    {
        try
        {
            Button clickedButton = sender as Button;
            clsEntityJournal objEntityLayerStock = new clsEntityJournal();
            clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            if (Session["USERID"] != null)
            {
                objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            objEntityLayerStock.RefNum = TxtRef.Value.ToUpper().Trim();
            objEntityLayerStock.JournalDate = objCommon.textToDateTime(txtdate.Value);
            objEntityLayerStock.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            objEntityLayerStock.Description = txtDescription.Value.Trim();
            //objEntityLayerStock.JournalId = Convert.ToInt32(HiddenFieldJournalId.Value);
            objEntityLayerStock.JournalTotAmnt = Convert.ToDecimal(HiddenFieldTotAmnt.Value);


            if (txtExchangeRate.Value.Trim() != "")
                objEntityLayerStock.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Value.Trim());


            List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityJournalLedgerDtl>();
            List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityJournalCostCntrDtl>();

            string jsonData = HiddenFieldJornlDataLedgr.Value;
            string c = jsonData.Replace("\"{", "\\{");
            string d = c.Replace("\\n", "\r\n");
            string g = d.Replace("\\", "");
            string h = g.Replace("}\"]", "}]");
            string i = h.Replace("}\",", "},");
            List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
            objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);


            if (HiddenFieldJornlDataLedgr.Value != "" && HiddenFieldJornlDataLedgr.Value != null)
            {
                foreach (clsLedgrData objclsTVData in objTVDataList5)
                {
                    clsEntityJournalLedgerDtl objEntityDtl = new clsEntityJournalLedgerDtl();
                    objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                    objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                    objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                    objEntityDtl.LedgerId = Convert.ToInt32(objclsTVData.LEDGRID);
                    if (objEntityDtl.TabMode == 0)
                    {
                        objEntityDtl.LedgerTotAmnt = Convert.ToDecimal(Request.Form["TxtAmount_" + objclsTVData.MAINTABID]);
                    }
                    else
                    {
                        objEntityDtl.LedgerTotAmnt = Convert.ToDecimal(Request.Form["TxtAmountCrdt" + objclsTVData.MAINTABID]);
                    }
                    if (Request.Form["TxtRemark" + objclsTVData.MAINTABID] != "")
                    {
                        objEntityDtl.Remarks = Request.Form["TxtRemark" + objclsTVData.MAINTABID];
                    }

                    objEntityJrnlLedgrList.Add(objEntityDtl);
                }
            }

            jsonData = HiddenFieldJornlDataCostCentr.Value;
            c = jsonData.Replace("\"{", "\\{");
            d = c.Replace("\\n", "\r\n");
            g = d.Replace("\\", "");
            h = g.Replace("}\"]", "}]");
            i = h.Replace("}\",", "},");
            List<clsCostCntrData> objTVDataList6 = new List<clsCostCntrData>();
            objTVDataList6 = JsonConvert.DeserializeObject<List<clsCostCntrData>>(i);


            if (HiddenFieldJornlDataCostCentr.Value != "" && HiddenFieldJornlDataCostCentr.Value != null)
            {
                foreach (clsCostCntrData objclsTVData in objTVDataList6)
                {
                    if (objclsTVData.COSTCENTRAMNT != "" && objclsTVData.COSTCENTRID != "" && objclsTVData.COSTCENTRID != "-Select Cost Center-")
                    {
                        clsEntityJournalCostCntrDtl objEntityDtl = new clsEntityJournalCostCntrDtl();
                        objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                        objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                        //objEntityDtl.SubTabId = Convert.ToInt32(objclsTVData.SUBTABID);
                        objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                        objEntityDtl.PurSaleRefNum = objclsTVData.PURSALESTS;
                        objEntityDtl.CostCenterId = Convert.ToInt32(objclsTVData.COSTCENTRID);
                        objEntityDtl.CostCntrAmnt = Convert.ToDecimal(objclsTVData.COSTCENTRAMNT);
                        objEntityDtl.CostGrp1Id = Convert.ToInt32(objclsTVData.COSTGRPID_ONE);
                        objEntityDtl.CostGrp2Id = Convert.ToInt32(objclsTVData.COSTGRPID_TWO);


                        objEntityJrnlCostcentrList.Add(objEntityDtl);
                    }
                }
            }

            //     objEntityJrnlLedgrList.Reverse();
            //    objEntityJrnlCostcentrList.Reverse();

            int AcntCloseSts = AccountCloseCheck(txtdate.Value);
            int retFlg = 0;
            int AuditCloseSts = AuditCloseCheck(txtdate.Value);
            if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
            {
                retFlg = 1;
                Response.Redirect("fms_Journal_List.aspx?InsUpd=AuditClosed");
            }
            else if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
            {

            }
            else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
            {
                retFlg = 1;
                Response.Redirect("fms_Journal_List.aspx?InsUpd=AcntClosed");
            }
            if (retFlg == 0)
            {
                objBusinessLayerStock.AddJournalDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);

                if (clickedButton.ID == "bttnsave")
                {
                    Response.Redirect("fms_Journal.aspx?InsUpd=Ins");
                }
                if (clickedButton.ID == "btnFloatSave")
                {
                    Response.Redirect("fms_Journal.aspx?InsUpd=Ins");
                }

                else if (clickedButton.ID == "btnSaveCls")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnFloatSaveCls")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=Ins");
                }



            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            Button clickedButton = sender as Button;

            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                clsEntityJournal objEntityLayerStock = new clsEntityJournal();
                clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                if (Session["USERID"] != null)
                {
                    objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                objEntityLayerStock.RefNum = TxtRef.Value.ToUpper().Trim();
                objEntityLayerStock.JournalDate = objCommon.textToDateTime(txtdate.Value);
                objEntityLayerStock.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                objEntityLayerStock.Description = txtDescription.Value.Trim();
                objEntityLayerStock.JournalId = Convert.ToInt32(strId);
                objEntityLayerStock.JournalTotAmnt = Convert.ToDecimal(HiddenFieldTotAmnt.Value);
                if (HiddenRefChange.Value != HiddenEditDate.Value)
                    objEntityLayerStock.ViewStatus = 1;

                int PostdateChqSts = 0;
                DataTable dtReadById = objBusinessLayerStock.ReadJournalDtlsById(objEntityLayerStock);
                if (dtReadById.Rows.Count > 0)
                {
                    if (dtReadById.Rows[0]["JURNL_REF_SEQNUM"].ToString() != "")
                    {
                        objEntityLayerStock.RefSeqNo = Convert.ToInt32(dtReadById.Rows[0]["JURNL_REF_SEQNUM"].ToString());
                    }
                    if (dtReadById.Rows[0]["PST_CHEQUE_DTLS_ID"].ToString() != "")
                    {
                        PostdateChqSts = 1;
                    }
                }

                if (txtExchangeRate.Value.Trim() != "")
                    objEntityLayerStock.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Value.Trim());
                List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityJournalLedgerDtl>();
                List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityJournalCostCntrDtl>();

                string jsonData = HiddenFieldJornlDataLedgr.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
                objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);


                if (HiddenFieldJornlDataLedgr.Value != "" && HiddenFieldJornlDataLedgr.Value != null)
                {
                    foreach (clsLedgrData objclsTVData in objTVDataList5)
                    {
                        clsEntityJournalLedgerDtl objEntityDtl = new clsEntityJournalLedgerDtl();
                        objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                        objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                        objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                        objEntityDtl.LedgerId = Convert.ToInt32(objclsTVData.LEDGRID);
                        if (objEntityDtl.TabMode == 0)
                        {
                            objEntityDtl.LedgerTotAmnt = Convert.ToDecimal(Request.Form["TxtAmount_" + objclsTVData.MAINTABID]);
                        }
                        else
                        {
                            objEntityDtl.LedgerTotAmnt = Convert.ToDecimal(Request.Form["TxtAmountCrdt" + objclsTVData.MAINTABID]);
                        }
                        if (Request.Form["TxtRemark" + objclsTVData.MAINTABID] != "")
                        {
                            objEntityDtl.Remarks = Request.Form["TxtRemark" + objclsTVData.MAINTABID];
                        }

                        objEntityJrnlLedgrList.Add(objEntityDtl);
                    }
                }

                jsonData = HiddenFieldJornlDataCostCentr.Value;
                c = jsonData.Replace("\"{", "\\{");
                d = c.Replace("\\n", "\r\n");
                g = d.Replace("\\", "");
                h = g.Replace("}\"]", "}]");
                i = h.Replace("}\",", "},");
                List<clsCostCntrData> objTVDataList6 = new List<clsCostCntrData>();
                objTVDataList6 = JsonConvert.DeserializeObject<List<clsCostCntrData>>(i);


                if (HiddenFieldJornlDataCostCentr.Value != "" && HiddenFieldJornlDataCostCentr.Value != null)
                {
                    foreach (clsCostCntrData objclsTVData in objTVDataList6)
                    {
                        if (objclsTVData.COSTCENTRAMNT != "" && objclsTVData.COSTCENTRID != "" && objclsTVData.COSTCENTRID != "-Select Cost Center-")
                        {
                            clsEntityJournalCostCntrDtl objEntityDtl = new clsEntityJournalCostCntrDtl();
                            objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                            objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                            //objEntityDtl.SubTabId = Convert.ToInt32(objclsTVData.SUBTABID);
                            objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                            objEntityDtl.PurSaleRefNum = objclsTVData.PURSALESTS;
                            objEntityDtl.CostCenterId = Convert.ToInt32(objclsTVData.COSTCENTRID);
                            objEntityDtl.CostCntrAmnt = Convert.ToDecimal(objclsTVData.COSTCENTRAMNT);

                            objEntityDtl.CostGrp1Id = Convert.ToInt32(objclsTVData.COSTGRPID_ONE);
                            objEntityDtl.CostGrp2Id = Convert.ToInt32(objclsTVData.COSTGRPID_TWO);


                            objEntityJrnlCostcentrList.Add(objEntityDtl);
                        }
                    }
                }

                //  objEntityJrnlLedgrList.Reverse();
                //   objEntityJrnlCostcentrList.Reverse();
                DataTable dt = objBusinessLayerStock.CheckJournlCnclSts(objEntityLayerStock);

                int AcntCloseSts = AccountCloseCheck(txtdate.Value);

                int AuditCloseSts = AuditCloseCheck(txtdate.Value);
                if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=AuditClosed");
                }
                else if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
                {

                }

                else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=AcntClosed");
                }



                if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "0")
                {
                    objBusinessLayerStock.EditJournalDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);

                    if (clickedButton.ID == "btnUpdate")
                    {
                        if (PostdateChqSts == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedValue", "PassSavedValue(0);", true);
                            if (Request.QueryString["VId"] != null)
                            {
                                Response.Redirect("fms_Journal.aspx?Id=" + Request.QueryString["Id"].ToString() + "&InsUpd=Upd&VId=1");
                            }
                            else
                            {
                                Response.Redirect("fms_Journal.aspx?Id=" + Request.QueryString["Id"].ToString() + "&InsUpd=Upd");
                            }
                        }
                        else
                        {
                            Response.Redirect("fms_Journal.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                        }
                    }
                    else if (clickedButton.ID == "btnUpdatecls")
                    {
                        Response.Redirect("fms_Journal_List.aspx?InsUpd=Upd");
                    }
                    if (clickedButton.ID == "btnFloatUpdate")
                    {
                        if (PostdateChqSts == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedValue", "PassSavedValue(0);", true);
                            if (Request.QueryString["VId"] != null)
                            {
                                Response.Redirect("fms_Journal.aspx?Id=" + Request.QueryString["Id"].ToString() + "&InsUpd=Upd&VId=1");
                            }
                            else
                            {
                                Response.Redirect("fms_Journal.aspx?Id=" + Request.QueryString["Id"].ToString() + "&InsUpd=Upd");
                            }
                        }
                        else
                        {
                            Response.Redirect("fms_Journal.aspx?Id=" + Request.QueryString["Id"] + "&&InsUpd=Upd");
                        }
                    }
                    else if (clickedButton.ID == "btnFloatUpdateCls")
                    {
                        Response.Redirect("fms_Journal_List.aspx?InsUpd=Upd");
                    }
                }
                else if (dt.Rows[0][0].ToString() != "")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=UpdCancl");
                }
                else
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=UpdConfm");
                }
            }
        }
        catch (Exception)
        {
        }
    }

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);

                clsEntityJournal objEntityLayerStock = new clsEntityJournal();
                clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
                clsEntityCommon objEntityCommon = new clsEntityCommon();
                clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                if (Session["USERID"] != null)
                {
                    objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["CORPOFFICEID"] != null)
                {
                    objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["ORGID"] != null)
                {
                    objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                objEntityLayerStock.RefNum = TxtRef.Value.ToUpper().Trim();
                objEntityLayerStock.JournalDate = objCommon.textToDateTime(txtdate.Value);
               // objEntityLayerStock.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                objEntityLayerStock.Description = txtDescription.Value.Trim();
                objEntityLayerStock.JournalId = Convert.ToInt32(strId);
                objEntityLayerStock.JournalTotAmnt = Convert.ToDecimal(HiddenFieldTotAmnt.Value);
                objEntityLayerStock.ConfirmSts = 1;
                objEntityLayerStock.FinancialYrId = Convert.ToInt32(HiddenFinancialYearId.Value);

                if (HiddenRefChange.Value != HiddenEditDate.Value)
                    objEntityLayerStock.ViewStatus = 1;

                int PostdateChqSts = 0;
                DataTable dtReadById = objBusinessLayerStock.ReadJournalDtlsById(objEntityLayerStock);
                if (dtReadById.Rows.Count > 0)
                {
                    if (dtReadById.Rows[0]["JURNL_REF_SEQNUM"].ToString() != "")
                    {
                        objEntityLayerStock.RefSeqNo = Convert.ToInt32(dtReadById.Rows[0]["JURNL_REF_SEQNUM"].ToString());
                    }
                    if (dtReadById.Rows[0]["PST_CHEQUE_DTLS_ID"].ToString() != "")
                    {
                        PostdateChqSts = 1;
                    }
                }

                if (txtExchangeRate.Value.Trim() != "")
                    objEntityLayerStock.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Value.Trim());

                List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityJournalLedgerDtl>();
                List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityJournalCostCntrDtl>();

                List<clsEntityJournalCostCntrDtl> objEntityDelete = new List<clsEntityJournalCostCntrDtl>();//EVM-0020

                string strRets = "successConfirm";

                string jsonData = HiddenFieldJornlDataLedgr.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
                objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);
                int DebtCount = 0;
                int CrdtCount = 0;

                if (HiddenFieldJornlDataLedgr.Value != "" && HiddenFieldJornlDataLedgr.Value != null)
                {
                    int Count = 0;
                    foreach (clsLedgrData objclsTVData in objTVDataList5)
                    {
                        clsEntityJournalLedgerDtl objEntityDtl = new clsEntityJournalLedgerDtl();

                        objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                        if (objEntityDtl.TabMode == 1)//Credit
                        {
                            CrdtCount++;
                        }
                        else if (objEntityDtl.TabMode == 0) //Debit
                        {
                            DebtCount++;
                        }
                        objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                        objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                        objEntityDtl.LedgerId = Convert.ToInt32(objclsTVData.LEDGRID);
                        if (objEntityDtl.TabMode == 0)
                        {
                            objEntityDtl.LedgerTotAmnt = Convert.ToDecimal(Request.Form["TxtAmount_" + objclsTVData.MAINTABID]);
                        }
                        else
                        {
                            objEntityDtl.LedgerTotAmnt = Convert.ToDecimal(Request.Form["TxtAmountCrdt" + objclsTVData.MAINTABID]);
                        }
                        if (Request.Form["TxtRemark" + objclsTVData.MAINTABID] != "")
                        {
                            objEntityDtl.Remarks = Request.Form["TxtRemark" + objclsTVData.MAINTABID];
                        }

                        if (txtExchangeRate.Value.Trim() != "")
                        {
                            objEntityDtl.ExchangeRate = objEntityDtl.LedgerTotAmnt * objEntityLayerStock.ExchangeRate;
                        }
                        else
                        {
                            objEntityDtl.ExchangeRate = objEntityDtl.LedgerTotAmnt;
                        }
                        objEntityDtl.LdgrCount = Count;

                        objEntityJrnlLedgrList.Add(objEntityDtl);
                        Count++;
                    }
                }
                objEntityLayerStock.CreditCount = CrdtCount;
                objEntityLayerStock.DebitCount = DebtCount;
                jsonData = HiddenFieldJornlDataCostCentr.Value;
                c = jsonData.Replace("\"{", "\\{");
                d = c.Replace("\\n", "\r\n");
                g = d.Replace("\\", "");
                h = g.Replace("}\"]", "}]");
                i = h.Replace("}\",", "},");
                List<clsCostCntrData> objTVDataList6 = new List<clsCostCntrData>();
                objTVDataList6 = JsonConvert.DeserializeObject<List<clsCostCntrData>>(i);

                int CntExceed = 0;

                if (HiddenFieldJornlDataCostCentr.Value != "" && HiddenFieldJornlDataCostCentr.Value != null)
                {
                    foreach (clsCostCntrData objclsTVData in objTVDataList6)
                    {
                        if (objclsTVData.COSTCENTRAMNT != "" && objclsTVData.COSTCENTRID != "" && objclsTVData.COSTCENTRID != "-Select Cost Center-")
                        {
                            clsEntityJournalCostCntrDtl objEntityDtl = new clsEntityJournalCostCntrDtl();
                            clsEntityJournalCostCntrDtl objSubEntityDEL = new clsEntityJournalCostCntrDtl();//EVM-0020
                            
                            objEntityDtl.TabMode = Convert.ToInt32(objclsTVData.TABMODE);
                            objEntityDtl.MainTabId = Convert.ToInt32(objclsTVData.MAINTABID);
                            //objEntityDtl.SubTabId = Convert.ToInt32(objclsTVData.SUBTABID);
                            objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                            objEntityDtl.PurSaleRefNum = objclsTVData.PURSALESTS;
                            objEntityDtl.CostCenterId = Convert.ToInt32(objclsTVData.COSTCENTRID);
                            objEntityDtl.CostGrp1Id = Convert.ToInt32(objclsTVData.COSTGRPID_ONE);
                            objEntityDtl.CostGrp2Id = Convert.ToInt32(objclsTVData.COSTGRPID_TWO);
                            objEntityDtl.SettlmntAmmnt = Convert.ToDecimal(objclsTVData.SETTLMNT_AMT);
                            objEntityDtl.CostCntrAmnt = Convert.ToDecimal(objclsTVData.COSTCENTRAMNT);

                            decimal decSalesRemainAmt = 0;//EVM-0020
                            decimal decPrchsRemainAmt = 0;

                            if (objclsTVData.PURSALESTS == "Deb")
                            {
                                DataTable dtSalesBalance = objBusinessLayerStock.ReadPurchaseBalance(objEntityLayerStock, objEntityDtl);
                                if (dtSalesBalance.Rows.Count > 0)
                                {
                                    if (dtSalesBalance.Rows[0][1].ToString() != "")
                                        decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                                }

                                if (decSalesRemainAmt != 0)
                                {
                                    if (decSalesRemainAmt < objEntityDtl.CostCntrAmnt)
                                    {
                                        strRets = "PrchsAmountExceeded";
                                        CntExceed++;
                                    }
                                }
                                else if (CntExceed == 0)
                                {
                                    strRets = "PrchsAmtFullySettld";
                                    objSubEntityDEL.JournalCostCntrId = Convert.ToInt32(Request.Form["tdSettld" + objEntityDtl.CostCenterId]);
                                    objEntityDelete.Add(objSubEntityDEL);
                                }
                            }
                            else if (objclsTVData.PURSALESTS == "Cre")
                            {
                                DataTable dtSalesBalance = objBusinessLayerStock.ReadSalesBalance(objEntityLayerStock, objEntityDtl);
                                if (dtSalesBalance.Rows.Count > 0)
                                {
                                    if (dtSalesBalance.Rows[0][1].ToString() != "")
                                        decPrchsRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                                }
                                if (decPrchsRemainAmt != 0)//EVM-0020
                                {
                                    if (decPrchsRemainAmt < objEntityDtl.CostCntrAmnt)
                                    {
                                        strRets = "SalesAmountExceeded";
                                        CntExceed++;
                                    }
                                }
                                else if (CntExceed == 0)
                                {
                                    strRets = "SalesAmtFullySettld";
                                    objSubEntityDEL.JournalCostCntrId = Convert.ToInt32(Request.Form["tdSettld" + objEntityDtl.CostCenterId]);
                                    objEntityDelete.Add(objSubEntityDEL);
                                }
                            } 
                            if (txtExchangeRate.Value.Trim() != "")
                            {
                                objEntityDtl.ExchangeRate = objEntityDtl.CostCntrAmnt * objEntityLayerStock.ExchangeRate;
                            }
                            else
                            {
                                objEntityDtl.ExchangeRate = objEntityDtl.CostCntrAmnt;
                            }

                            if (objEntityDtl.PurSaleRefNum == "" || (objEntityDtl.PurSaleRefNum == "Cre" && decPrchsRemainAmt != 0) || (objEntityDtl.PurSaleRefNum == "Deb" && decSalesRemainAmt != 0))//insert not fully settled or cst cntr
                            {
                                objEntityJrnlCostcentrList.Add(objEntityDtl);
                            }
                        }
                    }

                    if (objEntityDelete.Count > 0)//delete fully settld saved sales and purchs
                    {
                        objBusinessLayerStock.DeleteSalePurchaseLedgers(objEntityDelete);
                        strRets = "successConfirm";
                    }
                }

                if (hiddenDfltCurrencyMstrId.Value != "")
                {
                    objEntityLayerStock.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                }
              //  objEntityJrnlLedgrList.Reverse();
             //   objEntityJrnlCostcentrList.Reverse();
                DataTable dt = objBusinessLayerStock.CheckJournlCnclSts(objEntityLayerStock);
                int AcntCloseSts = AccountCloseCheck(txtdate.Value);

                int AuditCloseSts = AuditCloseCheck(txtdate.Value);
               
                if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=AuditClosed");
                }
                else if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
                {

                }

                else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=AcntClosed");
                }




                if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "0" && strRets != "SalesAmountExceeded" && strRets != "SalesAmtFullySettld")
                {
                    objBusinessLayerStock.ConfirmJournalDtls(objEntityLayerStock, objEntityJrnlLedgrList, objEntityJrnlCostcentrList);

                    if (PostdateChqSts == 1)
                    {
                        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
                        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();

                        objEntity_Cheque.ChequeBookId = Convert.ToInt32(dtReadById.Rows[0]["PST_CHEQUE_DTLS_ID"].ToString());
                        objEntity_Cheque.User_Id = objEntityLayerStock.User_Id;
                        //update paid status
                        objEntity_Cheque.Status = 1;
                        objBusiness_Cheque.UpdateChequePaidRejectStatus(objEntity_Cheque);

                        ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedValue", "PassSavedValue(1);", true);
                        if (Request.QueryString["VId"] != null)
                        {

                        }
                        else
                        {
                            Response.Redirect("fms_Journal_List.aspx?InsUpd=Confrm");
                        }
                    }
                    else
                    {
                        Response.Redirect("fms_Journal_List.aspx?InsUpd=Cnf");
                    }
                }
                else if (dt.Rows[0][0].ToString() != "")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=UpdCancl");
                }
                else if (dt.Rows[0][1].ToString() != "0")
                {
                    Response.Redirect("fms_Journal_List.aspx?InsUpd=UpdConfm");
                }
                else if (strRets == "SalesAmountExceeded")
                {
                    Response.Redirect("fms_Receipt_Account.aspx?InsUpd=SalesAmountExceeded&Id=" + Request.QueryString["Id"].ToString());
                }
                else if (strRets == "SalesAmtFullySettld")
                {
                    Response.Redirect("fms_Receipt_Account.aspx?InsUpd=SalesAmountFullySettld&Id=" + Request.QueryString["Id"].ToString());
                }
                else if (strRets == "PrchsAmountExceeded")
                {
                    Response.Redirect("fms_Receipt_Account.aspx?InsUpd=PrchsAmountExceeded&Id=" + Request.QueryString["Id"].ToString());
                }
                else if (strRets == "PrchsAmtFullySettld")
                {
                    Response.Redirect("fms_Receipt_Account.aspx?InsUpd=PrchsAmtFullySettld&Id=" + Request.QueryString["Id"].ToString());
                }
            }
        }
        catch (Exception)
        {
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
    public static string[] LoadSalesForLedger(string intLedgerId, string intuserid, string intorgid, string intcorpid, string mode, string x, string strCedtOrDbt, string strCurrencyId, string strViewSts, string strCrncyAbrv, string jrnlId, string LdgrId)
    {
        string[] result = new string[8];
        clsEntityJournal ObjEntityRequest = new clsEntityJournal();
        clsBusinessJournal objBussiness = new clsBusinessJournal();
        ObjEntityRequest.JournlLedgerId = Convert.ToInt32(intLedgerId);
        ObjEntityRequest.JournalId = Convert.ToInt32(jrnlId);

        ObjEntityRequest.Org_Id = Convert.ToInt32(intorgid);
        ObjEntityRequest.Corp_Id = Convert.ToInt32(intcorpid);
        if (strViewSts == "1")
            ObjEntityRequest.ViewStatus = Convert.ToInt32(strViewSts);
        if (strCedtOrDbt == "CDT")
        {
            ObjEntityRequest.ConfirmSts = 0;
        }
        else
            ObjEntityRequest.ConfirmSts = 1;
        DataTable dtSales = objBussiness.ReadSelectList(ObjEntityRequest);
        StringBuilder sb = new StringBuilder();
        StringBuilder sbGrp = new StringBuilder();

        string SettldFully = "";
        int SettledCnt = 0;
        string Groupid = "";
        string CopyGroupid = "";
        int flag = 0;
        if (dtSales.Rows.Count > 0)
        {
            sb.Append("<table class=\"table table-bordered\"  id=\"TableAddQstn\" >");
            sb.Append("<thead class=\"thead1\">");
            sb.Append("<tr>");
            sb.Append("<th class=\"col-md-3 td1 tr_l\">Bill#");
            sb.Append("</th>");
            sb.Append("<th class=\"col-md-3\">Bill Date");
            sb.Append("</th>");
            sb.Append("<th class=\"col-md-3 tr_r\">Bill Amount");
            sb.Append("</th>");
            sb.Append("<th class=\"col-md-3 tr_r\">Settlement");
            sb.Append("</th>");
            sb.Append("</tr>");
            sb.Append("</thead><tbody>");
            for (int row1 = 0; row1 < dtSales.Rows.Count; row1++)
            {
                decimal decTotal = 0;
                decimal decSettleAmt = 0;
                if (dtSales.Rows[row1]["BALNC_AMT"].ToString() != "")
                {
                    decTotal = Convert.ToDecimal(dtSales.Rows[row1]["BALNC_AMT"].ToString());
                }
                if (strViewSts == "1")
                {
                    if (dtSales.Rows[row1]["VOCHR_BFR_SETL_AMT"].ToString() != "")
                    {
                        decSettleAmt = Convert.ToDecimal(dtSales.Rows[row1]["VOCHR_BFR_SETL_AMT"].ToString());

                    }
                    else
                    {
                        decSettleAmt = Convert.ToDecimal(dtSales.Rows[row1]["BALNC_AMT"].ToString());

                    }
                }
                else
                {
                    decSettleAmt = Convert.ToDecimal(dtSales.Rows[row1]["BALNC_AMT"].ToString());

                }


                flag++;
                if ((LdgrId == dtSales.Rows[row1]["LD_JURNL_ID"].ToString()) || (LdgrId == "") || (dtSales.Rows[row1]["LD_JURNL_ID"].ToString() == ""))
                {
                    sb.Append("<tr class=\"tr1\" id=\"SelectRow" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >");
                    sb.Append("<td  id=\"tdSaleID" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" style=\"display:none;\">" + dtSales.Rows[row1]["SALES_ID"].ToString() + "</td>");
                    sb.Append("<td class=\"smart-form\" style=\"display:none; \" > <label class=\"checkbox \" ><input type=\"checkbox\"  onkeypress=\"return DisableEnter(event);\"  value=\"" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" id=\"cbMandatory" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\"><i></i></label></td>");
                    sb.Append("<td class=\"td1 tr_l\" id=\"tdSaleRef" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" style=\"\">" + dtSales.Rows[row1]["SALES_REF"].ToString() + "</td>");

                    sb.Append("<td>" + dtSales.Rows[row1]["SALES_DATE"].ToString() + "</td>");
                    sb.Append("<td class=\"tr_r\">" + decSettleAmt + " " + strCrncyAbrv + "</td>");

                    sb.Append("<td  id=\"tdDate" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" style=\"display:none;\">" + dtSales.Rows[row1]["SALES_DATE"].ToString() + "</td>");
                    sb.Append("<td class=\"tr_r\" id=\"tdAmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" style=\"display:none;\">" + dtSales.Rows[row1]["BALNC_AMT"].ToString() + "</td>");
                    sb.Append("<td  id=\"tdLedgerRow" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" style=\"display:none;\">" + x + "</td>");
                    sb.Append("<td class=\"td1 tr_r\" id=\"tdsettlmntAmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" style=\"display:none;\">" + dtSales.Rows[row1]["BALNC_AMT"].ToString() + "</td>");

                    if (decSettleAmt == 0)//EVM-0020
                    {
                        sb.Append("<td class=\"td1 tr_r\"  id=\"tdtxtAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" style=\"\"> ");
                        sb.Append("<div class=\"input-group\"><span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span><input disabled type=\"text\" autocomplete=\"off\" maxlength=10 class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onblur=\"return AmountCalculation(" + dtSales.Rows[row1]["SALES_ID"].ToString() + ");\"  id=\"txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" /></div>");
                        sb.Append("</td>");
                        sb.Append("<td style=\"display: none;\"><input type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" id=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" value=\"" + dtSales.Rows[row1]["CST_JURNL_ID"].ToString() + "\" /></td>");
                        SettledCnt++;
                    }
                    else
                    {
                        sb.Append("<td class=\"td1 tr_r\"  id=\"tdtxtAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" style=\"\"> ");
                        sb.Append("<div class=\"input-group\"><span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span><input type=\"text\" autocomplete=\"off\" class=\"form-control fg2_inp2 tr_r\" maxlength=10 onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onblur=\"return AmountCalculation(" + dtSales.Rows[row1]["SALES_ID"].ToString() + ");\"  id=\"txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" /></div>");
                        sb.Append("</td>");
                        sb.Append("<td style=\"display: none;\"><input type=\"text\" name=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" id=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" value=\"0\" /></td>");
                    }

                    sb.Append("</tr>");
                    if (row1 == 0)
                    {
                        Groupid = dtSales.Rows[row1]["SALES_ID"].ToString();
                    }
                }
            }
            sb.Append("</tbody></table>");

            if (SettledCnt == dtSales.Rows.Count)
            {
                SettldFully = "1";
            }
        }

        if (flag == 0)
            sb.Clear();

        DataTable dtacntblnc = objBussiness.ReadLedgrBal(ObjEntityRequest);
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
                //    CrOrDr = "CR";
                DBalance = DecCredAmnt - Openbalance;

            }
            else if (dtacntblnc.Rows[0]["LDGR_MODE"].ToString() == "0")
            {
                if (dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString() != "")
                    DecDebAmnt = Convert.ToDecimal(dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString());
                //if (dtacntblnc.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                //    Openbalance = Convert.ToDecimal(dtacntblnc.Rows[0]["LDGR_OPEN_BAL"].ToString());
                //    CrOrDr = "DR";
                DBalance = DecDebAmnt + Openbalance;
            }
            if (DBalance > 0)
            {
                CrOrDr = "DR";
            }

            Nature = dtacntblnc.Rows[0]["ACNT_NATURE_STS"].ToString();
        }
        result[4] = "";
        if (strCurrencyId != "")
        {
            clsBusinessSales objBusinessSales = new clsBusinessSales();
            clsEntitySales ObjEntitySales = new clsEntitySales();
            ObjEntitySales.Organisation_id = Convert.ToInt32(intorgid);
            ObjEntitySales.Corporate_id = Convert.ToInt32(intcorpid);
            ObjEntitySales.CurrencyId = Convert.ToInt32(strCurrencyId);
            DataTable dtSubConrt = objBusinessSales.ReadCrncyAbrvtn(ObjEntitySales);
            // dtSubConrt.TableName = "dtTableLoadProduct";
            //  string ABVRTN;
            if (dtSubConrt.Rows.Count > 0)
            {
                result[4] = dtSubConrt.Rows[0][0].ToString();
            }
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
        result[3] = "Purchase";
        result[5] = Groupid;
        result[6] = Nature;
        result[7] = SettldFully;

        return result;
    }

    [WebMethod]
    public static string LoadChequeBookNumber(string ChequeBook, string status)
    {
        string result = "";
        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
        if (ChequeBook != "" && ChequeBook != "--SELECT--")
        {
            ObjEntityRequest.ChequeBookId = Convert.ToInt32(ChequeBook);

            DataTable DtACI = objBussiness.ReadChequeBook_CancelIds(ObjEntityRequest);
            DataTable DtACI1 = objBussiness.ReadChequeBook_UsedIds(ObjEntityRequest);
            DtACI.TableName = "dtTableACIPackage";
            string strAI = "";
            string strCancelIds = "";
            int intFrom = 0;
            int intTo = 0;

            for (int i = 0; i < DtACI.Rows.Count; i++)
            {
                if (DtACI.Rows[i]["CHKBK_CNCL_NUM"].ToString() != "")
                {
                    if (strCancelIds == "")
                    {
                        strCancelIds = DtACI.Rows[i]["CHKBK_CNCL_NUM"].ToString();
                    }
                    else
                    {
                        strCancelIds = strCancelIds + "," + DtACI.Rows[i]["CHKBK_CNCL_NUM"].ToString();
                    }
                }
            }
            for (int i = 0; i < DtACI1.Rows.Count; i++)
            {
                if (status != "1")
                {
                    if (DtACI1.Rows[i]["PAYMNT_CHQ_NUMBER"].ToString() != "")
                    {
                        if (DtACI1.Rows[i]["PAYMNT_CHQ_NUMBER"].ToString() != "")
                        {
                            if (strCancelIds == "")
                            {
                                strCancelIds = DtACI1.Rows[i]["PAYMNT_CHQ_NUMBER"].ToString();
                            }
                            else
                            {
                                strCancelIds = strCancelIds + "," + DtACI1.Rows[i]["PAYMNT_CHQ_NUMBER"].ToString();
                            }

                        }
                    }
                }
            }
            if (DtACI.Rows.Count > 0)
            {
                if (DtACI.Rows[0]["CHKBK_NUM_FROM"].ToString() != "")
                {
                    intFrom = Convert.ToInt32(DtACI.Rows[0]["CHKBK_NUM_FROM"].ToString());
                }
                if (DtACI.Rows[0]["CHKBK_NUM_TO"].ToString() != "")
                {
                    intTo = Convert.ToInt32(DtACI.Rows[0]["CHKBK_NUM_TO"].ToString());
                }
            }

            for (int Chq = intFrom; intFrom <= intTo; intFrom++)
            {
                if (!(strCancelIds.Contains(Convert.ToString(intFrom))))
                {
                    if (strAI == "")
                    {
                        strAI = Convert.ToString(intFrom);
                    }
                    else
                    {
                        strAI = strAI + "," + Convert.ToString(intFrom);

                    }
                }
            }
            result = strAI;
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
        if (dtAuditCls.Rows.Count > 0 && AuditPrvsn!="1")
        {
            sts = 1;
        }
        else if (dtAuditCls.Rows.Count > 0 && AuditPrvsn == "1")
        {
          
        }
        else if (dtAccntCls.Rows.Count > 0 && AcntPrvsn!= "1")
        {
            sts = 2;
        }
        else if (dtAccntCls.Rows.Count > 0 && AcntPrvsn == "1")
        {
            
        }
        return sts.ToString();
    }
    [WebMethod]
    public static string CheckRefNumber(string jrnlDate, string orgID, string corptID, string usrID, string RefNum, string jrnlID)
    {
        string Ref = "";

        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();


        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(jrnlDate);
        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();


        objEntityLayerStock.FromDate = objCommon.textToDateTime(jrnlDate);

        if (corptID != null && corptID != "")
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(corptID);
            objEntityLayerStock.Corp_Id = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);
            objEntityAudit.Corporate_id = Convert.ToInt32(corptID);
        }
        if (orgID != null && orgID != "")
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(orgID);
            objEntityLayerStock.Org_Id = Convert.ToInt32(orgID);
            objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
            objEntityAudit.Organisation_id = Convert.ToInt32(orgID);

        }
        objEntityAudit.FromDate = objCommon.textToDateTime(jrnlDate);

        if (RefNum != "")
        {
            Ref = RefNum;
        }
        int SubRef = 1;
        DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
        DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);

        if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
        {
            DataTable dtRefFormat1 = objBusinessLayerStock.ReadRefNumberByDate(objEntityLayerStock);
            if (dtRefFormat1.Rows.Count > 0)
            {
                string strRef = "";
                if (dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "")
                {
                    if (Convert.ToInt32(dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString()) != 1)
                    {
                        strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                        strRef = strRef.TrimEnd('/');
                        strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                    }
                }
                else
                {
                    strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                }
                objEntityLayerStock.RefNum = strRef;
                DataTable dtRefFormat = objBusinessLayerStock.ReadRefNumberByDateLast(objEntityLayerStock);
                if (dtRefFormat.Rows.Count > 0)
                {
                    // if (Convert.ToInt32(jrnlID) != Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_ID"].ToString()))
                    // {
                    Ref = dtRefFormat.Rows[0]["JURNL_REF"].ToString();
                    if (dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != null)
                    {
                        SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString());
                    }
                    if (SubRef != 1)
                    {
                        Ref = Ref.TrimEnd('/');
                        Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                        Ref = Ref + "" + SubRef;
                    }
                    else
                    {
                        Ref = Ref + "/" + SubRef;
                    }
                    //}

                }
            }
            else
            {


                if (jrnlID == "")
                {
                    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL);
                    objEntityCommon.CorporateID = Convert.ToInt32(corptID);
                    objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
                    string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);
                    DataTable dtFormate = objBusinessLayerStock.readRefFormate(objEntityCommon);

                    int intOrgId = Convert.ToInt32(orgID);
                    int intCorpId = Convert.ToInt32(corptID);
                    string CurrentDate = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
                    DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                    int DtYear = dtCurrentDate.Year;
                    string dtyy = dtCurrentDate.ToString("yy");
                    int DtMonth = dtCurrentDate.Month;
                    int intUserId = Convert.ToInt32(usrID);
                    string refFormatByDiv = "";
                    string strRealFormat = "";
                    if (dtFormate.Rows.Count > 0)
                    {
                        if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                        {
                            refFormatByDiv = dtFormate.Rows[0]["REF_FORMATE"].ToString();
                            string strReferenceFormat = "";
                            strReferenceFormat = refFormatByDiv;


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
                            strRealFormat = strRealFormat.Replace("*", "");
                            strRealFormat = strRealFormat.Replace("%", "");


                        }
                        Ref = strRealFormat;

                    }
                }
            }
        }
        else 
        {
            if (jrnlID == "")
            {
                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL);
                objEntityCommon.CorporateID = Convert.ToInt32(corptID);
                objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
                string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);
                DataTable dtFormate = objBusinessLayerStock.readRefFormate(objEntityCommon);

                int intOrgId = Convert.ToInt32(orgID);
                int intCorpId = Convert.ToInt32(corptID);
                string CurrentDate = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
                DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
                int DtYear = dtCurrentDate.Year;
                string dtyy = dtCurrentDate.ToString("yy");
                int DtMonth = dtCurrentDate.Month;
                int intUserId = Convert.ToInt32(usrID);
                string refFormatByDiv = "";
                string strRealFormat = "";
                if (dtFormate.Rows.Count > 0)
                {
                    if (dtFormate.Rows[0]["REF_FORMATE"].ToString() != "")
                    {
                        refFormatByDiv = dtFormate.Rows[0]["REF_FORMATE"].ToString();
                        string strReferenceFormat = "";
                        strReferenceFormat = refFormatByDiv;


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
                        strRealFormat = strRealFormat.Replace("*", "");
                        strRealFormat = strRealFormat.Replace("%", "");


                    }
                    Ref = strRealFormat;

                }
            }

        }
        return Ref;
    }

    //protected void btnPRint_Click(object sender, EventArgs e)
    //{
    //    string strId = "";
    //    if (Request.QueryString["Id"] != null)
    //    {
    //        string strRandomMixedId = Request.QueryString["Id"].ToString();
    //        string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //        int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //        strId = strRandomMixedId.Substring(2, intLenghtofId);
    //    }
    //    else if (Request.QueryString["ViewId"] != null)
    //    {
    //        string strRandomMixedId = Request.QueryString["ViewId"].ToString();
    //        string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //        int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //        strId = strRandomMixedId.Substring(2, intLenghtofId);


    //    }
    //    clsEntityJournal objEntityLayerStock = new clsEntityJournal();
    //    clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();

    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    int intUserId = 0;
    //    string PreparedBy = "";

    //    if (Session["USERFULLNAME"] != null)
    //    {
    //        PreparedBy = Session["USERFULLNAME"].ToString();
    //    }

    //    if (Session["USERID"] != null)
    //    {
    //        objEntityLayerStock.User_Id = Convert.ToInt32(Session["USERID"].ToString());
    //        intUserId = Convert.ToInt32(Session["USERID"].ToString());
    //    }
    //    else
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    if (Session["CORPOFFICEID"] != null)
    //    {
    //        objEntityLayerStock.Corp_Id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //        objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //    }
    //    else if (Session["CORPOFFICEID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    if (Session["ORGID"] != null)
    //    {
    //        objEntityLayerStock.Org_Id = Convert.ToInt32(Session["ORGID"].ToString());
    //    }
    //    else if (Session["ORGID"] == null)
    //    {
    //        Response.Redirect("/Default.aspx");
    //    }
    //    int intUsrRolMstrId = 0, intAdd = 0, intUpdate = 0;
    //    intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
    //    int intConfirm = 0, intReopen = 0;
    //    intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Journal);
    //    DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);

    //    if (dtChildRol.Rows.Count > 0)
    //    {
    //        string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

    //        string[] strChildDefArrWords = strChildRolDeftn.Split('-');
    //        foreach (string strC_Role in strChildDefArrWords)
    //        {
    //            if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
    //            {
    //                intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
    //            }
    //            if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
    //            {
    //                intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
    //            }
    //            if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
    //            {
    //                intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
    //                HiddenFieldAcntCloseReopenSts.Value = "1";
    //            }
    //            if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
    //            {

    //                HiddenFieldAuditCloseReopenSts.Value = "1";
    //            }
    //        }
    //    }
    //    objEntityLayerStock.JournalId = Convert.ToInt32(strId);

    //    DataTable dt = objBusinessLayerStock.ReadJournalDtlsById(objEntityLayerStock);
    //    DataTable dtLedgrdDebDtl = objBusinessLayerStock.ReadJrnlLedgrDtlsById(objEntityLayerStock);
    //    DataTable dtCorp = objBusinessLayerStock.ReadCorpDtls(objEntityLayerStock);

    //    string DecCnt = hiddenDecimalCount.Value;

    //    //   PdfPrint(strId, dt, dtLedgrdDebDtl, dtCorp, PreparedBy, DecCnt, objEntityLayerStock);
    //    int Version_flg = 0;

    //    objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.JOURNAL);
    //    DataTable dtVersion = objBusinessLayer.ReadPrintVersion(objEntityCommon);
    //    if (dtVersion.Rows.Count > 0)
    //    {
    //        if (dtVersion.Rows[0][0].ToString() == "1")
    //        {

    //            Version_flg = 1;
    //            PdfPrintVersion1(strId, dt, dtLedgrdDebDtl, dtCorp, PreparedBy, DecCnt, objEntityLayerStock, Version_flg);

    //        }
    //        else if (dtVersion.Rows[0][0].ToString() == "2")
    //        {
    //            Version_flg = 2;
    //            PdfPrintVersion2(strId, dt, dtLedgrdDebDtl, dtCorp, PreparedBy, DecCnt, objEntityLayerStock, Version_flg);


    //        }
    //        else if (dtVersion.Rows[0][0].ToString() == "3")
    //        {
    //            Version_flg = 3;
    //            PdfPrintVersion2(strId, dt, dtLedgrdDebDtl, dtCorp, PreparedBy, DecCnt, objEntityLayerStock, Version_flg);

    //        }
    //        LeadgerLoad();
    //        CostCenterLoad();
    //        CostGroup1Load();
    //        CostGroup2Load();

    //        if (Request.QueryString["Id"] != null)
    //        {

    //            lblEntry.Text = "Edit Journal";
    //            string strRandomMixedId = Request.QueryString["Id"].ToString();
    //            string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //            int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //            strId = strRandomMixedId.Substring(2, intLenghtofId);
    //            bttnsave.Visible = false;
    //            btnUpdate.Visible = true;
    //            btnCancel.Visible = true;
    //            Update(strId, intConfirm, intReopen);
    //            ClientScript.RegisterStartupScript(this.GetType(), "updDebitColor", "updDebitColor();", true);
    //        }
    //        else if (Request.QueryString["ViewId"] != null)
    //        {

    //            lblEntry.Text = "View Journal";
    //            string strRandomMixedId = Request.QueryString["ViewId"].ToString();
    //            string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //            int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //            strId = strRandomMixedId.Substring(2, intLenghtofId);
    //            bttnsave.Visible = false;
    //            btnUpdate.Visible = false;
    //            btnConfirm.Visible = false;
    //            btnReopen.Visible = false;
    //            btnCancel.Visible = true;
    //            View(strId, intConfirm, intReopen);

    //            ClientScript.RegisterStartupScript(this.GetType(), "updDebitColor", "updDebitColor();", true);
    //        }
    //    }
    //    else
    //    {
    //        ScriptManager.RegisterStartupScript(this, GetType(), "PrintVersnError", "PrintVersnError();", true);
    //    }
    //}

    //public void PdfPrintVersion1(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtCorp, string PreparedBy, string DecCnt, clsEntityJournal objEntityLayerStock, int Version_flg)
    //{
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);

    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);

    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();

    //    objEntityCommon.CorporateID = objEntityLayerStock.Corp_Id;
    //    objEntityCommon.Organisation_Id = objEntityLayerStock.Org_Id;

    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL_PRINT);
    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Journal" + Id + "_" + strNextNumber + ".pdf";


    //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {
    //        int precision = Convert.ToInt32(DecCnt);
    //        string format = String.Format("{{0:N{0}}}", precision);


    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {
    //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
    //            PdfWriter writer = PdfWriter.GetInstance(document, file);
    //            document.Open();
    //            PdfPTable headImg = new PdfPTable(2);

    //            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
    //            if (dtCorp.Rows.Count > 0)
    //            {
    //                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
    //                    strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + dtCorp.Rows[0]["CORPRT_ICON"].ToString();

    //            }

    //            if (strImageLogo != "")
    //            {
    //                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
    //                image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //                image.ScaleToFit(100f, 80f);

    //                headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
    //            }
    //            else
    //            {
    //                headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
    //            }
    //            var FontColour = new BaseColor(79, 167, 206);

    //            if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
    //            {
    //                headImg.AddCell(new PdfPCell(new Phrase("JOURNAL", FontFactory.GetFont("Arial", 16, Font.BOLD, FontColour))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });

    //            }
    //            else
    //            {
    //                headImg.AddCell(new PdfPCell(new Phrase("DRAFT JOURNAL", FontFactory.GetFont("Arial", 16, Font.BOLD, FontColour))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });

    //            }
    //            float[] headersHeading = { 60, 40 };
    //            headImg.SetWidths(headersHeading);
    //            headImg.WidthPercentage = 100;

    //            document.Add(headImg);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;
    //            FontColour = new BaseColor(0, 174, 239);
    //            footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            //if (dtCorp.Rows.Count > 0)
    //            //{
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //}


    //            if (dtCorp.Rows.Count > 0)
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            }
    //            document.Add(footrtable);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            PdfPTable footrtables = new PdfPTable(2);
    //            float[] footrsBodys = { 15, 85 };
    //            footrtables.SetWidths(footrsBodys);
    //            footrtables.WidthPercentage = 100;

    //            footrtables.AddCell(new PdfPCell(new Phrase("Journal Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            document.Add(footrtables);

    //            if (dtLedgrdDebDtl.Rows.Count > 0)
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                var FontGray = new BaseColor(138, 138, 138);

    //                PdfPTable table2 = new PdfPTable(4);
    //                float[] tableBody2 = { 40, 20, 20,20 };
    //                table2.SetWidths(tableBody2);
    //                table2.WidthPercentage = 100;

    //                FontColour = new BaseColor(134, 152, 160);
    //                table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("DEBIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("CREDIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });


    //                var FontColour_BORDER = new BaseColor(236, 236, 236);
    //                for (int intRowBodyCount = 0; intRowBodyCount < dtLedgrdDebDtl.Rows.Count; intRowBodyCount++)
    //                {
    //                    decimal decAmnt = 0;
    //                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
    //                    {
    //                        decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
    //                    }
    //                    string valuestringAmnt = String.Format(format, decAmnt);

    //                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    else
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    else
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
              

    //                }
    //                FontColour = new BaseColor(216, 49, 61);
    //                decimal decTotal = 0;
    //                if (dt.Rows[0]["JURNL_TOTAL_AMT"].ToString() != "")
    //                {
    //                    decTotal = Convert.ToDecimal(dt.Rows[0]["JURNL_TOTAL_AMT"].ToString());
    //                }
    //                string valuestringTot = String.Format(format, decTotal);

    //                table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
    //                {
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
    //                }
    //                string strcurrenWord = objBusinessLayer.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));
    //                FontColour = new BaseColor(0, 174, 239);
    //                //table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE });
    //                //table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE });
    //                table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });
                  
    //                document.Add(table2);
    //            }

    //            if (dt.Rows[0]["JURNL_DSCRPTN"].ToString().Trim() != "")
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                document.Add(new Paragraph(new Chunk(dt.Rows[0]["JURNL_DSCRPTN"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //            }

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            string CheckedBy = dt.Rows[0]["USR_NAME"].ToString();

    //            PdfPTable table3 = new PdfPTable(3);
    //            float[] tableBody3 = { 33, 33, 33 };
    //            table3.SetWidths(tableBody3);
    //            table3.WidthPercentage = 100;
    //            table3.TotalWidth = 600F;

    //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });


    //            if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
    //            {
    //                table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            }
    //            else
    //            {
    //                table3.AddCell(new PdfPCell(new Phrase("     ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            }


    //            var FontColourPrprd = new BaseColor(33, 150, 243);
    //            var FontColourChkd = new BaseColor(76, 175, 80);
    //            var FontColourAuthrsd = new BaseColor(255, 87, 34);


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
    //        }

    //        Response.Write("<script>window.open('" + strImagePath + strImageName + "','_blank');</script>");
    //    }
    //    catch (Exception)
    //    {
    //        document.Close();
    //    }
    //}
    //public void PdfPrintVersion2(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtCorp, string PreparedBy, string DecCnt, clsEntityJournal objEntityLayerStock,int Version_flg)
    //{
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);
    //    clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);

    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();

    //    objEntityCommon.CorporateID = objEntityLayerStock.Corp_Id;
    //    objEntityCommon.Organisation_Id = objEntityLayerStock.Org_Id;

    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL_PRINT);
    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Journal" + Id + "_" + strNextNumber + ".pdf";
    //    DataTable dtBankDtls = objBusinessLayer.ReadBankDetails(objEntityCommon);
     

    //    Document document = new Document(PageSize.A4.Rotate(), 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {
    //        int precision = Convert.ToInt32(DecCnt);
    //        string format = String.Format("{{0:N{0}}}", precision);

    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {
    //            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strImagePath));

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

    //            if (Version_flg == 2)
    //            {
    //                PdfPTable headImg = new PdfPTable(2);

    //                if (strImageLogo != "")
    //                {


    //                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));

    //                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //                    image.ScaleToFit(100f, 80f);

    //                    headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });


    //                }
    //                else
    //                {
    //                    headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
    //                }

    //                headImg.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 16, Font.BOLD))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_LEFT });

    //                var FontGrey = new BaseColor(134, 152, 160);

    //                float[] headersHeading = { 70, 30 };
    //                headImg.SetWidths(headersHeading);
    //                headImg.WidthPercentage = 100;

    //                document.Add(headImg);

    //            }

    //            else
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            }


    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;

    //            if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase("JOURNAL", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_LEFT });
    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            }
    //            else
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase("DRAFT JOURNAL", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_LEFT });
    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            }
    //           // footrtable.AddCell(new PdfPCell(new Phrase("INVOICE", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 15 });
    //           // footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("Date :" + dt.Rows[0]["JURNL_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            //footrtable.AddCell(new PdfPCell(new Phrase("To", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 20 });

    //            //footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            //if (dtCorp.Rows.Count > 0)
    //            //{
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //}


    //            //if (dtCorp.Rows.Count > 0)
    //            //{
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //}
    //           document.Add(footrtable);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            //PdfPTable footrtables = new PdfPTable(2);
    //            //float[] footrsBodys = { 15, 85 };
    //            //footrtables.SetWidths(footrsBodys);
    //            //footrtables.WidthPercentage = 100;

    //            //footrtables.AddCell(new PdfPCell(new Phrase("Journal Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            //document.Add(footrtables);
    //            var FontRed = new BaseColor(202, 3, 20);
    //            var FontGreen = new BaseColor(46, 179, 51);
    //            var FontGray = new BaseColor(138, 138, 138);

    //            if (dtLedgrdDebDtl.Rows.Count > 0)
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //               // var FontGray = new BaseColor(138, 138, 138);

    //                PdfPTable table2 = new PdfPTable(8);
    //                float[] tableBody2 = { 18, 12, 12, 13,12,12,12,14 };
    //                table2.SetWidths(tableBody2);
    //                table2.WidthPercentage = 100;
    //              var  FontColour = new BaseColor(134, 152, 160);

    //              table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //              table2.AddCell(new PdfPCell(new Phrase("DEBIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //              table2.AddCell(new PdfPCell(new Phrase("CREDIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //              table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //              table2.AddCell(new PdfPCell(new Phrase("COST-G1", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //              table2.AddCell(new PdfPCell(new Phrase("COST-G2", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //              table2.AddCell(new PdfPCell(new Phrase("COST CENTRE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //              table2.AddCell(new PdfPCell(new Phrase("CC AMT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });


    //                var FontColour_BORDER = new BaseColor(236, 236, 236);
    //                int FLG = 0;
    //                int cstcntrSts = 0;
    //                for (int intRowBodyCount = 0; intRowBodyCount < dtLedgrdDebDtl.Rows.Count; intRowBodyCount++)
    //                {
    //                    decimal decAmnt = 0;
    //                     DataTable dtCostCntrDebDtl=new DataTable();

    //                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_ID"].ToString() != "")
    //                    {
    //                        objEntityLayerStock.JournalId = Convert.ToInt32(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_ID"].ToString());
    //                         dtCostCntrDebDtl = objBusinessLayerStock.ReadJrnlCostCntrDtlsById(objEntityLayerStock);
                 
    //                    }

    //                    if (dtCostCntrDebDtl.Rows.Count > 0)
    //                    {




    //                        FLG = 0;
                           
    //                        decimal CstAmmount = 0;
    //                        for (int j = 0; j < dtCostCntrDebDtl.Rows.Count; j++)
    //                        {

    //                            decimal costAmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString());
    //                            string valuestringCost = String.Format(format, costAmnt);
                               

    //                            if (dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() != "")
    //                            {
    //                                string costGrp1 = dtCostCntrDebDtl.Rows[j]["COSTCNTR_NAME"].ToString();
    //                                string costGrp2 = dtCostCntrDebDtl.Rows[j]["GRP_NAME_ONE"].ToString();
    //                                string costCntr = dtCostCntrDebDtl.Rows[j]["GRP_NAME_TWO"].ToString();
    //                               // string CCAmount = dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString();
    //                                decimal DecCstAmt = 0;
    //                                if (dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString() != "")
    //                                {
    //                                    DecCstAmt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString());
    //                                }
    //                                string valuestringCstAmnt = String.Format(format, DecCstAmt);


    //                                CstAmmount = CstAmmount + Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString());

                                   

    //                                if (FLG == 0)
    //                                {
    //                                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
    //                                    {
    //                                        decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
    //                                    }
    //                                    string valuestringAmnt = String.Format(format, decAmnt);

    //                                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    }
    //                                    else
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    }

    //                                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    }
    //                                    else
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    }

    //                                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                                }
    //                                else
    //                                {
    //                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                                }
    //                                table2.AddCell(new PdfPCell(new Phrase(costGrp1, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                table2.AddCell(new PdfPCell(new Phrase(costGrp2, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                table2.AddCell(new PdfPCell(new Phrase(costCntr, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                table2.AddCell(new PdfPCell(new Phrase(valuestringCstAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                                FLG = 1;
    //                            }
    //                            else 
    //                            {
    //                                cstcntrSts = 1;
    //                            }

                               
    //                        }

    //                        if (FLG == 1)
    //                        {
    //                            if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
    //                            {
    //                                objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
    //                            }
    //                           // string strcurrenWord1 = objBusinessLayer.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(CstAmmount));
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray,});
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray,  });

    //                            table2.AddCell(new PdfPCell(new Phrase("CC-TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, Colspan = 3 });


    //                            string CstCntrTotalDec = String.Format(format, CstAmmount);


    //                            table2.AddCell(new PdfPCell(new Phrase(CstCntrTotalDec, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });



    //                        }

    //                        if(FLG == 0)
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
    //                            {
    //                                decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
    //                            }
    //                            string valuestringAmnt = String.Format(format, decAmnt);

    //                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
    //                            {
    //                                table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            }
    //                            else
    //                            {
    //                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            }

    //                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
    //                            {
    //                                table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            }
    //                            else
    //                            {
    //                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            }

    //                            table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                   
    //                        }
                    
    //                    }
    //                    else
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                        if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
    //                        {
    //                            decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
    //                        }
    //                        string valuestringAmnt = String.Format(format, decAmnt);

    //                        if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        }
    //                        else
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        }

    //                        if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        }
    //                        else
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        }

    //                        table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
                      
    //                    }






    //                }
    //                //FontColour = new BaseColor(216, 49, 61);
    //                decimal decTotal = 0;
    //                if (dt.Rows[0]["JURNL_TOTAL_AMT"].ToString() != "")
    //                {
    //                    decTotal = Convert.ToDecimal(dt.Rows[0]["JURNL_TOTAL_AMT"].ToString());
    //                }
    //                string valuestringTot = String.Format(format, decTotal);

    //                table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
    //                {
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
    //                }
    //                string strcurrenWord = objBusinessLayer.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));
    //              //  FontGray = new BaseColor(0, 174, 239);
    //                //table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE });
    //                //table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE });
    //                table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, Colspan = 8 });

    //                document.Add(table2);
    //            }

    //            if (Version_flg == 2)
    //            {

    //                PdfPTable footrtables = new PdfPTable(2);
    //                float[] footrsBodys = { 15, 85 };
    //                footrtables.SetWidths(footrsBodys);
    //                footrtables.WidthPercentage = 100;

    //                footrtables.AddCell(new PdfPCell(new Phrase("Journal Ref #", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                document.Add(footrtables);




    //                if (dt.Rows[0]["JURNL_DSCRPTN"].ToString().Trim() != "")
    //                {
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                    document.Add(new Paragraph(new Chunk(dt.Rows[0]["JURNL_DSCRPTN"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                }

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


                 

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                //PdfPTable pdfCorprt = new PdfPTable(2);
    //                //float[] CorprtBody = { 100, 0 };
    //                //pdfCorprt.SetWidths(CorprtBody);
    //                //pdfCorprt.WidthPercentage = 100;

    //                //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //document.Add(pdfCorprt);

                   



    //                string CheckedBy = dt.Rows[0]["USR_NAME"].ToString();

    //                PdfPTable table3 = new PdfPTable(3);
    //                float[] tableBody3 = { 33, 33, 33 };
    //                table3.SetWidths(tableBody3);
    //                table3.WidthPercentage = 100;
                   
    //        table3.TotalWidth = 700F;

    //                table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });


    //                if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
    //                {
    //                    table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //                }
    //                else
    //                {
    //                    table3.AddCell(new PdfPCell(new Phrase("     ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                }


    //                //var FontColourPrprd = new BaseColor(33, 150, 243);
    //                //var FontColourChkd = new BaseColor(76, 175, 80);
    //                //var FontColourAuthrsd = new BaseColor(255, 87, 34);
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


    //                table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //                table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //                table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //                table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //                table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //                table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //                //  table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
             
              


    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });

                   

    //                table3.WriteSelectedRows(0,-1, 60, 230, writer.DirectContent);
    //            }


    //            document.Close();
    //        }

           

    //        Response.Write("<script>window.open('" + strImagePath + strImageName + "','_blank');</script>");
    //    }
    //    catch (Exception)
    //    {
    //        document.Close();
    //    }
    //}

    [WebMethod]
    public static string PrintPDF(string Id, string orgID, string corptID, string UsrName, string DecCnt)
    {

        string strId = Id;

        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (corptID != null)
        {
            objEntityLayerStock.Corp_Id = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        }
        if (orgID != null)
        {

            objEntityLayerStock.Org_Id = Convert.ToInt32(orgID);
        }
        objEntityLayerStock.JournalId = Convert.ToInt32(strId);

        DataTable dt = objBusinessLayerStock.ReadJournalDtlsById(objEntityLayerStock);
        DataTable dtLedgrdDebDtl = objBusinessLayerStock.ReadJrnlLedgrDtlsById(objEntityLayerStock);
        DataTable dtCorp = objBusinessLayerStock.ReadCorpDtls(objEntityLayerStock);


        int Version_flg = 0;

        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.JOURNAL);
        DataTable dtVersion = objBusinessLayer.ReadPrintVersion(objEntityCommon);

        string strReturn = "";
        if (dtVersion.Rows.Count > 0)
        {
            if (dtVersion.Rows[0][0].ToString() == "1")
            {
                Version_flg = 1;
                strReturn = objBusinessLayerStock.PdfPrintVersion1(strId, dt, dtLedgrdDebDtl, dtCorp, UsrName, DecCnt, objEntityLayerStock, Version_flg);
            }
            else if (dtVersion.Rows[0][0].ToString() == "2")
            {
                Version_flg = 2;
                strReturn = objBusinessLayerStock.PdfPrintVersion2(strId, dt, dtLedgrdDebDtl, dtCorp, UsrName, DecCnt, objEntityLayerStock, Version_flg);
            }
            else if (dtVersion.Rows[0][0].ToString() == "3")
            {
                Version_flg = 3;
                strReturn = objBusinessLayerStock.PdfPrintVersion2(strId, dt, dtLedgrdDebDtl, dtCorp, UsrName, DecCnt, objEntityLayerStock, Version_flg);
            }
        }

        return strReturn;

    }

    //public string PdfPrintVersion1(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtCorp, string PreparedBy, string DecCnt, clsEntityJournal objEntityLayerStock, int Version_flg)
    //{
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);
    //    string strRet = "";
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);

    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();

    //    objEntityCommon.CorporateID = objEntityLayerStock.Corp_Id;
    //    objEntityCommon.Organisation_Id = objEntityLayerStock.Org_Id;

    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL_PRINT);
    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Journal" + Id + "_" + strNextNumber + ".pdf";


    //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {
    //        int precision = Convert.ToInt32(DecCnt);
    //        string format = String.Format("{{0:N{0}}}", precision);


    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {
    //            FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
    //            PdfWriter writer = PdfWriter.GetInstance(document, file);
    //            document.Open();
    //            PdfPTable headImg = new PdfPTable(2);

    //            string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
    //            if (dtCorp.Rows.Count > 0)
    //            {
    //                if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
    //                    strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + dtCorp.Rows[0]["CORPRT_ICON"].ToString();

    //            }

    //            if (strImageLogo != "")
    //            {
    //                iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
    //                image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //                image.ScaleToFit(100f, 80f);

    //                headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
    //            }
    //            else
    //            {
    //                headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
    //            }
    //            var FontColour = new BaseColor(79, 167, 206);

    //            if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
    //            {
    //                headImg.AddCell(new PdfPCell(new Phrase("JOURNAL", FontFactory.GetFont("Arial", 16, Font.BOLD, FontColour))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });

    //            }
    //            else
    //            {
    //                headImg.AddCell(new PdfPCell(new Phrase("DRAFT JOURNAL", FontFactory.GetFont("Arial", 16, Font.BOLD, FontColour))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });

    //            }
    //            float[] headersHeading = { 60, 40 };
    //            headImg.SetWidths(headersHeading);
    //            headImg.WidthPercentage = 100;

    //            document.Add(headImg);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;
    //            FontColour = new BaseColor(0, 174, 239);
    //            footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            //if (dtCorp.Rows.Count > 0)
    //            //{
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //}


    //            if (dtCorp.Rows.Count > 0)
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            }
    //            document.Add(footrtable);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            PdfPTable footrtables = new PdfPTable(2);
    //            float[] footrsBodys = { 15, 85 };
    //            footrtables.SetWidths(footrsBodys);
    //            footrtables.WidthPercentage = 100;

    //            footrtables.AddCell(new PdfPCell(new Phrase("Journal Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            document.Add(footrtables);

    //            if (dtLedgrdDebDtl.Rows.Count > 0)
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                var FontGray = new BaseColor(138, 138, 138);

    //                PdfPTable table2 = new PdfPTable(4);
    //                float[] tableBody2 = { 40, 20, 20, 20 };
    //                table2.SetWidths(tableBody2);
    //                table2.WidthPercentage = 100;

    //                FontColour = new BaseColor(134, 152, 160);
    //                table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("DEBIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("CREDIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontColour, BorderColor = FontGray });


    //                var FontColour_BORDER = new BaseColor(236, 236, 236);
    //                for (int intRowBodyCount = 0; intRowBodyCount < dtLedgrdDebDtl.Rows.Count; intRowBodyCount++)
    //                {
    //                    decimal decAmnt = 0;
    //                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
    //                    {
    //                        decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
    //                    }
    //                    string valuestringAmnt = String.Format(format, decAmnt);

    //                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    else
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    else
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                }
    //                FontColour = new BaseColor(216, 49, 61);
    //                decimal decTotal = 0;
    //                if (dt.Rows[0]["JURNL_TOTAL_AMT"].ToString() != "")
    //                {
    //                    decTotal = Convert.ToDecimal(dt.Rows[0]["JURNL_TOTAL_AMT"].ToString());
    //                }
    //                string valuestringTot = String.Format(format, decTotal);

    //                table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
    //                {
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
    //                }
    //                string strcurrenWord = objBusinessLayer.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));
    //                FontColour = new BaseColor(0, 174, 239);
    //                //table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE });
    //                //table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE });
    //                table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE, Colspan = 4 });

    //                document.Add(table2);
    //            }

    //            if (dt.Rows[0]["JURNL_DSCRPTN"].ToString().Trim() != "")
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                document.Add(new Paragraph(new Chunk(dt.Rows[0]["JURNL_DSCRPTN"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //            }

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            string CheckedBy = dt.Rows[0]["USR_NAME"].ToString();

    //            PdfPTable table3 = new PdfPTable(3);
    //            float[] tableBody3 = { 33, 33, 33 };
    //            table3.SetWidths(tableBody3);
    //            table3.WidthPercentage = 100;
    //            table3.TotalWidth = 600F;

    //            table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });


    //            if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
    //            {
    //                table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //            }
    //            else
    //            {
    //                table3.AddCell(new PdfPCell(new Phrase("     ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //            }


    //            var FontColourPrprd = new BaseColor(33, 150, 243);
    //            var FontColourChkd = new BaseColor(76, 175, 80);
    //            var FontColourAuthrsd = new BaseColor(255, 87, 34);


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
    //        }

    //        //    Response.Write("<script>window.open('" + strImagePath + strImageName + "','_blank');</script>");
    //        strRet = strImagePath + strImageName;
    //    }
    //    catch (Exception)
    //    {
    //        document.Close();
    //    }

    //    return strRet;


    //}
    //public string PdfPrintVersion2(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtCorp, string PreparedBy, string DecCnt, clsEntityJournal objEntityLayerStock, int Version_flg)
    //{
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);
    //    clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();
    //    string strRet = "";
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.JOURNAL_VOUCHER);

    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();

    //    objEntityCommon.CorporateID = objEntityLayerStock.Corp_Id;
    //    objEntityCommon.Organisation_Id = objEntityLayerStock.Org_Id;

    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL_PRINT);
    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Journal" + Id + "_" + strNextNumber + ".pdf";
    //    DataTable dtBankDtls = objBusinessLayer.ReadBankDetails(objEntityCommon);


    //    Document document = new Document(PageSize.A4.Rotate(), 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {
    //        int precision = Convert.ToInt32(DecCnt);
    //        string format = String.Format("{{0:N{0}}}", precision);

    //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
    //        {
    //            System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(strImagePath));

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

    //            if (Version_flg == 2)
    //            {
    //                PdfPTable headImg = new PdfPTable(2);

    //                if (strImageLogo != "")
    //                {


    //                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));

    //                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
    //                    image.ScaleToFit(100f, 80f);

    //                    headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });


    //                }
    //                else
    //                {
    //                    headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
    //                }

    //                headImg.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 16, Font.BOLD))) { Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_LEFT });

    //                var FontGrey = new BaseColor(134, 152, 160);

    //                float[] headersHeading = { 70, 30 };
    //                headImg.SetWidths(headersHeading);
    //                headImg.WidthPercentage = 100;

    //                document.Add(headImg);

    //            }

    //            else
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            }


    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;

    //            if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase("JOURNAL", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_LEFT });
    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            }
    //            else
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase("DRAFT JOURNAL", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_LEFT });
    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            }
    //            // footrtable.AddCell(new PdfPCell(new Phrase("INVOICE", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 15 });
    //            // footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("Date : " + dt.Rows[0]["JURNL_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            //footrtable.AddCell(new PdfPCell(new Phrase("To", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 20 });

    //            //footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            //if (dtCorp.Rows.Count > 0)
    //            //{
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //}


    //            //if (dtCorp.Rows.Count > 0)
    //            //{
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //}
    //            document.Add(footrtable);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            //PdfPTable footrtables = new PdfPTable(2);
    //            //float[] footrsBodys = { 15, 85 };
    //            //footrtables.SetWidths(footrsBodys);
    //            //footrtables.WidthPercentage = 100;

    //            //footrtables.AddCell(new PdfPCell(new Phrase("Journal Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColour))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            //document.Add(footrtables);
    //            var FontRed = new BaseColor(202, 3, 20);
    //            var FontGreen = new BaseColor(46, 179, 51);
    //            var FontGray = new BaseColor(138, 138, 138);

    //            if (dtLedgrdDebDtl.Rows.Count > 0)
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                // var FontGray = new BaseColor(138, 138, 138);

    //                PdfPTable table2 = new PdfPTable(8);
    //                float[] tableBody2 = { 18, 12, 12, 13, 12, 12, 12, 14 };
    //                table2.SetWidths(tableBody2);
    //                table2.WidthPercentage = 100;
    //                var FontColour = new BaseColor(134, 152, 160);

    //                table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("DEBIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("CREDIT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("COST-G1", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("COST-G2", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("COST CENTRE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });
    //                table2.AddCell(new PdfPCell(new Phrase("CC AMT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BorderColor = FontGray, BackgroundColor = FontColour });


    //                var FontColour_BORDER = new BaseColor(236, 236, 236);
    //                int FLG = 0;
    //                int cstcntrSts = 0;
    //                for (int intRowBodyCount = 0; intRowBodyCount < dtLedgrdDebDtl.Rows.Count; intRowBodyCount++)
    //                {
    //                    decimal decAmnt = 0;
    //                    DataTable dtCostCntrDebDtl = new DataTable();

    //                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_ID"].ToString() != "")
    //                    {
    //                        objEntityLayerStock.JournalId = Convert.ToInt32(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_ID"].ToString());
    //                        dtCostCntrDebDtl = objBusinessLayerStock.ReadJrnlCostCntrDtlsById(objEntityLayerStock);

    //                    }

    //                    if (dtCostCntrDebDtl.Rows.Count > 0)
    //                    {




    //                        FLG = 0;

    //                        decimal CstAmmount = 0;
    //                        for (int j = 0; j < dtCostCntrDebDtl.Rows.Count; j++)
    //                        {

    //                            decimal costAmnt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT"].ToString());
    //                            string valuestringCost = String.Format(format, costAmnt);


    //                            if (dtCostCntrDebDtl.Rows[j]["COSTCNTR_ID"].ToString() != "")
    //                            {
    //                                string costGrp1 = dtCostCntrDebDtl.Rows[j]["COSTCNTR_NAME"].ToString();
    //                                string costGrp2 = dtCostCntrDebDtl.Rows[j]["GRP_NAME_ONE"].ToString();
    //                                string costCntr = dtCostCntrDebDtl.Rows[j]["GRP_NAME_TWO"].ToString();
    //                                // string CCAmount = dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString();
    //                                decimal DecCstAmt = 0;
    //                                if (dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString() != "")
    //                                {
    //                                    DecCstAmt = Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString());
    //                                }
    //                                string valuestringCstAmnt = String.Format(format, DecCstAmt);


    //                                CstAmmount = CstAmmount + Convert.ToDecimal(dtCostCntrDebDtl.Rows[j]["CST_JURNL_AMT_DEC"].ToString());



    //                                if (FLG == 0)
    //                                {
    //                                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
    //                                    {
    //                                        decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
    //                                    }
    //                                    string valuestringAmnt = String.Format(format, decAmnt);

    //                                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    }
    //                                    else
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    }

    //                                    if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    }
    //                                    else
    //                                    {
    //                                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    }

    //                                    table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                                }
    //                                else
    //                                {
    //                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                                    table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                                }
    //                                table2.AddCell(new PdfPCell(new Phrase(costGrp1, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                table2.AddCell(new PdfPCell(new Phrase(costGrp2, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                table2.AddCell(new PdfPCell(new Phrase(costCntr, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                                table2.AddCell(new PdfPCell(new Phrase(valuestringCstAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                                FLG = 1;
    //                            }
    //                            else
    //                            {
    //                                cstcntrSts = 1;
    //                            }


    //                        }

    //                        if (FLG == 1)
    //                        {
    //                            if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
    //                            {
    //                                objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
    //                            }
    //                            // string strcurrenWord1 = objBusinessLayer.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(CstAmmount));
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });

    //                            table2.AddCell(new PdfPCell(new Phrase("CC-TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, Colspan = 3 });


    //                            string CstCntrTotalDec = String.Format(format, CstAmmount);


    //                            table2.AddCell(new PdfPCell(new Phrase(CstCntrTotalDec, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, });



    //                        }

    //                        if (FLG == 0)
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
    //                            {
    //                                decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
    //                            }
    //                            string valuestringAmnt = String.Format(format, decAmnt);

    //                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
    //                            {
    //                                table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            }
    //                            else
    //                            {
    //                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            }

    //                            if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
    //                            {
    //                                table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            }
    //                            else
    //                            {
    //                                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            }

    //                            table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                        }

    //                    }
    //                    else
    //                    {
    //                        table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                        if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString() != "")
    //                        {
    //                            decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_AMT"].ToString());
    //                        }
    //                        string valuestringAmnt = String.Format(format, decAmnt);

    //                        if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "0")
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        }
    //                        else
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        }

    //                        if (dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_STS"].ToString() == "1")
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        }
    //                        else
    //                        {
    //                            table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        }

    //                        table2.AddCell(new PdfPCell(new Phrase(dtLedgrdDebDtl.Rows[intRowBodyCount]["LD_JURNL_REMARK"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                    }






    //                }
    //                //FontColour = new BaseColor(216, 49, 61);
    //                decimal decTotal = 0;
    //                if (dt.Rows[0]["JURNL_TOTAL_AMT"].ToString() != "")
    //                {
    //                    decTotal = Convert.ToDecimal(dt.Rows[0]["JURNL_TOTAL_AMT"].ToString());
    //                }
    //                string valuestringTot = String.Format(format, decTotal);

    //                table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
    //                {
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
    //                }
    //                string strcurrenWord = objBusinessLayer.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));
    //                //  FontGray = new BaseColor(0, 174, 239);
    //                //table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE });
    //                //table2.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontColour, BorderColor = iTextSharp.text.BaseColor.WHITE });
    //                table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BorderColor = FontGray, Colspan = 8 });

    //                document.Add(table2);
    //            }

    //            if (Version_flg == 2)
    //            {

    //                PdfPTable footrtables = new PdfPTable(2);
    //                float[] footrsBodys = { 15, 85 };
    //                footrtables.SetWidths(footrsBodys);
    //                footrtables.WidthPercentage = 100;

    //                footrtables.AddCell(new PdfPCell(new Phrase("Journal Ref #", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontGray))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["JURNL_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                document.Add(footrtables);




    //                if (dt.Rows[0]["JURNL_DSCRPTN"].ToString().Trim() != "")
    //                {
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                    document.Add(new Paragraph(new Chunk(dt.Rows[0]["JURNL_DSCRPTN"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                }

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


    //                var phrase2 = new Phrase();
    //                var phrase5 = new Phrase();
    //                var FontBlack = new BaseColor(8, 7, 7);




    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                //PdfPTable pdfCorprt = new PdfPTable(2);
    //                //float[] CorprtBody = { 100, 0 };
    //                //pdfCorprt.SetWidths(CorprtBody);
    //                //pdfCorprt.WidthPercentage = 100;

    //                //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //pdfCorprt.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //                //document.Add(pdfCorprt);

    //                string CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
    //                PdfPTable table3 = new PdfPTable(3);
    //                float[] tableBody3 = { 33, 33, 33 };
    //                table3.SetWidths(tableBody3);
    //                table3.WidthPercentage = 100;

    //                table3.TotalWidth = 700F;

    //                table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });


    //                if (dt.Rows[0]["JURNL_CNFRM_STS"].ToString() == "1")
    //                {
    //                    table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //                }
    //                else
    //                {
    //                    table3.AddCell(new PdfPCell(new Phrase("     ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                }


    //                //var FontColourPrprd = new BaseColor(33, 150, 243);
    //                //var FontColourChkd = new BaseColor(76, 175, 80);
    //                //var FontColourAuthrsd = new BaseColor(255, 87, 34);
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


    //                table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //                table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //                table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //                table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //                table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
    //                table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 3 });
    //                //  table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table3.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, PaddingLeft = 50, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });




    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
    //                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });



    //                table3.WriteSelectedRows(0, -1, 60, 230, writer.DirectContent);
    //            }


    //            document.Close();
    //        }


    //        strRet = strImagePath + strImageName;
    //    }
    //    catch (Exception)
    //    {
    //        document.Close();
    //    }

    //    return strRet;
    //}

    [WebMethod]
    public static string CheckSaleSettlement(string strSalePurchaseDtls, string strOrgIdID, string strCorpID, string strCrdtDbt)
    {
        //EVM-0020
        string ret = "successConfirm";

        clsEntityJournal objEntityLayerStock = new clsEntityJournal();
        clsBusinessJournal objBusinessLayerStock = new clsBusinessJournal();

        List<clsEntityJournalLedgerDtl> objEntityJrnlLedgrList = new List<clsEntityJournalLedgerDtl>();
        List<clsEntityJournalCostCntrDtl> objEntityJrnlCostcentrList = new List<clsEntityJournalCostCntrDtl>();

        decimal decSalesRemainAmt = 0;
        decimal decPrchsRemainAmt = 0;

        string SalePurchaseDtl = strSalePurchaseDtls;
        if (SalePurchaseDtl != "" && SalePurchaseDtl != "null" && SalePurchaseDtl != null)
        {
            string[] values = SalePurchaseDtl.Split('$');
            for (int i = 0; i < values.Length; i++)
            {
                clsEntityJournalCostCntrDtl objEntityDtl = new clsEntityJournalCostCntrDtl();

                objEntityLayerStock.Org_Id = Convert.ToInt32(strOrgIdID);
                objEntityLayerStock.Corp_Id = Convert.ToInt32(strCorpID);
                if (values[i] != "")
                {
                    string[] valSplit = values[i].Split('%');
                    objEntityDtl.CostCenterId = Convert.ToInt32(valSplit[0]);

                    valSplit[1] = valSplit[1].Replace(",", "");
                    objEntityDtl.CostCntrAmnt = Convert.ToDecimal(valSplit[1]);
                    objEntityDtl.SettlmntAmmnt = Convert.ToDecimal(valSplit[2]);

                    if (strCrdtDbt == "SAL")
                    {
                        DataTable dtSalesBalance = objBusinessLayerStock.ReadPurchaseBalance(objEntityLayerStock, objEntityDtl);
                        if (dtSalesBalance.Rows.Count > 0)
                        {
                            if (dtSalesBalance.Rows[0][1].ToString() != "")
                                decPrchsRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                        }

                        if (decPrchsRemainAmt != 0)
                        {
                            if (decPrchsRemainAmt < objEntityDtl.CostCntrAmnt)
                            {
                                ret = "PrchsAmountExceeded";
                                break;
                            }
                        }
                        else
                        {
                            ret = "PrchsAmtFullySettld";
                        }

                    }
                    else if (strCrdtDbt == "PURCH")
                    {
                        DataTable dtSalesBalance = objBusinessLayerStock.ReadSalesBalance(objEntityLayerStock, objEntityDtl);
                        if (dtSalesBalance.Rows.Count > 0)
                        {
                            if (dtSalesBalance.Rows[0][1].ToString() != "")
                                decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                        }

                        if (decSalesRemainAmt != 0)
                        {
                            if (decSalesRemainAmt < objEntityDtl.CostCntrAmnt)
                            {
                                ret = "SalesAmountExceeded";
                                break;
                            }
                        }
                        else
                        {
                            ret = "SalesAmtFullySettld";
                        }

                    }


                }
            }

        }

        return ret;
    }





}