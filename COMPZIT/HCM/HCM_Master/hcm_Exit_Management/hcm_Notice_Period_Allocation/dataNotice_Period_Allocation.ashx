<%@ WebHandler Language="C#" Class="dataNotice_Period_Allocation" %>

using System;
using System.Web;
using System.Linq;
using BL_Compzit.BusineesLayer_HCM;
using EL_Compzit.EntityLayer_HCM;
using CL_Compzit;
using EL_Compzit;
using BL_Compzit;
using System.Data;

public class dataNotice_Period_Allocation : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var OrgId = context.Request["ORG_ID"];
        var DesgTypId = context.Request["DESGTYP_ID"];
        var DesgCntrl = context.Request["DESG_CNTRL"];
        var UserId = context.Request["USERID"];
        var CorpId = context.Request["CORPOFFICEID"];


        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchDesignation = context.Request["sSearch_0"].ToLower();
        var sSearchNoticeDays = context.Request["sSearch_1"].ToLower();
        var sSearchStatus = context.Request["sSearch_2"].ToLower();

        var persons = Person.GetPersons(OrgId, DesgTypId, DesgCntrl, UserId, CorpId);

        Func<Person, object> order = p =>
        {


            if (iSortCol == 1)
            {
                return p.NoticeDays;
            }
            if (iSortCol == 2)
            {
                return p.Status;
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

            aaData = persons

            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchAll) || p.NoticeDays.ToString().ToLower().Contains(sSearchAll) || p.Status.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
             .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesignation))
            .Where(p => p.NoticeDays.ToString().ToLower().Contains(sSearchNoticeDays))  // Search: Avoid Contains() in production
            .Where(p => p.Status.ToString().ToLower().Contains(sSearchStatus))

            .Select(p => new[] { p.Designation, p.NoticeDays.ToString(), p.Status.ToString(), p.Action.ToString() })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.Designation.ToString().ToLower().Contains(sSearchAll) || p.NoticeDays.ToString().ToLower().Contains(sSearchAll) || p.Status.ToString().ToLower().Contains(sSearchAll) )  // Search: Avoid Contains() in production
             .Where(p => p.Designation.ToString().ToLower().Contains(sSearchDesignation))
            .Where(p => p.NoticeDays.ToString().ToLower().Contains(sSearchNoticeDays))  // Search: Avoid Contains() in production
            .Where(p => p.Status.ToString().ToLower().Contains(sSearchStatus))

            .Select(p => new[] { p.Designation, p.NoticeDays, p.Status.ToString(), p.Action.ToString() }).Count(),
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
        public string Designation { get; set; }
        public string NoticeDays { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }

        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string OrgId, string DesgTypId, string DesgCntrl, string UserId, string CorpId)
        {

            clsBusinessLayerNoticePeriod objBusinessNoticePeriod = new clsBusinessLayerNoticePeriod();
            clsEntityLayerNoticePeriod objEntityNoticePeriod = new clsEntityLayerNoticePeriod();

            objEntityNoticePeriod.OrgId = Convert.ToInt32(OrgId);
            objEntityNoticePeriod.DesignationTypeId = Convert.ToInt32(DesgTypId);
            objEntityNoticePeriod.DsgControl = Convert.ToChar(DesgCntrl);
            DataTable dtNoticePeriodList = objBusinessNoticePeriod.ReadNoticePrdAllocationList(objEntityNoticePeriod);


            int RowCount = 0;
            foreach (DataRow dtRowsIn in dtNoticePeriodList.Rows)
            {
                RowCount++;
                
                string strDesignationId = dtRowsIn["DSGN_ID"].ToString();
                string strDesignation = dtRowsIn["DESIGNATION NAME"].ToString();
                string strMsg = "INS";
                  
                
                
                string strNoticeDays = "";
                string strStatus = "";
                string strAction = "";
                string NoticePrdId = "";
                
            

                if (dtRowsIn["NTCPRD_INS_USR_ID"].ToString() == "")
                {
                    strNoticeDays = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"text\" onkeydown=\"return isNum(event)\" onblur=\"checkDays(" + RowCount + ");\" maxlength=3 class\"form-control\" id=\"NoticeDays_" + RowCount + "\" /></td>";
                    strStatus = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"checkbox\" class\"form-control\" id=\"cbxStatus_" + RowCount + "\" /></td>";
                    strAction = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a href=\"javascript:void(0)\" class=\"btn btn-xs btn-default\" title=\"Save\"   onclick=\"return SaveNoticePeriod('" + NoticePrdId + "'," + strDesignationId + "," + UserId + "," + OrgId + "," + CorpId + ",'" + strMsg + "'," + RowCount + ");\"><i class=\"glyphicon glyphicon-floppy-disk\"></i><b id=\"btnSave_" + RowCount + "\">Save</b></a>";
                }
                else
                {
                    if (dtRowsIn["NTCPRD_ID"].ToString() != "")
                    {
                        NoticePrdId = dtRowsIn["NTCPRD_ID"].ToString();
                        strMsg = "UPD";
                    }

                    strNoticeDays = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input value=\"" + dtRowsIn["NTCPRD_DAYS"].ToString() + "\" type=\"text\" onkeydown=\"return isNum(event)\" onblur=\"checkDays(" + RowCount + ");\" maxlength=3 class\"form-control\" id=\"NoticeDays_" + RowCount + "\" /></td>";

                    if (dtRowsIn["NTCPRD_STATUS"].ToString() == "1")
                    {
                        strStatus = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"checkbox\" class\"form-control\" id=\"cbxStatus_" + RowCount + "\" checked /></td>";
                    }
                    else
                    {
                        strStatus = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"checkbox\" class\"form-control\" id=\"cbxStatus_" + RowCount + "\" /></td>";
                    }
                    strAction = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a href=\"javascript:void(0)\" class=\"btn btn-xs btn-default\" title=\"Update\"   onclick=\"return SaveNoticePeriod(" + NoticePrdId + "," + strDesignationId + "," + UserId + "," + OrgId + "," + CorpId + ",'" + strMsg + "'," + RowCount + ");\"><i class=\"glyphicon glyphicon-floppy-disk\"></i><b id=\"btnUpdate_" + RowCount + "\">Update</b></a>";           
                }


                yield return new Person
                {

                    Designation = strDesignation,
                    NoticeDays = strNoticeDays,
                    Status = strStatus,
                    Action = strAction,

                };
            }
        }
    }

}