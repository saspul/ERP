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
        var OrgId = context.Request["ORG_ID"];
        var CorpId = context.Request["CORPOFFICEID"];
        var TeamLeadEmp_Id = context.Request["TEAMLEAD_EMPID"];
        var TeamId = context.Request["TEAM_ID"];
        var DivisionId = context.Request["DIV_ID"];

        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters

        var sSearchAll = context.Request["sSearch"].ToLower();

        var persons = Person.GetPersons(OrgId, CorpId, TeamLeadEmp_Id, TeamId, DivisionId);

        Func<Person, object> order = p =>
        {
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

            aaData = persons

            .Where(p => p.Employee.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production

            .Select(p => new[] {  p.AddImg.ToString(), p.EmployeeImg.ToString(), p.Employee.ToString(), p.Status.ToString() })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.Employee.ToString().ToLower().Contains(sSearchAll))
            .Select(p => new[] {  p.AddImg.ToString(), p.EmployeeImg.ToString(), p.Employee.ToString(), p.Status.ToString() }).Count(),
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
        public string AddImg { get; set; }
        public string EmployeeImg { get; set; }
        public string Employee { get; set; }
        public string Status { get; set; }
        // public string Action { get; set; }

        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string OrgId, string CorpId, string TeamLeadEmp_Id, string TeamId,string DivisionId)
        {
            clsEntityLayerTeamHierarchy objEntityTeamHierarchy = new clsEntityLayerTeamHierarchy();
            clsBusinessLayerTeamHierarchy objBusinessLayerTeamHierarchy = new clsBusinessLayerTeamHierarchy();

            clsCommonLibrary objCommon = new clsCommonLibrary();

            string ret = "true";

            if (TeamLeadEmp_Id == "")
            {
                ret = "false";
            }



            if (ret == "true")
            {
                objEntityTeamHierarchy.TeamLeadEmp_Id = Convert.ToInt32(TeamLeadEmp_Id);

                if (TeamId != "")
                {
                    objEntityTeamHierarchy.TeamId = Convert.ToInt32(TeamId);
                }
                objEntityTeamHierarchy.Organisation_Id = Convert.ToInt32(OrgId);
                objEntityTeamHierarchy.CorpOffice_Id = Convert.ToInt32(CorpId);
                
                objEntityTeamHierarchy.Divsnid = Convert.ToInt32(DivisionId);

                DataTable dt = new DataTable();
                dt = objBusinessLayerTeamHierarchy.ReadUsersForMember(objEntityTeamHierarchy);
                for (int intRowBodyCount = 0; intRowBodyCount < dt.Rows.Count; intRowBodyCount++)
                 //   for (int intRowBodyCount = 0; intRowBodyCount < 3; intRowBodyCount++)
                {
                    string EmployeeImg = "";


                    string strAddImg = "";
                    string strEmployee = "";
                    string strStatus = "";

                    int intMemberInOtherTeamCount = Convert.ToInt32(dt.Rows[intRowBodyCount]["TMCOUNT"].ToString());

                    if (intMemberInOtherTeamCount != 0)
                    {
                        strAddImg = "<td style=\"width:4%; word-wrap:break-word;text-align: center;\"></td>";
                    }
                    else
                    {
                        strAddImg = "<td style=\"width:4%; word-wrap:break-word;text-align: center;\">" +
                            "<img   src='../../Images/Icons/freeIcon.jpg' style=\"margin-top: 12%;\" /> " + " </td>";
                    }



                    for (int intColumnBodyCount = 0; intColumnBodyCount < dt.Columns.Count; intColumnBodyCount++)
                    {
                       // EmployeeImg = "";
                        string strForImageDiv = "";


                        if (intColumnBodyCount == 1)
                        {
                            if (dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != null && dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                            {
                                string strImagePath = objCommon.GetImagePath(CL_Compzit.clsCommonLibrary.IMAGE_SECTION.USER_PROFILEPIC) + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString();

                                EmployeeImg += "<td   style=\"width:10%;height:40px; word-wrap:break-word;text-align: center;\" > <a  class=\"lightbox\" href=\"#goofy_" + dt.Rows[intRowBodyCount][0].ToString() + "\"  >" + "<img   id='imgId_" + dt.Rows[intRowBodyCount][0].ToString() + "' src='" + strImagePath + "' />" + "</a></td>";                                
                                strForImageDiv += " <div class=\"lightbox-target\" id=\"goofy_" + dt.Rows[intRowBodyCount][0].ToString() + "\">";

                                strForImageDiv += " <img src=\"" + strImagePath + "\"/>";
                                strForImageDiv += " <a class=\"lightbox-close\" href=\"#\"></a>";
                                strForImageDiv += "</div>";
                            }

                            else
                            {
                                string strImagePath = "/Images/Icons/wlcm.png";// class=\"lightbox\"
                                EmployeeImg += "<td   style=\"width:10%;height:40px; word-wrap:break-word;text-align: center;\" > <a  class=\"lightbox\" href=\"#goofy_" + dt.Rows[intRowBodyCount][0].ToString() + "\"  >" + "<img   id='imgId_" + dt.Rows[intRowBodyCount][0].ToString() + "' src='" + strImagePath + "' />" + "</a></td>";

                                strForImageDiv += " <div class=\"lightbox-target\" id=\"goofy_" + dt.Rows[intRowBodyCount][0].ToString() + "\">";

                                strForImageDiv += " <img src=\"" + strImagePath + "\"/>";
                                strForImageDiv += " <a class=\"lightbox-close\" href=\"#\"></a>";
                                strForImageDiv += "</div>";
                            }
                        }

                        if (intColumnBodyCount == 2)
                        {
                            strEmployee += "<td> <span style=\"display: none;\" id=\"EmpName_" + dt.Rows[intRowBodyCount][0].ToString() + "\"> " + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + " </span>" + dt.Rows[intRowBodyCount][intColumnBodyCount].ToString() + "</td>";
                        }
                    }

                    strStatus += "<td  style=\" width:5%;word-break: break-all; word-wrap:break-word;text-align: center;vertical-align: bottom;padding-bottom: 2.5%;padding-left: 0;\"  >" +
                       "  <input class=\"theClass\"  type=\"checkbox\" onkeydown=\"return DisableEnter(event)\" onchange=\"IncrmntConfrmCounter();\"  id=\"chbx_" + dt.Rows[intRowBodyCount][0].ToString() + "\"> " + " </td>";

                    yield return new Person
                    {
                        AddImg = strAddImg,
                        EmployeeImg = EmployeeImg,
                        Employee = strEmployee,
                        Status = strStatus,
                    };
                }
            }
        }
    }
}