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
       
      

        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"];
        var sSearchDay = context.Request["sSearch_0"];
        var sSearchDate = context.Request["sSearch_1"];
        var sSearchNoEmp = context.Request["sSearch_2"];
        var sSearchFile = context.Request["sSearch_3"];
       
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id);

        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
           
           
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
            //  iTotalDisplayRecords = persons.Count(),
            aaData = persons

            .Where(p => p.DocNum.ToString().Contains(sSearchAll) || p.Empname.ToString().Contains(sSearchAll) || p.Deduction.ToString().Contains(sSearchAll) || p.Installmentno.ToString().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.DocNum.ToString().Contains(sSearchDay))  // Search: Avoid Contains() in production
            .Where(p => p.Empname.ToString().Contains(sSearchDate))
            .Where(p => p.Deduction.ToString().Contains(sSearchNoEmp))
            .Where(p => p.Amount.ToString().Contains(sSearchFile))
            .Select(p => new[] { p.DocNum, p.Empname.ToString(), p.Deduction, p.Amount, p.TOTALPAID, p.Installmentno, p.View })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.DocNum.ToString().Contains(sSearchAll) || p.Empname.ToString().Contains(sSearchAll) || p.Deduction.ToString().Contains(sSearchAll) || p.Installmentno.ToString().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.DocNum.ToString().Contains(sSearchDay))  // Search: Avoid Contains() in production
            .Where(p => p.Empname.ToString().Contains(sSearchDate))
            .Where(p => p.Deduction.ToString().Contains(sSearchNoEmp))
            .Where(p => p.Amount.ToString().Contains(sSearchFile))
            .Select(p => new[] { p.DocNum, p.Empname.ToString(), p.Deduction, p.Amount, p.TOTALPAID, p.Installmentno, p.View }).Count()
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
        public string Amount { get; set; }
        public string PaidAmount { get; set; }
        public string Installmentno { get; set; }
        public string View { get; set; }
        public string TOTALPAID { get; set; }
        
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id)
        {
           
            ClsEntityEmployeeDeduction objEntityEmployeeDeduction = new ClsEntityEmployeeDeduction();
            clsBusinessLayerEmployeeDeductn objBusinessLayerEmployeeDeductn = new clsBusinessLayerEmployeeDeductn();





            objEntityEmployeeDeduction.CorpId = Convert.ToInt32(Corpt_Id);
            objEntityEmployeeDeduction.orgid = Convert.ToInt32(Org_Id);

            DataTable dtlist = objBusinessLayerEmployeeDeductn.ReadDeductionList(objEntityEmployeeDeduction);



          //int cout = 0;
            foreach (DataRow dtRowsIn in dtlist.Rows)
            {
               
                string TableID = dtRowsIn[0].ToString();
               
                yield return new Person
                {

                    DocNum = dtRowsIn["EMPDEDTN_DOC_NO"].ToString(),
                    Deduction = dtRowsIn["EMPDEDTN_DEDCTNID"].ToString() == "1" ? "Loan" :dtRowsIn["EMPDEDTN_DEDCTNID"].ToString() == "2"? "Advance Amount":"Other",
                    
                    PaidAmount = dtRowsIn["EMPDEDTN_DEDCTNID"].ToString(),
                    TOTALPAID = dtRowsIn["TOTALPAID"].ToString(),
                    Amount = dtRowsIn["EMPDEDTN_AMOUNT"].ToString(),
                    Installmentno = dtRowsIn["EMPDEDTN_INSTLMNTNO"].ToString(),
                    Empname = dtRowsIn["EMPNAME"].ToString(),
                    //View = "<span class=\"responsiveExpander\"></span><img title=\"View\"  onclick=\"return ViewRow(" + TableID + ");\" style=\"cursor:pointer;margin-left:0%;\" src='/Images/Icons/view.png' />",
                    View = "<td style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button runat=\"server\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" onclick=\"ViewRow(" + TableID + ");\"><i class=\"fa fa-eye\"></i></button>",

                
                
                };
            }
        }

    }
}
