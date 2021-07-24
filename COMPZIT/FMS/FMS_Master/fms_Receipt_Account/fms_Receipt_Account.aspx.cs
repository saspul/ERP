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

public partial class FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account : System.Web.UI.Page
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
            btnReopen.Visible = false;
            btnFloatReopen.Visible = false;
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            ddlAccontLed.Focus();

            HiddenRecurring.Value = "0";
            hiddenLedgerddl.Value = "0";
            hiddenCostCenterddl.Value = "0";
            HiddenCostGroup1ddl.Value = "0";
            HiddenCostGroup2ddl.Value = "0";
            CostCenterLoad();
            CostGroup1Load();
            CostGroup2Load();
            AccountLedgerLoad();
            LeadgerLoad();
            // LoadBank();
            // txtTotalAmt.Enabled = false;
            CurrencyLoad();
            HiddenView.Value = "0";
            HiddenFieldTaxId.Value = "";
            //Hiddentxtefctvedate.Value = DateTime.Now.ToString("dd-MM-yyyy");
            HiddenCurrentDate.Value = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");

            //txtFromdate
            HiddenChkSts.Value = "1";
            btnUpdate.Visible = false;
            btnUpdatecls.Visible = false;
            //EVM-0027 12-04
            btnFloatUpdate.Visible = false;
            btnFloatUpdateCls.Visible = false;
            //END

            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            HiddenRefAccountCls.Value = "0";
          //  clsEntityCommon objentcommn = new clsEntityCommon();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsEntity_Receipt_Account objEntity = new clsEntity_Receipt_Account();

            //cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
            //clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();

            HiddenPaymode.Value = "0";
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
                objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntity.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
              //  objEntityAudit.Corporate_id = intCorpId;

            }
            else if (Session["CORPOFFICEID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                objEntity.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntityCommon.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
             //   objEntityAudit.Organisation_id = intOrgId;
                //  objEntity.OrgId = intOrgId;

            }
            else if (Session["ORGID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Session["FINCYRID"] != null)
            {
                objEntityCommon.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
            clsCommonLibrary objCommon = new clsCommonLibrary();
            HiddenReopenSts.Value = "0";
            HiddenProvisionSts.Value = "0";
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Receipt);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            divRecur.Visible = false;
            if (dtChildRol.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Add).ToString())
                    {
                        intAdd = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Modify).ToString())
                    {
                        intUpdate = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }

                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        intConfirm = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }

                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        HiddenProvisionSts.Value = (clsCommonLibrary.StatusAll.Active).ToString();
                        HiddenFieldAcntCloseReopenSts.Value="1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        HiddenReopenSts.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        HiddenFieldAuditCloseReopenSts.Value = "1";
                    }

                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Recurring).ToString())
                    {
                        divRecur.Visible = true;
                        HiddenRecurring.Value = "1";
                    }
                }
            }
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                          clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                          clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                          clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS,
                                                          clsCommonLibrary.CORP_GLOBAL.FMS_LDGR_DUPLICATION
                                                       };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                HiddenRefAccountCls.Value = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();
                HiddenLedgrDupSts.Value = dtCorpDetail.Rows[0]["FMS_LDGR_DUPLICATION"].ToString();
            }

            // for adding comma
            clsCommonLibrary objcommon = new clsCommonLibrary();
       

            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                HiddenCurrcyFxAbbrvn.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();

            }

            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);


            // objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Receipt);
            clsBusinessLayer_Receipt_Account objBussinessRcpt = new clsBusinessLayer_Receipt_Account();



            DataTable dtFormate = objBussinessRcpt.readRefFormate(objEntityCommon);


            string CurrentDate = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
            DateTime dtCurrentDate = objCommon.textToDateTime(CurrentDate);
            int DtYear = dtCurrentDate.Year;
            int DtMonth = dtCurrentDate.Month;
            string dtyy = dtCurrentDate.ToString("yy");

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
                TxtRef.Value = strRealFormat;

            }
            else
            {
                TxtRef.Value = strNextId;
            }


            lblEntry.Text = "Add Receipt";



            if (intAdd == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                bttnsave.Visible = false;
               
                btnSaveCls.Visible = false;
                //EVM-0027
                btnFloatSaveCls.Visible = false;
                btnFloatSave.Visible = false;
                //END
                //btnSaveCls.Visible = false;
                //bttnUpdate.Visible = false;

            }
            if (intUpdate == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {

            }
            else
            {
                //  btnUpdate.Visible = false;
                // bttnUpdateCls.Visible = false;
            }

            if (Request.QueryString["InsUpd"] != null)
            {
                string strInsUpd = Request.QueryString["InsUpd"].ToString();
                if (strInsUpd == "Ins")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessMsg", "SuccessMsg();", true);
                }
                else if (strInsUpd == "UPD")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessUpdMsg", "SuccessUpdMsg();", true);
                }
                else if (strInsUpd == "UpdCancl")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "CanclUpdMsg", "CanclUpdMsg();", true);
                }
                else if (strInsUpd == "Confrm")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmation", "SuccessConfirmation();", true);
                }
                else if (strInsUpd == "CNFERR")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessNotConfirmation", "SuccessNotConfirmation();", true);

                }
                else if (strInsUpd == "CNCL")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SuccessCancel", "SuccessCancel();", true);
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
                else if (strInsUpd == "SalesAmountExceeded")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SalesAmountExceeded", "SalesAmountExceeded();", true);
                }
                else if (strInsUpd == "SalesAmountFullySettld")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "SalesAmountFullySettld", "SalesAmountFullySettld();", true);
                }
                

            }


            if (intConfirm == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
            {


            }
            else
            {
                btnConfirm.Visible = false;
                btnFloatConfirm.Visible = false;
            }



            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objEntityCommon);
          //  DataTable dtfinaclYear = objBussinessRcpt.readFinancialYear(objEntity);
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
                objEntity.StartDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString());
                objEntity.EndDate = objCommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString());

                DataTable dtAcntClsDate = objBussinessRcpt.readAcntClsDate(objEntity);
                DataTable dtAuditClsDate = objBusinessLayer.ReadLastAuditClose(objEntityCommon);

     

                if (dtAcntClsDate.Rows.Count > 0 && dtAuditClsDate.Rows.Count > 0)
                {
                    HiddenAcntClsDate.Value = dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString();

                    if (HiddenFieldAuditCloseReopenSts.Value == "1")
                    {
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    }

                    else
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
                        else  if (startDate < startDate1)
                        {
                            if (HiddenFieldAuditCloseReopenSts.Value != "1")
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

                       else  if (startDate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {


                        }
                        else
                        {
                            HiddenStartDate.Value = startDate.AddDays(1).ToString("dd-MM-yyyy");
                            HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
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

                                objEntity.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntity.Corporate_id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntity.Organisation_id = intOrgId;
                                objEntityAudit.Corporate_id = intCorpId;
                                objEntityAudit.Organisation_id = intOrgId;

                                int SubRef = 1;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                                if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
                                {
                                    //DataTable dtRefFormat1 = objBusinessLayerStock1.ReadRefNumberByDate(objEntityLayerStock1);
                                    DataTable dtRefFormat1 = objBussinessRcpt.ReadRefNumberByDate(objEntity);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (dtRefFormat1.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "")
                                        {
                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                                        }
                                        objEntity.RefNum = strRef;
                                        //  DataTable dtRefFormat = objBusinessLayerStock1.ReadRefNumberByDateLast(objEntityLayerStock1);
                                        DataTable dtRefFormat = objBussinessRcpt.ReadRefNumberByDateLast(objEntity);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["RECPT_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString());
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
                    DateTime curdate = objcommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    string Ref = "";

                    if (curdate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        DateTime startDate = objcommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());
                        if (HiddenFieldAcntCloseReopenSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {

                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();

                                cls_Business_Audit_Closeing objEmpAccntCls = new cls_Business_Audit_Closeing();
                                clsEntityLayerAuditClosing objEntityAccnt = new clsEntityLayerAuditClosing();


                                objEntityAccnt.FromDate = objCommon.textToDateTime(txtdate.Value);


                                int SubRef = 1;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAuditClosingDate(objEntityAccnt);
                                if (dtAccntCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = objBussinessRcpt.ReadRefNumberByDate(objEntity);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
                                        if (dtRefFormat1.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "")
                                        {
                                            if (Convert.ToInt32(dtRefFormat1.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString()) != 1)
                                            {
                                                strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                                                strRef = strRef.TrimEnd('/');
                                                strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                            }
                                        }
                                        else
                                        {
                                            strRef = dtRefFormat1.Rows[0]["RECPT_REF"].ToString();
                                        }
                                        objEntity.RefNum = strRef;
                                        DataTable dtRefFormat = objBussinessRcpt.ReadRefNumberByDateLast(objEntity);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["RECPT_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString());
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
                    HiddenAcntClsDate.Value = dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString();
                    if (HiddenProvisionSts.Value == (clsCommonLibrary.StatusAll.Active).ToString())
                    {
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                    }
                    else
                    {
                        if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "")
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
                    }

                    DateTime curdate = objcommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    string Ref = "";

                    if (curdate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {

                        DateTime startDate = objcommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                        if (HiddenProvisionSts.Value == clsCommonLibrary.StatusAll.Active.ToString())
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {

                                txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                                clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
                                clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                                objEntityAccnt.FromDate = objCommon.textToDateTime(txtdate.Value);
                                //clsEntityJournal objEntityLayerStock1 = new clsEntityJournal();
                                //clsBusinessJournal objBusinessLayerStock1 = new clsBusinessJournal();
                                objEntity.FromDate = objCommon.textToDateTime(txtdate.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntity.Corporate_id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntity.Organisation_id = intOrgId;
                                int SubRef = 1;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                if (dtAccntCls.Rows.Count > 0)
                                {
                                    DataTable dtRefFormat1 = objBussinessRcpt.ReadRefNumberByDate(objEntity);
                                    if (dtRefFormat1.Rows.Count > 0)
                                    {
                                        string strRef = "";
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
                                        objEntity.RefNum = strRef;
                                        DataTable dtRefFormat = objBussinessRcpt.ReadRefNumberByDateLast(objEntity);
                                        if (dtRefFormat.Rows.Count > 0)
                                        {
                                            Ref = dtRefFormat.Rows[0]["RECPT_REF"].ToString();
                                            if (dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString());
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


                        if (curdate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {
                            txtdate.Value = objBusinessLayer.LoadCurrentDateInString();
                        }
                    }
                    HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                }
            }
            HiddenUpdatedDate.Value = "";
            btnPRint.Visible = false;
            btnFloatPrint.Visible = false;
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
                    Update(dt.Rows[0]["RECPT_ID"].ToString(), YearEndCls);
                    txtdate.Value = dt.Rows[0]["REPARECSUB_DATE"].ToString();
                    btnConfirm.Visible = false;
                    HiddenFieldTaxId.Value = dt.Rows[0]["RECPT_ID"].ToString();
                }               
            }

            else if (Request.QueryString["Id"] != null)
            {
                btnPRint.Visible = false;
                lblEntry.Text = "Edit Receipt";
                ButtnClose.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenFieldTaxId.Value = strId;
                bttnsave.Visible = false;
               

                btnSaveCls.Visible = false;
                //EVM-0027 12-04
                btnFloatSaveCls.Visible = false;
                btnFloatSave.Visible = false;
                btnFloatUpdate.Visible = true;
                btnFloatUpdateCls.Visible = true;
                ButtnFloatClear.Visible = false;
                //END
                btnUpdate.Visible = true;

               

                btnCancel.Visible = true;
                btnUpdatecls.Visible = true;
                Update(strId, YearEndCls);

            }
            else if (Request.QueryString["ViewId"] != null)
            {
                HiddenView.Value = "1";
                spandate.Attributes["style"]="pointer-events:none;";
                spanChqDate.Attributes["style"] = "pointer-events:none;";  
                lblEntry.Text = "View Receipt";
                string status = "";
                btnPRint.Visible = true;
                btnFloatPrint.Visible = true;
                //EVm-0027 12-04
                btnFloatUpdate.Visible = false;
                btnFloatUpdateCls.Visible = false;
                //END
                btnUpdate.Visible = false;
                btnUpdatecls.Visible = false;
                btnCancel.Visible = true;
                ButtnClose.Visible = false;
                ButtnFloatClear.Visible = false;


                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                HiddenFieldTaxId.Value = strId;
                btnReopen.Visible = true;
                btnFloatReopen.Visible = true;

                Update(strId, YearEndCls);


                //EVM-0027 12-04
                btnFloatSaveCls.Visible = false;
                btnFloatSave.Visible = false;
                //END
                bttnsave.Visible = false;
                btnSaveCls.Visible = false;
               
            
            }
            else
            {
                btnConfirm.Visible = false;
               
                btnFloatConfirm.Visible = false;
            }

            if (Request.QueryString["VId"] != null)
            {
                divLinkSection.Visible = false;
                divList.Visible = false;
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
                btnCancel.Visible = false;
                btnUpdatecls.Visible = false;
                btnFloatUpdateCls.Visible = false;
                btnFloatCancel.Visible = false;
            }
        }

    }
    public void Update(string strP_Id, int YearEndCls)
    {
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

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

        ObjEntityRequest.ReceiptId = Convert.ToInt32(strP_Id);



        DataTable dt = objBussiness.ReadReceptDetailsById(ObjEntityRequest);

        int AcntCloseSts = 0;
        int AuditCloseSts = 0;

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


            if (Request.QueryString["Rid"] == null)
            {

                HiddenRefNextNum.Value = dt.Rows[0]["RECPT_REF_NEXTNUM"].ToString();


                if (dt.Rows[0]["RECPT_REF"].ToString() != "")
                {
                    TxtRef.Value = dt.Rows[0]["RECPT_REF"].ToString();
                    HiddenRefNum.Value = dt.Rows[0]["RECPT_REF"].ToString();
                }
            }
            ddlAccontLed.ClearSelection();
            if (dt.Rows[0]["RECPT_ACCNT_LDGR_ID"].ToString() != "")
            {
                if (ddlAccontLed.Items.FindByValue(dt.Rows[0]["RECPT_ACCNT_LDGR_ID"].ToString()) != null)
                {
                    ddlAccontLed.Items.FindByValue(dt.Rows[0]["RECPT_ACCNT_LDGR_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dt.Rows[0]["LDGR_NAME"].ToString(), dt.Rows[0]["RECPT_ACCNT_LDGR_ID"].ToString());
                ddlAccontLed.Items.Insert(1, lstGrp);
                SortDDL(ref this.ddlAccontLed);
                ddlAccontLed.Items.FindByValue(dt.Rows[0]["RECPT_ACCNT_LDGR_ID"].ToString()).Selected = true;
            }

            if (Request.QueryString["Rid"] == null)
            {
                if (dt.Rows[0]["RECPT_DATE"].ToString() != "")
                {
                    txtdate.Value = dt.Rows[0]["RECPT_DATE"].ToString();

                    HiddenUpdatedDate.Value = dt.Rows[0]["RECPT_DATE"].ToString();
                    // RcptUpdateDate
                }
            }
            ddlCurrency.ClearSelection();
            if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
            {
                if (ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()) != null)
                {
                    ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dt.Rows[0]["CRNCMST_NAME"].ToString(), dt.Rows[0]["CRNCMST_ID"].ToString());
                ddlCurrency.Items.Insert(1, lstGrp);
                SortDDL(ref this.ddlCurrency);
                ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
            }




            hiddenDfltCurrencyMstrId.Value = dt.Rows[0]["CRNCMST_ID"].ToString();
            HiddenCurrcyFxAbbrvn.Value = dt.Rows[0]["CRNCMST_ABBRV"].ToString();


            if (dt.Rows[0]["CRNCMST_ABBRV"].ToString() != "")
            {
                if (dt.Rows[0]["RECPT_TOTAL_AMT"].ToString() != "")
                {
                    //  HiddenCRNCYABRVTN.Value = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                    HiddenTotalAmount.Value = dt.Rows[0]["RECPT_TOTAL_AMT"].ToString();
                    txtTotalAmt.Value = dt.Rows[0]["RECPT_TOTAL_AMT"].ToString();
                    txtTotal.Text = dt.Rows[0]["RECPT_TOTAL_AMT"].ToString();
                }
                if (dt.Rows[0]["RCPT_EXCHANGE_RATE"].ToString() != "")
                {

                    divExchangecurency.Attributes["style"] = "display:block;";
                    txtExchangeRate.Text = dt.Rows[0]["RCPT_EXCHANGE_RATE"].ToString();

                    divForeXAmt.Attributes["style"] = "display:block;margin-bottom:20px;width: 32%;float: right;";
                    //  txtExchangeRate.Text ="";
                    decimal ForxTtl = Convert.ToDecimal(dt.Rows[0]["RCPT_EXCHANGE_RATE"].ToString()) * Convert.ToDecimal(dt.Rows[0]["RECPT_TOTAL_AMT"].ToString());
                    txtForexAmt.Value = ForxTtl.ToString() + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                    ObjEntityRequest.CurrcyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());
                    DataTable dtSubConrt = objBussiness.ReadCrncyAbrvtn(ObjEntityRequest);
                    // dtSubConrt.TableName = "dtTableLoadProduct";
                    //  string ABVRTN;
                    if (dtSubConrt.Rows.Count > 0)
                    {
                        lblCrncyAbrvtn.Text = dtSubConrt.Rows[0][0].ToString();

                    }
                    ObjEntityRequest.CurrcyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
                    DataTable dtSubConrtTTl = objBussiness.ReadCrncyAbrvtn(ObjEntityRequest);
                    if (dtSubConrt.Rows.Count > 0)
                    {
                        HiddenCRNCYABRVTN.Value = dtSubConrtTTl.Rows[0][0].ToString();

                    }


                    //   lblCrncyAbrvtn.Text=

                }

            }

            if (dt.Rows[0]["RECPT_DSCRPTN"].ToString() != "")
            {
                txtDesc.Value = dt.Rows[0]["RECPT_DSCRPTN"].ToString();

            }

            ddlMode_BankTransfer.ClearSelection();
            if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() != "")
            {
                if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "0")
                {

                    ddlChequeBank.Value = dt.Rows[0]["RCPT_BANK_NAME"].ToString();
                    txtChequeIBAN.Value = dt.Rows[0]["RCPT_IBAN_NO"].ToString();
                    if (Request.QueryString["Rid"] == null)
                    {
                        txtDate_Cheque.Value = dt.Rows[0]["RCPT_PAMNT_DATE"].ToString();
                        txtChequeNo_Cheque.Value = dt.Rows[0]["RCPT_CHEQUE_NO"].ToString();
                    }
                }
                else if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "1")
                {
                    HiddenPaymode.Value = "1";

                    ddlDDBank.Value = dt.Rows[0]["RCPT_BANK_NAME"].ToString();
                    txtDDIBAN.Value = dt.Rows[0]["RCPT_IBAN_NO"].ToString();
                    if (Request.QueryString["Rid"] == null)
                    {
                        txtDate_DD.Value = dt.Rows[0]["RCPT_PAMNT_DATE"].ToString();
                        txtDD_DD.Value = dt.Rows[0]["RCPT_DD_NO"].ToString();
                    }
                }
                else if (dt.Rows[0]["RCPT_PAYMNT_MOD"].ToString() == "2")
                {
                    HiddenPaymode.Value = "2";

                    ddlTransfrBank.Value = dt.Rows[0]["RCPT_BANK_NAME"].ToString();

                    txtTranserIBAN.Value = dt.Rows[0]["RCPT_IBAN_NO"].ToString();
                    if (Request.QueryString["Rid"] == null)
                    {
                        txtDate_BankTransfer.Value = dt.Rows[0]["RCPT_PAMNT_DATE"].ToString();
                    }
                    if (ddlMode_BankTransfer.Items.FindByValue(dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString()) != null)
                    {
                        ddlMode_BankTransfer.Items.FindByValue(dt.Rows[0]["RCPT_TRANSFR_MODE"].ToString()).Selected = true;
                    }

                }

            }

            AcntCloseSts = AccountCloseCheck(dt.Rows[0]["RECPT_DATE"].ToString());
            AuditCloseSts = AuditCloseCheck(dt.Rows[0]["RECPT_DATE"].ToString());

            if (Request.QueryString["Rid"] != null)
            {
                AcntCloseSts = AccountCloseCheck(txtdate.Value);
                AuditCloseSts = AuditCloseCheck(txtdate.Value);
            }

            if (Request.QueryString["Rid"] == null)
            {
                if (dt.Rows[0]["RECPT_CNFRM_STS"].ToString() == "1")
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


                    btnPRint.Visible = true;
                    btnConfirm.Visible = false;
                    btnFloatConfirm.Visible = false;
                    btnUpdate.Visible = false;
                    btnUpdatecls.Visible = false;
                    //EVm-0027 12-04
                    btnFloatUpdate.Visible = false;
                    btnFloatUpdateCls.Visible = false;
                    btnFloatPrint.Visible = true;
                    //End
                    if (HiddenReopenSts.Value == "1")
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

                }
                else
                {
                    btnReopen.Visible = false;
                    btnFloatReopen.Visible = false;
                }
            }

            if (dt.Rows[0]["RECPT_CNCL_USR_ID"].ToString() == "" && dt.Rows[0]["RECPT_CNFRM_STS"].ToString() != "1")
            {
                btnPRint.Visible = true;
                btnPRint.Text = "Draft Print";

                btnFloatPrint.Visible = true;
                btnFloatPrint.Text = "Draft Print";
            }
            if (Request.QueryString["Rid"] == null)
            {
                if (HiddenView.Value == "1" || dt.Rows[0]["RECPT_CNCL_USR_ID"].ToString() != "" || HiddenAcntClsSts.Value == "1")
                {

                    btnRecurMinus.Disabled = true;
                    btnRecurPlus.Disabled = true;
                    btnRecurrSave.Disabled = true;
                    ddlRecurPeriod.Disabled = true;
                    txtRemindDays.Disabled = true;

                    if (dt.Rows[0]["REPAREC_PERIOD"].ToString() == "")
                    {
                        divRecur.Visible = false;
                    }


                    btnUpdate.Visible = false;
                    btnUpdatecls.Visible = false;
                    //EVM-0027 12-04
                    btnFloatUpdate.Visible = false;
                    btnFloatUpdateCls.Visible = false;
                    //END
                    txtDesc.Disabled = true;
                    ddlAccontLed.Enabled = false;
                    txtdate.Disabled = true;
                    ddlCurrency.Enabled = false;
                    btnConfirm.Visible = false;
                    btnFloatConfirm.Visible = false;
                    ddlChequeBank.Disabled = true;
                    txtChequeIBAN.Disabled = true;
                    txtDate_Cheque.Disabled = true;
                    ddlDDBank.Disabled = true;
                    txtDate_DD.Disabled = true;

                    txtDD_DD.Disabled = true;
                    ddlTransfrBank.Disabled = true;
                    txtTranserIBAN.Disabled = true;
                    txtDate_BankTransfer.Disabled = true;
                    ddlMode_BankTransfer.Enabled = false;
                    txtDDIBAN.Disabled = true;
                    ddlTransfrBank.Attributes["style"] = "width: 100%;background-color: #eee;";
                    ddlDDBank.Attributes["style"] = "width: 100%;background-color: #eee;";
                    txtChequeNo_Cheque.Attributes["style"] = "width: 100%;background-color: #eee;";
                    ddlChequeBank.Attributes["style"] = "width: 100%;background-color: #eee;";
                    txtChequeIBAN.Attributes["style"] = "width: 100%;background-color: #eee;";
                    txtDate_Cheque.Attributes["style"] = "width: 100%;background-color: #eee;";
                    txtDate_DD.Attributes["style"] = "width: 100%;background-color: #eee;";
                    txtDDIBAN.Attributes["style"] = "width: 100%;background-color: #eee;";
                    txtDate_BankTransfer.Attributes["style"] = "width: 100%;background-color: #eee;";
                    txtTranserIBAN.Attributes["style"] = "width: 100%;background-color: #eee;";
                    HiddenView.Value = "1";

                }
            }

            decimal value = 0;
            int precision = Convert.ToInt32(hiddenDecimalCount.Value);
            string format = String.Format("{{0:N{0}}}", precision);
            string valuestring = String.Format(format, value);


            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add("RCPT_ID", typeof(int));
            dtDetail.Columns.Add("RCPT_LDGR_ID", typeof(int));
            dtDetail.Columns.Add("LDGR_ID", typeof(int));
            dtDetail.Columns.Add("LDGR_AMT", typeof(string));
            dtDetail.Columns.Add("LDGR_NAME", typeof(string));
            dtDetail.Columns.Add("LDGR_REMARKS", typeof(string));
            dtDetail.Columns.Add("ROW_COUNT", typeof(string));

            dtDetail.Columns.Add("PYMNT_CST_ID", typeof(int));
            dtDetail.Columns.Add("COSTCNTR_ID", typeof(string));
            dtDetail.Columns.Add("PYMNT_CST_AMT", typeof(string));
            dtDetail.Columns.Add("PURCHS_ID", typeof(string));
            dtDetail.Columns.Add("RECPT_PURCHS_REF", typeof(string));
            dtDetail.Columns.Add("COST_LD", typeof(int));
            dtDetail.Columns.Add("SALES_ID", typeof(string));
            dtDetail.Columns.Add("OB_PAID", typeof(string));

            string NewRev = "";
            int first = 0, firstcst = 0;
            DataTable dtLDGRdTLS = objBussiness.ReadReceptLedgerDetailsById(ObjEntityRequest);

            for (int intCount = 0; intCount < dtLDGRdTLS.Rows.Count; intCount++)
            {
                DataRow drDtl = dtDetail.NewRow();
                drDtl["ROW_COUNT"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["ROWCNT"].ToString());
                drDtl["RCPT_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["RECPT_ID"].ToString());
                drDtl["RCPT_LDGR_ID"] = Convert.ToInt32(dtLDGRdTLS.Rows[intCount]["RECPT_LD_ID"].ToString());
                drDtl["LDGR_REMARKS"] = dtLDGRdTLS.Rows[intCount]["RCPT_LD_REMARKS"].ToString();

                int revflg = 0;
                    string[] newRev1 = NewRev.Split(',');
                    for (int i = 0; i < newRev1.Length; i++)
                    {
                        if (newRev1[i] != dtLDGRdTLS.Rows[intCount]["RECPT_LD_ID"].ToString())
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
                        NewRev = NewRev + "," + dtLDGRdTLS.Rows[intCount]["RECPT_LD_ID"].ToString();
                        first = 1; firstcst = 1;
                        for (int intCountinn = 0; intCountinn < dtLDGRdTLS.Rows.Count; intCountinn++)
                        {
                            if (dtLDGRdTLS.Rows[intCount]["RECPT_LD_ID"].ToString() == dtLDGRdTLS.Rows[intCountinn]["RECPT_LD_ID"].ToString())
                            {
                                if (dtLDGRdTLS.Rows[intCountinn]["OBPAID_AMT"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["OBBAL_AMT"].ToString() != "")
                                {
                                    drDtl["OB_PAID"] = dtLDGRdTLS.Rows[intCountinn]["OBPAID_AMT"].ToString() + "#" + dtLDGRdTLS.Rows[intCountinn]["OBBAL_AMT"].ToString();
                                }

                                if (firstcst == 1)
                                {
                                    if (dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_AMT"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_AMT"].ToString() != valuestring)
                                    {
                                        int CstGrpId_one = 0;
                                        int CstGrpId_Two = 0;


                                        if (dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_AMT"].ToString() != "")
                                        {
                                            drDtl["PYMNT_CST_AMT"] = dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_AMT"].ToString();
                                        }
                                        if (dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString() != "")
                                        {
                                            CstGrpId_one = Convert.ToInt32(dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString());
                                        }
                                        if (dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString() != "")
                                        {
                                            CstGrpId_Two = Convert.ToInt32(dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString());
                                        }
                                        if (dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() != "")
                                        {
                                            drDtl["COSTCNTR_ID"] = dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() + "%" + drDtl["PYMNT_CST_AMT"] + "%" + "UPD" + "%" + dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_ID"].ToString() + "%" + CstGrpId_one + "%" + CstGrpId_Two;
                                        }
                                    }
                                    firstcst++;
                                }
                                else
                                {
                                    if (dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_AMT"].ToString() != "")
                                    {
                                        int CstGrpId_one = 0;
                                        int CstGrpId_Two = 0;

                                        if (dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString() != "")
                                        {
                                            CstGrpId_one = Convert.ToInt32(dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_ONE"].ToString());
                                        }
                                        if (dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString() != "")
                                        {
                                            CstGrpId_Two = Convert.ToInt32(dtLDGRdTLS.Rows[intCountinn]["COSTGRP_ID_TWO"].ToString());
                                        }

                                        if (dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_AMT"].ToString() != "")
                                        {
                                            drDtl["PYMNT_CST_AMT"] = dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_AMT"].ToString();
                                        }
                                        if (dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() != "")
                                        {
                                            drDtl["COSTCNTR_ID"] = drDtl["COSTCNTR_ID"] + "$" + dtLDGRdTLS.Rows[intCountinn]["COSTCNTR_ID"].ToString() + "%" + drDtl["PYMNT_CST_AMT"] + "%" + "UPD" + "%" + dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_ID"].ToString() + "%" + CstGrpId_one + "%" + CstGrpId_Two;
                                        }
                                    }
                                }

                                if (first == 1)
                                {
                                    if (dtLDGRdTLS.Rows[intCountinn]["SALES_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_AMT"].ToString() != "")
                                    {
                                        if (dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_AMT"].ToString() != "")
                                        {
                                            drDtl["PYMNT_CST_AMT"] = dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_AMT"].ToString();
                                        }
                                        if (dtLDGRdTLS.Rows[intCountinn]["SALES_ID"].ToString() != "")
                                        {

                                            string strCreDDl = "0";
                                            if (dtLDGRdTLS.Rows[intCountinn]["LDGR_CR_ID"].ToString() != "")
                                            {
                                                strCreDDl = dtLDGRdTLS.Rows[intCountinn]["LDGR_CR_ID"].ToString();
                                            }

                                            drDtl["SALES_ID"] = dtLDGRdTLS.Rows[intCountinn]["SALES_ID"].ToString() + "%" + drDtl["PYMNT_CST_AMT"] + "%" + dtLDGRdTLS.Rows[intCountinn]["BALNC_AMT"].ToString() + "%%" + strCreDDl + "%" + dtLDGRdTLS.Rows[intCountinn]["CREDITNOTE_BAL"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["CREDITNOTE_SETLAMNT"].ToString();
                                        }
                                    }
                                    first++;
                                }
                                else
                                {
                                    if (dtLDGRdTLS.Rows[intCountinn]["SALES_ID"].ToString() != "" && dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_AMT"].ToString() != "")
                                    {
                                        if (dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_AMT"].ToString() != "")
                                        {
                                            drDtl["PYMNT_CST_AMT"] = dtLDGRdTLS.Rows[intCountinn]["RECPT_CST_AMT"].ToString();
                                        }
                                        if (dtLDGRdTLS.Rows[intCountinn]["SALES_ID"].ToString() != "")
                                        {
                                            string strCreDDl = "0";
                                            if (dtLDGRdTLS.Rows[intCountinn]["LDGR_CR_ID"].ToString() != "")
                                            {
                                                strCreDDl = dtLDGRdTLS.Rows[intCountinn]["LDGR_CR_ID"].ToString();
                                            }

                                            drDtl["SALES_ID"] = drDtl["SALES_ID"] + "$" + dtLDGRdTLS.Rows[intCountinn]["SALES_ID"].ToString() + "%" + drDtl["PYMNT_CST_AMT"] + "%" + dtLDGRdTLS.Rows[intCountinn]["BALNC_AMT"].ToString() + "%%" + strCreDDl + "%" + dtLDGRdTLS.Rows[intCountinn]["CREDITNOTE_BAL"].ToString() + "%" + dtLDGRdTLS.Rows[intCountinn]["CREDITNOTE_SETLAMNT"].ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        drDtl["LDGR_ID"] = 0;
                    }



                if (dtLDGRdTLS.Rows[intCount]["LDGR_ID"].ToString() != "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "AccntChangeFunt", "AccntChangeFunt();", true);

                }

                drDtl["LDGR_AMT"] = dtLDGRdTLS.Rows[intCount]["RECPT_LD_AMT"].ToString();

                if (dtLDGRdTLS.Rows[intCount]["LDGR_NAME"].ToString() != "")
                {
                    drDtl["LDGR_NAME"] = dtLDGRdTLS.Rows[intCount]["LDGR_NAME"].ToString();
                }
                else
                {
                    drDtl["LDGR_NAME"] = "";
                }
                dtDetail.Rows.Add(drDtl);
            }
            string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);

            if (Request.QueryString["Rid"] == null)
            {
                if (dt.Rows[0]["RECPT_CNFRM_STS"].ToString() == "0" && dt.Rows[0]["RECPT_CNCL_USR_ID"].ToString() == "" && HiddenView.Value == "0" && HiddenAcntClsSts.Value != "1")
                {
                    HiddenEdit.Value = strJson;
                }
                else
                {
                    HiddenViewDtls.Value = strJson;
                }
            }
            else
            {
                HiddenEdit.Value = strJson;
            }

            if (dt.Rows[0]["RECPT_CNCL_USR_ID"].ToString() != "")
            {
                btnPRint.Visible = false;
                btnFloatPrint.Visible = false;
            }

            if (dt.Rows[0]["PST_CHEQUE_DTLS_ID"].ToString() != "")
            {
                hiddenPostdated.Value = "1";
                ddlAccontLed.Enabled = false;
                txtdate.Disabled = true;
                divRecur.Visible = false;
                ddlChequeBank.Disabled = true;
                txtChequeIBAN.Disabled = true;
                txtChequeNo_Cheque.Disabled = true;
                spandate.Attributes.Add("style", "pointer-events:none");
                spanChqDate.Attributes.Add("style", "pointer-events:none");
                txtDate_Cheque.Disabled = true;
            }


            if (YearEndCls == 1)
            {
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
            }

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
    //private void SortDDL(ref DropDownList objDDL)
    //{
    //    System.Collections.ArrayList textList = new System.Collections.ArrayList();
    //    System.Collections.ArrayList valueList = new System.Collections.ArrayList();
    //    foreach (ListItem li in objDDL.Items)
    //    {
    //        textList.Add(li.Text);
    //    }
    //    textList.Sort();
    //    foreach (object item in textList)
    //    {
    //        string value = objDDL.Items.FindByText(item.ToString()).Value;
    //        valueList.Add(value);
    //    }
    //    objDDL.Items.Clear();

    //    for (int i = 0; i < textList.Count; i++)
    //    {
    //        ListItem objItem = new ListItem(textList[i].ToString(), valueList[i].ToString());
    //        objDDL.Items.Add(objItem);
    //    }
    //}
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
    [WebMethod]

    public static string ReadreceiptCstcntr(string strOrgId, string strCorpId, string strldgrId)
    {
        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();
        ObjEntityRequest.Organisation_id = Convert.ToInt32(strOrgId);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(strCorpId);
        ObjEntityRequest.LedgerId = Convert.ToInt32(strldgrId);
       


        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("RECPT_CST_ID", typeof(int));
        dtDetail.Columns.Add("COSTCNTR_ID", typeof(int));
        dtDetail.Columns.Add("RECPT_ID", typeof(int));
        dtDetail.Columns.Add("RECPT_CST_AMT", typeof(string));
        dtDetail.Columns.Add("RECPT_LD_ID", typeof(int));
        dtDetail.Columns.Add("SALES_ID", typeof(int));
        dtDetail.Columns.Add("RECPT_SALES_REF", typeof(string));
        dtDetail.Columns.Add("ROWCOUNT", typeof(int));
        dtDetail.Columns.Add("SALEAMOUNT", typeof(string));
        DataTable dtSubConrt = objBussiness.ReadReceptCostcntrDetailsById(ObjEntityRequest);
        dtSubConrt.TableName = "dtTableLoadcstcntr";

        for (int intCount = 0; intCount < dtSubConrt.Rows.Count; intCount++)
        {

            DataRow drDtl = dtDetail.NewRow();
            drDtl["ROWCOUNT"] = dtSubConrt.Rows.Count;
            drDtl["RECPT_CST_ID"] = Convert.ToInt32(dtSubConrt.Rows[intCount]["RECPT_CST_ID"].ToString());
            if (dtSubConrt.Rows[intCount]["COSTCNTR_ID"].ToString() != "")
            {
                drDtl["COSTCNTR_ID"] = Convert.ToInt32(dtSubConrt.Rows[intCount]["COSTCNTR_ID"].ToString());
            }
            else
            {
                drDtl["COSTCNTR_ID"] = 0;
            }
            drDtl["RECPT_ID"] = Convert.ToInt32(dtSubConrt.Rows[intCount]["RECPT_ID"].ToString());
            drDtl["RECPT_CST_AMT"] = dtSubConrt.Rows[intCount]["RECPT_CST_AMT"].ToString();
            drDtl["RECPT_LD_ID"] = Convert.ToInt32(dtSubConrt.Rows[intCount]["RECPT_LD_ID"].ToString());
            if (dtSubConrt.Rows[intCount]["SALES_ID"].ToString() != "")
            {
                drDtl["SALES_ID"] = Convert.ToInt32(dtSubConrt.Rows[intCount]["SALES_ID"].ToString());
                drDtl["RECPT_SALES_REF"] = dtSubConrt.Rows[intCount]["SALES_REF"].ToString();
                drDtl["SALEAMOUNT"] = dtSubConrt.Rows[intCount]["BALNC_AMT"].ToString();

            }
            else
            {
                drDtl["SALES_ID"] = 0;
            }


            dtDetail.Rows.Add(drDtl);
        }

        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);

        //string result;
        //using (StringWriter sw = new StringWriter())
        //{
        //    dtSubConrt.WriteXml(sw);
        //    result = sw.ToString();
        //}

        return strJson;
    }

    public void CostGroup1Load()
    {
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

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
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

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
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

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
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

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


    public void CurrencyLoad()
    {
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

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
        ddlCurrency.ClearSelection();
        DataTable dtSubConrt = objBussiness.ReadCurrency(ObjEntityRequest);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtSubConrt;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();

        }
        //ddlCurrency.Items.Insert(0, "--SELECT--");
        ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");

        DataTable dtDefaultcurc = objBussiness.ReadDefualtCurrency(ObjEntityRequest);
        if (dtDefaultcurc.Rows.Count > 0)
        {
            string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
            {
                ddlCurrency.ClearSelection();
                ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
            }

        }
    }

    public void AccountLedgerLoad()
    {
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();
        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusiness = new clsBusinessLayer();

       

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntityRequest.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"]);
            objEntityCommon.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"]);
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
        objEntityCommon.PrimaryGrpIds = Convert.ToString(Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.BANK) + "," + Convert.ToInt32(clsCommonLibrary.PRIMARYGRP.CASHINHND));
        DataTable dtSubConrt = objBusiness.ReadLedgers(objEntityCommon);
        //DataTable dtSubConrt = objBussiness.ReadAccountLedger(ObjEntityRequest);
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


    protected void bttnsave_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();
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
        if (ddlCurrency.SelectedItem.Value == hiddenDfltCurrencyMstrId.Value)
        {
            ObjEntityRequest.CurrcyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            ObjEntityRequest.ExchangeRate = 0;
        }
        else
        {
            ObjEntityRequest.CurrcyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            ObjEntityRequest.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Text);
        }
        ObjEntityRequest.Description = txtDesc.Value;
        if (HiddenTotalAmount.Value != "")
        {
            ObjEntityRequest.TotalAmnt = Convert.ToDecimal(HiddenTotalAmount.Value);
        }

        if (HiddenPrevTab.Value == "Cheque")
        {
            if (ddlChequeBank.Value != "")
            {
                ObjEntityRequest.Bank_Name = ddlChequeBank.Value;
            }
            if (txtChequeIBAN.Value.Trim() != "")
            {
                ObjEntityRequest.IbanNo = txtChequeIBAN.Value.Trim();
            }
            if (txtChequeNo_Cheque.Value.Trim() != "")
            {
                ObjEntityRequest.ChequeBook_No = txtChequeNo_Cheque.Value.Trim();
            }
            ObjEntityRequest.PaymentDate = objcommon.textToDateTime(txtDate_Cheque.Value);
            ObjEntityRequest.PaymentMod = 0;
        }
        else if (HiddenPrevTab.Value == "DD")
        {
            ObjEntityRequest.PaymentMod = 1;
            if (ddlDDBank.Value != "")
            {
                ObjEntityRequest.Bank_Name = ddlDDBank.Value;
            }
            if (txtDDIBAN.Value.Trim() != "")
            {
                ObjEntityRequest.IbanNo = txtDDIBAN.Value.Trim();
            }
            ObjEntityRequest.PaymentDate = objcommon.textToDateTime(txtDate_DD.Value);
            ObjEntityRequest.DDNumber = txtDD_DD.Value;
        }
        else if (HiddenPrevTab.Value == "BankTransfer")
        {
            ObjEntityRequest.PaymentMod = 2;
            if (ddlTransfrBank.Value != "")
            {
                ObjEntityRequest.Bank_Name = ddlTransfrBank.Value;
            }
            if (txtTranserIBAN.Value.Trim() != "")
            {
                ObjEntityRequest.IbanNo = txtTranserIBAN.Value.Trim();
            }
            ObjEntityRequest.PaymentDate = objcommon.textToDateTime(txtDate_BankTransfer.Value);
            ObjEntityRequest.TransferModId = Convert.ToInt32(ddlMode_BankTransfer.SelectedItem.Value);

        }
        else
        {
            ObjEntityRequest.PaymentMod = 3;
        }
        int AcntCloseSts = AccountCloseCheck(txtdate.Value);
        int AuditCloseSts = AuditCloseCheck(txtdate.Value);

        if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
        {
            Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=AuditClosed");
        }
        else if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
        {

        }
        else if (AcntCloseSts == 1 && HiddenProvisionSts.Value != (clsCommonLibrary.StatusAll.Active).ToString())
        {
            Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=AcntClosed");
        }


        //Start:-Recurrence
        if (HiddenFieldRecurrencyPeriod.Value != "")
        {
            ObjEntityRequest.RecurPeriodId = Convert.ToInt32(HiddenFieldRecurrencyPeriod.Value);
            ObjEntityRequest.RecurRemindDays = Convert.ToInt32(HiddenFieldRemindDays.Value);
        }
        //End:-Recurrence

        List<clsEntity_Receipt_Account> objEntityPerfomList = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> objEntityPerfomListGrps = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> objEntityInsertToVT = new List<clsEntity_Receipt_Account>();//EVM-0027

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

            foreach (clsAccntDetails objClsVideoAddAttDat in objVideoDataDltAttList)
            {
                clsEntity_Receipt_Account objSubEntityGrp = new clsEntity_Receipt_Account();

                objSubEntityGrp.LedgerRow = Convert.ToInt32(objClsVideoAddAttDat.LEDGERID);
                objSubEntityGrp.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttDat.LEDGERID]);
                objSubEntityGrp.Remarks = Request.Form["TxtRemark" + objClsVideoAddAttDat.LEDGERID];
                if (Request.Form["TxtAmount_" + objClsVideoAddAttDat.LEDGERID] != "")
                {
                    objSubEntityGrp.LedgerAmnt = Convert.ToDecimal(Request.Form["TxtAmount_" + objClsVideoAddAttDat.LEDGERID]);
                }

                string CostCenterDtl = Request.Form["tdCostCenterDtls" + objClsVideoAddAttDat.LEDGERID];
                if (CostCenterDtl != "" && CostCenterDtl != null && CostCenterDtl != "null")
                {
                    string[] CostCenterDtlvalues = CostCenterDtl.Split('$');
                    for (int i = 0; i < CostCenterDtlvalues.Length; i++)
                    {
                        clsEntity_Receipt_Account objSubEntity = new clsEntity_Receipt_Account();

                        objSubEntity.LedgerRow = Convert.ToInt32(objClsVideoAddAttDat.LEDGERID);
                        objSubEntity.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttDat.LEDGERID]);
                        string[] valSplit = CostCenterDtlvalues[i].Split('%');
                        objSubEntity.CostCtrId = Convert.ToInt32(valSplit[0]);
                        valSplit[1] = valSplit[1].Replace(",", "");
                        objSubEntity.CstCntrAmnt = Convert.ToDecimal(valSplit[1]);
                        if (valSplit[4] != "" && valSplit[4] != null)
                        {
                            objSubEntity.CostGrp1Id = Convert.ToInt32(valSplit[4]);
                        }
                        if (valSplit[5] != "" && valSplit[5] != null)
                        {
                            objSubEntity.CostGrp2Id = Convert.ToInt32(valSplit[5]);
                        }
                        objEntityPerfomList.Add(objSubEntity);
                    }
                }

                string OBtoVT = Request.Form["tdLedgrPaid" + objClsVideoAddAttDat.LEDGERID];
                clsEntity_Receipt_Account objSubEntityOB = new clsEntity_Receipt_Account();
                if (OBtoVT != "" && OBtoVT != "null" && OBtoVT != null)
                {
                    string[] OBvalues = OBtoVT.Split('#');
                    objSubEntityOB.FromDate = ObjEntityRequest.FromDate;
                    objSubEntityOB.LedgerRow = Convert.ToInt32(objClsVideoAddAttDat.LEDGERID);
                    objSubEntityOB.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttDat.LEDGERID]);
                    objSubEntityOB.Status = 1;
                    objSubEntityOB.PaidAmt = Convert.ToDecimal(OBvalues[0]);
                    objSubEntityOB.BalnceAmt = Convert.ToDecimal(OBvalues[1]);
                    objSubEntityOB.Organisation_id = ObjEntityRequest.Organisation_id;
                    objSubEntityOB.Corporate_id = ObjEntityRequest.Corporate_id;
                    objEntityInsertToVT.Add(objSubEntityOB);
                    objEntityPerfomList.Add(objSubEntityOB);
                }
                string PurchaseDtl = Request.Form["tdSalesDtls" + objClsVideoAddAttDat.LEDGERID];
                if (PurchaseDtl != "" && PurchaseDtl != null && PurchaseDtl != "null")
                {
                    string[] values = PurchaseDtl.Split('$');
                    for (int i = 0; i < values.Length; i++)
                    {
                        clsEntity_Receipt_Account objSubEntity = new clsEntity_Receipt_Account();

                        objSubEntity.LedgerRow = Convert.ToInt32(objClsVideoAddAttDat.LEDGERID);
                        objSubEntity.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttDat.LEDGERID]);
                        string[] valSplit = values[i].Split('%');
                        objSubEntity.CostCtrId = Convert.ToInt32(valSplit[0]);
                        if (valSplit[1] != "" || valSplit[6] != "")
                        {
                            if (valSplit[1] != "")
                            {
                                valSplit[1] = valSplit[1].Replace(",", "");
                                objSubEntity.CstCntrAmnt = Convert.ToDecimal(valSplit[1]);
                            }
                            objSubEntity.Status = 1;
                            valSplit[5] = valSplit[5].Replace(",", "");
                            valSplit[6] = valSplit[6].Replace(",", "");
                            objSubEntity.AccntNameId = Convert.ToInt32(valSplit[4]);
                            if (valSplit[5] != "")
                                objSubEntity.BalanceAmount = Convert.ToDecimal(valSplit[5]);
                            if (valSplit[6] != "")
                                objSubEntity.LedgerAmnt = Convert.ToDecimal(valSplit[6]);

                            if (objSubEntity.CstCntrAmnt > 0 || objSubEntity.LedgerAmnt > 0)
                            {
                                objEntityPerfomList.Add(objSubEntity);
                            }
                        }
                    }
                }
                objEntityPerfomListGrps.Add(objSubEntityGrp);

            }

            objBussiness.InsertReceiptDtls(ObjEntityRequest, objEntityPerfomListGrps, objEntityPerfomList);
        }

        if (clickedButton.ID == "bttnsave")
        {
            Response.Redirect("fms_Receipt_Account.aspx?InsUpd=Ins");
        }
        else if (clickedButton.ID == "btnSaveCls")
        {
            Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=Ins");
        }
        //EVM-0027 12-04
        else if (clickedButton.ID == "btnFloatSave")
        {

            Response.Redirect("fms_Receipt_Account.aspx?InsUpd=Ins");
        }
        else if (clickedButton.ID == "btnFloatSaveCls")
        {
            Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=Ins");

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
    public static string[] LoadSalesForLedger(string intLedgerId, string intuserid, string intorgid, string intcorpid, string x, string rcptLdId, string chngSts, string CrncyAbrvtn, string rcptId, string View, string LedgerDtlId)
    {

        string[] result = new string[7];

        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();
        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

        ObjEntityRequest.ReceiptId = Convert.ToInt32(rcptId);
        ObjEntityRequest.LedgerId = Convert.ToInt32(intLedgerId);
        ObjEntityRequest.LedId = Convert.ToInt32(intLedgerId);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(intcorpid);
        if (LedgerDtlId != "")
        {
            ObjEntityRequest.ReceiptLedgrId = Convert.ToInt32(LedgerDtlId);
        }

        DataTable dtSales = objBussiness.ReadSalesbyId(ObjEntityRequest);//Sales
        DataTable dtForOB = objBussiness.ReadOepningBalById(ObjEntityRequest);//Opening balance
        DataTable dtCreNote = objBussiness.ReadDebitNoteList(ObjEntityRequest);//Debit note
        DataTable dtSalesReturn = objBussiness.ReadPurchaseReturnbyId(ObjEntityRequest);//Purchase return

        DataTable dtSubConrt = new DataTable();
        if (rcptLdId != "")
        {
            ObjEntityRequest.LedgerId = Convert.ToInt32(rcptLdId);
            ObjEntityRequest.Status = 2;
            dtSubConrt = objBussiness.ReadReceptCostcntrDetailsById(ObjEntityRequest);//Details by Id
        }

        StringBuilder sb = new StringBuilder();
        StringBuilder sbGrp = new StringBuilder();

        string SettldFully = "";
        string Groupid = "";
        string CopyGroupid = ""; 
        int SettledCnt = 0;
        int intOBSts = 0;
        string strDebCr = "";
        if (dtForOB.Rows.Count > 0)
        {
            if (Convert.ToDecimal(dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString()) != 0)
            {
                intOBSts = 1;
                sb.Append("<tr class=\"tr_opn\">");
                sb.Append("<td>Opening Balance</td>");
                sb.Append("<td></td>");
                if (dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                {
                    if (Convert.ToDecimal(dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString()) > 0)
                    {
                        strDebCr = "DR";
                    }
                    else
                    {
                        strDebCr = "CR";
                    }
                }
                sb.Append("<td class=\"tr_r\" id=\"tdOpeningBalnc" + x + "\"  name=\"tdOpeningBalnc" + x + "\" >" + dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString() +" "+strDebCr +"</td>");
                sb.Append("<td style=\"display:none;\" id=\"tdDupOBAmnt" + x + "\" >" + dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString() + "</td>");//evm-0020

                sb.Append("<td>");
                sb.Append("<div class=\"input-group in1\">");

                if (dtForOB.Rows[0]["OBPAID_AMT"].ToString() != "0" && dtForOB.Rows[0]["OBPAID_AMT"].ToString() != "")
                    sb.Append("<input type=\"text\" autocomplete=\'off\'  class=\"form-control fg2_inp2 tr_r\" value=\"" + dtForOB.Rows[0]["OBPAID_AMT"].ToString() + "\"  id=\"txtOpeningBalnc" + x + "\"  name=\"txtOpeningBalnc" + x + "\"   onchange=\"return AmountCalculationForOB(" + x + ");\" onkeydown=\"return isDecimalNumber(event,this.id)\" onkeypress=\"return isDecimalNumber(event,this.id)\"  />");
                else
                    sb.Append("<input type=\"text\" autocomplete=\'off\'  class=\"form-control fg2_inp2 tr_r\" value=\"\"  id=\"txtOpeningBalnc" + x + "\"  name=\"txtOpeningBalnc" + x + "\"   onchange=\"return AmountCalculationForOB(" + x + ");\" onkeydown=\"return isDecimalNumber(event,this.id)\" onkeypress=\"return isDecimalNumber(event,this.id)\"  />");
                sb.Append("</div>");
                decimal decBalnceAmt = Convert.ToDecimal(dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString());
                if (dtForOB.Rows[0]["OBPAID_AMT"].ToString() != "")
                {
                    decBalnceAmt = decBalnceAmt - Convert.ToDecimal(dtForOB.Rows[0]["OBPAID_AMT"].ToString());
                }
                sb.Append("<span class=\"input-group-addon cur2 flt_r\" id=\"SpanOpeningBalance" + x + "\" name=\"SpanOpeningBalance" + x + "\">" + decBalnceAmt.ToString() + " " + CrncyAbrvtn + "</span>");
                sb.Append("</td>");
                sb.Append("<td colspan=\"4\"></td>");
                sb.Append("</tr>");
            }

        }

        if (dtSales.Rows.Count > 0)
        {
            //----------------------------Sales master------------------------------

            if (dtSubConrt.Rows.Count == 0)//if no settlemnts saved
            {
                for (int row1 = 0; row1 < dtSales.Rows.Count; row1++)
                {
                    sb.Append("<tr class=\"tr1\" id=\"SelectRow_" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >");
                    sb.Append("<td style=\"display:none;\" id=\"tdSaleID" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["SALES_ID"].ToString() + "</td>");
                    sb.Append("<td style=\"display:none; \" ><input type=\"text\" class=\"txtVal\" value=\"" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" id=\"cbMandatory" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" ></td>");

                    sb.Append("<th scope=\"row\" class=\"td1\"  id=\"tdSaleRef" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["SALES_REF"].ToString() + "</th>");
                    sb.Append("<td style=\"display:none; \"></td>");
                    sb.Append("<td>" + dtSales.Rows[row1]["SALES_DATE"].ToString() + " </td>");
                    sb.Append("<td id=\"tdBalnc" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" class=\"tr_r\">" + dtSales.Rows[row1]["BALNC_AMT"].ToString() + "</td>");

                    sb.Append("<td style=\"display:none;\" id=\"tdRef" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["SALES_REF"].ToString() + "</td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdDate" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["SALES_DATE"].ToString() + "</td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdAmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["BALNC_AMT"].ToString() + " </td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdsettlmntAmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\">" + dtSales.Rows[row1]["BALNC_AMT"].ToString() + " </td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdLedgerRow" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + x + "</td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdDupAmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["BALNC_AMT"].ToString() + " </td>");

                    sb.Append("<td class=\"td1 tr_r\" id=\"tdtxtAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >");
                    sb.Append("<div class=\"input-group in1\">");
                    sb.Append("<input  autocomplete=\'off\' type=\"text\" class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"     onchange=\"return AmountCalculation(" + dtSales.Rows[row1]["SALES_ID"].ToString() + ");\"   id=\"txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\"  />");
                    sb.Append("</div>");
                    sb.Append("<span id=\"SlsBlnc" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\"  class=\"input-group-addon cur2 c1h flt_r\"><i class=\"fas fa-money-check-alt\"></i>" + dtSales.Rows[row1]["BALNC_AMT"].ToString() + " " + CrncyAbrvtn + "</span>");
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("<label class=\"switch\">");
                    sb.Append("<input disabled type=\"checkbox\" id=\"cbx_sly" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >");
                    sb.Append("<span class=\"slider_tog round\"></span>");
                    sb.Append("</label>");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("<select class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" onchange=\"ddlCreditNoteChange('" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\" id=\"ddlCreditNote" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" disabled>");
                    sb.Append("<option  value=\"0\">-Select DebitNote-</option>");
                    for (int intRowCount = 0; intRowCount < dtCreNote.Rows.Count; intRowCount++)
                    {
                        sb.Append("<option value=\"" + dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() + "\">" + dtCreNote.Rows[intRowCount]["CR_NOTE_REF"].ToString() + "</option>");
                    }
                    sb.Append("</select>");

                    sb.Append("<span id=\"creNoteBalaF" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" class=\"input-group-addon cur2 c1h c1_d1 flt_r\"></span>");

                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("<div class=\"input-group in1\">");
                    sb.Append("<input type=\"text\" class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\" onchange=\"CreditNoteStlmtAmntChange('" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  id=\"txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" disabled>");
                    sb.Append("</div><span class=\"input-group-addon cur2 flt_r\" id=\"creNoteBala" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\">" + dtSales.Rows[row1]["BALNC_AMT"].ToString() + " " + CrncyAbrvtn + "</span>");
                    sb.Append("</td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdCredNoteAmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" ></td>");


                    sb.Append("<td style=\"display: none;\" id=\"tdEvtInx" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\">INS</td>");
                    sb.Append("<td style=\"display: none;\" id=\"tdrcptSalId" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\"></td>");
                    sb.Append("<td style=\"display: none;\"><input type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" id=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" value=\"0\" /></td>");

                    sb.Append("</tr>");

                    result[3] = dtSales.Rows[row1]["LDGR_NAME"].ToString();
                }
            }
            else //if settlemnts saved
            {
                for (int row1 = 0; row1 < dtSales.Rows.Count; row1++)
                {
                    decimal decTotal = 0;
                    decimal decSettleAmt = 0;
                    if (dtSales.Rows[row1]["BALNC_AMT"].ToString() != "")
                    {
                        decTotal = Convert.ToDecimal(dtSales.Rows[row1]["BALNC_AMT"].ToString());
                    }

                    if (View == "1")
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
                    sb.Append("<tr class=\"tr1\" id=\"SelectRow" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >");
                    sb.Append("<td style=\"display:none;\" id=\"tdSaleID" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["SALES_ID"].ToString() + "</td>");
                    sb.Append("<td style=\"display:none; \" ><input type=\"text\" class=\"txtVal\"  onkeypress=\"return DisableEnter(event);\"  value=\"" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" id=\"cbMandatory" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\"></td>");

                    sb.Append("<th scope=\"row\" class=\"td1\" id=\"tdSaleRef" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" \">" + dtSales.Rows[row1]["SALES_REF"].ToString() + "</th>");
                    sb.Append("<td style=\"display:none;\"></td>");
                    sb.Append("<td>" + dtSales.Rows[row1]["SALES_DATE"].ToString() + " </td>");
                    sb.Append("<td id=\"tdBalnc" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" class=\"tr_r\">" + decSettleAmt + "</td>");

                    sb.Append("<td style=\"display:none;\" id=\"tdRef" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["SALES_REF"].ToString() + "</td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdDate" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["SALES_DATE"].ToString() + "</td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdAmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["BALNC_AMT"].ToString() + " </td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdsettlmntAmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSales.Rows[row1]["BALNC_AMT"].ToString() + " </td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdLedgerRow" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + x + "</td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdDupAmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + decSettleAmt + " </td>");

                    int flg = 0;
                    for (int row2 = 0; row2 < dtSubConrt.Rows.Count; row2++)
                    {
                        decimal balAmt = 0;

                        if (dtSubConrt.Rows[row2]["SALES_ID"].ToString() != "" && dtSubConrt.Rows[row2]["SALES_ID"].ToString() == dtSales.Rows[row1]["SALES_ID"].ToString())
                        {
                            if (decSettleAmt == 0)
                            {
                                sb.Append("<td  class=\"td1 tr_r\"  id=\"tdtxtAmt" + dtSubConrt.Rows[row2]["SALES_ID"].ToString() + "\" >");
                                sb.Append("<div class=\"input-group in1\"><input disabled value=" + dtSubConrt.Rows[row2]["RECPT_CST_AMT"].ToString() + " type=\"text\"  class=\"form-control fg2_inp2 tr_r\"  id=\"txtPurchaseAmt" + dtSubConrt.Rows[row2]["SALES_ID"].ToString() + "\" /></div>");
                                sb.Append("</td>");

                                sb.Append("<td>");
                                sb.Append("<label class=\"switch\">");
                                if (dtSubConrt.Rows[row2]["LDGR_CR_ID"].ToString() != "")
                                {
                                    sb.Append("<input disabled checked=\"true\" type=\"checkbox\" id=\"cbx_sly" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >");
                                }
                                else
                                {
                                    sb.Append("<input disabled type=\"checkbox\" id=\"cbx_sly" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >");
                                }
                                sb.Append("<span class=\"slider_tog round\"></span>");
                                sb.Append("</label>");
                                sb.Append("</td>");
                                sb.Append("<td>");
                                int f = 0;
                                if (dtSubConrt.Rows[row2]["LDGR_CR_ID"].ToString() != "")
                                {
                                    sb.Append("<select class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" disabled onchange=\"ddlCreditNoteChange('" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\" id=\"ddlCreditNote" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\">");
                                }
                                else
                                {
                                    f = 1;
                                    sb.Append("<select class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" disabled onchange=\"ddlCreditNoteChange('" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\" id=\"ddlCreditNote" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" disabled>");
                                }
                                sb.Append("<option  value=\"0\">-Select DebitNote-</option>");
                                for (int intRowCount = 0; intRowCount < dtCreNote.Rows.Count; intRowCount++)
                                {
                                    if (dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() == dtSubConrt.Rows[row2]["LDGR_CR_ID"].ToString())
                                    {
                                        f = 1;
                                        sb.Append("<option selected value=\"" + dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() + "\">" + dtCreNote.Rows[intRowCount]["CR_NOTE_REF"].ToString() + "</option>");
                                    }
                                    else
                                    {
                                        sb.Append("<option value=\"" + dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() + "\">" + dtCreNote.Rows[intRowCount]["CR_NOTE_REF"].ToString() + "</option>");
                                    }
                                }
                                if (f == 0)
                                {
                                    sb.Append("<option selected value=\"" + dtSubConrt.Rows[row2]["LDGR_CR_ID"].ToString() + "\">" + dtSubConrt.Rows[row2]["CR_NOTE_REF"].ToString() + "</option>");
                                }
                                sb.Append("</select>");
                                sb.Append("<span id=\"creNoteBalaF" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" class=\"input-group-addon cur2 c1h c1_d1 flt_r\">" + dtSubConrt.Rows[row2]["CREDITNOTE_BAL"].ToString() + "</span>");
                                sb.Append("</td>");
                                sb.Append("<td>");
                                sb.Append("<div class=\"input-group in1\">");
                                if (dtSubConrt.Rows[row2]["LDGR_CR_ID"].ToString() != "")
                                {
                                    sb.Append("<input disabled value=" + dtSubConrt.Rows[row2]["CREDITNOTE_SETLAMNT"].ToString() + " type=\"text\" class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\" onchange=\"CreditNoteStlmtAmntChange('" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  id=\"txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\">");
                                }
                                else
                                {
                                    sb.Append("<input disabled type=\"text\" class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\" onchange=\"CreditNoteStlmtAmntChange('" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  id=\"txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" disabled>");
                                }
                                string strbalspan = "";
                                if (dtSubConrt.Rows[row2]["LDGR_CR_ID"].ToString() != "")
                                {
                                    decimal balSpan = Convert.ToDecimal(dtSubConrt.Rows[row2]["CREDITNOTE_BAL"].ToString()) - Convert.ToDecimal(dtSubConrt.Rows[row2]["CREDITNOTE_SETLAMNT"].ToString());
                                    strbalspan = balSpan.ToString() + " " + CrncyAbrvtn;
                                }
                                sb.Append("</div><span class=\"input-group-addon cur2 flt_r\" id=\"creNoteBala" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\">" + strbalspan + "</span>");
                                sb.Append("</td>");
                                sb.Append("<td style=\"display:none;\" id=\"tdCredNoteAmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSubConrt.Rows[row2]["CREDITNOTE_BAL"].ToString() + "</td>");

                                sb.Append("<td style=\"display: none;\"><input type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" id=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" value=\"" + dtSales.Rows[row1]["RECPT_CST_ID"].ToString() + "\" /></td>");
                                SettledCnt++;
                            }
                            else
                            {
                                if (flg == 0)
                                {
                                    balAmt = decSettleAmt - Convert.ToDecimal(dtSubConrt.Rows[row2]["RECPT_CST_AMT"].ToString());
                                    if (dtSubConrt.Rows[row2]["CREDITNOTE_SETLAMNT"].ToString() != "")
                                    {
                                        balAmt = balAmt - Convert.ToDecimal(dtSubConrt.Rows[row2]["CREDITNOTE_SETLAMNT"].ToString());
                                    }


                                    sb.Append("<td  class=\"td1 tr_r\"  id=\"tdtxtAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >");
                                    sb.Append("<div class=\"input-group in1\"><input type=\"text\"  class=\"form-control fg2_inp2 tr_r\"  onchange=\"return AmountCalculation(" + dtSales.Rows[row1]["SALES_ID"].ToString() + ");\" value=\"" + dtSubConrt.Rows[row2]["RECPT_CST_AMT"].ToString() + "\"  onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  autocomplete=\'off\'   id=\"txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\"/> </div>");
                                    sb.Append("<div> <span id=\"SlsBlnc" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" class=\"input-group-addon cur2 c1h flt_r\" ><i class=\"fas fa-money-check-alt\"></i>" + balAmt + " " + CrncyAbrvtn + "</span></div></td>");


                                    sb.Append("<td>");
                                    sb.Append("<label class=\"switch\" >");
                                    if (dtSubConrt.Rows[row2]["LDGR_CR_ID"].ToString() != "")
                                    {
                                        sb.Append("<input disabled checked=\"true\" type=\"checkbox\" id=\"cbx_sly" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >");
                                    }
                                    else
                                    {
                                        sb.Append("<input disabled type=\"checkbox\" id=\"cbx_sly" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >");
                                    }
                                    sb.Append("<span class=\"slider_tog round\"></span>");
                                    sb.Append("</label>");
                                    sb.Append("</td>");
                                    sb.Append("<td>");
                                    int f = 0;
                                    if (dtSubConrt.Rows[row2]["LDGR_CR_ID"].ToString() != "")
                                    {
                                        sb.Append("<select class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" onchange=\"ddlCreditNoteChange('" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\" id=\"ddlCreditNote" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\">");
                                    }
                                    else
                                    {
                                        f = 1;
                                        sb.Append("<select class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" onchange=\"ddlCreditNoteChange('" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\" id=\"ddlCreditNote" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" disabled>");
                                    }
                                    sb.Append("<option  value=\"0\">-Select DebitNote-</option>");
                                    for (int intRowCount = 0; intRowCount < dtCreNote.Rows.Count; intRowCount++)
                                    {
                                        if (dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() == dtSubConrt.Rows[row2]["LDGR_CR_ID"].ToString())
                                        {
                                            f = 1;
                                            sb.Append("<option selected value=\"" + dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() + "\">" + dtCreNote.Rows[intRowCount]["CR_NOTE_REF"].ToString() + "</option>");
                                        }
                                        else
                                        {
                                            sb.Append("<option value=\"" + dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() + "\">" + dtCreNote.Rows[intRowCount]["CR_NOTE_REF"].ToString() + "</option>");
                                        }
                                    }
                                    if (f == 0)
                                    {
                                        sb.Append("<option selected value=\"" + dtSubConrt.Rows[row2]["LDGR_CR_ID"].ToString() + "\">" + dtSubConrt.Rows[row2]["CR_NOTE_REF"].ToString() + "</option>");
                                    }
                                    sb.Append("</select>");
                                    sb.Append("<span id=\"creNoteBalaF" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" class=\"input-group-addon cur2 c1h c1_d1 flt_r\" >" + dtSubConrt.Rows[row2]["CREDITNOTE_BAL"].ToString() + "</span>");
                                    sb.Append("</td>");
                                    sb.Append("<td>");
                                    sb.Append("<div class=\"input-group in1\">");
                                    if (dtSubConrt.Rows[row2]["LDGR_CR_ID"].ToString() != "")
                                    {
                                        sb.Append("<input value=" + dtSubConrt.Rows[row2]["CREDITNOTE_SETLAMNT"].ToString() + " type=\"text\" class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\" onchange=\"CreditNoteStlmtAmntChange('" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  id=\"txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\">");
                                    }
                                    else
                                    {
                                        sb.Append("<input type=\"text\" class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\" onchange=\"CreditNoteStlmtAmntChange('" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  id=\"txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" disabled>");
                                    }
                                    string strbalspan = "";
                                    if (dtSubConrt.Rows[row2]["LDGR_CR_ID"].ToString() != "")
                                    {
                                        decimal balSpan = Convert.ToDecimal(dtSubConrt.Rows[row2]["CREDITNOTE_BAL"].ToString()) - Convert.ToDecimal(dtSubConrt.Rows[row2]["CREDITNOTE_SETLAMNT"].ToString());
                                        strbalspan = balSpan.ToString() + " " + CrncyAbrvtn;
                                    }
                                    sb.Append("</div><span class=\"input-group-addon cur2 flt_r\" id=\"creNoteBala" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\">" + balAmt + " " + CrncyAbrvtn + "</span>");
                                    sb.Append("</td>");
                                    sb.Append("<td style=\"display:none;\" id=\"tdCredNoteAmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSubConrt.Rows[row2]["CREDITNOTE_BAL"].ToString() + "</td>");

                                    sb.Append("<td style=\"display: none;\" id=\"tdEvtInx" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >INS</td>");
                                    sb.Append("<td style=\"display: none;\" id=\"tdrcptSalId" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSubConrt.Rows[row2]["RECPT_CST_ID"].ToString() + "</td>");
                                    sb.Append("<td style=\"display: none;\"><input type=\"text\" name=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" id=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" value=\"0\" /></td>");
                                }
                            }
                            flg = 1;
                        }
                    }

                    if (flg == 0 && decSettleAmt != 0)//sales display without edit values
                    {
                        sb.Append("<td  class=\"td1 tr_r\"  id=\"tdtxtAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" style=\"\">");
                        sb.Append("<div class=\"input-group in1\"><input type=\"text\" class=\"form-control fg2_inp2 tr_r\"  onchange=\"return AmountCalculation(" + dtSales.Rows[row1]["SALES_ID"].ToString() + ");\"   autocomplete=\'off\'    id=\"txtPurchaseAmt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\"/></div>");
                        sb.Append("<div> <span  id=\"SlsBlnc" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" class=\"input-group-addon cur2 c1h flt_r\"><i class=\"fas fa-money-check-alt\"></i>" + dtSales.Rows[row1]["BALNC_AMT"].ToString() + " " + CrncyAbrvtn + "</span></div></td>");


                        sb.Append("<td>");
                        sb.Append("<label class=\"switch\" >");
                        sb.Append("<input disabled type=\"checkbox\" id=\"cbx_sly" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" >");
                        sb.Append("<span class=\"slider_tog round\"></span>");
                        sb.Append("</label>");
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append("<select class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" onchange=\"ddlCreditNoteChange('" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\" id=\"ddlCreditNote" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" disabled>");
                        sb.Append("<option  value=\"0\">-Select DebitNote-</option>");
                        for (int intRowCount = 0; intRowCount < dtCreNote.Rows.Count; intRowCount++)
                        {
                            sb.Append("<option value=\"" + dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() + "\">" + dtCreNote.Rows[intRowCount]["CR_NOTE_REF"].ToString() + "</option>");
                        }
                        sb.Append("</select>");
                        sb.Append("<span id=\"creNoteBalaF" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" class=\"input-group-addon cur2 c1h c1_d1 flt_r\" ></span>");
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append("<div class=\"input-group in1\">");
                        sb.Append("<input type=\"text\" class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\" onchange=\"CreditNoteStlmtAmntChange('" + dtSales.Rows[row1]["SALES_ID"].ToString() + "')\"  id=\"txtCreNoteStlmntAmmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" disabled>");
                        sb.Append("</div><span class=\"input-group-addon cur2 flt_r\" id=\"creNoteBala" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\">" + dtSales.Rows[row1]["BALNC_AMT"].ToString() + " " + CrncyAbrvtn + "</span>");
                        sb.Append("</td>");
                        sb.Append("<td style=\"display:none;\" id=\"tdCredNoteAmnt" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" ></td>");

                        sb.Append("<td style=\"display: none;\" id=\"tdEvtInx" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\">INS</td>");
                        sb.Append("<td style=\"display: none;\" id=\"tdrcptSalId" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\"></td>");
                        sb.Append("<td style=\"display: none;\"><input type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" id=\"tdSettld" + dtSales.Rows[row1]["SALES_ID"].ToString() + "\" value=\"0\" /></td>");
                    }

                    sb.Append("</tr>");
                    result[3] = dtSales.Rows[row1]["LDGR_NAME"].ToString();
                }

            }

            if (SettledCnt == dtSales.Rows.Count)
            {
                SettldFully = "1";
            }
        }
        else if (dtSalesReturn.Rows.Count > 0)
        {
            //----------------------------Purchase return------------------------------

            for (int row1 = 0; row1 < dtSalesReturn.Rows.Count; row1++)
            {
                decimal decTotal = 0;
                decimal decSettleAmt = 0;


                if (dtSalesReturn.Rows[row1]["PURCHS_RETURN_AMNT"].ToString() != "")
                {
                    decSettleAmt = Convert.ToDecimal(dtSalesReturn.Rows[row1]["PURCHS_RETURN_AMNT"].ToString());
                }

                if (View == "1")
                {
                    if (dtSalesReturn.Rows[row1]["VOCHR_BFR_SETL_AMT"].ToString() != "")
                    {
                        decSettleAmt = Convert.ToDecimal(dtSalesReturn.Rows[row1]["VOCHR_BFR_SETL_AMT"].ToString());
                    }
                    else
                    {
                        if (dtSalesReturn.Rows[row1]["PURCHS_RETURN_AMNT"].ToString() != "")
                        {
                            decSettleAmt = Convert.ToDecimal(dtSalesReturn.Rows[row1]["PURCHS_RETURN_AMNT"].ToString());
                        }
                    }
                }

                sb.Append("<tr class=\"tr1\" id=\"SelectRow" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >");
                sb.Append("<td style=\"display:none;\" id=\"tdSaleID" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "</td>");
                sb.Append("<td style=\"display:none; \" ><input type=\"text\" class=\"txtVal\"  onkeypress=\"return DisableEnter(event);\"  value=\"" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" id=\"cbMandatory" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\"></td>");

                sb.Append("<th scope=\"row\" class=\"td1\" id=\"tdSaleRef" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" \">" + dtSalesReturn.Rows[row1]["SALES_REF"].ToString() + "</th>");
                sb.Append("<td style=\"display:none;\"></td>");
                sb.Append("<td>" + dtSalesReturn.Rows[row1]["SALES_DATE"].ToString() + " </td>");
                sb.Append("<td id=\"tdBalnc" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" class=\"tr_r\">" + decSettleAmt + "</td>");

                sb.Append("<td style=\"display:none;\" id=\"tdRef" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSalesReturn.Rows[row1]["SALES_REF"].ToString() + "</td>");
                sb.Append("<td style=\"display:none;\" id=\"tdDate" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSalesReturn.Rows[row1]["SALES_DATE"].ToString() + "</td>");
                sb.Append("<td style=\"display:none;\" id=\"tdAmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >" + decSettleAmt + " </td>");
                sb.Append("<td style=\"display:none;\" id=\"tdsettlmntAmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >" + decSettleAmt + " </td>");
                sb.Append("<td style=\"display:none;\" id=\"tdLedgerRow" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >" + x + "</td>");
                sb.Append("<td style=\"display:none;\" id=\"tdDupAmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >" + decSettleAmt + " </td>");

                decimal balAmt = 0;

                if (decSettleAmt == 0)
                {
                    string cstamnt = dtSalesReturn.Rows[row1]["RECPT_CST_AMT"].ToString();

                    sb.Append("<td  class=\"td1 tr_r\"  id=\"tdtxtAmt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >");
                    if (cstamnt != "")
                    {
                        sb.Append("<div class=\"input-group in1\"><input disabled value=" + dtSalesReturn.Rows[row1]["RECPT_CST_AMT"].ToString() + " type=\"text\"  class=\"form-control fg2_inp2 tr_r\"  id=\"txtPurchaseAmt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" /></div>");
                    }
                    else
                    {
                        sb.Append("<div class=\"input-group in1\"><input disabled type=\"text\"  class=\"form-control fg2_inp2 tr_r\"  id=\"txtPurchaseAmt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" /></div>");
                    }
                    sb.Append("</td>");

                    sb.Append("<td>");
                    sb.Append("<label class=\"switch\">");
                    if (dtSalesReturn.Rows[row1]["LDGR_CR_ID"].ToString() != "")
                    {
                        sb.Append("<input disabled checked=\"true\" type=\"checkbox\" id=\"cbx_sly" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >");
                    }
                    else
                    {
                        sb.Append("<input disabled type=\"checkbox\" id=\"cbx_sly" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >");
                    }
                    sb.Append("<span class=\"slider_tog round\"></span>");
                    sb.Append("</label>");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    int f = 0;
                    if (dtSalesReturn.Rows[row1]["LDGR_CR_ID"].ToString() != "")
                    {
                        sb.Append("<select class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" disabled onchange=\"ddlCreditNoteChange('" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\" id=\"ddlCreditNote" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\">");
                    }
                    else
                    {
                        f = 1;
                        sb.Append("<select class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" disabled onchange=\"ddlCreditNoteChange('" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\" id=\"ddlCreditNote" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" disabled>");
                    }
                    sb.Append("<option  value=\"0\">-Select Debit Note-</option>");
                    for (int intRowCount = 0; intRowCount < dtCreNote.Rows.Count; intRowCount++)
                    {
                        if (dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() == dtSalesReturn.Rows[row1]["LDGR_CR_ID"].ToString())
                        {
                            f = 1;
                            sb.Append("<option selected value=\"" + dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() + "\">" + dtCreNote.Rows[intRowCount]["CR_NOTE_REF"].ToString() + "</option>");
                        }
                        else
                        {
                            sb.Append("<option value=\"" + dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() + "\">" + dtCreNote.Rows[intRowCount]["CR_NOTE_REF"].ToString() + "</option>");
                        }
                    }
                    if (f == 0)
                    {
                        sb.Append("<option selected value=\"" + dtSalesReturn.Rows[row1]["LDGR_CR_ID"].ToString() + "\">" + dtSalesReturn.Rows[row1]["CR_NOTE_REF"].ToString() + "</option>");
                    }
                    sb.Append("</select>");
                    sb.Append("<span id=\"creNoteBalaF" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" class=\"input-group-addon cur2 c1h c1_d1 flt_r\">" + decSettleAmt + "</span>");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("<div class=\"input-group in1\">");
                    if (dtSalesReturn.Rows[row1]["LDGR_CR_ID"].ToString() != "")
                    {
                        sb.Append("<input disabled value=" + dtSalesReturn.Rows[row1]["CREDITNOTE_SETLAMNT"].ToString() + " type=\"text\" class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\" onchange=\"CreditNoteStlmtAmntChange('" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\"  id=\"txtCreNoteStlmntAmmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\">");
                    }
                    else
                    {
                        sb.Append("<input disabled type=\"text\" class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\" onchange=\"CreditNoteStlmtAmntChange('" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\"  id=\"txtCreNoteStlmntAmmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" disabled>");
                    }
                    string strbalspan = "";
                    if (dtSalesReturn.Rows[row1]["LDGR_CR_ID"].ToString() != "")
                    {
                        decimal balSpan = Convert.ToDecimal(dtSalesReturn.Rows[row1]["CREDITNOTE_BAL"].ToString()) - Convert.ToDecimal(dtSalesReturn.Rows[row1]["CREDITNOTE_SETLAMNT"].ToString());
                        strbalspan = balSpan.ToString() + " " + CrncyAbrvtn;
                    }
                    sb.Append("</div><span class=\"input-group-addon cur2 flt_r\" id=\"creNoteBala" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\">" + strbalspan + "</span>");
                    sb.Append("</td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdCredNoteAmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >" + decSettleAmt + "</td>");

                    sb.Append("<td style=\"display: none;\"><input type=\"text\" style=\"display: none;\" name=\"tdSettld" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" id=\"tdSettld" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" value=\"" + dtSalesReturn.Rows[row1]["RECPT_CST_ID"].ToString() + "\" /></td>");
                    SettledCnt++;
                }
                else
                {
                    decimal decCstAmnt = 0;
                    if (dtSalesReturn.Rows[row1]["RECPT_CST_AMT"].ToString() != "")
                    {
                        decCstAmnt = Convert.ToDecimal(dtSalesReturn.Rows[row1]["RECPT_CST_AMT"].ToString());
                    }
                    balAmt = decSettleAmt - decCstAmnt;
                    if (dtSalesReturn.Rows[row1]["CREDITNOTE_SETLAMNT"].ToString() != "")
                    {
                        balAmt = balAmt - Convert.ToDecimal(dtSalesReturn.Rows[row1]["CREDITNOTE_SETLAMNT"].ToString());
                    }


                    sb.Append("<td  class=\"td1 tr_r\"  id=\"tdtxtAmt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >");
                    sb.Append("<div class=\"input-group in1\"><input disabled type=\"text\"  class=\"form-control fg2_inp2 tr_r\"  onchange=\"return AmountCalculation(" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + ");\" value=\"" + dtSalesReturn.Rows[row1]["RECPT_CST_AMT"].ToString() + "\"  onkeydown=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtPurchaseAmt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\"  autocomplete=\'off\'   id=\"txtPurchaseAmt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\"/> </div>");
                    sb.Append("<div style=\"display:none\"> <span id=\"SlsBlnc" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" class=\"input-group-addon cur2 c1h flt_r\" ><i class=\"fas fa-money-check-alt\"></i>" + balAmt + " " + CrncyAbrvtn + "</span></div></td>");


                    sb.Append("<td>");
                    if (View == "1")
                    {
                        sb.Append("<label class=\"switch\" >");
                    }
                    else
                    {
                        sb.Append("<label class=\"switch\" onclick=\"suply1('" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\">");
                    }
                    if (dtSalesReturn.Rows[row1]["LDGR_CR_ID"].ToString() != "")
                    {
                        sb.Append("<input checked=\"true\" type=\"checkbox\" id=\"cbx_sly" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >");
                    }
                    else
                    {
                        sb.Append("<input type=\"checkbox\" id=\"cbx_sly" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >");
                    }
                    sb.Append("<span class=\"slider_tog round\"></span>");
                    sb.Append("</label>");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    int f = 0;
                    if (dtSalesReturn.Rows[row1]["LDGR_CR_ID"].ToString() != "")
                    {
                        sb.Append("<select class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" onchange=\"ddlCreditNoteChange('" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\" id=\"ddlCreditNote" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\">");
                    }
                    else
                    {
                        f = 1;
                        sb.Append("<select class=\"fg2_inp2 fg2_inp3 fg_chs1 fgs1\" onchange=\"ddlCreditNoteChange('" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\" id=\"ddlCreditNote" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" disabled>");
                    }
                    sb.Append("<option  value=\"0\">-Select Debit Note-</option>");
                    for (int intRowCount = 0; intRowCount < dtCreNote.Rows.Count; intRowCount++)
                    {
                        if (dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() == dtSalesReturn.Rows[row1]["LDGR_CR_ID"].ToString())
                        {
                            f = 1;
                            sb.Append("<option selected value=\"" + dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() + "\">" + dtCreNote.Rows[intRowCount]["CR_NOTE_REF"].ToString() + "</option>");
                        }
                        else
                        {
                            sb.Append("<option value=\"" + dtCreNote.Rows[intRowCount]["LDGR_CR_ID"].ToString() + "\">" + dtCreNote.Rows[intRowCount]["CR_NOTE_REF"].ToString() + "</option>");
                        }
                    }
                    if (f == 0)
                    {
                        sb.Append("<option selected value=\"" + dtSalesReturn.Rows[row1]["LDGR_CR_ID"].ToString() + "\">" + dtSalesReturn.Rows[row1]["CR_NOTE_REF"].ToString() + "</option>");
                    }
                    sb.Append("</select>");
                    sb.Append("<span id=\"creNoteBalaF" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" class=\"input-group-addon cur2 c1h c1_d1 flt_r\" >" + decSettleAmt + "</span>");
                    sb.Append("</td>");
                    sb.Append("<td>");
                    sb.Append("<div class=\"input-group in1\">");
                    if (dtSalesReturn.Rows[row1]["LDGR_CR_ID"].ToString() != "")
                    {
                        sb.Append("<input value=" + dtSalesReturn.Rows[row1]["CREDITNOTE_SETLAMNT"].ToString() + " type=\"text\" class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\" onchange=\"CreditNoteStlmtAmntChange('" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\"  id=\"txtCreNoteStlmntAmmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\">");
                    }
                    else
                    {
                        sb.Append("<input type=\"text\" class=\"form-control fg2_inp2 tr_r\" onkeydown=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\"  onkeypress=\"return isDecimalNumber(event,'txtCreNoteStlmntAmmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\" onchange=\"CreditNoteStlmtAmntChange('" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "')\"  id=\"txtCreNoteStlmntAmmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" disabled>");
                    }
                    string strbalspan = "";
                    if (dtSalesReturn.Rows[row1]["LDGR_CR_ID"].ToString() != "")
                    {
                        decimal balSpan = Convert.ToDecimal(dtSalesReturn.Rows[row1]["CREDITNOTE_BAL"].ToString()) - Convert.ToDecimal(dtSalesReturn.Rows[row1]["CREDITNOTE_SETLAMNT"].ToString());
                        strbalspan = balSpan.ToString() + " " + CrncyAbrvtn;
                    }
                    sb.Append("</div><span class=\"input-group-addon cur2 flt_r\" id=\"creNoteBala" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\">" + balAmt + " " + CrncyAbrvtn + "</span>");
                    sb.Append("</td>");
                    sb.Append("<td style=\"display:none;\" id=\"tdCredNoteAmnt" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >" + decSettleAmt + "</td>");

                    sb.Append("<td style=\"display: none;\" id=\"tdEvtInx" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >INS</td>");
                    sb.Append("<td style=\"display: none;\" id=\"tdrcptSalId" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" >" + dtSalesReturn.Rows[row1]["RECPT_CST_ID"].ToString() + "</td>");
                    sb.Append("<td style=\"display: none;\"><input type=\"text\" name=\"tdSettld" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" id=\"tdSettld" + dtSalesReturn.Rows[row1]["SALES_ID"].ToString() + "\" value=\"0\" /></td>");
                }
            }
        }

        ObjEntityRequest.LedgerId = Convert.ToInt32(intLedgerId);
        DataTable dtacntblnc = objBussiness.AccntBalancebyId(ObjEntityRequest);
        decimal DecDebAmnt = 0, DecCredAmnt = 0, DBalance = 0, Openbalance = 0;
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
            else
            {
                if (dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString() != "")
                    DecDebAmnt = Convert.ToDecimal(dtacntblnc.Rows[0]["LDGR_CURRENT_BAL"].ToString());
                DBalance = DecDebAmnt + Openbalance;
            }

            if (DBalance < 0)
            {
                string srDBalance = Convert.ToString(DBalance);
                srDBalance = srDBalance.Substring(1);
                DBalance = Convert.ToDecimal(srDBalance);
            }
            else
            {
                CrOrDr = "DR";
            }

            Nature = dtacntblnc.Rows[0]["ACNT_NATURE_STS"].ToString();
        }

        result[0] = sb.ToString();
        result[1] = DBalance.ToString();
        result[2] = CrOrDr;
        result[3] = Nature;
        result[4] = SettldFully;
        result[5] = intOBSts.ToString();
        result[6] = strDebCr;

        return result;
    }

    [WebMethod]
    public static string[] ReadCreditNoteDtls(string CreNoteid)
    {

        string[] result = new string[2];
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();
        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();
        ObjEntityRequest.LedgerId = Convert.ToInt32(CreNoteid);
        DataTable dtCreNote = objBussiness.ReadDebitNoteDtls(ObjEntityRequest);
        if (dtCreNote.Rows.Count > 0)
        {
            result[0] = dtCreNote.Rows[0]["LDGR_BAL_AMNT"].ToString();
            result[1] = dtCreNote.Rows[0]["CST_CNTR_DR_AMOUNT"].ToString();
        }
        return result;
    }

    [WebMethod]
    public static string[] LoadSaleData(string intLedgerId, string intuserid, string intorgid, string intcorpid, string x, string rcptLdId)
    {
        string[] result = new string[3];
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();


        ObjEntityRequest.LedgerId = Convert.ToInt32(intLedgerId);
        ObjEntityRequest.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(intcorpid);
        ObjEntityRequest.ReceiptLedgrId = Convert.ToInt32(rcptLdId);
        ObjEntityRequest.Status = 1;

        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("RECPT_CST_ID", typeof(int));

        dtDetail.Columns.Add("RECPT_ID", typeof(int));
        dtDetail.Columns.Add("RECPT_CST_AMT", typeof(string));
        dtDetail.Columns.Add("RECPT_LD_ID", typeof(int));
        dtDetail.Columns.Add("SALES_ID", typeof(int));
        dtDetail.Columns.Add("RECPT_SALES_REF", typeof(string));
        dtDetail.Columns.Add("ROWCOUNT", typeof(int));
        dtDetail.Columns.Add("SALEAMOUNT", typeof(string));


        DataTable dtSubConrt = objBussiness.ReadReceptCostcntrDetailsById(ObjEntityRequest);

        dtDetail.TableName = "dtTableLoadcstcntr";

        for (int intCount = 0; intCount < dtDetail.Rows.Count; intCount++)
        {

            DataRow drDtl = dtDetail.NewRow();
            drDtl["ROWCOUNT"] = dtSubConrt.Rows.Count;
            drDtl["RECPT_CST_ID"] = Convert.ToInt32(dtSubConrt.Rows[intCount]["RECPT_CST_ID"].ToString());

            drDtl["RECPT_ID"] = Convert.ToInt32(dtSubConrt.Rows[intCount]["RECPT_ID"].ToString());
            drDtl["RECPT_CST_AMT"] = dtSubConrt.Rows[intCount]["RECPT_CST_AMT"].ToString();
            drDtl["RECPT_LD_ID"] = Convert.ToInt32(dtSubConrt.Rows[intCount]["RECPT_LD_ID"].ToString());
            if (dtSubConrt.Rows[intCount]["SALES_ID"].ToString() != "")
            {
                drDtl["SALES_ID"] = Convert.ToInt32(dtSubConrt.Rows[intCount]["SALES_ID"].ToString());

                drDtl["SALEAMOUNT"] = dtSubConrt.Rows[intCount]["BALNC_AMT"].ToString();

            }
            else
            {
                drDtl["SALES_ID"] = 0;
            }


            dtDetail.Rows.Add(drDtl);
        }

        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);

        //string result;
        //using (StringWriter sw = new StringWriter())
        //{
        //    dtSubConrt.WriteXml(sw);
        //    result = sw.ToString();
        //}
        result[0] = strJson;
        return result;


    }


    [WebMethod]
    public static string[] AccntBalanceLedger(string intLedgerId, string intuserid, string intorgid, string intcorpid)
    {
        string[] result = new string[3];
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

        if (intLedgerId != "--SELECT--")
        {
            ObjEntityRequest.LedgerId = Convert.ToInt32(intLedgerId);
        }
        ObjEntityRequest.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(intcorpid);
        DataTable dtSales = objBussiness.AccntBalancebyId(ObjEntityRequest);
        decimal DecDebAmnt = 0, DecCredAmnt = 0, DBalance = 0; ;
        string CrOrDr = "CR";
        decimal Openbalance = 0;
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
            if (dtSales.Rows[0]["LDGR_MODE"].ToString() == "1")
            {
                if (dtSales.Rows[0]["LDGR_CURRENT_BAL"].ToString() != "")
                    DecCredAmnt = Convert.ToDecimal(dtSales.Rows[0]["LDGR_CURRENT_BAL"].ToString());
                //if (dtSales.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                //    Openbalance = Convert.ToDecimal(dtSales.Rows[0]["LDGR_OPEN_BAL"].ToString());
                DBalance = DecCredAmnt - Openbalance;

            }
            else
            {
                if (dtSales.Rows[0]["LDGR_CURRENT_BAL"].ToString() != "")
                    DecDebAmnt = Convert.ToDecimal(dtSales.Rows[0]["LDGR_CURRENT_BAL"].ToString());
                //if (dtSales.Rows[0]["LDGR_OPEN_BAL"].ToString() != "")
                //    Openbalance = Convert.ToDecimal(dtSales.Rows[0]["LDGR_OPEN_BAL"].ToString());
                DBalance = DecDebAmnt + Openbalance;
            }
        }

        if (DBalance < 0)
        {
            string srDBalance = Convert.ToString(DBalance);
            srDBalance = srDBalance.Substring(1);
            DBalance = Convert.ToDecimal(srDBalance);
        }
        else
        {
            CrOrDr = "DR";
        }

        result[0] = DBalance.ToString();
        result[1] = CrOrDr;
        result[2] = exists.ToString();

        return result;

    }
    [WebMethod]
    public static string RedCurencyAbrvtn(string intCrncyId, string intuserid, string intorgid, string intcorpid)
    {

        string result = "";
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();
        ObjEntityRequest.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntityRequest.Corporate_id = Convert.ToInt32(intcorpid);

        if (intCrncyId != "--SELECT CURRENCY--")
        {
            ObjEntityRequest.CurrcyId = Convert.ToInt32(intCrncyId);
            DataTable dtSubConrt = objBussiness.ReadCrncyAbrvtn(ObjEntityRequest);
            // dtSubConrt.TableName = "dtTableLoadProduct";
            //  string ABVRTN;
            if (dtSubConrt.Rows.Count > 0)
            {
                result = dtSubConrt.Rows[0][0].ToString();

            }

        }
        return result;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        Button clickedButton = sender as Button;
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();
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

        if (HiddenRefNextNum.Value != "")
        {
            ObjEntityRequest.RefNextNum = Convert.ToInt32(HiddenRefNextNum.Value);
        }

        ObjEntityRequest.AccntNameId = Convert.ToInt32(ddlAccontLed.SelectedItem.Value);
        ObjEntityRequest.RefNum = TxtRef.Value;
        ObjEntityRequest.FromDate = objcommon.textToDateTime(txtdate.Value);

        if (HiddenUpdatedDate.Value != "")
        {
            ObjEntityRequest.RcptUpdateDate = objcommon.textToDateTime(HiddenUpdatedDate.Value);
        }

        if (hiddenDfltCurrencyMstrId.Value!="")
        {
            ObjEntityRequest.CurrcyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
        }

        ObjEntityRequest.Description = txtDesc.Value;

        if (HiddenTotalAmount.Value != "")
        {
            ObjEntityRequest.TotalAmnt = Convert.ToDecimal(HiddenTotalAmount.Value);
        }


        if (HiddenPrevTab.Value == "Cheque")
        {
            if (ddlChequeBank.Value != "")
            {
                ObjEntityRequest.Bank_Name = ddlChequeBank.Value;
            }
            if (txtChequeIBAN.Value.Trim() != "")
            {
                ObjEntityRequest.IbanNo = txtChequeIBAN.Value.Trim();
            }
            if (txtChequeNo_Cheque.Value.Trim() != "")
            {
                ObjEntityRequest.ChequeBook_No = txtChequeNo_Cheque.Value.Trim();
            }
            ObjEntityRequest.PaymentDate = objcommon.textToDateTime(txtDate_Cheque.Value);
            ObjEntityRequest.PaymentMod = 0;
        }
        else if (HiddenPrevTab.Value == "DD")
        {
            ObjEntityRequest.PaymentMod = 1;
            if (ddlDDBank.Value != "")
            {
                ObjEntityRequest.Bank_Name = ddlDDBank.Value;
            }
            if (txtDDIBAN.Value.Trim() != "")
            {
                ObjEntityRequest.IbanNo = txtDDIBAN.Value.Trim();
            }
            ObjEntityRequest.PaymentDate = objcommon.textToDateTime(txtDate_DD.Value);
            ObjEntityRequest.DDNumber = txtDD_DD.Value;
        }
        else if (HiddenPrevTab.Value == "BankTransfer")
        {
            ObjEntityRequest.PaymentMod = 2;
            if (ddlTransfrBank.Value != "")
            {
                ObjEntityRequest.Bank_Name = ddlTransfrBank.Value;
            }
            if (txtTranserIBAN.Value.Trim() != "")
            {
                ObjEntityRequest.IbanNo = txtTranserIBAN.Value.Trim();
            }
            ObjEntityRequest.PaymentDate = objcommon.textToDateTime(txtDate_BankTransfer.Value);
            ObjEntityRequest.TransferModId = Convert.ToInt32(ddlMode_BankTransfer.SelectedItem.Value);

        }
        else
        {
            ObjEntityRequest.PaymentMod = 3;
        }

        //Start:-Recurrence
        if (HiddenFieldRecurrencyPeriod.Value != "")
        {
            ObjEntityRequest.RecurPeriodId = Convert.ToInt32(HiddenFieldRecurrencyPeriod.Value);
            ObjEntityRequest.RecurRemindDays = Convert.ToInt32(HiddenFieldRemindDays.Value);
        }
        //End:-Recurrence

        string strRets = "successConfirm";

        ObjEntityRequest.ReceiptId = Convert.ToInt32(HiddenFieldTaxId.Value);
        List<clsEntity_Receipt_Account> objEntityPerfomList = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> objEntityPerfomListGrps = new List<clsEntity_Receipt_Account>();


        List<clsEntity_Receipt_Account> ObjEntityLedger_Insert = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> ObjEntityLedger_Update = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> ObjEntityLedger_Delete = new List<clsEntity_Receipt_Account>();


        List<clsEntity_Receipt_Account> ObjEntitycostCntr_Insert = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> ObjEntitycostCntr_Update = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> ObjEntitycostCntr_Delete = new List<clsEntity_Receipt_Account>();

        List<clsEntity_Receipt_Account> objEntityDeleteSale = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> objEntityInsertToVT = new List<clsEntity_Receipt_Account>();//EVM-0027

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
                clsEntity_Receipt_Account objSubEntityLedgerINS = new clsEntity_Receipt_Account();

                clsEntity_Receipt_Account objSubEntityLedgerUPD = new clsEntity_Receipt_Account();

                clsEntity_Receipt_Account objSubEntitySaleDEL = new clsEntity_Receipt_Account();

                if (Request.Form["tdEvtGrp" + objClsVideoAddAttData.LEDGERID] == "INS")
                {
                    objSubEntityLedgerINS.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                    objSubEntityLedgerINS.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                    if (Request.Form["TxtAmount_" + objClsVideoAddAttData.LEDGERID] != "")
                    {
                        objSubEntityLedgerINS.LedgerAmnt = Convert.ToDecimal(Request.Form["TxtAmount_" + objClsVideoAddAttData.LEDGERID]);
                    }
                    objSubEntityLedgerINS.Remarks = Request.Form["TxtRemark" + objClsVideoAddAttData.LEDGERID];


                    //EVM-0027 17-08-2019
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
                        objSubEntityLedgerINS.VoucherCategory = 1;
                        objSubEntityLedgerINS.PaidAmt = Convert.ToDecimal(OBvalues[0]);
                        objSubEntityLedgerINS.BalnceAmt = Convert.ToDecimal(OBvalues[1]);
                        objSubEntityLedgerINS.VoucherCategory = 1;
                        if (objSubEntityLedgerUPD.PaidAmt != 0)
                        {
                            objEntityInsertToVT.Add(objSubEntityLedgerINS);
                            ObjEntitycostCntr_Insert.Add(objSubEntityLedgerINS);
                        }
                    }
                    //END

                    ObjEntityLedger_Insert.Add(objSubEntityLedgerINS);
                    objEntityPerfomListGrps.Add(objSubEntityLedgerINS);
                }
                if (Request.Form["tdEvtGrp" + objClsVideoAddAttData.LEDGERID] == "UPD")
                {
                    objSubEntityLedgerUPD.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                    objSubEntityLedgerUPD.ReceiptLedgrId = Convert.ToInt32(Request.Form["tdRcptLdgrId" + objClsVideoAddAttData.LEDGERID]);
                    objSubEntityLedgerUPD.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                    if (Request.Form["TxtAmount_" + objClsVideoAddAttData.LEDGERID] != "")
                    {
                        objSubEntityLedgerUPD.LedgerAmnt = Convert.ToDecimal(Request.Form["TxtAmount_" + objClsVideoAddAttData.LEDGERID]);
                    }
                    objSubEntityLedgerUPD.Remarks = Request.Form["TxtRemark" + objClsVideoAddAttData.LEDGERID];

                   
                    //EVM-0027 17-08-2019
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
                        objSubEntityLedgerUPD.VoucherCategory = 1;
                        objSubEntityLedgerUPD.PaidAmt = Convert.ToDecimal(OBvalues[0]);
                        objSubEntityLedgerUPD.BalnceAmt = Convert.ToDecimal(OBvalues[1]);
                        ObjEntityRequest.VoucherCategory = 1;
                        if (objSubEntityLedgerUPD.PaidAmt != 0)
                        {
                            objEntityInsertToVT.Add(objSubEntityLedgerUPD);
                            ObjEntitycostCntr_Insert.Add(objSubEntityLedgerUPD);
                        }
                    }

                    //END
                    ObjEntityLedger_Update.Add(objSubEntityLedgerUPD);
                    objEntityPerfomListGrps.Add(objSubEntityLedgerUPD);

                }

                string CostCenterDtl = Request.Form["tdCostCenterDtls" + objClsVideoAddAttData.LEDGERID];
                if (CostCenterDtl != "" && CostCenterDtl != null && CostCenterDtl != "null")
                {
                    string[] CostCenterDtlvalues = CostCenterDtl.Split('$');
                    for (int i = 0; i < CostCenterDtlvalues.Length; i++)
                    {
                        clsEntity_Receipt_Account objSubEntity = new clsEntity_Receipt_Account();

                        objSubEntity.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                        objSubEntity.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                        string[] valSplit = CostCenterDtlvalues[i].Split('%');
                        if (CostCenterDtlvalues[i] != "")
                        {
                            objSubEntity.CostCtrId = Convert.ToInt32(valSplit[0]);
                            valSplit[1] = valSplit[1].Replace(",", "");

                            objSubEntity.CstCntrAmnt = Convert.ToDecimal(valSplit[1]);
                            if (valSplit[4] != "" && valSplit[4] != null && valSplit[4] != "0")
                            {
                                objSubEntity.CostGrp1Id = Convert.ToInt32(valSplit[4]);
                            }
                            if (valSplit[5] != "" && valSplit[5] != null && valSplit[5] != "0")
                            {
                                objSubEntity.CostGrp2Id = Convert.ToInt32(valSplit[5]);
                            }
                            valSplit[2] = valSplit[2].Replace(",", "");

                            ObjEntitycostCntr_Insert.Add(objSubEntity);
                        }
                    }
                }


                int CntExceed = 0;

                string PurchaseDtl = Request.Form["tdSalesDtls" + objClsVideoAddAttData.LEDGERID];
                if (PurchaseDtl != "" && PurchaseDtl != "null" && PurchaseDtl != null)
                {
                    string[] values = PurchaseDtl.Split('$');
                    for (int i = 0; i < values.Length; i++)
                    {
                        clsEntity_Receipt_Account objSubEntity = new clsEntity_Receipt_Account();

                        objSubEntity.LedgerRow = Convert.ToInt32(objClsVideoAddAttData.LEDGERID);
                        objSubEntity.Organisation_id = ObjEntityRequest.Organisation_id;
                        objSubEntity.Corporate_id = ObjEntityRequest.Corporate_id;
                        if (values[i] != "")
                        {
                            objSubEntity.Status = 1;
                            objSubEntity.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                            string[] valSplit = values[i].Split('%');
                            objSubEntity.CostCtrId = Convert.ToInt32(valSplit[0]);

                            if (valSplit[1] != "" || valSplit[6] != "")
                            {
                                valSplit[1] = valSplit[1].Replace(",", "");
                                if (valSplit[1] != "")
                                {
                                    valSplit[1] = valSplit[1].Replace(",", "");
                                    objSubEntity.CstCntrAmnt = Convert.ToDecimal(valSplit[1]);
                                }
                                if (valSplit[2] != "")
                                {
                                    objSubEntity.SettlmntAmmnt = Convert.ToDecimal(valSplit[2]);
                                }

                                valSplit[5] = valSplit[5].Replace(",", "");
                                valSplit[6] = valSplit[6].Replace(",", "");
                                objSubEntity.AccntNameId = Convert.ToInt32(valSplit[4]);
                                if (valSplit[5] != "")
                                    objSubEntity.BalanceAmount = Convert.ToDecimal(valSplit[5]);
                                if (valSplit[6] != "")
                                    objSubEntity.LedgerAmnt = Convert.ToDecimal(valSplit[6]);

                                string strDebitNoteId = valSplit[4];

                                if (objSubEntity.CstCntrAmnt > 0 || objSubEntity.LedgerAmnt > 0)
                                {
                                    DataTable dtSalesBalance = objBussiness.ReadSalesBalance(objSubEntity);

                                    if (strDebitNoteId != "" && strDebitNoteId != "0")
                                    {
                                        dtSalesBalance = objBussiness.ReadSalesReturnBalance(objSubEntity);
                                    }

                                    decimal decSalesRemainAmt = 0;
                                    if (dtSalesBalance.Rows.Count > 0)
                                    {
                                        if (dtSalesBalance.Rows[0][1].ToString() != "")
                                            decSalesRemainAmt = Convert.ToDecimal(dtSalesBalance.Rows[0][1].ToString());
                                    }
                                    if (clickedButton.ID == "btnConfirm1" || clickedButton.ID == "btnFloatConfirm1")
                                    {
                                        if (decSalesRemainAmt != 0)
                                        {
                                            if (decSalesRemainAmt < (objSubEntity.CstCntrAmnt + objSubEntity.LedgerAmnt))
                                            {
                                                strRets = "SalesAmountExceeded";
                                                CntExceed++;
                                            }
                                        }
                                        else if (CntExceed == 0)
                                        {
                                            strRets = "SalesAmtFullySettld";
                                            objSubEntitySaleDEL.ReceiptCstCntrId = Convert.ToInt32(Request.Form["tdSettld" + objSubEntity.CostCtrId]);
                                            objEntityDeleteSale.Add(objSubEntitySaleDEL);
                                        }

                                        if (objSubEntity.Status == 0 || (objSubEntity.Status == 1 && decSalesRemainAmt != 0))//insert not fully settled or cst cntr
                                        {
                                            ObjEntitycostCntr_Insert.Add(objSubEntity);
                                        }
                                    }
                                    else
                                    {
                                        ObjEntitycostCntr_Insert.Add(objSubEntity);
                                    }
                                }
                            }
                        }
                    }

                    if (clickedButton.ID == "btnConfirm1" || clickedButton.ID == "btnFloatConfirm1")
                    {
                        if (objEntityDeleteSale.Count > 0)//delete fully settld saved sales
                        {
                            objBussiness.DeleteSaleLedgers(objEntityDeleteSale);
                            strRets = "successConfirm";
                        }
                    }
                }


                string strCTCNRCanclDtlId = "";
                string[] strarrCSTCNTCancldtlIds = strCTCNRCanclDtlId.Split(',');
                if (hiddenQstnCanclDtlId.Value != "" && hiddenQstnCanclDtlId.Value != null)
                {
                    strCTCNRCanclDtlId = hiddenQstnCanclDtlId.Value;
                    strarrCSTCNTCancldtlIds = strCTCNRCanclDtlId.Split(',');

                }
                //Cancel the rows that have been cancelled when editing in Detail table
                foreach (string strDtlId in strarrCSTCNTCancldtlIds)
                {
                    if (strDtlId != "" && strDtlId != null)
                    {
                        int intDtlId = Convert.ToInt32(strDtlId);
                        clsEntity_Receipt_Account objEntityDelete = new clsEntity_Receipt_Account();
                        objEntityDelete.CostCtrId = Convert.ToInt32(strDtlId);
                        objEntityDelete.LedgerId = Convert.ToInt32(Request.Form["ddlLedId" + objClsVideoAddAttData.LEDGERID]);
                        ObjEntitycostCntr_Delete.Add(objEntityDelete);
                    }
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
                        clsEntity_Receipt_Account objSubEntityLedgerDEL = new clsEntity_Receipt_Account();
                        objSubEntityLedgerDEL.ReceiptLedgrId = Convert.ToInt32(strDtlId);
                        ObjEntityLedger_Delete.Add(objSubEntityLedgerDEL);
                    }
                }
            }
        }

        int AcntCloseSts = AccountCloseCheck(txtdate.Value);
        int AuditCloseSts = AuditCloseCheck(txtdate.Value);
      
        if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
        {
            Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=AuditClosed");
        }
        else if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
        {
         
        }
        else  if (AcntCloseSts == 1 && HiddenProvisionSts.Value != (clsCommonLibrary.StatusAll.Active).ToString())
        {
            Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=AcntClosed");
        }

        if (clickedButton.ID == "btnConfirm1")
        {
            ObjEntityRequest.ConfirmStatus = 1;
            ObjEntityRequest.FinancialYrId = Convert.ToInt32(HiddenFinancialYearId.Value);
        }
        else if (clickedButton.ID == "btnFloatConfirm1")
        {
            ObjEntityRequest.ConfirmStatus = 1;
            ObjEntityRequest.FinancialYrId = Convert.ToInt32(HiddenFinancialYearId.Value);

        }
        int flag = 0;


        DataTable dtPCancel = objBussiness.ReadReceptDetailsById(ObjEntityRequest);

        int intConfrm = 0;
        if (dtPCancel.Rows[0]["RECPT_CNFRM_STS"].ToString() != "")
            intConfrm = Convert.ToInt32(dtPCancel.Rows[0]["RECPT_CNFRM_STS"].ToString());
        if (intConfrm > 0)
        {
            flag++;
            Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=ALConfrm");
        }
        DataTable dtCNCLSTS = objBussiness.ReadReceptDetailsById(ObjEntityRequest);

        if (dtCNCLSTS.Rows.Count > 0)
        {
            if (dtCNCLSTS.Rows[0]["RECPT_CNCL_USR_ID"].ToString() != "")
            {
                int intCancel = 0;
                intCancel = Convert.ToInt32(dtCNCLSTS.Rows[0]["RECPT_CNCL_USR_ID"].ToString());
                if (intCancel > 0)
                {
                    flag++;
                    Response.Redirect("fms_Receipt_Account.aspx?InsUpd=CNCL");
                }
            }
        }

        if (flag == 0)
        {
            if (strRets != "SalesAmountExceeded" && strRets != "SalesAmtFullySettld")
            {
                objBussiness.updateReceiptDtls(ObjEntityRequest, objEntityPerfomListGrps, objEntityPerfomList, ObjEntityLedger_Insert, ObjEntityLedger_Update, ObjEntityLedger_Delete, ObjEntitycostCntr_Insert, ObjEntitycostCntr_Update, ObjEntitycostCntr_Delete);
            }
            else
            {
                if (strRets == "SalesAmountExceeded")
                {
                    Response.Redirect("fms_Receipt_Account.aspx?InsUpd=SalesAmountExceeded&Id=" + Request.QueryString["Id"].ToString());
                }
                else if (strRets == "SalesAmtFullySettld")
                {
                    Response.Redirect("fms_Receipt_Account.aspx?InsUpd=SalesAmountFullySettld&Id=" + Request.QueryString["Id"].ToString());
                }
            }

            if (clickedButton.ID == "btnUpdate")
            {
                if (Request.QueryString["VId"] != null)
                {
                    Response.Redirect("fms_Receipt_Account.aspx?InsUpd=UPD&Id=" + Request.QueryString["Id"].ToString() + "&VId=1");
                }
                else
                {
                    Response.Redirect("fms_Receipt_Account.aspx?InsUpd=UPD&Id=" + Request.QueryString["Id"].ToString());
                }
            }
            else if (clickedButton.ID == "btnUpdatecls")
            {
                Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=UPD");
            }
            //EVM-0027 12-04
            else if (clickedButton.ID == "btnFloatUpdate")
            {
                if (Request.QueryString["VId"] != null)
                {
                    Response.Redirect("fms_Receipt_Account.aspx?InsUpd=UPD&Id=" + Request.QueryString["Id"].ToString() + "&VId=1");
                }
                else
                {
                    Response.Redirect("fms_Receipt_Account.aspx?InsUpd=UPD&Id=" + Request.QueryString["Id"].ToString());
                }
            }
            else if (clickedButton.ID == "btnFloatUpdateCls")
            {


                Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=UPD");

            }
            //ENd
            else if (clickedButton.ID == "btnConfirm1")
            {
                if (Request.QueryString["VId"] != null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedValue", "PassSavedValue(1);", true);
                }

                    //0039
                else if (dtPCancel.Rows[0]["RECPT_CNFRM_STS"].ToString() != "0")
                {
                    Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=ALConfrm");
                }


                else
                {
                    Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=Confrm");
                }
            }
            else if (clickedButton.ID == "btnFloatConfirm")
            {
                if (Request.QueryString["VId"] != null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "PassSavedValue", "PassSavedValue(1);", true);
                }
                else
                {
                    Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=Confrm");
                }
            }
        }
    }

    [WebMethod]
    public static string CheckRefNumber(string jrnlDate, string orgID, string corptID, string UsrID, string RefNum, string ReptID)
    {
        string Ref = "";

        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsCommonLibrary objCommon = new clsCommonLibrary();




        cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();

        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

        objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT);
        objEntityCommon.CorporateID = Convert.ToInt32(corptID);
        objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
        if (jrnlDate != "")
        {
            objEntityAccnt.FromDate = objCommon.textToDateTime(jrnlDate);
            objEntityAudit.FromDate = objCommon.textToDateTime(jrnlDate);
        }
        // string strNextId = objBusinessLayer.ReadNextNumber(objEntityCommon);



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

        DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
        if (dtAccntCls.Rows.Count > 0 || dtAuditCls.Rows.Count > 0)
        {

            //if(dtAccntCls.Rows[0]["ACCNT_CLS_DATE"].ToString()!="" && 
            //if(dtAccntCls.Rows[0]["AUDIT_CLS_DATE"]

            DataTable dtRefFormat1 = objBussiness.ReadRefNumberByDate(ObjEntityRequest);
            if (dtRefFormat1.Rows.Count > 0)
            {
                string strRef = "";

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
                //if (dtRefFormat.Rows.Count > 0)
                //{
                //    if (Convert.ToInt32(ReptID) != Convert.ToInt32(dtRefFormat.Rows[0]["RECPT_ID"].ToString()))
                //    {
                //        Ref = dtRefFormat.Rows[0]["RECPT_REF"].ToString();
                //        if (dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != null)
                //        {
                //            SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString());
                //        }
                //        if (SubRef != 1)
                //        {
                //            Ref = Ref.TrimEnd('/');
                //            Ref = Ref.Remove(Ref.LastIndexOf('/') + 1);
                //        }
                //        else
                //        {
                //            Ref += "/";
                //        }
                //        Ref = Ref + "" + SubRef;
                //    }
                //}


                if (dtRefFormat.Rows.Count > 0)
                {
                    Ref = dtRefFormat.Rows[0]["RECPT_REF"].ToString();
                    if (dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString() != null)
                    {
                        SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["RCPT_REF_NXT_SUBNUM"].ToString());
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

                }
            }
        }
        else
        {
            if (ReptID == "")//on add
            {

                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.RECEIPT);
                objEntityCommon.CorporateID = Convert.ToInt32(corptID);
                objEntityCommon.Organisation_Id = Convert.ToInt32(orgID);
                string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);
                DataTable dtFormate = objBussiness.readRefFormate(objEntityCommon);

                int intOrgId = Convert.ToInt32(orgID);
                int intCorpId = Convert.ToInt32(corptID);
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

                int intUserId = Convert.ToInt32(UsrID);
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
    
    

    protected void btnReopen_Click(object sender, EventArgs e)
    {
        string strRets = "";
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();
        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

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

        string ReceiptId = "";
        if (Request.QueryString["ViewId"] != null)
        {
            string strRandomMixedId = Request.QueryString["ViewId"].ToString();
            ReceiptId = Request.QueryString["ViewId"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            ObjEntityRequest.ReceiptId = Convert.ToInt32(strId);
        }

        List<clsEntity_Receipt_Account> objEntityPerfomList = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> objEntityPerfomListGrps = new List<clsEntity_Receipt_Account>();
        List<clsEntity_Receipt_Account> objEntityUpdateOB = new List<clsEntity_Receipt_Account>();


        DataTable dtLDGRdTLS = objBussiness.ReadReceptLedgerDetailsById(ObjEntityRequest);
        if (dtLDGRdTLS.Rows.Count > 0)
        {
            for (int rowCnt = 0; rowCnt < dtLDGRdTLS.Rows.Count; rowCnt++)
            {
                if (dtLDGRdTLS.Rows[rowCnt]["RECPT_CST_AMT"].ToString() != "0" || dtLDGRdTLS.Rows[rowCnt]["LDGR_CR_ID"].ToString() != "" )
                {
                    clsEntity_Receipt_Account objSubEntityGrp = new clsEntity_Receipt_Account();

                   

                    objSubEntityGrp.ReceiptLedgrId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["RECPT_LD_ID"].ToString());
                    objSubEntityGrp.LedgerId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["LDGR_ID"].ToString());
                    objSubEntityGrp.LedId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["LDGR_ID"].ToString());
                    objSubEntityGrp.LedgerAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[rowCnt]["RECPT_LD_AMT"].ToString());

                    objEntityPerfomList.Add(objSubEntityGrp);

                 

                    if (dtLDGRdTLS.Rows[rowCnt]["RECPT_LD_ID"].ToString() != "")
                    {
                        ObjEntityRequest.Status = 1;
                        ObjEntityRequest.ReceiptLedgrId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["RECPT_LD_ID"].ToString());

                        if (dtLDGRdTLS.Rows[rowCnt]["RECPT_CST_ID"].ToString() != "")
                        {
                            objSubEntityGrp.ReceiptLedgrId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["RECPT_LD_ID"].ToString());
                            if (dtLDGRdTLS.Rows[rowCnt]["COSTCNTR_ID"].ToString() == "")
                            {
                                objSubEntityGrp.Status = 1;
                                objSubEntityGrp.CostCtrId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["SALES_ID"].ToString());

                            }
                            else
                            {
                                objSubEntityGrp.Status = 0;
                                objSubEntityGrp.CostCtrId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["COSTCNTR_ID"].ToString());
                            }
                            objSubEntityGrp.ReceiptLedgrId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["RECPT_LD_ID"].ToString());
                            objSubEntityGrp.CstCntrAmnt = Convert.ToDecimal(dtLDGRdTLS.Rows[rowCnt]["RECPT_CST_AMT"].ToString());
                            objSubEntityGrp.ReceiptCstCntrId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["RECPT_CST_ID"].ToString());

                            if (dtLDGRdTLS.Rows[rowCnt]["LDGR_CR_ID"].ToString() != "")
                            {
                                objSubEntityGrp.AccntNameId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["LDGR_CR_ID"].ToString());
                                objSubEntityGrp.BalanceAmount = Convert.ToDecimal(dtLDGRdTLS.Rows[rowCnt]["CREDITNOTE_BAL"].ToString());
                                objSubEntityGrp.LedgerCreditAmt = Convert.ToDecimal(dtLDGRdTLS.Rows[rowCnt]["CREDITNOTE_SETLAMNT"].ToString());
                            }
                            objEntityPerfomListGrps.Add(objSubEntityGrp);
                        }
                    }
                }

                //EVM-0027 Aug 13
                if (dtLDGRdTLS.Rows[rowCnt]["OBPAID_AMT"].ToString() != "")
                {
                    clsEntity_Receipt_Account objSubEntityGrp1 = new clsEntity_Receipt_Account();
                    objSubEntityGrp1.Organisation_id = ObjEntityRequest.Organisation_id;
                    objSubEntityGrp1.Corporate_id = ObjEntityRequest.Corporate_id;
                    objSubEntityGrp1.ReceiptId = ObjEntityRequest.ReceiptId;
                    objSubEntityGrp1.ReceiptLedgrId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["RECPT_LD_ID"].ToString());
                    objSubEntityGrp1.VoucherCategory = 1;
                    objSubEntityGrp1.LedId = Convert.ToInt32(dtLDGRdTLS.Rows[rowCnt]["LDGR_ID"].ToString());
                    DataTable dtForOB = objBussiness.ReadOepningBalById(objSubEntityGrp1);
                    if (dtForOB.Rows.Count > 0 && dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString() != "0" && dtForOB.Rows[0]["OBPAID_AMT"].ToString() != "")
                    {
                        if (dtForOB.Rows[0]["OBPAID_AMT"].ToString() != "")
                        {
                            decimal decOpeningBal = Convert.ToDecimal(dtForOB.Rows[0]["LDGR_OPEN_BAL"].ToString());
                            decimal decPaidAmt = Convert.ToDecimal(dtForOB.Rows[0]["OBPAID_AMT"].ToString());
                            objSubEntityGrp1.BalnceAmt = decOpeningBal + decPaidAmt;
                            objEntityUpdateOB.Add(objSubEntityGrp1);
                        }
                    }
                }

                //END

            }
        }

        try
        {

            ObjEntityRequest.AccntNameId = Convert.ToInt32(ddlAccontLed.SelectedItem.Value);
            DataTable dtCHK = objBussiness.CheckReceiptCnclSts(ObjEntityRequest);
            int AcntCloseSts = AccountCloseCheck(txtdate.Value);
            int AuditCloseSts = AuditCloseCheck(txtdate.Value);

            if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
            {
                Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=AuditClosed");
            }
            else  if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
            {
            
            }
            //0039
            else if (dtCHK.Rows[0]["RECPT_REOPEN_USRID"].ToString() != "" && dtCHK.Rows[0]["RECPT_CNFRM_STS"].ToString() == "0")
            {
                Response.Redirect("fms_Receipt_Account.aspx?Id=" + Request.QueryString["ViewId"] + "&InsUpd=AlreadyReopen");
            }
            //end
            else if (AcntCloseSts == 1 && HiddenProvisionSts.Value != (clsCommonLibrary.StatusAll.Active).ToString())
            {
                Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=AcntClosed");
            }
             if (dtCHK.Rows[0][0].ToString() == "")
            {
                objBussiness.ReOpenById(ObjEntityRequest, objEntityPerfomList, objEntityPerfomListGrps, objEntityUpdateOB);
                //0039
                Response.Redirect("fms_Receipt_Account.aspx?Id=" + Request.QueryString["ViewId"] + "&InsUpd=Reop");
                
               // Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=Reopns");
                 //end
            }
            else if (dtCHK.Rows[0][0].ToString() != "")
            {
                Response.Redirect("fms_Receipt_Account_List.aspx?InsUpd=UpdCancl");
            }



        }
        catch
        {

        }
        //   HttpContext.Current.Session["REOPEN_STS"] = strRets;
        //return strRets;

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

    [WebMethod]
    public static string printReceiptDetails(string strId, string strUserID, string strOrgIdID, string strCorpID, string crncyAbrvt, string crncyId, string UsrName)
    {
       

        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsCommonLibrary objCommn = new clsCommonLibrary();

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();
        clsEntity_Receipt_Account objEntityRcpt = new clsEntity_Receipt_Account();
        string PreparedBy = "";
        string CheckedBy = "";
        if (strCorpID != null)
        {
            objEntityCommon.CorporateID = Convert.ToInt32(strCorpID);
            objEntityRcpt.Corporate_id = Convert.ToInt32(strCorpID);
        }
        if (strOrgIdID != null)
        {
            objEntityRcpt.Organisation_id = Convert.ToInt32(strOrgIdID);
        }
        if (strUserID != null)
        {
            objEntityRcpt.User_Id = Convert.ToInt32(strUserID);
        }

        objEntityRcpt.ReceiptId = Convert.ToInt32(strId);

        if (UsrName != "")
        {
            PreparedBy = UsrName;
        }

       

       


        DataTable dt = objBussiness.ReadReceptDetailsById(objEntityRcpt);
        DataTable dtSales = new DataTable();
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["RECPT_CONFRM_USRID"].ToString() != "")
            {
                objEntityRcpt.User_Id = Convert.ToInt32(dt.Rows[0]["RECPT_CONFRM_USRID"].ToString());
                DataTable dtCheckedUserName = objBussiness.ReadUserName(objEntityRcpt);
                if (dtCheckedUserName.Rows.Count > 0)
                {
                    if (dtCheckedUserName.Rows[0]["USR_NAME"].ToString() != "")
                    {
                        CheckedBy = dtCheckedUserName.Rows[0]["USR_NAME"].ToString();
                    }
                }
            }

            if (dt.Rows[0]["RECPT_ACCNT_LDGR_ID"].ToString() != "")
            {
                objEntityRcpt.LedgerId = Convert.ToInt32(dt.Rows[0]["RECPT_ACCNT_LDGR_ID"].ToString());
            }
            dtSales = objBussiness.AccntBalancebyId(objEntityRcpt);

        }
        DataTable dtProduct = objBussiness.ReadReceptLedgerDetailsByIdforPrint(objEntityRcpt);
        DataTable invoiceDtl = new DataTable();
        //   ObjEntitySales.LedgerId = Convert.ToInt32(ddlCustomerLdgr.SelectedItem.Value);
        if (dtProduct.Rows.Count == 1)
        {
            objEntityRcpt.LedgerId = Convert.ToInt32(dtProduct.Rows[0]["RECPT_LD_ID"].ToString());
            objEntityRcpt.Status = 3;
            invoiceDtl = objBussiness.ReadReceptCostcntrDetailsById(objEntityRcpt);
        }


        DataTable dtCorp = objBussiness.ReadCorpDtls(objEntityRcpt);

        FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account objPage = new FMS_FMS_Master_fms_Receipt_Account_fms_Receipt_Account();


        int Version_flg = 0;
       
        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.RECEIPT);
        DataTable dtVersion = objBusinessLayer.ReadPrintVersion(objEntityCommon);

        string strReturn = "";
        if (dtVersion.Rows.Count > 0)
        {
            if (dtVersion.Rows[0][0].ToString() == "1")
            {
                Version_flg = 1;

                strReturn = objBussiness.PdfPrintVersion1(strId, dt, dtProduct, dtCorp, objEntityRcpt, PreparedBy, CheckedBy, crncyAbrvt, crncyId, Version_flg);
            }
            else if (dtVersion.Rows[0][0].ToString() == "2")
            {
                Version_flg = 2;
                strReturn = objBussiness.PdfPrintVersion2(strId, dt, dtProduct, dtCorp, objEntityRcpt, PreparedBy, CheckedBy, crncyAbrvt, crncyId, Version_flg, dtSales, invoiceDtl);
            }
            else if (dtVersion.Rows[0][0].ToString() == "3")
            {
                Version_flg = 3;
                strReturn = objBussiness.PdfPrintVersion2(strId, dt, dtProduct, dtCorp, objEntityRcpt, PreparedBy, CheckedBy, crncyAbrvt, crncyId, Version_flg, dtSales, invoiceDtl);
            }
        }

        return strReturn;


       // return objPage.PdfPrint(strId, dt, dtProduct, dtCorp, objEntityRcpt, PreparedBy, CheckedBy, crncyAbrvt, crncyId);
    }


    [WebMethod]
    public static string CheckSaleSettlement(string strSalePurchaseDtls, string strOrgIdID, string strCorpID, string strxLoop, string strTotalAmnt, string strPurchaseId)
    {
        //EVM-0020
        string ret = "successConfirm";

        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();
        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

        string SalePurchaseDtl = strSalePurchaseDtls;
        if (SalePurchaseDtl != "" && SalePurchaseDtl != "null" && SalePurchaseDtl != null)
        {
            string[] values = SalePurchaseDtl.Split('$');
            for (int i = 0; i < values.Length; i++)
            {
                clsEntity_Receipt_Account objSubEntity = new clsEntity_Receipt_Account();
                objSubEntity.Organisation_id = Convert.ToInt32(strOrgIdID);
                objSubEntity.Corporate_id = Convert.ToInt32(strCorpID);
                if (values[i] != "")
                {
                    objSubEntity.Status = 1;
                    //objSubEntity.LedgerId = Convert.ToInt32(HttpContext.Current.Request.Form["ddlLedId" + strxLoop]);
                    string[] valSplit = values[i].Split('%');
                    objSubEntity.CostCtrId = Convert.ToInt32(valSplit[0]);

                    if (valSplit[1] != "" || valSplit[6] != "")
                    {

                        valSplit[1] = valSplit[1].Replace(",", "");
                        if (valSplit[1] != "")
                        {
                            valSplit[1] = valSplit[1].Replace(",", "");
                            objSubEntity.CstCntrAmnt = Convert.ToDecimal(valSplit[1]);
                        }
                        if (valSplit[2] != "")
                        {
                            objSubEntity.SettlmntAmmnt = Convert.ToDecimal(valSplit[2]);
                        }

                        valSplit[5] = valSplit[5].Replace(",", "");
                        valSplit[6] = valSplit[6].Replace(",", "");

                        string strDebitNoteId = valSplit[4];

                        objSubEntity.AccntNameId = Convert.ToInt32(valSplit[4]);
                        if (valSplit[5] != "")
                            objSubEntity.BalanceAmount = Convert.ToDecimal(valSplit[5]);
                        if (valSplit[6] != "")
                            objSubEntity.LedgerAmnt = Convert.ToDecimal(valSplit[6]);

                        if (objSubEntity.CstCntrAmnt > 0 || objSubEntity.LedgerAmnt > 0)
                        {
                            DataTable dtSalesBalance = objBussiness.ReadSalesBalance(objSubEntity);

                            if (strDebitNoteId != "" && strDebitNoteId != "0")
                            {
                                dtSalesBalance = objBussiness.ReadSalesReturnBalance(objSubEntity);
                            }

                            decimal decCheckAmnt = objSubEntity.CstCntrAmnt;
                            if (strDebitNoteId != "" && strDebitNoteId != "0")
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
                                    ret = "SalesAmountExceeded";
                                    break;
                                }
                                else
                                {
                                    if (strPurchaseId == objSubEntity.CostCtrId.ToString() && decSalesRemainAmt < Convert.ToDecimal(strTotalAmnt))
                                    {
                                        ret = "SalesAmountExceeded";
                                        break;
                                    }
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

        }

        return ret;
    }
    [WebMethod]
    public static string CheckDupBankAcNum(string RcptBankCurr, string RcptAcntNumCurr, string UpdateId)
    {
        string result = "";
        clsEntity_Receipt_Account ObjEntityRequest = new clsEntity_Receipt_Account();
        clsBusinessLayer_Receipt_Account objBussiness = new clsBusinessLayer_Receipt_Account();

        //clsEntity_Postdated_Cheque objEntity_Cheque = new clsEntity_Postdated_Cheque();
        //clsBusinessPostdated_Cheque objBusiness_Cheque = new clsBusinessPostdated_Cheque();
        ObjEntityRequest.Bank_Name = RcptBankCurr;
        ObjEntityRequest.CancelReason = RcptAcntNumCurr;
        ObjEntityRequest.ReceiptId = Convert.ToInt32(UpdateId);
        DataTable dtChequeBook = objBussiness.CheckDupBankAcNum(ObjEntityRequest);
        if (dtChequeBook.Rows.Count > 0)
        {
            result = "false";
        }
        return result;
    }




   
}

