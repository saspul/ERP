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
       
      

        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchEmpid = context.Request["sSearch_0"].ToLower();
        var sSearchEmp = context.Request["sSearch_1"].ToLower();
        var sSearchDesg = context.Request["sSearch_2"].ToLower();
        var sSearchDept = context.Request["sSearch_3"].ToLower();
        var sSearchLeaveFromDate = context.Request["sSearch_4"].ToLower();
        var sSearchLeaveToDate = context.Request["sSearch_5"].ToLower();
       
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id);

        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
            if (iSortCol == 1)
            {
                return p.Employeeid;
            }
           
            if (iSortCol ==2)
            {
                return p.Designation;
            }
            if (iSortCol == 3)
            {
                return p.Department;
            }
            if (iSortCol == 4)
            {
                return p.LeaveFromDate;
            }
            if (iSortCol == 5)
            {
                return p.LeaveToDate;
            }
            return p.Employee;
           
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

            .Where(p => p.Employee.ToString().ToLower().Contains(sSearchAll) || p.Employeeid.ToString().ToLower().Contains(sSearchAll) || p.Designation.ToString().ToLower().Contains(sSearchAll) || p.Department.ToLower().ToString().Contains(sSearchAll) || p.LeaveFromDate.ToString().Contains(sSearchAll) || p.LeaveToDate.ToString().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.Employeeid.ToString().ToLower().Contains(sSearchEmpid))
            .Where(p => p.Employee.ToString().ToLower().Contains(sSearchEmp))  // Search: Avoid Contains() in production
            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesg))
            .Where(p => p.Department.ToString().ToLower().Contains(sSearchDept))
            .Where(p => p.LeaveFromDate.ToString().Contains(sSearchLeaveFromDate))
             .Where(p => p.LeaveToDate.ToString().Contains(sSearchLeaveToDate))
            .Select(p => new[] { p.Employeeid, p.Employee, p.Designation.ToString(), p.Department, p.LeaveFromDate, p.LeaveToDate, p.Rejoin })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.Employee.ToString().ToLower().Contains(sSearchAll) || p.Employeeid.ToString().ToLower().Contains(sSearchAll) || p.Designation.ToString().ToLower().Contains(sSearchAll) || p.Department.ToLower().ToString().Contains(sSearchAll) || p.LeaveFromDate.ToString().Contains(sSearchAll) || p.LeaveToDate.ToString().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.Employeeid.ToString().ToLower().Contains(sSearchEmpid))
            .Where(p => p.Employee.ToString().ToLower().Contains(sSearchEmp))  // Search: Avoid Contains() in production
            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesg))
            .Where(p => p.Department.ToString().ToLower().Contains(sSearchDept))
            .Where(p => p.LeaveFromDate.ToString().Contains(sSearchLeaveFromDate))
             .Where(p => p.LeaveToDate.ToString().Contains(sSearchLeaveToDate))
            .Select(p => new[] { p.Employeeid, p.Employee, p.Designation.ToString(), p.Department, p.LeaveFromDate, p.LeaveToDate, p.Rejoin }).Count()
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
        public string Employee { get; set; }
        public string Designation{get;set;}
        public string Department { get; set; }
        public string LeaveFromDate { get; set; }
        public string LeaveToDate { get; set; }
        public string Rejoin { get; set; }
        public string Employeeid { get; set; }
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id)
        {
            clsBusinessLayerDutyRejoin objBusinessDutyRejoin = new clsBusinessLayerDutyRejoin();
            clsEntityLayerDutyRejoin objEntityDutyRejoin = new clsEntityLayerDutyRejoin();


            objEntityDutyRejoin.CorpId = Convert.ToInt32(Corpt_Id);
            objEntityDutyRejoin.orgid = Convert.ToInt32(Org_Id);
            objEntityDutyRejoin.UserDate = System.DateTime.Now;


            DataTable dtorglist = objBusinessDutyRejoin.ReadRejoinList(objEntityDutyRejoin);

          //int cout = 0;
            foreach (DataRow dtRowsIn in dtorglist.Rows)
            {
               
                string TableID = dtRowsIn[0].ToString();
                string UserID = dtRowsIn["USR_ID"].ToString();
                string userName = dtRowsIn["USR_NAME"].ToString();
                if (dtRowsIn["USR_NAME2"].ToString() != "")
                {
                    userName = dtRowsIn["USR_NAME2"].ToString();
                }
               
                yield return new Person
                {

                    Employee = userName,
                    Employeeid = dtRowsIn["USR_CODE"].ToString(),
                    Designation = dtRowsIn["DSGN_NAME"].ToString(),
                    Department = dtRowsIn["CPRDEPT_NAME"].ToString(),
                    LeaveFromDate = dtRowsIn["LEAVE_FROM_DATE"].ToString(),
                    LeaveToDate = dtRowsIn["LEAVE_TO_DATE"].ToString(),
                    Rejoin = "<span class=\"responsiveExpander\"></span><img title=\"Rejoin\"  style=\" cursor:pointer;\" src='/Images/Icons/RejoinIcon.png' onclick=\"return Rejoin('" + TableID + "','" + UserID + "','" + userName + "',' " + dtRowsIn["DSGN_NAME"].ToString() + "','" + dtRowsIn["CPRDEPT_NAME"].ToString() + "','" + dtRowsIn["LEAVE_FROM_DATE"].ToString() + "','" + dtRowsIn["LEAVE_TO_DATE"].ToString() + "');\" />",
                };
            }
        }

    }
}
