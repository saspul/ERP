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
        try
        {
            //PARAMETERS MANUALLY ADDED
            var Org_Id = context.Request["ORG_ID"];
            var Corpt_Id = context.Request["CORPT_ID"];
            var CnclSts = context.Request["CNCL_CHEK"];


            // Those parameters are sent by the plugin
            var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
            var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
            var iSortCol = int.Parse(context.Request["iSortCol_0"]);
            var iSortDir = context.Request["sSortDir_0"];
            // Search parameters
            var sSearchAll = context.Request["sSearch"].ToLower();
            var sSearchOvrtmName = context.Request["sSearch_0"].ToLower();
            var sSearchOvrtmRate = context.Request["sSearch_1"].ToLower();
            var sSearchStatus = context.Request["sSearch_2"].ToLower();

            // Fetch the data from a repository (in my case in-memory)
            var persons = Person.GetPersons(Corpt_Id, Org_Id, CnclSts);

            // Define an order function based on the iSortCol parameter
            Func<Person, object> order = p =>
            {
                if (iSortCol == 2)
                {
                    return p.OverTimeRate;
                }
                if (iSortCol == 3)
                {
                    return p.Status;
                }
                return p.OvertTimeName;

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

                .Where(p => p.OvertTimeName.ToString().ToLower().Contains(sSearchAll) || p.OverTimeRate.ToString().ToLower().Contains(sSearchAll) || p.Status.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
                .Where(p => p.OvertTimeName.ToString().ToLower().Contains(sSearchOvrtmName))  // Search: Avoid Contains() in production
                .Where(p => p.OverTimeRate.ToString().ToLower().Contains(sSearchOvrtmRate))
                .Where(p => p.Status.ToString().ToLower().Contains(sSearchStatus))
                .Select(p => new[] { p.OvertTimeName, p.OverTimeRate.ToString(), p.Status, p.Edit, p.Delete })
                .Skip(iDisplayStart)
                .Take(iDisplayLength),
                iTotalDisplayRecords = persons

                .Where(p => p.OvertTimeName.ToString().ToLower().Contains(sSearchAll) || p.OverTimeRate.ToString().ToLower().Contains(sSearchAll) || p.Status.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
                .Where(p => p.OvertTimeName.ToString().ToLower().Contains(sSearchOvrtmName))  // Search: Avoid Contains() in production
                .Where(p => p.OverTimeRate.ToString().ToLower().Contains(sSearchOvrtmRate))
                .Where(p => p.Status.ToString().ToLower().Contains(sSearchStatus))
                .Select(p => new[] { p.OvertTimeName, p.OverTimeRate.ToString(), p.Status, p.Edit, p.Delete }).Count()
            };

            var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var json = serializer.Serialize(result);
            context.Response.ContentType = "application/json";
            context.Response.Write(json);
        }
        catch (Exception)
        {
            
           // throw;
        }
      
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
        public string OvertTimeName { get; set; }
        public string OverTimeRate{get;set;}
        public string Status { get; set; }
        public string Edit { get; set; }
        public string Delete { get; set; }
        
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string CnclSts)
        {
            clsBusiness_OverTime_Category objBusiness_OverTime_Category = new clsBusiness_OverTime_Category();
            clsEntity_OverTime_Category objEntity_OverTime_Category = new clsEntity_OverTime_Category();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            
            objEntity_OverTime_Category.Corporate_id = Convert.ToInt32(Corpt_Id);
            objEntity_OverTime_Category.Organisation_id = Convert.ToInt32(Org_Id);
            objEntity_OverTime_Category.CancelStatus = Convert.ToInt32(CnclSts);


            DataTable dtorglist = objBusiness_OverTime_Category.ReadOverTimeCateg(objEntity_OverTime_Category);

          //int cout = 0;
            foreach (DataRow dtRowsIn in dtorglist.Rows)
            {
                string Id = dtRowsIn[0].ToString();
                
            
                int intIdLength = dtRowsIn[0].ToString().Length;
            string stridLength = intIdLength.ToString("00");
            string strId = stridLength + Id + strRandom;
                
               
                if (objEntity_OverTime_Category.CancelStatus == 0)
                {
                    yield return new Person
                    {
                        OvertTimeName = dtRowsIn["NAME"].ToString(),
                        OverTimeRate = dtRowsIn["RATE"].ToString(),
                        Status = dtRowsIn["STATUS"].ToString() == "INACTIVE" ? "Inactive" : dtRowsIn["STATUS"].ToString() == "ACTIVE" ? "Active" : "Others",

                        //Edit = "<span class=\"responsiveExpander\"></span><button runat=\"server\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" onclick=\"getEditRow(" + strId + ");\"><i class=\"fa fa-pencil\"></i></button>",
                        Edit = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"hcm_OverTime_Category_Master.aspx?Id=" + strId + "\"><i class=\"fa fa-pencil\"></i></a>",
                        // Delete = "<span class=\"responsiveExpander\" ></span><button runat=\"server\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" onclick=\"OpenCancelView('" + strId + "');\"><i class=\"fa fa-trash\"></i></button>",
                        Delete = "<td style=\" width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button  class=\"btn btn-xs btn-default\" \"tooltip\" title=\"Delete Row\" data-original-title=\"Edit Row\" onclick=\"return OpenCancelView(" + Id + ");\"><i class=\"fa fa-trash\"></i></button>",
                         //" <a class=\"tooltip\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"gen_Consultancy_Master.aspx?Id=" + Id + "\">" ;

                    };
                }

                else
                {
                    yield return new Person
                    {
                        OvertTimeName = dtRowsIn["NAME"].ToString(),
                        OverTimeRate = dtRowsIn["RATE"].ToString(),
                        Status = dtRowsIn["STATUS"].ToString() == "INACTIVE" ? "Inactive" : dtRowsIn["STATUS"].ToString() == "ACTIVE" ? "Active" : "Others",
                       // Edit = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button  runat=\"server\" class=\"btn btn-xs btn-default\" \"tooltip\" title=\"View\" data-original-title=\"Edit Row\" onclick=\"getEditRow(" + strId + ");\"><i class=\"fa fa-eye\"></i></button>",
                        Edit = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"hcm_OverTime_Category_Master.aspx?ViewId=" + strId + "\"><i class=\"fa fa-eye\"></i></a>",

                    };
                }
            }
        }

    }
}
