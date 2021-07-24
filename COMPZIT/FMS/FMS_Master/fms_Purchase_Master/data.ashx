<%@ WebHandler Language="C#" Class="data" %>
using System;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using EL_Compzit;
using BL_Compzit.BusineesLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Web.Services;
using System.Threading;
using CL_Compzit;
using BL_Compzit;
public class data : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var Org_Id = context.Request["ORG_ID"];
        var Corpt_Id = context.Request["CORPT_ID"];
        var Status = context.Request["STATUS"];
        var CnclSts = context.Request["CNCL_STS"];
        var SuplierId = context.Request["SUPLIER"];
        var fromdt = context.Request["FROMDT"];
        var Todt = context.Request["TODAT"];
        var EnableEdit = context.Request["ENABLEDIT"];
        var EnableDelete = context.Request["ENABLEDELETE"];
        var StartDate = context.Request["STARTDATE"];
        var EndDate = context.Request["ENDDATE"];
        var ReOpen = context.Request["REOPEN"];
        var AcntClsDate = context.Request["ACNTCLSDT"];
        var AuditSts = context.Request["AUDITPRVSN"];

        var EnableAudit = context.Request["ENABLEAUDIT"];
        var Confirm = context.Request["CONFIRM"];
        var PurchaseStatus = context.Request["PURCAHSESTATUS"];
        var CurencyId = context.Request["CURRENCY"];
        var Mode = context.Request["MODE"];
        
        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchRef = context.Request["sSearch_0"].ToLower();
        var sSearchFrm = context.Request["sSearch_1"].ToLower();
        var sSearchSup = context.Request["sSearch_2"].ToLower();
        var sSearchTotal = context.Request["sSearch_3"].ToLower();

       
        //   var sSearchSts = context.Request["sSearch_2"].ToLower();
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id, Status, CnclSts, SuplierId, fromdt, Todt, StartDate, EndDate, ReOpen, AcntClsDate, AuditSts, EnableAudit, Confirm, PurchaseStatus, CurencyId);
        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
            if (iSortCol == 0)
            {
                return p.Ref;
            }
            if (iSortCol == 1)
            {
                return p.Date;
            } if (iSortCol == 2)
            {
                return p.Suplier;
            }
            if (iSortCol == 3)
            {
                return p.Total;
            }
            return p.RefNumSeq;
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
        
        object result =null;
        
            result = new
            {
                iTotalRecords = persons.Count(),
                 iTotalDisplayRecords = persons.Count(),
                aaData = persons

                .Where(p => p.Ref.ToString().ToLower().Contains(sSearchAll) || p.Date.ToString().ToLower().Contains(sSearchAll) || p.Suplier.ToString().ToLower().Contains(sSearchAll) || p.Total.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
                .Where(p => p.Ref.ToString().ToLower().Contains(sSearchRef))  // Search: Avoid Contains() in production
                     .Where(p => p.Date.ToString().ToLower().Contains(sSearchFrm))
                 .Where(p => p.Suplier.ToString().ToLower().Contains(sSearchSup))
                 .Where(p => p.Total.Replace(",", "").ToString().ToLower().Contains(sSearchTotal))


                //.Where(p => p.Status.ToString().ToLower().Contains(sSearchSts))
                .Select(p => new[] { p.Ref, p.Date.ToString("dd-MM-yyyy"), p.Suplier, p.Total, p.Status, p.Actions, p.RefNumSeq.ToString() })
                .Skip(iDisplayStart)
                .Take(iDisplayLength),

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
        public string Ref { get; set; }
        public DateTime Date { get; set; }
        public string Suplier { get; set; }
        public string Total { get; set; }
        public string Status { get; set; }
        public string Actions { get; set; }
       
        public int RefNumSeq { get; set; }
        
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string Status, string CnclSts, string suplier, string fromdt, string todt, string StartDate, string EndDate, string ReOpen, string AcntClsDate, string AuditSts, string EnableAudit, string Confirm, string PurchaseStatus, string CurencyId)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsEntityPurchaseMaster objEntityPurchase = new clsEntityPurchaseMaster();
            clsBusiness_purchaseMaster objBusinesspurchase = new clsBusiness_purchaseMaster();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
            
            if (CurencyId != "")
                objEntityCommon.CurrencyId = Convert.ToInt32(CurencyId);
            objEntityPurchase.OrgId = Convert.ToInt32(Org_Id);
            objEntityPurchase.CorpId = Convert.ToInt32(Corpt_Id);
            objEntityPurchase.AccountStatus = Convert.ToInt32(Status);
            objEntityPurchase.CancelStatus = Convert.ToInt32(CnclSts);
            objEntityAudit.Organisation_id = Convert.ToInt32(Org_Id);
            objEntityAudit.Corporate_id = Convert.ToInt32(Corpt_Id);
            if (suplier != "--SELECT SUPPLIER --" && suplier!="0")
            {
                objEntityPurchase.LedgerCustomer = Convert.ToInt32(suplier);
            }
            if (fromdt != "")
            {
                objEntityPurchase.FromDate = objCommon.textToDateTime(fromdt);
            }
            if (todt != "")
            {
                objEntityPurchase.ToDate = objCommon.textToDateTime(todt);
            }

            if (StartDate != "")
            {
                objEntityPurchase.StartDate = objCommon.textToDateTime(StartDate);
            }
            if (EndDate != "")
            {
                objEntityPurchase.EndDate = objCommon.textToDateTime(EndDate);
            } if (PurchaseStatus != "")
            {
                objEntityPurchase.ConfirmStatus = Convert.ToInt32(PurchaseStatus); 
            }
            
            objEntityCommon.Organisation_Id = objEntityPurchase.OrgId;
            objEntityCommon.CorporateID = objEntityPurchase.CorpId;
            
            DataTable dtAcntClsDate = objBusiness.ReadAccountClsDate(objEntityCommon);
            DateTime acntClsDate = DateTime.MinValue;
            int YearEndCls = 0;
            if (dtAcntClsDate.Rows.Count > 0)
            {
                YearEndCls = Convert.ToInt32(dtAcntClsDate.Rows[0]["ACCNT_CLS_YEAREND_STS"].ToString());                
                if (dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString() != "")
                {
                    acntClsDate = objCommon.textToDateTime(dtAcntClsDate.Rows[0]["ACCNT_CLS_DATE"].ToString());
                }
            }
            
            DataTable dtCategory = objBusinesspurchase.ReadPurchseOnList(objEntityPurchase);
            int intCount = 0;
            //clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            foreach (DataRow dtRowsIn in dtCategory.Rows)
            {
                string strDelete = "";
                string strEdit = "";
                intCount = intCount + 1;
                string strCount = Convert.ToString(intCount);
                string strId = dtRowsIn[0].ToString();
                int usrId = Convert.ToInt32(strId);
                int intIdLength = dtRowsIn[0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strStatus = "";
                string stsmode;
                string strStatusImg = "";
                string totalAmnt = "";
                string SuplierName = "";
                string NetAmountWithCommaFrm = "";
                string strPrint = "";
                string strReopen = "";
                string strConfirm = "";
                stsmode = dtRowsIn["STATUS"].ToString();
                string cnclusrId = dtRowsIn["PURCHS_CNCL_USR_ID"].ToString();
                
                int confrm = 0;
                confrm = Convert.ToInt32(dtRowsIn["PURCHS_CNFRM_STS"].ToString());
                objEntityAudit.FromDate = objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString());
                DataTable dtAuditClsDate = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);

                string SettleCnt = dtRowsIn["CNT_SETTLE"].ToString();
                if (CnclSts != "1")
                {
                    if (confrm > 0)
                    {
                        strStatusImg = "<td class=\"tdT\"  >Confirmed </td>";
                    }
                    else if (dtRowsIn["PURCHS_REOPEN_STATUS"].ToString() == "1")
                    {
                        if (dtRowsIn["PURCHS_REOPEN_USRID"].ToString() != "")
                        {
                            strStatusImg = "<td class=\"tdT\" >Reopened </td>";
                        }
                    }
                    else
                    {
                        strStatusImg = "<td class=\"tdT\"  >Pending </td>";
                    }
                }

                string strView = "";
                if (CnclSts == "1")
                {
                    strView = "<a class=\"btn act_btn bn4 \" title=\"View\"onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                }
                else
                {
                    if (YearEndCls == 0)
                    {

                        if (confrm > 0)
                        {
                            strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\" disabled=\"true\"  onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\"disabled=\"true\"  class=\"fa fa-trash\"></i></a>";
                            strEdit = "<a class=\"btn act_btn bn4\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";



                            if (ReOpen == "1")
                            {
                                if (SettleCnt == "0")
                                {
                                    if (dtAuditClsDate.Rows.Count > 0)
                                    {

                                        if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                                        {

                                            if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                            {
                                                strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";

                                            }
                                            else
                                            {
                                                strReopen = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\"></i></a>";

                                            }
                                        }
                                        else
                                        {
                                            strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";

                                        }

                                    }

                                    //else if (acntClsDate != "")
                                    //{
                                    if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                                    {

                                        if (AuditSts == "1")
                                        {
                                            strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";

                                        }
                                        else
                                        {
                                            strReopen = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                                        }
                                    }
                                    else
                                    {
                                        strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";

                                    }
                                    //}
                                    //else
                                    //{
                                    //    strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";
                                    //}

                                }
                                else
                                {
                                    strReopen = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" onclick=\"return ReopenNotPossible();\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                                }
                            }
                            else
                            {
                                strReopen = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";

                            }
                            strConfirm = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                        }
                        else
                        {
                            if (dtAuditClsDate.Rows.Count > 0)
                            {

                                if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                                {

                                    if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                    {
                                        strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\"  onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                                    }
                                    else
                                    {
                                        strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\" disabled=\"true\"  onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" disabled=\"true\" class=\"fa fa-trash\"></i></a>";

                                    }
                                }
                                else
                                {
                                    strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\"  onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                                }

                            }

                            //else if (acntClsDate != "")
                            //{
                            if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                            {

                                if (AuditSts == "1")
                                {
                                    strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\"  onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                                }
                                else
                                {
                                    strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\" disabled=\"true\" onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" disabled=\"true\" class=\"fa fa-trash\"></i></a>";
                                }
                            }
                            else
                            {
                                strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\"  onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                            }
                            //}
                            //else
                            //{
                            //    strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\"  onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";
                            //}



                            if (dtAuditClsDate.Rows.Count > 0)
                            {

                                if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                                {

                                    if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                    {
                                        strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";


                                    }
                                    else
                                    {
                                        strEdit = "<a class=\"btn act_btn bn4\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                                    }
                                }
                                else
                                {
                                    strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";


                                }

                            }

                            //else if (acntClsDate != "")
                            //{
                            if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                            {

                                if (AuditSts == "1")
                                {
                                    strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";


                                }
                                else
                                {
                                    strEdit = "<a class=\"btn act_btn bn4\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                                }
                            }
                            else
                            {
                                strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";


                            }
                            //}
                            //else
                            //{
                            //    strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";

                            //}

                            //strPrint = "<td style=\"width:1%;opacity: 0.2;cursor: pointer;  word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Print Invoice\" href=\"javascript:;\" onclick=\"return PrintNotPossible();\"><i style=\"opacity: 0.5\" class=\"fa fa-print\"></i></a>";

                            strReopen = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                            if (Confirm == "1")
                            {
                                if (dtAuditClsDate.Rows.Count > 0)
                                {

                                    if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                                    {

                                        if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                        {
                                            strConfirm = "<a class=\"btn act_btn bn2 \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";


                                        }
                                        else
                                        {
                                            strConfirm = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                                        }
                                    }
                                    else
                                    {
                                        strConfirm = "<a class=\"btn act_btn bn2 \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";


                                    }

                                }

                                //else if (acntClsDate != "")
                                //{
                                if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()))
                                {

                                    if (AuditSts == "1")
                                    {
                                        strConfirm = "<a class=\"btn act_btn bn2 \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";


                                    }
                                    else
                                    {
                                        strConfirm = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                                    }
                                }
                                else
                                {
                                    strConfirm = "<a class=\"btn act_btn bn2 \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";


                                }
                                //}
                                //else
                                //{
                                //    strConfirm = "<a class=\"btn act_btn bn2\" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";

                                //}


                            }
                            else
                            {
                                strConfirm = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                            }

                        }

                    }
                    else
                    {
                        strReopen = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                        strDelete = " <a class=\"btn act_btn bn3\" href=\"javascript:;\" title=\"Delete\" disabled=\"true\"  onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" disabled=\"true\" class=\"fa fa-trash\"></i></a>";
                        strEdit = "<a class=\"btn act_btn bn4\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                        strConfirm = "<a style=\"opacity: 0.5;\" disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                    }                    
                    
                    strPrint = " <a class=\"btn act_btn bn6\" title=\"Print Invoice\" href=\"javascript:;\" onclick=\"return OpenPrint('" + Id + "');\"><i class=\"fa fa-print\"></i></a>";
                }
              
                if (dtRowsIn["PURCHS_NET_TOTAL"].ToString() != "")
                {
                    totalAmnt = dtRowsIn["PURCHS_NET_TOTAL"].ToString();
                }

                if (dtRowsIn["PURCH_SUP_TYP"].ToString() == "0")
                {
                    SuplierName = dtRowsIn["LDGR_NAME"].ToString();
                }
                else
                {
                    SuplierName = dtRowsIn["PURCH_SUP_NAME"].ToString();
                }
                
                NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmnt.ToString(), objEntityCommon);
                
                yield return new Person
                {
                    Ref = dtRowsIn["PURCHS_REF"].ToString(),
                    Date =objCommon.textToDateTime(dtRowsIn["PURCHS_DATE"].ToString()),
                    Suplier = SuplierName,
                    Total = NetAmountWithCommaFrm,
                    Status = strStatusImg,
                    Actions = "<td>" + strView+strEdit + strConfirm + strReopen + strDelete + strPrint + "</td>",
                    //Edit =strEdit,
                    //Confirm = strConfirm,
                    //ReOpen = strReopen,
                    //View = "<td style=\" width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><a class=\"btn btn-xs btn-default \" title=\"View\"onclick='return getdetails(this.href);' href=\"Purchase_master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>",
                    //Delete = strDelete,
                    //Print = strPrint,
                    RefNumSeq = Convert.ToInt32(dtRowsIn["PURCHS_REF_SEQNUM"].ToString())
                    
                };
            }
        }

    }
}
