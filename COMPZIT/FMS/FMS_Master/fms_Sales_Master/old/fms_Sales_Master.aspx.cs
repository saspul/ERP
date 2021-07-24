using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using EL_Compzit.EntityLayer_FMS;
using BL_Compzit;
using BL_Compzit.BusinessLayer_FMS;
using CL_Compzit;
using System.Data;
using BL_Compzit.BusineesLayer_FMS;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Web.Services;
using System.Threading;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;


public partial class FMS_FMS_Master_fms_Sales_Master_fms_Sales_Master : System.Web.UI.Page
{
    clsBusinessSales objBusinessSales = new clsBusinessSales();
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
        cbxExtngSplr.Focus();
       
        if (!IsPostBack)
        {
            txtOrder.Focus();
            loadCustomerLedger();
          
            CurrencyLoad();
          //  HiddenDfltLdgr.Value = "0";
            LoadDfltLdgr();
            LoadLedgers();
            CostCenterLoad();
            CostGroup1Load();
            CostGroup2Load();
            HiddenDefultCrncAbrvtn.Value = "";
            HiddenDiscountEnableSts.Value = "0";
            clsEntitySales objEntity = new clsEntitySales();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objcommon = new clsCommonLibrary();
            clsEntityCommon objentcommn = new clsEntityCommon();
           
            int intCorpId = 0, intOrgId = 0, intUserId = 0;
            if (Session["USERID"] != null)
            {
                intUserId = Convert.ToInt32(Session["USERID"]);

                objEntity.User_Id = intUserId;

            }
            else if (Session["USERID"] == null)
            {
                Response.Redirect("/Default.aspx");
            }
            if (Session["CORPOFFICEID"] != null)
            {
                intCorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objentcommn.CorporateID = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
                objEntity.Corporate_id = intCorpId;
            }
            else if (Session["CORPOFFICEID"] == null)
            {

                Response.Redirect("/Default.aspx");
            }
            if (Session["ORGID"] != null)
            {
                intOrgId = Convert.ToInt32(Session["ORGID"].ToString());
                objEntity.Organisation_id = intOrgId;
                objentcommn.Organisation_Id = Convert.ToInt32(Session["ORGID"].ToString());
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

            objEntity.ActModeId = Convert.ToInt32(clsCommonLibrary.ASMOD_ID.sales);
            //objEntityLedger.ActModeId = 5;
            DataTable dtdiv = objBusinessSales.ReadDefultLdgr(objEntity);
            if (dtdiv.Rows.Count > 0)
            {

                HiddenDefltPrdtLedId.Value = "0";
            }
            else
            {
                HiddenDefltPrdtLedId.Value = "1";
                //  ScriptManager.RegisterStartupScript(this, GetType(), "AcntGrpErrMsg", "AcntGrpErrMsg();", true);
            }



            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_INVENTORY_FOREX_STATUS,
                                                            clsCommonLibrary.CORP_GLOBAL.REFNUM_ACCNTCLS_STS
                                                             ,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_TAX_ENABLED,
                                                            clsCommonLibrary.CORP_GLOBAL.FMS_PRDT_DUPLICATION,
                                                           clsCommonLibrary.CORP_GLOBAL.FMS_DYNAMIC_CNTRL_STS
                                                      
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                hiddenDecimalCount.Value = dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                objEntity.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
                HiddenCurrncyId.Value = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
                HiddenInventoryForex.Value = dtCorpDetail.Rows[0]["GN_INVENTORY_FOREX_STATUS"].ToString();
                HiddenTaxEnable.Value = dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString();
                HiddenRefAccountCls.Value = dtCorpDetail.Rows[0]["REFNUM_ACCNTCLS_STS"].ToString();

                HiddenProductDupSts.Value = dtCorpDetail.Rows[0]["FMS_PRDT_DUPLICATION"].ToString();
                // 0-Duplication not allowed 1-Duplication allowed

                if (dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString() != "")
                {
                    TaxEnable = Convert.ToInt32(dtCorpDetail.Rows[0]["GN_TAX_ENABLED"].ToString());
                }

            }


            this.Form.Enctype = "multipart/form-data";
            // for adding comma
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.CurrencyId = Convert.ToInt32(hiddenDfltCurrencyMstrId.Value);
            DataTable dtCurrencyDetail = new DataTable();
            dtCurrencyDetail = objBusinessLayer.ReadCurrencyDetails(objEntityCommon);
            if (dtCurrencyDetail.Rows.Count > 0)
            {
                hiddenCurrencyModeId.Value = dtCurrencyDetail.Rows[0]["CRNCYMD_ID"].ToString();
                HiddenCurrency.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
                HiddenDefultCrncAbrvtn.Value = dtCurrencyDetail.Rows[0]["CRNCMST_ABBRV"].ToString();
            }
            int intConfirm = 0, intUsrRolMstrId = 0, IntAllDivision = 0, intAdd = 0, intUpdate = 0, intEnableCancel = 0, intEnableDiscount = 0,intreopen=0;
            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.SALES);
            DataTable dtChildRol = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenFieldAuditCloseReopenSts.Value = "0";
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
                        HiddenUpdateSts.Value = "1";
                    }
                    else if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Cancel).ToString())
                    {
                        intEnableCancel = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                    }

                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.DISCOUNT).ToString())
                    {
                        intEnableDiscount = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenDiscountEnableSts.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_ACCOUNT).ToString())
                    {
                        HiddenProvisionSts.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Re_Open).ToString())
                    {
                        intreopen = Convert.ToInt32(clsCommonLibrary.StatusAll.Active);
                        HiddenReopenPrvsn.Value = "1";
                       
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.Confirm).ToString())
                    {
                        HiddenConfirmStatus.Value = "1";
                    }
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.FMS_AUDIT).ToString())
                    {
                        HiddenFieldAuditCloseReopenSts.Value = "1";
                    }
                   
                }
            }


            intUsrRolMstrId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.Customer_Master);
            DataTable dtChildRol1 = objBusinessLayer.LoadChildRoleDefnDetail(intUserId, intUsrRolMstrId);
            HiddenAccountSpecific.Value = "0";

            if (dtChildRol1.Rows.Count > 0)
            {
                string strChildRolDeftn = dtChildRol1.Rows[0]["USRROL_CHLDRL_DEFN"].ToString();

                string[] strChildDefArrWords = strChildRolDeftn.Split('-');
                foreach (string strC_Role in strChildDefArrWords)
                {
                    
                    if (strC_Role == Convert.ToInt16(clsCommonLibrary.ChildRole.ACCOUNT_SPECIFIC).ToString())
                    {
                        HiddenAccountSpecific.Value = "1";
                    }


                }
            }

            btnPRint.Visible = false;
            btnFloatPRint.Visible = false;
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES);
            objEntityCommon.CorporateID = intCorpId;
            objEntityCommon.Organisation_Id = intOrgId;
            string strNextId = objBusinessLayer.ReadNextSequence(objEntityCommon);
          //  objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.USR_ROLE_MSTR.SALES);
            DataTable dtFormate = objBusinessSales.readRefFormate(objEntityCommon);
            // evm 0044
            string refenablests = "";
            
            if (dtFormate.Rows.Count > 0)
            {
                refenablests = dtFormate.Rows[0]["REF_SALES_NUM_ENABLE_STS"].ToString();
                HiddenRefEnableSts.Value = refenablests;
            }

            //------
            string CurrentDate = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
            DateTime dtCurrentDate = objcommon.textToDateTime(CurrentDate);
            int DtYear = dtCurrentDate.Year;
            int DtMonth = dtCurrentDate.Month;
            string dtyy = dtCurrentDate.ToString("yy");

            clsCommonLibrary objCommon = new clsCommonLibrary();

            DataTable dtCurrentFiscalYr = objBusinessLayer.ReadFinancialYearById(objentcommn);
            DateTime dtFinStartDate = new DateTime();
            DateTime dtFinEndDate = new DateTime();
            if (dtCurrentFiscalYr.Rows.Count > 0)
            {
                dtFinStartDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_START_DT"].ToString());
                dtFinEndDate = objCommon.textToDateTime(dtCurrentFiscalYr.Rows[0]["FINCYR_END_DT"].ToString());
            }

            string refFormatByDiv = "";
            string strRealFormat = "";
            //evm 0044---------
            if (refenablests  == "0")
            {
                txtRef.Enabled = false;
                //---------------            
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
                    txtRef.Text = strRealFormat;
                 
                }
                     
                
            }
            else
            {
                txtRef.Text = strNextId;
              
            }

              }

            //--------------evm 00444
                
            else if (refenablests  == "1")
               
            {
                
                txtRef.Enabled = true;
                 
                txtRef.Text = "";
                 
                txtRef.Focus();
             
            }
            DataTable dtfinaclYear = objBusinessLayer.ReadFinancialYearById(objentcommn);

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
                DataTable dtAcntClsDate = objBusinessLayer.ReadAccountClsDate(objEntityCommon);
                DataTable dtAuditClsDate = objBusinessLayer.ReadLastAuditClose(objentcommn);


                DateTime curdate1 = objcommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());

                if ((dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString() != "" && dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString() != ""))
                {
                    if (curdate1 > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate1 < objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                      //  txtDateFrom.Value = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");

                    }

                    HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();

                }

                if (dtAcntClsDate.Rows.Count > 0 && dtAuditClsDate.Rows.Count > 0)
                {
       

                    HiddenAcntClsDate.Value = dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString();

                    if (HiddenFieldAuditCloseReopenSts.Value == "1")
                    {
                        txtDateFrom.Value = objBusinessLayer.LoadCurrentDateInString();
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();


                        if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            HiddenReopen.Value = "1";
                        }
                        else
                        {
                            HiddenReopen.Value = "0";

                        }
                    }
                    else
                    {


                        if (objcommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                        {

                            HiddenReopen.Value = "0";

                            DateTime startDate = new DateTime();
                            if (dtAcntClsDate.Rows.Count > 0 && dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "")
                            {
                                startDate = objcommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                            }

                            DateTime startDate1 = new DateTime();
                            if (dtAuditClsDate.Rows.Count > 0 && dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString() != "")
                            {
                                startDate1 = objcommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());
                            }


                            if (startDate >= startDate1)
                            {
                                if (HiddenProvisionSts.Value != "1")
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


                    if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        HiddenReopen.Value = "1";
                    }
                    else
                    {
                        HiddenReopen.Value = "0";

                    }

                    DateTime curdate = objcommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    string Ref = "";

                    if (curdate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        DateTime startDate = new DateTime();
                       
                            startDate = objcommon.textToDateTime(HiddenStartDate.Value);
                        
                        if (HiddenFieldAuditCloseReopenSts.Value=="1")
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {

                                txtDateFrom.Value = objBusinessLayer.LoadCurrentDateInString();
                                clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
                                clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                                 cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
                                clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                                objEntityAccnt.FromDate = objcommon.textToDateTime(txtDateFrom.Value);
                                objEntityAudit.FromDate = objcommon.textToDateTime(txtDateFrom.Value);

                                objEntity.FromPeriod = objcommon.textToDateTime(txtDateFrom.Value);
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
                                {   //evm 0044
                                    if (refenablests == "0")
                                    {
                                        //-------
                                        DataTable dtRefFormat1 = objBusinessSales.ReadRefNumberByDate(objEntity);
                                        if (dtRefFormat1.Rows.Count > 0)
                                        {

                                            string strRef = "";
                                            if (dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                if (Convert.ToInt32(dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString()) != 1)
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                                                    strRef = strRef.TrimEnd('/');
                                                    strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                                }
                                                else
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                                                }
                                            }
                                            else
                                            {
                                                strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                                            }
                                            objEntity.Ref = strRef;
                                            DataTable dtRefFormat = objBusinessSales.ReadRefNumberByDateLast(objEntity);
                                            if (dtRefFormat.Rows.Count > 0)
                                            {
                                                Ref = dtRefFormat.Rows[0]["SALES_REF"].ToString();
                                                if (dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != null)
                                                {
                                                    SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString());
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
                        }
                        else
                        {
                            
                            if (dtAcntClsDate.Rows.Count > 0 && dtAuditClsDate.Rows.Count > 0)
                            {
                                if (objcommon.textToDateTime(HiddenStartDate.Value) < curdate)
                                {
                                    txtDateFrom.Value = objBusinessLayer.LoadCurrentDateInString();
                                }
                                else
                                {
                                    txtDateFrom.Value = HiddenStartDate.Value;
                                }
                            }


                            else
                            {
                                txtDateFrom.Value = objBusinessLayer.LoadCurrentDateInString();
                            }
                        }
                    }
                }
                else if ( dtAuditClsDate.Rows.Count > 0)
                {
                  //  HiddenAcntClsDate.Value = dtAuditClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString();
                    if (HiddenFieldAuditCloseReopenSts.Value == "1")
                    {
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                        if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            HiddenReopen.Value = "1";
                        }
                        else
                        {
                            HiddenReopen.Value = "0";

                        }
                    }
                    else
                    {
                        if (objcommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                        {

                            HiddenReopen.Value = "0";

                            DateTime startDate = new DateTime();
                            if (dtAuditClsDate.Rows.Count > 0 && dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString() != "")
                            {
                                startDate = objcommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString());
                            }

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

                    if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        HiddenReopen.Value = "1";
                    }
                    else
                    {
                        HiddenReopen.Value = "0";

                    }

                    DateTime curdate = objcommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    string Ref = "";

                    if (curdate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        DateTime startDate = new DateTime();

                        startDate = objcommon.textToDateTime(HiddenStartDate.Value);

                        if (HiddenFieldAuditCloseReopenSts.Value == "1")
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {

                                txtDateFrom.Value = objBusinessLayer.LoadCurrentDateInString();

                                cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
                                clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
                                objEntityAudit.FromDate = objcommon.textToDateTime(txtDateFrom.Value);

                                objEntity.FromPeriod = objcommon.textToDateTime(txtDateFrom.Value);

                                objEntity.Corporate_id = intCorpId;

                                objEntity.Organisation_id = intOrgId;
                                objEntityAudit.Corporate_id = intCorpId;
                                objEntityAudit.Organisation_id = intOrgId;
                                int SubRef = 1;

                                DataTable dtAuditCls = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                                if (dtAuditCls.Rows.Count > 0)
                                  {   //evm 0044
                                      if (refenablests == "0")
                                      {
                                          //-------
                                          DataTable dtRefFormat1 = objBusinessSales.ReadRefNumberByDate(objEntity);
                                          if (dtRefFormat1.Rows.Count > 0)
                                          {
                                              string strRef = "";
                                              if (dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != null)
                                              {
                                                  if (Convert.ToInt32(dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString()) != 1)
                                                  {
                                                      strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                                                      strRef = strRef.TrimEnd('/');
                                                      strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                                  }
                                              }
                                              else
                                              {
                                                  strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                                              }
                                              objEntity.Ref = strRef;
                                              DataTable dtRefFormat = objBusinessSales.ReadRefNumberByDateLast(objEntity);
                                              if (dtRefFormat.Rows.Count > 0)
                                              {
                                                  Ref = dtRefFormat.Rows[0]["SALES_REF"].ToString();
                                                  if (dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != null)
                                                  {
                                                      SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString());
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
                        }
                        else
                        {

                            if (dtAuditClsDate.Rows.Count > 0)
                            {
                                if (startDate < curdate)
                                {
                                    txtDateFrom.Value = objBusinessLayer.LoadCurrentDateInString();
                                }
                            }
                            else
                            {
                                txtDateFrom.Value = objBusinessLayer.LoadCurrentDateInString();
                            }

                        }
                    }
                }

                else  if (dtAcntClsDate.Rows.Count > 0)
                {
                    HiddenAcntClsDate.Value = dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString();
                    if (HiddenProvisionSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                    {
                        HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                        HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                        if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                        {
                            HiddenReopen.Value = "1";
                        }
                        else
                        {
                            HiddenReopen.Value = "0";

                        }
                    }
                    else
                    {
                        if (objcommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString()) >= objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()))
                        {
                            HiddenReopen.Value = "0";

                            DateTime startDate = new DateTime();
                            if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "" && dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != null)
                            {
                                startDate = objcommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                            }

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

                    if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        HiddenReopen.Value = "1";
                    }
                    else
                    {
                        HiddenReopen.Value = "0";

                    }

                    DateTime curdate = objcommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());
                    string Ref = "";

                    if (curdate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curdate < objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                    {
                        DateTime startDate = new DateTime();
                        if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "" && dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != null)
                        {
                            startDate = objcommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                        }
                        if (HiddenProvisionSts.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                        {
                            if (HiddenRefAccountCls.Value == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                            {

                                txtDateFrom.Value = objBusinessLayer.LoadCurrentDateInString();
                                clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
                                clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
                                objEntityAccnt.FromDate = objcommon.textToDateTime(txtDateFrom.Value);

                                objEntity.FromPeriod = objcommon.textToDateTime(txtDateFrom.Value);
                                objEntityAccnt.Corporate_id = intCorpId;
                                objEntity.Corporate_id = intCorpId;
                                objEntityAccnt.Organisation_id = intOrgId;
                                objEntity.Organisation_id = intOrgId;
                                int SubRef = 1;
                                DataTable dtAccntCls = objEmpAccntCls.CheckAccountClosingDate(objEntityAccnt);
                                if (dtAccntCls.Rows.Count > 0)
                                {   //evm 0044
                                    if (refenablests == "0")
                                    {
                                        //-------
                                        DataTable dtRefFormat1 = objBusinessSales.ReadRefNumberByDate(objEntity);
                                        if (dtRefFormat1.Rows.Count > 0)
                                        {
                                            string strRef = "";
                                            if (dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != null)
                                            {
                                                if (Convert.ToInt32(dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString()) != 1)
                                                {
                                                    strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                                                    strRef = strRef.TrimEnd('/');
                                                    strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                                                }
                                            }
                                            else
                                            {
                                                strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                                            }
                                            objEntity.Ref = strRef;
                                            DataTable dtRefFormat = objBusinessSales.ReadRefNumberByDateLast(objEntity);
                                            if (dtRefFormat.Rows.Count > 0)
                                            {
                                                Ref = dtRefFormat.Rows[0]["SALES_REF"].ToString();
                                                if (dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != null)
                                                {
                                                    SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString());
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
                        }
                        else
                        {
                            if (dtAcntClsDate.Rows.Count > 0)
                            {
                                if (startDate < curdate)
                                {
                                    txtDateFrom.Value = objBusinessLayer.LoadCurrentDateInString();
                                }
                            }
                            else
                            {
                                txtDateFrom.Value = objBusinessLayer.LoadCurrentDateInString();
                            }
                        }
                    }
                }
                else
                {
                    if (intreopen == Convert.ToInt32(clsCommonLibrary.StatusAll.Active))
                    {
                        HiddenReopen.Value = "1";
                    }
                    else
                    {
                        HiddenReopen.Value = "0";

                    }


                    if (dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString() != "" && dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString() != "")
                    {
                        DateTime curntdate = objcommon.textToDateTime(objBusinessLayer.LoadCurrentDateInString());

                        if (curntdate > objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString()) && curntdate < objcommon.textToDateTime(dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString()))
                        {
                            txtDateFrom.Value = objBusinessLayer.LoadCurrentDateInString();
                        }
                    }
                    HiddenStartDate.Value = dtfinaclYear.Rows[0]["FINCYR_START_DT"].ToString();
                    HiddenCurrentDate.Value = dtfinaclYear.Rows[0]["FINCYR_END_DT"].ToString();
                }


            }
            HiddensaleId.Value = "";

            btnClear.Visible = true;
            btnFloatClear.Visible = true;

            if (Request.QueryString["Id"] != null)
            {
                lblEntry.Text = "Edit Sale";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnFloatAdd.Visible = false;
                btnFloatAddClose.Visible = false;
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
                string strRandomMixedId = Request.QueryString["Id"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId, HiddenReopen.Value, HiddenConfirmStatus.Value, YearEndCls);

                HiddensaleId.Value = strId;

                btnClear.Visible = false;
                btnFloatClear.Visible = false;

            }
            else if (Request.QueryString["ViewId"] != null)
            {
                HiddenAcntClsSts.Value = "1";
                lblEntry.Text = "View Sale";
                btnAdd.Visible = false;
                btnAddClose.Visible = false;
                btnFloatAdd.Visible = false;
                btnFloatAddClose.Visible = false;
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnFloatUpdate.Visible = false;
                btnFloatUpdateClose.Visible = false;
                btnConfirm.Visible = false;
                btnFloatConfirm.Visible = false;
                btnClear.Visible = false;
                btnFloatClear.Visible = false;

                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;
                string strRandomMixedId = Request.QueryString["ViewId"].ToString();
                string strLenghtofId = strRandomMixedId.Substring(0, 2);
                int intLenghtofId = Convert.ToInt16(strLenghtofId);
                string strId = strRandomMixedId.Substring(2, intLenghtofId);
                Update(strId, HiddenReopen.Value, HiddenConfirmStatus.Value, YearEndCls);

                HiddensaleId.Value = strId;

                btnClear.Visible = false;
                btnFloatClear.Visible = false;

            }
            else
            {
                lblEntry.Text = "Add Sale";
                btnUpdate.Visible = false;
                btnUpdateClose.Visible = false;
                btnFloatUpdate.Visible = false;
                btnFloatUpdateClose.Visible = false;
                btnConfirm.Visible = false;
                btnFloatConfirm.Visible = false;
                btnReopen.Visible = false;
                btnFloatReopen.Visible = false;

            }
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
            else if (strInsUpd == "CNFMERROR")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ConfirmError", "ConfirmError();", true);
            }
            else if (strInsUpd == "StsErr")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "StatusError", "StatusError();", true);
            }
            else if (strInsUpd == "CNFM")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessConfirmationcnfrm", "SuccessConfirmationcnfrm();", true);
            }
            else if (strInsUpd == "Reop")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SuccessReopMsg", "SuccessReopMsg();", true);
            }
            else if (strInsUpd == "REOPENERROR")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "ReopenError", "ReopenError();", true);
            }
            else if (strInsUpd == "ERROR")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", "Error();", true);
            }
            //---evm 0044
            else if (strInsUpd == "DUPE")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "DuplicationRefNumMsg", "DuplicationRefNumMsg();", true);
            }
            //-------
        }
    }
    public void LoadDfltLdgr()
    {
     
        clsEntitySales ObjEntitySales = new clsEntitySales();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySales.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySales.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        ObjEntitySales.ActModeId = Convert.ToInt32(clsCommonLibrary.ASMOD_ID.customer);
        //objEntityLedger.ActModeId = 5;
      DataTable dtdiv = objBusinessSales.ReadDefultLdgr(ObjEntitySales);
        if (dtdiv.Rows.Count > 0)
        {
            HiddenDfltLdgr.Value = dtdiv.Rows[0]["LDGR_ID"].ToString();
            HiddenDefaultLdgrSts.Value = "0";
        }
        else
        {
            HiddenDefaultLdgrSts.Value = "1";
            //  ScriptManager.RegisterStartupScript(this, GetType(), "AcntGrpErrMsg", "AcntGrpErrMsg();", true);
        }
    }
    public void Update(string strP_Id, string Reopen, string Confirm, int YearEndCls)
    {
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsEntitySales ObjEntitySales = new clsEntitySales();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySales.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySales.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            //intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntitySales.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        ObjEntitySales.SalesId = Convert.ToInt32(strP_Id);
        DataTable dt = objBusinessSales.ReadSalesDetailsById(ObjEntitySales);
        DataTable dtProduct = objBusinessSales.ReadProductSalesById(ObjEntitySales);

        DataTable dtPAttchmnt = new DataTable();
        dtPAttchmnt.Columns.Add("AttachmentDtlId", typeof(int));
        dtPAttchmnt.Columns.Add("FileName", typeof(string));
        dtPAttchmnt.Columns.Add("ActualFileName", typeof(string));
        dtPAttchmnt.Columns.Add("RowCount", typeof(int));
        clsCommonLibrary objCommon = new clsCommonLibrary();
        DataTable dtPermitAttchmnt = new DataTable();
        dtPermitAttchmnt = objBusinessSales.ReadAttachmentById(ObjEntitySales);
        hiddenFilePath.Value = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SALES_ATTACHMENT);
        if (dtPermitAttchmnt.Rows.Count > 0)
        {
            for (int intcnt = 0; intcnt < dtPermitAttchmnt.Rows.Count; intcnt++)
            {
                DataRow drAttchPermt = dtPAttchmnt.NewRow();
                drAttchPermt["AttachmentDtlId"] = dtPermitAttchmnt.Rows[intcnt][0].ToString();
                drAttchPermt["FileName"] = dtPermitAttchmnt.Rows[intcnt][1].ToString();
                drAttchPermt["ActualFileName"] = dtPermitAttchmnt.Rows[intcnt][2].ToString();
                drAttchPermt["RowCount"] = dtPermitAttchmnt.Rows[intcnt][3].ToString();

                dtPAttchmnt.Rows.Add(drAttchPermt);
            
            }

            string strJson1 = DataTableToJSONWithJavaScriptSerializer(dtPAttchmnt);
            hiddenEditPrmtAttchmnt.Value = strJson1;
        }



        if (dt.Rows.Count > 0)
        {

            Hiddenref_NextNumber.Value = dt.Rows[0]["SALES_REF_NEXTNUM"].ToString();


            txtDesc.Value = dt.Rows[0]["SALES_DESC"].ToString();

            if (dt.Rows[0]["SALES_REF"].ToString() != "")
            {
                txtRef.Text = dt.Rows[0]["SALES_REF"].ToString();
                HiddenUpdRefNum.Value = dt.Rows[0]["SALES_REF"].ToString();
            }
            if (dt.Rows[0]["SALES_DATE"].ToString() != "")
            {
                txtDateFrom.Value = dt.Rows[0]["SALES_DATE"].ToString();
                HiddenUpdatedDate.Value = dt.Rows[0]["SALES_DATE"].ToString();
            }
            ddlCurrency.ClearSelection();
            if (dt.Rows[0]["CRNCMST_ID"].ToString() != "")
            {
                if (ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()) != null)
                {

                    ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }
                else
                {
                    System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dt.Rows[0]["CRNCMST_NAME"].ToString(), dt.Rows[0]["CRNCMST_ID"].ToString());
                    ddlCurrency.Items.Insert(1, lstGrp);
                    SortDDL(ref this.ddlCurrency);
                    ddlCurrency.Items.FindByValue(dt.Rows[0]["CRNCMST_ID"].ToString()).Selected = true;
                }
            }
            else
            {
                ddlCurrency.Items.FindByValue(dt.Rows[0]["DEFAULT_CRNCMST_ID"].ToString()).Selected = true;
            }


            if (dt.Rows[0]["SALES_ATACHMENT_STS"].ToString() != "")
            {
                if (dt.Rows[0]["SALES_ATACHMENT_STS"].ToString() == "1")
                {
                    cbxAddAttachment.Checked = true;
                }
                else
                {
                    cbxAddAttachment.Checked = false;
                }

            }


            if (dt.Rows[0]["SALES_CR_PRD"].ToString() != "")
            {
                txtcrdtPeriod.Text = dt.Rows[0]["SALES_CR_PRD"].ToString();
            }
            //43
            if (dt.Rows[0]["SALES_GUEST_NAME"].ToString() != "")
            {
                txtGuestName.Text = dt.Rows[0]["SALES_GUEST_NAME"].ToString();
            }
            //end

            if (dt.Rows[0]["SALES_CUST_TYP"].ToString() == "0")
            {
                cbxExtngSplr.Checked = true;

                if (ddlCustomerLdgr.Items.FindByValue(dt.Rows[0]["CSTMR_ID"].ToString()) != null)
                {
                    ddlCustomerLdgr.Items.FindByValue(dt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                    ObjEntitySales.LedgerId = Convert.ToInt32(dt.Rows[0]["CSTMR_ID"].ToString());
                }
                else
                {
                    System.Web.UI.WebControls.ListItem lstGrp = new System.Web.UI.WebControls.ListItem(dt.Rows[0]["CUSTOMER"].ToString(), dt.Rows[0]["CSTMR_ID"].ToString());
                    ddlCustomerLdgr.Items.Insert(1, lstGrp);
                    SortDDL(ref this.ddlCustomerLdgr);
                    ddlCustomerLdgr.Items.FindByValue(dt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                    ObjEntitySales.LedgerId = Convert.ToInt32(dt.Rows[0]["CSTMR_ID"].ToString());
                }

            }

            else
            {
                cbxExtngSplr.Checked = false;
                if (dt.Rows[0]["SALES_CUST_NAME"].ToString() != "")
                {
                    txtsplrName.Text = dt.Rows[0]["SALES_CUST_NAME"].ToString();
                }

                if (dt.Rows[0]["SALES_CUST_ADDRS_ONE"].ToString() != "")
                {
                    txtAddress1.Text = dt.Rows[0]["SALES_CUST_ADDRS_ONE"].ToString();
                }
                if (dt.Rows[0]["SALES_CUST_ADDRS_TWO"].ToString() != "")
                {
                    txtAddress2.Text = dt.Rows[0]["SALES_CUST_ADDRS_TWO"].ToString();
                }
                if (dt.Rows[0]["SALES_CUST_ADDRS_THREE"].ToString() != "")
                {
                    txtAddress3.Text = dt.Rows[0]["SALES_CUST_ADDRS_THREE"].ToString();
                }
                if (dt.Rows[0]["CSTMR_ID"].ToString() != "")
                {
                    ddlLedger.Items.FindByValue(dt.Rows[0]["CSTMR_ID"].ToString()).Selected = true;
                    HiddenDfltLdgr.Value = dt.Rows[0]["CSTMR_ID"].ToString();
                }
            }
       
            if (dt.Rows[0]["SALES_ORDERNO"].ToString() != "")
            {
                txtOrder.Text = dt.Rows[0]["SALES_ORDERNO"].ToString();
            }
            if (dt.Rows[0]["CRNCY_STS"].ToString() == "1")
            {
                if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
                {
                    txtGrsTotal.InnerHtml = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                    HiddenGrossAmt.Value = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
                }
                if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
                {
                    txtTotalTaxAmt.InnerHtml = dt.Rows[0]["SALES_TAX_TOTAL"].ToString() + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                    HiddenTax.Value = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();
                }
                if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
                {
                    txtDiscount.Text = dt.Rows[0]["SALES_DISCOUNT"].ToString() + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                    Hiddendiscount.Value = dt.Rows[0]["SALES_DISCOUNT"].ToString();
                }
                if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                {
                    txtNetTotal.Text = dt.Rows[0]["SALES_NET_TOTAL"].ToString() + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                    HiddenNetAmt.Value = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
                    
                }
                if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "" && dt.Rows[0]["EXCHANG_RATE"].ToString() != "")
                {
                    divTotalDefultCrncy.Attributes["style"] = "display:block;";
                    divExchangecurency.Attributes["style"] = "display:block;";
                    txtExchangeRate.Text = dt.Rows[0]["EXCHANG_RATE"].ToString();
                    lblCrncyAbrvtn.Text = dt.Rows[0]["CRNCMST_ABBRV"].ToString();
                    decimal nettotal = Convert.ToDecimal(dt.Rows[0]["SALES_NET_TOTAL"].ToString());
                    decimal exchangeRate = Convert.ToDecimal(dt.Rows[0]["EXCHANG_RATE"].ToString());
                    decimal TotalDefultCurnc = nettotal * exchangeRate;
                    txtDefultCrncyTotl.Text = TotalDefultCurnc.ToString() + " " + dt.Rows[0]["DEFULT_ABRVTN"].ToString();
                }
               
                

            }
            else
            {
                if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
                {
                    txtGrsTotal.InnerHtml = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() + " " + dt.Rows[0]["DEFULT_ABRVTN"].ToString(); 
                    HiddenGrossAmt.Value = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
                }
                if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
                {
                    txtTotalTaxAmt.InnerHtml = dt.Rows[0]["SALES_TAX_TOTAL"].ToString() + " " + dt.Rows[0]["DEFULT_ABRVTN"].ToString();
                    HiddenTax.Value = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();
                }
                if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
                {
                    txtDiscount.Text = dt.Rows[0]["SALES_DISCOUNT"].ToString() + " " + dt.Rows[0]["DEFULT_ABRVTN"].ToString();
                    Hiddendiscount.Value = dt.Rows[0]["SALES_DISCOUNT"].ToString();
                }
                if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                {
                    txtNetTotal.Text = dt.Rows[0]["SALES_NET_TOTAL"].ToString() + " " + dt.Rows[0]["DEFULT_ABRVTN"].ToString();
                    HiddenNetAmt.Value = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
                }
            }

            int STS = Convert.ToInt32(dt.Rows[0]["STATUS"].ToString());
            if (STS == 1)
            {
                checkSts.Checked = true;
            }
            else
            {
                checkSts.Checked = false;
                btnFloatConfirm.Visible = false;
                btnConfirm.Visible = false;
            }

        }
        int AcntCloseSts = 0; int AuditCloseSts = 0;
        if (dt.Rows.Count > 0)
        {
            AccountCloseCheck(dt.Rows[0]["SALES_DATE"].ToString());

            AuditCloseCheck(dt.Rows[0]["SALES_DATE"].ToString());
        }

        if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
        {
            btnPRint.Visible = true;
            btnFloatPRint.Visible = true;
            if (Reopen == "1")
            {

                if (dt.Rows[0]["CNT_SETTLE"].ToString() == "0")
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
                    else if (AcntCloseSts == 1 && HiddenProvisionSts.Value == "1")
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

            }

        }

        else if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() != "1" && AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
        {

        }
        else if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() != "1" && AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
        {
        }


        else if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() != "1" && AcntCloseSts == 1 && HiddenProvisionSts.Value != "1")
        {

        }
        else if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() != "1" && AcntCloseSts == 1 && HiddenProvisionSts.Value == "1")
        {
        }


        if (Request.QueryString["VId"] != null)
        {
            divList.Visible = false;
            btnCancel.Visible = false;
            btnFloatCancel.Visible = false;
            btnReopen.Visible = false;
            btnFloatReopen.Visible = false;
        }

        if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() != "1")
        {
            btnPRint.Text = "Draft Print";
            btnPRint.Visible = true;
            btnFloatPRint.Visible = true;
            btnFloatPRint.Text = "Draft Print";
        }
        if (dt.Rows[0]["SALES_CNCL_USR_ID"].ToString() != "")
        {
            btnPRint.Visible = false;
            btnFloatPRint.Visible = false;
        }
        if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1" || dt.Rows[0]["SALES_CNCL_USR_ID"].ToString() != "" || HiddenAcntClsSts.Value == "1")
        {
            cbxAddAttachment.Disabled = true;
           txtDesc.Disabled = true;
           txtRef.Enabled = false;
        //   ddlAccountName.Enabled = false;
           txtcrdtPeriod.Enabled = false; //EVM 0044
           ddlCustomerLdgr.Enabled = false;
           txtOrder.Enabled = false;
           txtReceipt.Enabled = false;
           checkSts.Disabled = true;
           txtDateFrom.Disabled = true;
           btnUpdate.Visible = false;
           btnUpdateClose.Visible = false;
           btnFloatUpdate.Visible = false;
           btnFloatUpdateClose.Visible = false;
           btnConfirm.Visible = false;
           btnFloatConfirm.Visible = false;
           btnClear.Visible = false;
           btnFloatClear.Visible = false;
           ddlCurrency.Enabled = false;
           txtExchangeRate.Enabled = false;
           cbxExtngSplr.Disabled = true;
           HiddenviewSts.Value = "1";
           txtDiscount.Enabled = false;
           txtGuestName.Enabled = false;

           if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
           {
               decimal CreditPeriod = 0;
               decimal CreditAmt = 0;
               decimal PurchaseAmt = 0;
               decimal PaymentAmt = 0;
               DateTime DatePurchase = new DateTime();
               DateTime dttoday = new DateTime();//= objCommn.textToDateTime(DateTime.Now.ToString());

               DataTable dtCredits = objBusinessSales.ReadCustomerCredits(ObjEntitySales);
               if (dtCredits.Rows.Count > 0)
               {
                   if (dtCredits.Rows[0]["CSTMR_CRD_LMT"].ToString() != "")
                   {
                       CreditAmt = Convert.ToDecimal(dtCredits.Rows[0]["CSTMR_CRD_LMT"].ToString());
                   }
                   if (dtCredits.Rows[0]["CSTMR_CRD_PERIOD"].ToString() != "")
                   {
                       CreditPeriod = Convert.ToDecimal(dtCredits.Rows[0]["CSTMR_CRD_PERIOD"].ToString());
                   }
                   if (dtCredits.Rows[0]["PAID_AMT"].ToString() != "")
                   {
                       PaymentAmt = Convert.ToDecimal(dtCredits.Rows[0]["PAID_AMT"].ToString());
                   }
                   if (dtCredits.Rows[0]["SALES_UPD_DATE"].ToString() != "")
                   {
                       DatePurchase = objCommn.textToDateTime(dtCredits.Rows[0]["SALES_UPD_DATE"].ToString());
                       // objEntityPurchase.AccountDate = objCommn.textToDateTime(dtCredits.Rows[0]["SALES_UPD_DATE"].ToString());
                   }
                   int DiffDate = Convert.ToInt32((dttoday - DatePurchase).TotalDays);
                   if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
                   {
                       PurchaseAmt = Convert.ToDecimal(dt.Rows[0]["SALES_NET_TOTAL"].ToString());
                   }


                   if (CreditAmt < PurchaseAmt && CreditAmt > 0)
                   {
                       ScriptManager.RegisterStartupScript(this, GetType(), "CreditLimtAlert", "CreditLimtAlert();", true);
                   }
                   else if (DiffDate > CreditPeriod && CreditPeriod > 0)
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

        DataTable dtDetail = new DataTable();
        dtDetail.Columns.Add("SALES_ID", typeof(int));
        dtDetail.Columns.Add("PRODUCT_ID", typeof(int));
        dtDetail.Columns.Add("PRODUCTROW", typeof(string));
        dtDetail.Columns.Add("SLNO", typeof(int));
        dtDetail.Columns.Add("QUANTITY", typeof(string));
        dtDetail.Columns.Add("RATE", typeof(string));
        dtDetail.Columns.Add("DISPER", typeof(string));
        dtDetail.Columns.Add("DISAMT", typeof(string));
        dtDetail.Columns.Add("TAX", typeof(string));
        dtDetail.Columns.Add("TAXAMT", typeof(string));
        dtDetail.Columns.Add("PRICE", typeof(string));
        dtDetail.Columns.Add("TAXNAME", typeof(string));
        dtDetail.Columns.Add("TAXPERCENTAGE", typeof(string));
        dtDetail.Columns.Add("PRODUCT_NAME", typeof(string));
       // dtDetail.Columns.Add("PRODUCT_STATUS", typeof(string));
        dtDetail.Columns.Add("PRDCT_CHCK", typeof(string));
        dtDetail.Columns.Add("SALS_PRODUCT_REMARK", typeof(string));
        dtDetail.Columns.Add("COSTCENTRE", typeof(string));

        for (int intCount = 0; intCount < dtProduct.Rows.Count; intCount++)
        {

            DataRow drDtl = dtDetail.NewRow();
            drDtl["SALES_ID"] = Convert.ToInt32(dtProduct.Rows[intCount]["SALES_ID"].ToString());
            drDtl["PRODUCT_ID"] = Convert.ToInt32(dtProduct.Rows[intCount]["PRDT_ID"].ToString());
            drDtl["PRODUCTROW"] = dtProduct.Rows[intCount]["SALS_PRODUCT_ID"].ToString();
            ObjEntitySales.SalesProductId = Convert.ToInt32(dtProduct.Rows[intCount]["SALS_PRODUCT_ID"].ToString());
            DataTable dtCCDtls = objBusinessSales.ReadSaleCCDetails(ObjEntitySales);
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
            drDtl["SLNO"] = dtProduct.Rows[intCount]["SALS_PRODUCT_SLNO"].ToString();

            drDtl["QUANTITY"] =dtProduct.Rows[intCount]["SALS_PRODUCT_QTY"].ToString();
            if (dtProduct.Rows[intCount]["SALS_PRODUCT_RATE"].ToString() != "")
            {
                drDtl["RATE"] = dtProduct.Rows[intCount]["SALS_PRODUCT_RATE"].ToString();
            }
            if (dtProduct.Rows[intCount]["SALS_PRODUCT_DISCOUNT"].ToString() != "")
            {
                drDtl["DISPER"] = dtProduct.Rows[intCount]["SALS_PRODUCT_DISCOUNT"].ToString();
            }
            if (dtProduct.Rows[intCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
            {
                drDtl["DISAMT"] = dtProduct.Rows[intCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
            }
            if (dtProduct.Rows[intCount]["SALS_PRODUCT_TAX_AMT"].ToString() != "")
            {
                drDtl["TAXAMT"] = dtProduct.Rows[intCount]["SALS_PRODUCT_TAX_AMT"].ToString();
            }
            drDtl["PRICE"] = dtProduct.Rows[intCount]["SALS_PRODUCT_PRICE"].ToString();
            if (dtProduct.Rows[intCount]["TAX_ID"].ToString() != "")
            {
                drDtl["TAX"] = dtProduct.Rows[intCount]["TAX_ID"].ToString();
            }

            if (dtProduct.Rows[intCount]["TAX_NAME"].ToString() != "")
            {
                drDtl["TAXNAME"] = dtProduct.Rows[intCount]["TAX_NAME"].ToString();
            }
            else
            {
                drDtl["TAXNAME"] = "";
            }
            if (dtProduct.Rows[intCount]["TAX_PERCENTAGE"].ToString() != "")
            {
                drDtl["TAXPERCENTAGE"] = dtProduct.Rows[intCount]["TAX_PERCENTAGE"].ToString();
            }
            else
            {
                drDtl["TAXPERCENTAGE"] = "";
            }
            if (dtProduct.Rows[intCount]["PRDT_NAME"].ToString() != "")
            {
                drDtl["PRODUCT_NAME"] = dtProduct.Rows[intCount]["PRDT_NAME"].ToString();
            }
            else
            {
                drDtl["PRODUCT_NAME"] = "";
            }
            if (dtProduct.Rows[intCount]["PRDT_STATUS"].ToString() != "")
            {
                drDtl["PRDCT_CHCK"] = dtProduct.Rows[intCount]["PRDT_STATUS"].ToString();   
            }
            if (dtProduct.Rows[intCount]["SALS_PRODUCT_REMARK"].ToString() != "")
            {
                drDtl["SALS_PRODUCT_REMARK"] = dtProduct.Rows[intCount]["SALS_PRODUCT_REMARK"].ToString();   
            }
            
            dtDetail.Rows.Add(drDtl);
        }

        if (dt.Rows[0]["SALES_CNCL_USR_ID"].ToString() != "")
        {
            btnPRint.Visible = false;
            btnFloatPRint.Visible = false;
        }
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtDetail);
        if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "0" &&  dt.Rows[0]["SALES_CNCL_USR_ID"].ToString() == "" && HiddenAcntClsSts.Value != "1")
        {
            HiddenEdit.Value = strJson;
        }
        else
        {
            HiddenView.Value = strJson;
        }

        if (YearEndCls == 1)
        {
            btnReopen.Visible = false;
            btnFloatReopen.Visible = false;
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

    public void CurrencyLoad()
    {
        clsEntitySales ObjEntitySales = new clsEntitySales();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySales.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySales.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            //intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntitySales.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
       
        ddlCurrency.ClearSelection();
        DataTable dtSubConrt = objBusinessSales.ReadCurrency(ObjEntitySales);
        if (dtSubConrt.Rows.Count > 0)
        {
            ddlCurrency.DataSource = dtSubConrt;
            ddlCurrency.DataTextField = "CRNCMST_NAME";
            ddlCurrency.DataValueField = "CRNCMST_ID";
            ddlCurrency.DataBind();

        }
        //ddlCurrency.Items.Insert(0, "--SELECT--");
        ddlCurrency.Items.Insert(0, "--SELECT CURRENCY--");

        DataTable dtDefaultcurc = objBusinessSales.ReadDefualtCurrency(ObjEntitySales);
        if (dtDefaultcurc.Rows.Count > 0)
        {
            string strdefltcurrcy = dtDefaultcurc.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            if (ddlCurrency.Items.FindByValue(strdefltcurrcy) != null)
            {
                ddlCurrency.ClearSelection();
                ddlCurrency.Items.FindByValue(strdefltcurrcy).Selected = true;
                HiddenDefaultCurncy.Value = dtDefaultcurc.Rows[0][0].ToString();
            }
        }
    }
    [WebMethod]
    public static string RedCurencyAbrvtn(string intCrncyId, string intuserid, string intorgid, string intcorpid)
    {

        string result="";
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
    public static string[] DropdownProductBind(string strOrgid, string strCorpid, string prefix)
    {

        List<string> customers = new List<string>();

        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsEntitySales ObjEntitySales = new clsEntitySales();
        ObjEntitySales.Organisation_id = Convert.ToInt32(strOrgid);
        ObjEntitySales.Corporate_id = Convert.ToInt32(strCorpid);
        ObjEntitySales.ProdctName = prefix;

        //ObjEntitySales.
        DataTable dtSubConrt = objBusinessSales.ReadProducts(ObjEntitySales);
        dtSubConrt.TableName = "dtTableLoadProduct";

        foreach (DataRow r in dtSubConrt.Rows)
        {
            customers.Add(string.Format("{0}—{1}", r[1], r[0]));
        }
        return customers.ToArray();
    }
    [WebMethod]
    public static string DropdownTaxBind(string strOrgId, string strCorpId, string strproductId)
    {
        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsEntitySales ObjEntitySales = new clsEntitySales();
        ObjEntitySales.product_id = Convert.ToInt32(strproductId);
        ObjEntitySales.Organisation_id = Convert.ToInt32(strOrgId);
        ObjEntitySales.Corporate_id = Convert.ToInt32(strCorpId);
        DataTable dtSubConrt = objBusinessSales.ReadTax(ObjEntitySales);
        dtSubConrt.TableName = "dtTableLoadTax";

        string result;
        using (StringWriter sw = new StringWriter())
        {
            dtSubConrt.WriteXml(sw);
            result = sw.ToString();
        }

        return result;
    }
    public void loadCustomerLedger()
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
        ddlCustomerLdgr.Items.Clear();
        if (dtlCstmrLedger.Rows.Count > 0)
        {
            ddlCustomerLdgr.Items.Clear();
            ddlCustomerLdgr.DataSource = dtlCstmrLedger;
            ddlCustomerLdgr.DataTextField = "LDGR_NAME";
            ddlCustomerLdgr.DataValueField = "LDGR_ID";
            ddlCustomerLdgr.DataBind();
        }
        ddlCustomerLdgr.Items.Insert(0, "--SELECT CUSTOMER--");
        if (dtlCstmrLedger.Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SundryDebtorSelect", "SundryDebtorSelect();", true);
        }
    }

    public void LoadLedgers()
    {
        clsBusiness_Account_Setting objBusiness = new clsBusiness_Account_Setting();
        clsEntity_Account_Setting objEntity = new clsEntity_Account_Setting();

        if (Session["CORPOFFICEID"] != null)
        {
            objEntity.CorpId = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            objEntity.OrgId = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }

        objEntity.AccountNatureStatus = 0;
        DataTable dtlCstmrLedger = objBusiness.ReadLedgerByNature(objEntity);

        if (dtlCstmrLedger.Rows.Count > 0)
        {
            dtlCstmrLedger.TableName = "dtTableLedgers";
            string result;
            using (StringWriter sw = new StringWriter())
            {
                dtlCstmrLedger.WriteXml(sw);
                result = sw.ToString();
            }
            HiddenLoadLedgers.Value = result;
        }


        //ddlLedger.Items.Clear();
        if (dtlCstmrLedger.Rows.Count > 0)
        {
            ddlLedger.Items.Clear();
            ddlLedger.DataSource = dtlCstmrLedger;
            ddlLedger.DataTextField = "LDGR_NAME";
            ddlLedger.DataValueField = "LDGR_ID";
            ddlLedger.DataBind();



        }
      
        ddlLedger.Items.Insert(0, "--SELECT LEDGER--");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntitySales ObjEntitySales = new clsEntitySales();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        List<clsEntitySales> ObjEntityProductList = new List<clsEntitySales>();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySales.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySales.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            //intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntitySales.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["FINCYRID"] != null)
        {
            ObjEntitySales.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
        }
        else
        {
            Response.Redirect("/Default.aspx");
        }

        ObjEntitySales.Ref = txtRef.Text;
        if (txtDateFrom.Value != "")
        {
            ObjEntitySales.Date = objCommon.textToDateTime(txtDateFrom.Value);
        }
        //  if (ddlAccountName.SelectedItem.Value != "" && ddlAccountName.SelectedItem.Value != "--SELECT--")
        //  {
        //     ObjEntitySales.AccId = Convert.ToInt32(ddlAccountName.SelectedItem.Value);
        //  }



        if (cbxExtngSplr.Checked == true)
        {
            ObjEntitySales.ExistingSplrsts = 0;
            if (Hiddencustldgr.Value != "" && Hiddencustldgr.Value != "--SELECT CUSTOMER--")
            {
                ObjEntitySales.LedgerId = Convert.ToInt32(Hiddencustldgr.Value);
            }
        }
        else
        {


            ObjEntitySales.LedgerId = Convert.ToInt32(HiddenDfltLdgr.Value);
            if (ddlLedger.SelectedItem.Value != "" || ddlLedger.SelectedItem.Value != "--SELECT LEDGER--")
            {
                ObjEntitySales.LedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);

            }
            else
            {
                ObjEntitySales.LedgerId = Convert.ToInt32(HiddenDfltLdgr.Value);
            }
            ObjEntitySales.ExistingSplrsts = 1;
            if (txtsplrName.Text.Trim() != "")
            {
                ObjEntitySales.CustName = txtsplrName.Text;
            }
            if (txtAddress1.Text.Trim() != "")
            {
                ObjEntitySales.AddressOne = txtAddress1.Text;
            }
            if (txtAddress2.Text.Trim() != "")
            {
                ObjEntitySales.AddressTwo = txtAddress2.Text;
            }
            if (txtAddress3.Text.Trim() != "")
            {
                ObjEntitySales.AddressThree = txtAddress3.Text;
            }
        }

        //43
        if (txtGuestName.Text.Trim() != "")
        {
            ObjEntitySales.GuestName = txtGuestName.Text;
        }
        //end

        if (txtOrder.Text != "")
        {
            ObjEntitySales.OrderNo = txtOrder.Text.Trim();
        }
        if (HiddenGrossAmt.Value != "")
        {
            ObjEntitySales.GrossTotal = Convert.ToDecimal(HiddenGrossAmt.Value);
        }
        if (HiddenTax.Value != "")
        {
            ObjEntitySales.TotalTax = Convert.ToDecimal(HiddenTax.Value);
        }
        if (Hiddendiscount.Value != "")
        {
            ObjEntitySales.TotalDiscount = Convert.ToDecimal(Hiddendiscount.Value);
        }

        //---evm 0044
        if (txtcrdtPeriod.Text != "" && txtcrdtPeriod.Text != null)
        {
            ObjEntitySales.CreditPeriod = Convert.ToInt32(txtcrdtPeriod.Text);
        }
        else
        {
            ObjEntitySales.CreditPeriod = 0;
        }
        //-----------

        if (HiddenCurrncyId.Value != ddlCurrency.SelectedItem.Value)
        {
            ObjEntitySales.TotalExchangeRate = Convert.ToDecimal(HiddenNetAmt.Value);
            decimal exchangRt = Convert.ToDecimal(txtExchangeRate.Text);
            decimal Amt = Convert.ToDecimal(HiddenNetAmt.Value);
            ObjEntitySales.NetTotal = Amt * exchangRt;
            ObjEntitySales.BalencAmtl = Amt * exchangRt;
        }
        else
        {
            ObjEntitySales.NetTotal = Convert.ToDecimal(HiddenNetAmt.Value);
            ObjEntitySales.BalencAmtl = Convert.ToDecimal(HiddenNetAmt.Value);

        }
        if (checkSts.Checked == true)
        {
            ObjEntitySales.status = 1;
        }
        else
        {
            ObjEntitySales.status = 0;
        }
        if (HiddenCurrncyId.Value != "")
        {
            ObjEntitySales.DefaultCurrencyId = Convert.ToInt32(HiddenCurrncyId.Value);
        }
        if (HiddenExRateSts.Value == "1")
        {
            ObjEntitySales.Currencysts = 1;

            ObjEntitySales.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            ObjEntitySales.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Text);
        }
        else
        {
            ObjEntitySales.Currencysts = 0;

        }
        if (txtDesc.Value.Trim() != "")
        {
            ObjEntitySales.CancelReason = txtDesc.Value.Trim();
        }
        List<clsEntitySales> objEntitySalesCCList = new List<clsEntitySales>();
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

                clsEntitySales ObjEntity = new clsEntitySales();
                if (objclsWBData.PRDTID != "" && objclsWBData.QTY != "" && objclsWBData.RATE != "" && objclsWBData.PRICE != "")
                {
                    if (objclsWBData.SLNO != "")
                    {
                        ObjEntity.SLnO = Convert.ToInt32(objclsWBData.SLNO);
                    }
                    if (objclsWBData.PRDTID != "")
                    {
                        ObjEntity.product_id = Convert.ToInt32(objclsWBData.PRDTID);
                    }
                    if (objclsWBData.QTY != "")
                    {
                        ObjEntity.Quantity = Convert.ToDecimal(objclsWBData.QTY);
                    }
                    if (objclsWBData.RATE != "")
                    {
                        ObjEntity.Rate = Convert.ToDecimal(objclsWBData.RATE);
                    }
                    if (objclsWBData.DESCPRCNTG != "")
                    {
                        ObjEntity.DcntPrcntg = Convert.ToDecimal(objclsWBData.DESCPRCNTG);
                    }
                    if (objclsWBData.DECAMT != "")
                    {
                        ObjEntity.DcntAmt = Convert.ToDecimal(objclsWBData.DECAMT);
                    }
                    if (objclsWBData.TAXID != "")
                    {
                        ObjEntity.Tax_id = Convert.ToInt32(objclsWBData.TAXID);
                    }
                    if (objclsWBData.TAXAMT != "")
                    {
                        ObjEntity.TaxAmt = Convert.ToDecimal(objclsWBData.TAXAMT);
                    }
                    if (objclsWBData.PRICE != "")
                    {
                        ObjEntity.Price = Convert.ToDecimal(objclsWBData.PRICE);
                    }

                    if (Request.Form["txtRemark" + objclsWBData.SLNO] != "")
                    {
                        ObjEntity.Remark = Request.Form["txtRemark" + objclsWBData.SLNO];
                    }

                    //if (objclsWBData.REMARK != "")
                    //    ObjEntity.Remark = objclsWBData.REMARK;

                    ObjEntityProductList.Add(ObjEntity);
                    string CostCenterDtl = Request.Form["tdCostCenterDtls" + objclsWBData.XLOOP];
                    if (CostCenterDtl != "" && CostCenterDtl != ",")
                    {
                        string[] CostCenterDtlvalues = CostCenterDtl.Split('$');
                        for (int i = 0; i < CostCenterDtlvalues.Length; i++)
                        {
                            clsEntitySales objSubEntity = new clsEntitySales();

                            if (objclsWBData.SLNO != "")
                            {
                                objSubEntity.SLnO = Convert.ToInt32(objclsWBData.SLNO);
                            }
                            if (objclsWBData.PRDTID != "")
                            {
                                objSubEntity.product_id = Convert.ToInt32(objclsWBData.PRDTID);
                            }
                            string[] valSplit = CostCenterDtlvalues[i].Split('%');
                            objSubEntity.CC_Id = Convert.ToInt32(valSplit[0]);
                            valSplit[1] = valSplit[1].Replace(",", "");

                            objSubEntity.CC_Amount = Convert.ToDecimal(valSplit[1]);
                            if (valSplit[2] != "" && valSplit[2] != "0")
                            {
                                objSubEntity.CC_Grp1_Id = Convert.ToInt32(valSplit[2].Replace(",", ""));
                            }
                            if (valSplit[3] != "" && valSplit[3] != "0")
                            {
                                objSubEntity.CC_Grp2_Id = Convert.ToInt32(valSplit[3].Replace(",", ""));
                            }
                            objEntitySalesCCList.Add(objSubEntity);

                        }
                    }
                }
            }

        }
        List<clsEntitySales> objEntityAttchmntDeatilsList = new List<clsEntitySales>();


        if (cbxAddAttachment.Checked == true)
        {
            ObjEntitySales.AtchmntSts = 1;
            string jsonData1 = HiddenField4_FileUpload.Value;
            string c1 = jsonData1.Replace("\"{", "\\{");
            string d1 = c1.Replace("\\n", "\r\n");
            string g1 = d1.Replace("\\", "");
            string h1 = g1.Replace("}\"]", "}]");
            string i = h1.Replace("}\",", "},");

            List<clsAtchmntData> objTVDataList2 = new List<clsAtchmntData>();
            objTVDataList2 = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);


            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES_ATTACHMENT);
            objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
            objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
            //---evm 0044
            //--16/01/2020
            ObjEntitySales.Ref = txtRef.Text;

            if (HiddenField4_FileUpload.Value != "" && HiddenField4_FileUpload.Value != null)
            {


                for (int count = 0; count < objTVDataList2.Count; count++)
                {
                    string jsonFileid = "file" + objTVDataList2[count].ROWID;
                    for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                    {

                        string fileId = Request.Files.AllKeys[intCount].ToString();
                        HttpPostedFile PostedFile = Request.Files[intCount];
                        if (fileId == jsonFileid)
                        {
                            if (PostedFile.ContentLength > 0)
                            {
                                string strNextId = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);

                                clsEntitySales objEntityRnwlDetailsAttchmnt = new clsEntitySales();
                                string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                objEntityRnwlDetailsAttchmnt.ActualFileName = strFileName;
                                string strFileExt;

                                strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();


                                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SALES_ATTACHMENT);

                                string strImageName = "SALES_" + intImageSection.ToString() + "_" + strNextId + "." + strFileExt;
                                objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SALES_ATTACHMENT);

                                PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);

                                objEntityAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);



                            }
                        }
                    }
                }


            }

        }
        else
        {
            ObjEntitySales.AtchmntSts = 0;
        }

        // evm 0044
        string strCodeCount = objBusinessSales.CheckCodeDuplicatn(ObjEntitySales);
        //----------

        int AcntCloseSts = AccountCloseCheck(txtDateFrom.Value);
        int retFlg = 0;
        int AuditCloseSts = AuditCloseCheck(txtDateFrom.Value);
        if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
        {
            retFlg = 1;
            Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=AuditClosed");
        }
        else if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
        {

        }
        else if (AcntCloseSts == 1 && HiddenProvisionSts.Value != "1")
        {
            retFlg = 1;
            Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=AcntClosed");
        }
        //--evm 0044
        else if (strCodeCount != "0")
        {
            retFlg = 1;
            Response.Redirect("fms_Sales_Master.aspx?InsUpd=DUPE");
        }
        //-----

        try
        {

            if (retFlg == 0)
            {
                clsEntityCommon objentcommn = new clsEntityCommon();
                objentcommn.CorporateID = ObjEntitySales.Corporate_id;
                objentcommn.Organisation_Id = ObjEntitySales.Organisation_id;
                objentcommn.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES);
                string strNextId1 = objBusinessLayer.ReadNextNumber(objentcommn);


                objBusinessSales.InsertSalesDetls(ObjEntitySales, ObjEntityProductList, objEntityAttchmntDeatilsList, objEntitySalesCCList);  
            
            }
            if (clickedButton.ID == "btnAdd")
            {
                Response.Redirect("fms_Sales_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnAddClose")
            {
                Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=Ins");
            }
            if (clickedButton.ID == "btnFloatAdd")
            {
                Response.Redirect("fms_Sales_Master.aspx?InsUpd=Ins");
            }
            else if (clickedButton.ID == "btnFloatAddClose")
            {
                Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=Ins");
            }

        }
        catch (Exception ex)
        {
            if (ex.Message.StartsWith("Thread") == false)
            {
                Response.Redirect("fms_Sales_Master.aspx?InsUpd=ERROR");
            }
        }
    }

    public class clsAtchmntData
    {

        public string ROWID { get; set; }
        public string FILEPATH { get; set; }
        public string DESCRPTN { get; set; }
        public string EVTACTION { get; set; }
        public string DTLID { get; set; }

    }

    public class clsWBData
    {
        public string SLNO { get; set; }
        public string PRDTID { get; set; }
        public string QTY { get; set; }
        public string RATE { get; set; }
        public string DESCPRCNTG { get; set; }
        public string DECAMT { get; set; }
        public string TAXID  { get; set; }
        public string TAXAMT{ get; set; }
        public string PRICE  { get; set; }
        public string EVENT { get; set; }
        public string DTLIT { get; set; }
        public string REMARK { get; set; }
        public string XLOOP { get; set; }
        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        clsEntitySales ObjEntitySales = new clsEntitySales();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        List<clsEntitySales> ObjEntityProductList = new List<clsEntitySales>();
        List<clsEntitySales> ObjEntityProductList_Update = new List<clsEntitySales>();
        List<clsEntitySales> ObjEntityProductList_Delete = new List<clsEntitySales>();
        List<clsEntitySales> ObjEntityAttachmentList_Delete = new List<clsEntitySales>();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySales.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySales.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
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
        if (Session["FINCYRID"] != "" && Session["FINCYRID"] != null)
            ObjEntitySales.FinancialYrId = Convert.ToInt32(Session["FINCYRID"]);
         
        ObjEntitySales.SalesId = Convert.ToInt32(HiddensaleId.Value);
        DataTable dtCancel = objBusinessSales.SaleCancelChk(ObjEntitySales);
        if (dtCancel.Rows.Count > 0)
        {
            if (Convert.ToInt32(dtCancel.Rows[0][0].ToString()) > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "AlreadyCancelMsg", "AlreadyCancelMsg();", true);
            }
        }
        else
        { 
        ObjEntitySales.Ref = txtRef.Text;
        if (txtDateFrom.Value != "")
        {
            ObjEntitySales.Date = objCommon.textToDateTime(txtDateFrom.Value);
        }
        if (HiddenUpdatedDate.Value != "")
        {
            ObjEntitySales.UpdSaleDate = objCommon.textToDateTime(HiddenUpdatedDate.Value);
        }
        ObjEntitySales.RefNextNumbr = Convert.ToInt32(Hiddenref_NextNumber.Value);
             
        if (txtOrder.Text != "")
        {
            ObjEntitySales.OrderNo = txtOrder.Text.Trim();
        }
        if (HiddenGrossAmt.Value!= "")
        {
            ObjEntitySales.GrossTotal = Convert.ToDecimal(HiddenGrossAmt.Value);
        }
        if (HiddenTax.Value != "")
        {
            ObjEntitySales.TotalTax = Convert.ToDecimal(HiddenTax.Value);
        }
        if (Hiddendiscount.Value != "")
        {
            ObjEntitySales.TotalDiscount = Convert.ToDecimal(Hiddendiscount.Value);
        }

        //---evm 0044
        if (txtcrdtPeriod.Text != "" && txtcrdtPeriod.Text != null)
        {
            ObjEntitySales.CreditPeriod = Convert.ToInt32(txtcrdtPeriod.Text);
        }
        else
        {
            ObjEntitySales.CreditPeriod = 0;
        }
        //-----------

        if (HiddenCurrncyId.Value != ddlCurrency.SelectedItem.Value)
        {
            ObjEntitySales.TotalExchangeRate = Convert.ToDecimal(HiddenNetAmt.Value);
            decimal exchangRt = Convert.ToDecimal(txtExchangeRate.Text);
            decimal Amt = Convert.ToDecimal(HiddenNetAmt.Value);
            ObjEntitySales.NetTotal = Amt * exchangRt;
            ObjEntitySales.BalencAmtl = Amt * exchangRt;
        }
        else
        {
            ObjEntitySales.NetTotal = Convert.ToDecimal(HiddenNetAmt.Value);
            ObjEntitySales.BalencAmtl = Convert.ToDecimal(HiddenNetAmt.Value);

        }
        if (checkSts.Checked == true)
        {
            ObjEntitySales.status = 1;
        }
        else
        {
            ObjEntitySales.status = 0;
        }

        if (HiddenCurrncyId.Value != "")
        {
            ObjEntitySales.DefaultCurrencyId = Convert.ToInt32(HiddenCurrncyId.Value);
        }
        if (HiddenExRateSts.Value == "1")
        {
            ObjEntitySales.Currencysts = 1;

            ObjEntitySales.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedItem.Value);
            ObjEntitySales.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Text);
        }
        else
        {
            ObjEntitySales.Currencysts = 0;

        }

        if (txtDesc.Value.Trim() != "")
        {
            ObjEntitySales.CancelReason = txtDesc.Value.Trim();
        }


        if (cbxExtngSplr.Checked == true)
        {
            ObjEntitySales.ExistingSplrsts = 0;
            if (Hiddencustldgr.Value != "" && Hiddencustldgr.Value != "--SELECT CUSTOMER--")
            {
                ObjEntitySales.LedgerId = Convert.ToInt32(Hiddencustldgr.Value);
            }
        }
        else
        {
            ObjEntitySales.LedgerId = Convert.ToInt32(HiddenDfltLdgr.Value);
            if (ddlLedger.SelectedItem.Value != "")
            {
                ObjEntitySales.LedgerId = Convert.ToInt32(ddlLedger.SelectedItem.Value);
            }
            else
            {
                ObjEntitySales.LedgerId = Convert.ToInt32(HiddenDfltLdgr.Value);
            }
            ObjEntitySales.ExistingSplrsts = 1;
            if (txtsplrName.Text.Trim() != "")
            {
                ObjEntitySales.CustName = txtsplrName.Text;
            }
            if (txtAddress1.Text.Trim() != "")
            {
                ObjEntitySales.AddressOne = txtAddress1.Text;
            }
            if (txtAddress2.Text.Trim() != "")
            {
                ObjEntitySales.AddressTwo = txtAddress2.Text;
            }
            if (txtAddress3.Text.Trim() != "")
            {
                ObjEntitySales.AddressThree = txtAddress3.Text;
            }
        }

        //43
        if (txtGuestName.Text.Trim() != "")
        {
            ObjEntitySales.GuestName = txtGuestName.Text;
        }
        //end

        List<clsEntitySales> objEntitySalesCCList = new List<clsEntitySales>();

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

                clsEntitySales ObjEntity = new clsEntitySales();
                if (objclsWBData.EVENT == "INS")
                {
                    if (objclsWBData.SLNO != "")
                    {
                        ObjEntity.SLnO = Convert.ToInt32(objclsWBData.SLNO);
                    }
                    if (objclsWBData.PRDTID != "")
                    {
                        ObjEntity.product_id = Convert.ToInt32(objclsWBData.PRDTID);
                    }
                    if (objclsWBData.QTY != "")
                    {
                        ObjEntity.Quantity = Convert.ToDecimal(objclsWBData.QTY);
                    }
                    if (objclsWBData.RATE != "")
                    {
                        ObjEntity.Rate = Convert.ToDecimal(objclsWBData.RATE);
                    }
                    if (objclsWBData.DESCPRCNTG != "")
                    {
                        ObjEntity.DcntPrcntg = Convert.ToDecimal(objclsWBData.DESCPRCNTG);
                    }
                    if (objclsWBData.DECAMT != "")
                    {
                        ObjEntity.DcntAmt = Convert.ToDecimal(objclsWBData.DECAMT);
                    }
                    if (objclsWBData.TAXID != "null" && objclsWBData.TAXID != "")
                    {
                        ObjEntity.Tax_id = Convert.ToInt32(objclsWBData.TAXID);
                    }
                    if (objclsWBData.TAXAMT != "")
                    {
                        ObjEntity.TaxAmt = Convert.ToDecimal(objclsWBData.TAXAMT);
                    }
                    if (objclsWBData.PRICE != "")
                    {
                        ObjEntity.Price = Convert.ToDecimal(objclsWBData.PRICE);
                    }
                    ObjEntityProductList.Add(ObjEntity);

                }
                if (objclsWBData.EVENT == "UPD")
                {

                    if (objclsWBData.SLNO != "")
                    {
                        ObjEntity.SLnO = Convert.ToInt32(objclsWBData.SLNO);
                    }
                    if (objclsWBData.PRDTID != "")
                    {
                        ObjEntity.product_id = Convert.ToInt32(objclsWBData.PRDTID);
                    }
                    if (objclsWBData.QTY != "")
                    {
                        ObjEntity.Quantity = Convert.ToDecimal(objclsWBData.QTY);
                    }
                    if (objclsWBData.RATE != "")
                    {
                        ObjEntity.Rate = Convert.ToDecimal(objclsWBData.RATE);
                    }
                    if (objclsWBData.DESCPRCNTG != "")
                    {
                        ObjEntity.DcntPrcntg = Convert.ToDecimal(objclsWBData.DESCPRCNTG);
                    }
                    if (objclsWBData.DECAMT != "")
                    {
                        ObjEntity.DcntAmt = Convert.ToDecimal(objclsWBData.DECAMT);
                    }
                    if (objclsWBData.TAXID != "null" && objclsWBData.TAXID != "")
                    {
                        ObjEntity.Tax_id = Convert.ToInt32(objclsWBData.TAXID);
                    }
                    if (objclsWBData.TAXAMT != "")
                    {
                        ObjEntity.TaxAmt = Convert.ToDecimal(objclsWBData.TAXAMT);
                    }
                    if (objclsWBData.PRICE != "")
                    {
                        ObjEntity.Price = Convert.ToDecimal(objclsWBData.PRICE);
                    }
                    ObjEntity.SalesProductId = Convert.ToInt32(objclsWBData.DTLIT);
                    if (Request.Form["txtRemark" + objclsWBData.SLNO] != "")
                    {
                        ObjEntity.Remark = Request.Form["txtRemark" + objclsWBData.SLNO];
                    }

                    //if (objclsWBData.REMARK != "")
                    //    ObjEntity.Remark = objclsWBData.REMARK;

                    ObjEntityProductList_Update.Add(ObjEntity);

                }
                string CostCenterDtl = Request.Form["tdCostCenterDtls" + objclsWBData.XLOOP];
                if (CostCenterDtl != "" && CostCenterDtl != ",")
                {
                    string[] CostCenterDtlvalues = CostCenterDtl.Split('$');
                    for (int i = 0; i < CostCenterDtlvalues.Length; i++)
                    {
                        clsEntitySales objSubEntity = new clsEntitySales();

                        if (objclsWBData.SLNO != "")
                        {
                            objSubEntity.SLnO = Convert.ToInt32(objclsWBData.SLNO);
                        }
                        if (objclsWBData.PRDTID != "")
                        {
                            objSubEntity.product_id = Convert.ToInt32(objclsWBData.PRDTID);
                        }
                        string[] valSplit = CostCenterDtlvalues[i].Split('%');
                        objSubEntity.CC_Id = Convert.ToInt32(valSplit[0]);
                        valSplit[1] = valSplit[1].Replace(",", "");

                        objSubEntity.CC_Amount = Convert.ToDecimal(valSplit[1]);
                        if (valSplit[2] != "" && valSplit[2] != null)
                        {
                            objSubEntity.CC_Grp1_Id = Convert.ToInt32(valSplit[2].Replace(",", ""));
                        }
                        if (valSplit[3] != "" && valSplit[3] != null)
                        {
                            objSubEntity.CC_Grp2_Id = Convert.ToInt32(valSplit[3].Replace(",", ""));
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
                    clsEntitySales objEntityDetailsDelete = new clsEntitySales();
                    objEntityDetailsDelete.SalesProductId = Convert.ToInt32(strDtlId);
                    ObjEntityProductList_Delete.Add(objEntityDetailsDelete);

                }
            }


        }
        List<clsEntitySales> objEntityAttchmntDeatilsList = new List<clsEntitySales>();
        if (cbxAddAttachment.Checked == true)
        {
            ObjEntitySales.AtchmntSts = 1;

            clsEntityCommon objEntityCommon = new clsEntityCommon();
            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES_ATTACHMENT);
            objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
            objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;

            string jsonData1 = HiddenField4_FileUpload.Value;
            string c1 = jsonData1.Replace("\"{", "\\{");
            string d1 = c1.Replace("\\n", "\r\n");
            string g1 = d1.Replace("\\", "");
            string h1 = g1.Replace("}\"]", "}]");
            string i = h1.Replace("}\",", "},");

            List<clsAtchmntData> objTVDataList2 = new List<clsAtchmntData>();
            objTVDataList2 = JsonConvert.DeserializeObject<List<clsAtchmntData>>(i);


            if (HiddenField4_FileUpload.Value != "" && HiddenField4_FileUpload.Value != null)
            {


                for (int count = 0; count < objTVDataList2.Count; count++)
                {
                    string jsonFileid = "file" + objTVDataList2[count].ROWID;
                    for (int intCount = 0; intCount < Request.Files.Count; intCount++)
                    {

                        string fileId = Request.Files.AllKeys[intCount].ToString();
                        HttpPostedFile PostedFile = Request.Files[intCount];
                        if (fileId == jsonFileid)
                        {
                            if (PostedFile.ContentLength > 0)
                            {

                                string strNextId = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);



                                clsEntitySales objEntityRnwlDetailsAttchmnt = new clsEntitySales();
                                string strFileName = System.IO.Path.GetFileName(PostedFile.FileName);
                                objEntityRnwlDetailsAttchmnt.ActualFileName = strFileName;
                                string strFileExt;

                                strFileExt = strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower();


                                int intImageSection = Convert.ToInt32(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SALES_ATTACHMENT);

                                string strImageName = "SALES_" + intImageSection.ToString() + "_" + strNextId + "." + strFileExt;
                                objEntityRnwlDetailsAttchmnt.FileName = strImageName;
                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.SALES_ATTACHMENT);

                                PostedFile.SaveAs(Server.MapPath(strImagePath) + objEntityRnwlDetailsAttchmnt.FileName);

                                if (objTVDataList2[count].DTLID != "")
                                {
                                    objEntityRnwlDetailsAttchmnt.AtchmntId = Convert.ToInt32(objTVDataList2[count].DTLID);
                                }


                                objEntityAttchmntDeatilsList.Add(objEntityRnwlDetailsAttchmnt);


                            }
                        }
                    }
                }
            }

            string strCanclDtlId1 = "";
            string[] strarrCancldtlIds1 = strCanclDtlId1.Split(',');
            if (hiddenVhclFileCanclDtlId.Value != "" && hiddenVhclFileCanclDtlId.Value != null)
            {
                strCanclDtlId1 = hiddenVhclFileCanclDtlId.Value;
                strarrCancldtlIds1 = strCanclDtlId1.Split(',');

            }
            //Cancel the rows that have been cancelled when editing in Detail table
            foreach (string strDtlId in strarrCancldtlIds1)
            {
                if (strDtlId != "" && strDtlId != null)
                {
                    int intDtlId = Convert.ToInt32(strDtlId);
                    clsEntitySales objEntityDetailsDelete = new clsEntitySales();
                    objEntityDetailsDelete.AtchmntId = Convert.ToInt32(strDtlId);
                    ObjEntityAttachmentList_Delete.Add(objEntityDetailsDelete);

                }
            }

        }

        else
        {
            ObjEntitySales.AtchmntSts = 0;
        }

        // evm 0044
        string strCodeCount = objBusinessSales.CheckCodeDuplicatn(ObjEntitySales);
        //----------

        DataTable dt = objBusinessSales.ReadSalesDetailsById(ObjEntitySales);
        if (dt.Rows.Count > 0)
        {

            int AcntCloseSts = AccountCloseCheck(txtDateFrom.Value);
            int retFlg = 0;
            int AuditCloseSts = AuditCloseCheck(txtDateFrom.Value);
            if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
            {
                retFlg = 1;
                Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=AuditClosed");
            }
            else if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
            {

            }
            else if (AcntCloseSts == 1 && HiddenProvisionSts.Value != "1")
            {
                retFlg = 1;
                Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=AcntClosed");
            }
            //---evm 0044
            else if (strCodeCount != "0")
            {
                Response.Redirect("fms_Sales_Master.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=DUPE");
            }

            if (clickedButton.ID == "btnConfirm1")
            {
                ObjEntitySales.Status = 1;
                if (checkSts.Checked == true)
                {
                    DataTable dtSlsDtls = objBusinessSales.ReadSalesDetailsById(ObjEntitySales);
                    string sts = dtSlsDtls.Rows[0]["SALES_CNFRM_STS"].ToString();
                    if (sts != "0")
                    {
                        retFlg = 1;
                        Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=CNFMERROR");
                    }
                }
                else
                {
                    retFlg = 1;
                    Response.Redirect("fms_Sales_Master.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=StsErr");
                }
            }

            try
            {
                if (dt.Rows[0]["SALES_ID"].ToString() != "" && retFlg == 0)
                {
                    objBusinessSales.UpdateSalesDetls(ObjEntitySales, ObjEntityProductList, ObjEntityProductList_Update, ObjEntityProductList_Delete, objEntityAttchmntDeatilsList, ObjEntityAttachmentList_Delete, objEntitySalesCCList);

            
                    if (clickedButton.ID == "btnUpdate")
                    {
                        Response.Redirect("fms_Sales_Master.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnUpdateClose")
                    {
                        Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=Upd");
                    }
                    if (clickedButton.ID == "btnFloatUpdate")
                    {
                        Response.Redirect("fms_Sales_Master.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnFloatUpdateClose")
                    {
                        Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=Upd");
                    }
                    else if (clickedButton.ID == "btnConfirm1")
                    {
                        Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=CNFM");
                    }
                }

                //if (clickedButton.ID == "btnConfirm1")
                //{
                //    if (checkSts.Checked == true)
                //    {
                //        DataTable dtSlsDtls = objBusinessSales.ReadSalesDetailsById(ObjEntitySales);
                //        string sts = dtSlsDtls.Rows[0]["SALES_CNFRM_STS"].ToString();
                //        if (sts == "0")
                //        {
                //            objBusinessSales.UpdateSalesDetls(ObjEntitySales, ObjEntityProductList, ObjEntityProductList_Update, ObjEntityProductList_Delete, objEntityAttchmntDeatilsList, ObjEntityAttachmentList_Delete, objEntitySalesCCList);

                //            //objBusinessSales.ConfmSaleDetlById(ObjEntitySales, ObjEntityProductList, ObjEntityProductList_Update);

                //            Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=CNFM");
                //        }
                //        else
                //        {
                //            Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=CNFMERROR");
                //        }
                //    }
                //    else
                //    {
                //        Response.Redirect("fms_Sales_Master.aspx?Id=" + Request.QueryString["Id"] + "&InsUpd=StsErr");
                //    }

                //}
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Thread") == false)
                {
                    Response.Redirect("fms_Sales_Master.aspx?InsUpd=ERROR");
                }
            }

        }
       
    }

    }

    [WebMethod]
    public static string PrintPDF(string saleId, string orgID, string corptID, string UsrName)
    {

        //string strRandomMixedId = saleId;
        //string strLenghtofId = strRandomMixedId.Substring(0, 2);
        //int intLenghtofId = Convert.ToInt16(strLenghtofId);
        //string strId = strRandomMixedId.Substring(2, intLenghtofId);

        string strId = saleId;

        clsBusinessSales objBusinessSales = new clsBusinessSales();
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsEntitySales ObjEntitySales = new clsEntitySales();
        if (corptID != null)
        {
            ObjEntitySales.Corporate_id = Convert.ToInt32(corptID);
        }
        if (orgID != null)
        {
            ObjEntitySales.Organisation_id = Convert.ToInt32(orgID);
        }
        ObjEntitySales.SalesId = Convert.ToInt32(strId);
        string PreparedBy = "";
        if (UsrName != null)
        {
            PreparedBy = UsrName;
        }


        DataTable dt = objBusinessSales.ReadSalesDetailsById(ObjEntitySales);
        DataTable dtProduct = objBusinessSales.ReadProductSalesById(ObjEntitySales);
        ObjEntitySales.LedgerId = Convert.ToInt32(dt.Rows[0]["CSTMR_ID"].ToString());
        DataTable dtCust = new DataTable();
        if (Convert.ToInt32(dt.Rows[0]["SALES_CUST_TYP"].ToString()) == 0)
        {
            dtCust = objBusinessSales.ReadCustomerDtls(ObjEntitySales);
            if (dtCust.Rows.Count == 0)
            {
                //dtCust.Columns.Add("CSTMR_NAME", typeof(string));
                //dtCust.Columns.Add("CSTMR_ADDRESS1", typeof(string));
                //dtCust.Columns.Add("CSTMR_ADDRESS2", typeof(string));
                //dtCust.Columns.Add("CSTMR_ADDRESS3", typeof(string));
                //dtCust.Columns.Add("CSTMR_EMAIL", typeof(string));
                DataRow drDtl = dtCust.NewRow();

                drDtl["CSTMR_NAME"] = dt.Rows[0]["LDGR_COMTN_NAME"].ToString();

                drDtl["CSTMR_ADDRESS1"] = dt.Rows[0]["LDGR_ADDRESS"].ToString();
                drDtl["CSTMR_ADDRESS2"] = "";

                drDtl["CSTMR_ADDRESS3"] = "";
                drDtl["CSTMR_EMAIL"] = "";
                dtCust.Rows.Add(drDtl);


            }


        }
        else
        {
            dtCust.Columns.Add("CSTMR_NAME", typeof(string));
            dtCust.Columns.Add("CSTMR_ADDRESS1", typeof(string));
            dtCust.Columns.Add("CSTMR_ADDRESS2", typeof(string));
            dtCust.Columns.Add("CSTMR_ADDRESS3", typeof(string));
            dtCust.Columns.Add("CSTMR_EMAIL", typeof(string));
            DataRow drDtl = dtCust.NewRow();

            drDtl["CSTMR_NAME"] = dt.Rows[0]["SALES_CUST_NAME"].ToString();

            drDtl["CSTMR_ADDRESS1"] = dt.Rows[0]["SALES_CUST_ADDRS_ONE"].ToString();
            drDtl["CSTMR_ADDRESS2"] = dt.Rows[0]["SALES_CUST_ADDRS_TWO"].ToString();

            drDtl["CSTMR_ADDRESS3"] = dt.Rows[0]["SALES_CUST_ADDRS_THREE"].ToString();
            drDtl["CSTMR_EMAIL"] = "";
            dtCust.Rows.Add(drDtl);



        }
        DataTable dtCorp = objBusinessSales.ReadCorpDtls(ObjEntitySales);

        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

        objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
        objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.SALE);

        DataTable dtVersion = objBusinessLayer.ReadPrintVersion(objEntityCommon);

        string strReturn = "";

        if (dtVersion.Rows.Count > 0)
        {
            int Version_flg = Convert.ToInt32(dtVersion.Rows[0][0].ToString());

            if (dtVersion.Rows[0][0].ToString() == "1")
            {
                strReturn = objBusinessSales.PdfPrintVersion1(strId, dt, dtProduct, dtCust, dtCorp, ObjEntitySales, PreparedBy, Version_flg);
            }
            else if (dtVersion.Rows[0][0].ToString() == "2")
            {
                strReturn = objBusinessSales.PdfPrintVersion2(strId, dt, dtProduct, dtCust, dtCorp, ObjEntitySales, PreparedBy, Version_flg);
            }
            else if (dtVersion.Rows[0][0].ToString() == "3")
            {
                strReturn = objBusinessSales.PdfPrintVersion2(strId, dt, dtProduct, dtCust, dtCorp, ObjEntitySales, PreparedBy, Version_flg);
            }
        }
        return strReturn;


    }

   
    //protected void btnPRint_Click(object sender, EventArgs e)
    //{
    //    if (Request.QueryString["ViewId"] != null || Request.QueryString["Id"] != null)
    //    {
    //        string strRandomMixedId = "";
    //        if (Request.QueryString["ViewId"] != null)
    //        {
    //            strRandomMixedId = Request.QueryString["ViewId"].ToString();
    //        }
    //        else
    //        {
    //            strRandomMixedId = Request.QueryString["Id"].ToString();
    //        }
    //        string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //        int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //        string strId = strRandomMixedId.Substring(2, intLenghtofId);

    //        clsCommonLibrary objCommn = new clsCommonLibrary();
    //        clsEntitySales ObjEntitySales = new clsEntitySales();

    //        if (Session["CORPOFFICEID"] != null)
    //        {
    //            ObjEntitySales.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
    //        }
    //        else if (Session["CORPOFFICEID"] == null)
    //        {
    //            Response.Redirect("~/Default.aspx");
    //        }
    //        if (Session["ORGID"] != null)
    //        {
    //            ObjEntitySales.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
    //        }
    //        else if (Session["ORGID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }
    //        if (Session["USERID"] != null)
    //        {
    //            //intUserId = Convert.ToInt32(Session["USERID"]);
    //            ObjEntitySales.User_Id = Convert.ToInt32(Session["USERID"]);
    //        }
    //        else if (Session["USERID"] == null)
    //        {
    //            Response.Redirect("/Default.aspx");
    //        }

    //        ObjEntitySales.SalesId = Convert.ToInt32(strId);

    //        DataTable dt = objBusinessSales.ReadSalesDetailsById(ObjEntitySales);
    //        DataTable dtProduct = objBusinessSales.ReadProductSalesById(ObjEntitySales);

    //        if (cbxExtngSplr.Checked == true)
    //        {
    //            if (ddlCustomerLdgr.SelectedItem.Value != "--SELECT SUPPLIER --")
    //            {
    //                ObjEntitySales.LedgerId = Convert.ToInt32(ddlCustomerLdgr.SelectedItem.Value);
    //            }
    //        }
    //        else
    //        {


    //            ObjEntitySales.LedgerId = Convert.ToInt32(HiddenDfltLdgr.Value);
    //        }

    //        DataTable dtCust = new DataTable();
    //        if (Convert.ToInt32(dt.Rows[0]["SALES_CUST_TYP"].ToString()) == 0)
    //        {
    //            dtCust = objBusinessSales.ReadCustomerDtls(ObjEntitySales);
    //            if (dtCust.Rows.Count == 0)
    //            {
    //                //dtCust.Columns.Add("CSTMR_NAME", typeof(string));
    //                //dtCust.Columns.Add("CSTMR_ADDRESS1", typeof(string));
    //                //dtCust.Columns.Add("CSTMR_ADDRESS2", typeof(string));
    //                //dtCust.Columns.Add("CSTMR_ADDRESS3", typeof(string));
    //                //dtCust.Columns.Add("CSTMR_EMAIL", typeof(string));
    //                DataRow drDtl = dtCust.NewRow();

    //                drDtl["CSTMR_NAME"] = dt.Rows[0]["LDGR_COMTN_NAME"].ToString();

    //                drDtl["CSTMR_ADDRESS1"] = dt.Rows[0]["LDGR_ADDRESS"].ToString();
    //                drDtl["CSTMR_ADDRESS2"] ="";

    //                drDtl["CSTMR_ADDRESS3"] = "";
    //                drDtl["CSTMR_EMAIL"] = "";
    //                dtCust.Rows.Add(drDtl);


    //            }


    //        }
    //        else
    //        {
    //            dtCust.Columns.Add("CSTMR_NAME", typeof(string));
    //            dtCust.Columns.Add("CSTMR_ADDRESS1", typeof(string));
    //            dtCust.Columns.Add("CSTMR_ADDRESS2", typeof(string));
    //            dtCust.Columns.Add("CSTMR_ADDRESS3", typeof(string));
    //            dtCust.Columns.Add("CSTMR_EMAIL", typeof(string));
    //            DataRow drDtl = dtCust.NewRow();

    //            drDtl["CSTMR_NAME"] = dt.Rows[0]["SALES_CUST_NAME"].ToString();

    //            drDtl["CSTMR_ADDRESS1"] = dt.Rows[0]["SALES_CUST_ADDRS_ONE"].ToString();
    //            drDtl["CSTMR_ADDRESS2"] = dt.Rows[0]["SALES_CUST_ADDRS_TWO"].ToString();

    //            drDtl["CSTMR_ADDRESS3"] = dt.Rows[0]["SALES_CUST_ADDRS_THREE"].ToString();
    //            drDtl["CSTMR_EMAIL"] = "";
    //            dtCust.Rows.Add(drDtl);



    //        }
    //        string PreparedBy = "";

    //        if (Session["USERFULLNAME"] != null)
    //        {
    //            PreparedBy = Session["USERFULLNAME"].ToString();
    //        }
    //        DataTable dtCorp = objBusinessSales.ReadCorpDtls(ObjEntitySales);

    //        clsEntityCommon objEntityCommon = new clsEntityCommon();
    //        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();

    //        objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
    //        objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
    //        objEntityCommon.Vouchar_Type = Convert.ToInt32(clsCommonLibrary.VOUCHER_TYPE.SALE);

    //        DataTable dtVersion = objBusinessLayer.ReadPrintVersion(objEntityCommon);

    //        string strReturn = "";

    //        if (dtVersion.Rows.Count > 0)
    //        {
    //            int Version_flg = Convert.ToInt32(dtVersion.Rows[0][0].ToString());

    //            if (dtVersion.Rows[0][0].ToString() == "1")
    //            {
    //                //strReturn = objBusinessSales.PdfPrintVersion1(dt, dtProduct, dtCust, dtCorp, ObjEntitySales, PreparedBy, Version_flg);
    //            }
    //            else if (dtVersion.Rows[0][0].ToString() == "2")
    //            {
    //                //strReturn = objBusinessSales.PdfPrintVersion2(dt, dtProduct, dtCust, dtCorp, ObjEntitySales, PreparedBy, Version_flg);
    //            }
    //            else if (dtVersion.Rows[0][0].ToString() == "3")
    //            {
    //                //strReturn = objBusinessSales.PdfPrintVersion2(dt, dtProduct, dtCust, dtCorp, ObjEntitySales, PreparedBy, Version_flg);
    //            }

    //            if (strReturn != "")
    //            {
    //                Response.Write("<script>window.open('" + strReturn + "','_blank');</script>");  
    //            }


    //        }
    //        else
    //        {
    //            ScriptManager.RegisterStartupScript(this, GetType(), "PrintVersnError", "PrintVersnError();", true);
    //        }
    //    }
    //}


    //public string PdfPrintVersion1(DataTable dt, DataTable dtProduct, DataTable dtCust, DataTable dtCorp, clsEntitySales ObjEntitySales, string PreparedBy,int Version_flg)
    //{

    //    string strRet = "true";

    //    string strId = "";
    //    if (Request.QueryString["ViewId"] != null)
    //    {
    //        string strRandomMixedId = Request.QueryString["ViewId"].ToString();
    //        string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //        int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //        strId = strRandomMixedId.Substring(2, intLenghtofId);
    //    }


    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);


    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    if (ObjEntitySales.Corporate_id != 0)
    //    {
    //        objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
    //    }
    //    if (ObjEntitySales.Organisation_id != 0)
    //    {
    //        objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
    //    }

    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES_PRINT);
    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Sale_Invoice" + strId + "_" + strNextNumber + ".pdf";


    //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {

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

    //            PdfPTable headImg = new PdfPTable(2);

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

    //            if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
    //                headImg.AddCell(new PdfPCell(new Phrase("SALES INVOICE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });
    //            else
    //                headImg.AddCell(new PdfPCell(new Phrase("PROFORMA INVOICE", FontFactory.GetFont("Arial", 16, Font.BOLD, FontBlueGrey))) { Rowspan = 2, Border = 0, PaddingTop = 20, HorizontalAlignment = Element.ALIGN_RIGHT });



    //            float[] headersHeading = { 70, 30 };
    //            headImg.SetWidths(headersHeading);
    //            headImg.WidthPercentage = 100;

    //            document.Add(headImg);



    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;



    //            footrtable.AddCell(new PdfPCell(new Phrase("From", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            footrtable.AddCell(new PdfPCell(new Phrase("For", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            if (dtCust.Rows.Count > 0)
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            }
    //            if (dtCust.Rows.Count > 0)
    //            {
    //                if (dtCust.Rows[0][4].ToString().Trim() != "")
    //                {
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                }

    //                else
    //                {
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                }
    //            }
    //            else
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            }
    //            document.Add(footrtable);



    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            PdfPTable footrtables = new PdfPTable(2);
    //            float[] footrsBodys = { 15, 85 };
    //            footrtables.SetWidths(footrsBodys);
    //            footrtables.WidthPercentage = 100;




    //            footrtables.AddCell(new PdfPCell(new Phrase("Order No.", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_ORDERNO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase("Sales Ref #", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            document.Add(footrtables);



    //            var FontGrey = new BaseColor(134, 152, 160);
    //            var FontBordrGrey = new BaseColor(236, 236, 236);


    //            if (dtProduct.Rows.Count > 0)
    //            {

    //                string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "";
    //                string strcurrenWord = "", strCrncyAbbrv = "";

    //                if (dt.Rows[0]["CRNCY_STS"].ToString() == "1")
    //                {
    //                    strCrncyAbbrv = dt.Rows[0]["CRNCMST_ABBRV"].ToString();

    //                    if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
    //                    {

    //                        grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);


    //                        grossTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
    //                    {


    //                        taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);

    //                        taxTotal = strNetAmountDebitComma;

    //                    }
    //                    if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
    //                    {



    //                        discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);

    //                        discTotal = strNetAmountDebitComma;

    //                    }
    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {

    //                        netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);

    //                        netTotal = strNetAmountDebitComma;

    //                    }
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());

    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                        strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
    //                    }
    //                }
    //                else
    //                {
    //                    strCrncyAbbrv = dt.Rows[0]["DEFULT_ABRVTN"].ToString();

    //                    if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
    //                    {
    //                        grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);

    //                        grossTotal = strNetAmountDebitComma;



    //                    }
    //                    if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
    //                    {
    //                        taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);

    //                        taxTotal = strNetAmountDebitComma;

    //                    }
    //                    if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
    //                    {
    //                        discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
    //                        discTotal = strNetAmountDebitComma;


    //                    }
    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
    //                        netTotal = strNetAmountDebitComma;

    //                    }
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["DEFULT_CRNCMST_ID"].ToString());

    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                        strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
    //                    }
    //                }



    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                var FontRed = new BaseColor(202, 3, 20);
    //                var FontGreen = new BaseColor(46, 179, 51);
    //                var FontGray = new BaseColor(138, 138, 138);


    //                if (TaxEnable == 1)
    //                {


    //                    PdfPTable table2 = new PdfPTable(6);
    //                    float[] tableBody2 = { 34, 10, 14, 12, 15, 15 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    // table2.AddCell(new PdfPCell(new Phrase("DISCOUNT %", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    //table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontGray });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {
    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";
    //                        string ProductTaxAmt = "";
    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString() != "")
    //                        {
    //                            ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
    //                            ProductTaxAmt = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }


    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        //  table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        //table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["TAX_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6 });
    //                    //  table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    table2.AddCell(new PdfPCell(new Phrase("Gross Total  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    table2.AddCell(new PdfPCell(new Phrase("Tax Amount   ", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontRed))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontRed))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
    //                    table2.AddCell(new PdfPCell(new Phrase("Discount   ", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, FontGreen))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, });
    //                    table2.AddCell(new PdfPCell(new Phrase("Net Total   ", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                    //table2.AddCell(new PdfPCell(new Phrase("Net Total (In words)", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
    //                    //table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });



    //                    //table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontBlue });



    //                    document.Add(table2);

    //                }
    //                else
    //                {
    //                    PdfPTable table2 = new PdfPTable(5);
    //                    float[] tableBody2 = { 38, 12, 12, 16, 22 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
    //                    // table2.AddCell(new PdfPCell(new Phrase("DISCOUNT %", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontGrey, BorderColor = FontBordrGrey });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {

    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";

    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }

    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        //       table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontBordrGrey });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 5 });
    //                    //  table2.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
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


    //            if (dt.Rows[0]["SALES_DESC"].ToString().Trim() != "")
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk("Remarks", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                document.Add(new Paragraph(new Chunk(dt.Rows[0]["SALES_DESC"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //            }


    //            string CheckedBy = "";
    //            if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
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

    //public string PdfPrintVersion2(DataTable dt, DataTable dtProduct, DataTable dtCust, DataTable dtCorp, clsEntitySales ObjEntitySales, string PreparedBy,int Version_flg)
    //{
    //    string strRet = "true";

    //    string strId = "";
    //    if (Request.QueryString["ViewId"] != null)
    //    {
    //        string strRandomMixedId = Request.QueryString["ViewId"].ToString();
    //        string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //        int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //        strId = strRandomMixedId.Substring(2, intLenghtofId);
    //    }
    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    if (ObjEntitySales.Corporate_id != 0)
    //    {
    //        objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
    //    }
    //    if (ObjEntitySales.Organisation_id != 0)
    //    {
    //        objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
    //    }

    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES_PRINT);
    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Sale_Invoice" + strId + "_" + strNextNumber + ".pdf";

    //    DataTable dtBankDtls = objBusinessLayer.ReadBankDetails(objEntityCommon);


    //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {

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



    //                float[] headersHeading = { 70, 30 };
    //                headImg.SetWidths(headersHeading);
    //                headImg.WidthPercentage = 100;

    //                document.Add(headImg);



    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            }
    //            else
    //            {
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            }

    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;

    //            if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
    //                footrtable.AddCell(new PdfPCell(new Phrase("SALES INVOICE", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 15 });
    //            else
    //                footrtable.AddCell(new PdfPCell(new Phrase("PROFORMA INVOICE", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 15 });

    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["SALES_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            footrtable.AddCell(new PdfPCell(new Phrase("To", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 20 });

    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            if (dtCust.Rows.Count > 0)
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            }
    //            if (dtCust.Rows.Count > 0)
    //            {
    //                if (dtCust.Rows[0][4].ToString().Trim() != "")
    //                {
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                }

    //                else
    //                {
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                }
    //            }
    //            else
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            }
    //            document.Add(footrtable);



    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            //PdfPTable footrtables = new PdfPTable(2);
    //            //float[] footrsBodys = { 15, 85 };
    //            //footrtables.SetWidths(footrsBodys);
    //            //footrtables.WidthPercentage = 100;




    //            //footrtables.AddCell(new PdfPCell(new Phrase("Order No.", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_ORDERNO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase("Sales Ref #", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase("Date", FontFactory.GetFont("Arial", 9, Font.NORMAL, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            //document.Add(footrtables);



    //            var FontGrey = new BaseColor(134, 152, 160);
    //            var FontBordrGrey = new BaseColor(236, 236, 236);


    //            if (dtProduct.Rows.Count > 0)
    //            {

    //                string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "";
    //                string strcurrenWord = "", strCrncyAbbrv = "";

    //                if (dt.Rows[0]["CRNCY_STS"].ToString() == "1")
    //                {
    //                    strCrncyAbbrv = dt.Rows[0]["CRNCMST_ABBRV"].ToString();

    //                    if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
    //                    {

    //                        grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);


    //                        grossTotal = strNetAmountDebitComma;
    //                    }
    //                    if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
    //                    {


    //                        taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);

    //                        taxTotal = strNetAmountDebitComma;

    //                    }
    //                    if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
    //                    {



    //                        discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);

    //                        discTotal = strNetAmountDebitComma;

    //                    }
    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {

    //                        netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);

    //                        netTotal = strNetAmountDebitComma;

    //                    }
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());

    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                        strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
    //                    }
    //                }
    //                else
    //                {
    //                    strCrncyAbbrv = dt.Rows[0]["DEFULT_ABRVTN"].ToString();

    //                    if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
    //                    {
    //                        grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);

    //                        grossTotal = strNetAmountDebitComma;



    //                    }
    //                    if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
    //                    {
    //                        taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);

    //                        taxTotal = strNetAmountDebitComma;

    //                    }
    //                    if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
    //                    {
    //                        discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
    //                        discTotal = strNetAmountDebitComma;


    //                    }
    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
    //                        netTotal = strNetAmountDebitComma;

    //                    }
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["DEFULT_CRNCMST_ID"].ToString());

    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                        strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
    //                    }
    //                }



    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                var FontRed = new BaseColor(202, 3, 20);
    //                var FontGreen = new BaseColor(46, 179, 51);
    //                var FontGray = new BaseColor(138, 138, 138);
    //                var FontColour = new BaseColor(134, 152, 160);
    //                var FontWhite = new BaseColor(255, 255, 255);

    //                if (TaxEnable == 1)
    //                {
    //                    PdfPTable table2 = new PdfPTable(8);
    //                    float[] tableBody2 = { 4, 24, 8, 12, 10, 9, 15, 18 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("SL#", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    //table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {
    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";
    //                        string ProductTaxAmt = "";
    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString() != "")
    //                        {
    //                            ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
    //                            ProductTaxAmt = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "" && dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != null)
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }
    //                        string strRemark = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString() != "")
    //                        {
    //                            strRemark = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString();

    //                        }
    //                        int SlNo = intRowBodyCount + 1;
    //                        table2.AddCell(new PdfPCell(new Phrase(SlNo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        //table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["TAX_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(strRemark, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase("Total  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColorTop = FontGray, BorderColorLeft = FontGray, BorderColorRight = FontGray, BorderColorBottom = FontGray, });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray});
    //                    table2.AddCell(new PdfPCell(new Phrase("Discount  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColorTop = FontGray, BorderColorLeft = FontGray, BorderColorRight = FontGray, BorderColorBottom = FontGray, });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("Tax  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7, BorderColorTop = FontGray, BorderColorLeft = FontGray, BorderColorRight = FontGray, BorderColorBottom = FontGray, });
    //                    table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });

    //                    table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, Colspan = 7, });
    //                    table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });

    //                    document.Add(table2);

    //                }
    //                else
    //                {
    //                    PdfPTable table2 = new PdfPTable(7);
    //                    float[] tableBody2 = { 4, 30, 8, 12, 12, 14, 20 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("SL#", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("DISC", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL" + " (" + strCrncyAbbrv + ")", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray, BackgroundColor = FontColour });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {

    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";

    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }
    //                        string strRemark = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString() != "")
    //                        {
    //                            strRemark = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString();

    //                        }
    //                        int slNo = intRowBodyCount + 1;
    //                        table2.AddCell(new PdfPCell(new Phrase(slNo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(strRemark, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase("Total  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColorTop = FontGray, BorderColorLeft = FontGray, BorderColorRight = FontGray, BorderColorBottom = FontGray, });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("Discount  ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColorTop = FontGray, BorderColorLeft = FontGray, BorderColorRight = FontGray, BorderColorBottom = FontGray, });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });


    //                    table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray, Colspan = 6, });
    //                    table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
                        
                        
    //                    document.Add(table2);
    //                }

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                if (Version_flg == 2)
    //                {

    //                    PdfPTable footrtables = new PdfPTable(2);
    //                    float[] footrsBodys = { 30, 70 };
    //                    footrtables.SetWidths(footrsBodys);
    //                    footrtables.WidthPercentage = 100;




    //                    footrtables.AddCell(new PdfPCell(new Phrase("Sale Order No.", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_ORDERNO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase("Reference No.", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    document.Add(footrtables);


    //                    if (dt.Rows[0]["SALES_DESC"].ToString().Trim() != "")
    //                    {
    //                        document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                        document.Add(new Paragraph(new Chunk("Remarks", FontFactory.GetFont("Arial", 9, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                        document.Add(new Paragraph(new Chunk(dt.Rows[0]["SALES_DESC"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //                    }
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


    //                    var phrase2 = new Phrase();
    //                    var phrase5 = new Phrase();

    //                    if (dtBankDtls.Rows.Count > 0)
    //                    {
    //                        phrase2.Add(new Chunk("Make all cheques payable to ", FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));

    //                        if (dtCorp.Rows.Count > 0)
    //                        {
    //                            if (dtCorp.Rows[0][0].ToString() != "")
    //                            {
    //                                phrase2.Add(new Chunk(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));

    //                                phrase5.Add(new Chunk(" Bank Details for ", FontFactory.GetFont("Arial", 9, Font.UNDERLINE)));
    //                                phrase5.Add(new Chunk(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD | Font.UNDERLINE)));
    //                                phrase5.Add(new Chunk("", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));

    //                            }
    //                        }


    //                        document.Add(new Paragraph(phrase2) { Alignment = Element.ALIGN_CENTER });
    //                        document.Add(new Paragraph(phrase5) { Alignment = Element.ALIGN_CENTER, });

    //                        var phrase4 = new Phrase();
    //                        var phrase6 = new Phrase();
    //                        var phrase7 = new Phrase();
    //                        var phrase9 = new Phrase();


    //                        if (dtBankDtls.Rows[0]["BANK_I_BAN_NO"].ToString().Trim() != "")
    //                        {
    //                            phrase6.Add(new Chunk(" IBAN ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //                            phrase6.Add(new Chunk(dtBankDtls.Rows[0]["BANK_I_BAN_NO"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));

    //                        }
    //                        if (dtBankDtls.Rows[0]["BANK_ACC_NO"].ToString().Trim() != "")
    //                        {
    //                            phrase7.Add(new Chunk(" A/C No. ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //                            phrase7.Add(new Chunk(dtBankDtls.Rows[0]["BANK_ACC_NO"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //                        }
    //                        if (dtBankDtls.Rows[0]["BANK_NAME"].ToString().Trim() != "")
    //                        {
    //                            phrase7.Add(new Chunk(" Bank ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //                            phrase7.Add(new Chunk(dtBankDtls.Rows[0]["BANK_NAME"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //                        }
    //                        if (dtBankDtls.Rows[0]["BANK_SWIFT_CODE"].ToString().Trim() != "")
    //                        {
    //                            phrase9.Add(new Chunk(" Swift Code ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //                            phrase9.Add(new Chunk(dtBankDtls.Rows[0]["BANK_SWIFT_CODE"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //                        }
    //                        document.Add(new Paragraph(phrase4) { Alignment = Element.ALIGN_CENTER });
    //                        document.Add(new Paragraph(phrase6) { Alignment = Element.ALIGN_CENTER });
    //                        document.Add(new Paragraph(phrase7) { Alignment = Element.ALIGN_CENTER });
    //                        document.Add(new Paragraph(phrase9) { Alignment = Element.ALIGN_CENTER });
    //                    }


    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                    PdfPTable pdfCorprt = new PdfPTable(1);
    //                    pdfCorprt.WidthPercentage = 100;

    //                    pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    pdfCorprt.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    document.Add(pdfCorprt);

    //                }

    //            }

    //            string CheckedBy = "";
    //            if (dt.Rows[0]["SALES_CNFRM_STS"].ToString() == "1")
    //            {
    //                CheckedBy = dt.Rows[0]["USR_NAME"].ToString();
    //            }

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

    //public string PdfPrintVersion3(DataTable dt, DataTable dtProduct, DataTable dtCust, DataTable dtCorp, clsEntitySales ObjEntitySales, string PreparedBy)
    //{
    //    string strRet = "true";

    //    string strId = "";
    //    if (Request.QueryString["ViewId"] != null)
    //    {
    //        string strRandomMixedId = Request.QueryString["ViewId"].ToString();
    //        string strLenghtofId = strRandomMixedId.Substring(0, 2);
    //        int intLenghtofId = Convert.ToInt16(strLenghtofId);
    //        strId = strRandomMixedId.Substring(2, intLenghtofId);
    //    }
    //    clsBusinessLayer objBusiness = new clsBusinessLayer();
    //    clsCommonLibrary objCommon = new clsCommonLibrary();
    //    int intImageSection = Convert.ToInt32(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
    //    string strImagePath = objCommon.GetImagePath(clsCommonLibrary.IMAGE_SECTION.SALE_INVOICE);
    //    clsEntityCommon objEntityCommon = new clsEntityCommon();
    //    if (ObjEntitySales.Corporate_id != 0)
    //    {
    //        objEntityCommon.CorporateID = ObjEntitySales.Corporate_id;
    //    }
    //    if (ObjEntitySales.Organisation_id != 0)
    //    {
    //        objEntityCommon.Organisation_Id = ObjEntitySales.Organisation_id;
    //    }

    //    clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
    //    objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES_PRINT);
    //    string strNextNumber = objBusinessLayer.ReadNextNumberSequanceForUI(objEntityCommon);
    //    string strImageName = "Sale_Invoice" + strId + "_" + strNextNumber + ".pdf";
    //    DataTable dtBankDtls = objBusinessSales.ReadBankDetails(ObjEntitySales);
    //    if (dt.Rows.Count > 0)
    //    {
    //        if (dt.Rows[0]["CSTMR_ID"].ToString() != "")
    //        {
    //            ObjEntitySales.LedgerId = Convert.ToInt32(dt.Rows[0]["CSTMR_ID"].ToString());

    //        }

    //    }

    //    Document document = new Document(PageSize.A4, 50f, 40f, 20f, 10f);
    //    Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
    //    try
    //    {

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


    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            PdfPTable footrtable = new PdfPTable(2);
    //            float[] footrsBody = { 50, 50 };
    //            footrtable.SetWidths(footrsBody);
    //            footrtable.WidthPercentage = 100;


    //            footrtable.AddCell(new PdfPCell(new Phrase("INVOICE", FontFactory.GetFont("Arial", 12, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 15 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase(dt.Rows[0]["SALES_DATE"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            footrtable.AddCell(new PdfPCell(new Phrase("To", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3, PaddingTop = 20 });

    //            footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            if (dtCust.Rows.Count > 0)
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.BOLD, FontBlue))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //            }
    //            if (dtCust.Rows.Count > 0)
    //            {
    //                if (dtCust.Rows[0][4].ToString().Trim() != "")
    //                {
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                }

    //                else
    //                {
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase(dtCust.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                    footrtable.AddCell(new PdfPCell(new Phrase("", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                }
    //            }
    //            else
    //            {
    //                footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][4].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase("                          ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][1].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });

    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][2].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                footrtable.AddCell(new PdfPCell(new Phrase(dtCorp.Rows[0][3].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });


    //            }
    //            document.Add(footrtable);



    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //            var FontGrey = new BaseColor(134, 152, 160);
    //            var FontBordrGrey = new BaseColor(236, 236, 236);


    //            if (dtProduct.Rows.Count > 0)
    //            {

    //                string netTotal = "", grossTotal = "", taxTotal = "", discTotal = "";
    //                string strcurrenWord = "";

    //                if (dt.Rows[0]["CRNCY_STS"].ToString() == "1")
    //                {
    //                    if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
    //                    {

    //                        grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);


    //                        grossTotal = strNetAmountDebitComma + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();
    //                    }
    //                    if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
    //                    {


    //                        taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);

    //                        taxTotal = strNetAmountDebitComma + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();

    //                    }
    //                    if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
    //                    {



    //                        discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);

    //                        discTotal = strNetAmountDebitComma + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();

    //                    }
    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {

    //                        netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);

    //                        netTotal = strNetAmountDebitComma + " " + dt.Rows[0]["CRNCMST_ABBRV"].ToString();

    //                    }
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["CRNCMST_ID"].ToString());

    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                        strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
    //                    }
    //                }
    //                else
    //                {
    //                    if (dt.Rows[0]["SALES_GROSS_TOTAL"].ToString() != "")
    //                    {
    //                        grossTotal = dt.Rows[0]["SALES_GROSS_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(grossTotal, objEntityCommon);

    //                        grossTotal = strNetAmountDebitComma + " " + dt.Rows[0]["DEFULT_ABRVTN"].ToString();



    //                    }
    //                    if (dt.Rows[0]["SALES_TAX_TOTAL"].ToString() != "")
    //                    {
    //                        taxTotal = dt.Rows[0]["SALES_TAX_TOTAL"].ToString();

    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(taxTotal, objEntityCommon);

    //                        taxTotal = strNetAmountDebitComma + " " + dt.Rows[0]["DEFULT_ABRVTN"].ToString();

    //                    }
    //                    if (dt.Rows[0]["SALES_DISCOUNT"].ToString() != "")
    //                    {
    //                        discTotal = dt.Rows[0]["SALES_DISCOUNT"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(discTotal, objEntityCommon);
    //                        discTotal = strNetAmountDebitComma + " " + dt.Rows[0]["DEFULT_ABRVTN"].ToString();


    //                    }
    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        netTotal = dt.Rows[0]["SALES_NET_TOTAL"].ToString();
    //                        string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(netTotal, objEntityCommon);
    //                        netTotal = strNetAmountDebitComma + " " + dt.Rows[0]["DEFULT_ABRVTN"].ToString();

    //                    }
    //                    objEntityCommon.CurrencyId = Convert.ToInt32(dt.Rows[0]["DEFULT_CRNCMST_ID"].ToString());

    //                    if (dt.Rows[0]["SALES_NET_TOTAL"].ToString() != "")
    //                    {
    //                        clsBusinessLayer ObjBusiness = new clsBusinessLayer();
    //                        strcurrenWord = ObjBusiness.ConvertCurrencyToWords(objEntityCommon, dt.Rows[0]["SALES_NET_TOTAL"].ToString());
    //                    }
    //                }



    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                var FontRed = new BaseColor(202, 3, 20);
    //                var FontGreen = new BaseColor(46, 179, 51);
    //                var FontGray = new BaseColor(138, 138, 138);


    //                if (TaxEnable == 1)
    //                {


    //                    PdfPTable table2 = new PdfPTable(9);
    //                    float[] tableBody2 = { 4, 20, 15, 12, 10, 10, 7, 10, 12 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("SR.", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("DIS. AMOUNT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TAX", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TAX AMOUNT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {
    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";
    //                        string ProductTaxAmt = "";
    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString() != "")
    //                        {
    //                            ProductTaxAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_TAX_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTaxAmt, objEntityCommon);
    //                            ProductTaxAmt = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "" && dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != null)
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }
    //                        string strRemark = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString() != "")
    //                        {
    //                            strRemark = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString();

    //                        }
    //                        int SlNo = intRowBodyCount + 1;
    //                        table2.AddCell(new PdfPCell(new Phrase(SlNo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(strRemark, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["TAX_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTaxAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 8, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 8, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("Tax", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 8, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    //   table2.AddCell(new PdfPCell(new Phrase("Net Total", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 2, BorderColor = FontGray });
    //                    //    table2.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    //table2.AddCell(new PdfPCell(new Phrase("Net Total (In words)", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 7 });
    //                    //table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });



    //                    //table2.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = FontBlue });



    //                    document.Add(table2);

    //                }
    //                else
    //                {
    //                    PdfPTable table2 = new PdfPTable(7);
    //                    float[] tableBody2 = { 4, 32, 16, 12, 12, 12, 12 };
    //                    table2.SetWidths(tableBody2);
    //                    table2.WidthPercentage = 100;
    //                    table2.AddCell(new PdfPCell(new Phrase("SR.", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("PRODUCT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("REMARKS", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("DIS. AMOUNT", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("QTY", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("RATE", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("TOTAL", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });

    //                    for (int intRowBodyCount = 0; intRowBodyCount < dtProduct.Rows.Count; intRowBodyCount++)
    //                    {

    //                        string ProductPrice = "";
    //                        string ProductDisAmt = "";

    //                        string ProductTtlAmt = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString() != "")
    //                        {
    //                            ProductPrice = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_RATE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductPrice, objEntityCommon);
    //                            ProductPrice = strNetAmountDebitComma;

    //                        }
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString() != "")
    //                        {
    //                            ProductDisAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_DISCOUNT_AMT"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductDisAmt, objEntityCommon);
    //                            ProductDisAmt = strNetAmountDebitComma;

    //                        }

    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString() != "")
    //                        {
    //                            ProductTtlAmt = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_PRICE"].ToString();
    //                            string strNetAmountDebitComma = objBusiness.AddCommasForNumberSeperation(ProductTtlAmt, objEntityCommon);
    //                            ProductTtlAmt = strNetAmountDebitComma;

    //                        }
    //                        string strRemark = "";
    //                        if (dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString() != "")
    //                        {
    //                            strRemark = dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_REMARK"].ToString();

    //                        }
    //                        int SlNo = intRowBodyCount + 1;
    //                        table2.AddCell(new PdfPCell(new Phrase(SlNo.ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["PRDT_NAME"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(strRemark, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductDisAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(dtProduct.Rows[intRowBodyCount]["SALS_PRODUCT_QTY"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductPrice, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                        table2.AddCell(new PdfPCell(new Phrase(ProductTtlAmt, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    }
    //                    table2.AddCell(new PdfPCell(new Phrase("Total", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase(grossTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("Discount", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase(discTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase("Tax", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, Colspan = 6, BorderColor = FontGray });
    //                    table2.AddCell(new PdfPCell(new Phrase(taxTotal, FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE, BorderColor = FontGray });
    //                    document.Add(table2);
    //                }

    //                //   document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));


    //                PdfPTable tablettl = new PdfPTable(2);
    //                float[] tablettlBody = { 88, 12 };
    //                tablettl.SetWidths(tablettlBody);
    //                tablettl.WidthPercentage = 100;

    //                //  tablettl.AddCell(new PdfPCell(new Phrase(" ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.WHITE))) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BackgroundColor = iTextSharp.text.BaseColor.WHITE });
    //                tablettl.AddCell(new PdfPCell(new Phrase(strcurrenWord.ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 2, BorderColor = FontGray });
    //                tablettl.AddCell(new PdfPCell(new Phrase(netTotal, FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 2, BorderColor = FontGray });
    //                document.Add(tablettl);

    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //                document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));

    //                //PdfPTable footrtables = new PdfPTable(2);
    //                //float[] footrsBodys = { 30, 70 };
    //                //footrtables.SetWidths(footrsBodys);
    //                //footrtables.WidthPercentage = 100;




    //                //footrtables.AddCell(new PdfPCell(new Phrase("Sale Order No.", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_ORDERNO"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //footrtables.AddCell(new PdfPCell(new Phrase("Proforma INV Reference No.", FontFactory.GetFont("Arial", 9, Font.NORMAL))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //footrtables.AddCell(new PdfPCell(new Phrase(": " + dt.Rows[0]["SALES_REF"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Border = 0, HorizontalAlignment = Element.ALIGN_LEFT, Padding = 3 });
    //                //document.Add(footrtables);
    //            }


    //            //if (dt.Rows[0]["SALES_DESC"].ToString().Trim() != "")
    //            //{
    //            //    document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //    document.Add(new Paragraph(new Chunk("Remarks", FontFactory.GetFont("Arial", 9, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //            //    document.Add(new Paragraph(new Chunk(dt.Rows[0]["SALES_DESC"].ToString(), FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { Alignment = Element.ALIGN_LEFT });
    //            //}
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //var phrase2 = new Phrase();
    //            //if (dtBankDtls.Rows.Count > 0)
    //            //{
    //            //    phrase2.Add(new Chunk("Make all checks payable to ", FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));

    //            //    if (dtCorp.Rows.Count > 0)
    //            //    {
    //            //        if (dtCorp.Rows[0][0].ToString() != "")
    //            //        {
    //            //            phrase2.Add(new Chunk(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //            //            phrase2.Add(new Chunk(" or Bank Details for ", FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //            //            phrase2.Add(new Chunk(dtCorp.Rows[0][0].ToString(), FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //            //        }
    //            //    }
    //            //    document.Add(new Paragraph(phrase2) { Alignment = Element.ALIGN_CENTER });

    //            //    var phrase4 = new Phrase();

    //            //    if (dtBankDtls.Rows[0]["BANK_I_BAN_NO"].ToString().Trim() != "")
    //            //    {
    //            //        phrase4.Add(new Chunk(" IBAN ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //            //        phrase4.Add(new Chunk(dtBankDtls.Rows[0]["BANK_I_BAN_NO"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));

    //            //    }
    //            //    if (dtBankDtls.Rows[0]["BANK_ACC_NO"].ToString().Trim() != "")
    //            //    {
    //            //        phrase4.Add(new Chunk(" A/C No. ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //            //        phrase4.Add(new Chunk(dtBankDtls.Rows[0]["BANK_ACC_NO"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //            //    }
    //            //    if (dtBankDtls.Rows[0]["BANK_NAME"].ToString().Trim() != "")
    //            //    {
    //            //        phrase4.Add(new Chunk(" Bank ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //            //        phrase4.Add(new Chunk(dtBankDtls.Rows[0]["BANK_NAME"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //            //    }
    //            //    if (dtBankDtls.Rows[0]["BANK_SWIFT_CODE"].ToString().Trim() != "")
    //            //    {
    //            //        phrase4.Add(new Chunk(" Swift Code ", FontFactory.GetFont("Arial", 9, Font.BOLD, BaseColor.BLACK)));
    //            //        phrase4.Add(new Chunk(dtBankDtls.Rows[0]["BANK_SWIFT_CODE"].ToString(), FontFactory.GetFont("Arial", 9, BaseColor.BLACK)));
    //            //    }
    //            //    document.Add(new Paragraph(phrase4) { Alignment = Element.ALIGN_CENTER });

    //            //}

    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk("Accounting Department ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))) { PaddingTop = 25 });
    //            //document.Add(new Paragraph(new Chunk(".......................................", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));



    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
    //            //document.Add(new Paragraph(new Chunk(" ", FontFactory.GetFont("Arial", 9, Font.NORMAL, BaseColor.BLACK))));
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
    public static string CheckRefNumber(string jrnlDate, string orgID, string corptID, string usrID, string RefNum, string saleId)
    {
        string Ref = "";

        clsBusinessLayer_Account_Close objEmpAccntCls = new clsBusinessLayer_Account_Close();
        clsEntityLayer_Account_Close objEntityAccnt = new clsEntityLayer_Account_Close();
        clsEntityCommon objEntityCommon = new clsEntityCommon();
        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityAccnt.FromDate = objCommon.textToDateTime(jrnlDate);
        clsBusinessSales objBusinessLayerStock = new clsBusinessSales();
        clsEntitySales objEntityLayerStock = new clsEntitySales();
        cls_Business_Audit_Closeing objBusinessAudit = new cls_Business_Audit_Closeing();
        clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
        objEntityAudit.FromDate = objCommon.textToDateTime(jrnlDate);

        objEntityLayerStock.FromPeriod = objCommon.textToDateTime(jrnlDate);

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
                if (dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != null)
                {
                    if (Convert.ToInt32(dtRefFormat1.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString()) != 1)
                    {
                        strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                        strRef = strRef.TrimEnd('/');
                        strRef = strRef.Remove(strRef.LastIndexOf('/') + 1);
                    }
                    else
                    {
                        strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                    }
                }
                else
                {
                    strRef = dtRefFormat1.Rows[0]["SALES_REF"].ToString();
                }
                objEntityLayerStock.Ref = strRef;
                DataTable dtRefFormat = objBusinessLayerStock.ReadRefNumberByDateLast(objEntityLayerStock);

                if (dtRefFormat.Rows.Count > 0)
                {
                    // if (Convert.ToInt32(saleId) != Convert.ToInt32(dtRefFormat.Rows[0]["SALES_ID"].ToString()))
                    //{
                    Ref = dtRefFormat.Rows[0]["SALES_REF"].ToString();
                    if (dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != "" && dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString() != null)
                    {
                        SubRef = Convert.ToInt32(dtRefFormat.Rows[0]["SALES_REF_NXT_SUBNUM"].ToString());
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
            if (saleId == "")
            {

                objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.SALES);
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

    protected void btnReopen1_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        string saleId = "";
        clsCommonLibrary objCommn = new clsCommonLibrary();
        clsEntitySales ObjEntitySales = new clsEntitySales();
        if (Session["CORPOFFICEID"] != null)
        {
            ObjEntitySales.Corporate_id = Convert.ToInt32(Session["CORPOFFICEID"].ToString());
        }
        else if (Session["CORPOFFICEID"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        if (Session["ORGID"] != null)
        {
            ObjEntitySales.Organisation_id = Convert.ToInt32(Session["ORGID"].ToString());
        }
        else if (Session["ORGID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Session["USERID"] != null)
        {
            //intUserId = Convert.ToInt32(Session["USERID"]);
            ObjEntitySales.User_Id = Convert.ToInt32(Session["USERID"]);
        }
        else if (Session["USERID"] == null)
        {
            Response.Redirect("/Default.aspx");
        }
        if (Request.QueryString["ViewId"] != null)
        {
            string strRandomMixedId = Request.QueryString["ViewId"].ToString();
            saleId = Request.QueryString["ViewId"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            ObjEntitySales.SalesId = Convert.ToInt32(strId);
        }
        if (Request.QueryString["Id"] != null)
        {
            string strRandomMixedId = Request.QueryString["Id"].ToString();
            saleId = Request.QueryString["Id"].ToString();
            string strLenghtofId = strRandomMixedId.Substring(0, 2);
            int intLenghtofId = Convert.ToInt16(strLenghtofId);
            string strId = strRandomMixedId.Substring(2, intLenghtofId);
            ObjEntitySales.SalesId = Convert.ToInt32(strId);
        }
        int AcntCloseSts = 0;

        int AuditCloseSts = 0;
        DataTable dt = objBusinessSales.ReadSalesDetailsById(ObjEntitySales);
        if (dt.Rows.Count > 0)
        {
            AcntCloseSts = AccountCloseCheck(dt.Rows[0]["SALES_DATE"].ToString());
            AuditCloseSts = AuditCloseCheck(dt.Rows[0]["SALES_DATE"].ToString());

            if (dt.Rows[0]["CSTMR_ID"].ToString() != null)
            {
                ObjEntitySales.LedgerId = Convert.ToInt32(dt.Rows[0]["CSTMR_ID"].ToString());
            }
        }
        ObjEntitySales.NetTotal = Convert.ToDecimal(HiddenNetAmt.Value);


        int retFlg = 0;

        if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value != "1")
        {
            retFlg = 1;
            Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=AuditClosed");
        }
        else if (AuditCloseSts == 1 && HiddenFieldAuditCloseReopenSts.Value == "1")
        {

        }
        else if (AcntCloseSts == 1 && HiddenProvisionSts.Value != "1")
        {
            retFlg = 1;
            Response.Redirect("fms_Sales_Master_List.aspx?InsUpd=AcntClosed");
        }

        string sts = dt.Rows[0]["SALES_CNFRM_STS"].ToString();
        if (sts == "0")
        {
            retFlg = 1;
            Response.Redirect("fms_Sales_Master.aspx?Id=" + saleId + "&InsUpd=REOPENERROR");
        }

        if (retFlg == 0)
        {
            objBusinessSales.ReopenSales(ObjEntitySales);
            if (clickedButton.ID == "btnReopen1" || clickedButton.ID == "btnFloatReopen")
            {
                Response.Redirect("fms_Sales_Master.aspx?Id=" + saleId + "&InsUpd=Reop");
            }
        }
    }

    protected void btnCustomer_Click(object sender, EventArgs e)
    {
        loadCustomerLedger();
        if (HiddenCustomerId.Value != "")
        {
            if (ddlCustomerLdgr.Items.FindByValue(HiddenCustomerId.Value.ToString()) != null)
            {
                ddlCustomerLdgr.Items.FindByValue(HiddenCustomerId.Value.ToString()).Selected = true;
            }

            else
            {
                //ListItem lstGrp = new ListItem(strProjectName, HiddenSupplierId.Value.ToString());
                //ddlCustomerLdgr.Items.Insert(1, lstGrp);

                SortDDL(ref this.ddlCustomerLdgr);
                ddlCustomerLdgr.ClearSelection();
                if (ddlCustomerLdgr.Items.FindByValue(HiddenCustomerId.Value.ToString()) != null)
                {
                    ddlCustomerLdgr.Items.FindByValue(HiddenCustomerId.Value.ToString()).Selected = true;
                }
            }


            //evm 0044 
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntitySales objEntityLedger = new clsEntitySales();
            clsBusinessSales objBusinessSales = new clsBusinessSales();
            clsBusinessLayerCustomer objBusinessCustomer = new clsBusinessLayerCustomer();
            clsEntityCustomer objEntityCustomer = new clsEntityCustomer();


            objEntityLedger.LedgerId = Convert.ToInt32(ddlCustomerLdgr.SelectedItem.Value);
            string CurrentDate = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
            objEntityLedger.Date = objCommon.textToDateTime(CurrentDate);
            objEntityLedger.LedgerId = Convert.ToInt32(ddlCustomerLdgr.SelectedItem.Value);
            DataTable dt = objBusinessSales.ReadSaleCreditDtls(objEntityLedger);

            if (dt.Rows.Count > 0)
            {

                if (dt.Rows[0]["LDGR_CRDT_PERIOD"].ToString() != "")
                {
                    txtcrdtPeriod.Text = dt.Rows[0]["LDGR_CRDT_PERIOD"].ToString();
                }

            }
            //-----------


        }
    }

    [WebMethod]
    public static string RedPrdtName(string intProductId, string intuserid, string intorgid, string intcorpid)
    {

        string result = "";
        clsEntitySales ObjEntitySales = new clsEntitySales();

        clsBusinessSales objBusinessSales = new clsBusinessSales();
        ObjEntitySales.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntitySales.product_id = Convert.ToInt32(intProductId);
        ObjEntitySales.Corporate_id = Convert.ToInt32(intcorpid);


        if (intProductId != "")
        {

            DataTable dtSubConrt = objBusinessSales.ReadProductName(ObjEntitySales);
            // dtSubConrt.TableName = "dtTableLoadProduct";
            //  string ABVRTN;
            if (dtSubConrt.Rows.Count > 0)
            {
                result = dtSubConrt.Rows[0][0].ToString();

            }

        }
        return result;
    }


    [WebMethod]
    public static string RedCustmrName(string intCustomerId, string intuserid, string intorgid, string intcorpid)
    {

        string result = "";
        clsEntitySales ObjEntitySales = new clsEntitySales();
        clsBusinessSales objBusinessSales = new clsBusinessSales();

        ObjEntitySales.Organisation_id = Convert.ToInt32(intorgid);
        ObjEntitySales.Corporate_id = Convert.ToInt32(intcorpid);

        ObjEntitySales.LedgerType = "SALE";
        DataTable dtlCstmrLedger = objBusinessSales.ReadCustomerLedger(ObjEntitySales);

        StringBuilder sb = new StringBuilder();

        sb.Append("<option value=\"0\" selected=\"true\">--SELECT CUSTOMER--</option>");
        for (int intRow = 0; intRow < dtlCstmrLedger.Rows.Count; intRow++)
        {
            sb.Append("<option value=\"" + dtlCstmrLedger.Rows[intRow]["LDGR_ID"].ToString() + "\">" + dtlCstmrLedger.Rows[intRow]["LDGR_NAME"].ToString() + "</option>");
        }

        result = sb.ToString();

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
    //evm-0027 AUG 27
    [WebMethod]
    public static string ReadLeadgers(string intProductId, string intuserid, string intorgid, string intcorpid)
    {
        string result = "";
        clsBusiness_Account_Setting objBusiness = new clsBusiness_Account_Setting();
        clsEntity_Account_Setting objEntity = new clsEntity_Account_Setting();
        objEntity.OrgId = Convert.ToInt32(intorgid);
        objEntity.CorpId = Convert.ToInt32(intcorpid);
        objEntity.AccountNatureStatus = 0;

        DataTable dtlCstmrLedger = objBusiness.ReadLedgerByNature(objEntity);
        if (dtlCstmrLedger.Rows.Count > 0)
        {
            dtlCstmrLedger.TableName = "dtTableCostCenter";
        }
       
        return result;
    }



    //END


    [WebMethod]
    public static string[] DisplayCreditDtls(string CustomerId, string NetAmnt, string Date, string SaleId)
    {
        string[] result = new string[6];
        result[0] = "";
        result[1] = "";
        result[2] = "";
        result[3] = "";
        result[4] = "";
        result[5] = "";

        int flsgLimit = 0;
        int flsgPeriod = 0;

        clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
        clsCommonLibrary objCommon = new clsCommonLibrary();

        clsEntitySales objEntityLedger = new clsEntitySales();
        clsBusinessSales objBusinessSales = new clsBusinessSales();
        //evm 0044 08/02
        clsBusinessLayerCustomer objBusinessCustomer = new clsBusinessLayerCustomer();
        clsEntityCustomer objEntityCustomer = new clsEntityCustomer();
        //-----------
        string CurrentDate = objBusinessLayer.LoadCurrentDate().ToString("dd-MM-yyyy");
        objEntityLedger.Date = objCommon.textToDateTime(CurrentDate);
        objEntityLedger.LedgerId = Convert.ToInt32(CustomerId);


        if (Date == "")
        {
            Date = objEntityLedger.Date.ToString();
        }
        if (SaleId != "")
        {
            objEntityLedger.SalesId = Convert.ToInt32(SaleId);
        }

        DateTime dtFrom = objCommon.textToDateTime(Date);
        DateTime dtTo = objEntityLedger.Date;

        int NoOfDays = 0;
        if (dtFrom < dtTo)
        {
            NoOfDays = Convert.ToInt32((dtTo - dtFrom).TotalDays);
        }

        decimal decNetAmnt = Convert.ToDecimal(NetAmnt);

        DataTable dt = objBusinessSales.ReadSaleCreditDtls(objEntityLedger);

        string strLimit = "";
        string strPeriod = "";

        int Period = 0;
        string WarnPeriod = "0";
        string RestrictPeriod = "0";

        decimal Limit = 0;
        string WarnLimit = "0";
        string RestrictLimit = "0";

        decimal PrcntLimit = 0;
        decimal PrcntPeriod = 0;

        int intRestrict = 0;

        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["LDGR_CRDT_LMT"].ToString() != "")
            {
                strLimit = dt.Rows[0]["LDGR_CRDT_LMT"].ToString();
                Limit = Convert.ToDecimal(dt.Rows[0]["LDGR_CRDT_LMT"].ToString());
                WarnLimit = dt.Rows[0]["LDGR_CRDT_LMT_WARN"].ToString();
                RestrictLimit = dt.Rows[0]["LDGR_CRDT_LMT_RESTRICT"].ToString();

                decimal Sum = 0;
                if (dt.Rows[0]["SUM"].ToString() != "")
                {
                    Sum = Convert.ToDecimal(dt.Rows[0]["SUM"].ToString());
                }

                PrcntLimit = ((decNetAmnt + Sum) * 100) / Limit;

                if ((Limit != 0 && ((Convert.ToDecimal(NetAmnt) + Sum) > Limit)))
                {
                    if (RestrictLimit != "0" || WarnLimit != "0")
                    {
                        result[0] = "limit";

                        if (RestrictLimit != "0")
                        {
                            intRestrict++;
                        }
                        flsgLimit++;
                    }
                }

                if (intRestrict > 0)
                {
                    result[1] = "restrict";
                }
            }

            if (dt.Rows[0]["LDGR_CRDT_PERIOD"].ToString() != "")
            {
                strPeriod = dt.Rows[0]["LDGR_CRDT_PERIOD"].ToString();
                Period = Convert.ToInt32(dt.Rows[0]["LDGR_CRDT_PERIOD"].ToString());
                WarnPeriod = dt.Rows[0]["LDGR_CRDT_PERIOD_WARN"].ToString();
                RestrictPeriod = dt.Rows[0]["LDGR_CRDT_PERIDO_RESTRICT"].ToString();

                decimal MaxDays = 0;
                if (dt.Rows[0]["MAXDAYS"].ToString() != "")
                {
                    MaxDays = Convert.ToDecimal(dt.Rows[0]["MAXDAYS"].ToString());
                }

                PrcntPeriod = ((MaxDays + NoOfDays) * 100) / Period;

                if (Convert.ToInt32((MaxDays + NoOfDays)) > Period)
                {
                    if (RestrictPeriod != "0" || WarnPeriod != "0")
                    {
                        result[0] = "period";

                        if (RestrictPeriod != "0")
                        {
                            intRestrict++;
                        }
                        flsgPeriod++;
                    }
                }

                if (intRestrict > 0)
                {
                    result[1] = "restrict";
                }
            }

            if (flsgLimit != 0 && flsgPeriod != 0)
            {
                result[0] = "both";
            }

            result[2] = PrcntLimit.ToString();
            result[3] = PrcntPeriod.ToString();

            result[4] = strLimit;
            result[5] = strPeriod;

        }

        return result;
    }




}