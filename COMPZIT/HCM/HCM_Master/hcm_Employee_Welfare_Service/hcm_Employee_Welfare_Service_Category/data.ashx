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
        var Status = context.Request["STATUS"];
        var CnclSts = context.Request["CNCL_STS"];
        var EnableEdit = context.Request["ENABLEDIT"];
        var EnableDelete = context.Request["ENABLEDELETE"];   
        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchCat = context.Request["sSearch_0"].ToLower();
        var sSearchSts = context.Request["sSearch_1"].ToLower();
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id, Status, CnclSts);
        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
            if (iSortCol == 1)
            {
                return p.Status;
            }
            return p.Category;
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

            .Where(p => p.Category.ToString().ToLower().Contains(sSearchAll) || p.Status.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.Category.ToString().ToLower().Contains(sSearchCat))  // Search: Avoid Contains() in production
            .Where(p => p.Status.ToString().ToLower().Contains(sSearchSts))
            .Select(p => new[] { p.SL,p.Category, p.Status, p.Edit,p.View, p.Delete })
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
        public string SL { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string Edit { get; set; }
        public string View { get; set; }
        public string Delete { get; set; }
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string Status, string CnclSts)
        {
            clsEntity_Emp_Welfare_Service_category objEntityWelfare_Category = new clsEntity_Emp_Welfare_Service_category();
            clsBusiness_Emp_Welfare_Service_Category objBusinessWelfare_Category = new clsBusiness_Emp_Welfare_Service_Category();
            objEntityWelfare_Category.OrgId = Convert.ToInt32(Org_Id);
            objEntityWelfare_Category.CorpId = Convert.ToInt32(Corpt_Id);
            objEntityWelfare_Category.Status = Convert.ToInt32(Status);
            objEntityWelfare_Category.Cancel_Status = Convert.ToInt32(CnclSts);

            DataTable dtCategory = objBusinessWelfare_Category.ReadCategoryDetails(objEntityWelfare_Category);
            int intCount = 0;                          
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            foreach (DataRow dtRowsIn in dtCategory.Rows)
            {
                string strDelete = "";

                intCount = intCount + 1;
                string strCount = Convert.ToString(intCount);
                string strId = dtRowsIn[0].ToString();
                int intIdLength = dtRowsIn[0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strStatus="";               
                string stsmode;
                string strStatusImg = "";
                stsmode = dtRowsIn[2].ToString();
                string cnclusrId = dtRowsIn["WLFRCAT_CNCL_USRID"].ToString();
                int Category =Convert.ToInt32(dtRowsIn["CATEGORYCOUNT"].ToString());
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
                if (Category > 0)
                {

                    // strDelete = "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >" +"<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                    strDelete = "<td style=\"width:1%;opacity: 0.2;cursor: pointer;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Delete\"  onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" class=\"fa fa-trash\"></i></a>";

                }
                else
                {
                    strDelete = "<td style=\"width:1%;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Delete\"  onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";
                }            
                yield return new Person
                {
                    SL=strCount,
                    Category = dtRowsIn[1].ToString(),
                    Status = strStatusImg,
                    Edit = "<td style=\"width:1%;word-break: break-all;text-align:center; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"hcm_Emp_Welfare_Service_Category.aspx?Id=" + Id + "\"><i class=\"fa fa-pencil\"></i></a>",
                    View = "<td style=\" width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><a class=\"btn btn-xs btn-default \" title=\"View\"onclick='return getdetails(this.href);' href=\"hcm_Emp_Welfare_Service_Category.aspx?ViewId=" + Id + "\"><i class=\"fa fa-eye\"></i></a>",
                    Delete = strDelete,
                };
            }
        }

    }
}
