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
    int flag = 0;
    public void ProcessRequest(HttpContext context)
    {
        //PARAMETERS MANUALLY ADDED
        var Org_Id = context.Request["ORG_ID"];
        var Corpt_Id = context.Request["CORPT_ID"];
        var Status = context.Request["STATUS"];
        var CnclSts = context.Request["CNCL_STS"];
        var DesgId = context.Request["DESG_ID"];
        var LmtdUser = context.Request["LMTD_USER"];
        
       
      
        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchEmpId = context.Request["sSearch_0"].ToLower();
        var sSearchEmp = context.Request["sSearch_1"].ToLower();
        var sSearchLvType = context.Request["sSearch_2"].ToLower();
        var sSearchOpngLeave = context.Request["sSearch_3"].ToLower();
        var sSearchBlncLeave = context.Request["sSearch_4"].ToLower();
        var sSearchAmount = context.Request["sSearch_5"].ToLower();
        var sSearchBlncAmount = context.Request["sSearch_6"].ToLower();
        var sSearchYear = context.Request["Ssearch_7"].ToLower();
       
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id, Status, CnclSts, DesgId, LmtdUser);

        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
           
           
            if (iSortCol ==1)
            {
                return p.Employee;
            }
            if (iSortCol == 2)
            {
                return p.LeaveType;
            }
            if (iSortCol == 3)
            {               
                return p.OpeningLeave;
            }
            if (iSortCol == 4)
            {              
                return p.BalanceLeave;
            }
            //if (iSortCol == 5)
            //{               
            //    return p.Amount;
            //}
            //if (iSortCol == 6)
            //{
            //    return p.BalanceAmount;
            //}
            if (iSortCol == 5)
            {
                return p.Year;
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

            .Where(p => p.UserId.ToString().ToLower().Contains(sSearchAll) || p.Employee.ToString().ToLower().Contains(sSearchAll) || p.LeaveType.ToString().ToLower().Contains(sSearchAll) || p.OpeningLeave.ToString().ToLower().Contains(sSearchAll) || p.BalanceLeave.ToLower().ToString().Contains(sSearchAll) || p.Year.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
             .Where(p => p.UserId.ToString().ToLower().Contains(sSearchEmpId))
            .Where(p => p.Employee.ToString().ToLower().Contains(sSearchEmp))  // Search: Avoid Contains() in production
            .Where(p => p.LeaveType.ToString().ToLower().Contains(sSearchLvType))
            .Where(p => p.OpeningLeave.ToString().ToLower().Contains(sSearchOpngLeave))
            .Where(p => p.BalanceLeave.ToString().ToLower().Contains(sSearchBlncLeave))
          
            .Where(p => p.Year.ToString().ToLower().Contains(sSearchYear))

            .Select(p => new[] { p.UserId, p.Employee, p.LeaveType.ToString(), p.OpeningLeave.ToString(), p.BalanceLeave, p.Year, p.Update, p.Confirm })
            .Skip(iDisplayStart)
            .Take(iDisplayLength),
            iTotalDisplayRecords = persons

            .Where(p => p.UserId.ToString().ToLower().Contains(sSearchAll) || p.Employee.ToString().ToLower().Contains(sSearchAll) || p.LeaveType.ToString().ToLower().Contains(sSearchAll) || p.OpeningLeave.ToString().ToLower().Contains(sSearchAll) || p.BalanceLeave.ToLower().ToString().Contains(sSearchAll) || p.Year.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
             .Where(p => p.UserId.ToString().ToLower().Contains(sSearchEmpId))
            .Where(p => p.Employee.ToString().ToLower().Contains(sSearchEmp))  // Search: Avoid Contains() in production
            .Where(p => p.LeaveType.ToString().ToLower().Contains(sSearchLvType))
           .Where(p => p.OpeningLeave.ToString().ToLower().Contains(sSearchOpngLeave))
            .Where(p => p.BalanceLeave.ToString().ToLower().Contains(sSearchBlncLeave))
            
            .Where(p => p.Year.ToString().ToLower().Contains(sSearchYear))
            .Select(p => new[] { p.UserId, p.Employee, p.LeaveType.ToString(), p.OpeningLeave.ToString(), p.BalanceLeave,p.Year, p.Update, p.Confirm }).Count(),
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
        public string LeaveType { get; set; }
        public string OpeningLeave { get; set; }
        public string BalanceLeave { get; set; }
        //public string Amount { get; set; }
        //public string BalanceAmount { get; set; }
        public string Year { get; set; }
        public string Update { get; set; }
        public string Confirm { get; set; }
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string Status, string CnclSts, string DesgId, string LmtdUser)
        {

            clsEntityOpeningLeaveAlloc objEntityOpngLvAlloc = new clsEntityOpeningLeaveAlloc();
            clsBuisnesslayerOpeningLeaveAlloc objBuisnessOpngLvAlloc = new clsBuisnesslayerOpeningLeaveAlloc();
            objEntityOpngLvAlloc.CorpId = Convert.ToInt32(Corpt_Id);
            objEntityOpngLvAlloc.OrgId = Convert.ToInt32(Org_Id);
            objEntityOpngLvAlloc.LimitedUsrId = Convert.ToInt32(LmtdUser);
            objEntityOpngLvAlloc.DesignationId = Convert.ToInt32(DesgId);
            objEntityOpngLvAlloc.UserSts = Convert.ToInt32(Status);
            objEntityOpngLvAlloc.CancelSts = Convert.ToInt32(CnclSts);

            
            
            DataTable dtUsers = objBuisnessOpngLvAlloc.ReadUsers(objEntityOpngLvAlloc);
         //   DataTable dtLeaveTypes = objBuisnessOpngLvAlloc.ReadLeaveTypes(objEntityOpngLvAlloc);
            
            

            //OPUSLETYP_ID               
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            string strrr = "11";
            decimal dc = Convert.ToDecimal(strrr);

            foreach (DataRow dtRowsIn in dtUsers.Rows)
            {
                string str = dtRowsIn["EMPLOYEE NAME"].ToString();                               

                string strMsg = "INS";
                string strUpdate = "";
                string strConfirm = "";
                string strId = dtRowsIn[0].ToString();
                int intIdLength = dtRowsIn[0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;

                string strLeaveTypId = dtRowsIn["HR_LEAVETYP_ID"].ToString();
                string strLeaveTyp = dtRowsIn["LEAVETYP_NAME"].ToString();

                string strTxtBxId = "";
                strTxtBxId = strId + strLeaveTypId;
                strUpdate = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a href=\"javascript:void(0)\" class=\"btn btn-xs btn-default\" title=\"Update\"   onclick=\"return SaveLeaveDetails(" + strId + "," + strLeaveTypId + ",'" + strMsg + "');\"><i class=\"glyphicon glyphicon-floppy-disk\"></i><b>Update</b></a>";

                strConfirm = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a href=\"javascript:void(0)\" class=\"btn btn-xs btn-default\" title=\"Confirm\" disabled=\"disabled\" ><i class=\"glyphicon glyphicon-ok\"></i><b>Confirm</b></a>";
                if (dtRowsIn["OPUSLETYP_ID"].ToString() != "")
                {
                    strTxtBxId = strId + dtRowsIn["OPUSLETYP_ID"].ToString();
                    strMsg = "UPD";
                    strUpdate = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a href=\"javascript:void(0)\" class=\"btn btn-xs btn-default\" title=\"Update\"  onclick=\"return SaveLeaveDetails(" + strId + "," + dtRowsIn["OPUSLETYP_ID"].ToString() + ",'" + strMsg + "');\"><i class=\"glyphicon glyphicon-floppy-disk\"></i><b>Update</b></a>";

                    strConfirm = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a href=\"javascript:void(0)\" class=\"btn btn-xs btn-default\" title=\"Confirm\" onclick=\"return ConfirmLeaveDetails('" + dtRowsIn["OPUSLETYP_ID"].ToString() + "');\"><i class=\"glyphicon glyphicon-ok\"></i><b>Confirm</b></a>";

                    if (dtRowsIn["OPUSLETYP_CNFRM_STS"].ToString() == "1")
                    {
                        strUpdate = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a href=\"javascript:void(0)\" class=\"btn btn-xs btn-default\" title=\"Update\"  disabled=\"disabled\"><i class=\"glyphicon glyphicon-floppy-disk\"></i><b>Update</b></a>";
                        strConfirm = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a href=\"javascript:void(0)\" class=\"btn btn-xs btn-default\" title=\"Confirm\" style=\"opacity:0.5\" onclick=\"return AlrdyCnfrmd();\"><i class=\"glyphicon glyphicon-ok\"></i><b>Confirm</b></a>";
                    }

                }


                string strOpengLv = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"text\" onkeydown=\"return isNum(event)\" onchange=\"return changeisNum(this);\" maxlength=4 class\"form-control\" id=\"opnglv_" + strTxtBxId + "\" /></td>";
                string strBlncLv = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"text\" onkeydown=\"return isNum(event)\" onchange=\"return changeisNum(this);\"  maxlength=4 class\"form-control\" id=\"blnclv_" + strTxtBxId + "\" /></td>";
                string strAmount = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"text\" onkeydown=\"return isNum(event)\" class\"form-control\" id=\"amnt_" + strTxtBxId + "\" /></td>";
                string strBlncAmnt = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"text\" onkeydown=\"return isNum(event)\" class\"form-control\" id=\"blncamnt_" + strTxtBxId + "\" /></td>";
                string strYear = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"text\" onkeydown=\"return isNum(event)\"  onblur=\"yearValidation(this.value," + strId + "," + strLeaveTypId + ")\"  maxlength=4 class\"form-control\" id=\"Year_" + strTxtBxId + "\" /></td>";

                if (dtRowsIn["OPENING_NUMLEAVE"].ToString() != "")
                {
                    strOpengLv = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"text\" maxlength=4 onkeydown=\"return isNum(event)\" onchange=\"return changeisNum(this);\" value=\"" + dtRowsIn["OPENING_NUMLEAVE"].ToString() + "\" class\"form-control\" id=\"opnglv_" + strTxtBxId + "\" /></td>";
                    if (dtRowsIn["OPUSLETYP_CNFRM_STS"].ToString() == "1")
                    {
                        strOpengLv = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input readonly=\"true\" type=\"text\" maxlength=4 onkeydown=\"return isNum(event)\" value=\"" + dtRowsIn["OPENING_NUMLEAVE"].ToString() + "\" class\"form-control\" style=\"background: #dddddd\"; id=\"opnglv_" + strTxtBxId + "\" /></td>";
                    }
                }
                if (dtRowsIn["BALANCE_NUMLEAVE"].ToString() != "")
                {
                    strBlncLv = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"text\" maxlength=4 onkeydown=\"return isNum(event)\" onchange=\"return changeisNum(this);\" value=\"" + dtRowsIn["BALANCE_NUMLEAVE"].ToString() + "\" class\"form-control\" id=\"blnclv_" + strTxtBxId + "\" /></td>";
                    if (dtRowsIn["OPUSLETYP_CNFRM_STS"].ToString() == "1")
                    {
                        strBlncLv = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input readonly=\"true\" type=\"text\" maxlength=4 onkeydown=\"return isNum(event)\" value=\"" + dtRowsIn["BALANCE_NUMLEAVE"].ToString() + "\" class\"form-control\" style=\"background: #dddddd\"; id=\"blnclv_" + strTxtBxId + "\" /></td>";
                    }
                }
                
                //12-03-2019
                //if (dtRowsIn["OPENING_LEAVE_AMOUNT"].ToString() != "")
                //{
                //    strAmount = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"text\" onkeydown=\"return isNum(event)\" value=\"" + Convert.ToDecimal(dtRowsIn["OPENING_LEAVE_AMOUNT"].ToString()) + "\" class\"form-control\" id=\"amnt_" + strTxtBxId + "\" /></td>";
                //    if (dtRowsIn["OPUSLETYP_CNFRM_STS"].ToString() == "1")
                //    {
                //        strAmount = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input readonly=\"true\" type=\"text\" onkeydown=\"return isNum(event)\" value=\"" + Convert.ToDecimal(dtRowsIn["OPENING_LEAVE_AMOUNT"].ToString()) + "\" class\"form-control\" style=\"background: #dddddd\"; id=\"amnt_" + strTxtBxId + "\" /></td>";
                //    }
                //}
                
                if (dtRowsIn["BALANCE_LEAVE_AMOUNT"].ToString() != "")
                {
                    strBlncAmnt = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"text\" onkeydown=\"return isNum(event)\" value=\"" + dtRowsIn["BALANCE_LEAVE_AMOUNT"].ToString() + "\" class\"form-control\" id=\"blncamnt_" + strTxtBxId + "\" /></td>";
                    if (dtRowsIn["OPUSLETYP_CNFRM_STS"].ToString() == "1")
                    {
                        strBlncAmnt = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input readonly=\"true\" type=\"text\" onkeydown=\"return isNum(event)\" value=\"" + dtRowsIn["BALANCE_LEAVE_AMOUNT"].ToString() + "\" class\"form-control\" style=\"background: #dddddd\"; id=\"blncamnt_" + strTxtBxId + "\" /></td>";
                    }
                }
                if (dtRowsIn["OPUSLETYP_YEAR"].ToString() != "")
                {
                    strYear = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input type=\"text\" maxlength=4 onkeydown=\"return isNum(event)\" onblur=\"yearValidation(this.value, " + strId + "," + dtRowsIn["OPUSLETYP_ID"].ToString() + ")\" value=\"" + dtRowsIn["OPUSLETYP_YEAR"].ToString() + "\" class\"form-control\" id=\"Year_" + strTxtBxId + "\" /></td>";
                    if (dtRowsIn["OPUSLETYP_CNFRM_STS"].ToString() == "1")
                    {
                        strYear = "<td style=\"width:1%;word-break: break-all; word-wrap:break-word;\" role=\"gridcell\" aria-describedby=\"jqgrid_act\"><input readonly=\"true\" maxlength=4 type=\"text\"  onkeydown=\"return isNum(event)\" value=\"" + dtRowsIn["OPUSLETYP_YEAR"].ToString() + "\" class\"form-control\" style=\"background: #dddddd\"; id=\"Year_" + strTxtBxId + "\" /></td>";
                    }
                }


                yield return new Person
                {

                    UserId = dtRowsIn["USR_CODE"].ToString(),
                    Employee = dtRowsIn[1].ToString(),
                    LeaveType = strLeaveTyp,
                    OpeningLeave = strOpengLv,
                    BalanceLeave = strBlncLv,
                   // Amount = strAmount,
                   // BalanceAmount = strBlncAmnt,
                    Year=strYear,
                    Update = strUpdate,
                    Confirm = strConfirm,
                };

            }
        }
    }
}
