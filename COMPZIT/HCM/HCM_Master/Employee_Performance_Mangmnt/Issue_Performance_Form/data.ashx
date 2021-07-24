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
        var sSearchRef = context.Request["sSearch_0"].ToLower();
        var sSearchIssue = context.Request["sSearch_1"].ToLower();
        var sSearchPerform = context.Request["sSearch_2"].ToLower();
        var sSearchDate= context.Request["sSearch_3"].ToLower();
        var sSearchRev = context.Request["sSearch_4"].ToLower();
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id, dtFromDate, dtToDate, dtDesgn,Status, CnclSts);
        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
            if (iSortCol == 1)
            {
                return p.Issue;
            }
             if (iSortCol == 2)
            {
                return p.Perform;
            }
            if (iSortCol == 3)
            {
                return p.Issuedate;
            }
            if (iSortCol == 3)
            {
                return p.IssueRev;
            }
            return p.Ref;
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

            .Where(p => p.Ref.ToString().ToLower().Contains(sSearchAll) || p.Issue.ToString().ToLower().Contains(sSearchAll) || p.Perform.ToString().ToLower().Contains(sSearchAll) || p.Issuedate.ToString().ToLower().Contains(sSearchAll) || p.IssueRev.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.Ref.ToString().ToLower().Contains(sSearchRef))
            .Where(p => p.Issue.ToString().ToLower().Contains(sSearchIssue))
            .Where(p => p.Perform.ToString().ToLower().Contains(sSearchPerform))
            .Where(p => p.Issuedate.ToString().ToLower().Contains(sSearchDate))// Search: Avoid Contains() in production
             .Where(p => p.IssueRev.ToString().ToLower().Contains(sSearchRev))
            .Select(p => new[] { p.Ref, p.Issue, p.Perform, p.Issuedate, p.IssueRev, p.status, p.Edit, p.Analyze, p.Delete, p.View })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.Ref.ToString().ToLower().Contains(sSearchAll) || p.Issue.ToString().ToLower().Contains(sSearchAll) || p.Perform.ToString().ToLower().Contains(sSearchAll) || p.Issuedate.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.Ref.ToString().ToLower().Contains(sSearchRef))
            .Where(p => p.Issue.ToString().ToLower().Contains(sSearchIssue))
            .Where(p => p.Perform.ToString().ToLower().Contains(sSearchPerform))
            .Where(p => p.Issuedate.ToString().ToLower().Contains(sSearchDate))// Search: Avoid Contains() in production
             .Where(p => p.IssueRev.ToString().ToLower().Contains(sSearchRev))

            .Select(p => new[] { p.Ref, p.Issue, p.Perform, p.Issuedate, p.IssueRev, p.status, p.Edit, p.Analyze, p.Delete, p.View }).Count()
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
        public string Ref { get; set; }
        public string Issue { get; set; }
        public string Perform { get; set; }
        public string Issuedate { get; set; }
        public string IssueRev { get; set; }
        public string status { get; set; }
        public string Edit { get; set; }
        public string Analyze { get; set; }
        public string Delete { get; set; }
        public string View { get; set; }
        
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string dtFromDate, string dtToDate, string dtDesgn, string Status, string CnclSts)
        {
            clsEntity_Issue_Performance objEntityIssue_Performance = new clsEntity_Issue_Performance();
            cls_Business_Issue_performance objBusiness_Issue_Performance = new cls_Business_Issue_performance();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            
            objEntityIssue_Performance.OrgId = Convert.ToInt32(Org_Id);
            objEntityIssue_Performance.Corp_Id = Convert.ToInt32(Corpt_Id);
            if (dtFromDate != "")
            {
                objEntityIssue_Performance.FromDate = objCommon.textToDateTime(dtFromDate);
            }
            if (dtToDate != "")
            {
                objEntityIssue_Performance.ToDate = objCommon.textToDateTime(dtToDate);
            }
            if (dtDesgn != "--SELECT TEMPLATE--")
            {
                objEntityIssue_Performance.PerfrmTempltId = Convert.ToInt32(dtDesgn);
            }
            objEntityIssue_Performance.Status = Convert.ToInt32(Status);
            objEntityIssue_Performance.Cancel_Status = Convert.ToInt32(CnclSts);

            DataTable dtCategory = objBusiness_Issue_Performance.ReadServiceDetailsList(objEntityIssue_Performance);
  
            string strRandom = objCommon.Random_Number();
            foreach (DataRow dtRowsIn in dtCategory.Rows)
            {
                string strId = dtRowsIn["ISSUE_ID"].ToString();
                objEntityIssue_Performance.IssueId =Convert.ToInt32(strId);
                DataTable dt = objBusiness_Issue_Performance.ReadAnalyzePerform(objEntityIssue_Performance);
               
                int intIdLength = dtRowsIn["ISSUE_ID"].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strStatus = "";
                string stsmode;
                string strStatusImg = "";
                string strEdit = "";
                string strDelete = "";
                DateTime dtIssue =objCommon.textToDateTime(dtRowsIn["ISSUE_DATE"].ToString());
                string strDate = dtIssue.ToString("dd-MM-yyyy");
                string strAnalyze = "";
                int intIssueCount = 0;
                intIssueCount = Convert.ToInt32(dtRowsIn["ISSUECOUNT"].ToString());
                if (dt.Rows.Count > 0)
                {
                    strAnalyze = "<td style=\" width:1%; word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><button class=\"btn btn-xs btn-default \" title=\"Analyse\" data-toggle=\"modal\" data-target=\"#exampleModalLong\" onclick=\"return OpenAnalyzeView('" + Id + "');\"><i class=\"fa fa-pencil-square-o\" style=\"font-size:18px;color:blue;\"></i></button>";
                }
                else
                {
                    strAnalyze = "<td style=\" width:1%; word-break: break-all; word-wrap:break-word;\"><a class=\"btn btn-xs btn-default \" title=\"Analyse\" data-toggle=\"modal\"  style=\"opacity: 0.5;\"><i class=\"fa fa-pencil-square-o\" style=\"font-size:18px;color:blue;\"></i></a>";

                }
                stsmode = dtRowsIn["STATUS"].ToString();

                string cnclusrId = dtRowsIn["ISSUE_CNCL_USR_ID"].ToString();
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
                if (dtRowsIn["ISSUE_CNFRM_STATS"].ToString() == "1")
                {
                    strEdit = "<td style=\"width:1%;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"View\" href=\"Emp_Issue_Prfrmnce_Form.aspx?ViewId=" + Id + "\"\"><i class=\"fa fa-eye\" style=\"font-size:12px\"></i></a>";
                }
                else
                {
                    strEdit = "<td style=\"width:1%;word-break: break-all;text-align:center; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"Emp_Issue_Prfrmnce_Form.aspx?Id=" + Id + "\"><i class=\"fa fa-pencil\"></i></a>";
                }
                if (intIssueCount > 0)
                {

                    // strDelete = "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a   onclick='return CancelNotPossible();' >" +"<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                    strDelete = "<td style=\"width:1%;opacity: 0.2;cursor: pointer;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Delete\" href=\"#\" onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" class=\"fa fa-trash\"style=\"font-size:18px\"></i></a>";

                }
                else
                {
                    strDelete = "<td style=\"width:1%;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Delete\" href=\"#\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\" style=\"font-size:18px\"></i></a>";
                }  
                yield return new Person
                {
                    Ref = dtRowsIn["ISSUE_REFNO"].ToString(),
                    Issue = dtRowsIn["ISSUE_PRFM"].ToString(),
                    Perform = dtRowsIn["PRFMNC_TMPLT_FORM"].ToString(),
                    Issuedate = strDate,
                    IssueRev = dtRowsIn["ISSUE_REVNO"].ToString(),
                    status = strStatusImg,
                    Analyze = strAnalyze,
                    Edit = strEdit,
                    Delete = strDelete,
                    View = "<td style=\"width:1%;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"View\" href=\"Emp_Issue_Prfrmnce_Form.aspx?ViewId=" + Id + "\"\"><i class=\"fa fa-eye\" style=\"font-size:18px\"></i></a>",
                };
            }
        }
    }
}
