<%@ WebHandler Language="C#" Class="dataVIewWPSList" %>

using System;
using System.Web;
using System.Linq;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using System.Data;

public class dataVIewWPSList : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        //PARAMETERS MANUALLY ADDED
        var Org_Id = context.Request["ORG_ID"];
        var Corpt_Id = context.Request["CORPT_ID"];
        var Mode = context.Request["MODE"];
        var BusnsUnit = context.Request["BSNS_UNIT"];
        var Month = context.Request["MONTH"];
        var Year = context.Request["YEAR"];
        var ProcessDate = context.Request["PRCS_DATE"];
        var Type = context.Request["TYPE"];

        var Bank = context.Request["BANK"];
        var Designation = context.Request["DESIG_ID"]; ;
        var Department = context.Request["DEP_ID"];
        var Division = context.Request["DIV_ID"];
    
        // Those parameters are sent by the plugin

        var iDisplayLength = 0;
        if (context.Request["iDisplayLength"]!="")
         iDisplayLength=   int.Parse(context.Request["iDisplayLength"]);
        
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);

        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchEmpId = context.Request["sSearch_0"].ToLower();
        var sSearchEmpName = context.Request["sSearch_1"].ToLower();
        var sSearchDesg = context.Request["sSearch_2"].ToLower();
        var sSearchTotAmnt = context.Request["sSearch_3"].ToLower();
        var sSearchPaidAmnt = context.Request["sSearch_4"].ToLower();

        // Fetch the data from a repository (in my case in-memory)
     
           var persons = Person.GetPersons(Corpt_Id, Org_Id, Mode, BusnsUnit, Month, Year, ProcessDate, Type, Bank, Designation, Division, Department);

        //  prepare an anonymous object for JSON serialization
        var result = new
        {
            iTotalRecords = persons.Count(),
            // iTotalDisplayRecords = persons.Count(),
            aaData = persons

            .Where(p => p.Empname.ToString().ToLower().Contains(sSearchAll.ToLower()) || p.EmpId.ToString().ToLower().Contains(sSearchAll.ToLower()) || p.Designation.ToString().ToLower().Contains(sSearchAll.ToLower()) || p.TotalAmt.ToString().ToLower().Contains(sSearchAll.ToLower()) || p.PaidAmt.ToLower().ToString().Contains(sSearchAll.ToLower()))  // Search: Avoid Contains() in production
                // Search: Avoid Contains() in production
            .Where(p => p.EmpId.ToString().ToLower().Contains(sSearchEmpId.ToLower()))
            .Where(p => p.Empname.ToString().ToLower().Contains(sSearchEmpName.ToLower()))
            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesg.ToLower()))
            .Where(p => p.TotalAmt.ToString().ToLower().Contains(sSearchTotAmnt.ToLower()))
            .Where(p => p.PaidAmt.ToString().ToLower().Contains(sSearchPaidAmnt.ToLower()))
            .Select(p => new[] { p.check, p.EmpId.ToString(), p.Empname.ToString(), p.Designation, p.Paygrade, p.TotalAmt, p.PaidAmt, p.Close })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.Empname.ToString().ToLower().Contains(sSearchAll.ToLower()) || p.EmpId.ToString().ToLower().Contains(sSearchAll.ToLower()) || p.Designation.ToString().ToLower().Contains(sSearchAll.ToLower()) || p.TotalAmt.ToString().ToLower().Contains(sSearchAll.ToLower()) || p.PaidAmt.ToLower().ToString().Contains(sSearchAll.ToLower()))  // Search: Avoid Contains() in production
                // Search: Avoid Contains() in production
            .Where(p => p.EmpId.ToString().ToLower().Contains(sSearchEmpId.ToLower()))
            .Where(p => p.Empname.ToString().ToLower().Contains(sSearchEmpName.ToLower()))
            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesg.ToLower()))
            .Where(p => p.TotalAmt.ToString().ToLower().Contains(sSearchTotAmnt.ToLower()))
            .Where(p => p.PaidAmt.ToString().ToLower().Contains(sSearchPaidAmnt.ToLower()))
            .Select(p => new[] { p.check, p.EmpId.ToString(), p.Empname.ToString(), p.Designation, p.Paygrade, p.TotalAmt, p.PaidAmt, p.Close }).Count()
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
        public string check { get; set; }
        public string EmpId { get; set; }
        public string Empname{get;set;}
        public string Designation { get; set; }
        public string TotalAmt { get; set; }
        public string PaidAmt { get; set; }
        public string Close { get; set; }
        public string Paygrade { get; set; }  
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string Mode, string BusnsUnit, string Month, string Year, string ProcessDate, string Type, string Bank,string Designation,string Division,string Department)
        {

            ClsEntityLayerWps_List objEntityWPS_List = new ClsEntityLayerWps_List();
            clsBusiness_Mnthly_WPS_List objBusinessLayerWPS_List = new clsBusiness_Mnthly_WPS_List();

            clsBusinessLayer objBusiness = new clsBusinessLayer();
            clsEntityCommon objEntityCommon = new clsEntityCommon();
            clsCommonLibrary objCommon = new clsCommonLibrary();
            DataTable dtlist = new DataTable();
          
            if (Mode != "0")
            {
                objEntityWPS_List.CorprtId = Convert.ToInt32(Corpt_Id);
                objEntityWPS_List.OrgId = Convert.ToInt32(Org_Id);
                if (Month != "--SELECT MONTH--")
                {
                    objEntityWPS_List.Month = Convert.ToInt32(Month);
                }
                if (Year != "--SELECT YEAR--")
                {
                    objEntityWPS_List.Year = Convert.ToInt32(Year);
                }
                if(Mode!="")
                {
                    objEntityWPS_List.Mode = Convert.ToInt32(Mode);
                }
                objEntityWPS_List.Staff_Worker = Convert.ToInt32(Type);
                if (ProcessDate != "")
                {
                    objEntityWPS_List.date = objCommon.textToDateTime(ProcessDate);
                }
                if (BusnsUnit != null && BusnsUnit != "")
                {
                    objEntityWPS_List.BusnsUnitId = Convert.ToInt32(BusnsUnit);
                }
                if (Bank != "--SELECT BANK--")
                {
                    objEntityWPS_List.BankId = Convert.ToInt32(Bank);
                } if (Division != "--SELECT DIVISION--")
                {
                    objEntityWPS_List.Division = Convert.ToInt32(Division);
                } if (Designation != "--SELECT DESIGNATION--")
                {
                    objEntityWPS_List.Designation = Convert.ToInt32(Designation);
                }
                if (Department != "--SELECT DEPARTMENT--")
                {
                    objEntityWPS_List.Department = Convert.ToInt32(Department);
                }
                dtlist = objBusinessLayerWPS_List.ReadMonthlySal_PaidList(objEntityWPS_List);        
            }
            
            string Ids = "";
            string amount = "";
            string SettledLeavMssg = "";
            foreach (DataRow dtRowsIn in dtlist.Rows)
            {
                string TableID = dtRowsIn["USR_ID"].ToString();

                if (Ids == "")
                {
                    Ids = TableID;
                }
                else
                {
                    Ids = Ids + "," + TableID;
                    
                }
             }
            int i = 0;
            foreach (DataRow dtRowsIn in dtlist.Rows)
            {
                i++;
                string paidS = "";
            
                string TableID = dtRowsIn["USR_ID"].ToString();
                if (Mode == "1")
                {
                    objEntityWPS_List.Employee = Convert.ToInt32(dtRowsIn["USR_ID"].ToString());
                    DataTable dtLeavSettlmentVChk = objBusinessLayerWPS_List.ReadLeavSettlmentChk(objEntityWPS_List);
                    decimal decSettlmntAmnt = 0;
                    if (dtLeavSettlmentVChk.Rows.Count > 0)
                    {
                        decSettlmntAmnt = Convert.ToDecimal(dtLeavSettlmentVChk.Rows[0]["LEVSETLMT_CRNTMNTH_SAL"].ToString());
                        if (decSettlmntAmnt > 0)
                        {
                            SettledLeavMssg = "LEAVE SETTLED";
                        }
                        else
                        {
                            SettledLeavMssg = "";
                        }
                    }
                }
                string StlID = dtRowsIn["STL_ID"].ToString();
                paidS = "<th class=\"hasinput\" style=\"width:20%\"><input name=\"txtPaid" + StlID + "\" id=\"txtPaid" + StlID + "\"value=\"" + SettledLeavMssg + "\" style=\"text-align:left;width:100%;\" type=\"text\" class=\"form-control\" onkeypress=\"return isTag(event)\" onblur=\"return blurcomments('#txtPaid" + StlID + "',450);\"  maxlength=100 /></th>";
   
                objEntityCommon.CorporateID =Convert.ToInt32(Corpt_Id);
                amount = objBusiness.AddCommasForNumberSeperation(dtRowsIn["NET_AMOUNT"].ToString(), objEntityCommon);
                yield return new Person
                {
                    EmpId = dtRowsIn["USR_CODE"].ToString(),
                    Empname = dtRowsIn["Empname"].ToString(),
                    Designation = dtRowsIn["DSGN_NAME"].ToString(),
                    Paygrade = dtRowsIn["PYGRD_NAME"].ToString(),
                    TotalAmt = amount,
                    PaidAmt = paidS,
                    Close = "<td style=\" width:5%;word-break: break-all; word-wrap:break-word;display:none\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\" ><input type=\"text\"  value=\"" + TableID + "\"  id=\"allIds" + i + "\" style=\"display:none;\" /><input type=\"text\"  value=\"" + StlID + "\"  id=\"STl_id" + i + "\" style=\"display:none;\" /></td> ",
                   check = "<th class=\"hasinput\" style=\"width:2.5%;text-align: center;\"> <label class=\"checkbox\"style=\"margin-bottom: 13%;\" ><input type=\"checkbox\"  onchange=\"check() \" onkeypress='return DisableEnter(event)'  id=\"cbMandatory" + i + "\"><i  style=\"margin-left: 30%;\"></i></label>",
            
                };
            }           
        }

    }
}
