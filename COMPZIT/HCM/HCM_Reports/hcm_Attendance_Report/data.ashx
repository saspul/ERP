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

public class data : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        var OrgId = context.Request["ORG_ID"];
        var UserId = context.Request["USERID"];
        var CorpId = context.Request["CORPOFFICEID"];
        var DeparmentId = context.Request["DEP_ID"];
        var DivisionId = context.Request["DIV_ID"];
        var ProjectId = context.Request["PROJECT_ID"];
        var OtType = context.Request["OT_TYP"];
        var Date = context.Request["DATE"];


        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];

        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();


        var persons = Person.GetPersons(OrgId, UserId, CorpId, DeparmentId, DivisionId, ProjectId, OtType, Date);


        Func<Person, object> order = p =>
        {
            if (iSortCol == 1)
            {
                return p.EmployeeId;
            }
            if (iSortCol == 2)
            {
                return p.Employee;
            }
            if (iSortCol == 3)
            {
                return p.Designation;
            }
            return p.Date;
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

            aaData = persons

            .Where(p => p.Date.ToString().ToLower().Contains(sSearchAll) || p.EmployeeId.ToString().ToLower().Contains(sSearchAll) || p.Employee.ToString().ToLower().Contains(sSearchAll) || p.Designation.ToString().ToLower().Contains(sSearchAll) ||
            p.Project.ToString().ToLower().Contains(sSearchAll) || p.IdleHours.ToString().ToLower().Contains(sSearchAll) || p.OtType.ToString().ToLower().Contains(sSearchAll) || p.OtHours.ToString().ToLower().Contains(sSearchAll) ||
            p.TotalHours.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production


            .Select(p => new[] { p.Date, p.EmployeeId, p.Employee, p.Designation, p.Project,p.IdleHours, p.OtType, p.OtHours, p.TotalHours})
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons


            .Where(p => p.Date.ToString().ToLower().Contains(sSearchAll) || p.EmployeeId.ToString().ToLower().Contains(sSearchAll) || p.Employee.ToString().ToLower().Contains(sSearchAll) || p.Designation.ToString().ToLower().Contains(sSearchAll) ||
            p.Project.ToString().ToLower().Contains(sSearchAll) || p.IdleHours.ToString().ToLower().Contains(sSearchAll) || p.OtType.ToString().ToLower().Contains(sSearchAll) || p.OtHours.ToString().ToLower().Contains(sSearchAll) ||
            p.TotalHours.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production

            .Select(p => new[] { p.Date, p.EmployeeId, p.Employee, p.Designation, p.Project, p.IdleHours, p.OtType, p.OtHours, p.TotalHours }).Count(),
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
        public string Date { get; set; }
        public string EmployeeId { get; set; }
        public string Employee { get; set; }
        public string Designation { get; set; }

        public string Project { get; set; }
        public string IdleHours { get; set; }
        public string OtType { get; set; }
        public string OtHours { get; set; }
        public string TotalHours { get; set; }

        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string OrgId, string UserId, string CorpId, string DeparmentId, string DivisionId,
          string ProjectId, string OtType, string Date)
        {
            clsBusinessAttendanceReport objBusinessJoingIntimation = new clsBusinessAttendanceReport();
            clsEntityAttendanceReport objEntityJoiningList = new clsEntityAttendanceReport();
            clsCommonLibrary objCommon = new clsCommonLibrary();

            objEntityJoiningList.UserId = Convert.ToInt32(UserId);
            objEntityJoiningList.CorpId = Convert.ToInt32(CorpId);
            objEntityJoiningList.OrgId = Convert.ToInt32(OrgId);

            if (OtType != "")
            {
                objEntityJoiningList.OtType = Convert.ToInt32(OtType);
            }
            if (DeparmentId != "")
            {
                objEntityJoiningList.DepartmentId = Convert.ToInt32(DeparmentId);
            }
            if (DivisionId != "--SELECT--")
            {
                objEntityJoiningList.DivsnId = Convert.ToInt32(DivisionId);
            }
            if (ProjectId != "--SELECT--")
            {
                objEntityJoiningList.ProjectId = Convert.ToInt32(ProjectId);
            }
            if (Date != "")
            {
                objEntityJoiningList.FromDate = objCommon.textToDateTime(Date.Trim());
            }
                       
            
            DataTable dtShortlistcandidates = objBusinessJoingIntimation.ReadListReport(objEntityJoiningList);

            foreach (DataRow dtRowsIn in dtShortlistcandidates.Rows)
            {

                string strDate = dtRowsIn["DATE ATT"].ToString();
                string strEmployeeId = dtRowsIn["USR_CODE"].ToString();
                string strEmployee = dtRowsIn["EMPLOYEE"].ToString();
                string strDesignation = dtRowsIn["DSGN_NAME"].ToString();

                string strProject = dtRowsIn["PROJECT_NAME"].ToString();
                string strIdleHours = dtRowsIn["EMDLHRDTL_IDLE_HOUR"].ToString();
                string strOtType = dtRowsIn["OVRTMCATG_NAME"].ToString();
                string strOtHours = dtRowsIn["EMDLHRDTL_OT"].ToString();
                string strTotalHours = dtRowsIn["EMDLHRDTL_RNDED_OT"].ToString();

                yield return new Person
                {
                    Date = strDate,
                    EmployeeId = strEmployeeId,
                    Employee = strEmployee,
                    Designation = strDesignation,

                    Project = strProject,
                    IdleHours = strIdleHours,
                    OtType = strOtType,
                    OtHours = strOtHours,
                    TotalHours = strTotalHours,
                };
            }
        }
    }

}