using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DL_Compzit;
using EL_Compzit;
using System.Data;
using DL_Compzit.DataLayer_AWMS;
using EL_Compzit.EntityLayer_AWMS;
using BL_Compzit.BusinessLayer_AWMS;
using System.Web.Script.Serialization;
using BL_Compzit;
// CREATED BY:EVM-0005
// CREATED DATE:04/10/2016
// REVIEWED BY:
// REVIEW DATE:

/// <summary>
/// Summary description for Service_Accommodation
/// </summary>
[WebService(Namespace = "http://microsoft.com/webservices/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Service_Accommodation : System.Web.Services.WebService
{

    public Service_Accommodation()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //create media master details through web service
    [WebMethod]
    public string[] FillAccommodationDetails(int intAccId)
    {
        clsEntityAccommodation ObjEntityAcco = new clsEntityAccommodation();
        clsBusinessLayerAccommodation ObjBusinessAcco = new clsBusinessLayerAccommodation();
        DataTable dtCategoryContents = new DataTable();

        ObjEntityAcco.AccommodationId = Convert.ToInt32(intAccId);

        dtCategoryContents = ObjBusinessAcco.ReadAccommodationById(ObjEntityAcco);
        int intRowFullCount = dtCategoryContents.Rows.Count;

        string[] contents = new string[3];
        if (dtCategoryContents.Rows.Count > 0)
        {

            contents[0] = dtCategoryContents.Rows[0]["ACCMDTN_NAME"].ToString();
            contents[1] = dtCategoryContents.Rows[0]["ACCMDTN_ADDRS"].ToString();
            contents[2] = dtCategoryContents.Rows[0]["ACCMDTN_STATUS"].ToString();
        }
        return contents;
    }
    [WebMethod]
    public string DirectCancelClick(string strAccId, string strCorpId, string strOrgId, string strUserId, string strReason)
    {
        clsEntityAccommodation ObjEntityAcco = new clsEntityAccommodation();
        clsBusinessLayerAccommodation ObjBusinessAcco = new clsBusinessLayerAccommodation();
        string ret = "";
        ObjEntityAcco.Corporate_id = Convert.ToInt32(strCorpId);
        ObjEntityAcco.Organisation_id = Convert.ToInt32(strOrgId);
        ObjEntityAcco.User_Id = Convert.ToInt32(strUserId);
        ObjEntityAcco.Date = System.DateTime.Now;
        ObjEntityAcco.AccommodationId = Convert.ToInt32(strAccId);
        ObjEntityAcco.CancelReason = strReason;


        try
        {
            ObjBusinessAcco.CancelAccommodation(ObjEntityAcco);

            ret = "success";

        }
        catch
        {
            ret = "failed";
        }
        return ret;
    }

    //convert datatable to json format
    public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
    {
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        foreach (DataRow row in table.Rows)
        {
            childRow = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                childRow.Add(col.ColumnName, row[col]);
            }
            parentRow.Add(childRow);
        }
        return jsSerializer.Serialize(parentRow);
    }

}
