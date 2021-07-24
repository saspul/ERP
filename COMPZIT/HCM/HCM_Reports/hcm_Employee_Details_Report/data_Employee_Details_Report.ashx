<%@ WebHandler Language="C#" Class="data_Employee_Details_Report" %>

using System;
using System.Web;
using System.Linq;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using System.Data;

public class data_Employee_Details_Report : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {


        var OrgId = context.Request["OrgId"];
        var CorpId = context.Request["CorpId"];
        var DesignationId = context.Request["DesignationId"];
        var DepartmentId = context.Request["DepartmentId"];
        var DivisionId = context.Request["DivisionId"];
        var ProjectId = context.Request["ProjectId"];
        var ReligionId = context.Request["ReligionId"];

        var GenderId = context.Request["GenderId"];
        var NumOfYears = context.Request["NumOfYears"];
        var PayGradeId = context.Request["PayGradeId"];
        var AgeFrom = context.Request["AgeFrom"];
        var AgeTo = context.Request["AgeTo"];
        var StatusId = context.Request["StatusId"];
        var NationalityId = context.Request["NationalityId"];


        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];

        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchEmployeeID = context.Request["sSearch_0"].ToLower();
        var sSearchEmployeeName = context.Request["sSearch_1"].ToLower();
        var sSearchDesignation = context.Request["sSearch_2"].ToLower();
        var sSearchDepartment = context.Request["sSearch_3"].ToLower();
        var sSearchDivision = context.Request["sSearch_4"].ToLower();
        var sSearchPaygrade = context.Request["sSearch_5"].ToLower();


        var persons = Person.GetPersons(OrgId, CorpId, DesignationId, DepartmentId, DivisionId, ProjectId, ReligionId, GenderId, NumOfYears, PayGradeId, AgeFrom, AgeTo, StatusId, NationalityId);

        Func<Person, object> order = p =>
        {
            if (iSortCol == 1)
            {
                return p.EmployeeName;
            }
            if (iSortCol == 2)
            {
                return p.Designation;
            }
            if (iSortCol == 3)
            {
                return p.Department;
            }
            if (iSortCol == 4)
            {
                return p.Division;
            }
            if (iSortCol == 5)
            {
                return p.Paygrade;
            }
            return p.EmployeeID;

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

            .Where(p => p.EmployeeID.ToString().ToLower().Contains(sSearchAll) || p.EmployeeName.ToString().ToLower().Contains(sSearchAll) || p.Designation.ToString().ToLower().Contains(sSearchAll) || p.Department.ToString().ToLower().Contains(sSearchAll) || p.Division.ToString().ToLower().Contains(sSearchAll) || p.Paygrade.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
             .Where(p => p.EmployeeID.ToString().ToLower().Contains(sSearchEmployeeID))
            .Where(p => p.EmployeeName.ToString().ToLower().Contains(sSearchEmployeeName))
            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesignation))

             .Where(p => p.Department.ToString().ToLower().Contains(sSearchDepartment))
            .Where(p => p.Division.ToString().ToLower().Contains(sSearchDivision))
            .Where(p => p.Paygrade.ToString().ToLower().Contains(sSearchPaygrade))

            .Select(p => new[] { p.EmployeeID.ToString(), p.EmployeeName.ToString(), p.Designation.ToString(), p.Department.ToString(), p.Division.ToString(), p.Paygrade.ToString(), p.MoreInfo.ToString() })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.EmployeeID.ToString().ToLower().Contains(sSearchAll) || p.EmployeeName.ToString().ToLower().Contains(sSearchAll) || p.Designation.ToString().ToLower().Contains(sSearchAll) || p.Department.ToString().ToLower().Contains(sSearchAll) || p.Division.ToString().ToLower().Contains(sSearchAll) || p.Paygrade.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
             .Where(p => p.EmployeeID.ToString().ToLower().Contains(sSearchEmployeeID))
            .Where(p => p.EmployeeName.ToString().ToLower().Contains(sSearchEmployeeName))  // Search: Avoid Contains() in production
            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesignation))

            .Where(p => p.Department.ToString().ToLower().Contains(sSearchDepartment))
            .Where(p => p.Division.ToString().ToLower().Contains(sSearchDivision))  // Search: Avoid Contains() in production
            .Where(p => p.Paygrade.ToString().ToLower().Contains(sSearchPaygrade))

            .Select(p => new[] { p.EmployeeID.ToString(), p.EmployeeName.ToString(), p.Designation.ToString(), p.Department.ToString(), p.Division.ToString(), p.Paygrade.ToString(), p.MoreInfo.ToString() }).Count(),
        };


        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        var json = serializer.Serialize(result);
        context.Response.ContentType = "application/json";
        context.Response.Write(json);


    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }



    public class Person
    {
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }

        public string Division { get; set; }
        public string Paygrade { get; set; }
        public string MoreInfo { get; set; }

        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string OrgId, string CorpId, string DesignationId, string DepartmentId, string DivisionId, string ProjectId, string ReligionId, string GenderId, string NumOfYears, string PayGradeId, string AgeFrom, string AgeTo, string StatusId, string NationalityId)
        {

            clsEntityEmployeeDetailsReport objEntityEmployeeDetailsreport = new clsEntityEmployeeDetailsReport();
            clsBusinessLayerEmployeeDetailsReport objBusinessEmployeeDetailsReport = new clsBusinessLayerEmployeeDetailsReport();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            objEntityEmployeeDetailsreport.OrganisationId = Convert.ToInt32(OrgId);
            objEntityEmployeeDetailsreport.Corporate_id = Convert.ToInt32(CorpId);

            if (DesignationId != "")
            {
                objEntityEmployeeDetailsreport.DesignationId = Convert.ToInt32(DesignationId);
            }


            if (DepartmentId != "")
            {
                objEntityEmployeeDetailsreport.DepartmentId = Convert.ToInt32(DepartmentId);
            }


            if (DivisionId != "")
            {
                objEntityEmployeeDetailsreport.DivisionId = Convert.ToInt32(DivisionId);
            }

            if (ProjectId != "")
            {
                objEntityEmployeeDetailsreport.ProjectId = Convert.ToInt32(ProjectId);
            }

            if (ReligionId != "")
            {
                objEntityEmployeeDetailsreport.ReligionId = Convert.ToInt32(ReligionId);
            }

            /////////////

            if (GenderId != "")
            {
                objEntityEmployeeDetailsreport.GenderId = Convert.ToInt32(GenderId);
            }
            if (NumOfYears != "")
            {
                objEntityEmployeeDetailsreport.NumOfYears = Convert.ToInt32(NumOfYears);
            }
            if (PayGradeId != "")
            {
                objEntityEmployeeDetailsreport.GradeId = Convert.ToInt32(PayGradeId);
            }
            if (AgeFrom != "")
            {
                objEntityEmployeeDetailsreport.AgeFrom = Convert.ToInt32(AgeFrom);
            }
            if (AgeTo != "")
            {
                objEntityEmployeeDetailsreport.AgeTo = Convert.ToInt32(AgeTo);
            }
            if (StatusId != "")
            {
                if (StatusId == "0")
                {
                    objEntityEmployeeDetailsreport.StatusId = 1;
                }
                if (StatusId == "1")
                {
                    objEntityEmployeeDetailsreport.StatusId = 2;
                }
                if (StatusId == "2")
                {
                    objEntityEmployeeDetailsreport.StatusId = 3;
                }
                if (StatusId == "3")
                {
                    objEntityEmployeeDetailsreport.StatusId = 0;
                }                                                             
            }
            if (NationalityId != "")
            {
                objEntityEmployeeDetailsreport.NationalityId = Convert.ToInt32(NationalityId);
            }


            DataTable dtEmpDetails = new DataTable();
            dtEmpDetails = objBusinessEmployeeDetailsReport.ReadEmployeeList(objEntityEmployeeDetailsreport);



            for (int intRowBodyCount = 0; intRowBodyCount < dtEmpDetails.Rows.Count; intRowBodyCount++)
            {

                string strEmployeeID = "";
                string strEmployeeName = "";
                string strDesignation = "";
                string strDepartment = "";
                string strDivision = "";
                string strPaygrade = "";
                string strMoreInfo = "";
                
                
                objEntityEmployeeDetailsreport.UserId = Convert.ToInt32(dtEmpDetails.Rows[intRowBodyCount]["USR_ID"]);
                DataTable dtDivisions = objBusinessEmployeeDetailsReport.ReadDivisionOfEmp(objEntityEmployeeDetailsreport);

                objEntityEmployeeDetailsreport.date = System.DateTime.Now;
                DataTable dtProject = objBusinessEmployeeDetailsReport.ReadProjectDetails(objEntityEmployeeDetailsreport);

                string strShowPrjct = "false";
                if (dtProject.Rows.Count == 0 && ProjectId == "")
                {
                    strShowPrjct = "true";
                }

                foreach (DataRow dtDiv in dtProject.Rows)
                {
                    if (ProjectId != "")
                    {
                        if (dtDiv["PROJECT_ID"].ToString() == ProjectId)
                        {
                            strShowPrjct = "true";
                        }
                    }
                    else
                    {
                        strShowPrjct = "true";
                    }
                }

                //End:-For Project Search



                //Start:-For Division Search
                string strShow = "false";
                string strDivisions = "";
                if (dtDivisions.Rows.Count == 0 && DivisionId == "")
                {
                    strShow = "true";
                }

                foreach (DataRow dtDiv in dtDivisions.Rows)
                {
                    if (strDivisions == "")
                    {
                        strDivisions = dtDiv["CPRDIV_NAME"].ToString();
                    }
                    else
                    {
                        strDivisions = strDivisions + "," + dtDiv["CPRDIV_NAME"];
                    }

                    if (DivisionId != "")
                    {
                        if (dtDiv["CPRDIV_ID"].ToString() == DivisionId)
                        {
                            strShow = "true";
                        }
                    }
                    else
                    {
                        strShow = "true";
                    }

                }
                //End:-For Division Search

                //Start:-For Age Search EVM-0027
                Int64 Years = 000;
                string strShowAge = "false";
                clsCommonLibrary commn = new clsCommonLibrary();

                if (dtEmpDetails.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString() != "")
                {
                    string Dob1 = dtEmpDetails.Rows[intRowBodyCount]["EMPERDTL_DOB"].ToString();
                    DateTime dob = commn.textToDateTime(Dob1);
                    if (dob < DateTime.Now)
                    {

                        Years = new DateTime(DateTime.Now.Subtract(dob).Ticks).Year - 1;
                    }

                }
                //END

                if (AgeFrom != "" && AgeTo != "")
                {
                    if (Years >= Convert.ToInt32(AgeFrom) && Years <= Convert.ToInt32(AgeTo))
                    {
                        strShowAge = "true";
                    }
                }
                else if (AgeFrom != "")
                {
                    if (Years >= Convert.ToInt32(AgeFrom))
                    {
                        strShowAge = "true";
                    }
                }
                else if (AgeTo != "")
                {
                    if (Years <= Convert.ToInt32(AgeTo))
                    {
                        strShowAge = "true";
                    }
                }
                else
                {
                    strShowAge = "true";
                }
                //End:-For Age Search

                
                //Start:-For Exp Years Search
                int ExpYears = 0;
                string strShowExp = "false";
                if (dtEmpDetails.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString() != "")
                {
                    DateTime Dob = commn.textToDateTime(dtEmpDetails.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString());
                    //  DateTime Dob = Convert.ToDateTime(dt.Rows[intRowBodyCount]["EMPERDTL_JOIN_DATE"].ToString());
                    if (Dob < DateTime.Now)
                        ExpYears = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;

                }

                //  CorpId,  DesignationId,  DepartmentId,  DivisionId,  ProjectId,  ReligionId,  GenderId,  NumOfYears,  PayGradeId,  AgeFrom,  AgeTo,  StatusId,  NationalityId)

                if (NumOfYears == "1")
                {
                    if (ExpYears >= 1)
                    {
                        strShowExp = "true";
                    }
                }
                else if (NumOfYears == "2")
                {
                    if (ExpYears >= 3)
                    {
                        strShowExp = "true";
                    }
                }
                else if (NumOfYears == "3")
                {
                    if (ExpYears >= 5)
                    {
                        strShowExp = "true";
                    }
                }
                else if (NumOfYears == "4")
                {
                    if (ExpYears >= 8)
                    {
                        strShowExp = "true";
                    }
                }
                else
                {
                    strShowExp = "true";
                }
                //End:-For Exp Years Search


                if (strShow == "true" && strShowPrjct == "true" && strShowAge == "true" && strShowExp == "true")
                {

                    string strId = dtEmpDetails.Rows[intRowBodyCount][0].ToString();
                    int intIdLength = dtEmpDetails.Rows[intRowBodyCount][0].ToString().Length;
                    string stridLength = intIdLength.ToString("00");
                    string Id = stridLength + strId + strRandom;
                    
                                      
                    for (int intColumnBodyCount = 0; intColumnBodyCount < dtEmpDetails.Columns.Count; intColumnBodyCount++)
                    {
                        if (intColumnBodyCount == 1)
                        {
                            strEmployeeID += "<td class=\"tdT\" style=\" width:20%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtEmpDetails.Rows[intRowBodyCount][3].ToString() + "</td>";
                        }

                        if (intColumnBodyCount == 2)
                        {
                            if (dtEmpDetails.Rows[intRowBodyCount][intColumnBodyCount].ToString() != "")
                            {
                                strEmployeeName = "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtEmpDetails.Rows[intRowBodyCount]["USRNAME"].ToString() + "</td>";
                            }
                            else
                            {
                                strEmployeeName = "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtEmpDetails.Rows[intRowBodyCount][9].ToString() + "</td>";
                            }
                        }

                        if (intColumnBodyCount == 3)
                        {
                            strDesignation = "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtEmpDetails.Rows[intRowBodyCount]["DSGN_NAME"].ToString() + "</td>";
                        }
                        if (intColumnBodyCount == 4)
                        {
                            strDepartment = "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtEmpDetails.Rows[intRowBodyCount]["CPRDEPT_NAME"].ToString() + "</td>";
                        }

                        strDivision = "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + strDivisions + "</td>";

                        strPaygrade = "<td class=\"tdT\" style=\" width:15%;word-break: break-all; word-wrap:break-word;text-align: left;\" >" + dtEmpDetails.Rows[intRowBodyCount][6].ToString().ToUpper() + "</td>";

                        strMoreInfo = "<td class=\"tdT\" style=\"width:5%; word-wrap:break-word;text-align: center;padding-left: 0.5%;\"><input type=\"button\" class=\"save\" style=\"height:22px;margin-top:3%\" value=\"More Info\" onclick='return OpenCancelView(" + strId + ");' /></td>";

                    }
                    
                    
                }


                yield return new Person
                {

                    EmployeeID = strEmployeeID,
                    EmployeeName = strEmployeeName,
                    Designation = strDesignation,
                    Department = strDepartment,
                    Division = strDivision,
                    Paygrade = strPaygrade,
                    MoreInfo = strMoreInfo,
                };
                                
            }
            

            

        }

    }

}