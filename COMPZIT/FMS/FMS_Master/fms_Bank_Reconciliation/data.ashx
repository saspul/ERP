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
        // var EnableEdit = context.Request["ENABLEDIT"];
        //  var EnableDelete = context.Request["ENABLEDELETE"];  
        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        //  var sSearchRef = context.Request["sSearch_1"].ToLower();
        var sSearchAcc = context.Request["sSearch_0"].ToLower();
       // var sSearchVouch = context.Request["sSearch_3"].ToLower();
        var sSearchAmt = context.Request["sSearch_1"].ToLower();


        //   var sSearchSts = context.Request["sSearch_2"].ToLower();
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id, AccountId, LedgerId, fromdt, Todt, CnclSts);
        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {

            if (iSortCol == 0)
            {
                return p.REF;
            }

            if (iSortCol == 1)
            {
                return p.AccountName;
            }
       
            if (iSortCol == 2)
            {
                return p.Total;
            }
            return p.AccountName;
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
            iTotalDisplayRecords = persons.Count(),
            aaData = persons

            .Where(p => p.AccountName.ToString().ToLower().Contains(sSearchAll) || p.Total.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
                //  .Where(p => p.REF.ToString().ToLower().Contains(sSearchRef))  // Search: Avoid Contains() in production
             .Where(p => p.AccountName.ToString().ToLower().Contains(sSearchAcc))
           //  .Where(p => p.VoucherTyp.ToString().ToLower().Contains(sSearchVouch))
             .Where(p => p.Total.ToString().ToLower().Contains(sSearchAmt))
                //.Where(p => p.Status.ToString().ToLower().Contains(sSearchSts))
            .Select(p => new[] { p.AccountName, p.Total, p.Acions, p.Amount })
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
        public string Total { get; set; }
        public string Acions { get; set; }
        public string Amount { get; set; }
        
        //public string Edit { get; set; }
        //public string View { get; set; }
        //public string Delete { get; set; }
        //public string Recall { get; set; }
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string AccountId, string LedgerId, string fromdt, string Todt, string CnclSts)
        {
            clsBusiness_BankReconciliation objBussiness = new clsBusiness_BankReconciliation();
            clsEntityBankReconciliation ObjEntityRequest = new clsEntityBankReconciliation();
            clsEntityCommon objEntityCommon = new clsEntityCommon();

            clsCommonLibrary ObjCommonlib = new clsCommonLibrary();

            ObjEntityRequest.Organisation_id = Convert.ToInt32(Org_Id);
            ObjEntityRequest.Corporate_id = Convert.ToInt32(Corpt_Id);
            ObjEntityRequest.Status = Convert.ToInt32(CnclSts);
            int intCorpId = 0;
            if (Corpt_Id != "")
                intCorpId = Convert.ToInt32(Corpt_Id);
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




            ObjEntityRequest.VoucherTyp = Convert.ToInt32(AccountId);
            if (fromdt != "")
            {
                ObjEntityRequest.FromDate = ObjCommonlib.textToDateTime(fromdt);
            }
            if (Todt != "")
            {
                ObjEntityRequest.ToDate = ObjCommonlib.textToDateTime(Todt);
            }
            DataTable dtCategory = objBussiness.BankReconciliation_List(ObjEntityRequest);
            int intCount = 0;

            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            foreach (DataRow dtRowsIn in dtCategory.Rows)
            {
                string strDelete = "", strVoucherTyp;
                string strEditView = "";
                intCount = intCount + 1;
                string strCount = Convert.ToString(intCount);
                string strId = dtRowsIn[0].ToString();
                int usrId = Convert.ToInt32(strId);
                int intIdLength = dtRowsIn[0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strNetAmountWithComma = "";
                decimal NetAmount = 0;
                string strsurAbrv = "";
                NetAmount = Convert.ToDecimal(dtRowsIn["VOCHR_AMT"].ToString());
                if (NetAmount < 0)
                {
                    string srDBalance = Convert.ToString(NetAmount);
                    srDBalance = srDBalance.Substring(1);
                    NetAmount = Convert.ToDecimal(srDBalance);
                }
                if (dtRowsIn["VOCHR_STS"].ToString() != "")
                {
                    if (dtRowsIn["VOCHR_STS"].ToString() == "0")
                    {
                        strsurAbrv = "DR";
                    }
                    else if (dtRowsIn["VOCHR_STS"].ToString() == "1")
                    {
                        strsurAbrv = "CR";
                    }
                }

            
                strNetAmountWithComma = objBusiness.AddCommasForNumberSeperation(NetAmount.ToString(), objEntityCommon);
                //string strActions="<td> <div class=\"btn_stl1\">";
                if (CnclSts == "0")
                {
                    strEditView =  "<td> <div class=\"btn_stl1\"><button class=\"btn act_btn bn1\" title=\"Edit\"  onclick=\"return OpenReconView('" + Id + "');\" ><i class=\"fa fa-edit\"></i></button></div></td>";
                }
                else
                {
                    strEditView = "<td> <div class=\"btn_stl1\"> <a class=\"btn act_btn bn3 \" title=\"Recall\" href=\"javascript:;\" onclick=\"return Recall('" + Id + "');\"><i class=\"fa fa-repeat\" ></i></a></div></td>";
                }
                
                
              
                yield return new Person
                {
                   // SL = strCount,
                    AccountName = dtRowsIn["LDGR_NAME"].ToString(),
                    Total = strNetAmountWithComma + " " + strsurAbrv,
                    Acions = strEditView,
                    Amount = NetAmount.ToString(),
                   
                };
            }
        }
    }
}
