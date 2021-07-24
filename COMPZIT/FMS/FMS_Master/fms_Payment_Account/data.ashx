<%@ WebHandler Language="C#" Class="data" %>

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

using System.Data;

public class data : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //PARAMETERS MANUALLY ADDED
        var Org_Id = context.Request["ORG_ID"];
        var Corpt_Id = context.Request["CORPT_ID"];
        var CnclSts = context.Request["CNCL_STS"];
        var AccountId = context.Request["ACCOUNTID"];
        var LedgerId = context.Request["LEDGERID"];
        var fromdt = context.Request["FROMDT"];
        var Todt = context.Request["TODAT"];
        var EnableEdit = context.Request["ENABLEDIT"];
        var EnableDelete = context.Request["ENABLEDELETE"];
        var EnableAccount = context.Request["ENABLEREOPEN"];
        var EnableAudit = context.Request["ENABLEAUDIT"];


        var StartDate = context.Request["STARTDATE"];
        var EndDate = context.Request["ENDDATE"];
        var AcntClsDate = context.Request["ACNTCLSDATE"];
        var Confirm = context.Request["CONFIRM"];
        var PurchaseStatus = context.Request["PURCAHSESTATUS"];
        var CurencyId = context.Request["CURRENCY"];
        var Mode = context.Request["MODE"];
        var Reccu = context.Request["RECCU"];
        var FinYrId = context.Request["FINYRID"];
        
        
        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchRef = context.Request["sSearch_0"].ToLower();
        var sSearchAcc = context.Request["sSearch_1"].ToLower();
        var sSearchPayee = context.Request["sSearch_2"].ToLower();
        var sSearchDate = context.Request["sSearch_3"].ToLower();
        var sSearchNarratn = context.Request["sSearch_4"].ToLower();
        var sSearchAmt = context.Request["sSearch_5"].ToLower();

        var persons = Person.GetPersons(Corpt_Id, Org_Id, CnclSts, AccountId, LedgerId, fromdt, Todt, EnableAccount, StartDate, EndDate, AcntClsDate, EnableAudit, Confirm, PurchaseStatus, CurencyId, Reccu, FinYrId);
        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {

            if (iSortCol == 1)
            {
                return p.AccountName;
            }
            if (iSortCol == 2)
            {
                return p.PayeeName;
            }
            if (iSortCol == 3)
            {
                return p.Date;
            }
            if (iSortCol == 4)
            {
                return p.Narration;
            }
            if (iSortCol == 5)
            {
                return p.Total;
            }
            return p.ID;
        };
        // Define the order direction based on the iSortDir parameter
        if ("desc" == iSortDir)
        {

            persons = persons.OrderByDescending(order);
        }
        else
        {
            persons = persons.OrderBy(order);
        }
        object result = null;
            result = new
            {
                iTotalRecords = persons.Count(),
                iTotalDisplayRecords = persons.Count(),
                aaData = persons

                .Where(p => p.REF.ToString().ToLower().Contains(sSearchAll) || p.AccountName.ToString().ToLower().Contains(sSearchAll) || p.PayeeName.ToString().ToLower().Contains(sSearchAll) || p.Date.ToString().ToLower().Contains(sSearchAll) || p.Narration.ToString().ToLower().Contains(sSearchAll) || p.Total.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
                .Where(p => p.REF.ToString().ToLower().Contains(sSearchRef))  // Search: Avoid Contains() in production
                 .Where(p => p.AccountName.ToString().ToLower().Contains(sSearchAcc))
                 .Where(p => p.PayeeName.ToString().ToLower().Contains(sSearchPayee))
                 .Where(p => p.Date.ToString().ToLower().Contains(sSearchDate))
                 .Where(p => p.Narration.ToString().ToLower().Contains(sSearchNarratn))
                 .Where(p => p.Total.Replace(",", "").ToString().ToLower().Contains(sSearchAmt))
                .Select(p => new[] { p.REF, p.AccountName, p.PayeeName, p.Date.ToString("dd-MM-yyyy"), p.Narration, p.Total, p.Status, p.Actions, p.ID.ToString() })
                .Skip(iDisplayStart)
                .Take(iDisplayLength)
            };
        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        var json = serializer.Serialize(result);
        context.Response.ContentType = "application/json";
        context.Response.Write(json);
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    public class Person
    {
        public string REF { get; set; }
        public string AccountName { get; set; }
        public string PayeeName { get; set; }
        public DateTime Date { get; set; }
        public string Total { get; set; }
        public string Narration { get; set; }
        public string Status { get; set; }
        public string Actions { get; set; }
       
        public int ID { get; set; }
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string CnclSts, string AccountId, string LedgerId, string fromdt, string Todt, string EnableAccount, string StartDate, string EndDate, string AcntClsDate, string EnableAudit, string Confirm, string PurchaseStatus, string CurencyId, string Reccu, string FinYrId)
        {
            clsBusiness_PaymentAccount objBussiness = new clsBusiness_PaymentAccount();
            clsEntityPaymentAccount ObjEntityRequest = new clsEntityPaymentAccount();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();

            objEntityAudit.Organisation_id = Convert.ToInt32(Org_Id);
            objEntityAudit.Corporate_id = Convert.ToInt32(Corpt_Id);
            
            ObjEntityRequest.Organisation_id = Convert.ToInt32(Org_Id);
            ObjEntityRequest.Corporate_id = Convert.ToInt32(Corpt_Id);
            ObjEntityRequest.cnclStatus = Convert.ToInt32(CnclSts);
            objEntityCommon.Organisation_Id = Convert.ToInt32(Org_Id);
            objEntityCommon.CorporateID = Convert.ToInt32(Corpt_Id);
            int intCorpId = 0;
            if (Corpt_Id != "")
                intCorpId = Convert.ToInt32(Corpt_Id);
            if (CurencyId != "")
                objEntityCommon.CurrencyId = Convert.ToInt32(CurencyId);
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID,
                                                           clsCommonLibrary.CORP_GLOBAL.CNCL_REASN_MUST
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, intCorpId);
            if (dtCorpDetail.Rows.Count > 0)
            {
                objEntityCommon.CurrencyId = Convert.ToInt32(dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString());
            }


            objEntityCommon.SectionId = Convert.ToInt32(clsCommonLibrary.Section.FMS_PAYMENT);
            objEntityCommon.CorporateID = ObjEntityRequest.Corporate_id;
            DataTable dtFormate = objBussiness.readRefFormate(objEntityCommon);
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
                    string arrReferenceSplit = strReferenceFormat.Replace("INVPMD","");
                    strRealFormat = refFormatByDiv.ToString();
                }
            }
            

            if (AccountId != "--SELECT ACCOUNT--" && AccountId != "0")
            {
                ObjEntityRequest.AccntNameId = Convert.ToInt32(AccountId);
            }
            if (LedgerId != "--SELECT LEDGER--" && LedgerId != "0")
            {
                ObjEntityRequest.LedgerId = Convert.ToInt32(LedgerId);
            }
            if (fromdt != "")
            {
                ObjEntityRequest.FromDate = objCommon.textToDateTime(fromdt);
            }
            if (Todt != "")
            {
                ObjEntityRequest.ToDate = objCommon.textToDateTime(Todt);
            }
            if (StartDate != "")
            {
                ObjEntityRequest.StartDate = objCommon.textToDateTime(StartDate);
            }
            if (EndDate != "")
            {
                ObjEntityRequest.EndDate = objCommon.textToDateTime(EndDate);
            }
            if (PurchaseStatus != "")
            {
                ObjEntityRequest.ConfirmStatus = Convert.ToInt32(PurchaseStatus);
            }


            DataTable dtAcntClsDate = objBusiness.ReadAccountClsDate(objEntityCommon);
            DateTime acntClsDate = DateTime.MinValue;
            int YearEndCls = 0;

            if (FinYrId != "")
            {
                objEntityCommon.FinancialYrId = Convert.ToInt32(FinYrId);
            }
            DataTable dtYearEndClsDate = objBusiness.ReadYearEndCloseDate(objEntityCommon);
            if (dtYearEndClsDate.Rows.Count > 0)
            {
                YearEndCls = 1;
            }  
            
            if (dtAcntClsDate.Rows.Count > 0)
            {              
                if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "")
                {
                    acntClsDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                }
            }
            
            DataTable dtCategory = objBussiness.Payment_List(ObjEntityRequest);
            int intCount = 0;

            string strRandom = objCommon.Random_Number();
            foreach (DataRow dtRowsIn in dtCategory.Rows)
            {
                objEntityAudit.FromDate = objCommon.textToDateTime(dtRowsIn["PAYMNT_DATE"].ToString());
                DataTable dtAuditClsDate = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);
                
                string strPrint = "";
                string strDelete = "";
                string strEditView = "";
                string strCheck = "";
                string strActions = "";
                string strReopen = "";
                intCount = intCount + 1;
                string strCount = Convert.ToString(intCount);
                string strId = dtRowsIn[0].ToString();
                int usrId = Convert.ToInt32(strId);
                int intIdLength = dtRowsIn[0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strNetAmount = "";
                string strNetAmountWithComma = "";
                string strsurAbrv = "";
                string strStatus = "";
                string strConfirm = "";
                string strRefNo = "";
                
                
                strsurAbrv = dtRowsIn["CRNCMST_ABBRV"].ToString();
                if (dtRowsIn["TOTAL_AMT"].ToString() != "")
                {
                    strNetAmount = dtRowsIn["TOTAL_AMT"].ToString();
                    strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(strNetAmount, objEntityCommon);
                }
                string cnclusrId = dtRowsIn["PAYMNT_CNCL_USR_ID"].ToString();

                int confrm = 0;
                confrm = Convert.ToInt32(dtRowsIn["PAYMNT_CNFRM_STS"].ToString());
                if (dtRowsIn["PAYMNT_REF_SEQNUM"].ToString() != "")
                {
                    strRefNo = "<td =id=\"sdggfgdfg\" style=\"display:none;\">  " + dtRowsIn["PAYMNT_REF_SEQNUM"].ToString() + " </td>";
                }

                if (confrm > 0)
                {
                    strStatus = "<td class=\"tdT\" style=\" \" >Confirmed </td>";
                }
                else
                {
                    if (dtRowsIn["PAYMNT_REOPEN_STATUS"].ToString() == "1")
                    {
                        strStatus = "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Reopened </td>";
                    }
                    else
                    {
                        strStatus = "<td class=\"tdT\" style=\" width:10%;word-break: break-all; word-wrap:break-word;text-align:left;\" >Pending </td>";
                    }
                }
                
                if (YearEndCls == 0)
                {
                    if (confrm > 0)
                    {
                        strConfirm = "<a disabled class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                        strDelete = " <a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" class=\"fa fa-trash\"></i></a>";
                        if (dtAuditClsDate.Rows.Count > 0)
                        {

                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["PAYMNT_DATE"].ToString()))
                            {

                                if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                {
                                    strReopen = "<a class=\"btn act_btn bn2\" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\"></i></a>";



                                }
                                else
                                {
                                    strReopen = "<a disabled class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\"></i></a>";

                                }
                            }
                            else
                            {
                                strReopen = "<i class=\"fa fa-arrow-circle-o-down\" style=\"font-size: 17px;\"></i></a>";

                            }

                        }
                        else if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["PAYMNT_DATE"].ToString()))
                        {
                            if (EnableAccount == "1")
                            {
                                strReopen = "<a class=\"btn act_btn bn2\" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\"></i></a>";
                            }
                            else
                            {
                                strReopen = "<a disabled class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\"></i></a>";

                            }
                        }





                        else
                        {
                            strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\"></i></a>";
                        }

                        if (dtRowsIn["PAYMNT_MODE"].ToString() == "1")
                        {
                            if (dtRowsIn["PAYMNT_ISSUE"].ToString() != "1")
                            {

                                if (dtAuditClsDate.Rows.Count > 0)
                                {

                                    if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["PAYMNT_DATE"].ToString()))
                                    {

                                        if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                        {

                                            strCheck = "<a class=\"btn act_btn bn7\" title=\"CHEQUE ISSUE\" href=\"javascript:;\" onclick=\"return CheckIssue('" + Id + "');\"><i class=\"fa fa-ticket\"></i></a>";

                                        }
                                        else
                                        {
                                            strCheck = "<a disabled class=\"btn act_btn bn7\" href=\"javascript:;\" title=\"CHEQUE ISSUE\" " + "><i class=\"fa fa-ticket\"></i></a>";

                                        }
                                    }
                                    else
                                    {

                                        strCheck = "<a class=\"btn act_btn bn7\" title=\"CHEQUE ISSUE\" href=\"javascript:;\" onclick=\"return CheckIssue('" + Id + "');\"><i class=\"fa fa-ticket\"></i></a>";

                                    }

                                }


                                else if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["PAYMNT_DATE"].ToString()))
                                {
                                    if (EnableAccount == "1")
                                    {
                                        strCheck = "<a class=\"btn act_btn bn7\" title=\"CHEQUE ISSUE\" href=\"javascript:;\" onclick=\"return CheckIssue('" + Id + "');\"><i class=\"fa fa-ticket\"></i></a>";
                                    }
                                    else
                                    {
                                        strCheck = "<a disabled class=\"btn act_btn bn7\" href=\"javascript:;\" title=\"CHEQUE ISSUE\" " + "><i class=\"fa fa-ticket\"></i></a>";

                                    }
                                }


                                else
                                {
                                    strCheck = "<a class=\"btn act_btn bn7\" title=\"CHEQUE ISSUE\" href=\"javascript:;\" onclick=\"return CheckIssue('" + Id + "');\"><i class=\"fa fa-ticket\"></i></a>";
                                }


                            }
                            else
                            {
                                strCheck = "<a disabled class=\"btn act_btn bn7 \" href=\"javascript:;\" title=\"CHEQUE ISSUE\" " + "><i class=\"fa fa-ticket\"></i></a>";
                            }

                        }
                        else
                        {
                            strCheck = "<a disabled class=\"btn act_btn bn7 \" href=\"javascript:;\" title=\"CHEQUE ISSUE\" " + "> <i class=\"fa fa-ticket\"></i></a>";
                        }

                        strEditView = "<a class=\"btn act_btn bn4 \" title=\"View\" onclick='return getdetails(this.href);' href=\"fms_Payment_Account.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";


                    }
                    else
                    {
                        if (Confirm == "1")
                        {


                            if (dtAuditClsDate.Rows.Count > 0)
                            {

                                if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["PAYMNT_DATE"].ToString()))
                                {

                                    if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                    {
                                        strConfirm = "<a class=\"btn act_btn bn2 \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";

                                    }
                                    else
                                    {
                                        strConfirm = "<a disabled class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\"></i></a>";

                                    }
                                }
                                else
                                {
                                    strConfirm = "<a class=\"btn act_btn bn2 \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";

                                }

                            }

                            else if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["PAYMNT_DATE"].ToString()))
                            {
                                if (EnableAccount == "1")
                                {
                                    strConfirm = "<a class=\"btn act_btn bn2\" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";
                                }
                                else
                                {
                                    strConfirm = "<a disabled class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                                }
                            }


                            else
                            {
                                strConfirm = "<a class=\"btn act_btn bn2 \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";

                            }
                        }
                        else
                        {
                            strConfirm = "<a disabled class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\"></i></a>";

                        }



                        if (dtAuditClsDate.Rows.Count > 0)
                        {

                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["PAYMNT_DATE"].ToString()))
                            {

                                if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                {
                                    strEditView = "<a  class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"fms_Payment_Account.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";

                                }
                                else
                                {
                                    strEditView = "<a class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' href=\"fms_Payment_Account.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                                }
                            }
                            else
                            {
                                strEditView = "<a  class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"fms_Payment_Account.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";

                            }

                        }

                        else if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["PAYMNT_DATE"].ToString()))
                        {
                            if (EnableAccount == "1")
                            {
                                strEditView = "<a  class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"fms_Payment_Account.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                            }
                            else
                            {
                                strEditView = "<a class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' href=\"fms_Payment_Account.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                            }
                        }

                        else
                        {
                            strEditView = "<a  class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"fms_Payment_Account.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";

                        }

                        strReopen = "<a disabled class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\"></i></a>";
                        strCheck = "<a disabled class=\"btn act_btn bn7 \" href=\"javascript:;\" title=\"CHEQUE ISSUE\" " + "><i class=\"fa fa-ticket\"></i></a>";

                        if (dtAuditClsDate.Rows.Count > 0)
                        {

                            if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["PAYMNT_DATE"].ToString()))
                            {

                                if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                {
                                    strDelete = "<a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                                }
                                else
                                {
                                    strDelete = "<a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" class=\"fa fa-trash\"></i></a>";

                                }
                            }
                            else
                            {
                                strDelete = "<a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                            }

                        }
                        else if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["PAYMNT_DATE"].ToString()))
                        {
                            if (EnableAccount == "1")
                            {

                                strDelete = " <a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";
                            }
                            else
                            {
                                strDelete = " <a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" class=\"fa fa-trash\"></i></a>";

                            }
                        }


                        else
                        {
                            strDelete = " <a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                        }





                        // strPrint = "<td style=\"width:1%;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a   disabled class=\"btn btn-xs btn-default\" title=\"Print\" href=\"javascript:;\" ><i class=\"fa fa-print\"></i></a>";

                    }

                }
                else
                {
                    strEditView = "<a class=\"btn act_btn bn4\" title=\"View\" onclick='return getdetails(this.href);' href=\"fms_Payment_Account.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";                    
                    strReopen = "<a disabled class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\"></i></a>";
                    strDelete = " <a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" class=\"fa fa-trash\"></i></a>";
                    strConfirm = "<a disabled class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                    strCheck = "<a disabled class=\"btn act_btn bn7\" href=\"javascript:;\" title=\"CHEQUE ISSUE\" " + "><i class=\"fa fa-ticket\"></i></a>";

                }

                strPrint = "<a  style=\"opacity: 1;\"  class=\"btn act_btn bn6\" title=\"Print\" href=\"javascript:;\" onclick=\"return PrintPdf('" + Id + "');\" ><i class=\"fa fa-print\"></i></a>";
                if (CnclSts == "1")
                {
                    strActions = "<td><a class=\"btn act_btn bn4 \" title=\"View\"onclick='return getdetails(this.href);' href=\"fms_Payment_Account.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a></td>";
                }
                else
                {
                    strActions = "<td>" + strEditView + strCheck + strConfirm + strReopen + strDelete + strPrint + "</td>";
                }
            
                string strReftd="<td class=\"tdT\" style=\" \" >"+dtRowsIn["PAYMNT_REF"].ToString()+"</td>";
                if (dtRowsIn["REPAREC_ID"].ToString() != "" && Reccu=="1")
                {
                    strReftd = "<td class=\"tdT\" style=\" \" >" + dtRowsIn["PAYMNT_REF"].ToString() + "<span class=\"pull-right gre_c\"><i class=\"fa fa-retweet\"></i></span>";
                }

                yield return new Person
                {
                    REF = strReftd,
                    AccountName = dtRowsIn["LDGR_NAME"].ToString(),
                    PayeeName = dtRowsIn["PAYMNT_CHQ_PAYEE"].ToString(),
                    Date = objCommon.textToDateTime(dtRowsIn["PAYMNT_DATE"].ToString()),
                    Narration = dtRowsIn["PAYMNT_DSCRPTN"].ToString(),
                    Total = strNetAmountWithComma + " " + strsurAbrv,
                    Status = strStatus,
                    Actions = strActions,
                    ID = Convert.ToInt32(dtRowsIn["PAYMNT_REF_SEQNUM"].ToString())
                };
            }
        }

    }
}
