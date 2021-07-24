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
        var ViewId = context.Request["View_Id"];
        var TableSts = context.Request["Table_Sts"];
      

        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchEmpCode = context.Request["sSearch_0"].ToLower();
        var sSearchEmployee = context.Request["sSearch_1"].ToLower();
        var sSearchDesignation = context.Request["sSearch_2"].ToLower();
        var sSearchJob = context.Request["sSearch_3"].ToLower();
        var sSearchAtt = context.Request["sSearch_4"].ToLower();
        var sSearchOT = context.Request["sSearch_5"].ToLower();

        var sSearchIdle = context.Request["sSearch_6"].ToLower();
        var sSearchFinalOT = context.Request["sSearch_7"].ToLower();
        var sSearchRndedOT = context.Request["sSearch_8"].ToLower();
        
        var sSearchRemarks = context.Request["sSearch_9"].ToLower();
       
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(ViewId, TableSts);

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
                return p.Job;
            }
            if (iSortCol == 4)
            {
                return p.Att;
            }
            if (iSortCol == 5)
            {
                return p.OT;
            }
            if (iSortCol == 6)
            {
                return p.IdleHr;
            }
            if (iSortCol == 7)
            {
                return p.FinalOT;
            }
            if (iSortCol == 8)
            {
                return p.RndedOT;
            }
            if (iSortCol == 9)
            {
                return p.Remark;
            }
            return p.EmpCode;
           
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

            .Where(p => p.EmpCode.ToString().ToLower().Contains(sSearchAll) || p.Employee.ToString().ToLower().Contains(sSearchAll) || p.Designation.ToLower().ToString().Contains(sSearchAll) || p.Job.ToString().ToLower().Contains(sSearchAll) || p.Att.ToString().ToLower().Contains(sSearchAll) || p.OT.ToString().ToLower().Contains(sSearchAll) || p.IdleHr.ToString().ToLower().Contains(sSearchAll) || p.FinalOT.ToString().ToLower().Contains(sSearchAll) || p.RndedOT.ToString().ToLower().Contains(sSearchAll) || p.Remark.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.EmpCode.ToString().ToLower().Contains(sSearchEmpCode))  // Search: Avoid Contains() in production
            .Where(p => p.Employee.ToString().ToLower().Contains(sSearchEmployee))
            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesignation))
            .Where(p => p.Job.ToString().ToLower().Contains(sSearchJob))
            .Where(p => p.Att.ToString().ToLower().Contains(sSearchAtt))
            .Where(p => p.OT.ToString().ToLower().Contains(sSearchOT))

              .Where(p => p.IdleHr.ToString().ToLower().Contains(sSearchIdle))
              .Where(p => p.FinalOT.ToString().ToLower().Contains(sSearchFinalOT))
              .Where(p => p.RndedOT.ToString().ToLower().Contains(sSearchRndedOT))


            .Where(p => p.Remark.ToString().ToLower().Contains(sSearchRemarks))
            .Select(p => new[] { p.EmpCode, p.Employee.ToString(), p.Designation, p.Job, p.Att, p.OT, p.IdleHr, p.FinalOT, p.RndedOT, p.Remark })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.EmpCode.ToString().ToLower().Contains(sSearchAll) || p.Employee.ToString().ToLower().Contains(sSearchAll) || p.Designation.ToLower().ToString().Contains(sSearchAll) || p.Job.ToString().ToLower().Contains(sSearchAll) || p.Att.ToString().ToLower().Contains(sSearchAll) || p.OT.ToString().ToLower().Contains(sSearchAll) || p.IdleHr.ToString().ToLower().Contains(sSearchAll) || p.FinalOT.ToString().ToLower().Contains(sSearchAll) || p.RndedOT.ToString().ToLower().Contains(sSearchAll) || p.Remark.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.EmpCode.ToString().ToLower().Contains(sSearchEmpCode))  // Search: Avoid Contains() in production
            .Where(p => p.Employee.ToString().ToLower().Contains(sSearchEmployee))
            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesignation))
            .Where(p => p.Job.ToString().ToLower().Contains(sSearchJob))
            .Where(p => p.Att.ToString().ToLower().Contains(sSearchAtt))
            .Where(p => p.OT.ToString().ToLower().Contains(sSearchOT))

              .Where(p => p.IdleHr.ToString().ToLower().Contains(sSearchIdle))
              .Where(p => p.FinalOT.ToString().ToLower().Contains(sSearchFinalOT))
              .Where(p => p.RndedOT.ToString().ToLower().Contains(sSearchRndedOT))


            .Where(p => p.Remark.ToString().ToLower().Contains(sSearchRemarks))
            .Select(p => new[] { p.EmpCode, p.Employee.ToString(), p.Designation, p.Job, p.Att, p.OT, p.IdleHr, p.FinalOT, p.RndedOT, p.Remark }).Count()
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
        public string EmpCode { get; set; }
        public string Employee{get;set;}
        public string Designation { get; set; }
        public string Job { get; set; }
        public string Att { get; set; }
        public string OT { get; set; }

        public string IdleHr { get; set; }
        public string FinalOT { get; set; }
        public string RndedOT { get; set; }
        
        public string Remark { get; set; }
      
        
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string ViewId,string TableSts)
        {
            clsBusinessLayerEmployeeDailyWorkHour objBusinessEmpDailyWorkHour = new clsBusinessLayerEmployeeDailyWorkHour();
            clsEntityEmployeeDailyWorkHour objEntityEmpDailyWorkHour = new clsEntityEmployeeDailyWorkHour();
            objEntityEmpDailyWorkHour.EmpDlyWrkHrID = Convert.ToInt32(ViewId);
            objEntityEmpDailyWorkHour.InsTableSts = Convert.ToInt32(TableSts);
            DataTable dtorglist = objBusinessEmpDailyWorkHour.readDailywrksheetDtls(objEntityEmpDailyWorkHour);

           int cout = 0;
            foreach (DataRow dtRowsIn in dtorglist.Rows)
            {
                cout++;
                string colIdleHr = "",  colRoundedOt = "", colRemark = "";
                string TableID = dtRowsIn["EMDLHRDTL_ID"].ToString();
                
                string ConfrmSts = dtRowsIn["EMPDLYHR_CNFRM_STS"].ToString();


                string att = dtRowsIn["ATTENDANCE"].ToString();

                string name = dtRowsIn["EMPLOYEE_NAME"].ToString();

                string FinalOTstr = "";
                Decimal idlHr = Convert.ToDecimal(dtRowsIn["EMDLHRDTL_IDLE_HOUR"].ToString());
                if (dtRowsIn["EMDLHRDTL_OT"].ToString() != "")
                {
                    Decimal OTdec = Convert.ToDecimal(dtRowsIn["EMDLHRDTL_OT"].ToString());
                    if (idlHr >= OTdec)
                    {
                        FinalOTstr = "0";
                    }
                    else
                    {
                        FinalOTstr = Convert.ToString(OTdec - idlHr);
                    }
                }

                string colOT = "", colFinalOT = "";
                
                
                if (ConfrmSts == "1")
                {
                    colIdleHr = dtRowsIn["EMDLHRDTL_IDLE_HOUR"].ToString();
                    colRoundedOt= dtRowsIn["EMDLHRDTL_RNDED_OT"].ToString();
                    colRemark = dtRowsIn["EMDLHRDTL_REMARKS"].ToString();
                    colOT = dtRowsIn["EMDLHRDTL_OT"].ToString();
                    colFinalOT = FinalOTstr;
                                  
                }
                else
                {
                    colIdleHr = "<th class=\"hasinput\" style=\"width:20%\"><input id=\"txtIdleHR" + TableID + "\" style=\"text-align:left;width:100%;padding:3px;height:20px;\" type=\"text\" class=\"form-control\" value=\"" + dtRowsIn["EMDLHRDTL_IDLE_HOUR"].ToString() + "\" onblur=\"return BlurIdleHr(" + TableID + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" maxlength=5 /></th>";
                    colRoundedOt = "<th class=\"hasinput\" style=\"width:20%\"><input id=\"txtRoudedOT" + TableID + "\" style=\"text-align:left;width:100%;padding:3px;height:20px;\" type=\"text\" class=\"form-control\" value=\"" + dtRowsIn["EMDLHRDTL_RNDED_OT"].ToString() + "\" onblur=\"return BlurRoundedOT(" + TableID + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" maxlength=5 /></th>";
                    colRemark = "<th class=\"hasinput\" style=\"width:20%\"><input id=\"txtRemrks" + TableID + "\" style=\"text-align:left;width:100%;padding:3px;height:20px;\" type=\"text\" class=\"form-control\" value=\"" + dtRowsIn["EMDLHRDTL_REMARKS"].ToString() + "\" onkeydown=\"return isTag(event)\" onkeypress=\"return isTag(event)\" onblur=\"return BlurRemark(" + TableID + ");\" maxlength=100 /></th>";
                    colOT = "<th class=\"hasinput\" style=\"width:20%\"><input disabled id=\"txtOT" + TableID + "\" style=\"text-align:left;width:100%;padding:3px;height:20px;\" type=\"text\" class=\"form-control\" value=\"" + dtRowsIn["EMDLHRDTL_OT"].ToString() + "\" onblur=\"return BlurIdleHr(" + TableID + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" maxlength=5 /></th>";
                    colFinalOT = "<th class=\"hasinput\" style=\"width:20%\"><input disabled id=\"txtFinalOT" + TableID + "\" style=\"text-align:left;width:100%;padding:3px;height:20px;\" type=\"text\" class=\"form-control\" value=\"" + FinalOTstr + "\" onblur=\"return BlurIdleHr(" + TableID + ");\" onkeydown=\"return isNumberDec(event)\" onkeypress=\"return isNumberDec(event)\" maxlength=5 /></th>";
                                
                }
                string ShowAmnt = "";
                if (dtRowsIn["CNT_AMNENDMENT"].ToString() != "0" && dtRowsIn["CNT_AMNENDMENT"].ToString()!="")
                {
                    ShowAmnt = "<span class=\"responsiveExpander\"></span><button class=\"btn btn-xs btn-default\" title=\"Show Amendment\" data-original-title=\"Show Amendment\" onclick=\"return ShowAmendment(" + dtRowsIn["CNT_AMNENDMENT"].ToString() + ");\"><i class=\"fa fa-info\"></i></button>";
                }
              
                yield return new Person
                {

                    EmpCode = dtRowsIn["USR_CODE"].ToString() +" "+ ShowAmnt,
                    Employee = name,
                    Designation = dtRowsIn["DESIGNATION"].ToString(),
                    Job = dtRowsIn["PROJECTS_INTER_REF"].ToString(),
                    Att = att,
                    OT = colOT,
                    IdleHr = colIdleHr,
                    FinalOT = colFinalOT,
                    RndedOT = colRoundedOt,
                    Remark = colRemark,
                 
                };
            }
        }

    }
}
