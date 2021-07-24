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
        var dtFromDate = context.Request["FROMDATE"];
        var dtToDate = context.Request["TODATE"];
        var dtDesgn = context.Request["DESIGNATION"];
        var Status = context.Request["STATUS"];  
        var CnclSts = context.Request["CANCEL"];  
        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchService = context.Request["sSearch_0"].ToLower();
        var sSearchCategory = context.Request["sSearch_1"].ToLower();
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id, dtFromDate, dtToDate, dtDesgn,Status, CnclSts);
        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
            if (iSortCol == 1)
            {
                return p.Category;
            }
         
             return p.Service;
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
            //iTotalDisplayRecords = persons.Count(),
            aaData = persons

            .Where(p => p.Service.ToString().ToLower().Contains(sSearchAll) || p.Category.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.Service.ToString().ToLower().Contains(sSearchService))
            .Where(p => p.Category.ToString().ToLower().Contains(sSearchCategory))// Search: Avoid Contains() in production
            .Select(p => new[] { p.Service, p.Category, p.Status, p.Applicable, p.Edit, p.Delete })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.Service.ToString().ToLower().Contains(sSearchAll) || p.Category.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.Service.ToString().ToLower().Contains(sSearchService))
            .Where(p => p.Category.ToString().ToLower().Contains(sSearchCategory))// Search: Avoid Contains() in production
            .Select(p => new[] { p.Service, p.Category, p.Status, p.Applicable, p.Edit, p.Delete }).Count()
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
        public string Service { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string Applicable { get; set; }
        public string Edit { get; set; }
        public string Delete { get; set; }
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id,string dtFromDate,string dtToDate,string dtDesgn,string Status, string CnclSts)
        {
            clsEntity_Emp_Welfare_Service objEntityWelfare = new clsEntity_Emp_Welfare_Service();
            clsBusiness_Emp_Welfare_Service objBusinessWelfare = new clsBusiness_Emp_Welfare_Service();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            objEntityWelfare.OrgId = Convert.ToInt32(Org_Id);
            objEntityWelfare.CorpId = Convert.ToInt32(Corpt_Id);
            if (dtFromDate != "")
            {
                objEntityWelfare.FromPeriod = objCommon.textToDateTime(dtFromDate);
            }
            if (dtToDate != "")
            {
                objEntityWelfare.ToPeriod = objCommon.textToDateTime(dtToDate);
            }
            if (dtDesgn != "--SELECT DESIGNATION--")
            {
                objEntityWelfare.DesignationId = Convert.ToInt32(dtDesgn);
            }
            objEntityWelfare.Status = Convert.ToInt32(Status);
            objEntityWelfare.Cancel_Status = Convert.ToInt32(CnclSts);

            DataTable dtCategory = objBusinessWelfare.ReadServiceDetailsList(objEntityWelfare);
            string strRandom = objCommon.Random_Number();
            foreach (DataRow dtRowsIn in dtCategory.Rows)
            {
                string strId = dtRowsIn[0].ToString();
                int intIdLength = dtRowsIn[0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strStatus="";               
                string stsmode;
                string strStatusImg = "";
                int intDivcount=0;
                int intDeptcount=0;
                int intDsgnCount=0;
                int intEmpCount=0;
                string strDelete="";
                intDivcount=Convert.ToInt32(dtRowsIn["DIVCOUNT"].ToString());
                intDeptcount=Convert.ToInt32(dtRowsIn["DEPTCOUNT"].ToString());
                intDsgnCount= Convert.ToInt32(dtRowsIn["DESGNCOUNT"].ToString());
                intEmpCount=  Convert.ToInt32(dtRowsIn["USERCOUNT"].ToString());
                stsmode = dtRowsIn["STATUS"].ToString();
              
                string cnclusrId = dtRowsIn["WLFRSRVC_CNCL_USRID"].ToString();
                if (stsmode == "ACTIVE")
                {
                    strStatus = "1";
                    strStatusImg = "<span class=\"responsiveExpander\"></span><img title=\"Make Inactive\"  style=\"  cursor:pointer;float: left;margin-left: 39%;\" src='/Images/Icons/activate.png' onclick=\"return ChangeStatus('" + Id + "','" + strStatus + "','" + cnclusrId + "');\" />";
                }
                else
                {
                    strStatus = "0";
                    strStatusImg = "<span class=\"responsiveExpander\"></span><img title=\" Make Active\"  style=\"  cursor:pointer;float: left;margin-left: 39%;\" src='/Images/Icons/inactivate.png' onclick=\"return ChangeStatus('" + Id + "','" + strStatus + "','" + cnclusrId + "');\" />";
                }
                if (intDeptcount > 0 || intDivcount > 0 || intDsgnCount > 0 || intEmpCount > 0)
                {

                   // strDelete = "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >" +"<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                    strDelete = "<td style=\"width:1%;opacity: 0.2;cursor: pointer;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Delete\"  onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" class=\"fa fa-trash\"></i></a>";
                    
                }
                else{
                    strDelete = "<td style=\"width:1%;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Delete\"  onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";
                }   
                yield return new Person
                {
                    Service = dtRowsIn["WLFRSRVC_NAME"].ToString(),
                    Category = dtRowsIn["WLFRCAT_NAME"].ToString(),
                    Status = strStatusImg,
                    Applicable = "<td style=\" width:1%; word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><a class=\"btn btn-xs btn-default \" title=\"View\"onclick='return getdetails(this.href);' href=\"hcm_Emp_welfare_service.aspx?ViewId=" + Id + "\"><i class=\"fa fa-eye\"></i></a>",
                    Edit = "<td style=\"width:1%;word-break: break-all;text-align:center; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"hcm_Emp_welfare_service.aspx?Id=" + Id + "\"><i class=\"fa fa-pencil\"></i></a>",
                    Delete = strDelete,
                };
            }
        }

    }
}
