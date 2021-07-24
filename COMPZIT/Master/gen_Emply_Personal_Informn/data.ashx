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
        var DesgId = context.Request["DESG_ID"];
        var LmtdUser = context.Request["LMTD_USER"];
      
        //0039 for fil search
        
        var fromDate = context.Request["FR_DATE"];
        var toDate = context.Request["TO_DATE"];
        //end 0039

        DateTime dtDateMin = new DateTime();
        
        if (fromDate == "")
        {
            fromDate = dtDateMin.ToString("dd-MM-yyyy");
        }

        if (toDate == "")
        {
            toDate = dtDateMin.ToString("dd-MM-yyyy");
        }
        
        //end
      
        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchEmpId = context.Request["sSearch_0"].ToLower();
        var sSearchEmp = context.Request["sSearch_1"].ToLower();
        var sSearchDesg = context.Request["sSearch_2"].ToLower();
        var sSearchDept = context.Request["sSearch_3"].ToLower();
        var sSearchSts = context.Request["sSearch_4"].ToLower();
       
       
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id, Status, CnclSts, DesgId, LmtdUser, fromDate, toDate);

        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
           
           
            if (iSortCol ==1)
            {
                return p.Employee;
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
                return p.Status;
            }
            return p.UserId;
           
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

            .Where(p => p.UserId.ToString().ToLower().Contains(sSearchAll) || p.Employee.ToString().ToLower().Contains(sSearchAll) || p.Designation.ToString().ToLower().Contains(sSearchAll) || p.Department.ToLower().ToString().Contains(sSearchAll) || p.Status.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
             .Where(p => p.UserId.ToString().ToLower().Contains(sSearchEmpId))
            .Where(p => p.Employee.ToString().ToLower().Contains(sSearchEmp))  // Search: Avoid Contains() in production
            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesg))
            .Where(p => p.Department.ToString().ToLower().Contains(sSearchDept))
            .Where(p => p.Status.ToString().ToLower().Contains(sSearchSts))
            .Select(p => new[] { p.UserId, p.Employee, p.Designation.ToString(), p.Department, p.Status, p.Edit, p.View, p.Rejoin })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.UserId.ToString().ToLower().Contains(sSearchAll) || p.Employee.ToString().ToLower().Contains(sSearchAll) || p.Designation.ToString().ToLower().Contains(sSearchAll) || p.Department.ToLower().ToString().Contains(sSearchAll) || p.Status.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
             .Where(p => p.UserId.ToString().ToLower().Contains(sSearchEmpId))
            .Where(p => p.Employee.ToString().ToLower().Contains(sSearchEmp))  // Search: Avoid Contains() in production
            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesg))
            .Where(p => p.Department.ToString().ToLower().Contains(sSearchDept))
            .Where(p => p.Status.ToString().ToLower().Contains(sSearchSts))
            .Select(p => new[] { p.UserId, p.Employee, p.Designation.ToString(), p.Department, p.Status, p.Edit, p.View, p.Rejoin }).Count(),
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
        public string UserId { get; set; } 
        public string Employee { get; set; }
        public string Designation{get;set;}
        public string Department { get; set; }
        public string Status { get; set; }
        public string Edit { get; set; }
        public string View { get; set; }
        //0039
        public string Rejoin { get; set; }
        //end
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string Status, string CnclSts, string DesgId, string LmtdUser, string fromDate, string toDate)
        {
            clsBusinessLayerUserRegisteration objBusinessLayerUsrReg = new clsBusinessLayerUserRegisteration();
            clsEntityLayerUserRegistration objEntityUserRegistration = new clsEntityLayerUserRegistration();
            ////0039
            clsCommonLibrary objCommon = new clsCommonLibrary();
            ////end
            objEntityUserRegistration.UserOrgId=Convert.ToInt32(Org_Id);
            objEntityUserRegistration.UserCrprtId = Convert.ToInt32(Corpt_Id);
            objEntityUserRegistration.LimitedUser = Convert.ToInt32(LmtdUser);
            objEntityUserRegistration.UserDsgnId = Convert.ToInt32(DesgId);
            objEntityUserRegistration.UserStatus = Convert.ToInt32(Status);
            objEntityUserRegistration.Cancel_Status = Convert.ToInt32(CnclSts);
            //0039
            //if (fromDate != DateTime.MinValue)
            //objEntityUserRegistration.LeaveFrmDate = Convert.ToDateTime(fromDate);
            //objEntityUserRegistration.LeaveToDate = Convert.ToDateTime(toDate);

            objEntityUserRegistration.LeaveFrmDate = objCommon.textToDateTime(fromDate);
            objEntityUserRegistration.LeaveToDate = objCommon.textToDateTime(toDate);
            //end

            DataTable dtUser =objBusinessLayerUsrReg.GridDisplay(objEntityUserRegistration);
                           
            //clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            foreach (DataRow dtRowsIn in dtUser.Rows)
            {
               
               //int hh = Convert.ToInt32(dtUser.Rows[0]["LASTREJOIN_DATE"].ToString());
                string strId = dtRowsIn[0].ToString();
                int intIdLength = dtRowsIn[0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strStatus="";
                string Rejoin = "";
                if (dtRowsIn[5].ToString() !="0")
                {
                    if (dtRowsIn[5].ToString() =="1")
                    {
                          strStatus = "RESIGN";
                    }
                    else if (dtRowsIn[5].ToString() =="2")
                    {
                          strStatus = "TERMINATION";
                    }
                    else if (dtRowsIn[5].ToString() =="3")
                    {
                          strStatus = "RETIREMENT";
                    }
                     else if (dtRowsIn[5].ToString() =="4")
                    {
                          strStatus = "ABSCOND";
                    }
                     else if (dtRowsIn[5].ToString() =="5")
                    {
                          strStatus = "DEATH";
                    }
                     else if (dtRowsIn[5].ToString() =="6")
                    {
                          strStatus = "REJOIN";
                    }
                     else if (dtRowsIn[5].ToString() =="7")
                    {
                          strStatus = "UNDER POLICE CUSTODY";
                    }
                    else if (dtRowsIn[5].ToString() =="8")
                    {
                          strStatus = "OTHER";
                    }
                }
                else if (dtRowsIn["LEAVE_STS"].ToString() != "0")
                {
                    strStatus = "ON LEAVE";
                }
                else
                {
                    strStatus = dtRowsIn[4].ToString();
                }
                //0039 nw
                if (dtRowsIn["EOSETL_DATE"].ToString() != "" && dtRowsIn["REJOIN_STS"].ToString() != "1")
                {

                    Rejoin = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Rejoin\"  onclick=\"return RejoinAlert('" + Id + "');\">  <img src=\"../../Images/Icons/shake_hnd.png\" /></a>";

                    //Rejoin = dtRowsIn[4].ToString();
                }
                else
                {


                    Rejoin = "";
                    
                }
             
                   
                
                //0039
                yield return new Person
                {

                    UserId = dtRowsIn["USR_CODE"].ToString(),
                    Employee = dtRowsIn[1].ToString(),
                    Designation = dtRowsIn[2].ToString(),
                    Department = dtRowsIn[3].ToString(),
                    Status = strStatus,                    
                    Edit = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"gen_Emply_Personal_Informn.aspx?Id=" + Id + "\"><i class=\"fa fa-pencil\"></i></a>",
                    View = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"View\"  onclick=\"return preview('" + Id + "');\"><i class=\"fa fa-eye\"></i></a>",
                    Rejoin = Rejoin,
                };
               
               
            }
        }

    }
}
