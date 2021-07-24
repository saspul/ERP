<%@ WebHandler Language="C#" Class="dataVIewpaymentclose" %>

using System;
using System.Web;
using System.Linq;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using System.Data;

public class dataVIewpaymentclose : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //PARAMETERS MANUALLY ADDED
        var Org_Id = context.Request["ORG_ID"];
        var Corpt_Id = context.Request["CORPT_ID"];
        var Mode = context.Request["MODE"];
        var BusnsUnit = context.Request["BSNS_UNIT"];
        var Month = context.Request["MONTH"];
        var Year = context.Request["YEAR"];
        var ProcessDate = context.Request["PRCS_DATE"];
        var Type = context.Request["TYPE"];
        var IndRnd = context.Request["IND_RND"];
        
      

        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchEmpId = context.Request["sSearch_0"].ToLower();
        var sSearchEmpName = context.Request["sSearch_1"].ToLower();
        var sSearchDesg = context.Request["sSearch_2"].ToLower();
        var sSearchTotAmnt = context.Request["sSearch_3"].ToLower();
        var sSearchPaidAmnt = context.Request["sSearch_4"].ToLower();
       
        // Fetch the data from a repository (in my case in-memory)

        var persons = Person.GetPersons(Corpt_Id, Org_Id, Mode, BusnsUnit, Month, Year, ProcessDate, Type, IndRnd);
       
        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
           
           
            if (iSortCol ==1)
            {
                return p.Empname;
            }
            if (iSortCol == 2)
            {
                return p.Designation;
            }
            if (iSortCol == 3)
            {
                return p.TotalAmt;
            }
            if (iSortCol == 4)
            {
                return p.PaidAmt;
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
            // iTotalDisplayRecords = persons.Count(),
            aaData = persons

            .Where(p => p.EmpId.ToString().ToLower().Contains(sSearchAll) || p.Empname.ToString().ToLower().Contains(sSearchAll) || p.Designation.ToString().ToLower().Contains(sSearchAll) || p.TotalAmt.ToString().ToLower().Contains(sSearchAll) || p.PaidAmt.ToLower().ToString().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.EmpId.ToString().ToLower().Contains(sSearchEmpId))  // Search: Avoid Contains() in production
            .Where(p => p.Empname.ToString().ToLower().Contains(sSearchEmpName))
            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesg))
            .Where(p => p.TotalAmt.ToString().ToLower().Contains(sSearchTotAmnt))
            .Where(p => p.PaidAmt.ToString().ToLower().Contains(sSearchPaidAmnt))
            .Select(p => new[] { p.EmpId, p.Empname.ToString(), p.Designation, p.TotalAmt, p.PaidAmt, p.Close })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),

            iTotalDisplayRecords = persons

            .Where(p => p.EmpId.ToString().ToLower().Contains(sSearchAll) || p.Empname.ToString().ToLower().Contains(sSearchAll) || p.Designation.ToString().ToLower().Contains(sSearchAll) || p.TotalAmt.ToString().ToLower().Contains(sSearchAll) || p.PaidAmt.ToLower().ToString().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.EmpId.ToString().ToLower().Contains(sSearchEmpId))  // Search: Avoid Contains() in production
            .Where(p => p.Empname.ToString().ToLower().Contains(sSearchEmpName))
            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesg))
            .Where(p => p.TotalAmt.ToString().ToLower().Contains(sSearchTotAmnt))
            .Where(p => p.PaidAmt.ToString().ToLower().Contains(sSearchPaidAmnt))
            .Select(p => new[] { p.EmpId, p.Empname.ToString(), p.Designation, p.TotalAmt, p.PaidAmt, p.Close }).Count()
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
        public string Designation { get; set; }
        public string TotalAmt { get; set; }
        public string PaidAmt { get; set; }
        public string Close { get; set; }
        
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id,string Mode,string BusnsUnit,string Month,string Year,string ProcessDate,string Type,string IndRnd)
        {

            clsEntityLayer_Payment_Closing objEntityEmployeeDeduction = new clsEntityLayer_Payment_Closing();
            clsBusinessLayer_payment_Closing objBusinessLayerEmployeeDeductn = new clsBusinessLayer_payment_Closing();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            DataTable dtlist = new DataTable();
          
            if (Mode != "0")
            
            {
                objEntityEmployeeDeduction.CorprtId = Convert.ToInt32(Corpt_Id);
                objEntityEmployeeDeduction.OrgId = Convert.ToInt32(Org_Id);
                if (Month != "--SELECT MONTH--")
                {
                    objEntityEmployeeDeduction.Month = Convert.ToInt32(Month);
                }
                if (Year != "--SELECT YEAR--")
                {
                    objEntityEmployeeDeduction.Year = Convert.ToInt32(Year);
                }
                objEntityEmployeeDeduction.Mode = Convert.ToInt32(Mode);
                objEntityEmployeeDeduction.Staff_Worker = Convert.ToInt32(Type);
                if (ProcessDate != "")
                {
                    objEntityEmployeeDeduction.date = objCommon.textToDateTime(ProcessDate);
                }
                if (BusnsUnit != "--SELECT BUSINESS UNIT--")
                {
                    objEntityEmployeeDeduction.BusnsUnitId = Convert.ToInt32(BusnsUnit);
                }

             
              dtlist = objBusinessLayerEmployeeDeductn.ReadMonthlySal_PaidList(objEntityEmployeeDeduction);
            }
            string Ids = "";
            foreach (DataRow dtRowsIn in dtlist.Rows)
            {               
                string TableID = dtRowsIn[0].ToString();
                if (Ids == "")
                {
                    Ids = TableID;
                }
                else
                {
                    Ids = Ids + "," + TableID;
                }
             }
            int i = 0;
            foreach (DataRow dtRowsIn in dtlist.Rows)
            {
                i++;
                string paidS = "";
                string TableID = dtRowsIn[0].ToString();
                              
                
                if (Mode == "1")
                {
                    if (IndRnd == "0")
                    {
                        paidS = Math.Round(Convert.ToDecimal(dtRowsIn[8].ToString()), 2).ToString("0.00") + " " + dtRowsIn["CRNCMST_ABBRV"].ToString();
                    }
                    else
                    {
                        paidS = Math.Round(Convert.ToDecimal(dtRowsIn[8].ToString()),0).ToString("0.00") + " " + dtRowsIn["CRNCMST_ABBRV"].ToString();
                    }
                }
                else
                {
                    paidS = "<th class=\"hasinput\" style=\"width:20%\"><input id=\"txtPaid" + TableID + "\" style=\"text-align:right;width:96%;padding:5px;height:20px;\" type=\"text\" class=\"form-control\" value=\"" + dtRowsIn[8].ToString() + "\" onkeydown=\"return isNumber(event)\" onkeypress=\"return isNumber(event)\" maxlength=10 /></th>";
                }

                string Amount = "";
                if (dtRowsIn[7].ToString() != "")
                {
                    //if (IndRnd == "0")
                    //{
                    //    Amount = dtRowsIn[7].ToString() + " " + dtRowsIn["CRNCMST_ABBRV"].ToString();
                    //}
                    //else
                    //{
                        Amount = Math.Round(Convert.ToDecimal(dtRowsIn[7].ToString()), 0).ToString("0.00") + " " + dtRowsIn["CRNCMST_ABBRV"].ToString();
                    //}
                }
                
                yield return new Person
                {

                    EmpId = dtRowsIn[1].ToString(),
                    Empname = dtRowsIn[2].ToString(),
                    Designation = dtRowsIn[6].ToString(),
                    TotalAmt = Amount,
                    PaidAmt = paidS,
                    Close = "<td style=\" width:5%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"button\"  class=\"btn btn-primary\"  onclick=\"Close(" + TableID + "," + Mode + ");\" style=\"Width:100%;height:20px;\" value=\"Close\" /><input type=\"text\" class=\"all_Ids\" value=\"" + Ids + "\"  id=\"allIds" + i + "\" style=\"display:none;\" />",                
                };
            }
            
            
        }

    }
}
