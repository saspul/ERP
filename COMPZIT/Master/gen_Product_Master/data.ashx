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
        var EnableEdit = context.Request["ENABLEDIT"];
        var EnableDelete = context.Request["ENABLEDELETE"];
        var Divisions = context.Request["DIVISION"];   
        
        // Those parameters are sent by the plugin
        var iDisplayLength = int.Parse(context.Request["iDisplayLength"]);
        var iDisplayStart = int.Parse(context.Request["iDisplayStart"]);
        var iSortCol = int.Parse(context.Request["iSortCol_0"]);
        var iSortDir = context.Request["sSortDir_0"];
        // Search parameters
        var sSearchAll = context.Request["sSearch"].ToLower();
        var sSearchName = context.Request["sSearch_1"].ToLower();
        var sSearchCode = context.Request["sSearch_2"].ToLower();
        var sSearchBrand = context.Request["sSearch_3"].ToLower();
        var sSearchDivisions = context.Request["sSearch_4"].ToLower();
        var sSearchSts = context.Request["sSearch_5"].ToLower();
        var sSearchGrp = context.Request["sSearch_6"].ToLower();
        var sSearchCategory = context.Request["sSearch_7"].ToLower();
        // Fetch the data from a repository (in my case in-memory)
        var persons = Person.GetPersons(Corpt_Id, Org_Id, Status, CnclSts, Divisions);
        // Define an order function based on the iSortCol parameter
        Func<Person, object> order = p =>
        {
          
            if (iSortCol == 2)
            {
                return p.ProductName;
            }
            if (iSortCol ==3)
            {
                return p.ProductCode;
            }
            if (iSortCol == 4)
            {
                return p.ProductBrand;
            }
            if (iSortCol ==5)
            {
                return p.Divisions;
            }
            if (iSortCol == 6)
            {
                return p.Status;
            }
            if (iSortCol == 7)
            {
                return p.ProductGroup;
            }
            if (iSortCol == 8)
            {
                return p.ProductCategory;
            }
            return p.ProductName;
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

            .Where(p => p.ProductName.ToString().ToLower().Contains(sSearchAll) || p.ProductCode.ToString().ToLower().Contains(sSearchAll) || p.ProductBrand.ToString().ToLower().Contains(sSearchAll) || p.Divisions.ToString().ToLower().Contains(sSearchAll) || p.Status.ToString().ToLower().Contains(sSearchAll) || p.ProductGroup.ToString().ToLower().Contains(sSearchAll) || p.ProductCategory.ToString().ToLower().Contains(sSearchAll))  // Search: Avoid Contains() in production
            .Where(p => p.ProductName.ToString().ToLower().Contains(sSearchName))  // Search: Avoid Contains() in production
             .Where(p => p.ProductCode.ToString().ToLower().Contains(sSearchCode))
             .Where(p => p.ProductBrand.ToString().ToLower().Contains(sSearchBrand))
             .Where(p => p.Divisions.ToString().ToLower().Contains(sSearchDivisions))
             .Where(p => p.Status.ToString().ToLower().Contains(sSearchSts))
             .Where(p => p.ProductGroup.ToString().ToLower().Contains(sSearchGrp))
             .Where(p => p.ProductCategory.ToString().ToLower().Contains(sSearchCategory))
            //.Where(p => p.Status.ToString().ToLower().Contains(sSearchSts))
            .Select(p => new[] { p.SL, p.ProductName, p.ProductCode, p.ProductBrand, p.Divisions, p.Status, p.ProductGroup, p.ProductCategory, p.Edit, p.View, p.Delete })
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
        public string SL { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductBrand { get; set; }
        public string Divisions { get; set; }
        public string Status { get; set; }
        public string ProductGroup { get; set; }
        public string ProductCategory { get; set; }
        public string Edit { get; set; }
        public string View { get; set; }
        public string Delete { get; set; }
        public static System.Collections.Generic.IEnumerable<Person> GetPersons(string Corpt_Id, string Org_Id, string Status, string CnclSts, string DivisionId)
        {
            clsBusinessLayerProductMaster objBusinessLayerProduct = new clsBusinessLayerProductMaster();
            clsEntityProduct_Master objEntityProduct = new clsEntityProduct_Master();
            objEntityProduct.Org_Id = Convert.ToInt32(Org_Id);
            objEntityProduct.Corp_Id = Convert.ToInt32(Corpt_Id);
            objEntityProduct.Status = Convert.ToInt32(Status);
            objEntityProduct.Cancel_Status = Convert.ToInt32(CnclSts);
            if (DivisionId != "--SELECT ALL DIVISION--" && DivisionId != "")
            {
                objEntityProduct.DivsionId = Convert.ToInt32(DivisionId);
            }
            DataTable dtCategory = objBusinessLayerProduct.ReadProductListBySearch(objEntityProduct);
            int intCount = 0;                          
            clsCommonLibrary objCommon = new clsCommonLibrary();
            string strRandom = objCommon.Random_Number();

            string Name = "";
            
            foreach (DataRow dtRowsIn in dtCategory.Rows)
            {
                string strDelete = "";
                intCount = intCount + 1;
                string strCount = Convert.ToString(intCount);
                string strId = dtRowsIn[0].ToString();
                int usrId = Convert.ToInt32(strId);
                int intIdLength = dtRowsIn[0].ToString().Length;
                string stridLength = intIdLength.ToString("00");
                string Id = stridLength + strId + strRandom;
                string stsmode;
                stsmode = dtRowsIn["STATUS"].ToString();
              //  string StrPredefinedType = dtRowsIn["ACNT_GRP_PREDFNED_TYP"].ToString();
                string cnclusrId = dtRowsIn["CANCEL USER ID"].ToString();
                int intCancTransaction = Convert.ToInt32(dtRowsIn["COUNT_TRANSACTION"].ToString());

                //if (stsmode == "ACTIVE")
                //{
                //    strStatus = "1";
                //    if (StrPredefinedType!="")
                //    {
                //        strStatusImg = "<span class=\"responsiveExpander\"></span><img title=\"Active\"  style=\" float: left;margin-left: 39%;\" src='/Images/Icons/activate.png'/>";
                //    }
                //    else
                //    {
                //        strStatusImg = "<span class=\"responsiveExpander\"></span><img title=\"Make Inactive\"  style=\"  cursor:pointer;float: left;margin-left: 39%;\" src='/Images/Icons/activate.png' onclick=\"return ChangeStatus('" + Id + "','" + strStatus + "','" + cnclusrId + "');\" />";
                //    }
                //}
                //else
                //{
                //    strStatus = "0";
                //    strStatusImg = "<span class=\"responsiveExpander\"></span><img title=\" Make Active\"  style=\"  cursor:pointer;float: left;margin-left: 39%;\" src='/Images/Icons/inactivate.png' onclick=\"return ChangeStatus('" + Id + "','" + strStatus + "','" + cnclusrId + "');\" />";
                //}
                //if (Category > 0)
                //{
                //    strDelete = "<td style=\"width:1%;opacity: 0.2;cursor: pointer;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Delete\" href=\"javascript:;\" onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" class=\"fa fa-trash\"></i></a>";
                //}
                //else if ((StrPredefinedType != "") || ChildCnt > 0 || AccntSet > 0)
                //{
                //    strDelete = "<td style=\"width:1%;opacity: 0.2;cursor: pointer;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Delete\" href=\"javascript:;\" onclick=\"return CancelNotPossible();\"><i style=\"opacity: 0.5\" class=\"fa fa-trash\"></i></a>";
                //}
                //else
                //{
                //    strDelete = "<td style=\"width:1%;word-break: break-all;word-wrap:break-word;\"  role=\"gridcell\" aria-describedby=\"jqgrid_act\"> <a class=\"btn btn-xs btn-default\" title=\"Delete\" href=\"javascript:;\" onclick=\"return OpenCancelView('" + Id + "');\"><i class=\"fa fa-trash\"></i></a>";
             //   }   
                if (cnclusrId == "0")
                {
                    if (intCancTransaction == 0)
                    {
                        strDelete = "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a title=\"Delete\"  onclick='return CancelAlert(this.href);' " + " href=\"gen_Product_MasterList.aspx?Id=" + Id + "\">" + "<img  src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                    }
                    else
                    {
                        strDelete = "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  title=\"Delete\" onclick='return CancelNotPossible();' >" + "<img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                    }
                }
                //else
                //{
                //    strDelete = "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a <img style=\"opacity: 0.2;cursor: pointer; \" src='../../Images/Icons/delete.png' /> " + "</a> </td>";
                //}  

                Name = "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + dtRowsIn["PRODUCT NAME"].ToString() + "";
                if (dtRowsIn["PRDT_SALEABLE_STS"].ToString() == "1")
                {
                    Name += "<img class=\"imgsalestck\" src=\"/Images/Icons/sales_mastr.png\" title=\"Saleable\" ><br/>";
                }
                if (dtRowsIn["PRDT_STOCKABLE_STS"].ToString() == "1")
                {
                    Name += "<img class=\"imgsalestck\" src=\"/Images/Icons/purchse_mstr.png\" title=\"Stockable\" ><br/>";
                }
                Name += "</td>";
                     
                yield return new Person
                {
                    SL=strCount,
                    ProductName = Name,
                    ProductCode = dtRowsIn["PRODUCT CODE"].ToString(),
                    ProductBrand = dtRowsIn["PRODUCT BRAND"].ToString(),
                    Divisions = dtRowsIn["DIVISION"].ToString(),
                    Status = dtRowsIn["STATUS"].ToString(),
                    ProductGroup = dtRowsIn["PRODUCT GROUP"].ToString(),
                    ProductCategory = dtRowsIn["PRODUCT CATEGORY"].ToString(),
                    Edit = "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a  title=\"Edit\" onclick='return getdetails(this.href);' " + " href=\"gen_Product_Master.aspx?Id=" + Id + "\">" + "<img  style=\"\" src='../../Images/Icons/edit.png' /> " + "</a> </td>",
                    View = "<td class=\"tdT\" style=\"width:4%; word-wrap:break-word;text-align: center;\">" + " <a title=\"View\"  onclick='return getdetails(this.href);' " + " href=\"gen_Product_Master.aspx?ViewId=" + Id + "\">" + "<img  style=\"\" src='../../Images/Icons/view.png' /> " + "</a> </td>",
                    Delete = strDelete,
                };
            }
        }

    }
}
