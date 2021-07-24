<%@ WebHandler Language="C#" Class="dataVIewpaymentclose_List" %>

using System;
using System.Web;
using System.Linq;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using System.Data;

public class dataVIewpaymentclose_List : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //PARAMETERS MANUALLY ADDED
        var Org_Id = context.Request["ORG_ID"];
        var Corpt_Id = context.Request["CORPT_ID"];
        //var Mode = context.Request["MODE"];
        //var BusnsUnit = context.Request["BSNS_UNIT"];
        //var Month = context.Request["MONTH"];
        //var Year = context.Request["YEAR"];
        //var ProcessDate = context.Request["PRCS_DATE"];
        //var Type = context.Request["TYPE"];

        var Month = context.Request["MONTH"];
        var Year = context.Request["YEAR"];
        var IndRnd = context.Request["IND_RND"];
        var Mode = context.Request["MODE"];
        
        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchEmpId = context.Request["sSearch_0"].ToLower();
        var sSearchEmpName = context.Request["sSearch_1"].ToLower();
        var sSearchprocess = context.Request["sSearch_2"].ToLower();
        var sSearchDate = context.Request["sSearch_3"].ToLower();
        var sSearchPaidAmnt = context.Request["sSearch_4"].ToLower();


       
        // Fetch the data from a repository (in my case in-memory)

        var persons = Person.GetPersons(Org_Id, Corpt_Id, Month, Year, IndRnd, Mode);
       
        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
           
           
            if (iSortCol ==1)
            {
                return p.Empname;
            }
            if (iSortCol == 2)
            {
                return p.Process;
            }
            if (iSortCol == 3)
            {
                return p.ClsdDate;
            }
            if (iSortCol == 4)
            {
                return p.Amt;   
            }
            if (iSortCol == 5)
            {
                return p.TotalAmt;
            }
              
            return p.EmpId;
           
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
            //   iTotalDisplayRecords = persons.Count(),
            aaData = persons

            .Where(p => p.EmpId.ToString().ToLower().Contains(sSearchAll) || p.Empname.ToString().ToLower().Contains(sSearchAll) || p.Process.ToString().ToLower().Contains(sSearchAll) || p.ClsdDate.ToString().ToLower().Contains(sSearchAll) || p.Amt.ToLower().ToString().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.EmpId.ToString().ToLower().Contains(sSearchEmpId))  // Search: Avoid Contains() in production
            .Where(p => p.Empname.ToString().ToLower().Contains(sSearchEmpName))
            .Where(p => p.Process.ToString().ToLower().Contains(sSearchprocess))
            .Where(p => p.ClsdDate.ToString().ToLower().Contains(sSearchDate))
            .Where(p => p.Amt.ToString().ToLower().Contains(sSearchPaidAmnt))
            .Select(p => new[] { p.EmpId, p.Empname.ToString(), p.Process, p.ClsdDate, p.Amt.ToString(), p.TotalAmt.ToString() })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.EmpId.ToString().ToLower().Contains(sSearchAll) || p.Empname.ToString().ToLower().Contains(sSearchAll) || p.Process.ToString().ToLower().Contains(sSearchAll) || p.ClsdDate.ToString().ToLower().Contains(sSearchAll) || p.Amt.ToLower().ToString().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.EmpId.ToString().ToLower().Contains(sSearchEmpId))  // Search: Avoid Contains() in production
            .Where(p => p.Empname.ToString().ToLower().Contains(sSearchEmpName))
            .Where(p => p.Process.ToString().ToLower().Contains(sSearchprocess))
            .Where(p => p.ClsdDate.ToString().ToLower().Contains(sSearchDate))
            .Where(p => p.Amt.ToString().ToLower().Contains(sSearchPaidAmnt))
            .Select(p => new[] { p.EmpId, p.Empname.ToString(), p.Process, p.ClsdDate, p.Amt.ToString(), p.TotalAmt.ToString() }).Count()
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
        public string EmpId { get; set; }
        public string Empname{get;set;}
        public string Process { get; set; }
        public string ClsdDate{ get; set; }
        public string Amt { get; set; }
        public string TotalAmt { get; set; }

        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Org_Id, string Corpt_Id, string Month, string Year, string IndRnd, string Mode)
        {

            clsEntityLayer_Payment_Closing objEntityPayment_Closing = new clsEntityLayer_Payment_Closing();
            clsBusinessLayer_payment_Closing objBusinessLayerPayment_Closing = new clsBusinessLayer_payment_Closing();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            DataTable dtlist = new DataTable();
            objEntityPayment_Closing.OrgId = Convert.ToInt32(Org_Id);
            objEntityPayment_Closing.CorprtId = Convert.ToInt32(Corpt_Id);
            if (Month != "--SELECT MONTH--")
            {
                objEntityPayment_Closing.SMonth = Month;
            }
            if (Year != "--SELECT YEAR--")
            {
                objEntityPayment_Closing.Year = Convert.ToInt32(Year);
            }
            objEntityPayment_Closing.Mode = Convert.ToInt32(Mode);
            dtlist = objBusinessLayerPayment_Closing.ReadPayment_paidedList(objEntityPayment_Closing);
                        


          //int cout = 0;
            foreach (DataRow dtRowsIn in dtlist.Rows)
            {
               
                string TableID = dtRowsIn[0].ToString();

                string Amount = "";
                if (dtRowsIn["PAID AMOUNT"].ToString() != "")
                {
                    if (IndRnd == "0")
                    {
                        Amount = Math.Round(Convert.ToDecimal(dtRowsIn["PAID AMOUNT"].ToString()), 2).ToString("0.00") + " " + dtRowsIn["CRNCMST_ABBRV"].ToString();
                    }
                    else
                    {
                        Amount = Math.Round(Convert.ToDecimal(dtRowsIn["PAID AMOUNT"].ToString()), 0).ToString("0.00") + " " + dtRowsIn["CRNCMST_ABBRV"].ToString();
                    }
                  
                }
                string TotalAmount = "";
                if (dtRowsIn["TOTAL AMOUNT"].ToString() != "")
                {
                    //if (IndRnd == "0")
                    //{
                    //    TotalAmount = dtRowsIn["TOTAL AMOUNT"].ToString() + " " + dtRowsIn["CRNCMST_ABBRV"].ToString();
                    //}
                    //else
                    //{
                        TotalAmount = Math.Round(Convert.ToDecimal(dtRowsIn["TOTAL AMOUNT"].ToString()), 0).ToString("0.00") + " " + dtRowsIn["CRNCMST_ABBRV"].ToString();
                    //}
                   
                }
                
                yield return new Person
                {

                    EmpId = dtRowsIn["USR_CODE"].ToString(),
                    Empname = dtRowsIn["EMPLOYEE NAME"].ToString(),
                    Process = dtRowsIn[4].ToString(),
                    ClsdDate = dtRowsIn["CLOSED ADTE"].ToString(),
                    Amt = Amount,
                    TotalAmt = TotalAmount,
                    
                                 
                };
            }
        }

    }
}
