<%@ WebHandler Language="C#" Class="dataVIewDeduction" %>

using System;
using System.Web;
using System.Linq;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using System.Data;

public class dataVIewDeduction : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //PARAMETERS MANUALLY ADDED
        var Org_Id = context.Request["ORG_ID"];
        var Corpt_Id = context.Request["CORPT_ID"];
        var Mode = context.Request["MODE"];
      

        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToUpper(); ;
        var sSearchDoc = context.Request["sSearch_0"].ToUpper();
        var sSearchEmpId = context.Request["sSearch_1"].ToUpper();
        var sSearchName = context.Request["sSearch_2"].ToUpper();
        var sSearchDed = context.Request["sSearch_3"].ToUpper();
        var sSearchAmont = context.Request["sSearch_4"].ToUpper();
        var sSearchAmPaid = context.Request["sSearch_5"].ToUpper();
        var sSearchNoInstl = context.Request["sSearch_6"].ToUpper();
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id, Mode);

        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {

            if (iSortCol == 1)
            {
                return p.Empid;
            }
            if (iSortCol ==2)
            {
                return p.Empname;
            }
            if (iSortCol == 3)
            {
                return p.Deduction;
            }
            if (iSortCol == 4)
            {
                return p.Amount;
            }
            if (iSortCol == 5)
            {
                return p.TOTALPAID;
            }
            if (iSortCol == 6)
            {
                return p.Installmentno;
            }
           
            return p.DocNum;
           
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

            .Where(p => p.DocNum.ToString().ToUpper().Contains(sSearchAll) || p.Empid.ToString().ToUpper().Contains(sSearchAll) || p.Empname.ToString().Contains(sSearchAll) || p.Deduction.ToString().Contains(sSearchAll) || p.Installmentno.ToString().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.DocNum.ToString().ToUpper().Contains(sSearchDoc))  // Search: Avoid Contains() in production
            .Where(p => p.Empid.ToString().ToUpper().Contains(sSearchEmpId))
            .Where(p => p.Empname.ToString().ToUpper().Contains(sSearchName))
            .Where(p => p.Deduction.ToString().ToUpper().Contains(sSearchDed))
            .Where(p => p.Amount.ToString().Contains(sSearchAmont))
            .Where(p => p.TOTALPAID.ToString().Contains(sSearchAmPaid))
            .Where(p => p.Installmentno.ToString().Contains(sSearchNoInstl))
            .Select(p => new[] { p.DocNum.ToString(), p.Empid.ToString(), p.Empname.ToString(), p.Deduction, p.Amount.ToString(), p.TOTALPAID.ToString(), p.Installmentno.ToString(), p.View, p.Delete })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.DocNum.ToString().ToUpper().Contains(sSearchAll) || p.Empid.ToString().ToUpper().Contains(sSearchAll) || p.Empname.ToString().Contains(sSearchAll) || p.Deduction.ToString().Contains(sSearchAll) || p.Installmentno.ToString().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.DocNum.ToString().ToUpper().Contains(sSearchDoc))  // Search: Avoid Contains() in production
            .Where(p => p.Empid.ToString().ToUpper().Contains(sSearchEmpId))
            .Where(p => p.Empname.ToString().ToUpper().Contains(sSearchName))
            .Where(p => p.Deduction.ToString().ToUpper().Contains(sSearchDed))
            .Where(p => p.Amount.ToString().Contains(sSearchAmont))
            .Where(p => p.TOTALPAID.ToString().Contains(sSearchAmPaid))
            .Where(p => p.Installmentno.ToString().Contains(sSearchNoInstl))
            .Select(p => new[] { p.DocNum.ToString(), p.Empid.ToString(), p.Empname.ToString(), p.Deduction, p.Amount.ToString(), p.TOTALPAID.ToString(), p.Installmentno.ToString(), p.View, p.Delete }).Count()
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
        public string DocNum { get; set; }
        public string Empname{get;set;}
      
        public string Deduction { get; set; }
        public decimal  Amount { get; set; }
        public decimal PaidAmount { get; set; }
        public string Installmentno { get; set; }
        public string View { get; set; }
        public string Delete { get; set; }
        public decimal TOTALPAID { get; set; }
        public string Empid { get; set; }
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string Mode)
        {
           
            ClsEntityEmployeeDeduction objEntityEmployeeDeduction = new ClsEntityEmployeeDeduction();
            clsBusinessLayerEmployeeDeductn objBusinessLayerEmployeeDeductn = new clsBusinessLayerEmployeeDeductn();





            objEntityEmployeeDeduction.CorpId = Convert.ToInt32(Corpt_Id);
            objEntityEmployeeDeduction.orgid = Convert.ToInt32(Org_Id);
            objEntityEmployeeDeduction.Mode = Convert.ToInt32(Mode);

            DataTable dtlist = objBusinessLayerEmployeeDeductn.ReadDeductionList(objEntityEmployeeDeduction);
            clsCommonLibrary objCommon = new clsCommonLibrary();

            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsCommonLibrary.CORP_GLOBAL[] arrEnumer = {  clsCommonLibrary.CORP_GLOBAL.GN_MNEY_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.GN_UNIT_DECIMAL_CNT,
                                                           clsCommonLibrary.CORP_GLOBAL.DEFLT_CURNCY_MST_ID
                                                              };
            DataTable dtCorpDetail = new DataTable();
            dtCorpDetail = objBusiness.LoadGlobalDetail(arrEnumer, Convert.ToInt32(Corpt_Id));
            string hiddenDecimalCount;
            string hiddenDfltCurrencyMstrId;
            if (dtCorpDetail.Rows.Count > 0)
            {
                objEntityCommon.CorporateID = Convert.ToInt32(Corpt_Id);
                hiddenDecimalCount= dtCorpDetail.Rows[0]["GN_MNEY_DECIMAL_CNT"].ToString();
                hiddenDfltCurrencyMstrId = dtCorpDetail.Rows[0]["DEFLT_CURNCY_MST_ID"].ToString();
            }

           
          //int cout = 0;
            foreach (DataRow dtRowsIn in dtlist.Rows)
            {
               
                string TableID = dtRowsIn[0].ToString();
                string TOTALPAID = dtRowsIn["TOTALPAID"].ToString();

                string del = "<td style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button runat=\"server\" class=\"btn btn-xs btn-default\" title=\"DELETE\" onclick=\"return DeleteNotPosble();\"><i style=\"opacity:0.3;\" class=\"fa fa-trash\"></i></button>";

                if (TOTALPAID == "")
                {
                    TOTALPAID = "0.0";
                    del = "<td style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button runat=\"server\" class=\"btn btn-xs btn-default\" title=\"DELETE\" onclick=\"return DeleteRow(" + TableID + ");\"><i class=\"fa fa-trash\"></i></button>";
                }
             TOTALPAID=   objBusiness.AddCommasForNumberSeperation(TOTALPAID,objEntityCommon);
                
          string  Amount = dtRowsIn["EMPDEDTN_AMOUNT"].ToString();
       
          if (Mode == "0")
          {
              yield return new Person
              {

                  DocNum = dtRowsIn["EMPDEDTN_DOC_NO"].ToString(),
                  Deduction = dtRowsIn["EMPDEDTN_DEDCTNID"].ToString() == "1" ? "Loan" : dtRowsIn["EMPDEDTN_DEDCTNID"].ToString() == "2" ? "Advance Amount" : "Other",

                  PaidAmount = Convert.ToDecimal(dtRowsIn["EMPDEDTN_DEDCTNID"].ToString()),
                  TOTALPAID = Convert.ToDecimal(TOTALPAID),
                  Amount = Convert.ToDecimal(dtRowsIn["EMPDEDTN_AMOUNT"].ToString()),
                  Installmentno = dtRowsIn["EMPDEDTN_INSTLMNTNO"].ToString(),
                  Empname = dtRowsIn["EMPNAME"].ToString(),
                  Empid = dtRowsIn["USR_CODE"].ToString(),
                  //View = "<span class=\"responsiveExpander\"></span><img title=\"View\"  onclick=\"return ViewRow(" + TableID + ");\" style=\"cursor:pointer;margin-left:0%;\" src='/Images/Icons/view.png' />",
                  View = "<td style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button runat=\"server\" class=\"btn btn-xs btn-default\" title=\"VIEW\" onclick=\"return ViewRow(" + TableID + ",0);\"><i class=\"fa fa-eye\"></i></button>",
                  Delete = del,


              };
          }
          else
          {
              yield return new Person
              {

                  DocNum = dtRowsIn["EMPDEDTN_DOC_NO"].ToString(),
                  Deduction = dtRowsIn["EMPDEDTN_DEDCTNID"].ToString() == "1" ? "Loan" : dtRowsIn["EMPDEDTN_DEDCTNID"].ToString() == "2" ? "Advance Amount" : "Other",

                  PaidAmount = Convert.ToDecimal(dtRowsIn["EMPDEDTN_DEDCTNID"].ToString()),
                  TOTALPAID = Convert.ToDecimal(TOTALPAID),
                  Amount = Convert.ToDecimal(dtRowsIn["EMPDEDTN_AMOUNT"].ToString()),
                  Installmentno = dtRowsIn["EMPDEDTN_INSTLMNTNO"].ToString(),
                  Empid = dtRowsIn["USR_CODE"].ToString(),
                  Empname = dtRowsIn["EMPNAME"].ToString(),
                 
                  //View = "<span class=\"responsiveExpander\"></span><img title=\"View\"  onclick=\"return ViewRow(" + TableID + ");\" style=\"cursor:pointer;margin-left:0%;\" src='/Images/Icons/view.png' />",
                  View = "<td style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button runat=\"server\" class=\"btn btn-xs btn-default\" title=\"VIEW\" onclick=\"return ViewRow(" + TableID + ",1);\"><i class=\"fa fa-eye\"></i></button>",
               


              };

          }
            }
        }

    }
}
