<%@ WebHandler Language="C#" Class="data" %>

using System;
using System.Web;
using System.Linq;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using System.Data;

public class data : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //PARAMETERS MANUALLY ADDED
        var Org_Id = context.Request["ORG_ID"];
        var Corpt_Id = context.Request["CORPT_ID"];
        var Month = context.Request["MONTH"];
        var Year = context.Request["YEAR"];
      

        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchDay = context.Request["sSearch_0"].ToLower();
        var sSearchDate = context.Request["sSearch_1"].ToLower();
        var sSearchNoEmp = context.Request["sSearch_2"].ToLower();
        //var sSearchFile = context.Request["sSearch_3"].ToLower();
       
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id, Month, Year);

        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
           
           
            if (iSortCol ==1)
            {
                return p.Date;
            }
            if (iSortCol == 2)
            {
                return p.NoOfEmp;
            }
            //if (iSortCol == 3)
            //{
            //    return p.File;
            //}
            return p.Day;
           
        };

        // Define the order direction based on the iSortDir parameter
        if ("desc" == iSortDir)
        {
            persons = persons.OrderByDescending(order);
        }
        else
        {
         //   persons = persons.OrderBy(order);
        }

        // prepare an anonymous object for JSON serialization
        var result = new
        {
            iTotalRecords = persons.Count(),
            //   iTotalDisplayRecords = persons.Count(),
            aaData = persons

            .Where(p => p.Day.ToString().ToLower().Contains(sSearchAll) || p.Date.ToString().ToLower().Contains(sSearchAll) || p.NoOfEmp.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.Day.ToString().ToLower().Contains(sSearchDay))  // Search: Avoid Contains() in production
            .Where(p => p.Date.ToString().Contains(sSearchDate))
            .Where(p => p.NoOfEmp.ToString().Contains(sSearchNoEmp))
                //.Where(p => p.File.ToString().ToLower().Contains(sSearchFile))
            .Select(p => new[] { p.Day, p.Date.ToString(), p.NoOfEmp, p.View })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.Day.ToString().ToLower().Contains(sSearchAll) || p.Date.ToString().ToLower().Contains(sSearchAll) || p.NoOfEmp.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.Day.ToString().ToLower().Contains(sSearchDay))  // Search: Avoid Contains() in production
            .Where(p => p.Date.ToString().Contains(sSearchDate))
            .Where(p => p.NoOfEmp.ToString().Contains(sSearchNoEmp))
                //.Where(p => p.File.ToString().ToLower().Contains(sSearchFile))
            .Select(p => new[] { p.Day, p.Date.ToString(), p.NoOfEmp, p.View }).Count()
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
        public string Day { get; set; }
        public string Date{get;set;}
        public string NoOfEmp { get; set; }
        public string View { get; set; }
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string Month, string Year)
        {
            clsBusinessLayerEmployeeDailyWorkHour objBusinessEmpDailyWorkHour = new clsBusinessLayerEmployeeDailyWorkHour();
            clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour = new clsEntityEmployeeDailyWorkHour();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            objEntityEmpDailyWorkHour.CorpId = Convert.ToInt32(Corpt_Id);
            objEntityEmpDailyWorkHour.orgid = Convert.ToInt32(Org_Id);

            if (Month != "--SELECT MONTH--")
            {
                
                objEntityEmpDailyWorkHour.Month = Convert.ToInt32(Month);
                objEntityEmpDailyWorkHour.Year = Convert.ToInt32(Year);
                if (objEntityEmpDailyWorkHour.Month < 10)
                {
                    Month = "0" + Month;
                }
                objEntityEmpDailyWorkHour.StrDate=Month + "-" + Year;
            }




            DataTable dtorglist = objBusinessEmpDailyWorkHour.readDailywrkShtMnthYear(objEntityEmpDailyWorkHour);

          //int cout = 0;
            foreach (DataRow dtRowsIn in dtorglist.Rows)
            {
               
                string DateMonth = dtRowsIn[0].ToString();
                string DateYear = dtRowsIn[1].ToString();
                
                yield return new Person
                {

                    Day = dtRowsIn[0].ToString(),
                    Date = dtRowsIn[1].ToString(),
                    NoOfEmp = dtRowsIn[2].ToString(),
                    View = "<span class=\"responsiveExpander\"></span><button runat=\"server\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" onclick=\"return ViewRow('" + DateMonth + "','" + DateYear + "','" + dtRowsIn["TABLE_STS"].ToString() + "');\"><i class=\"fa fa-eye\"></i></button>",
                };
            }
        }

    }
}
