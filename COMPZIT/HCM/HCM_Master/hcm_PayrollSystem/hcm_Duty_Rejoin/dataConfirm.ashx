<%@ WebHandler Language="C#" Class="dataConfirm" %>

using System;
using System.Web;
using System.Linq;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using System.Data;

public class dataConfirm : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //PARAMETERS MANUALLY ADDED
        var Org_Id = context.Request["ORG_ID"];
        var Corpt_Id = context.Request["CORPT_ID"];
        var user_id = context.Request["USER_ID"];
        var hr_confirm = context.Request["HR_CONFIRM"];
        var Radio_Btn = context.Request["RADIO_BTN"];
        var Conf_mode = context.Request["CONF_MODE"];
        
        

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
        var persons = Person.GetPersons(Corpt_Id, Org_Id, user_id, hr_confirm, Radio_Btn, Conf_mode);

        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {


            if (iSortCol == 1)
            {
                return p.Employeeid;
            }
            if (iSortCol ==2)
            {
                return p.Employee;
            }

            if (iSortCol == 3)
            {
                return p.Designation;
            }
            if (iSortCol == 4)
            {
                return p.Department;
            }
            if (iSortCol == 5)
            {
                return p.LeaveFromDate;
            }
            if (iSortCol == 6)
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
            .Select(p => new[] { p.Employeeid, p.Employee, p.Designation.ToString(), p.Department, p.LeaveFromDate, p.LeaveToDate, p.Confirm })
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
            .Select(p => new[] { p.Employeeid, p.Employee, p.Designation.ToString(), p.Department, p.LeaveFromDate, p.LeaveToDate, p.Confirm }).Count()
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
        public string Designation { get; set; }
        public string Department { get; set; }
        public string LeaveFromDate { get; set; }
        public string LeaveToDate { get; set; }
        public string Confirm { get; set; }
        public string Employeeid { get; set; }

        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string user_id, string hr_confirm, string Radio_Btn, string Conf_mode)
        {
            clsBusinessLayerDutyRejoin objBusinessDutyRejoin = new clsBusinessLayerDutyRejoin();
            clsEntityLayerDutyRejoin objEntityDutyRejoin = new clsEntityLayerDutyRejoin();


            objEntityDutyRejoin.CorpId = Convert.ToInt32(Corpt_Id);
            objEntityDutyRejoin.orgid = Convert.ToInt32(Org_Id);
            objEntityDutyRejoin.UserDate = System.DateTime.Now;

            DataTable dtorglist=new DataTable();
            if (Radio_Btn == "1")
            {
             dtorglist = objBusinessDutyRejoin.ReadConfirmList(objEntityDutyRejoin);
            }
            else
            {
             dtorglist = objBusinessDutyRejoin.ReadRejectedList(objEntityDutyRejoin);  
            }
                
                foreach (DataRow dtRowsIn in dtorglist.Rows)
                {
                    Boolean show = true;
                    string strDutyRejoinSts = dtRowsIn["DUTYREJOIN_STATUS"].ToString();
                    string ReportOfcrSts = "0";

                    string strUserId = dtRowsIn["USR_ID"].ToString();
                    objEntityDutyRejoin.UserId = Convert.ToInt32(strUserId);
                    DataTable dt = objBusinessDutyRejoin.ReportOfficerRead(objEntityDutyRejoin);
                    if (dt.Rows.Count > 0)
                    {
                        if (user_id == dt.Rows[0][0].ToString())
                        {
                            ReportOfcrSts = "1";
                        }
                    }

                    if (Conf_mode == "0")
                    {
                        if (strDutyRejoinSts == "1" && ReportOfcrSts == "0")
                        {
                            show = false;
                        }
                        else if (strDutyRejoinSts == "2" && ReportOfcrSts == "0")
                        {
                            show = false;
                        }
                        else if (strDutyRejoinSts == "3" && hr_confirm == "0")
                        {
                            show = false;
                        }
                    }
                    else
                    {
                        if (hr_confirm == "0")
                        {
                            show = false;
                        }
                    }
                    string StrConfirm = "";
                    string TableID = dtRowsIn[0].ToString();
                    string userName = dtRowsIn["USR_NAME"].ToString();
                    if (dtRowsIn["USR_NAME2"].ToString() != "")
                    {
                        userName = dtRowsIn["USR_NAME2"].ToString();
                    }
                    if (strDutyRejoinSts == "4")
                    {
                        StrConfirm = "<span class=\"responsiveExpander\"></span><button title=\"View\" runat=\"server\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" onclick=\"return Confirm('" + TableID + "','" + userName + "',' " + dtRowsIn["DSGN_NAME"].ToString() + "','" + dtRowsIn["CPRDEPT_NAME"].ToString() + "','" + dtRowsIn["LEAVE_FROM_DATE"].ToString() + "','" + dtRowsIn["LEAVE_TO_DATE"].ToString() + "','" + dtRowsIn["REJOINDATE"].ToString() + "','" + dtRowsIn["STATUS_PASSPORT_HR"].ToString() + "','" + dtRowsIn["DUTYREJOIN_STATUS"].ToString() + "','" + dtRowsIn["USR_ID"].ToString() + "','" + Radio_Btn + "','" + dtRowsIn["HALFDAY_STATUS"].ToString() + "');\"><i  class=\"fa fa-eye\"></i></button>";
                    }
                    else
                    {
                        StrConfirm = "<span class=\"responsiveExpander\"></span><button title=\"Confirm\" runat=\"server\" class=\"btn btn-xs btn-default\" data-original-title=\"Edit Row\" onclick=\"return Confirm('" + TableID + "','" + userName + "',' " + dtRowsIn["DSGN_NAME"].ToString() + "','" + dtRowsIn["CPRDEPT_NAME"].ToString() + "','" + dtRowsIn["LEAVE_FROM_DATE"].ToString() + "','" + dtRowsIn["LEAVE_TO_DATE"].ToString() + "','" + dtRowsIn["REJOINDATE"].ToString() + "','" + dtRowsIn["STATUS_PASSPORT_HR"].ToString() + "','" + dtRowsIn["DUTYREJOIN_STATUS"].ToString() + "','" + dtRowsIn["USR_ID"].ToString() + "','" + Radio_Btn + "','" + dtRowsIn["HALFDAY_STATUS"].ToString() + "');\"><i  class=\"fa fa-check\"></i></button>";
                    }

                    if (show == true)
                    {
                        yield return new Person
                        {

                            Employee = userName,
                            Employeeid = dtRowsIn["USR_CODE"].ToString(),
                            Designation = dtRowsIn["DSGN_NAME"].ToString(),
                            Department = dtRowsIn["CPRDEPT_NAME"].ToString(),
                            LeaveFromDate = dtRowsIn["LEAVE_FROM_DATE"].ToString(),
                            LeaveToDate = dtRowsIn["LEAVE_TO_DATE"].ToString(),
                            Confirm = StrConfirm
                        };
                    }
                }

            
            
            
            
                      
        }

    }
}
