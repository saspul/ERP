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
// CREATED BY:EVM-0005
// CREATED DATE:14/10/2016
// REVIEWED BY:
// REVIEW DATE:

/// <summary>
/// Summary description for ServiceVehicleClass
/// </summary>
[WebService(Namespace = "http://microsoft.com/webservices/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class ServiceVehicleClass : System.Web.Services.WebService
{

    public ServiceVehicleClass()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //create media master details through web service
    [WebMethod]
    public string[] FillVehicleClassDetails(int intVehId)
    {
        clsEntityLayerVehicleClass ObjEntityVeh = new clsEntityLayerVehicleClass();
        clsBusinessLayerVehicleClass ObjBusinessVeh = new clsBusinessLayerVehicleClass();
        DataTable dtCategoryContents = new DataTable();

        ObjEntityVeh.ClassId = Convert.ToInt32(intVehId);

        dtCategoryContents = ObjBusinessVeh.ReadVehicleClassById(ObjEntityVeh);
        int intRowFullCount = dtCategoryContents.Rows.Count;

        string[] contents = new string[3];


        contents[0] = dtCategoryContents.Rows[0]["VHCLCLS_NAME"].ToString();
        contents[1] = dtCategoryContents.Rows[0]["GNIMGSCT_ID"].ToString();
        contents[2] = dtCategoryContents.Rows[0]["VHCLCLS_STATUS"].ToString();

        return contents;
    }
    [WebMethod]
    public string DirectCancelClick(string strVehId, string strCorpId, string strOrgId, string strUserId, string strReason)
    {
        clsEntityLayerVehicleClass ObjEntityVeh = new clsEntityLayerVehicleClass();
        clsBusinessLayerVehicleClass ObjBusinessVeh = new clsBusinessLayerVehicleClass();
        string ret = "";
        ObjEntityVeh.Corporate_id = Convert.ToInt32(strCorpId);
        ObjEntityVeh.Organisation_id = Convert.ToInt32(strOrgId);
        ObjEntityVeh.User_Id = Convert.ToInt32(strUserId);
        ObjEntityVeh.Date = System.DateTime.Now;
        ObjEntityVeh.ClassId = Convert.ToInt32(strVehId);
        ObjEntityVeh.CancelReason = strReason;


        try
        {
            ObjBusinessVeh.CancelVehicleClass(ObjEntityVeh);

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

