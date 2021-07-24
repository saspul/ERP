using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_Compzit;
using CL_Compzit;
using EL_Compzit;
using System.Data;
using System.Web.Services;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit.BusineesLayer_FMS;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web;
using System.Text;


public partial class FMS_FMS_Master_fms_Credit_Note_fms_Credit_Note : System.Web.UI.Page
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
        if (Session["FRMWRK_ID"] != null && Session["FRMWRK_ID"].ToString() == "2")
        {
            aHome.HRef = "/Home/Compzit_Home/Compzit_Home_Finance.aspx";
        }
        else
        {
            aHome.HRef = " /Home/Compzit_LandingPage/Compzit_LandingPage.aspx";
        }
        if (!IsPostBack)
        {
            btnPRint.Visible = false;
            btnFloatPRint.Visible = false;
            HiddenCostGroup1ddl.Value = "0";
            HiddenCostGroup2ddl.Value = "0";

            CostCenterLoad();
            CostGroup1Load();
            CostGroup2Load();
            LeadgerLoad();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntity_Credit_Note ObjEntityCredit = new clsEntity_Credit_Note();
            cls_Business_Credit_Note objBussinessCredit = new cls_Business_Credit_Note();
              clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
            clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();

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
                objEntityAudit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntityAccnt.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntityAudit.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityAccnt.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS

                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusinessLayer.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                HiddenRefAccountCls.Value = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
            }
           
            HiddenDateNow.Value = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
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
            int intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Credit_Note);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenFieldAcntCloseReopenSts.Value = "0";
            HiddenAuditCloseProvisionStatus.Value = "0";
            HiddenReOpenStatus.Value = "0";
            HiddenConfirmSts.Value = "0";
      

            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenConfirmSts.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenReOpenStatus.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        intAccntCloseReopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenAuditCloseProvisionStatus.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        HiddenFieldAcntCloseReopenSts.Value = "1";
                    }
                }
            }
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CREDIT_NOTE);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;

             
            string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);

           // objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Credit_Note);
            DataTable dtFormate = objBussinessCredit.readRefFormate(objEntityCommon);
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
                    if (flag == 1)
                    {
                        refFormatByDiv = "#COR#*/*#USR#";
                    }
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
                        //strRealFormat = strRealFormat + "/" + strNextId;

                        if (strRealFormat.Contains("#NUM#"))
                        {
                            strRealFormat = strRealFormat.Replace("#NUM#", strNextId);
                        }
                        else
                        {
                            strRealFormat = strRealFormat + "/" + strNextId;
                        }
                        //if (strRealFormat == "")
                        //{
                        //    strRealFormat = intOrgId.ToString() + "/" + intCorpId.ToString() + "/" + strNextId;
                        //}
                        strRealFormat = strRealFormat.Replace("#", "");
                        strRealFormat = strRealFormat.Replace("*", "");
                        strRealFormat = strRealFormat.Replace("%", "");


                    }
                    TxtRef.Value = strRealFormat;
                }
            }
            else
            {
                TxtRef.Value = strNextId;
            }
            if (Session["FINCYRID"] != null)
            {
                objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
            cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();

            int YearEndCls = 0;

            if (dtfinaclYear.Rows.Count > 0)
            {
                if (dtfinaclYear.Rows[0]["FINCYR_ID"].ToString() != "")
                {
                    HiddenFinancialYearId.Value = dtfinaclYear.Rows[0]["FINCYR_ID"].ToString();
                }

                DateTime curdate1 = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                objEntityAudit.FromDate =curdate1;
                objEntityAccnt.FromDate = curdate1;

                 DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objEntityCommon);
                 DataTable dtAuditClsDate = objBusinessAudit.Read_Audit_Close(objEntityAudit);

             

                if ((dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString() != "" && dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString() != ""))
                {
                    if (curdate1 > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate1 < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                       // txtdate.Value = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");

                    }

                    HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

                }

                if (dtAuditClsDate.Rows.Count > 0 && dtAcntClsDate.Rows.Count > 0)
                {
                    HiddenAuditClsDate.Value = dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString();
                    HiddenAcntClsDate.Value = dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString();
                    YearEndCls = Convert.ToInt32(dtAcntClsDate.Rows[0]["ACCNT_CLS_YEAREND_STS"].ToString());

                    if (HiddenAuditCloseProvisionStatus.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                    {
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
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
                            if (HiddenAuditCloseProvisionStatus.Value != "1")
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
                    string Ref = "";

                    if (curdate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        DateTime startDate = new DateTime();
                        if (HiddenStartDate.Value != "" && HiddenStartDate.Value != null)
                        {
                            startDate = objCommon.textToDateTime(HiddenStartDate.Value);
                        }
                        if (HiddenAuditCloseProvisionStatus.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {

                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                                clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
                               

                                objEntityAudit.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAudit.Corporate_id = intCorpId;
                                objEntityAudit.Organisation_id = intOrgId;

                                objEntityAccnt.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;

                                ObjEntityCredit.Date_From = objCommon.textToDateTime(txtdate.Value);
                                ObjEntityCredit.Corporate_id = intCorpId;
                                ObjEntityCredit.Organisation_id = intOrgId;
                                int SubRef = 1;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                DataTable dtAuditCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);
                                if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count>0)
                                {
                                    DataTable dtRefFormat1 = objBussinessCredit.ReadRefNumberByDate(ObjEntityCredit);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (Convert.ToInt32(dtRefFormat1.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString()) != 1)
                                        {
                                            strRef = dtRefFormat1.Rows[0]["CR_NOTE_REF"].ToString();
                                            strRef = strRef.TrimEnd('/');
                                            strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["CR_NOTE_REF"].ToString();
                                        }
                                        ObjEntityCredit.Reference_Num = strRef;
                                        DataTable dtRefFormat = objBussinessCredit.ReadRefNumberByDateLast(ObjEntityCredit);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["CR_NOTE_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString());
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
                            if (dtAuditClsDate.Rows.Count > 0 ||dtAuditClsDate.Rows.Count>0)
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
                else if (dtAuditClsDate.Rows.Count > 0)
                {
                    HiddenAuditClsDate.Value = dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString();
                    if (HiddenFieldAcntCloseReopenSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                    {
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    }
                    else
                    {
                        if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                        {
                            DateTime startDate = new DateTime();
                            if (dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString() != "" && dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString() != null)
                            {
                                startDate = objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());
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
                    }
                    DateTime curdate = objCommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    string Ref = "";

                    if (curdate > objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        DateTime startDate = new DateTime();
                        if (dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString() != "" && dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString() != null)
                        {
                            startDate = objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());
                        }
                        if (HiddenAuditCloseProvisionStatus.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {

                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                                clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
                               
                                objEntityAccnt.FromDate = objCommon.textToDateTime(txtdate.Value);

                                ObjEntityCredit.Date_From = objCommon.textToDateTime(txtdate.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                ObjEntityCredit.Corporate_id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                ObjEntityCredit.Organisation_id = intOrgId;

                                objEntityAudit.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAudit.Corporate_id = intCorpId;
                                objEntityAudit.Organisation_id = intOrgId;
                                int SubRef = 1;
                                 DataTable dtAuditCls = objBusinessAudit.CheckAuditClosingDate(objEntityAudit);

                                 if (dtAuditCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = objBussinessCredit.ReadRefNumberByDate(ObjEntityCredit);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (Convert.ToInt32(dtRefFormat1.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString()) != 1)
                                        {
                                            strRef = dtRefFormat1.Rows[0]["CR_NOTE_REF"].ToString();
                                            strRef = strRef.TrimEnd('/');
                                            strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["CR_NOTE_REF"].ToString();
                                        }
                                        ObjEntityCredit.Reference_Num = strRef;
                                        DataTable dtRefFormat = objBussinessCredit.ReadRefNumberByDateLast(ObjEntityCredit);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["CR_NOTE_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString());
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
                        if (objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                        {
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

                                objEntityAccnt.FromDate = objCommon.textToDateTime(txtdate.Value);

                                ObjEntityCredit.Date_From = objCommon.textToDateTime(txtdate.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                ObjEntityCredit.Corporate_id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                ObjEntityCredit.Organisation_id = intOrgId;
                                int SubRef = 1;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                if (dtAccntCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = objBussinessCredit.ReadRefNumberByDate(ObjEntityCredit);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (Convert.ToInt32(dtRefFormat1.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString()) != 1)
                                        {
                                            strRef = dtRefFormat1.Rows[0]["CR_NOTE_REF"].ToString();
                                            strRef = strRef.TrimEnd('/');
                                            strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["CR_NOTE_REF"].ToString();
                                        }
                                        ObjEntityCredit.Reference_Num = strRef;
                                        DataTable dtRefFormat = objBussinessCredit.ReadRefNumberByDateLast(ObjEntityCredit);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["CR_NOTE_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString());
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
                    HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                }


            }
            if (Request.QueryString["Id"] != null)
            {

                lblEntry.Text = "Edit Credit Note";
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenCreditId.Value = strId;
                bttnsave.Visible = false;
                btnFloatSave.Visible = false;
                bttnsaveclose.Visible = false;
                bttnFloatsaveclose.Visible = false;
                btnClear.Visible = false;
                ButtnFloatClear.Visible = false;
                btnUpdate.Visible = true;
                btnUpdatecls.Visible = true;
                btnFloatUpdate.Visible = true;
                btnFloatUpdatecls.Visible = true;

                btnCancel.Visible = true;
                intReopen = Convert.ToInt32(HiddenReOpenStatus.Value);
                Update(strId, intConfirm, intReopen, YearEndCls);

            }
            else if (Request.QueryString["ViewId"] != null)
            {

                lblEntry.Text = "View Credit Note";
               
                spandate.Attributes["style"] = "pointer-events:none;";
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenCreditId.Value = strId;
                bttnsave.Visible = false;
                btnFloatSave.Visible = false;
                bttnsaveclose.Visible = false;
                bttnFloatsaveclose.Visible = false;
                btnClear.Visible = false;
                ButtnFloatClear.Visible = false;
                
                btnUpdate.Visible = false;
                btnUpdatecls.Visible = false;
                btnFloatUpdate.Visible = false;
                btnFloatUpdatecls.Visible = false;
                
                btnConfirm.Visible = false;
                btnFloatConfirm.Visible = false;
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
                btnCancel.Visible = true;
                txtDescription.Disabled = true;
                intReopen = Convert.ToInt32(HiddenReOpenStatus.Value);
                View(strId, intConfirm, intReopen,YearEndCls);
            }
            else
            {

                lblEntry.Text = "Add Credit Note";
                btnUpdate.Visible = false;
                btnUpdatecls.Visible = false;
                btnFloatUpdate.Visible = false;
                btnFloatUpdatecls.Visible = false;
                btnConfirm.Visible = false;
                btnFloatConfirm.Visible = false;
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
              
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
                if (strInsUpd == "Confrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "SalesAmountExceeded")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SalesAmountExceeded", "SalesAmountExceeded();", true);
                }
                else if (strInsUpd == "SalesAmountFullySettld")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SalesAmountFullySettld", "SalesAmountFullySettld();", true);
                }
                else if (strInsUpd == "Reopen")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReoen", "SuccessReoen();", true);
                }
                
            }
            if (Request.QueryString["VId"] != null)
            {
                divList.Visible = false;
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
                btnCancel.Visible = false;
                btnFloatCancel.Visible = false;
                divLinkSection.Visible = false;
            }
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

    public void CostCenterLoad()
    {
        clsEntity_Credit_Note ObjEntityCredit = new clsEntity_Credit_Note();
        cls_Business_Credit_Note objBussinessCredit = new cls_Business_Credit_Note();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityCredit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityCredit.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityCredit.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        DataTable dtLedger = objBussinessCredit.ReadCostCenter(ObjEntityCredit);


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
        clsEntity_Credit_Note ObjEntityCredit = new clsEntity_Credit_Note();
        cls_Business_Credit_Note objBussinessCredit = new cls_Business_Credit_Note();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityCredit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/ADMIN/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityCredit.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/ADMIN/Default.aspx");
        }
        DataTable dtLedger = objBussinessCredit.ReadLeadger(ObjEntityCredit);

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
    public class clsLedgrData
    {
        public string TABMODE { get; set; }
        public string MAINTABID { get; set; }
        public string LEDGRTABID { get; set; }
        public string LEDGRID { get; set; }
        public string LEDGRAMNT { get; set; }
        public string LEDGERSTATUS { get; set; }
        public string REMARKS { get; set; }
        public string TBL_ID { get; set; }
          
        
    }
    public class clsCostCntrData
    {
        public string TABMODE { get; set; }
        public string MAINTABID { get; set; }
        public string SUBTABID { get; set; }
        public string COSTCENTRTABID { get; set; }
        public string COSTCENTRID { get; set; }
        public string COSTCENTRAMNT { get; set; }
        public string COSTGRPID_ONE { get; set; }
        public string COSTGRPID_TWO { get; set; }
    }
    public class clsSaleData
    {
        public string TABMODE { get; set; }
        public string MAINTABID { get; set; }
        public string SALEID { get; set; }
        public string SALEAMNT { get; set; }
        public string SALEAMNT_ACT { get; set; }

    }
    protected void bttnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntity_Credit_Note ObjEntityCredit = new clsEntity_Credit_Note();
        cls_Business_Credit_Note objBussinessCredit = new cls_Business_Credit_Note();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityCredit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        if (Session["ORGID"] != null)
        {
            ObjEntityCredit.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityCredit.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        ObjEntityCredit.Reference_Num = TxtRef.Value.ToUpper().Trim();
        ObjEntityCredit.Credit_Date = objCommon.textToDateTime(txtdate.Value);
        ObjEntityCredit.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);



        if (txtDescription.Value.Trim() != "")
        {
            ObjEntityCredit.Description = txtDescription.Value.Trim();
        }
        ObjEntityCredit.Credit_Total = Convert.ToDecimal(HiddenFieldTotAmnt.Value);
        List<clsEntity_Credit_Note> objEntitylLedgrList = new List<clsEntity_Credit_Note>();
        List<clsEntity_Credit_Note> objEntityCostcentrList = new List<clsEntity_Credit_Note>();
        List<clsEntity_Credit_Note> objEntitySaleList = new List<clsEntity_Credit_Note>();
        string jsonData = HiddenLedgerDtls.Value;
        string c = jsonData.Replace("\"{", "\\{");
        string d = c.Replace("\\n", "\r\n");
        string g = d.Replace("\\", "");
        string h = g.Replace("}\"]", "}]");
        string i = h.Replace("}\",", "},");
        List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
        objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);


        if (HiddenLedgerDtls.Value != "" && HiddenLedgerDtls.Value != null)
        {
            foreach (clsLedgrData objclsTVData in objTVDataList5)
            {
                clsEntity_Credit_Note objEntityDtl = new clsEntity_Credit_Note();
                objEntityDtl.Credit_debit_Status = Convert.ToInt32(objclsTVData.TABMODE);
                objEntityDtl.Ledger_Credit_Id = Convert.ToInt32(objclsTVData.MAINTABID);
                // objEntityDtl.JournalId = objEntityLayerStock.JournalId;
                objEntityDtl.LedgerId = Convert.ToInt32(objclsTVData.LEDGRID);
                objEntityDtl.Ledger_Amount = Convert.ToDecimal(objclsTVData.LEDGRAMNT);
               // objEntityDtl.Remarks = objclsTVData.REMARKS;
                if (Request.Form["TxtRemark" + objclsTVData.TBL_ID] != "")
                {
                    objEntityDtl.Remarks = Request.Form["TxtRemark" + objclsTVData.TBL_ID];
                }
                objEntitylLedgrList.Add(objEntityDtl);
            }
        }

        jsonData = HiddenCostCentreDtls.Value;
        c = jsonData.Replace("\"{", "\\{");
        d = c.Replace("\\n", "\r\n");
        g = d.Replace("\\", "");
        h = g.Replace("}\"]", "}]");
        i = h.Replace("}\",", "},");
        List<clsCostCntrData> objTVDataList6 = new List<clsCostCntrData>();
        objTVDataList6 = JsonConvert.DeserializeObject<List<clsCostCntrData>>(i);
        if (HiddenCostCentreDtls.Value != "" && HiddenCostCentreDtls.Value != null)
        {
            foreach (clsCostCntrData objclsTVData in objTVDataList6)
            {
                if (objclsTVData.COSTCENTRAMNT != "" && objclsTVData.COSTCENTRID != "" && objclsTVData.COSTCENTRID != "-Select Cost Center-")
                {
                    clsEntity_Credit_Note objEntityDtl = new clsEntity_Credit_Note();
                    objEntityDtl.Ledger_Credit_Id = Convert.ToInt32(objclsTVData.MAINTABID);
                    objEntityDtl.Cost_Centre_Id = Convert.ToInt32(objclsTVData.COSTCENTRID);
                    objEntityDtl.Cost_Centre_Amt = Convert.ToDecimal(objclsTVData.COSTCENTRAMNT);
                    objEntityDtl.CostGrp1Id = Convert.ToInt32(objclsTVData.COSTGRPID_ONE);
                    objEntityDtl.CostGrp2Id = Convert.ToInt32(objclsTVData.COSTGRPID_TWO);
                    objEntityCostcentrList.Add(objEntityDtl);
                }
            }
        }
        jsonData = HiddenSaleDtls.Value;
        c = jsonData.Replace("\"{", "\\{");
        d = c.Replace("\\n", "\r\n");
        g = d.Replace("\\", "");
        h = g.Replace("}\"]", "}]");
        i = h.Replace("}\",", "},");
        List<clsSaleData> objSaleDataList = new List<clsSaleData>();
        objSaleDataList = JsonConvert.DeserializeObject<List<clsSaleData>>(i);
        if (HiddenSaleDtls.Value != "" && HiddenSaleDtls.Value != null)
        {
            foreach (clsSaleData objclsTVData in objSaleDataList)
            {
                if (objclsTVData.SALEAMNT != "" && objclsTVData.SALEID != "")
                {
                    clsEntity_Credit_Note objEntitySaleDtl = new clsEntity_Credit_Note();
                    objEntitySaleDtl.Ledger_Credit_Id = Convert.ToInt32(objclsTVData.MAINTABID);
                    objEntitySaleDtl.Cost_Centre_Id = Convert.ToInt32(objclsTVData.SALEID);
                    objEntitySaleDtl.Cost_Centre_Amt = Convert.ToDecimal(objclsTVData.SALEAMNT);
                    objEntitySaleDtl.ReceiptActAmount = Convert.ToDecimal(objclsTVData.SALEAMNT_ACT);
                    objEntitySaleList.Add(objEntitySaleDtl);
                }
            }
        }
        
        int AcntCloseSts = AccountCloseCheck(txtdate.Value);
        int AuditCloseSts = AuditCloseCheck(txtdate.Value);


        if (AuditCloseSts == 1 && HiddenAuditCloseProvisionStatus.Value != "1")
        {
            Response.Redirect("fms_Credit_Note_List.aspx?InsUpd=AuditClosed");
        }
        else if (AuditCloseSts == 1 && HiddenAuditCloseProvisionStatus.Value == "1")
        {

        }

        else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
        {
            Response.Redirect("fms_Credit_Note_List.aspx?InsUpd=AcntClosed");
        }


      //  objBussinessCredit.AddCreditNote(ObjEntityCredit, objEntitylLedgrList, objEntityCostcentrList);
        objBussinessCredit.AddCreditNote(ObjEntityCredit, objEntitylLedgrList, objEntityCostcentrList, objEntitySaleList);
        if (clickedButton.ID == "bttnsave")
        {

            Response.Redirect("fms_Credit_Note.aspx?InsUpd=Ins");
        }
        else if (clickedButton.ID == "btnFloatSave")
        {
            Response.Redirect("fms_Credit_Note.aspx?InsUpd=Ins");
        }
        else if (clickedButton.ID == "bttnsaveclose")
        {
            Response.Redirect("fms_Credit_Note_List.aspx?InsUpd=Ins");

        }
        else if (clickedButton.ID == "bttnFloatsaveclose")
        {
            Response.Redirect("fms_Credit_Note_List.aspx?InsUpd=Ins");

        }
    }

    public void Update(string strP_Id, int intConfirm, int intReopen,int YearEndCls)
    {
        clsEntity_Credit_Note ObjEntityCredit = new clsEntity_Credit_Note();
        cls_Business_Credit_Note objBussinessCredit = new cls_Business_Credit_Note();
        clsCommonLibrary objCommon=new clsCommonLibrary();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityCredit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityCredit.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityCredit.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        ObjEntityCredit.Credit_Id = Convert.ToInt32(strP_Id);
       // HiddenCreditID.Value = strP_Id;
        DataTable dt = objBussinessCredit.ReadCreditNote_By_ID(ObjEntityCredit);
        DataTable dtLDGRdTLS = objBussinessCredit.ReadCreditNote_Ledger_By_ID(ObjEntityCredit);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
            {
                hiddenDfltCurrencyMstrId.Value = dt.Rows[0]["CRNCMST_ID"].ToString();
            }
            if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
            {
                HiddenCurrencyAbrv.Value = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
            int AcntCloseSts = AccountCloseCheck(dt.Rows[0]["CR_NOTE_DATE"].ToString());
            int  AuditCloseSts=AuditCloseCheck(dt.Rows[0]["CR_NOTE_DATE"].ToString());
            btnPRint.Visible = true;
            btnFloatPRint.Visible = true;
            if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() == "0")
            {
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
                btnPRint.Text = "Draft Print";

                btnFloatPRint.Text = "Draft Print";
                if(HiddenConfirmSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                {
                   

                }
               
            }
            if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() == "1")
            {
                spandate.Attributes["style"] = "pointer-events:none;";
                lblEntry.Text = "View Credit Note";
                btnConfirm.Visible = false;
                btnFloatConfirm.Visible = false;
                btnUpdate.Visible = false;
                btnUpdatecls.Visible = false;
                btnFloatUpdate.Visible = false;
                btnFloatUpdatecls.Visible = false;

                if (HiddenReOpenStatus.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                {



                    if (AuditCloseSts == 1 && HiddenAuditCloseProvisionStatus.Value == "1")
                    {
                        btnReopen.Visible = true;
                        btnFloatReopen.Visible = true;
                    }
                    else if (AuditCloseSts == 1 && HiddenAuditCloseProvisionStatus.Value != "1")
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
                    btnFloatReopen.Visible = true;
                }
              View(strP_Id, intConfirm, intReopen,YearEndCls);


              if (dt.Rows[0]["CNT_VCHR"].ToString() != "0")
              {
                  btnReopen.Visible = false;
                  btnFloatReopen.Visible = false;
              }
            }


            //else if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() == "0" && AcntCloseSts == 1 && (HiddenFieldAcntCloseReopenSts.Value != "" && HiddenFieldAcntCloseReopenSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString()))
            //{
            //    btnConfirm.Visible = false;
            //    btnUpdate.Visible = false;
            //    btnReopen.Visible = false;
            //    View(strP_Id, intConfirm, intReopen);
            //}
            //else
            //{
                if (intConfirm == 0)
                {
                    btnConfirm.Visible = false;
                    btnFloatConfirm.Visible = false;
                }
                //btnReopen.Visible = false;
                if (dt.Rows[0]["CR_NOTE_REF"].ToString() != "")
                {
                    TxtRef.Value = dt.Rows[0]["CR_NOTE_REF"].ToString();
                    HiddenUpdRefNum.Value = dt.Rows[0]["CR_NOTE_REF"].ToString(); 
                }
                if (dt.Rows[0]["CR_NOTE_REF_NEXTNUM"].ToString() != "")
                {
                    HiddenSequenceNum.Value = dt.Rows[0]["CR_NOTE_REF_NEXTNUM"].ToString();
                }

                if (dt.Rows[0]["CR_NOTE_DATE"].ToString() != "")
                {
                    txtdate.Value = dt.Rows[0]["CR_NOTE_DATE"].ToString();
                    HiddenUpdatedDate.Value = dt.Rows[0]["CR_NOTE_DATE"].ToString();
                    ObjEntityCredit.UpdCredit_date=objCommon.textToDateTime(dt.Rows[0]["CR_NOTE_DATE"].ToString());
                }

                int precision = Convert.ToInt32(hiddenDecimalCount.Value);
                string format = String.Format("{{0:N{0}}}", precision);
                // if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                //  {
                if (dt.Rows[0]["CR_NOTE_TOTAL"].ToString() != "")
                {
                    decimal DecAmntTot = 0;
                    if (dt.Rows[0]["CR_NOTE_TOTAL"].ToString() != "")
                    {
                        DecAmntTot = Convert.ToDecimal(dt.Rows[0]["CR_NOTE_TOTAL"].ToString());
                    }
                    string valuestringTot = String.Format(format, DecAmntTot);
                    lblTotDeb.Value = valuestringTot + " " + HiddenCurrencyAbrv.Value;
                    lblTotCrdt.Value = valuestringTot + " " + HiddenCurrencyAbrv.Value;
                    HiddenGrdTotl.Value = valuestringTot;
                }

                //   }


                if (dt.Rows[0]["CR_NOTE_NARRATION"].ToString() != "")
                {
                    txtDescription.Value = dt.Rows[0]["CR_NOTE_NARRATION"].ToString();

                }
           // }
        }

        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("CREDIT_NOTE_ID", typeof(int));
        dtDetail.Columns.Add("LDGR_CR_ID", typeof(int));
        dtDetail.Columns.Add("LDGR_ID", typeof(int));
        dtDetail.Columns.Add("LDGR_CR_AMT", typeof(string));
        dtDetail.Columns.Add("LDGR_NAME", typeof(string));
        dtDetail.Columns.Add("LDGR_REMARKS", typeof(string));

        dtDetail.Columns.Add("CST_CNTR_CR_ID", typeof(int));
        dtDetail.Columns.Add("COSTCNTR_ID", typeof(string));
        dtDetail.Columns.Add("SALES_ID", typeof(string));
        
        dtDetail.Columns.Add("CST_CNTR_CR_AMOUNT", typeof(string));
        dtDetail.Columns.Add("LDGR_CR_DR_CR_STATUS", typeof(string));
        string NewRev = "";
       
        int first = 0;

        for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
        {
            DataRow drDtl = dtDetail.NewRow();
            drDtl["CREDIT_NOTE_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["CREDIT_NOTE_ID"].ToString());
            drDtl["LDGR_CR_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_CR_ID"].ToString());
            drDtl["LDGR_CR_DR_CR_STATUS"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_CR_DR_CR_STATUS"].ToString());


            int revflg = 0;
            string[] newRev1 = NewRev.Split(',');
            for (int i = 0; i < newRev1.Length; i++)
            {
                if (newRev1[i] != dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString())
                {
                    revflg = 0;
                }
                else
                {
                    revflg = 1;
                    break;
                }
            }
            if (revflg == 0)
            {


                drDtl["LDGR_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                NewRev = NewRev + "," + dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString();
                first = 1;
                for (int intCountinn = 0; intCountinn < dtLDGRdTLS.Rows.Count; intCountinn++)
                {
                    if (dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString() == dtLDGRdTLS.Rows[intCountinn]["LDGR_ID"].ToString())
                    {
                        if (first == 1)
                        {
                            if (dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["CST_CNTR_CR_AMOUNT"].ToString() != "")
                            {

                                string costGrp1 = "0";
                                string costGrp2 = "0";
                                if (dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString() != "")
                                {
                                    costGrp1 = dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString();
                                }
                                if (dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString() != "")
                                {
                                    costGrp2 = dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString();
                                }


                                if (dtLDGRdTLS.Rows[intCountinn]["CST_CNTR_CR_AMOUNT"].ToString() != "")
                                {
                                    drDtl["CST_CNTR_CR_AMOUNT"] = dtLDGRdTLS.Rows[intCountinn]["CST_CNTR_CR_AMOUNT"].ToString();
                                }
                                if (dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() != "")
                                {
                                    drDtl["COSTCNTR_ID"] = dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() + "%" + drDtl["CST_CNTR_CR_AMOUNT"] + "%" + costGrp1 + "%" + costGrp2;
                                }
                                first++;
                            }
                            if (dtLDGRdTLS.Rows[intCountinn]["SALES_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["CST_CNTR_CR_AMOUNT"].ToString() != "")
                            {
                                if (dtLDGRdTLS.Rows[intCountinn]["CST_CNTR_CR_AMOUNT"].ToString() != "")
                                {
                                    drDtl["CST_CNTR_CR_AMOUNT"] = dtLDGRdTLS.Rows[intCountinn]["CST_CNTR_CR_AMOUNT"].ToString();
                                }
                                if (dtLDGRdTLS.Rows[intCountinn]["SALES_ID"].ToString() != "")
                                {
                                    //drDtl["SALES_ID"] = dtLDGRdTLS.Rows[intCountinn]["SALES_ID"].ToString() + "%" + drDtl["CST_CNTR_CR_AMOUNT"];
                                      drDtl["SALES_ID"] = dtLDGRdTLS.Rows[intCountinn]["SALES_ID"].ToString() + "%" + drDtl["CST_CNTR_CR_AMOUNT"] + "%" + dtLDGRdTLS.Rows[intCountinn]["BALNC_AMT"].ToString();
                                }

                                first++;
                            }


                        }
                        else
                        {
                            string costGrp1 = "0";
                            string costGrp2 = "0";


                            if (dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString() != "")
                            {
                                costGrp1 = dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString();
                            }
                            if (dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString() != "")
                            {
                                costGrp2 = dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString();
                            }

                            if (dtLDGRdTLS.Rows[intCountinn]["CST_CNTR_CR_AMOUNT"].ToString() != "")
                            {
                                drDtl["CST_CNTR_CR_AMOUNT"] = dtLDGRdTLS.Rows[intCountinn]["CST_CNTR_CR_AMOUNT"].ToString();
                            }
                            if (dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() != "")
                            {
                                drDtl["COSTCNTR_ID"] = drDtl["COSTCNTR_ID"] + "$" + dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() + "%" + drDtl["CST_CNTR_CR_AMOUNT"] + "%" + costGrp1 + "%" + costGrp2;
                            }
                            if (dtLDGRdTLS.Rows[intCountinn]["SALES_ID"].ToString() != "")
                            {
                              //  drDtl["SALES_ID"] = drDtl["SALES_ID"] + "$" + dtLDGRdTLS.Rows[intCountinn]["SALES_ID"].ToString() + "%" + drDtl["CST_CNTR_CR_AMOUNT"];
                                drDtl["SALES_ID"] = drDtl["SALES_ID"] + "$" + dtLDGRdTLS.Rows[intCountinn]["SALES_ID"].ToString() + "%" + drDtl["CST_CNTR_CR_AMOUNT"] + "%" + dtLDGRdTLS.Rows[intCountinn]["BALNC_AMT"].ToString();
                            }
                        }
                    }
                }
                //}
                //else
                //{
                //    drDtl["LDGR_ID"] = 0;
                //}
                drDtl["LDGR_CR_AMT"] = dtLDGRdTLS.Rows[intCount]["LDGR_CR_AMT"].ToString();

                if (dtLDGRdTLS.Rows[intCount]["LDGR_NAME"].ToString() != "")
                {
                    drDtl["LDGR_NAME"] = dtLDGRdTLS.Rows[intCount]["LDGR_NAME"].ToString();
                }
                else
                {
                    drDtl["LDGR_NAME"] = "";
                }

                drDtl["LDGR_REMARKS"] = dtLDGRdTLS.Rows[intCount]["LDGR_CR_REMRKS"].ToString();
                if (dtLDGRdTLS.Rows[intCount]["CST_CNTR_CR_ID"].ToString() != "")
                {
                    drDtl["CST_CNTR_CR_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["CST_CNTR_CR_ID"].ToString());
                }
                dtDetail.Rows.Add(drDtl);
            }
        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenEdit.Value = strJson;

        if (YearEndCls == 1)
        {
            btnReopen.Visible = false;
            btnFloatReopen.Visible = false;
        }

    }

    public void View(string strP_Id, int intConfirm, int intReopen, int YearEndCls)
    {
        HiddenView.Value = "1";
        clsEntity_Credit_Note ObjEntityCredit = new clsEntity_Credit_Note();
        cls_Business_Credit_Note objBussinessCredit = new cls_Business_Credit_Note();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityCredit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntityCredit.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            ObjEntityCredit.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        ObjEntityCredit.Credit_Id = Convert.ToInt32(strP_Id);
        DataTable dt = objBussinessCredit.ReadCreditNote_By_ID(ObjEntityCredit);
        DataTable dtLDGRdTLS = objBussinessCredit.ReadCreditNote_Ledger_By_ID(ObjEntityCredit);
        if (dt.Rows.Count > 0)
        {

            if (dt.Rows[0]["CR_NOTE_CNCL_ID"].ToString() == "" && dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() != "1")
                {
                    btnPRint.Text = "Draft Print";
                    btnFloatPRint.Text = "Draft Print";

                    btnPRint.Visible = true;
                    btnFloatPRint.Visible = true;
                }


             


              //  btnReopen.Visible = false;
                if (dt.Rows[0]["CR_NOTE_REF"].ToString() != "")
                {
                    TxtRef.Value = dt.Rows[0]["CR_NOTE_REF"].ToString();
                }


                if (dt.Rows[0]["CR_NOTE_DATE"].ToString() != "")
                {
                    txtdate.Value = dt.Rows[0]["CR_NOTE_DATE"].ToString();
                }

                int precision = Convert.ToInt32(hiddenDecimalCount.Value);
                string format = String.Format("{{0:N{0}}}", precision);
                // if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
                //  {
                if (dt.Rows[0]["CR_NOTE_TOTAL"].ToString() != "")
                {
                    decimal DecAmntTot = 0;
                    if (dt.Rows[0]["CR_NOTE_TOTAL"].ToString() != "")
                    {
                        DecAmntTot = Convert.ToDecimal(dt.Rows[0]["CR_NOTE_TOTAL"].ToString());
                    }
                    string valuestringTot = String.Format(format, DecAmntTot);
                    lblTotDeb.Value = valuestringTot + " " + HiddenCurrencyAbrv.Value; 
                    lblTotCrdt.Value = valuestringTot + " " + HiddenCurrencyAbrv.Value;
                    //lblTotDeb.Value = valuestringTot;
                    //lblTotCrdt.Value = valuestringTot;
                    HiddenGrdTotl.Value = valuestringTot;
                }

                //   }


                if (dt.Rows[0]["CR_NOTE_NARRATION"].ToString() != "")
                {
                    txtDescription.Value = dt.Rows[0]["CR_NOTE_NARRATION"].ToString();

                }
            
        }

        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("CREDIT_NOTE_ID", typeof(int));
        dtDetail.Columns.Add("LDGR_CR_ID", typeof(int));
        dtDetail.Columns.Add("LDGR_ID", typeof(int));
        dtDetail.Columns.Add("LDGR_CR_AMT", typeof(string));
        dtDetail.Columns.Add("LDGR_NAME", typeof(string));
        dtDetail.Columns.Add("LDGR_REMARKS", typeof(string));

        dtDetail.Columns.Add("CST_CNTR_CR_ID", typeof(int));
        dtDetail.Columns.Add("COSTCNTR_ID", typeof(string));
        dtDetail.Columns.Add("CST_CNTR_CR_AMOUNT", typeof(string));
        dtDetail.Columns.Add("LDGR_CR_DR_CR_STATUS", typeof(string));
        string NewRev = "";

        int first = 0;

        for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
        {
            DataRow drDtl = dtDetail.NewRow();
            drDtl["CREDIT_NOTE_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["CREDIT_NOTE_ID"].ToString());
            drDtl["LDGR_CR_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_CR_ID"].ToString());
            drDtl["LDGR_CR_DR_CR_STATUS"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_CR_DR_CR_STATUS"].ToString());


            int revflg = 0;
            string[] newRev1 = NewRev.Split(',');
            for (int i = 0; i < newRev1.Length; i++)
            {
                if (newRev1[i] != dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString())
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
                NewRev = NewRev + "," + dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString();
                first = 1;
                for (int intCountinn = 0; intCountinn < dtLDGRdTLS.Rows.Count; intCountinn++)
                {
                    if (dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString() == dtLDGRdTLS.Rows[intCountinn]["LDGR_ID"].ToString())
                    {
                        string costGrp1 = "0";
                        string costGrp2 = "0";


                        if (dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString() != "")
                        {
                            costGrp1 = dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString();
                        }
                        if (dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString() != "")
                        {
                            costGrp2 = dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString();
                        }



                        if (first == 1)
                        {
                            if (dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["CST_CNTR_CR_AMOUNT"].ToString() != "")
                            {
                                if (dtLDGRdTLS.Rows[intCountinn]["CST_CNTR_CR_AMOUNT"].ToString() != "")
                                {
                                    drDtl["CST_CNTR_CR_AMOUNT"] = dtLDGRdTLS.Rows[intCountinn]["CST_CNTR_CR_AMOUNT"].ToString();
                                }
                                if (dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() != "")
                                {
                                    drDtl["COSTCNTR_ID"] = dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() + "%" + drDtl["CST_CNTR_CR_AMOUNT"] + "%" + costGrp1 + "%" + costGrp2;
                                }

                                first++;
                            }
                        }
                        else
                        {
                            if (dtLDGRdTLS.Rows[intCountinn]["CST_CNTR_CR_AMOUNT"].ToString() != "")
                            {
                                drDtl["CST_CNTR_CR_AMOUNT"] = dtLDGRdTLS.Rows[intCountinn]["CST_CNTR_CR_AMOUNT"].ToString();
                            }
                            if (dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() != "")
                            {
                                drDtl["COSTCNTR_ID"] = drDtl["COSTCNTR_ID"] + "$" + dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() + "%" + drDtl["CST_CNTR_CR_AMOUNT"] + "%" + costGrp1 + "%" + costGrp2;
                            }
                        }
                    }
                }
            }
            else
            {
                drDtl["LDGR_ID"] = 0;
            }
            drDtl["LDGR_CR_AMT"] = dtLDGRdTLS.Rows[intCount]["LDGR_CR_AMT"].ToString();

            if (dtLDGRdTLS.Rows[intCount]["LDGR_NAME"].ToString() != "")
            {
                drDtl["LDGR_NAME"] = dtLDGRdTLS.Rows[intCount]["LDGR_NAME"].ToString();
            }
            else
            {
                drDtl["LDGR_NAME"] = "";
            }
            drDtl["LDGR_REMARKS"] = dtLDGRdTLS.Rows[intCount]["LDGR_CR_REMRKS"].ToString();
            if (dtLDGRdTLS.Rows[intCount]["CST_CNTR_CR_ID"].ToString() != "")
            {
                drDtl["CST_CNTR_CR_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["CST_CNTR_CR_ID"].ToString());
            }
            dtDetail.Rows.Add(drDtl);
        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        HiddenEdit.Value = strJson;

        if (YearEndCls == 1)
        {
            btnReopen.Visible = false;
            btnFloatReopen.Visible = false;
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
    public int AccountCloseCheck(string strDate)
    {
        int sts = 0;
        clsBusinessLayer_Account_Close objBusEmpAccntCls = new clsBusinessLayer_Account_Close();
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
        DataTable dtAccntCls = objBusEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
        if (dtAccntCls.Rows.Count > 0)
        {
            sts = 1;
        }
        return sts;
    }
    [WebMethod]
    public static string[] LoadSalesForLedger(string intLedgerId, string intorgid, string intcorpid, string strCedtOrDbt, string strCurrencyId, string x, string strCrncyAbrv, string CreditID, string View)
    {
        string[] result = new string[7];


        clsEntity_Credit_Note ObjEntityCredit = new clsEntity_Credit_Note();
        cls_Business_Credit_Note objBussinessCredit = new cls_Business_Credit_Note();

        ObjEntityCredit.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntityCredit.Corporate_id = Convert.ToInt32(intcorpid);
        ObjEntityCredit.LedgerId = Convert.ToInt32(intLedgerId);
        if (CreditID != "")
            ObjEntityCredit.Credit_Id = Convert.ToInt32(CreditID);

        DataTable dtSales = objBussinessCredit.ReadSalesbyId(ObjEntityCredit);
        StringBuilder sb = new StringBuilder();
        string Groupid = "";
        string SettldFully = "";
        int SettledCnt = 0;

        if (dtSales.Rows.Count > 0)
        {
            sb.Append("<table class=\"table table-bordered\"  id=\"TableAddQstn\" >");
            sb.Append("<thead class=\"thead1\">");
            sb.Append("<tr>");
            sb.Append("<th class=\"th_b7 td1 tr_l \">Bill #");
            sb.Append(" </th>");
            sb.Append("<th class=\"th_b7\">Bill Date");
            sb.Append(" </th>");
            sb.Append("<th class=\"th_b7 tr_r\">Bill Amount");
            sb.Append("</th>");
            sb.Append(" <th class=\"th_b3\">Settlement");
            sb.Append(" </th>");
            sb.Append(" </tr>");
            sb.Append(" </thead>");
            sb.Append(" <tbody>");

            for (int row1 = 0; row1 < dtSales.Rows.Count; row1++)
            {
                decimal decTotal = 0;

                if (dtSales.Rows[row1]["VOCHR_BFR_SETL_AMT"].ToString() != "")
                {
                    decTotal = Convert.ToDecimal(dtSales.Rows[row1]["VOCHR_BFR_SETL_AMT"].ToString());
                }
                else if (dtSales.Rows[row1]["BALNC_AMT"].ToString() != "")
                {
                    decTotal = Convert.ToDecimal(dtSales.Rows[row1]["BALNC_AMT"].ToString());
                }

                sb.Append("<tr class=\"tr1\" id=\"SelectRow" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >");
                sb.Append("<td id=\"tdSaleID" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" style=\"display:none;\">" + dtSales.Rows[row1]["SALES_ID"].ToString() + "</td>");
                sb.Append("<td style=\"display:none;\" > <label class=\"checkbox \" ><input type=\"checkbox\"  onkeypress=\"return DisableEnter(event);\"  value=\"" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" id=\"cbMandatory" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\"><i></i></label></td>");
                sb.Append("<td style=\"display:none;\" id=\"tdSaleRef" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["SALES_REF"].ToString() + " <p><span>" + dtSales.Rows[row1]["SALES_DATE"].ToString() + " </span><span>" + decTotal + " " + strCrncyAbrv + "</span></p></td>");
                sb.Append("<td style=\"display:none; \" id=\"tdLedgerRow" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + x + "</td>");
                sb.Append("<td style=\"display:none;\" id=\"tdLedgerName" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["LDGR_NAME"].ToString() + "</td>");

                sb.Append("<td class=\"tr_l\" id=\"tdRef" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" class=\"td1 tr_l\" >" + dtSales.Rows[row1]["SALES_REF"].ToString() + "</td>");
                sb.Append("<td id=\"tdDate" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["SALES_DATE"].ToString() + "</td>");
                sb.Append("<td class=\"tr_r\" id=\"tdAmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" class=\"tr_r\"  >" + decTotal + "</td>");

                if (decTotal == 0)//EVM-0020
                {
                    sb.Append("<td class=\"td1 tr_r\"><div class=\"input-group ma_at flt_l\"><span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                    sb.Append("<input disabled autocomplete=\"off\"  type=\"text\" maxlength=\"10\" class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onblur=\"return AmountCalculation(" + dtSales.Rows[row1]["SALES_ID"].ToString() + ");\"  id=\"txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" /></div>");
                    sb.Append("</td>");
                    sb.Append("<td style=\"display: none;\"><input type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" id=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" value=\"" + dtSales.Rows[row1]["CST_CNTR_CR_ID"].ToString() + "\" /></td>");
                    SettledCnt++;
                }
                else
                {
                    sb.Append("<td class=\"td1 tr_r\"><div class=\"input-group ma_at flt_l\"><span class=\"input-group-addon cur1\">" + strCrncyAbrv + "</span>");
                    sb.Append("<input autocomplete=\"off\"  type=\"text\" maxlength=\"10\" class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onblur=\"return AmountCalculation(" + dtSales.Rows[row1]["SALES_ID"].ToString() + ");\"  id=\"txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" /></div>");
                    sb.Append("</td>");
                    sb.Append("<td style=\"display: none;\"><input type=\"text\" name=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" id=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" value=\"0\" /></td>");
                }

                sb.Append("</tr>");
                result[3] = dtSales.Rows[row1]["LDGR_NAME"].ToString();
                if (row1 == 0)
                {
                    Groupid = dtSales.Rows[row1]["SALES_ID"].ToString();
                }
            }
            sb.Append("</tbody>");
            sb.Append("</table>");

            if (SettledCnt == dtSales.Rows.Count)
            {
                SettldFully = "1";
            }

        }


        if (strCedtOrDbt == "CDT")
        {
            ObjEntityCredit.Credit_debit_Status = 1;
        }
        DataTable dtacntblnc = objBussinessCredit.ReadLedgrBalance(ObjEntityCredit);
        decimal DecDebAmnt = 0, DecCredAmnt = 0, DBalance = 0, Openbalance = 0;
        string CrOrDr = "CR";
        string Nature="";

        if (dtacntblnc.Rows.Count > 0)
        {
            if (dtacntblnc.Rows[0]["LDGR_MODE"].ToString() == "1")
            {
                if (dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString() != "")
                    DecCredAmnt = Convert.ToDecimal(dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString());
                //if (dtacntblnc.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                    //Openbalance = Convert.ToDecimal(dtacntblnc.Rows[0]["LDGR_OPEN_BAL"].ToString());
                DBalance = DecCredAmnt - Openbalance;

            }
            else if (dtacntblnc.Rows[0]["LDGR_MODE"].ToString() == "0")
            {
                //if (dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString() != "")
                //    DecDebAmnt = Convert.ToDecimal(dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString());
                if (dtacntblnc.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                    Openbalance = Convert.ToDecimal(dtacntblnc.Rows[0]["LDGR_OPEN_BAL"].ToString());
                DBalance = DecDebAmnt + Openbalance;
            }
            Nature = dtacntblnc.Rows[0]["ACNT_NATURE_STS"].ToString();
        }
        if (DBalance < 0)
        {
        }
        else
        {
            CrOrDr = "DR";
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
        result[0] = sb.ToString();
        result[1] = DBalance.ToString();
        result[2] = CrOrDr;
        result[5] = Nature;
        result[6] = SettldFully;

        return result;
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
                clsEntity_Credit_Note ObjEntityCredit = new clsEntity_Credit_Note();
                cls_Business_Credit_Note objBussinessCredit = new cls_Business_Credit_Note();
                clsCommonLibrary objCommon = new clsCommonLibrary();
                if (Session["CORPOFFICEID"] != null)
                {
                    ObjEntityCredit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                if (Session["ORGID"] != null)
                {
                    ObjEntityCredit.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["USERID"] != null)
                {
                    ObjEntityCredit.User_Id = Convert.ToInt32(Session["USERID"]);
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                ObjEntityCredit.Credit_Id = Convert.ToInt32(strId);
                ObjEntityCredit.Reference_Num = TxtRef.Value.ToUpper().Trim();
                ObjEntityCredit.Credit_Date = objCommon.textToDateTime(txtdate.Value);
                ObjEntityCredit.UpdCredit_date = objCommon.textToDateTime(HiddenUpdatedDate.Value);
                ObjEntityCredit.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);

                if (txtDescription.Value.Trim() != "")
                {
                    ObjEntityCredit.Description = txtDescription.Value.Trim();
                }
                else
                {
                    ObjEntityCredit.Description = "";
                }
                ObjEntityCredit.SequenceRef = Convert.ToInt32(HiddenSequenceNum.Value);
                ObjEntityCredit.Credit_Total = Convert.ToDecimal(HiddenFieldTotAmnt.Value);
                List<clsEntity_Credit_Note> objEntityCostCenterIns = new List<clsEntity_Credit_Note>();
                List<clsEntity_Credit_Note> objEntitySaleList = new List<clsEntity_Credit_Note>();

                List<clsEntity_Credit_Note> objEntityLedgerIns = new List<clsEntity_Credit_Note>();
                List<clsEntity_Credit_Note> objEntityLedgerUpd = new List<clsEntity_Credit_Note>();
                List<clsEntity_Credit_Note> objEntityLedgerDel = new List<clsEntity_Credit_Note>();

                List<clsEntity_Credit_Note> objEntityDelete = new List<clsEntity_Credit_Note>();//EVM-0020

                string strRets = "successConfirm";

                string jsonData = HiddenLedgerDtls.Value;
                string c = jsonData.Replace("\"{", "\\{");
                string d = c.Replace("\\n", "\r\n");
                string g = d.Replace("\\", "");
                string h = g.Replace("}\"]", "}]");
                string i = h.Replace("}\",", "},");
                List<clsLedgrData> objTVDataList5 = new List<clsLedgrData>();
                objTVDataList5 = JsonConvert.DeserializeObject<List<clsLedgrData>>(i);
                int DebtCount = 0;
                int CrdtCount = 0;

                if (HiddenLedgerDtls.Value != "" && HiddenLedgerDtls.Value != null)
                {
                    foreach (clsLedgrData objclsTVDataLdgr in objTVDataList5)
                    {
                        clsEntity_Credit_Note objSubEntityLedgerINS = new clsEntity_Credit_Note();
                        clsEntity_Credit_Note objSubEntityLedgerUPD = new clsEntity_Credit_Note();

                        if (objclsTVDataLdgr.LEDGRID !="")
                        {
                      
                            objSubEntityLedgerINS.Credit_debit_Status = Convert.ToInt32(objclsTVDataLdgr.TABMODE);
                            if (objSubEntityLedgerINS.Credit_debit_Status == 1)//Credit
                            {
                                CrdtCount++;
                            }
                            else if (objSubEntityLedgerINS.Credit_debit_Status == 0) //Debit
                            {
                                DebtCount++;
                            }
                            objSubEntityLedgerINS.Ledger_Credit_Id = Convert.ToInt32(objclsTVDataLdgr.MAINTABID);
                            objSubEntityLedgerINS.LedgerId = Convert.ToInt32(objclsTVDataLdgr.LEDGRID);
                            objSubEntityLedgerINS.Ledger_Amount = Convert.ToDecimal(objclsTVDataLdgr.LEDGRAMNT);
                         //   objSubEntityLedgerINS.Remarks = objclsTVDataLdgr.REMARKS;
                            if (Request.Form["TxtRemark" + objclsTVDataLdgr.TBL_ID] != "")
                            {
                                objSubEntityLedgerINS.Remarks = Request.Form["TxtRemark" + objclsTVDataLdgr.TBL_ID];
                            }
                            objEntityLedgerIns.Add(objSubEntityLedgerINS);
                        }
                    }

                    jsonData = HiddenCostCentreDtls.Value;
                    c = jsonData.Replace("\"{", "\\{");
                    d = c.Replace("\\n", "\r\n");
                    g = d.Replace("\\", "");
                    h = g.Replace("}\"]", "}]");
                    i = h.Replace("}\",", "},");
                    List<clsCostCntrData> objTVDataList6 = new List<clsCostCntrData>();
                    objTVDataList6 = JsonConvert.DeserializeObject<List<clsCostCntrData>>(i);
                    if (HiddenCostCentreDtls.Value != "" && HiddenCostCentreDtls.Value != null)
                    {

                        foreach (clsCostCntrData objclsTVData in objTVDataList6)
                        {
                            if (objclsTVData.COSTCENTRAMNT != "" && objclsTVData.COSTCENTRID != "" && objclsTVData.COSTCENTRID != "-Select Cost Center-")
                            {
                                clsEntity_Credit_Note objEntityDtl = new clsEntity_Credit_Note();
                                objEntityDtl.Ledger_Credit_Id = Convert.ToInt32(objclsTVData.MAINTABID);
                                objEntityDtl.Cost_Centre_Id = Convert.ToInt32(objclsTVData.COSTCENTRID);
                                objEntityDtl.Cost_Centre_Amt = Convert.ToDecimal(objclsTVData.COSTCENTRAMNT);
                                objEntityDtl.CostGrp1Id = Convert.ToInt32(objclsTVData.COSTGRPID_ONE);
                                objEntityDtl.CostGrp2Id = Convert.ToInt32(objclsTVData.COSTGRPID_TWO);

                                objEntityCostCenterIns.Add(objEntityDtl);
                            }
                        }
                    }
                    int CntExceed = 0;

                    jsonData = HiddenSaleDtls.Value;
                    c = jsonData.Replace("\"{", "\\{");
                    d = c.Replace("\\n", "\r\n");
                    g = d.Replace("\\", "");
                    h = g.Replace("}\"]", "}]");
                    i = h.Replace("}\",", "},");
                    List<clsSaleData> objSaleDataList = new List<clsSaleData>();
                    objSaleDataList = JsonConvert.DeserializeObject<List<clsSaleData>>(i);
                    if (HiddenSaleDtls.Value != "" && HiddenSaleDtls.Value != null)
                    {
                        foreach (clsSaleData objclsTVData in objSaleDataList)
                        {
                            if (objclsTVData.SALEAMNT != "" && objclsTVData.SALEID != "")
                            {
                                clsEntity_Credit_Note objEntitySaleDtl = new clsEntity_Credit_Note();
                                clsEntity_Credit_Note objSubEntityDEL = new clsEntity_Credit_Note();//EVM-0020

                                objEntitySaleDtl.Organisation_id = ObjEntityCredit.Organisation_id;
                                objEntitySaleDtl.Corporate_id = ObjEntityCredit.Corporate_id;
                                objEntitySaleDtl.Ledger_Credit_Id = Convert.ToInt32(objclsTVData.MAINTABID);
                                objEntitySaleDtl.Cost_Centre_Id = Convert.ToInt32(objclsTVData.SALEID);
                                objEntitySaleDtl.Cost_Centre_Amt = Convert.ToDecimal(objclsTVData.SALEAMNT);
                                objEntitySaleDtl.ReceiptActAmount = Convert.ToDecimal(objclsTVData.SALEAMNT_ACT);

                                if (clickedButton.ID == "Button1")
                                {

                                    DataTable dtSalesBalance = objBussinessCredit.ReadSalesBalance(objEntitySaleDtl);
                                    decimal decSalesRemainAmt = 0;
                                    if (dtSalesBalance.Rows.Count > 0)
                                    {
                                        if (dtSalesBalance.Rows[0][1].ToString() != "")
                                            decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                                    }

                                    if (decSalesRemainAmt != 0)//EVM-0020
                                    {
                                        if (decSalesRemainAmt < objEntitySaleDtl.Cost_Centre_Amt)
                                        {
                                            strRets = "SalesAmountExceeded";
                                            CntExceed++;
                                        }
                                    }
                                    else if (CntExceed == 0)
                                    {
                                        strRets = "SalesAmtFullySettld";
                                        objSubEntityDEL.Cost_Centre_Credit_Id = Convert.ToInt32(Request.Form["tdSettld" + objEntitySaleDtl.Cost_Centre_Id]);
                                        objEntityDelete.Add(objSubEntityDEL);
                                    }

                                    if (decSalesRemainAmt != 0)//insert not fully settled
                                    {
                                        objEntitySaleList.Add(objEntitySaleDtl);
                                    }
                                }
                                else
                                {
                                    objEntitySaleList.Add(objEntitySaleDtl);
                                }
                            }
                        }
                    }

                    if (objEntityDelete.Count > 0)//delete fully settld saved sales and purchs
                    {
                        objBussinessCredit.DeleteSaleLedgers(objEntityDelete);
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
                            clsEntity_Credit_Note objSubEntityLedgerDEL = new clsEntity_Credit_Note();
                            objSubEntityLedgerDEL.Ledger_Credit_Id = Convert.ToInt32(strDtlId);
                            objEntityLedgerDel.Add(objSubEntityLedgerDEL);

                        }
                    }
                }
                ObjEntityCredit.CreditCount = CrdtCount;
                ObjEntityCredit.DebitCount = DebtCount;
                DataTable dt = objBussinessCredit.CheckCreditNoteCnclSts(ObjEntityCredit);
                int AcntCloseSts = AccountCloseCheck(txtdate.Value);

                int AuditCloseSts = AuditCloseCheck(txtdate.Value);


                if (AuditCloseSts == 1 && HiddenAuditCloseProvisionStatus.Value != "1")
                {
                    Response.Redirect("fms_Credit_Note_List.aspx?InsUpd=AuditClosed");
                }
                else if (AuditCloseSts == 1 && HiddenAuditCloseProvisionStatus.Value == "1")
                {

                }

                else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
                {
                    Response.Redirect("fms_Credit_Note_List.aspx?InsUpd=AcntClosed");
                }




                if (dt.Rows[0][0].ToString() == "" && dt.Rows[0][1].ToString() == "1")
                {
                    Response.Redirect("fms_Credit_Note_List.aspx?InsUpd=NotConfrm");
                }
                else if (dt.Rows[0][0].ToString() != "")
                {
                    Response.Redirect("fms_Credit_Note_List.aspx?InsUpd=UpdCancl");
                }
                if (strRets == "SalesAmountExceeded")
                {
                    Response.Redirect("fms_Credit_Note.aspx?InsUpd=SalesAmountExceeded&Id=" + Request.QueryString["Id"].ToString());
                }
                else
                {
                    if (clickedButton.ID == "Button1")
                    {
                        if (strRets != "SalesAmtFullySettld")
                        {
                            ObjEntityCredit.ConfirmStatus = 1;
                            if (Session["FINCYRID"] != "" && Session["FINCYRID"] != null)
                                ObjEntityCredit.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
                            objBussinessCredit.UpdateCredit_Note(ObjEntityCredit, objEntityLedgerIns, objEntityLedgerUpd, objEntityLedgerDel, objEntityCostCenterIns, objEntitySaleList);
                            Response.Redirect("fms_Credit_Note_List.aspx?InsUpd=Confrm");
                        }
                        else if (strRets == "SalesAmtFullySettld")
                        {
                            Response.Redirect("fms_Credit_Note.aspx?InsUpd=SalesAmountFullySettld&Id=" + Request.QueryString["Id"].ToString());
                        }
                    }
                    else if (clickedButton.ID == "btnUpdate")
                    {
                        objBussinessCredit.UpdateCredit_Note(ObjEntityCredit, objEntityLedgerIns, objEntityLedgerUpd, objEntityLedgerDel, objEntityCostCenterIns, objEntitySaleList);
                        Response.Redirect("fms_Credit_Note.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");

                    }
                    else if (clickedButton.ID == "btnUpdatecls")
                    {
                        objBussinessCredit.UpdateCredit_Note(ObjEntityCredit, objEntityLedgerIns, objEntityLedgerUpd, objEntityLedgerDel, objEntityCostCenterIns, objEntitySaleList);
                        Response.Redirect("fms_Credit_Note_List.aspx?&InsUpd=Upd");

                    }
                    else if (clickedButton.ID == "btnFloatUpdate")
                    {
                        objBussinessCredit.UpdateCredit_Note(ObjEntityCredit, objEntityLedgerIns, objEntityLedgerUpd, objEntityLedgerDel, objEntityCostCenterIns, objEntitySaleList);
                        Response.Redirect("fms_Credit_Note.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");

                    }
                    else if (clickedButton.ID == "btnFloatUpdatecls")
                    {
                        objBussinessCredit.UpdateCredit_Note(ObjEntityCredit, objEntityLedgerIns, objEntityLedgerUpd, objEntityLedgerDel, objEntityCostCenterIns, objEntitySaleList);
                        Response.Redirect("fms_Credit_Note_List.aspx?&InsUpd=Upd");

                    }
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

    protected void ButtReopn_Click(object sender, EventArgs e)
    {
        clsEntity_Credit_Note ObjEntityCredit = new clsEntity_Credit_Note();
        cls_Business_Credit_Note objBussinessCredit = new cls_Business_Credit_Note();
        List<clsEntity_Credit_Note> objEntityLedger = new List<clsEntity_Credit_Note>();
        List<clsEntity_Credit_Note> objEntityLedgerCostCenter = new List<clsEntity_Credit_Note>();

        clsCommonLibrary objCommon = new clsCommonLibrary();
        string strRets = "successReopen";
        string NewRev = "";
        try
        {
            if (Request.QueryString["Id"] != null)
            {
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                ObjEntityCredit.Credit_Id = Convert.ToInt32(strId);
                if (Session["CORPOFFICEID"] != null)
                {
                    ObjEntityCredit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
                }
                else if (Session["CORPOFFICEID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                if (Session["ORGID"] != null)
                {
                    ObjEntityCredit.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                }
                else if (Session["ORGID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }
                if (Session["USERID"] != null)
                {
                    ObjEntityCredit.User_Id = Convert.ToInt32(Session["USERID"]);
                }
                else if (Session["USERID"] == null)
                {
                    Response.Redirect("/Default.aspx");
                }

                DataTable dtLDGRdTLS = objBussinessCredit.ReadCreditNote_Ledger_By_ID(ObjEntityCredit);

                for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
                {
                    clsEntity_Credit_Note ObjSubEntityRequestCostAndPurchase = new clsEntity_Credit_Note();
                    clsEntity_Credit_Note ObjSubEntityRequest = new clsEntity_Credit_Note();
                    if (!(NewRev.Contains(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString())) && dtLDGRdTLS.Rows[intCount]["LDGR_CR_AMT"].ToString() != "")
                    {
                        if (!(NewRev.Contains(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString())))
                        {
                            ObjSubEntityRequest.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                            NewRev = NewRev + "," + dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString();
                        }
                        if (dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString() != "")
                        {
                            ObjSubEntityRequest.Ledger_Credit_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString());
                        }
                        if (dtLDGRdTLS.Rows[intCount]["LDGR_CR_AMT"].ToString() != "")
                        {
                            ObjSubEntityRequest.Ledger_Amount = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["LDGR_CR_AMT"].ToString());
                        }
                        if (dtLDGRdTLS.Rows[intCount]["LDGR_CR_DR_CR_STATUS"].ToString() != "")
                        {
                            ObjSubEntityRequest.Credit_debit_Status = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["LDGR_CR_DR_CR_STATUS"].ToString());
                        }

                        objEntityLedger.Add(ObjSubEntityRequest);
                    }
                    if (dtLDGRdTLS.Rows[intCount]["CST_CNTR_CR_ID"].ToString() != "")
                    {
                        if (dtLDGRdTLS.Rows[intCount]["COSTCNTR_ID"].ToString() != "")
                        {
                            ObjSubEntityRequestCostAndPurchase.Cost_Centre_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["COSTCNTR_ID"].ToString());
                        }
                        if (dtLDGRdTLS.Rows[intCount]["SALES_ID"].ToString() != "")
                        {
                            ObjSubEntityRequestCostAndPurchase.Cost_Centre_Credit_Id = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["SALES_ID"].ToString());
                        }
                        if (dtLDGRdTLS.Rows[intCount]["CST_CNTR_CR_AMOUNT"].ToString() != "")
                        {
                            ObjSubEntityRequestCostAndPurchase.Cost_Centre_Amt = Convert.ToDecimal(dtLDGRdTLS.Rows[intCount]["CST_CNTR_CR_AMOUNT"].ToString());
                        }
                        objEntityLedgerCostCenter.Add(ObjSubEntityRequestCostAndPurchase);
                    }
                }

                  DataTable dt = objBussinessCredit.ReadCreditNote_By_ID(ObjEntityCredit);
                  int AcntCloseSts = 0;
                  int AuditCloseSts=0;
                  if (dt.Rows.Count > 0)
                  {

                      AcntCloseSts = AccountCloseCheck(dt.Rows[0]["CR_NOTE_DATE"].ToString());
                      AuditCloseSts = AuditCloseCheck(dt.Rows[0]["CR_NOTE_DATE"].ToString());

                  }

                if (AuditCloseSts == 1 && HiddenAuditCloseProvisionStatus.Value != "1")
                {
                    Response.Redirect("fms_Credit_Note_List.aspx?InsUpd=AuditClosed");
                }
                else if (AuditCloseSts == 1 && HiddenAuditCloseProvisionStatus.Value == "1")
                {

                }

                else if (AcntCloseSts == 1 && HiddenFieldAcntCloseReopenSts.Value != "1")
                {
                    Response.Redirect("fms_Credit_Note_List.aspx?InsUpd=AcntClosed");
                }
                

                objBussinessCredit.CreditNoteReOpenById(ObjEntityCredit, objEntityLedger, objEntityLedgerCostCenter);

                Session["REOPEN_STS"] = strRets;
                Response.Redirect("fms_Credit_Note.aspx?Id=" + strRandomMixedId + "&InsUpd=Reopen");
            }
        }
        catch
        {
            strRets = "failed";
        }


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
    public static string CheckRefNumber(string jrnlDate, string orgID, string corptID, string usrID, string RefNum, string CreditID)
    {
        string Ref = "";

        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();


        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(jrnlDate);
        clsEntity_Credit_Note objEntityLayerStock = new clsEntity_Credit_Note();
        cls_Business_Credit_Note objBusinessLayerStock = new cls_Business_Credit_Note();
        objEntityLayerStock.Date_From = objCommon.textToDateTime(jrnlDate);
        objEntityAudit.FromDate = objCommon.textToDateTime(jrnlDate);
        if (corptID != null && corptID != "")
        {
            objEntityAccnt.Corporate_id = Convert.ToInt32(corptID);
            objEntityLayerStock.Corporate_id = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);
            objEntityAudit.Corporate_id = Convert.ToInt32(corptID);


        }
        if (orgID != null && orgID != "")
        {
            objEntityAccnt.Organisation_id = Convert.ToInt32(orgID);
            objEntityLayerStock.Organisation_id = Convert.ToInt32(orgID);
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
                if (Convert.ToInt32(dtRefFormat1.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString()) != 1)
                {
                    strRef = dtRefFormat1.Rows[0]["CR_NOTE_REF"].ToString();
                    strRef = strRef.TrimEnd('/');
                    strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                }
                else
                {
                    strRef = dtRefFormat1.Rows[0]["CR_NOTE_REF"].ToString();
                }
                objEntityLayerStock.Reference_Num = strRef;
                DataTable dtRefFormat = objBusinessLayerStock.ReadRefNumberByDateLast(objEntityLayerStock);

                if (dtRefFormat.Rows.Count > 0)
                {

                    //if (Convert.ToInt32(CreditID) != Convert.ToInt32(dtRefFormat.Rows[0]["CREDIT_NOTE_ID"].ToString()))
                    // {
                    Ref = dtRefFormat.Rows[0]["CR_NOTE_REF"].ToString();
                    if (dtRefFormat.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString() != null)
                    {
                        SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["CR_NOTE_REF_NXT_SUBNUM"].ToString());
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
                    // }
                }

            }
        }
        else
        {
            if (CreditID == "")
            {

                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CREDIT_NOTE);
                objEntityCommon.CorporateID = Convert.ToInt32(corptID);
                objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);

                int intOrgId = objEntityCommon.Organisation_Id;
                int intCorpId = objEntityCommon.CorporateID;
                int intUserId = Convert.ToInt32(usrID);

                string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);

                // objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Credit_Note);
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

                        int flag = 0;
                        string[] arrReferenceSplit = strReferenceFormat.Split('*');
                        int intArrayRowCount = arrReferenceSplit.Length;
                        if (flag == 1)
                        {
                            refFormatByDiv = "#COR#*/*#USR#";
                        }
                        if (refFormatByDiv == "" || refFormatByDiv == null)
                        {
                            strRealFormat = Convert.ToInt32(corptID) + "/" + strNextId;
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
                            //strRealFormat = strRealFormat + "/" + strNextId;

                            if (strRealFormat.Contains("#NUM#"))
                            {
                                strRealFormat = strRealFormat.Replace("#NUM#", strNextId);
                            }
                            else
                            {
                                strRealFormat = strRealFormat + "/" + strNextId;
                            }
                            //if (strRealFormat == "")
                            //{
                            //    strRealFormat = intOrgId.ToString() + "/" + intCorpId.ToString() + "/" + strNextId;
                            //}
                            strRealFormat = strRealFormat.Replace("#", "");
                            strRealFormat = strRealFormat.Replace("*", "");
                            strRealFormat = strRealFormat.Replace("%", "");


                        }
                        Ref = strRealFormat;
                    }
                }
            }
        }
        return Ref;
    }
    //protected void btnPRint_Click(object sender, EventArgs e)
    //{
    //    if (Request.QueryString["Id"] != null)
    //    {
    //        string strRandomMixedId = Request.QueryString["Id"].ToString();
    //        string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //        int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //        string strId = strRandomMixedId.Substring(2, intLenghtofId);

    //        clsEntity_Credit_Note ObjEntityCredit = new clsEntity_Credit_Note();
    //        cls_Business_Credit_Note objBussinessCredit = new cls_Business_Credit_Note();
    //        clsCommonLibrary objCommon = new clsCommonLibrary();

    //        clsEntityCommon objEntityCommon = new clsEntityCommon();
    //        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

    //        string PreparedBy = "";

    //        if (Session["USERFULLNAME"] != null)
    //        {
    //            PreparedBy = Session["USERFULLNAME"].ToString();
    //        }

    //        if (Session["USERID"] != null)
    //        {
    //            ObjEntityCredit.User_Id = Convert.ToInt32(Session["USERID"].ToString());
    //        }
    //        else
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        if (Session["CORPOFFICEID"] != null)
    //        {
    //            ObjEntityCredit.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //        }
    //        else if (Session["CORPOFFICEID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        if (Session["ORGID"] != null)
    //        {
    //            ObjEntityCredit.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
    //        }
    //        else if (Session["ORGID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }

    //        ObjEntityCredit.Credit_Id = Convert.ToInt32(strId);
    //        string CurrencyId = "";
    //        if (hiddenDfltCurrencyMstrId.Value != "")
    //        {
    //            CurrencyId = hiddenDfltCurrencyMstrId.Value;
    //        }
    //        DataTable dt = objBussinessCredit.ReadCreditNote_By_ID(ObjEntityCredit);
    //        DataTable dtCredit = objBussinessCredit.ReadCreditNote_Credit(ObjEntityCredit);
    //        DataTable dtDedit = objBussinessCredit.ReadCreditNote_Debit(ObjEntityCredit);
    //        DataTable dtCorp = objBussinessCredit.ReadCorpDtls(ObjEntityCredit);

    //        string DecCnt = hiddenDecimalCount.Value;

    //        PdfPrint(strId, dt, dtCredit, dtDedit, dtCorp, PreparedBy, DecCnt, CurrencyId, ObjEntityCredit);

    //    }
    //}

    //public void PdfPrint(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtDedit, DataTable dtCorp, string PreparedBy, string DecCnt, string CurrencyId, clsEntity_Credit_Note ObjEntityCredit)
    //{
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CREDIT_NOTE);

    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CREDIT_NOTE);
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    if (ObjEntityCredit.Corporate_id != 0)
    //    {
    //        objEntityCommon.CorporateID = ObjEntityCredit.Corporate_id;
    //    }
    //    if (ObjEntityCredit.Organisation_id != 0)
    //    {
    //        objEntityCommon.Organisation_Id = ObjEntityCredit.Organisation_id;
    //    }
    //    if (CurrencyId != "")
    //    {
    //        objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);
    //    }
    //    clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CREDITNOTE_PRINT);
    //    string strNextNumber = ObjBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "CreditNote" + Id + "_" + strNextNumber + ".pdf";


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
    //            document.Open(); PdfPTable headImg = new PdfPTable(2);

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

    //            var FontBlue = new BaseColor(0, 174, 239);
    //            var FontBlueGrey = new BaseColor(79, 167, 206);

    //            if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() != "1")
    //                headImg.AddCell(new PdfPCell(new Phrase("DRAFT CREDIT NOTE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });
    //            else
    //                headImg.AddCell(new PdfPCell(new Phrase("CREDIT NOTE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });

    //            float[] headersHeading = { 70, 30 };
    //            headImg.SetWidths(headersHeading);
    //            headImg.WidthPercentage = 100;

    //            document.Add(headImg);

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;

    //            footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

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
    //            float[] footrsBodys = { 20, 80 };
    //            footrtables.SetWidths(footrsBodys);
    //            footrtables.WidthPercentage = 100;

    //            footrtables.AddCell(new PdfPCell(new Phrase("Credit note Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["CR_NOTE_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["CR_NOTE_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            if (dtLedgrdDebDtl.Rows.Count > 0)
    //            {
    //                footrtables.AddCell(new PdfPCell(new Phrase("Party", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                if (dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString() != "")
    //                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            }
    //            else
    //                footrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            document.Add(footrtables);

    //            var FontGrey = new BaseColor(134, 152, 160);
    //            var FontBordrGrey = new BaseColor(236, 236, 236);

    //            if (dtDedit.Rows.Count > 0)
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                PdfPTable table2 = new PdfPTable(2);
    //                float[] tableBody2 = { 70, 25 };
    //                table2.SetWidths(tableBody2);
    //                table2.WidthPercentage = 100;
    //                table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
    //                table2.AddCell(new PdfPCell(new Phrase("AMOUNT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });

    //                for (int intRowBodyCount = 0; intRowBodyCount < dtDedit.Rows.Count; intRowBodyCount++)
    //                {
    //                    decimal decAmnt = 0;
    //                    if (dtLedgrdDebDtl.Rows.Count > 0)
    //                    {
    //                        if (dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString() != "")
    //                        {
    //                            decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString());
    //                        }
    //                    }
    //                    string valuestringAmnt = String.Format(format, decAmnt);
    //                    if (dt.Rows[0]["CR_NOTE_NARRATION"].ToString() != "")
    //                        table2.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CR_NOTE_NARRATION"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
    //                    else
    //                        table2.AddCell(new PdfPCell(new Phrase(dtDedit.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });

    //                    table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
    //                }

    //                var FontRed = new BaseColor(202, 3, 20);

    //                decimal decTotal = 0;
    //                //if (dt.Rows[0]["CR_NOTE_TOTAL"].ToString() != "")
    //                //{
    //                //    decTotal = Convert.ToDecimal(dt.Rows[0]["CR_NOTE_TOTAL"].ToString());
    //                //}
    //                if (dtLedgrdDebDtl.Rows.Count > 0)
    //                {
    //                    if (dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString() != "")
    //                    {
    //                        decTotal = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString());
    //                    }
    //                }
    //                string valuestringTot = String.Format(format, decTotal);
    //                string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));
    //                table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, FontRed))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
    //                table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, FontRed))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
    //                //   table2.AddCell(new PdfPCell(new Phrase("AMOUNT (IN WORDS)", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontBlue, Colspan = 2, BorderColor = FontBordrGrey });

    //                table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColor = FontBordrGrey });
    //                table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColor = FontBordrGrey });
    //                document.Add(table2);
    //            }

    //            //if (dt.Rows[0]["CR_NOTE_NARRATION"].ToString().Trim() != "")
    //            //{
    //            //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //    document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //            //    document.Add(new Paragraph(new Chunk(dt.Rows[0]["CR_NOTE_NARRATION"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //            //}

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            string CheckedBy = "";
    //            if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() == "1")
    //            {
    //                CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
    //            }
    //            PdfPTable table3 = new PdfPTable(3);
    //            float[] tableBody3 = { 33, 33, 33 };
    //            table3.SetWidths(tableBody3);
    //            table3.WidthPercentage = 100;
    //            table3.TotalWidth = 600F;

    //            var FontColourPrprd = new BaseColor(33, 150, 243);
    //            var FontColourChkd = new BaseColor(76, 175, 80);
    //            var FontColourAuthrsd = new BaseColor(255, 87, 34);

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
    //        }

    //        Response.Write("<script>window.open('" + strImagePath + strImageName + "','_blank');</script>");
    //    }
    //    catch (Exception)
    //    {
    //        document.Close();
    //    }
    //    LeadgerLoad();
    //    CostCenterLoad();
    //    int confirmsts = Convert.ToInt32(HiddenConfirmSts.Value);
    //    int reopenSts = Convert.ToInt32(HiddenReOpenStatus.Value);
    //    View(Id, confirmsts, reopenSts);
    //}




    [WebMethod]
    public static string PrintPDF(string Id, string orgID, string corptID, string UsrName, string DecCnt, string crncyId)
    {
     
        string strId = Id;

        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsEntity_Credit_Note ObjEntityCredit = new clsEntity_Credit_Note();
        cls_Business_Credit_Note objBussinessCredit = new cls_Business_Credit_Note();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        if (corptID != null)
        {
            ObjEntityCredit.Corporate_id = Convert.ToInt32(corptID);
            objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        }
        if (orgID != null)
        {
            ObjEntityCredit.Organisation_id = Convert.ToInt32(orgID);
            objEntityCommon.Organisation_Id = ObjEntityCredit.Organisation_id;
        }
        ObjEntityCredit.Credit_Id = Convert.ToInt32(strId);

        DataTable dt = objBussinessCredit.ReadCreditNote_By_ID(ObjEntityCredit);
        DataTable dtCredit = objBussinessCredit.ReadCreditNote_Credit(ObjEntityCredit);
        DataTable dtDedit = objBussinessCredit.ReadCreditNote_Debit(ObjEntityCredit);
        DataTable dtCorp = objBussinessCredit.ReadCorpDtls(ObjEntityCredit);

        FMS_FMS_Master_fms_Credit_Note_fms_Credit_Note objPage = new FMS_FMS_Master_fms_Credit_Note_fms_Credit_Note();
       // return objPage.PdfPrint(strId, dt, dtCredit, dtDedit, dtCorp, UsrName, DecCnt, crncyId, ObjEntityCredit);
        DataTable dtinvoiceDtls = new DataTable();
        if (dtCredit.Rows.Count > 0)
        {
            if (dtCredit.Rows[0]["LDGR_CR_ID"].ToString() != "")
            {
                ObjEntityCredit.Ledger_Credit_Id = Convert.ToInt32(dtCredit.Rows[0]["LDGR_CR_ID"].ToString());
                dtinvoiceDtls = objBussinessCredit.ReadInvoiceDtls(ObjEntityCredit);
            }
        }
      

        int Version_flg = 0;
        string strReturn = "";
        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.CREDITNOTE);
        DataTable dtVersion = objBusinessLayer.ReadPrintVersion(objEntityCommon);
        //0039
        DataTable dtLDGRdTLSdbcr = objBussinessCredit.ReadCreditNote_Ledger_By_ID(ObjEntityCredit);
        //end

        if (dtVersion.Rows.Count > 0)
        {
            if (dtVersion.Rows[0][0].ToString() == "1")
            {
                Version_flg = 1;
                strReturn = objBussinessCredit.PdfPrintVersion1(strId, dt, dtCredit, dtDedit, dtCorp, UsrName, DecCnt, crncyId, ObjEntityCredit);
            }
            else if (dtVersion.Rows[0][0].ToString() == "2")
            {
                Version_flg = 2;
                strReturn = objBussinessCredit.PdfPrintVersion2(dtLDGRdTLSdbcr, strId, dt, dtCorp, UsrName, DecCnt, crncyId, ObjEntityCredit, Version_flg, dtinvoiceDtls);
            }
            else if (dtVersion.Rows[0][0].ToString() == "3")
            {
                Version_flg = 3;
                strReturn = objBussinessCredit.PdfPrintVersion2(dtLDGRdTLSdbcr, strId, dt, dtCorp, UsrName, DecCnt, crncyId, ObjEntityCredit, Version_flg, dtinvoiceDtls);
            }
        }


        return strReturn;



    }

    public string PdfPrintVersion1(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtDedit, DataTable dtCorp, string PreparedBy, string DecCnt, string crncyId, clsEntity_Credit_Note ObjEntityCredit)
    {
        string strRet = "";

        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CREDIT_NOTE);
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CREDIT_NOTE);
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (ObjEntityCredit.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityCredit.Corporate_id;
        }
        if (ObjEntityCredit.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityCredit.Organisation_id;
        }
        if (crncyId != "")
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(crncyId);
        }
        clsBusinessLayer ObjBusiness = new clsBusinessLayer();

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CREDITNOTE_PRINT);
        string strNextNumber = ObjBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "CreditNote" + Id + "_" + strNextNumber + ".pdf";


        Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        try
        {
            int precision = Convert.ToInt32(DecCnt);
            string format = String.Format("{{0:N{0}}}", precision);

            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                document.Open(); PdfPTable headImg = new PdfPTable(2);

                string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
                if (dtCorp.Rows.Count > 0)
                {
                    if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
                        strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + dtCorp.Rows[0]["CORPRT_ICON"].ToString();

                }

                if (strImageLogo != "")
                {
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
                    image.ScaleToFit(100f, 80f);

                    headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                else
                {
                    headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
                }

                var FontBlue = new BaseColor(0, 174, 239);
                var FontBlueGrey = new BaseColor(79, 167, 206);
                if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() != "1")
                    headImg.AddCell(new PdfPCell(new Phrase("DRAFT CREDIT NOTE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });
                else
                    headImg.AddCell(new PdfPCell(new Phrase("CREDIT NOTE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });

                float[] headersHeading = { 70, 30 };
                headImg.SetWidths(headersHeading);
                headImg.WidthPercentage = 100;

                document.Add(headImg);

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                PdfPTable footrtable = new PdfPTable(2);
                float[] footrsBody = { 50, 50 };
                footrtable.SetWidths(footrsBody);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                if (dtCorp.Rows.Count > 0)
                {
                    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                }
                document.Add(footrtable);

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                PdfPTable footrtables = new PdfPTable(2);
                float[] footrsBodys = { 20, 80 };
                footrtables.SetWidths(footrsBodys);
                footrtables.WidthPercentage = 100;

                footrtables.AddCell(new PdfPCell(new Phrase("Credit note Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["CR_NOTE_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["CR_NOTE_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                if (dtLedgrdDebDtl.Rows.Count > 0)
                {
                    footrtables.AddCell(new PdfPCell(new Phrase("Party", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    if (dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString() != "")
                        footrtables.AddCell(new PdfPCell(new Phrase(": " + dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                }
                else
                    footrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                document.Add(footrtables);

                var FontGrey = new BaseColor(134, 152, 160);
                var FontBordrGrey = new BaseColor(236, 236, 236);

                if (dtDedit.Rows.Count > 0)
                {
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                    PdfPTable table2 = new PdfPTable(2);
                    float[] tableBody2 = { 70, 25 };
                    table2.SetWidths(tableBody2);
                    table2.WidthPercentage = 100;
                    table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
                    table2.AddCell(new PdfPCell(new Phrase("AMOUNT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });

                    for (int intRowBodyCount = 0; intRowBodyCount < dtDedit.Rows.Count; intRowBodyCount++)
                    {
                        decimal decAmnt = 0;
                        if (dtLedgrdDebDtl.Rows.Count > 0)
                        {
                            if (dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString() != "")
                            {
                                decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString());
                            }
                        }
                        string valuestringAmnt = String.Format(format, decAmnt);
                        if (dt.Rows[0]["CR_NOTE_NARRATION"].ToString() != "")
                            table2.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CR_NOTE_NARRATION"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                        else
                            table2.AddCell(new PdfPCell(new Phrase(dtDedit.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });

                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                    }

                    var FontRed = new BaseColor(202, 3, 20);

                    decimal decTotal = 0;
                    //if (dt.Rows[0]["CR_NOTE_TOTAL"].ToString() != "")
                    //{
                    //    decTotal = Convert.ToDecimal(dt.Rows[0]["CR_NOTE_TOTAL"].ToString());
                    //}
                    if (dtLedgrdDebDtl.Rows.Count > 0)
                    {
                        if (dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString() != "")
                        {
                            decTotal = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString());
                        }
                    }
                    string valuestringTot = String.Format(format, decTotal);
                    string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));
                    table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, FontRed))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                    table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, FontRed))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                    //   table2.AddCell(new PdfPCell(new Phrase("AMOUNT (IN WORDS)", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontBlue, Colspan = 2, BorderColor = FontBordrGrey });

                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColor = FontBordrGrey });
                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColor = FontBordrGrey });
                    document.Add(table2);
                }

                //if (dt.Rows[0]["CR_NOTE_NARRATION"].ToString().Trim() != "")
                //{
                //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                //    document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                //    document.Add(new Paragraph(new Chunk(dt.Rows[0]["CR_NOTE_NARRATION"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                //}

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                string CheckedBy = "";
                if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() == "1")
                {
                    CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                }
                PdfPTable table3 = new PdfPTable(3);
                float[] tableBody3 = { 33, 33, 33 };
                table3.SetWidths(tableBody3);
                table3.WidthPercentage = 100;
                table3.TotalWidth = 600F;

                var FontColourPrprd = new BaseColor(33, 150, 243);
                var FontColourChkd = new BaseColor(76, 175, 80);
                var FontColourAuthrsd = new BaseColor(255, 87, 34);
                PreparedBy = dt.Rows[0]["INS_USR_NAME"].ToString();
                table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourPrprd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourChkd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourAuthrsd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });

                table3.WriteSelectedRows(0, -1, 0, 80, writer.DirectContent);

                document.Close();
            }
            strRet = strImagePath + strImageName;
        }
        catch (Exception)
        {
            document.Close();
        }

        return strRet;
    }


    public string PdfPrintVersion2(string Id, DataTable dt, DataTable dtLedgrdDebDtl, DataTable dtDedit, DataTable dtCorp, string PreparedBy, string DecCnt, string crncyId, clsEntity_Credit_Note ObjEntityCredit,int Version_flg)
    {
        string strRet = "";

        clsCommonLibrary objCommon = new clsCommonLibrary();
        int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.CREDIT_NOTE);
        string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.CREDIT_NOTE);
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        if (ObjEntityCredit.Corporate_id != 0)
        {
            objEntityCommon.CorporateID = ObjEntityCredit.Corporate_id;
        }
        if (ObjEntityCredit.Organisation_id != 0)
        {
            objEntityCommon.Organisation_Id = ObjEntityCredit.Organisation_id;
        }
        if (crncyId != "")
        {
            objEntityCommon.CurrencyId = Convert.ToInt32(crncyId);
        }
        clsBusinessLayer ObjBusiness = new clsBusinessLayer();

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.CREDITNOTE_PRINT);
        string strNextNumber = ObjBusiness.ReadNextNumberSequanceForUI(objEntityCommon);
        string strImageName = "CreditNote" + Id + "_" + strNextNumber + ".pdf";


        Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
        try
        {
            int precision = Convert.ToInt32(DecCnt);
            string format = String.Format("{{0:N{0}}}", precision);

            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                FileStream file = new FileStream(System.Web.HttpContext.Current.Server.MapPath(strImagePath) + strImageName, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, file);
                document.Open(); PdfPTable headImg = new PdfPTable(2);

                string strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.DEFAULT_LOGO);
                if (dtCorp.Rows.Count > 0)
                {
                    if (dtCorp.Rows[0]["CORPRT_ICON"].ToString() != "")
                        strImageLogo = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.Bussiness_Unit) + dtCorp.Rows[0]["CORPRT_ICON"].ToString();

                }

                if (strImageLogo != "")
                {
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(strImageLogo));
                    image.ScalePercent(PdfPCell.ALIGN_CENTER);
                    image.ScaleToFit(100f, 80f);

                    headImg.AddCell(new PdfPCell(image) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
                }
                else
                {
                    headImg.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK))) { Border = 0, PaddingTop = 15, HorizontalAlignment = Element.ALIGN_LEFT });
                }

                var FontBlue = new BaseColor(0, 174, 239);
                var FontBlueGrey = new BaseColor(79, 167, 206);
                if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() != "1")
                    headImg.AddCell(new PdfPCell(new Phrase("DRAFT CREDIT NOTE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });
                else
                    headImg.AddCell(new PdfPCell(new Phrase("CREDIT NOTE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 40, HorizontalAlignment = Element.ALIGN_RIGHT });

                float[] headersHeading = { 70, 30 };
                headImg.SetWidths(headersHeading);
                headImg.WidthPercentage = 100;

                document.Add(headImg);

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                PdfPTable footrtable = new PdfPTable(2);
                float[] footrsBody = { 50, 50 };
                footrtable.SetWidths(footrsBody);
                footrtable.WidthPercentage = 100;

                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                if (dtCorp.Rows.Count > 0)
                {
                    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                }
                document.Add(footrtable);

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                PdfPTable footrtables = new PdfPTable(2);
                float[] footrsBodys = { 20, 80 };
                footrtables.SetWidths(footrsBodys);
                footrtables.WidthPercentage = 100;

                footrtables.AddCell(new PdfPCell(new Phrase("Credit note Ref #", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["CR_NOTE_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["CR_NOTE_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                if (dtLedgrdDebDtl.Rows.Count > 0)
                {
                    footrtables.AddCell(new PdfPCell(new Phrase("Party", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                    if (dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString() != "")
                        footrtables.AddCell(new PdfPCell(new Phrase(": " + dtLedgrdDebDtl.Rows[0]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
                }
                else
                    footrtables.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

                document.Add(footrtables);

                var FontGrey = new BaseColor(134, 152, 160);
                var FontBordrGrey = new BaseColor(236, 236, 236);

                if (dtDedit.Rows.Count > 0)
                {
                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

                    PdfPTable table2 = new PdfPTable(2);
                    float[] tableBody2 = { 70, 25 };
                    table2.SetWidths(tableBody2);
                    table2.WidthPercentage = 100;
                    table2.AddCell(new PdfPCell(new Phrase("PARTICULARS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
                    table2.AddCell(new PdfPCell(new Phrase("AMOUNT" + " (" + dt.Rows[0]["CRNCMST_ABBRV"].ToString() + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 7, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });

                    for (int intRowBodyCount = 0; intRowBodyCount < dtDedit.Rows.Count; intRowBodyCount++)
                    {
                        decimal decAmnt = 0;
                        if (dtLedgrdDebDtl.Rows.Count > 0)
                        {
                            if (dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString() != "")
                            {
                                decAmnt = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString());
                            }
                        }
                        string valuestringAmnt = String.Format(format, decAmnt);
                        if (dt.Rows[0]["CR_NOTE_NARRATION"].ToString() != "")
                            table2.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["CR_NOTE_NARRATION"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                        else
                            table2.AddCell(new PdfPCell(new Phrase(dtDedit.Rows[intRowBodyCount]["LDGR_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });

                        table2.AddCell(new PdfPCell(new Phrase(valuestringAmnt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                    }

                    var FontRed = new BaseColor(202, 3, 20);

                    decimal decTotal = 0;
                    //if (dt.Rows[0]["CR_NOTE_TOTAL"].ToString() != "")
                    //{
                    //    decTotal = Convert.ToDecimal(dt.Rows[0]["CR_NOTE_TOTAL"].ToString());
                    //}
                    if (dtLedgrdDebDtl.Rows.Count > 0)
                    {
                        if (dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString() != "")
                        {
                            decTotal = Convert.ToDecimal(dtLedgrdDebDtl.Rows[0]["LDGR_CR_AMT"].ToString());
                        }
                    }
                    string valuestringTot = String.Format(format, decTotal);
                    string strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, Convert.ToString(decTotal));
                    table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, FontRed))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                    table2.AddCell(new PdfPCell(new Phrase(valuestringTot, FontFactory.GetFont("Arial", 9, Font.BOLD, FontRed))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
                    //   table2.AddCell(new PdfPCell(new Phrase("AMOUNT (IN WORDS)", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
                    table2.AddCell(new PdfPCell(new Phrase(strcurrenWord, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = FontBlue, Colspan = 2, BorderColor = FontBordrGrey });

                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColor = FontBordrGrey });
                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColor = FontBordrGrey });
                    document.Add(table2);
                }

                //if (dt.Rows[0]["CR_NOTE_NARRATION"].ToString().Trim() != "")
                //{
                //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                //    document.Add(new Paragraph(new Chunk("Narration", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                //    document.Add(new Paragraph(new Chunk(dt.Rows[0]["CR_NOTE_NARRATION"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
                //}

                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
                string CheckedBy = "";
                if (dt.Rows[0]["CR_NOTE_CONFIRM_STATUS"].ToString() == "1")
                {
                    CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
                }

                PreparedBy = dt.Rows[0]["INS_USR_NAME"].ToString();
                PdfPTable table3 = new PdfPTable(3);
                float[] tableBody3 = { 33, 33, 33 };
                table3.SetWidths(tableBody3);
                table3.WidthPercentage = 100;
                table3.TotalWidth = 600F;

                var FontColourPrprd = new BaseColor(33, 150, 243);
                var FontColourChkd = new BaseColor(76, 175, 80);
                var FontColourAuthrsd = new BaseColor(255, 87, 34);

                table3.AddCell(new PdfPCell(new Phrase(PreparedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase(CheckedBy, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase("____________________", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 0, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase("Prepared by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourPrprd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase("Checked by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourChkd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });
                table3.AddCell(new PdfPCell(new Phrase("Authorized by", FontFactory.GetFont("Arial", 9, Font.BOLD, FontColourAuthrsd))) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Border = 0 });

                table3.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });

                table3.WriteSelectedRows(0, -1, 0, 80, writer.DirectContent);

                document.Close();
            }
            strRet = strImagePath + strImageName;
        }
        catch (Exception)
        {
            document.Close();
        }

        return strRet;
    }

    [WebMethod]
    public static string CheckSaleSettlement(string strSalePurchaseDtls, string strOrgIdID, string strCorpID)
    {
        //EVM-0020
        string ret = "successConfirm";

        clsEntity_Credit_Note ObjEntityCredit = new clsEntity_Credit_Note();
        cls_Business_Credit_Note objBussinessCredit = new cls_Business_Credit_Note();

        string SalePurchaseDtl = strSalePurchaseDtls;
        if (SalePurchaseDtl != "" && SalePurchaseDtl != "null" && SalePurchaseDtl != null)
        {
            string[] values = SalePurchaseDtl.Split('$');
            for (int i = 0; i < values.Length; i++)
            {
                clsEntity_Credit_Note objEntitySaleDtl = new clsEntity_Credit_Note();

                ObjEntityCredit.Organisation_id = Convert.ToInt32(strOrgIdID);
                ObjEntityCredit.Corporate_id = Convert.ToInt32(strCorpID);
                if (values[i] != "")
                {
                    string[] valSplit = values[i].Split('%');
                    objEntitySaleDtl.Cost_Centre_Id = Convert.ToInt32(valSplit[0]);

                    valSplit[1] = valSplit[1].Replace(",", "");
                    objEntitySaleDtl.Cost_Centre_Amt = Convert.ToDecimal(valSplit[1]);

                    objEntitySaleDtl.Organisation_id = ObjEntityCredit.Organisation_id;
                    objEntitySaleDtl.Corporate_id = ObjEntityCredit.Corporate_id;

                    DataTable dtSalesBalance = objBussinessCredit.ReadSalesBalance(objEntitySaleDtl);
                    decimal decSalesRemainAmt = 0;
                    if (dtSalesBalance.Rows.Count > 0)
                    {
                        if (dtSalesBalance.Rows[0][1].ToString() != "")
                            decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                    }

                    if (decSalesRemainAmt != 0)
                    {
                        if (decSalesRemainAmt < objEntitySaleDtl.Cost_Centre_Amt)
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

        return ret;
    }



}