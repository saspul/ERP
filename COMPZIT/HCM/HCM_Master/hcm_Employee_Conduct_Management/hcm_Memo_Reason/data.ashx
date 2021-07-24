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

        var Org_Id = context.Request["ORG_ID"];
        var Corpt_Id = context.Request["CORPT_ID"];
        var status = context.Request["STATUS"];
        var cnclsts = context.Request["CNCL_STS"];
      
        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];

        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchsl = context.Request["sSearch_0"].ToLower();
        var sSearchResn = context.Request["sSearch_1"].ToLower();
        


        var persons = Person.GetPersons(Corpt_Id, Org_Id, status, cnclsts);
    

        Func<Person, object> order = p =>
        {

            if (iSortCol == 1)
            {
                return p.Status;
            }

            return p.Category;

        };

        if ("desc" == iSortDir)
        {
            persons = persons.OrderByDescending(order);
        }
        else
        {
            persons = persons.OrderBy(order);
        }


        
      //  var a = persons.Count();
       
        var result = new
        {
             iTotalRecords = persons.Count(),
          //  iTotalDisplayRecords = persons.Count(),
            
            aaData = persons

            .Where(p => p.Category.ToString().ToLower().Contains(sSearchAll) )  // Search: Avoid Contains() in production
            .Where(p => p.Category.ToString().ToLower().Contains(sSearchResn))  // Search: Avoid Contains() in production
        
            .Select(p => new[] { p.SL, p.Category, p.Status.ToString(), p.EDIT, p.DELETE, p.VIEW })

            .Skip(iDisplayStart)
            .Take(iDisplayLength),
             iTotalDisplayRecords = persons

            .Where(p => p.Category.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.Category.ToString().ToLower().Contains(sSearchResn))  // Search: Avoid Contains() in production

            .Select(p => new[] { p.SL, p.Category, p.Status.ToString(), p.EDIT, p.DELETE, p.VIEW }).Count()
           
        };
      //  var c = persons.Count();
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
        public string SL { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string EDIT { get; set; }
        public string DELETE { get; set; }
        public string VIEW { get; set; }
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id,string status,string cnclsts)
        {
            clsEntity_Memo_Reason_Master objEntityMemoReason = new clsEntity_Memo_Reason_Master();
            clsBusiness_Memo_Reason objBusinessMemoReason = new clsBusiness_Memo_Reason();
            objEntityMemoReason.Organisation_id = Convert.ToInt32(Org_Id);
            objEntityMemoReason.Corporate_id = Convert.ToInt32(Corpt_Id);
            objEntityMemoReason.MemoStatus=Convert.ToInt32(status);
            objEntityMemoReason.CnclStatus=Convert.ToInt32(cnclsts);
          
            DataTable dtReadMemoResnList = objBusinessMemoReason.ReadMemoResnList(objEntityMemoReason);


            int COUNT = 0;
            string sts;
                
          
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            foreach (DataRow dtRowsIn in dtReadMemoResnList.Rows)
            {
                
                
                
                COUNT = COUNT + 1;
                string CNT = Convert.ToString(COUNT);

               
                string STRSTS;
                string strId = dtRowsIn[0].ToString();
                int intIdLength = dtRowsIn[0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string stsmode;
                sts = dtRowsIn[2].ToString();
                string cnclusrId = dtRowsIn[3].ToString();
              
                if (sts == "ACTIVE")
                {
                    stsmode = "1";
                    STRSTS = "<span class=\"responsiveExpander\"></span><img title=\"Make Inactive\"  style=\"  cursor:pointer;float: left;margin-left: 39%;\" src='/Images/Icons/activate.png' onclick=\"return ChangeStatus('" + Id + "','" + stsmode + "','"+cnclusrId+"');\" />";
                  
                }
                else
                {
                    stsmode = "0";
                    STRSTS = "<span class=\"responsiveExpander\"></span><img title=\" Make Active\"  style=\"  cursor:pointer;float: left;margin-left: 39%;\" src='/Images/Icons/inactivate.png' onclick=\"return ChangeStatus('" + Id + "','" + stsmode + "','" + cnclusrId + "');\" />";
                }
               
                    yield return new Person
                    {

                        SL=CNT,
                        Category = dtRowsIn[1].ToString(),
                        Status = STRSTS,
                       
                        EDIT = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"hcm_Memo_Reason_Master.aspx?Id=" + Id + "\"><i class=\"fa fa-pencil\"></i></a>",
                        DELETE = "<td style=\" width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><a class=\"btn btn-xs btn-default \" title=\"Delete\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>",
                        VIEW = "<td style=\" width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"><a class=\"btn btn-xs btn-default \" title=\"View\"onclick='return getdetails(this.href);' href=\"hcm_Memo_Reason_Master.aspx?ViewId=" + Id + "\"><i class=\"fa fa-eye\"></i></a>",
                         
                    };
               
            }
        }

    }

}