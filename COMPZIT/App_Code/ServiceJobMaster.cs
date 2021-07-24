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
// CREATED BY:WEM-0006
// CREATED DATE:27/10/2016
// REVIEWED BY:
// REVIEW DATE:

/// <summary>
/// Summary description for ServiceJobMaster
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class ServiceJobMaster : System.Web.Services.WebService {

    public ServiceJobMaster () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

   
    [WebMethod]
    public string[] FillJobDetails(int intJobId)
    {
        clsEntityLayerJobMaster objEntityjob = new clsEntityLayerJobMaster();
        clsBusinessLayerJobMaster ObjBussinessJob = new clsBusinessLayerJobMaster();
        DataTable dtCategoryContents = new DataTable();

        objEntityjob.JobId = Convert.ToInt32(intJobId);

        dtCategoryContents = ObjBussinessJob.ReadJobTitleById(objEntityjob);
        int intRowFullCount = dtCategoryContents.Rows.Count;

        string[] contents = new string[3];
        if (dtCategoryContents.Rows.Count > 0)
        {

            contents[0] = dtCategoryContents.Rows[0]["JOBMSTR_TITLE"].ToString();
            contents[1] = dtCategoryContents.Rows[0]["JOBMSTR_DESCPTN"].ToString();
            contents[2] = dtCategoryContents.Rows[0]["JOBMSTR_STATUS"].ToString();
        }
        return contents;
    }
    [WebMethod]
    public string DirectCancelClick(string strAccId, string strCorpId, string strOrgId, string strUserId, string strReason)
    {
        clsEntityLayerJobMaster objEntityjob = new clsEntityLayerJobMaster();
        clsBusinessLayerJobMaster ObjBussinessJob = new clsBusinessLayerJobMaster();
        string ret = "";
        objEntityjob.Corporate_id = Convert.ToInt32(strCorpId);
        objEntityjob.Organisation_id = Convert.ToInt32(strOrgId);
        objEntityjob.User_Id = Convert.ToInt32(strUserId);
        objEntityjob.Date = System.DateTime.Now;
        objEntityjob.JobId = Convert.ToInt32(strAccId);
        objEntityjob.CancelReason = strReason;


        try
        {
            ObjBussinessJob.CancelJobTitle(objEntityjob);

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
