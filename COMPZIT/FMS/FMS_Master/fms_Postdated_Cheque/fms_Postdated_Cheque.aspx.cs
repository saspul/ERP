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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;
public partial class FMS_FMS_Master_fms_Postdated_Cheque_fms_Postdated_Cheque : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            ddlInvoice.Items.Insert(0, "--SELECT--");
            LoadExpIncmLdgrs();

            hiddenEndYrClose.Value = "0";

            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();
            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
            clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
            clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();

            DateTime dtToday = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
            HiddenToday.Value = dtToday.AddDays(1).ToString("dd-MM-yyyy");
            LoadAccountHeadLedger();

            btnReopen.Visible = false;
            btnFloatReopen.Visible = false;
            btnUpdate.Visible = false;
            btnUpdateClose.Visible = false;
            btnFloatUpdate.Visible = false;
            btnFloatUpdateCls.Visible = false;
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["FINCYRID"] != null)
            {
                objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
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
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            int intUsrRolMstrId = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.FMS_POSTDATED_CHEQUE);
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                              clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS,
                                                              clsCommonLibrary.CORP_GLOBAL.GN_REMOVE_RESTRCTNS_STS
                                                       };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                HiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                HiddenCurrencyId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                HiddenRefAccountCls.Value = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
                HiddenRestritionStatus.Value = dtCorpDetail.Rows[0]["GN_REMOVE_RESTRCTNS_STS"].ToString();
            }
            objEntityCommon.CurrencyId = Convert.ToInt32(HiddenCurrencyId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                HiddenCurrencyAbrv.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
                lblCurrency.InnerHtml = HiddenCurrencyAbrv.Value;

            }

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_POSTDATED_CHEQUE);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);
            DataTable dtFormate = objBusiness_Cheque.ReadRefFormate(objEntityCommon);
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
                    strRealFormat = strRealFormat.Replace("*", "");
                    strRealFormat = strRealFormat.Replace("%", "");
                }
                TxtRef.Value = strRealFormat;
            }
            else
            {
                TxtRef.Value = strNextId;
            }


            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.FMS_POSTDATED_CHEQUE);
            int confirm = 0, intAccntCloseReopen = 0;
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenReOpenStatus.Value = "0";
            HiddenFieldAcntCloseReopenSts.Value = "0";
            HiddenAuditProvisionStatus.Value = "0";
            HiddenConfirmProvisionStatus.Value = "0";

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
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString())
                    {
                        HiddenFieldChequePrint.Value = "1";
                    }
                }
            }

            //if (ddlTranscationType.SelectedItem.Value == "0")
            //{
            //    intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.PAYMENT_ACCOUNT);
            //    int confirm = 0, intAccntCloseReopen = 0;
            //    DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            //    HiddenReOpenStatus.Value = "0";
            //    HiddenFieldAcntCloseReopenSts.Value = "0";
            //    HiddenAuditProvisionStatus.Value = "0";
            //    HiddenConfirmProvisionStatus.Value = "0";
            //    if (dtChildRol.Rows.Count > 0)
            //    {
            //        string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            //        string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            //        foreach (string strC_Role in strChildDefArrWords)
            //        {
            //            if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
            //            {
            //                confirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
            //                HiddenConfirmProvisionStatus.Value = "1";
            //            }
            //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
            //            {
            //                intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
            //                HiddenFieldAcntCloseReopenSts.Value = "1";
            //            }
            //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
            //            {
            //                HiddenReOpenStatus.Value = "1";
            //            }
            //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
            //            {
            //                HiddenAuditProvisionStatus.Value = "1";
            //            }
            //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString())
            //            {
            //                HiddenFieldChequePrint.Value = "1";
            //            }
            //        }
            //    }
            //}
            //else if (ddlTranscationType.SelectedItem.Value == "1")
            //{
            //    intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Receipt);
            //    int confirm = 0, intAccntCloseReopen = 0;
            //    DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            //    HiddenReOpenStatus.Value = "0";
            //    HiddenFieldAcntCloseReopenSts.Value = "0";
            //    HiddenAuditProvisionStatus.Value = "0";
            //    HiddenConfirmProvisionStatus.Value = "0";
            //    if (dtChildRol.Rows.Count > 0)
            //    {
            //        string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

            //        string[] strChildDefArrWords = strChildRolDeftn.Split('-');
            //        foreach (string strC_Role in strChildDefArrWords)
            //        {
            //            if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
            //            {
            //                confirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
            //                HiddenConfirmProvisionStatus.Value = "1";
            //            }
            //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
            //            {
            //                intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
            //                HiddenFieldAcntCloseReopenSts.Value = "1";
            //            }
            //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
            //            {
            //                HiddenReOpenStatus.Value = "1";
            //            }
            //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
            //            {
            //                HiddenAuditProvisionStatus.Value = "1";
            //            }
            //            else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cheque_Print).ToString())
            //            {
            //                HiddenFieldChequePrint.Value = "1";
            //            }
            //        }
            //    }
            //}

            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
            DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objEntityCommon);
            DataTable dtAuditClsDate = objBusinessLayer.ReadLastAuditClose(objEntityCommon);

            int YearEndCls = 0;

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
                    YearEndCls = Convert.ToInt32(dtAcntClsDate.Rows[0]["ACCNT_CLS_YEAREND_STS"].ToString());

                    if (YearEndCls == 1)
                    {
                        hiddenEndYrClose.Value = "1";
                    }


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
                                    clsEntity_Postdated_Cheque objEntity = new clsEntity_Postdated_Cheque();
                                    clsBusinessPostdated_Cheque objBussinesschk = new clsBusinessPostdated_Cheque();
                                    objEntity.PostdatedChequeDate = objCommon.textToDateTime(txtdate.Value);
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
                                        DataTable dtRefFormat = objBussinesschk.ReadRefNumberByDate(objEntity);
                                        DataTable dtRefFormat1 = objBussinesschk.ReadRefNumberByDate(objEntity);
                                        string strRef = "";

                                        if (dtRefFormat1.Rows.Count > 0)
                                        {
                                            if (dtRefFormat1.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != "")
                                            {
                                                if (dtRefFormat1.Rows.Count > 0)
                                                {
                                                    if (Convert.ToInt32(dtRefFormat1.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString()) != 1)
                                                    {
                                                        strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();
                                                        strRef = strRef.TrimEnd('/');
                                                        strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                                    }
                                                    else
                                                    {
                                                        strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();
                                                    }
                                                }
                                                else
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();
                                                }
                                            }
                                            objEntity.RefNumber = strRef;
                                            if (dtRefFormat.Rows.Count > 0)
                                            {
                                                Ref = dtRefFormat.Rows[0]["PST_CHEQUE_REF"].ToString();
                                                if (dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != null)
                                                {
                                                    SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString());
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
                                clsEntity_Postdated_Cheque objEntity = new clsEntity_Postdated_Cheque();
                                clsBusinessPostdated_Cheque objBussinesschk = new clsBusinessPostdated_Cheque();
                                objEntity.PostdatedChequeDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAudit.Corporate_id = intCorpId;
                                objEntity.Corporate_id = intCorpId;
                                objEntityAudit.Organisation_id = intOrgId;
                                objEntity.Organisation_id = intOrgId;
                                int SubRef = 1;
                                DataTable dtAccntCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);
                                if (dtAccntCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat = objBussinesschk.ReadRefNumberByDate(objEntity);
                                    DataTable dtRefFormat1 = objBussinesschk.ReadRefNumberByDate(objEntity);
                                    string strRef = "";

                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        if (dtRefFormat1.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != "")
                                        {
                                            if (dtRefFormat1.Rows.Count > 0)
                                            {
                                                if (Convert.ToInt32(dtRefFormat1.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString()) != 1)
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();
                                                    strRef = strRef.TrimEnd('/');
                                                    strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                                }
                                                else
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();
                                                }
                                            }
                                            else
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();
                                            }
                                        }
                                        objEntity.RefNumber = strRef;
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["PST_CHEQUE_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString());
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
                    YearEndCls = Convert.ToInt32(dtAcntClsDate.Rows[0]["ACCNT_CLS_YEAREND_STS"].ToString());
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

                                clsEntity_Postdated_Cheque objEntity = new clsEntity_Postdated_Cheque();
                                clsBusinessPostdated_Cheque objBussinesschk = new clsBusinessPostdated_Cheque();
                                objEntity.PostdatedChequeDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntity.Corporate_id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntity.Organisation_id = intOrgId;
                                int SubRef = 1;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                if (dtAccntCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat = objBussinesschk.ReadRefNumberByDate(objEntity);
                                    DataTable dtRefFormat1 = objBussinesschk.ReadRefNumberByDate(objEntity);
                                    string strRef = "";

                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        if (dtRefFormat1.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != "")
                                        {
                                            if (dtRefFormat1.Rows.Count > 0)
                                            {
                                                if (Convert.ToInt32(dtRefFormat1.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString()) != 1)
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();
                                                    strRef = strRef.TrimEnd('/');
                                                    strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                                }
                                                else
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();
                                                }
                                            }
                                            else
                                            {
                                                strRef = dtRefFormat1.Rows[0]["PST_CHEQUE_REF"].ToString();
                                            }
                                        }
                                        objEntity.RefNumber = strRef;
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["PST_CHEQUE_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PST_CHEQUE_REF_NXT_SUBNUM"].ToString());
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

            lblEntry.Text = "Add Postdated Cheque";
            btnConfirm.Visible = false;
            btnFloatConfirm.Visible = false;
            btnPRint.Visible = false;
            btnFloatPrint.Visible = false;

            if (Request.QueryString["Id"] != null)
            {

                lblEntry.Text = "Edit Postdated Cheque";
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                //HiddenFieldTaxId.Value = strId;
                btnsave.Visible = false;
                btnSaveCls.Visible = false;
                btnUpdateClose.Visible = true;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;
                ButtnFloatClear.Visible = false;
                ButtnClose.Visible = false;

                btnsave.Visible = false;
                btnFloatSave.Visible = false;
                btnFloatSaveCls.Visible = false;
                btnFloatUpdateCls.Visible = true;
                btnFloatUpdate.Visible = true;
                btnFloatCancel.Visible = true;

                btnPRint.Visible = true;
                btnFloatPrint.Visible = true;

                Update(strId, "UPDATE");
                ddlTranscationType.Enabled = false;
                ddlMethod.Enabled = false;
            }
            else if (Request.QueryString["ViewId"] != null)
            {

                HiddenView.Value = "1";
                lblEntry.Text = "View Postdated Cheque";
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                // HiddenFieldTaxId.Value = strId;
                btnsave.Visible = false;
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
                btnPRint.Visible = true;
                btnFloatPrint.Visible = true;

                Update(strId, "VIEW");
                txtDescription.Disabled = true;
                ddlAccontLed.Enabled = false;
                ddlTranscationType.Enabled = false;
                ddlMethod.Enabled = false;
            }
            else
            {
                LoadSupplierLedger();
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
                btnFloat.Visible = false;
                hiddenModalView.Value = "1";
                btnPRint.Visible = true;
                btnFloatPrint.Visible = true;
            }


            //---Clearance Ledger---
            clsEntity_Account_Setting ObjEntityRequest = new clsEntity_Account_Setting();
            clsBusiness_Account_Setting objBussiness = new clsBusiness_Account_Setting();

            ObjEntityRequest.OrgId = objEntityCommon.Organisation_Id;
            ObjEntityRequest.CorpId = objEntityCommon.CorporateID;
            if (ddlTranscationType.SelectedItem.Value == "0")
            {
                ObjEntityRequest.AsmodId = 7;
            }
            else if (ddlTranscationType.SelectedItem.Value == "1")
            {
                ObjEntityRequest.AsmodId = 8;
            }
            ObjEntityRequest.LdgrGrpSts = 1;

            DataTable dt = objBussiness.ReadSelectedGrpOrLdgrLedger(ObjEntityRequest);
            if (dt.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ClearanceLedgerSelect", "ClearanceLedgerSelect();", true);
            }
            else
            {
                hiddenClearanceLedger.Value = dt.Rows[0]["LDGR_ID"].ToString();
            }
            //---Clearance Ledger---


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
                else if (strInsUpd == "Confrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "alrdyreopened")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Alreadyconfrm", "Alreadyconfrm();", true);
                }
                else if (strInsUpd == "ChqDup")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "ChequeNoDuplicate", "ChequeNoDuplicate();", true);
                }

            }

        }
    }

    public void LoadAccountHeadLedger()
    {
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessCommon = new clsBusinessLayer();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.BANK));
        DataTable dtAccountGrp = objBusinessCommon.ReadLedgers(objEntityCommon);
        if (dtAccountGrp.Rows.Count > 0)
        {
            ddlAccontLed.DataSource = dtAccountGrp;
            ddlAccontLed.DataTextField = "LDGR_NAME";
            ddlAccontLed.DataValueField = "LDGR_ID";
            ddlAccontLed.DataBind();

        }
        ddlAccontLed.Items.Insert(0, "--SELECT--");
    }
    public void LoadSupplierLedger()
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
            if (dtLedger.Rows.Count > 0)
            {
                ddlSupplier.DataSource = dtLedger;
                ddlSupplier.DataTextField = "LDGR_NAME";
                ddlSupplier.DataValueField = "LDGR_ID";
                ddlSupplier.DataBind();

            }
            ddlSupplier.Items.Insert(0, "--SELECT--");
        }

        
        clsEntity_Receipt_Account ObjEntityRequest1 = new clsEntity_Receipt_Account();
        clsBusinessLayer_Receipt_Account objBussiness1 = new clsBusinessLayer_Receipt_Account();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest1.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityRequest1.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityRequest1.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtLedger1 = objBussiness1.ReadLeadgerReceipt(ObjEntityRequest1);
        if (dtLedger1.Rows.Count > 0)
        {
            if (dtLedger1.Rows.Count > 0)
            {
                ddlSupplier1.DataSource = dtLedger1;
                ddlSupplier1.DataTextField = "LDGR_NAME";
                ddlSupplier1.DataValueField = "LDGR_ID";
                ddlSupplier1.DataBind();

            }
            ddlSupplier1.Items.Insert(0, "--SELECT--");
        }
       
    }

    [WebMethod]
    public static string ChequeBookLoad(string intLedgerId, string intorgid, string intcorpid)
    {
        string result = "";
        if (intLedgerId != "0")
        {
            clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
            clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
            objEntity_Cheque.LedgerId = Convert.ToInt32(intLedgerId);
            objEntity_Cheque.Corporate_id = Convert.ToInt32(intcorpid);
            DataTable dtChequeBook = objBusiness_Cheque.ReadChequeBooks(objEntity_Cheque);
            if (dtChequeBook.Rows.Count > 0)
            {
                dtChequeBook.TableName = "dtTableChequeBook";
                using (StringWriter sw = new StringWriter())
                {
                    dtChequeBook.WriteXml(sw);
                    result = sw.ToString();
                }
            }
        }
        return result;
    }

     [WebMethod]
    public static string CheckDupBankAcNum(string RcptBankCurr, string RcptAcntNumCurr, string UpdateId)
    {
        string result = "";
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        objEntity_Cheque.Bank = RcptBankCurr;
        objEntity_Cheque.CancelReason = RcptAcntNumCurr;
        objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(UpdateId);
        DataTable dtChequeBook = objBusiness_Cheque.CheckDupBankAcNum(objEntity_Cheque);
        if (dtChequeBook.Rows.Count > 0)
        {
            result = "false";
        }
        return result;
    }

    [WebMethod]
    public static string LoadChequeBookNumber(string ChequeBook, string status, string CorpId, string OrgId, string BankId, string EditId)
    {
        string result = "";
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        if (ChequeBook != "" && ChequeBook != "--SELECT--")
        {
            objEntity_Cheque.Organisation_id = Convert.ToInt32(OrgId);
            objEntity_Cheque.Corporate_id = Convert.ToInt32(CorpId);
            objEntity_Cheque.LedgerId = Convert.ToInt32(BankId);
            objEntity_Cheque.ChequeBookId = Convert.ToInt32(ChequeBook);
            if (EditId != "")
            {
                objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(EditId);
            }

            DataTable dtChqNumber = objBusiness_Cheque.ReadChqNoByChqbkId(objEntity_Cheque);

            DataTable dtChqCancel = objBusiness_Cheque.ReadChequeBook_CancelIds(objEntity_Cheque);

            dtChqNumber.TableName = "dtTableACIPackage";
            string strTotalChqNos = "";
            string strCancelIds = "";

            if (dtChqCancel.Rows.Count > 0)
            {
                strCancelIds = dtChqCancel.Rows[0]["CHKBK_CNCL_NUM"].ToString().TrimEnd(',', ' ');
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
    
    public class clsChequeDetails
    {
        public string ROWID { get; set; }
        public string CHEQUEBOOK { get; set; }
        public string CHEQUEBOOKNO { get; set; }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_Cheque.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity_Cheque.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntity_Cheque.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        objEntity_Cheque.TransactionType = Convert.ToInt32(ddlTranscationType.SelectedValue);
        objEntity_Cheque.RefNumber = TxtRef.Value;
        if (ddlAccontLed.SelectedValue != "0" && ddlAccontLed.SelectedValue != "--SELECT--")
            objEntity_Cheque.LedgerId = Convert.ToInt32(ddlAccontLed.SelectedValue);

        if (objEntity_Cheque.TransactionType == 0)
        {
            if (ddlSupplier.SelectedValue != "0" && ddlSupplier.SelectedValue != "--SELECT--")
                objEntity_Cheque.PartId = Convert.ToInt32(ddlSupplier.SelectedValue);
        }
        else
        {
            if (ddlSupplier1.SelectedValue != "0" && ddlSupplier1.SelectedValue != "--SELECT--")
                objEntity_Cheque.PartId = Convert.ToInt32(ddlSupplier1.SelectedValue);
        }
        if (txtdate.Value != "")
            objEntity_Cheque.PostdatedChequeDate = objCommon.textToDateTime(txtdate.Value);
        if (txtPayee.Value != "")
            objEntity_Cheque.Payee = txtPayee.Value;
        if (HiddenCurrencyId.Value != "")
            objEntity_Cheque.CurrencyId = Convert.ToInt32(HiddenCurrencyId.Value);
        if (txtGrantTotal.Value != "")
            objEntity_Cheque.TotalAmount = Convert.ToDecimal(txtGrantTotal.Value);
         if(objEntity_Cheque.TransactionType==0){ 
            if (ChkStatus_Cheque.Checked)
            {
            objEntity_Cheque.IssueStatus = 1;
            objEntity_Cheque.ChequeIssueDate = objCommon.textToDateTime(txtIssueDate_Cheque.Value);
            }
            else
            {
            objEntity_Cheque.IssueStatus = 0;
            }
         }
        objEntity_Cheque.Description = txtDescription.Value;

        objEntity_Cheque.Method = Convert.ToInt32(ddlMethod.SelectedItem.Value);

        if (objEntity_Cheque.Method == 1)
        {
            if (hiddenInvoiceId.Value != "")
            {
                if (objEntity_Cheque.TransactionType == 0)
                {
                    objEntity_Cheque.PurchaseId = Convert.ToInt32(hiddenInvoiceId.Value);
                }
                else if (objEntity_Cheque.TransactionType == 1)
                {
                    objEntity_Cheque.SalesId = Convert.ToInt32(hiddenInvoiceId.Value);
                }
            }
        }
        if (objEntity_Cheque.Method == 2)
        {
            if (objEntity_Cheque.Method == 2)
            {
                if (objEntity_Cheque.TransactionType == 0)
                {
                    if (ddlExp.SelectedItem.Value != "--SELECT--")
                    {
                        objEntity_Cheque.ExpIncmLedgerId = Convert.ToInt32(ddlExp.SelectedItem.Value);
                    }
                }
                else if (objEntity_Cheque.TransactionType == 1)
                {
                    if (ddlIncm.SelectedItem.Value != "--SELECT--")
                    {
                        objEntity_Cheque.ExpIncmLedgerId = Convert.ToInt32(ddlIncm.SelectedItem.Value);
                    }
                }
            }
        }
        if (hiddenClearanceLedger.Value != "")
        {
            objEntity_Cheque.ClearanceLedger = Convert.ToInt32(hiddenClearanceLedger.Value);
        }

        int DupChqNos = 0;

        List<clsEntity_Postdated_Cheque> objEntityChequeDtls = new List<clsEntity_Postdated_Cheque>();
        if (HiddenSaveInfo.Value != "" && HiddenSaveInfo.Value != null && HiddenSaveInfo.Value != "[]")
        {
            string jsonDataDltAttch = HiddenSaveInfo.Value;
            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
            string strAtt2 = strAtt1.Replace("\\", "");
            string strAtt3 = strAtt2.Replace("}\"]", "}]");
            string strAtt4 = strAtt3.Replace("}\",", "},");
            List<clsChequeDetails> objVideoDataDltAttList = new List<clsChequeDetails>();
            //   UserData  data
            objVideoDataDltAttList = JsonConvert.DeserializeObject<List<clsChequeDetails>>(strAtt4);

            foreach (clsChequeDetails objClsVideoAddAttData in objVideoDataDltAttList)
            {
                clsEntity_Postdated_Cheque objSubEntity_Cheque = new clsEntity_Postdated_Cheque();

                if (objEntity_Cheque.TransactionType == 0)
                {
                    objSubEntity_Cheque.ChequeBookId = Convert.ToInt32(objClsVideoAddAttData.CHEQUEBOOK);
                    objSubEntity_Cheque.ChequeBookNo = Convert.ToInt32(objClsVideoAddAttData.CHEQUEBOOKNO);
                }
                else
                {
                    objSubEntity_Cheque.ChequeBookNo = Convert.ToInt32(Request.Form["txtRcAcntNum" + objClsVideoAddAttData.ROWID]);
                    objSubEntity_Cheque.Bank = Request.Form["txtRcBank" + objClsVideoAddAttData.ROWID];
                    objSubEntity_Cheque.Iban = Request.Form["txtRcIban" + objClsVideoAddAttData.ROWID];
                }
                if (Request.Form["txtChequedate" + objClsVideoAddAttData.ROWID] != "")
                {
                    //DateTime dtChequeDate= objCommon.textToDateTime(Request.Form["txtChequedate" + objClsVideoAddAttData.ROWID]);
                    //objSubEntity_Cheque.ChequeDate = objCommon.textToDateTime(dtChequeDate.ToString("dd-MM-yyyy"));
                    objSubEntity_Cheque.ChequeDate = objCommon.textToDateTime(Request.Form["txtChequedate" + objClsVideoAddAttData.ROWID]);
                }
                if (Request.Form["txtChequeAmount" + objClsVideoAddAttData.ROWID] != "")
                {
                    objSubEntity_Cheque.ChequeAmount = Convert.ToDecimal(Request.Form["txtChequeAmount" + objClsVideoAddAttData.ROWID]);
                }
                if (Request.Form["TxtRemark" + objClsVideoAddAttData.ROWID] != "")
                {
                    objSubEntity_Cheque.Remarks = Request.Form["TxtRemark" + objClsVideoAddAttData.ROWID];
                }

                if (objEntity_Cheque.TransactionType == 0)
                {
                    objSubEntity_Cheque.Organisation_id = objEntity_Cheque.Organisation_id;
                    objSubEntity_Cheque.Corporate_id = objEntity_Cheque.Corporate_id;

                    DataTable dtCheqDup = objBusiness_Cheque.CheckChequeNumbersAdded(objSubEntity_Cheque);

                    if (dtCheqDup.Rows.Count > 0 && Convert.ToInt32(dtCheqDup.Rows[0]["CNT_CHQNO"].ToString()) > 0)
                    {
                        DupChqNos++;
                        break;
                    }
                }

                objEntityChequeDtls.Add(objSubEntity_Cheque);
            }

            if (DupChqNos > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ChequeNoDuplicate", "ChequeNoDuplicate();", true);
            }
            else
            {
                objBusiness_Cheque.InsertPostDatedCheque(objEntity_Cheque, objEntityChequeDtls);

                if (clickedButton.ID == "btnsave" || clickedButton.ID == "btnFloatSave")
                {
                    Response.Redirect("fms_Postdated_Cheque.aspx?InsUpd=Ins");
                }
                else if (clickedButton.ID == "btnSaveCls" || clickedButton.ID == "btnFloatSaveCls")
                {
                    Response.Redirect("fms_Postdated_Cheque_List.aspx?InsUpd=Ins");
                }
            }

        }
    }

    public void Update(string strP_Id, string mode)
    {
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_Cheque.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity_Cheque.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntity_Cheque.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(strP_Id);
        HiddenPostdatedChequeId.Value = strP_Id;

        DataTable dt = objBusiness_Cheque.Read_PostDatedChequeByID(objEntity_Cheque);
        if (dt.Rows.Count > 0)
        {
            ddlAccontLed.Enabled = false;

            ddlTranscationType.ClearSelection();
            if (ddlTranscationType.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString()) != null)
            {
                ddlTranscationType.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString()).Selected = true;
            }

            if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
            {
                HiddenCurrencyId.Value = dt.Rows[0]["CRNCMST_ID"].ToString();
            }
            if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
            {
                HiddenCurrencyAbrv.Value = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
            }


            if (dt.Rows[0]["PST_CHEQUE_REF"].ToString() != "")
            {
                TxtRef.Value = dt.Rows[0]["PST_CHEQUE_REF"].ToString();
                HiddenUpdRefNum.Value = dt.Rows[0]["PST_CHEQUE_REF"].ToString();
            }
            LoadAccountHeadLedger();
            ddlAccontLed.ClearSelection();
            if (dt.Rows[0]["PST_CHEQUE_ACC_LDGR_ID"].ToString() != "")
            {
                if (ddlAccontLed.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_ACC_LDGR_ID"].ToString()) != null)
                {
                    ddlAccontLed.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_ACC_LDGR_ID"].ToString()).Selected = true;
                }
            }
            LoadSupplierLedger();
            ddlSupplier.ClearSelection();
            ddlSupplier1.ClearSelection();
            if (dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString() != "")
            {
                if (dt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "0")
                {
                    if (ddlSupplier.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString()) != null)
                    {
                        ddlSupplier.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    if (ddlSupplier1.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString()) != null)
                    {
                        ddlSupplier1.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString()).Selected = true;
                    }
                }
            }

            if (dt.Rows[0]["PST_CHEQUE_PAYEE"].ToString() != "")
            {
                txtPayee.Value = dt.Rows[0]["PST_CHEQUE_PAYEE"].ToString();
            }
            if (dt.Rows[0]["PST_CHEQUE_DATE"].ToString() != "")
            {
                txtdate.Value = dt.Rows[0]["PST_CHEQUE_DATE"].ToString();
                HiddenUpdatedDate.Value = dt.Rows[0]["PST_CHEQUE_DATE"].ToString();
            }
            if (dt.Rows[0]["PST_CHEQUE_ISSUE_STATUS"].ToString() == "0")
            {
                ChkStatus_Cheque.Checked = false;
            }
            else if (dt.Rows[0]["PST_CHEQUE_ISSUE_STATUS"].ToString() == "1")
            {
                ChkStatus_Cheque.Checked = true;
                if (dt.Rows[0]["PST_CHEQUE_ISSUE_DATE"].ToString() != "")
                {
                    txtIssueDate_Cheque.Value = dt.Rows[0]["PST_CHEQUE_ISSUE_DATE"].ToString();
                }
            }
            if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
            {
                lblCurrency.InnerHtml = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                if (dt.Rows[0]["PST_CHEQUE_AMOUNT"].ToString() != "")
                {
                    txtGrantTotal.Value = dt.Rows[0]["PST_CHEQUE_AMOUNT"].ToString();
                    //HiddenGrdTotl.Value = dt.Rows[0]["PST_CHEQUE_AMOUNT"].ToString();
                }

            }
            if (dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString() != "")
            {
                txtDescription.Value = dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString();

            }
            if (dt.Rows[0]["PST_CHEQUE_REF_SEQNUM"].ToString() != "")
            {
                HiddenSequenceRef.Value = dt.Rows[0]["PST_CHEQUE_REF_SEQNUM"].ToString();
            }

            if (ddlMethod.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_METHOD_STS"].ToString()) != null)
            {
                ddlMethod.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_METHOD_STS"].ToString()).Selected = true;
            }

            ddlExp.ClearSelection();
            ddlIncm.ClearSelection();
            ddlInvoice.ClearSelection();

            if (dt.Rows[0]["PST_CHEQUE_EXPINCM_LDGRID"].ToString() != "")
            {
                if (dt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "0")
                {
                    if (ddlExp.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_EXPINCM_LDGRID"].ToString()) != null)
                    {
                        ddlExp.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_EXPINCM_LDGRID"].ToString()).Selected = true;
                    }
                }
                else
                {
                    if (ddlIncm.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_EXPINCM_LDGRID"].ToString()) != null)
                    {
                        ddlIncm.Items.FindByValue(dt.Rows[0]["PST_CHEQUE_EXPINCM_LDGRID"].ToString()).Selected = true;
                    }
                }
            }

            if (dt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "0")
            {
                if (dt.Rows[0]["PURCHS_ID"].ToString() != "")
                {
                    hiddenInvoiceId.Value = dt.Rows[0]["PURCHS_ID"].ToString();
                    hiddenInvoiceRefrnc.Value = dt.Rows[0]["PURCHS_REF"].ToString();
                }
            }
            else
            {
                if (dt.Rows[0]["SALES_ID"].ToString() != "")
                {
                    hiddenInvoiceId.Value = dt.Rows[0]["SALES_ID"].ToString();
                    hiddenInvoiceRefrnc.Value = dt.Rows[0]["SALES_REF"].ToString();
                }
            }

        }

        int flag = 0;
        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("PST_CHEQUE_ID", typeof(int));
        dtDetail.Columns.Add("PST_CHEQUE_DTLS_ID", typeof(int));
        dtDetail.Columns.Add("CHKBK_ID", typeof(int));
        dtDetail.Columns.Add("CHQ_DTLS_NUMBER", typeof(int));
        dtDetail.Columns.Add("CHQ_DTLS_AMOUNT", typeof(string));
        dtDetail.Columns.Add("CHQ_DTLS_CHQ_DATE", typeof(string));
        dtDetail.Columns.Add("CHQ_DTLS_REMARK", typeof(string));
        dtDetail.Columns.Add("CHQ_DTLS_PAID_RJCT_STATUS", typeof(int));
        dtDetail.Columns.Add("PST_CHEQUE_CONFIRM_STATUS", typeof(int));
        dtDetail.Columns.Add("CHQ_DTLS_BANK", typeof(string));
        dtDetail.Columns.Add("CHQ_DTLS_IBAN", typeof(string));
        dtDetail.Columns.Add("PYMNTRECPT_REF", typeof(string));

        DataTable dtLDGRdTLS = objBusiness_Cheque.Read_Cheque_Dtls_ById(objEntity_Cheque);
        for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
        {
            DataRow drDtl = dtDetail.NewRow();
            drDtl["PST_CHEQUE_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PST_CHEQUE_ID"].ToString());
            drDtl["PST_CHEQUE_DTLS_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PST_CHEQUE_DTLS_ID"].ToString());
            if (dtLDGRdTLS.Rows[intCount]["CHKBK_ID"].ToString() != "")
            {
                drDtl["CHKBK_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["CHKBK_ID"].ToString());
            }
            drDtl["CHQ_DTLS_NUMBER"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_NUMBER"].ToString());
            drDtl["CHQ_DTLS_AMOUNT"] = dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString();
            drDtl["CHQ_DTLS_CHQ_DATE"] = dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_CHQ_DATE"].ToString();

            if (dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_REMARK"].ToString() != "")
            {
                drDtl["CHQ_DTLS_REMARK"] = dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_REMARK"].ToString();
            }
            drDtl["CHQ_DTLS_PAID_RJCT_STATUS"] = dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString();
            drDtl["PST_CHEQUE_CONFIRM_STATUS"] = dtLDGRdTLS.Rows[intCount]["PST_CHEQUE_CONFIRM_STATUS"].ToString();

            drDtl["CHQ_DTLS_BANK"] = dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_BANK"].ToString();
            drDtl["CHQ_DTLS_IBAN"] = dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_IBAN"].ToString();

            if (dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_PAID_RJCT_STATUS"].ToString() == "1")
                flag++;
            dtDetail.Rows.Add(drDtl);
        }
        int AcntCloseSts = AccountCloseCheck(dt.Rows[0]["PST_CHEQUE_DATE"].ToString());
        int AuditCloseSts = AuditCloseCheck(dt.Rows[0]["PST_CHEQUE_DATE"].ToString());
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenEdit.Value = strJson;

        if (dt.Rows[0]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "1")
        {
            btnPRint.Text = "Print";
            btnFloatPrint.Text = "Print";

            lblEntry.Text = "View Postdated Cheque";
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
        else 
        {
            btnPRint.Text = "Draft Print";
            btnFloatPrint.Text = "Draft Print";

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


        if (mode == "VIEW" || dt.Rows[0]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "1" || HiddenAcntClsSts.Value == "1")
        {

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
            ChequeIssueDatePikrSpan.Disabled = true;
            ChequeIssueDatePikrSpan.Attributes.Add("style", "pointer-events:none");
            ChkStatus_Cheque.Disabled = true;
            txtIssueDate_Cheque.Disabled = true;
            txtPayee.Disabled = true;
            ddlSupplier.Enabled = false;
            ddlSupplier1.Enabled = false;
            ddlMethod.Enabled = false;
            ddlExp.Enabled = false;
            ddlIncm.Enabled = false;
            ddlInvoice.Enabled = false;
            PaymentDatePikrSpan.Disabled = true;
            PaymentDatePikrSpan.Attributes.Add("style", "pointer-events:none");

        }
        else
        {
            btnUpdate.Visible = true;
            btnsave.Visible = false;
            btnSaveCls.Visible = false;
            btnUpdateClose.Visible = true;

            btnFloatUpdate.Visible = true;
            btnFloatSave.Visible = false;
            btnFloatSaveCls.Visible = false;
            btnFloatUpdateCls.Visible = true;
            HiddenView.Value = "0";
        }
        if (flag != 0)
        {
            btnReopen.Visible = false;
            btnFloatReopen.Visible = false;
        }
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_Cheque.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity_Cheque.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntity_Cheque.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (HiddenUpdatedDate.Value != "")
        {
            objEntity_Cheque.UpdChequeDate = objCommon.textToDateTime(HiddenUpdatedDate.Value);
        }
        objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(HiddenPostdatedChequeId.Value);
        objEntity_Cheque.TransactionType = Convert.ToInt32(ddlTranscationType.SelectedValue);
        objEntity_Cheque.RefNumber = TxtRef.Value;
        if (ddlAccontLed.SelectedValue != "0" && ddlAccontLed.SelectedValue != "--SELECT--")
            objEntity_Cheque.LedgerId = Convert.ToInt32(ddlAccontLed.SelectedValue);
        if (objEntity_Cheque.TransactionType == 0)
        {
            if (ddlSupplier.SelectedValue != "0" && ddlSupplier.SelectedValue != "--SELECT--")
                objEntity_Cheque.PartId = Convert.ToInt32(ddlSupplier.SelectedValue);
        }
        else
        {
            if (ddlSupplier1.SelectedValue != "0" && ddlSupplier1.SelectedValue != "--SELECT--")
                objEntity_Cheque.PartId = Convert.ToInt32(ddlSupplier1.SelectedValue);
        }
        if (txtdate.Value != "")
            objEntity_Cheque.PostdatedChequeDate = objCommon.textToDateTime(txtdate.Value);
        if (txtGrantTotal.Value != "")
            objEntity_Cheque.TotalAmount = Convert.ToDecimal(txtGrantTotal.Value);
        if (txtPayee.Value != "")
            objEntity_Cheque.Payee = txtPayee.Value;
        if (HiddenCurrencyId.Value != "")
            objEntity_Cheque.CurrencyId = Convert.ToInt32(HiddenCurrencyId.Value);
        if (objEntity_Cheque.TransactionType == 0)
        {
            if (ChkStatus_Cheque.Checked)
            {
                objEntity_Cheque.IssueStatus = 1;
                objEntity_Cheque.ChequeIssueDate = objCommon.textToDateTime(txtIssueDate_Cheque.Value);
            }
            else
            {
                objEntity_Cheque.IssueStatus = 0;
            }
        }
        objEntity_Cheque.Description = txtDescription.Value;

        objEntity_Cheque.Method = Convert.ToInt32(ddlMethod.SelectedItem.Value);

        if (objEntity_Cheque.Method == 1)
        {
            if (hiddenInvoiceId.Value != "")
            {
                if (objEntity_Cheque.TransactionType == 0)
                {
                    objEntity_Cheque.PurchaseId = Convert.ToInt32(hiddenInvoiceId.Value);
                }
                else if (objEntity_Cheque.TransactionType == 1)
                {
                    objEntity_Cheque.SalesId = Convert.ToInt32(hiddenInvoiceId.Value);
                }
            }
        }
        if (objEntity_Cheque.Method == 2)
        {
            if (objEntity_Cheque.Method == 2)
            {
                if (objEntity_Cheque.TransactionType == 0)
                {
                    if (ddlExp.SelectedItem.Value != "--SELECT--")
                    {
                        objEntity_Cheque.ExpIncmLedgerId = Convert.ToInt32(ddlExp.SelectedItem.Value);
                    }
                }
                else if (objEntity_Cheque.TransactionType == 1)
                {
                    if (ddlIncm.SelectedItem.Value != "--SELECT--")
                    {
                        objEntity_Cheque.ExpIncmLedgerId = Convert.ToInt32(ddlIncm.SelectedItem.Value);
                    }
                }
            }
        }
        if (hiddenClearanceLedger.Value != "")
        {
            objEntity_Cheque.ClearanceLedger = Convert.ToInt32(hiddenClearanceLedger.Value);
        }

        int DupChqNos = 0;

        List<clsEntity_Postdated_Cheque> objEntityChequeDtls = new List<clsEntity_Postdated_Cheque>();
        if (HiddenSaveInfo.Value != "" && HiddenSaveInfo.Value != null && HiddenSaveInfo.Value != "[]")
        {
            string jsonDataDltAttch = HiddenSaveInfo.Value;
            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
            string strAtt2 = strAtt1.Replace("\\", "");
            string strAtt3 = strAtt2.Replace("}\"]", "}]");
            string strAtt4 = strAtt3.Replace("}\",", "},");
            List<clsChequeDetails> objVideoDataDltAttList = new List<clsChequeDetails>();
            //   UserData  data
            objVideoDataDltAttList = JsonConvert.DeserializeObject<List<clsChequeDetails>>(strAtt4);

            foreach (clsChequeDetails objClsVideoAddAttData in objVideoDataDltAttList)
            {
                clsEntity_Postdated_Cheque objSubEntity_Cheque = new clsEntity_Postdated_Cheque();
                if (objEntity_Cheque.TransactionType == 0)
                {
                    objSubEntity_Cheque.ChequeBookId = Convert.ToInt32(objClsVideoAddAttData.CHEQUEBOOK);
                    objSubEntity_Cheque.ChequeBookNo = Convert.ToInt32(objClsVideoAddAttData.CHEQUEBOOKNO);
                }
                else
                {
                    objSubEntity_Cheque.ChequeBookNo = Convert.ToInt32(Request.Form["txtRcAcntNum" + objClsVideoAddAttData.ROWID]);
                    objSubEntity_Cheque.Bank = Request.Form["txtRcBank" + objClsVideoAddAttData.ROWID];
                    objSubEntity_Cheque.Iban = Request.Form["txtRcIban" + objClsVideoAddAttData.ROWID];
                }

                if (Request.Form["txtChequedate" + objClsVideoAddAttData.ROWID] != "")
                {
                    //DateTime dtChequeDate= objCommon.textToDateTime(Request.Form["txtChequedate" + objClsVideoAddAttData.ROWID]);
                    //objSubEntity_Cheque.ChequeDate = objCommon.textToDateTime(dtChequeDate.ToString("dd-MM-yyyy"));
                    objSubEntity_Cheque.ChequeDate = objCommon.textToDateTime(Request.Form["txtChequedate" + objClsVideoAddAttData.ROWID]);
                }
                if (Request.Form["txtChequeAmount" + objClsVideoAddAttData.ROWID] != "")
                {
                    objSubEntity_Cheque.ChequeAmount = Convert.ToDecimal(Request.Form["txtChequeAmount" + objClsVideoAddAttData.ROWID]);
                }
                if (Request.Form["TxtRemark" + objClsVideoAddAttData.ROWID] != "")
                {
                    objSubEntity_Cheque.Remarks = Request.Form["TxtRemark" + objClsVideoAddAttData.ROWID];
                }

                if (objEntity_Cheque.TransactionType == 0)
                {
                    objSubEntity_Cheque.Organisation_id = objEntity_Cheque.Organisation_id;
                    objSubEntity_Cheque.Corporate_id = objEntity_Cheque.Corporate_id;
                    objSubEntity_Cheque.PostDatedChequeId = objEntity_Cheque.PostDatedChequeId;

                    DataTable dtCheqDup = objBusiness_Cheque.CheckChequeNumbersAdded(objSubEntity_Cheque);

                    if (dtCheqDup.Rows.Count > 0 && Convert.ToInt32(dtCheqDup.Rows[0]["CNT_CHQNO"].ToString()) > 0)
                    {
                        DupChqNos++;
                        break;
                    }
                }

                objEntityChequeDtls.Add(objSubEntity_Cheque);
            }

            if (DupChqNos > 0)
            {
                Response.Redirect("fms_Postdated_Cheque.aspx?Id=" + Request.QueryString["Id"].ToString() + "&InsUpd=ChqDup");
            }
            else
            {
                objBusiness_Cheque.UpdatePostDatedCheque(objEntity_Cheque, objEntityChequeDtls);

                if (clickedButton.ID == "btnUpdate" || clickedButton.ID == "btnFloatUpdate")
                {
                    Response.Redirect("fms_Postdated_Cheque.aspx?Id=" + Request.QueryString["Id"].ToString() + "&InsUpd=Upd");
                }
                else if (clickedButton.ID == "btnUpdateClose" || clickedButton.ID == "btnFloatUpdateCls")
                {
                    Response.Redirect("fms_Postdated_Cheque_List.aspx?InsUpd=Upd");
                }
            }
        }
    }

    protected void btnConfirm1_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_Cheque.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity_Cheque.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            objEntity_Cheque.User_Id = Convert.ToInt32(Session["USERID"].ToString());
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["FINCYRID"] != "" && Session["FINCYRID"] != null)
        {
            objEntity_Cheque.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
        }

        if (HiddenUpdatedDate.Value != "")
        {
            objEntity_Cheque.UpdChequeDate = objCommon.textToDateTime(HiddenUpdatedDate.Value);
        }
        objEntity_Cheque.ConfirmStatus = 1;
        objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(HiddenPostdatedChequeId.Value);
        objEntity_Cheque.TransactionType = Convert.ToInt32(ddlTranscationType.SelectedValue);
        objEntity_Cheque.RefNumber = TxtRef.Value;
        if (ddlAccontLed.SelectedValue != "0" && ddlAccontLed.SelectedValue != "--SELECT--")
            objEntity_Cheque.LedgerId = Convert.ToInt32(ddlAccontLed.SelectedValue);
        if (objEntity_Cheque.TransactionType == 0)
        {
            if (ddlSupplier.SelectedValue != "0" && ddlSupplier.SelectedValue != "--SELECT--")
                objEntity_Cheque.PartId = Convert.ToInt32(ddlSupplier.SelectedValue);
        }
        else
        {
            if (ddlSupplier1.SelectedValue != "0" && ddlSupplier1.SelectedValue != "--SELECT--")
                objEntity_Cheque.PartId = Convert.ToInt32(ddlSupplier1.SelectedValue);
        }
        if (txtdate.Value != "")
            objEntity_Cheque.PostdatedChequeDate = objCommon.textToDateTime(txtdate.Value);
        if (txtGrantTotal.Value != "")
            objEntity_Cheque.TotalAmount = Convert.ToDecimal(txtGrantTotal.Value);
        if (txtPayee.Value != "")
            objEntity_Cheque.Payee = txtPayee.Value;
        if (HiddenCurrencyId.Value != "")
            objEntity_Cheque.CurrencyId = Convert.ToInt32(HiddenCurrencyId.Value);
        if (objEntity_Cheque.TransactionType == 0)
        {
            if (ChkStatus_Cheque.Checked)
            {
                objEntity_Cheque.IssueStatus = 1;
                objEntity_Cheque.ChequeIssueDate = objCommon.textToDateTime(txtIssueDate_Cheque.Value);
            }
            else
            {
                objEntity_Cheque.IssueStatus = 0;
            }
        }
        objEntity_Cheque.Description = txtDescription.Value;

        DataTable dt = objBusiness_Cheque.Read_PostDatedChequeByID(objEntity_Cheque);

        objEntity_Cheque.Method = Convert.ToInt32(ddlMethod.SelectedItem.Value);

        if (objEntity_Cheque.Method == 1)
        {
            if (hiddenInvoiceId.Value != "")
            {
                if (objEntity_Cheque.TransactionType == 0)
                {
                    objEntity_Cheque.PurchaseId = Convert.ToInt32(hiddenInvoiceId.Value);
                }
                else if (objEntity_Cheque.TransactionType == 1)
                {
                    objEntity_Cheque.SalesId = Convert.ToInt32(hiddenInvoiceId.Value);
                }
            }
        }
        if (objEntity_Cheque.Method == 2)
        {
            if (objEntity_Cheque.TransactionType == 0)
            {
                if (ddlExp.SelectedItem.Value != "--SELECT--")
                {
                    objEntity_Cheque.ExpIncmLedgerId = Convert.ToInt32(ddlExp.SelectedItem.Value);
                }
            }
            else if (objEntity_Cheque.TransactionType == 1)
            {
                if (ddlIncm.SelectedItem.Value != "--SELECT--")
                {
                    objEntity_Cheque.ExpIncmLedgerId = Convert.ToInt32(ddlIncm.SelectedItem.Value);
                }
            }
        }

        if (hiddenClearanceLedger.Value != "")
        {
            objEntity_Cheque.ClearanceLedger = Convert.ToInt32(hiddenClearanceLedger.Value);
        }

        int DupChqNos = 0;

        List<clsEntity_Postdated_Cheque> objEntityChequeDtls = new List<clsEntity_Postdated_Cheque>();
        if (HiddenSaveInfo.Value != "" && HiddenSaveInfo.Value != null && HiddenSaveInfo.Value != "[]")
        {
            string jsonDataDltAttch = HiddenSaveInfo.Value;
            string strAtt1 = jsonDataDltAttch.Replace("\"{", "\\{");
            string strAtt2 = strAtt1.Replace("\\", "");
            string strAtt3 = strAtt2.Replace("}\"]", "}]");
            string strAtt4 = strAtt3.Replace("}\",", "},");
            List<clsChequeDetails> objVideoDataDltAttList = new List<clsChequeDetails>();
            //   UserData  data
            objVideoDataDltAttList = JsonConvert.DeserializeObject<List<clsChequeDetails>>(strAtt4);

            foreach (clsChequeDetails objClsVideoAddAttData in objVideoDataDltAttList)
            {
                clsEntity_Postdated_Cheque objSubEntity_Cheque = new clsEntity_Postdated_Cheque();
                if (objEntity_Cheque.TransactionType == 0)
                {
                    objSubEntity_Cheque.ChequeBookId = Convert.ToInt32(objClsVideoAddAttData.CHEQUEBOOK);
                    objSubEntity_Cheque.ChequeBookNo = Convert.ToInt32(objClsVideoAddAttData.CHEQUEBOOKNO);
                }
                else
                {
                    objSubEntity_Cheque.ChequeBookNo = Convert.ToInt32(Request.Form["txtRcAcntNum" + objClsVideoAddAttData.ROWID]);
                    objSubEntity_Cheque.Bank = Request.Form["txtRcBank" + objClsVideoAddAttData.ROWID];
                    objSubEntity_Cheque.Iban = Request.Form["txtRcIban" + objClsVideoAddAttData.ROWID];
                }
                if (Request.Form["txtChequedate" + objClsVideoAddAttData.ROWID] != "")
                {
                    //DateTime dtChequeDate= objCommon.textToDateTime(Request.Form["txtChequedate" + objClsVideoAddAttData.ROWID]);
                    //objSubEntity_Cheque.ChequeDate = objCommon.textToDateTime(dtChequeDate.ToString("dd-MM-yyyy"));
                    objSubEntity_Cheque.ChequeDate = objCommon.textToDateTime(Request.Form["txtChequedate" + objClsVideoAddAttData.ROWID]);
                }
                if (Request.Form["txtChequeAmount" + objClsVideoAddAttData.ROWID] != "")
                {
                    objSubEntity_Cheque.ChequeAmount = Convert.ToDecimal(Request.Form["txtChequeAmount" + objClsVideoAddAttData.ROWID]);
                }
                if (Request.Form["TxtRemark" + objClsVideoAddAttData.ROWID] != "")
                {
                    objSubEntity_Cheque.Remarks = Request.Form["TxtRemark" + objClsVideoAddAttData.ROWID];
                }

                if (objEntity_Cheque.TransactionType == 0)
                {
                    objSubEntity_Cheque.Organisation_id = objEntity_Cheque.Organisation_id;
                    objSubEntity_Cheque.Corporate_id = objEntity_Cheque.Corporate_id;
                    objSubEntity_Cheque.PostDatedChequeId = objEntity_Cheque.PostDatedChequeId;

                    DataTable dtCheqDup = objBusiness_Cheque.CheckChequeNumbersAdded(objSubEntity_Cheque);

                    if (dtCheqDup.Rows.Count > 0 && Convert.ToInt32(dtCheqDup.Rows[0]["CNT_CHQNO"].ToString()) > 0)
                    {
                        DupChqNos++;
                        break;
                    }
                }

                objEntityChequeDtls.Add(objSubEntity_Cheque);
            }
            if (dt.Rows[0]["PST_CHEQUE_CONFIRM_STATUS"].ToString() != "0")
            {
                Response.Redirect("fms_Postdated_Cheque.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=alrdyreopened");
                    //strRets = "alrdyreopened";
            }

            if (DupChqNos > 0)
            {
                Response.Redirect("fms_Postdated_Cheque.aspx?Id=" + Request.QueryString["Id"].ToString() + "&InsUpd=ChqDup");
            }
            else
            {

                objBusiness_Cheque.UpdatePostDatedCheque(objEntity_Cheque, objEntityChequeDtls);

                if (clickedButton.ID == "btnConfirm1")
                {
                    Response.Redirect("fms_Postdated_Cheque_List.aspx?InsUpd=Confrm");
                }
            }
        }
    }

    [WebMethod]
    public static string[] CheckPaymentInserted(string ChkId, string ChkBkId, string TranType, string CorpId, string OrgId, string AcntClosePrvsn, string AuditClosePrvsn, string Date, string Method)
    {
        string[] strRets = new string[2];
        strRets[0] = "Not_Paid";
        clsCommonLibrary objCommon = new clsCommonLibrary();
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(ChkId);
        objEntity_Cheque.ChequeBookId = Convert.ToInt32(ChkBkId);
        objEntity_Cheque.Status = Convert.ToInt32(TranType);
        objEntity_Cheque.ChequeDate = objCommon.textToDateTime(Date);
        objEntity_Cheque.Method = Convert.ToInt32(Method);

        DataTable dtCheck = objBusiness_Cheque.Read_Cheque_Dtls_Payment(objEntity_Cheque);
        if (dtCheck.Rows.Count > 0)
        {
            if (objEntity_Cheque.Method == 0)
            {
                if (Convert.ToInt32(dtCheck.Rows[0][0].ToString()) > 0)
                {
                    if (TranType == "0")
                    {
                        strRets[0] = dtCheck.Rows[0]["PAYMNT_ID"].ToString();
                    }
                    else
                    {
                        strRets[0] = dtCheck.Rows[0]["RECPT_ID"].ToString();
                    }
                }
            }
            else
            {
                strRets[0] = dtCheck.Rows[0]["JURNL_ID"].ToString();
            }
        }

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        objEntityCommon.CorporateID = Convert.ToInt32(CorpId);
        objEntityCommon.Organisation_Id = Convert.ToInt32(OrgId);
        if (objEntity_Cheque.Method == 0)
        {
            if (TranType == "0")
            {
                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_PAYMENT);
            }
            else
            {
                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT);
            }
        }
        else
        {
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.JOURNAL);
        }

        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();

        objEntityAccnt.FromDate = objEntity_Cheque.ChequeDate;
        objEntityAudit.FromDate = objEntity_Cheque.ChequeDate;
        objEntityAccnt.Corporate_id = objEntityCommon.CorporateID;
        objEntityAudit.Corporate_id = objEntityCommon.CorporateID;
        objEntityAccnt.Organisation_id = objEntityCommon.Organisation_Id;
        objEntityAudit.Organisation_id = objEntityCommon.Organisation_Id;

        DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
        DataTable dtAuditCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);

        string strNextId = "";

        if (dtAccntCls.Rows.Count > 0 && AcntClosePrvsn != "1")//postdated provisn for accnt and audit close
        {
            strNextId = "AcntClosed";
        }
        else if (dtAuditCls.Rows.Count > 0 && AuditClosePrvsn != "1")
        {
            strNextId = "AuditClosed";
        }
        else if ((dtAccntCls.Rows.Count > 0 && AcntClosePrvsn == "1") || (dtAuditCls.Rows.Count > 0 && AuditClosePrvsn == "1"))
        {
            string strRef = "";
            int SubRef = 1;
            if (objEntity_Cheque.Method == 0)
            {
                if (TranType == "0")
                {
                    clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
                    clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();

                    ObjEntityRequest.FromDate = objEntity_Cheque.ChequeDate;
                    ObjEntityRequest.Corporate_id = objEntityCommon.CorporateID;
                    ObjEntityRequest.Organisation_id = objEntityCommon.Organisation_Id;

                    DataTable dtRefFormat1 = objBussiness.ReadRefNumberByDate(ObjEntityRequest);
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
                            strNextId = dtRefFormat.Rows[0]["PAYMNT_REF"].ToString();
                            if (dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString() != null)
                            {
                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["PAYMENT_REF_NXT_SUBNUM"].ToString());
                            }
                            if (SubRef != 1)
                            {
                                strNextId = strNextId.TrimEnd('/');
                                strNextId = strNextId.Remove(strNextId.LastIndexOf('/') + 1);
                            }
                            else
                            {
                                strNextId += "/";
                            }
                            strNextId = strNextId + "" + SubRef;
                        }
                    }
                }
                else
                {
                    clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();
                    clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

                    ObjEntityRequest.FromDate = objEntity_Cheque.ChequeDate;
                    ObjEntityRequest.Corporate_id = objEntityCommon.CorporateID;
                    ObjEntityRequest.Organisation_id = objEntityCommon.Organisation_Id;

                    DataTable dtRefFormat1 = objBussiness.ReadRefNumberByDate(ObjEntityRequest);
                    if (dtRefFormat1.Rows.Count > 0)
                    {
                        if (dtRefFormat1.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "")
                        {
                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString()) != 1)
                            {
                                strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                                strRef = strRef.TrimEnd('/');
                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                            }
                            else
                            {
                                strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                            }
                        }
                        else
                        {
                            strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                        }
                        ObjEntityRequest.RefNum = strRef;
                        DataTable dtRefFormat = objBussiness.ReadRefNumberByDateLast(ObjEntityRequest);

                        if (dtRefFormat.Rows.Count > 0)
                        {
                            strNextId = dtRefFormat.Rows[0]["RECPT_REF"].ToString();
                            if (dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != null)
                            {
                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString());
                            }
                            if (SubRef != 1)
                            {
                                strNextId = strNextId.TrimEnd('/');
                                strNextId = strNextId.Remove(strNextId.LastIndexOf('/') + 1);
                                strNextId = strNextId + "" + SubRef;
                            }
                            else
                            {
                                strNextId = strNextId + "/" + SubRef;
                            }

                        }
                    }
                }
            }
            else
            {
                clsEntityJournal ObjEntityRequest = new clsEntityJournal();
                clsBusinessJournal objBussiness = new clsBusinessJournal();

                ObjEntityRequest.FromDate = objEntity_Cheque.ChequeDate;
                ObjEntityRequest.Corp_Id = objEntityCommon.CorporateID;
                ObjEntityRequest.Org_Id = objEntityCommon.Organisation_Id;

                DataTable dtRefFormat1 = objBussiness.ReadRefNumberByDate(ObjEntityRequest);
                if (dtRefFormat1.Rows.Count > 0)
                {
                    if (dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "")
                    {
                        if (Convert.ToInt32(dtRefFormat1.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString()) != 1)
                        {
                            strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                            strRef = strRef.TrimEnd('/');
                            strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                        }
                        else
                        {
                            strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                        }
                    }
                    else
                    {
                        strRef = dtRefFormat1.Rows[0]["JURNL_REF"].ToString();
                    }
                    ObjEntityRequest.RefNum = strRef;
                    DataTable dtRefFormat = objBussiness.ReadRefNumberByDateLast(ObjEntityRequest);

                    if (dtRefFormat.Rows.Count > 0)
                    {
                        strNextId = dtRefFormat.Rows[0]["JURNL_REF"].ToString();
                        if (dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString() != null)
                        {
                            SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["JURNL_REF_NXT_SUBNUM"].ToString());
                        }
                        if (SubRef != 1)
                        {
                            strNextId = strNextId.TrimEnd('/');
                            strNextId = strNextId.Remove(strNextId.LastIndexOf('/') + 1);
                            strNextId = strNextId + "" + SubRef;
                        }
                        else
                        {
                            strNextId = strNextId + "/" + SubRef;
                        }

                    }
                }

            }
        }
        else
        {
            strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);
        }
        strRets[1] = strNextId;

        return strRets;
    }

    [WebMethod]
    public static string[] ChequePaidRejectStatus(string usrId, string ChequeId, string strCorpID, string strOrgIdID, string ChequeBkId, string Status, string TransType, string PaymntRecptId, string AcntClosePrvsn, string AuditClosePrvsn, string Method, string ChequeDate)
    {
        string[] strRets = new string[2];

        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();

        clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
        clsBusiness_PaymentAccount objBussinessPayment = new clsBusiness_PaymentAccount();
        List<clsEntityPaymentAccount> objEntityPerfomList = new List<clsEntityPaymentAccount>();
        List<clsEntityPaymentAccount> objEntityPerfomListGrps = new List<clsEntityPaymentAccount>();
        clsEntityPaymentAccount objSubEntity = new clsEntityPaymentAccount();

        clsEntity_Receipt_Account ObjEntityRequest1 = new clsEntity_Receipt_Account();
        clsBusinessLayer_Receipt_Account objBussinessPayment1 = new clsBusinessLayer_Receipt_Account();
        List<clsEntity_Receipt_Account> objEntityPerfomList1 = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> objEntityPerfomListGrps1 = new List<clsEntity_Receipt_Account>();
        clsEntity_Receipt_Account objSubEntity1 = new clsEntity_Receipt_Account();

        clsEntityJournal ObjEntityRequestJrnl = new clsEntityJournal();
        clsBusinessJournal objBussinessPaymentJrnl = new clsBusinessJournal();
        List<clsEntityJournalLedgerDtl> objEntityPerfomListJrnl = new List<clsEntityJournalLedgerDtl>();
        List<clsEntityJournalCostCntrDtl> objEntityPerfomListGrpsJrnl = new List<clsEntityJournalCostCntrDtl>();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        strRets[0] = "successUpdate";

        objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(ChequeId);
        objEntity_Cheque.ChequeBookId = Convert.ToInt32(ChequeBkId);
        objEntity_Cheque.User_Id = Convert.ToInt32(usrId);
        objEntity_Cheque.Organisation_id = Convert.ToInt32(strOrgIdID);
        objEntity_Cheque.Corporate_id = Convert.ToInt32(strCorpID);
        objEntity_Cheque.ChequeDate = objCommon.textToDateTime(ChequeDate);
        objEntity_Cheque.Method = Convert.ToInt32(Method);

        int flag = 0;
        try
        {
            objEntity_Cheque.Status = Convert.ToInt32(Status);

            DataTable dtPaidStatus = objBusiness_Cheque.CheckChequeIsPaid_Reject(objEntity_Cheque);
            if (dtPaidStatus.Rows.Count > 0)
            {
                if (Convert.ToInt32(dtPaidStatus.Rows[0][0].ToString()) == 1)
                {
                    strRets[0] = "Paid";
                    flag++;
                }
                else if (Convert.ToInt32(dtPaidStatus.Rows[0][0].ToString()) == 2 && objEntity_Cheque.Status != 0)
                {
                    strRets[0] = "Rejected";
                    flag++;
                }
                else if (Convert.ToInt32(dtPaidStatus.Rows[0][0].ToString()) == 0 && objEntity_Cheque.Status == 0)
                {
                    strRets[0] = "CnclReject";
                    flag++;
                }
            }
            if (flag == 0)
            {
                if (Status == "2")//reject update
                {
                    objEntity_Cheque.Status = Convert.ToInt32(Status);

                    objBusiness_Cheque.UpdateChequePaidRejectStatus(objEntity_Cheque);
                }
                else if (Status == "0")// cancel reject update
                {
                    objEntity_Cheque.Status = Convert.ToInt32(Status);
                    objBusiness_Cheque.UpdateChequePaidRejectStatus(objEntity_Cheque);
                }
                else
                {

                    if (PaymntRecptId != "")//edit paymnt/receipt
                    {
                        string strRandom = objCommon.Random_Number();
                        string strId = PaymntRecptId;
                        int intIdLength = PaymntRecptId.Length;
                        string stridLength = intIdLength.ToString("00");
                        string Id = stridLength + strId + strRandom;

                        strRets[0] = Id;
                    }
                    else//paymnt/recept insert
                    {

                        DataTable dt = objBusiness_Cheque.Read_PostDatedChequeByID(objEntity_Cheque);

                        if (Method == "0")//method 1
                        {

                            if (TransType == "0")//paymnt insert
                            {
                                if (dt.Rows.Count > 0)
                                {
                                    ObjEntityRequest.Organisation_id = Convert.ToInt32(strOrgIdID);
                                    ObjEntityRequest.Corporate_id = Convert.ToInt32(strCorpID);
                                    ObjEntityRequest.PayemntMode = 1;
                                    if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
                                    {
                                        ObjEntityRequest.CurrcyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                                    }
                                    if (dt.Rows[0]["PST_CHEQUE_ACC_LDGR_ID"].ToString() != "")
                                    {
                                        ObjEntityRequest.AccntNameId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_ACC_LDGR_ID"].ToString());
                                    }

                                    if (dt.Rows[0]["PST_CHEQUE_DATE"].ToString() != "")
                                    {
                                        ObjEntityRequest.FromDate = objCommon.textToDateTime(dt.Rows[0]["PST_CHEQUE_DATE"].ToString());
                                    }
                                    if (dt.Rows[0]["PST_CHEQUE_ISSUE_STATUS"].ToString() == "0")
                                    {
                                        ObjEntityRequest.ChequeIssue = 0;
                                    }
                                    else if (dt.Rows[0]["PST_CHEQUE_ISSUE_STATUS"].ToString() == "1")
                                    {
                                        ObjEntityRequest.ChequeIssue = 1;
                                        if (dt.Rows[0]["PST_CHEQUE_ISSUE_DATE"].ToString() != "")
                                            ObjEntityRequest.ChequeIssueDate = objCommon.textToDateTime(dt.Rows[0]["PST_CHEQUE_ISSUE_DATE"].ToString());
                                    }
                                    if (dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString() != "")
                                    {
                                        ObjEntityRequest.Description = dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString();
                                    }

                                    DataTable dtLDGRdTLS = objBusiness_Cheque.Read_Cheque_Dtls_By_ChequeId(objEntity_Cheque);
                                    for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
                                    {
                                        ObjEntityRequest.ChequeBookId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["CHKBK_ID"].ToString());
                                        ObjEntityRequest.ChequeBookNumber = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_NUMBER"].ToString());
                                        ObjEntityRequest.TotalAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString());
                                        ObjEntityRequest.ToDate = objCommon.textToDateTime(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_CHQ_DATE"].ToString());
                                        ObjEntityRequest.FromDate = ObjEntityRequest.ToDate;

                                        ObjEntityRequest.Payee = dt.Rows[0]["PST_CHEQUE_PAYEE"].ToString();
                                        if (dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString() != "")
                                        {
                                            objSubEntity.LedgerId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString());
                                        }
                                        if (dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                                        {
                                            objSubEntity.LedgerAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString());
                                        }
                                        ObjEntityRequest.PostdateChqDtlId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PST_CHEQUE_DTLS_ID"].ToString());
                                        objEntityPerfomList.Add(objSubEntity);
                                    }
                                }
                                ObjEntityRequest.PostdatedStatus = 1;
                                ObjEntityRequest.PostdateChqId = objEntity_Cheque.PostDatedChequeId;

                                ObjEntityRequest.User_Id = objEntity_Cheque.User_Id;

                                int intflag = 0;
                                objEntity_Cheque.Status = Convert.ToInt32(TransType);
                                DataTable dtCheck = objBusiness_Cheque.Read_Cheque_Dtls_Payment(objEntity_Cheque);
                                if (dtCheck.Rows.Count > 0)
                                {
                                    if (Convert.ToInt32(dtCheck.Rows[0][0].ToString()) > 0)
                                    {
                                        intflag++;
                                        strRets[0] = "Payment";
                                    }
                                }
                                if (intflag == 0)
                                {
                                    objBussinessPayment.InsertPaymentMaster(ObjEntityRequest, objEntityPerfomListGrps, objEntityPerfomList);
                                    
                                    string strRandom = objCommon.Random_Number();
                                    string strId = ObjEntityRequest.PaymentId.ToString();
                                    int intIdLength = ObjEntityRequest.PaymentId.ToString().Length;
                                    string stridLength = intIdLength.ToString("00");
                                    string Id = stridLength + strId + strRandom;
                                    strRets[0] = Id;


                                    DataTable dtPaymnt = objBussinessPayment.Read_PayemntByID(ObjEntityRequest);
                                    if (dtPaymnt.Rows.Count > 0)
                                    {
                                        strRets[1] = dtPaymnt.Rows[0]["PAYMNT_REF"].ToString();
                                    }

                                }
                            }//receipt insert
                            else
                            {

                                if (dt.Rows.Count > 0)
                                {
                                    ObjEntityRequest1.Organisation_id = Convert.ToInt32(strOrgIdID);
                                    ObjEntityRequest1.Corporate_id = Convert.ToInt32(strCorpID);
                                    ObjEntityRequest1.PaymentMod = 0;
                                    if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
                                    {
                                        ObjEntityRequest1.CurrcyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                                    }
                                    if (dt.Rows[0]["PST_CHEQUE_ACC_LDGR_ID"].ToString() != "")
                                    {
                                        ObjEntityRequest1.LedgerId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_ACC_LDGR_ID"].ToString());
                                    }
                                    if (dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString() != "")
                                    {
                                        ObjEntityRequest1.Description = dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString();
                                    }

                                    DataTable dtLDGRdTLS = objBusiness_Cheque.Read_Cheque_Dtls_By_ChequeId(objEntity_Cheque);
                                    for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
                                    {
                                        ObjEntityRequest1.Bank_Name = dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_BANK"].ToString();
                                        ObjEntityRequest1.IbanNo = dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_IBAN"].ToString();
                                        ObjEntityRequest1.ChequeBook_No = dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_NUMBER"].ToString();

                                        ObjEntityRequest1.TotalAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString());
                                        ObjEntityRequest1.PaymentDate = objCommon.textToDateTime(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_CHQ_DATE"].ToString());
                                        ObjEntityRequest1.FromDate = ObjEntityRequest1.PaymentDate;

                                        if (dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString() != "")
                                        {
                                            objSubEntity1.LedgerId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString());
                                        }
                                        if (dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString() != "")
                                        {
                                            objSubEntity1.LedgerAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CHQ_DTLS_AMOUNT"].ToString());
                                        }
                                        ObjEntityRequest1.RecurMasterId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["PST_CHEQUE_DTLS_ID"].ToString());
                                        objEntityPerfomList1.Add(objSubEntity1);
                                    }
                                }

                                ObjEntityRequest1.User_Id = objEntity_Cheque.User_Id;

                                int intflag = 0;
                                objEntity_Cheque.Status = Convert.ToInt32(TransType);
                                DataTable dtCheck = objBusiness_Cheque.Read_Cheque_Dtls_Payment(objEntity_Cheque);
                                if (dtCheck.Rows.Count > 0)
                                {
                                    if (Convert.ToInt32(dtCheck.Rows[0][0].ToString()) > 0)
                                    {
                                        intflag++;
                                        strRets[0] = "Payment";
                                    }
                                }
                                if (intflag == 0)
                                {
                                    objBussinessPayment1.InsertReceiptDtls(ObjEntityRequest1, objEntityPerfomList1, objEntityPerfomListGrps1);
                                    
                                    string strRandom = objCommon.Random_Number();
                                    string strId = ObjEntityRequest1.ReceiptId.ToString();
                                    int intIdLength = ObjEntityRequest1.ReceiptId.ToString().Length;
                                    string stridLength = intIdLength.ToString("00");
                                    string Id = stridLength + strId + strRandom;
                                    strRets[0] = Id;

                                    DataTable dtReceipt = objBussinessPayment1.ReadReceptDetailsById(ObjEntityRequest1);
                                    if (dtReceipt.Rows.Count > 0)
                                    {
                                        strRets[1] = dtReceipt.Rows[0]["RECPT_REF"].ToString();
                                    }

                                }
                            }
                        }
                        else//journal insert
                        {
                            if (dt.Rows.Count > 0)
                            {
                                clsEntityJournalLedgerDtl objEntityDtlCredit1 = new clsEntityJournalLedgerDtl();
                                clsEntityJournalLedgerDtl objEntityDtlDebit1 = new clsEntityJournalLedgerDtl();
                                clsEntityJournalLedgerDtl objEntityDtlCredit2 = new clsEntityJournalLedgerDtl();
                                clsEntityJournalLedgerDtl objEntityDtlDebit2 = new clsEntityJournalLedgerDtl();

                                ObjEntityRequestJrnl.Org_Id = Convert.ToInt32(strOrgIdID);
                                ObjEntityRequestJrnl.Corp_Id = Convert.ToInt32(strCorpID);
                                if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
                                {
                                    ObjEntityRequestJrnl.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                                }
                                if (dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString() != "")
                                {
                                    ObjEntityRequestJrnl.Description = dt.Rows[0]["PST_CHEQUE_DESCRIPTION"].ToString();
                                }

                                string Bank = dt.Rows[0]["PST_CHEQUE_ACC_LDGR_ID"].ToString();
                                string Clearance = dt.Rows[0]["PST_CHEQUE_CLRNC_LDGRID"].ToString();
                                string Party = dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString();
                                string ExpIncm = dt.Rows[0]["PST_CHEQUE_EXPINCM_LDGRID"].ToString();
                                string Amnt = dt.Rows[0]["PST_CHEQUE_AMOUNT"].ToString();
                                string ChequeAmnt = dt.Rows[0]["PST_CHEQUE_AMOUNT"].ToString();

                                DataTable dtLDGRdTLS = objBusiness_Cheque.Read_Cheque_Dtls_By_ChequeId(objEntity_Cheque);
                                if (dtLDGRdTLS.Rows.Count > 0)
                                {
                                    ObjEntityRequestJrnl.JournalDate = objCommon.textToDateTime(dtLDGRdTLS.Rows[0]["CHQ_DTLS_CHQ_DATE"].ToString());
                                    ObjEntityRequestJrnl.PostdateChqDtlId = Convert.ToInt32(dtLDGRdTLS.Rows[0]["PST_CHEQUE_DTLS_ID"].ToString());
                                    ChequeAmnt = dtLDGRdTLS.Rows[0]["CHQ_DTLS_AMOUNT"].ToString();                                
                                }


                                if (TransType == "0")//payment => bank to clearance
                                {

                                    //------------add bank----------
                                    objEntityDtlCredit1.TabMode = 1;//credit
                                    objEntityDtlCredit1.MainTabId = 1;//rowid
                                    objEntityDtlCredit1.LedgerId = Convert.ToInt32(Bank);
                                    objEntityDtlCredit1.LedgerTotAmnt = Convert.ToDecimal(ChequeAmnt);

                                    objEntityPerfomListJrnl.Add(objEntityDtlCredit1);

                                    //------------add clearance----------
                                    objEntityDtlDebit1.TabMode = 0;//debit
                                    objEntityDtlDebit1.MainTabId = 2;//rowid
                                    objEntityDtlDebit1.LedgerId = Convert.ToInt32(Clearance);
                                    objEntityDtlDebit1.LedgerTotAmnt = Convert.ToDecimal(ChequeAmnt);

                                    objEntityPerfomListJrnl.Add(objEntityDtlDebit1);

                                    ObjEntityRequestJrnl.JournalTotAmnt = Convert.ToDecimal(ChequeAmnt);

                                    if (Method == "2") //=> party to expense
                                    {
                                        //------------add party----------
                                        objEntityDtlCredit2.TabMode = 1;//credit
                                        objEntityDtlCredit2.MainTabId = 3;//rowid
                                        objEntityDtlCredit2.LedgerId = Convert.ToInt32(Party);
                                        objEntityDtlCredit2.LedgerTotAmnt = Convert.ToDecimal(ChequeAmnt);

                                        objEntityPerfomListJrnl.Add(objEntityDtlCredit2);

                                        //------------add expense/incm----------
                                        objEntityDtlDebit2.TabMode = 0;//debit
                                        objEntityDtlDebit2.MainTabId = 4;//rowid
                                        objEntityDtlDebit2.LedgerId = Convert.ToInt32(ExpIncm);
                                        objEntityDtlDebit2.LedgerTotAmnt = Convert.ToDecimal(ChequeAmnt);

                                        objEntityPerfomListJrnl.Add(objEntityDtlDebit2);

                                        ObjEntityRequestJrnl.JournalTotAmnt = 2 * Convert.ToDecimal(ChequeAmnt);
                                    }
                                }
                                else//receipt => clearance to bank
                                {
                                    //------------add bank----------
                                    objEntityDtlCredit1.TabMode = 0;//debit
                                    objEntityDtlCredit1.MainTabId = 1;//rowid
                                    objEntityDtlCredit1.LedgerId = Convert.ToInt32(Bank);
                                    objEntityDtlCredit1.LedgerTotAmnt = Convert.ToDecimal(ChequeAmnt);

                                    objEntityPerfomListJrnl.Add(objEntityDtlCredit1);

                                    //------------add clearance----------
                                    objEntityDtlDebit1.TabMode = 1;//credit
                                    objEntityDtlDebit1.MainTabId = 2;//rowid
                                    objEntityDtlDebit1.LedgerId = Convert.ToInt32(Clearance);
                                    objEntityDtlDebit1.LedgerTotAmnt = Convert.ToDecimal(ChequeAmnt);

                                    objEntityPerfomListJrnl.Add(objEntityDtlDebit1);

                                    ObjEntityRequestJrnl.JournalTotAmnt = Convert.ToDecimal(ChequeAmnt);

                                    if (Method == "2") //=> income to party
                                    {
                                        //------------add party----------
                                        objEntityDtlCredit2.TabMode = 0;//debit
                                        objEntityDtlCredit2.MainTabId = 3;//rowid
                                        objEntityDtlCredit2.LedgerId = Convert.ToInt32(Party);
                                        objEntityDtlCredit2.LedgerTotAmnt = Convert.ToDecimal(ChequeAmnt);

                                        objEntityPerfomListJrnl.Add(objEntityDtlCredit2);

                                        //------------add expense/incm----------
                                        objEntityDtlDebit2.TabMode = 1;//credit
                                        objEntityDtlDebit2.MainTabId = 4;//rowid
                                        objEntityDtlDebit2.LedgerId = Convert.ToInt32(ExpIncm);
                                        objEntityDtlDebit2.LedgerTotAmnt = Convert.ToDecimal(ChequeAmnt);

                                        objEntityPerfomListJrnl.Add(objEntityDtlDebit2);

                                        ObjEntityRequestJrnl.JournalTotAmnt = 2 * Convert.ToDecimal(ChequeAmnt);
                                    }
                                }

                            }

                            ObjEntityRequestJrnl.User_Id = objEntity_Cheque.User_Id;

                            int intflag = 0;
                            objEntity_Cheque.Status = Convert.ToInt32(TransType);
                            DataTable dtCheck = objBusiness_Cheque.Read_Cheque_Dtls_Payment(objEntity_Cheque);
                            if (dtCheck.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dtCheck.Rows[0][0].ToString()) > 0)
                                {
                                    intflag++;
                                    strRets[0] = "Payment";
                                }
                            }

                            if (intflag == 0)
                            {
                                objBussinessPaymentJrnl.AddJournalDtls(ObjEntityRequestJrnl, objEntityPerfomListJrnl, objEntityPerfomListGrpsJrnl);
                                
                                string strRandom = objCommon.Random_Number();
                                string strId = ObjEntityRequestJrnl.JournalId.ToString();
                                int intIdLength = ObjEntityRequestJrnl.JournalId.ToString().Length;
                                string stridLength = intIdLength.ToString("00");
                                string Id = stridLength + strId + strRandom;
                                strRets[0] = Id;


                                DataTable dtPaymnt = objBussinessPaymentJrnl.ReadJournalDtlsById(ObjEntityRequestJrnl);
                                if (dtPaymnt.Rows.Count > 0)
                                {
                                    strRets[1] = dtPaymnt.Rows[0]["JURNL_REF"].ToString();
                                }

                            }
                        }

                    }

                }


            }
        }
        catch
        {
            strRets[0] = "failed";
        }
        return strRets;
    }

    [WebMethod]
    public static string[] CancelMemoReason(string strmemotId, string reasonmust, string usrId, string cnclRsn, string strCorpID, string strOrgIdID)
    {
        string[] strRets = new string[3];
        clsEntity_Debit_Note ObjEntityCredit = new clsEntity_Debit_Note();
        cls_Business_Debit_Note objBussinessCredit = new cls_Business_Debit_Note();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        strRets[0] = "successcncl";
        string strRandomMixedId = strmemotId;
        string id = strRandomMixedId;
        string strLenghtofId = strRandomMixedId.Substring(0, 2);
        int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strId = strRandomMixedId.Substring(2, intLenghtofId);
        ObjEntityCredit.Debit_Id = Convert.ToInt32(strId);
        ObjEntityCredit.User_Id = Convert.ToInt32(usrId);

        if (reasonmust == "1")
        {
            ObjEntityCredit.CancelReason = cnclRsn;
        }

        else
        {
            ObjEntityCredit.CancelReason = objCommon.CancelReason();
        }

        try
        {
            DataTable dt = objBussinessCredit.CheckCreditNoteCnclSts(ObjEntityCredit);
            if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "0")
            {
                objBussinessCredit.CancelCreditNote(ObjEntityCredit);
            }
            else if (dt.Rows[0][0].ToString() != "")
            {
                strRets[0] = "UpdCancl";
            }
            else
            {
                strRets[0] = "CnfCancl";
            }

           
        }
        catch
        {
            strRets[0] = "failed";
        }
        return strRets;
    }
    
    protected void btnReopen1_Click(object sender, EventArgs e)
    {
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        string strRets = "successReopen";
       
        if (Session["USERID"] != null)
        {
            objEntity_Cheque.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_Cheque.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity_Cheque.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        try
        {
            objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(HiddenPostdatedChequeId.Value);
            objEntity_Cheque.ConfirmStatus = 1;

            DataTable dt = objBusiness_Cheque.Read_PostDatedChequeByID(objEntity_Cheque);
            if (dt.Rows.Count > 0)
            {
                objEntity_Cheque.TotalAmount = Convert.ToDecimal(dt.Rows[0]["PST_CHEQUE_AMOUNT"].ToString());
                objEntity_Cheque.TransactionType = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString());
                objEntity_Cheque.PartId = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_PARTY_LDGR_ID"].ToString());
                objEntity_Cheque.ClearanceLedger = Convert.ToInt32(dt.Rows[0]["PST_CHEQUE_CLRNC_LDGRID"].ToString());
                if (dt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString() == "0")
                {
                    if (dt.Rows[0]["PURCHS_ID"].ToString() != "")
                    {
                        objEntity_Cheque.PurchaseId = Convert.ToInt32(dt.Rows[0]["PURCHS_ID"].ToString());
                    }
                }
                else
                {
                    if (dt.Rows[0]["SALES_ID"].ToString() != "")
                    {
                        objEntity_Cheque.SalesId = Convert.ToInt32(dt.Rows[0]["SALES_ID"].ToString());
                    }
                }
                ////0039

                if (dt.Rows[0]["PST_CHEQUE_REOPEN_USR_ID"].ToString() != "" && dt.Rows[0]["PST_CHEQUE_CONFIRM_STATUS"].ToString() == "0")
                {
                    //Response.Redirect("fms_Postdated_Cheque_List.aspx?InsUpd=Allconfirm");
                    //if (strRets == "Alreadyreopen")
                    //    Response.Redirect("fms_Postdated_Cheque_List.aspx");
                    Response.Redirect("fms_Postdated_Cheque_List.aspx?InsUpd=AllreadyReop");


                }
                else
                {
                    objBusiness_Cheque.Reopen_list(objEntity_Cheque);
                    Response.Redirect("fms_Postdated_Cheque_List.aspx?InsUpd=Reopens");
                    //if (strRets == "successReopen")
                    //    Response.Redirect("fms_Postdated_Cheque_List.aspx");
                }
                //end
            }
        }
        catch (Exception ex)
        {
            //strRets = "failed";
            //Response.Redirect("fms_Postdated_Cheque.aspx");
        }
        //if (Session["REOPEN_STS"] == "Alreadyreopen")
        //    Response.Redirect("Purchase_Master_List.aspx?InsUpd=AlreadyConfirm");
           // Response.Redirect("fms_Postdated_Cheque_List.aspx");

       
    }

    [WebMethod]
    //0039
    public static string printReceiptDetails(string strId, string UsrName, string strOrgIdID, string strCorpID, string crncyAbrvt, string crncyId)
    {
        //string strRandomMixedId = strId;
        //string strLenghtofId = strRandomMixedId.Substring(0, 2);
        //int intLenghtofId = Convert.ToInt16(strLenghtofId);
        string strrId = strId;

        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        string PreparedBy = "";

        if (UsrName != "")
        {
            PreparedBy = UsrName;
        }

        FMS_FMS_Master_fms_Postdated_Cheque_fms_Postdated_Cheque objPage = new FMS_FMS_Master_fms_Postdated_Cheque_fms_Postdated_Cheque();

        string CheckedBy = "";
        if (strCorpID != null)
        {
            objEntity_Cheque.Corporate_id = Convert.ToInt32(strCorpID);
            objEntityCommon.CorporateID = Convert.ToInt32(strCorpID);
        }
        if (strOrgIdID != null)
        {
            objEntity_Cheque.Organisation_id = Convert.ToInt32(strOrgIdID);
        }

        //0039
        objEntity_Cheque.PostDatedChequeId = Convert.ToInt32(strrId);
        DataTable dtforprnnt = objBusiness_Cheque.Read_PostDatedChequeByID(objEntity_Cheque);
        DataTable dtLDGRdTLS = objBusiness_Cheque.Read_Cheque_Dtls_ById(objEntity_Cheque);
        //end

        int TransctnType = Convert.ToInt32(dtforprnnt.Rows[0]["PST_CHEQUE_TRANSACTION_TYPE"].ToString());

        DataTable dtCorp = objBusiness_Cheque.ReadCorpDtls(objEntity_Cheque);
        if (TransctnType == 0)
        {
            objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.PDC_PAYMENT);
        }
        else
        {
            objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.PDC_RECEIPT);
        }
        string strReturn = "";
        DataTable dtVersion = objBusiness.ReadPrintVersion(objEntityCommon);
        if (dtVersion.Rows.Count > 0)
        {
            if (dtVersion.Rows[0][0].ToString() == "1")
            {
                //strReturn = objPage.PdfPrintVersion1(dt, dtProduct, dtCorp, ObjEntityPayment);
                //strReturn = objBusiness_Cheque.PdfPrintVersion1(dtforprnnt, dtLDGRdTLS, dtCorp, objEntity_Cheque);
                strReturn = objBusiness_Cheque.PdfPrintVersion2And3(dtforprnnt, dtLDGRdTLS, dtCorp, objEntity_Cheque, 2, crncyAbrvt);
            }
            else if (dtVersion.Rows[0][0].ToString() == "2")
            {
                strReturn = objBusiness_Cheque.PdfPrintVersion2And3(dtforprnnt, dtLDGRdTLS, dtCorp, objEntity_Cheque, 2, crncyAbrvt);
                //strReturn = objPage.PdfPrintVersion2And3(dtforprnnt, dtLDGRdTLS, dtCorp, objEntity_Cheque, 2, dtPayment, crncyAbrvt, dtCost);
            }
            else if (dtVersion.Rows[0][0].ToString() == "3")
            {
                strReturn = objBusiness_Cheque.PdfPrintVersion2And3(dtforprnnt, dtLDGRdTLS, dtCorp, objEntity_Cheque, 3, crncyAbrvt);
            }
        }
        return strReturn;

    }
    //end
    [WebMethod]
    public static string LoadPartyLedger(string TranType, string intOrgID, string intCorrpID)
    {
        string result = "";
        DataTable dtChequeBook = new DataTable();
        if (TranType == "0")
        {
            clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
            clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
            if (intCorrpID != null && intCorrpID != "")
            {
                ObjEntityRequest.Corporate_id = Convert.ToInt32(intCorrpID);
            }
            if (intOrgID != null && intOrgID != "")
            {
                ObjEntityRequest.Organisation_id = Convert.ToInt32(intOrgID);
            }
            dtChequeBook = objBussiness.ReadLeadgerReceipt(ObjEntityRequest);          
        }
        else
        {
            clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();
            clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();
            if (intCorrpID != null && intCorrpID != "")
            {
                ObjEntityRequest.Corporate_id = Convert.ToInt32(intCorrpID);
            }
            if (intOrgID != null && intOrgID != "")
            {
                ObjEntityRequest.Organisation_id = Convert.ToInt32(intOrgID);
            }
            dtChequeBook = objBussiness.ReadLeadgerReceipt(ObjEntityRequest);
        }
      
        if (dtChequeBook.Rows.Count > 0)
        {
            dtChequeBook.TableName = "dtTableChequeBook";
            using (StringWriter sw = new StringWriter())
            {
                dtChequeBook.WriteXml(sw);
                result = sw.ToString();
            }
        }
        return result;
    }

    [WebMethod]
    public static string LoadInvoices(string CorpId, string OrgId, string TransactionType, string Party, string InvoiceId, string InvoiceRefrnc)
    {
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();

        objEntity_Cheque.Corporate_id = Convert.ToInt32(CorpId);
        objEntity_Cheque.Organisation_id = Convert.ToInt32(OrgId);
        objEntity_Cheque.TransactionType = Convert.ToInt32(TransactionType);
        objEntity_Cheque.PartId = Convert.ToInt32(Party);
        DataTable dt = objBusiness_Cheque.ReadSalesPurchase(objEntity_Cheque);

        bool contains = true;
        if (InvoiceId != "")
        {
            int intInvoiceId = Convert.ToInt32(InvoiceId);
            contains = dt.AsEnumerable().Any(row => intInvoiceId == row.Field<decimal>("PURCHS_ID"));
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("<option value=\"--SELECT--\" selected=\"true\">--SELECT--</option>");
        foreach (DataRow dtRow in dt.Rows)
        {
            sb.Append("<option value=\"" + dtRow["PURCHS_ID"].ToString() + "\">" + dtRow["PURCHS_REF"].ToString() + "</option>");
        }
        if (contains == false)
        {
            sb.Append("<option value=\"" + InvoiceId + "\">" + InvoiceRefrnc + "</option>");
        }

        return sb.ToString();
    }

    public void LoadExpIncmLdgrs()
    {
        clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntity_Cheque.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity_Cheque.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntity_Cheque.TransactionType = 0;
        DataTable dtExp = objBusiness_Cheque.ReadIncomeExpenses(objEntity_Cheque);

        if (dtExp.Rows.Count > 0)
        {
            ddlExp.DataSource = dtExp;
            ddlExp.DataTextField = "LDGR_NAME";
            ddlExp.DataValueField = "LDGR_ID";
            ddlExp.DataBind();
        }
        ddlExp.Items.Insert(0, "--SELECT--");


        objEntity_Cheque.TransactionType = 1;
        DataTable dtIncm = objBusiness_Cheque.ReadIncomeExpenses(objEntity_Cheque);

        if (dtIncm.Rows.Count > 0)
        {
            ddlIncm.DataSource = dtIncm;
            ddlIncm.DataTextField = "LDGR_NAME";
            ddlIncm.DataValueField = "LDGR_ID";
            ddlIncm.DataBind();
        }
        ddlIncm.Items.Insert(0, "--SELECT--");
    }


    [WebMethod]
    public static string CheckClrnceLdgrSlctn(string CorpId, string OrgId, string TransactionType)
    {
        string strReturn = "";

        //---Clearance Ledger---
        clsEntity_Account_Setting ObjEntityRequest = new clsEntity_Account_Setting();
        clsBusiness_Account_Setting objBussiness = new clsBusiness_Account_Setting();

        ObjEntityRequest.OrgId = Convert.ToInt32(OrgId);
        ObjEntityRequest.CorpId = Convert.ToInt32(CorpId);
        if (TransactionType == "0")
        {
            ObjEntityRequest.AsmodId = 7;
        }
        else if (TransactionType == "1")
        {
            ObjEntityRequest.AsmodId = 8;
        }
        ObjEntityRequest.LdgrGrpSts = 1;

        DataTable dt = objBussiness.ReadSelectedGrpOrLdgrLedger(ObjEntityRequest);
        if (dt.Rows.Count == 0)
        {
            strReturn = "ClearanceLedgerSelect";
        }
        else
        {
            strReturn = dt.Rows[0]["LDGR_ID"].ToString();
        }
        //---Clearance Ledger---

        return strReturn;
    }

    [WebMethod]
    public static string GetBalanceAmnt(string CorpId, string OrgId, string TransactionType, string Invoice)
    {
        string strReturn = "";

        if (TransactionType == "0")//purchase
        {
            clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
            clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();

            objEntityPurchase.CorpId = Convert.ToInt32(CorpId);
            objEntityPurchase.OrgId = Convert.ToInt32(OrgId);
            if (Invoice != "" && Invoice != "--SELECT--")
            {
                objEntityPurchase.PurchaseId = Convert.ToInt32(Invoice);
            }

            DataTable dt = objBusinesspurchase.ReadPurchaseById(objEntityPurchase);

            if (dt.Rows.Count > 0)
            {
                strReturn = dt.Rows[0]["PURCHS_BAL_AMT"].ToString();
            }
        }
        else if (TransactionType == "1")//sales
        {
            clsBusinessSales objBusinessSales = new clsBusinessSales();
            clsEntitySales ObjEntitySales = new clsEntitySales();

            ObjEntitySales.Corporate_id = Convert.ToInt32(CorpId);
            ObjEntitySales.Organisation_id = Convert.ToInt32(OrgId);
            if (Invoice != "" && Invoice != "--SELECT--")
            {
                ObjEntitySales.SalesId = Convert.ToInt32(Invoice);
            }

            DataTable dt = objBusinessSales.ReadSalesDetailsById(ObjEntitySales);

            if (dt.Rows.Count > 0)
            {
                strReturn = dt.Rows[0]["BALNC_AMT"].ToString();
            }
        }

        return strReturn;
    }


}