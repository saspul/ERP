<%@ WebHandler Language="C#" Class="data" %>

using System;
using System.Web;
using System.Linq;
using BL_Compzit.BusinessLayer_FMS;
using EL_Compzit.EntityLayer_FMS;
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
        var GroupId = context.Request["PARNT_GRP"];
        var EnableEdit = context.Request["ENABLEDIT"];
        var EnableDelete = context.Request["ENABLEDELETE"];   
        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchCat = context.Request["sSearch_0"].ToLower();
        var sSearchGrp = context.Request["sSearch_1"].ToLower();
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id, Status, CnclSts, GroupId, EnableEdit, EnableDelete);
        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
            if (iSortCol == 1)
            {
                return p.ParentGrp;
            }
            if (iSortCol == 0)
            {
                return p.AccountName;
            }
            return p.AccountName;
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

            .Where(p => p.AccountName.ToString().ToLower().Contains(sSearchAll) || p.ParentGrp.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.AccountName.ToString().ToLower().Contains(sSearchCat))  // Search: Avoid Contains() in production
             .Where(p => p.ParentGrp.ToString().ToLower().Contains(sSearchGrp))
            .Select(p => new[] { p.AccountName, p.ParentGrp, p.Status, p.Acions })
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
        public string AccountName { get; set; }
        public string Status { get; set; }
        public string ParentGrp { get; set; }
        public string Acions { get; set; }

        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string Status, string CnclSts, string GroupId,string EnableEdit, string EnableDelete)
        {
            clsEntityAccountGroup objEntityAccountGroup = new clsEntityAccountGroup();
            clsBusinessAccountGroup objBusinessAcountGrp = new clsBusinessAccountGroup();
            objEntityAccountGroup.OrgId = Convert.ToInt32(Org_Id);
            objEntityAccountGroup.CorpId = Convert.ToInt32(Corpt_Id);
            objEntityAccountGroup.GroupStatus = Convert.ToInt32(Status);
            objEntityAccountGroup.Cancel_status = Convert.ToInt32(CnclSts);
            if (GroupId != "--SELECT GROUP--" && GroupId != "")
            {
                objEntityAccountGroup.AccountGrpId = Convert.ToInt32(GroupId);
            }
            DataTable dtCategory = objBusinessAcountGrp.ReadAccountGroupList(objEntityAccountGroup);
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();
            foreach (DataRow dtRowsIn in dtCategory.Rows)
            {
                string strDelete = "";
                string strId = dtRowsIn[0].ToString();
                int usrId = Convert.ToInt32(strId);
                int intIdLength = dtRowsIn[0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string strStatus="";
                string strEdit = "";            
                string stsmode;
                string strStatusImg = "";
                stsmode = dtRowsIn["STATUS"].ToString();
                string StrPredefinedType = dtRowsIn["ACNT_GRP_PREDFNED_TYP"].ToString();
                string cnclusrId = dtRowsIn["ACNT_CNCL_USR_ID"].ToString();
                int Category =Convert.ToInt32(dtRowsIn["LDGR_ACCOUNT"].ToString());
                int ChildCnt = Convert.ToInt32(dtRowsIn["CNT_CHILD"].ToString());
                int AccntSet = Convert.ToInt32(dtRowsIn["CNT_ACTSET"].ToString());
                if (stsmode == "ACTIVE")
                {
                    strStatus = "1";
                    if (StrPredefinedType != "")
                    {
                        strStatusImg = "<button class=\"btn tab_but1 butn1\" onclick=\"return ChngStsNotPossible();\">Active</button>";
                    }
                    else
                    {
                        strStatusImg = "<button class=\"btn tab_but1 butn1\" onclick=\"return ChangeStatus('" + Id + "','" + strStatus + "','" + cnclusrId + "');\">Active</button>";
                    }
                }
                else
                {
                    strStatus = "0";
                    strStatusImg = "<button class=\"btn tab_but1 butn6\" onclick=\"return ChangeStatus('" + Id + "','" + strStatus + "','" + cnclusrId + "');\">Inactive</button>";
                }
                if (Category > 0)
                {
                    strDelete = "<td style=\"width:1%;opacity: 0.2;cursor: pointer;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" class=\"fa fa-trash\"></i></a>";
                }
                else if ((StrPredefinedType != "") || ChildCnt > 0 || AccntSet > 0)
                {
                    strDelete = "<td style=\"width:1%;opacity: 0.2;cursor: pointer;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" class=\"fa fa-trash\"></i></a>";
                }
                else if (cnclusrId != "")
                {
                    strDelete = "";
                }
                else
                {
                    strDelete = "<td style=\"width:1%;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn act_btn bn3\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";
                }
                if (cnclusrId == "" && EnableEdit == "Active" )
                {
                    strEdit = "<a class=\"btn act_btn bn1 bt_e\" title=\"Edit\"  onclick='return getdetails(this.href);' href=\"AccountGroup.aspx?Id=" + Id + "\"><i class=\"fa fa-edit\"></i></a>";
                }
                else
                {
                    strEdit = "<a class=\"btn act_btn bn4 bt_v \" title=\"View\"onclick='return getdetails(this.href);' href=\"AccountGroup.aspx?ViewId=" + Id + "\"><i class=\"fa fa-list-alt\"></i></a>";
                }  
                     
                yield return new Person
                {
                    AccountName = dtRowsIn["ACNT_GRP_NAME"].ToString(),
                    ParentGrp = dtRowsIn["PARENTGRP"].ToString(),
                    Status = strStatusImg,
                    Acions = "<td>" + strEdit + strDelete + "</td>",
                };
            }
        }

    }
}
