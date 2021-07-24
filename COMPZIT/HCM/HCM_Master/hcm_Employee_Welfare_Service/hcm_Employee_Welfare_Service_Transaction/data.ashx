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
        var EditRole = context.Request["EDIT_ROLE"];
        var sts = context.Request["STS"];
        var dtFromDate = context.Request["FROMDATE"];
        var dtToDate = context.Request["TODATE"];
        var CnclSts = context.Request["CNCL_STS"];
        
        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchDesg = context.Request["sSearch_0"].ToLower();
        var sSearchDiv = context.Request["sSearch_1"].ToLower();
        var sSearchDate = context.Request["sSearch_2"].ToLower();
        var sSearchNoEmp = context.Request["sSearch_3"].ToLower();
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id, EditRole, sts, dtFromDate, dtToDate, CnclSts);
        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
            if (iSortCol == 1)
            {
                return p.Division;
            }
            if (iSortCol == 2)
            {
                return p.Date;
            }
            if (iSortCol == 3)
            {
                return p.NoEmp;
            }
             return p.Designation;
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

            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchAll) || p.Division.ToString().ToLower().Contains(sSearchAll)|| p.Date.ToString().ToLower().Contains(sSearchAll)|| p.NoEmp.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesg)) 
            .Where(p => p.Division.ToString().ToLower().Contains(sSearchDiv))// Search: Avoid Contains() in production
            .Where(p => p.Date.ToString().ToLower().Contains(sSearchDate))
             .Where(p => p.NoEmp.ToString().ToLower().Contains(sSearchNoEmp))
            .Select(p => new[] { p.Designation,p.Division,p.Date,p.NoEmp, p.Status,p.Edit,p.Delete,p.View })
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
        public string Designation { get; set; }
        public string Division { get; set; }
        public string Date { get; set; }
        public string NoEmp { get; set; }
        public string Status { get; set; }
        public string Edit { get; set; }
        public string Delete { get; set; }
        public string View { get; set; }
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string editRole, string sts, string dtFromDate, string dtToDate, string CnclSts)
        {
            clsEntityWelfareServiceTransaction objentityPassport = new clsEntityWelfareServiceTransaction();
            clsBusinessWelfareServiceTransaction objBussinesspasprt = new clsBusinessWelfareServiceTransaction();
            clsBusinessLayer objBusinessLayer = new clsBusinessLayer();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            objentityPassport.OrgId = Convert.ToInt32(Org_Id);
            objentityPassport.CorpId = Convert.ToInt32(Corpt_Id);
            objentityPassport.CancelStatus = Convert.ToInt32(sts);
            objentityPassport.CnclStsCbx = Convert.ToInt32(CnclSts);
            
            if (dtFromDate != "")
            {
                objentityPassport.FromDate = objCommon.textToDateTime(dtFromDate);
            }
            if (dtToDate != "")
            {
                objentityPassport.ToDate = objCommon.textToDateTime(dtToDate);
            }         
            DataTable dtCategory = objBussinesspasprt.ReadServiceTransList(objentityPassport);
            string strRandom = objCommon.Random_Number();
            foreach (DataRow dtRowsIn in dtCategory.Rows)
            {
                string strId = dtRowsIn[0].ToString();
                int intIdLength = dtRowsIn[0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                
                
                 DateTime dtTo = Convert.ToDateTime(dtRowsIn["WLTRNMSTR_INS_DATE"].ToString());               
                string desg=dtRowsIn["DSGN_NAME"].ToString();
                string div = dtRowsIn["CPRDEPT_NAME"].ToString();
                if (div == "DEFAULT")
                {
                    div = "";
                }
                string date=dtTo.ToString("dd-MM-yyyy");
                string NoEmpl=dtRowsIn[4].ToString();
                string status = "NOT CONFIRMED";
                if (sts == "1")
                {
                   status = "CONFIRMED"; 
                }
                string editRow = "<td style=\"width:1%;word-break: break-all;text-align:center; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"hcm_Welfare_Service_Transaction.aspx?Id=" + Id + "\"><i class=\"fa fa-pencil\"></i></a>";
                if (sts == "1" || CnclSts=="1")
                {
                    editRow = "<td style=\" width:1%;word-break: break-all; word-wrap:break-word;text-align:center;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><a class=\"btn btn-xs btn-default \" title=\"View\"onclick='return getdetails(this.href);' href=\"hcm_Welfare_Service_Transaction.aspx?ViewId=" + Id + "\"><i class=\"fa fa-eye\"></i></a>";
                }
                  
                        
                yield return new Person
                {
                    Designation = desg,
                    Division=div,
                    Date=date,
                    NoEmp=NoEmpl,
                    Status = status,
                    Edit = editRow,
                    Delete = "<td style=\"width:1%;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Delete\"  onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>",
                    View = editRow,
                };
            }
        }

    }
}
