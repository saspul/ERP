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
        var customerId = context.Request["CUSTOMER"];
        var fromdt = context.Request["FROMDT"];
        var Todt = context.Request["TODAT"];
        var EnableEdit = context.Request["ENABLEDIT"];
        var EnableDelete = context.Request["ENABLEDELETE"];
        var AcntClsDate = context.Request["ACNTCLSDT"];
        var StartDate = context.Request["STARTDATE"];
        var EndDate = context.Request["ENDDATE"];
        var AcntPrvsn = context.Request["AUDITPRVSN"];
        var ReOpen = context.Request["REOPEN"];
        var EnableAudit = context.Request["ENABLEAUDIT"];
        var SalesSts = context.Request["SALES_STS"];
        var CurrencyId = context.Request["CURRENCY"];
        
        var Confirm = context.Request["CONFIRM"];
        var UserId = context.Request["USERID"];
        
        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchRef = context.Request["sSearch_0"].ToLower();
        var sSearchFrm = context.Request["sSearch_1"].ToLower();
        var sSearchSup1 = context.Request["sSearch_2"].ToLower();
        var sSearchTotal = context.Request["sSearch_3"].ToLower();


        //   var sSearchSts = context.Request["sSearch_2"].ToLower();
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id, Status, CnclSts, customerId, fromdt, Todt, StartDate, EndDate, ReOpen, AcntClsDate, AcntPrvsn, EnableAudit, SalesSts, Confirm, CurrencyId, UserId);
        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
            if (iSortCol == 0)
            {
                return p.ID;
            }
            if (iSortCol == 1)
            {
                return p.Date;
            } if (iSortCol == 2)
            {
                return p.Customer;
            }
            if (iSortCol == 3)
            {
                return p.DecTotl;
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
        // prepare an anonymous object for JSON serialization
        var result = new
        {
            iTotalRecords = persons.Count(),
           // iTotalDisplayRecords = persons.Count(),
            aaData = persons

            .Where(p => p.Ref.ToString().ToLower().Contains(sSearchAll) || p.Date.ToString().ToLower().Contains(sSearchAll) || p.Customer.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.Ref.ToString().ToLower().Contains(sSearchRef))  // Search: Avoid Contains() in production
            .Where(p => p.Date.ToString().ToLower().Contains(sSearchFrm))
            .Where(p => p.Customer.ToString().ToLower().Contains(sSearchSup1))
            .Where(p => p.DecTotl.ToString().ToLower().Contains(sSearchTotal))
        

            //.Where(p => p.Status.ToString().ToLower().Contains(sSearchSts))
            .Select(p => new[] { p.Ref, p.Date.ToString("dd-MM-yyyy"), p.Customer, p.Total, p.Status, p.Actions, p.ID.ToString(), p.DecTotl.ToString() })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
             iTotalDisplayRecords = persons

            .Where(p => p.Ref.ToString().ToLower().Contains(sSearchAll) || p.Date.ToString().ToLower().Contains(sSearchAll) || p.Customer.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.Ref.ToString().ToLower().Contains(sSearchRef))  // Search: Avoid Contains() in production
            .Where(p => p.Date.ToString().ToLower().Contains(sSearchFrm))
            .Where(p => p.Customer.ToString().ToLower().Contains(sSearchSup1))
            .Where(p => p.DecTotl.ToString().ToLower().Contains(sSearchTotal))


            //.Where(p => p.Status.ToString().ToLower().Contains(sSearchSts))
            .Select(p => new[] { p.Ref, p.Date.ToString("dd-MM-yyyy"), p.Customer, p.Total, p.Status, p.Actions, p.DecTotl.ToString() }).Count()
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
        public string Customer { get; set; }
        public string Total { get; set; }
        public string Status { get; set; }
        public string Actions { get; set; }
        public int ID { get; set; }
        public decimal DecTotl { get; set; }

        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string Status, string CnclSts, string Customer, string fromdt, string todt, string startDate, string EndDate, string ReOpen, string AcntClsDate, string AcntPrvsn, string EnableAudit, string SalesSts, string Confirm, string CurrencyId, string UserId)
        {
            clsCommonLibrary objCommon = new clsCommonLibrary();
            clsBusinessSales objBusinessSales = new clsBusinessSales();
            clsEntitySales objEntity = new clsEntitySales();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            cls_Business_Audit_Closeing objEmpAuditCls = new cls_Business_Audit_Closeing();
            clsEntityLayerAuditClosing objEntityAudit = new clsEntityLayerAuditClosing();
            clsEntityCommon objentcommn = new clsEntityCommon();
            if (CurrencyId != "")
                objEntityCommon.CurrencyId = Convert.ToInt32(CurrencyId);
            objEntity.Organisation_id = Convert.ToInt32(Org_Id);
            objEntity.Corporate_id = Convert.ToInt32(Corpt_Id);
            objEntity.Status = Convert.ToInt32(Status);
            objEntity.SalesSts = Convert.ToInt32(SalesSts);
            objEntityAudit.Organisation_id = Convert.ToInt32(Org_Id);
            objEntityAudit.Corporate_id = Convert.ToInt32(Corpt_Id);
            objEntity.cnclStatus = Convert.ToInt32(CnclSts);
            objentcommn.Organisation_Id = Convert.ToInt32(Org_Id);
            objentcommn.CorporateID = Convert.ToInt32(Corpt_Id);
            if (Customer != "--SELECT CUSTOMER--")
            {
                objEntity.LedgerId = Convert.ToInt32(Customer);
            }
            if (fromdt != "")
            {
                objEntity.FromPeriod = objCommon.textToDateTime(fromdt);
            }
            if (todt != "")
            {
                objEntity.ToPeriod = objCommon.textToDateTime(todt);
            }
            if (startDate != "")
            {
                objEntity.StartDate = objCommon.textToDateTime(startDate);
            }
            if (EndDate != "")
            {
                objEntity.EndDate = objCommon.textToDateTime(EndDate);
            }

            DataTable dtAcntClsDate = objBusiness.ReadAccountClsDate(objentcommn);
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
            DataTable dtCategory = objBusinessSales.ReadSalesDetailsList(objEntity);
            int intCount = 0;
           
            string strRandom = objCommon.Random_Number();
            foreach (DataRow dtRowsIn in dtCategory.Rows)
            {
                string strConfirm = "";
                string strPrint = "";
                string strDelete = "";
                intCount = intCount + 1;
                string strEdit = "";
                string strCount = Convert.ToString(intCount);
                
                string strId = dtRowsIn[0].ToString();
                int usrId = Convert.ToInt32(strId);
                int intIdLength = dtRowsIn[0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                
                string strStatus = "";
                string stsmode;
                string totalAmnt = "";
                string strStatusImg = "";
                string NetAmountWithCommaFrm = "";
                string CustmrName = "";
                stsmode = dtRowsIn["STATUS"].ToString();
                string cnclusrId = dtRowsIn["SALES_CNCL_USR_ID"].ToString();
                int Category = 0;
                string strReopen = "";
                string strRefNo = "";
                decimal DecimalTotl = 0;
                string StrTotl = "";
                // int Category =Convert.ToInt32(dtRowsIn["LDGR_ACCOUNT"].ToString());
              string confrm = "";
              confrm =dtRowsIn ["SALES_CNFRM_STS"].ToString();
              objEntityAudit.FromDate = objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString());
              DataTable dtAuditClsDate = objEmpAuditCls.CheckAuditClosingDate(objEntityAudit);

              string SettleCnt = dtRowsIn["CNT_SETTLE"].ToString();
              if (CnclSts != "1")
              {
                  if (confrm == "1")
                  {
                      strStatusImg = "<td  id=\"tdstatus\">CONFIRMED </td>";
                  }
                  else if (dtRowsIn["SALES_REOPEN_STATUS"].ToString() == "1")
                  {
                      if (dtRowsIn["SALES_REOPEN_USRID"].ToString() != "")
                      {
                          strStatusImg = "<td id=\"tdstatus\" >REOPENED </td>";
                      }
                  }
                  else
                  {
                      strStatusImg = "<td  id=\"tdstatus\">PENDING </td>";
                  }
              }
              string strView = "";
              if (CnclSts == "1")
              {
                  strView = "<a class=\"btn act_btn bn4\" title=\"View\"onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
              }
              else
              {
                  if (YearEndCls == 0)
                  {

                      if (confrm == "1")
                      {
                          strDelete = "<a class=\"btn act_btn bn3\" disabled=\"true\" title=\"Delete\" href=\"javascript:;\"  onclick=\"return CancelNotPossible();\"><i class=\"fa fa-trash\"></i></a>";
                          strPrint = "<a class=\"btn act_btn bn6\" title=\"Print Invoice\" href=\"javascript:;\" onclick=\"return OpenPrint('" + Id + "');\"><i class=\"fa fa-print\"></i></a>";
                          strEdit = "<a class=\"btn act_btn bn4 \" title=\"View\"onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                          if (ReOpen == "1")
                          {
                              if (SettleCnt == "0")
                              {
                                  if (dtAuditClsDate.Rows.Count > 0)
                                  {

                                      if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                                      {

                                          if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                          {
                                              strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";

                                          }
                                          else
                                          {
                                              strReopen = "<a disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";

                                          }
                                      }
                                      else
                                      {
                                          strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";

                                      }

                                  }

                                  else if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                                  {
                                      if (AcntPrvsn == "Active")
                                      {
                                          strReopen = "<a class=\"btn act_btn bn2 \" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";
                                      }
                                      else
                                      {
                                          strReopen = "<a disabled=\"true\" class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                                      }
                                  }
                                  else
                                  {
                                      strReopen = "<a class=\"btn act_btn bn2\" title=\"REOPEN\" href=\"javascript:;\" onclick=\"return ReOpenByID('" + Id + "');\"><i class=\"fa fa-unlock\" ></i></a>";
                                  }
                              }
                              else
                              {
                                  strReopen = "<a disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" onclick=\"return ReopenNotPossible();\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                              }
                          }
                          else
                          {
                              strReopen = "<a disabled=\"true\" class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                          }



                          strConfirm = "<a disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";



                      }
                      else
                      {
                          if (dtAuditClsDate.Rows.Count > 0)
                          {

                              if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                              {

                                  if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                  {
                                      strDelete = " <a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                                  }
                                  else
                                  {
                                      strDelete = " <a class=\"btn act_btn bn3\"  disabled=\"true\" title=\"Delete\" href=\"javascript:;\"  onclick=\"return CancelNotPossible();\"><i disabled=\"true\" class=\"fa fa-trash\"></i></a>";

                                  }
                              }
                              else
                              {
                                  strDelete = "<a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";

                              }

                          }

                          else if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                          {
                              if (AcntPrvsn == "Active")
                              {
                                  strDelete = "<a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";
                              }
                              else
                              {
                                  strDelete = " <a class=\"btn act_btn bn3\" disabled=\"true\" title=\"Delete\" href=\"javascript:;\"  onclick=\"return CancelNotPossible();\"><i disabled=\"true\" class=\"fa fa-trash\"></i></a>";
                              }
                          }
                          else
                          {
                              strDelete = " <a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";
                          }
                          strPrint = " <a class=\"btn act_btn bn6\" title=\"Print Invoice\" href=\"javascript:;\" onclick=\"return OpenPrint('" + Id + "');\"><i class=\"fa fa-print\"></i></a>";
                          if (dtAuditClsDate.Rows.Count > 0)
                          {

                              if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                              {

                                  if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                  {
                                      strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";

                                  }
                                  else
                                  {
                                      strEdit = "<a class=\"btn act_btn bn4\" title=\"View\"onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";

                                  }
                              }
                              else
                              {
                                  strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";

                              }

                          }

                          else if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                          {
                              if (AcntPrvsn == "Active")
                              {
                                  strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                              }
                              else
                              {
                                  strEdit = "<a class=\"btn act_btn bn4 \" title=\"View\"onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                              }
                          }
                          else
                          {
                              strEdit = "<a class=\"btn act_btn bn1\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                          }
                          strReopen = "<a disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                          if (Confirm == "1")
                          {
                              if (dtAuditClsDate.Rows.Count > 0)
                              {

                                  if (objCommon.textToDateTime(dtAuditClsDate.Rows[0]["AUDIT_CLS_DATE"].ToString()) >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                                  {

                                      if (EnableAudit == Convert.ToInt32(clsCommonLibrary.StatusAll.Active).ToString())
                                      {
                                          strConfirm = "<a class=\"btn act_btn bn2  \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";

                                      }
                                      else
                                      {
                                          strConfirm = "<a disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                                      }
                                  }
                                  else
                                  {
                                      strConfirm = "<a class=\"btn act_btn bn2  \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";

                                  }

                              }

                              else if (acntClsDate >= objCommon.textToDateTime(dtRowsIn["SALES_DATE"].ToString()))
                              {
                                  if (AcntPrvsn == "Active")
                                  {
                                      strConfirm = "<a class=\"btn act_btn bn2 \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";
                                  }
                                  else
                                  {
                                      strConfirm = "<a disabled=\"true\" class=\"btn act_btn bn2  \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                                  }
                              }
                              else
                              {
                                  strConfirm = "<a class=\"btn act_btn bn2  \" title=\"CONFIRM\" href=\"javascript:;\" onclick=\"return ConfirmByID('" + Id + "');\"><i class=\"fa fa-check\" ></i></a>";
                              }



                          }
                          else
                          {
                              strConfirm = "<a disabled=\"true\" class=\"btn act_btn bn2  \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";

                          }
                      }

                  }
                  else
                  {
                      strConfirm = "<a disabled=\"true\" class=\"btn act_btn bn2  \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                      strEdit = "<a class=\"btn act_btn bn4 \" title=\"View\"onclick='return getdetails(this.href);' href=\"fms_Sales_Master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                      strDelete = " <a class=\"btn act_btn bn3\" disabled=\"true\" title=\"Delete\" href=\"javascript:;\"  onclick=\"return CancelNotPossible();\"><i disabled=\"true\" class=\"fa fa-trash\"></i></a>";
                      strReopen = "<a disabled=\"true\" class=\"btn act_btn bn2\" href=\"javascript:;\" title=\"REOPEN\" " + "><i class=\"fa fa-unlock\" ></i></a>";
                      strPrint = "<a class=\"btn act_btn bn6\" title=\"Print Invoice\" href=\"javascript:;\" onclick=\"return OpenPrint('" + Id + "');\"><i class=\"fa fa-print\"></i></a>";
                  }
                  
                  
                  if (stsmode == "INACTIVE")
                  {
                      strConfirm = "<a disabled=\"true\" class=\"btn act_btn bn2 \" href=\"javascript:;\" title=\"CONFIRM\" " + "><i class=\"fa fa-check\" ></i></a>";
                  }
              }
                if (dtRowsIn["SALES_NET_TOTAL"].ToString() != "")
                {
                    totalAmnt = dtRowsIn["SALES_NET_TOTAL"].ToString();
                    DecimalTotl = Convert.ToDecimal(dtRowsIn["SALES_NET_TOTAL"].ToString());
                    
                    
                    
                }

                
                NetAmountWithCommaFrm = objBusiness.AddCommasForNumberSeperation(totalAmnt.ToString(), objEntityCommon);



                if (dtRowsIn["SALES_REF_NEXTNUM"].ToString() != "")
                {
                    strRefNo = "<td =id=\"sdggfgdfg\" style=\"display:none;\">  " + dtRowsIn["SALES_REF_NEXTNUM"].ToString() + " </td>";
                }

                if (dtRowsIn["SALES_CUST_TYP"].ToString() == "0")
                {
                    CustmrName = dtRowsIn["LDGR_NAME"].ToString();
                }
                else
                {
                    CustmrName = dtRowsIn["SALES_CUST_NAME"].ToString();  
                }
                StrTotl = "<td =id=\"sdggfgdfg\" style=\"display:none;\">  " + dtRowsIn["SALES_NET_TOTAL"].ToString() + " </td>";
                int strnn=Convert.ToInt32(dtRowsIn["SALES_REF_NEXTNUM"].ToString());
                yield return new Person
                {
                    Ref =     "<td > "+  dtRowsIn["SALES_REF"].ToString()+"</td>",
                    Date = objCommon.textToDateTime( dtRowsIn["SALES_DATE"].ToString()),
                    Customer = "<td > " +CustmrName+ "</td>",
                    Total = "<td > " + NetAmountWithCommaFrm + "</td>",
                    Status = strStatusImg,
                    Actions = "<td>"+strView + strEdit + strConfirm + strReopen + strDelete + strPrint+"</td>",
                    ID =Convert.ToInt32(dtRowsIn["SALES_REF_NEXTNUM"].ToString()),
                    DecTotl = DecimalTotl,
                 
                };
            }
        }

    }
}
