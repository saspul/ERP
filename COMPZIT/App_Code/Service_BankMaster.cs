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
using BL_Compzit;
using System.Web.Script.Serialization;
// CREATED BY:WEM-0006
// CREATED DATE:26/10/2016
// REVIEWED BY:
// REVIEW DATE:

/// <summary>
/// Summary description for Service_BankMaster
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Service_BankMaster : System.Web.Services.WebService
{

    public Service_BankMaster()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string[] FillBankDetails(int intBankId)
    {
        clsEntityLayerBank objEntityBank = new clsEntityLayerBank();
        clsBusinessLayerBank objBusinessbank = new clsBusinessLayerBank();
        DataTable dtCategoryContents = new DataTable();

        objEntityBank.BankId = Convert.ToInt32(intBankId);

        dtCategoryContents = objBusinessbank.ReadBankById(objEntityBank);
        int intRowFullCount = dtCategoryContents.Rows.Count;

        string[] contents = new string[7];


        contents[0] = dtCategoryContents.Rows[0]["BANK_NAME"].ToString();
        contents[1] = dtCategoryContents.Rows[0]["BANK_ACC_NO"].ToString();
        contents[2] = dtCategoryContents.Rows[0]["BANK_ADDRESS"].ToString();
        contents[3] = dtCategoryContents.Rows[0]["BANK_IFSC_CODE"].ToString();
        contents[4] = dtCategoryContents.Rows[0]["BANK_SWIFT_CODE"].ToString();
        contents[5] = dtCategoryContents.Rows[0]["BANK_FOREX_ACC_NO"].ToString();
        contents[6] = dtCategoryContents.Rows[0]["BANK_STATUS"].ToString();
        return contents;
    }
    [WebMethod]
    public string DirectCancelClick(string strBnkId, string strCorpId, string strOrgId, string strUserId, string strReason)
    {
        clsEntityLayerBank objEntityBank = new clsEntityLayerBank();
        clsBusinessLayerBank objBusinessbank = new clsBusinessLayerBank();
        string ret = "";
        objEntityBank.Corporate_id = Convert.ToInt32(strCorpId);
        objEntityBank.Organisation_id = Convert.ToInt32(strOrgId);
        objEntityBank.User_Id = Convert.ToInt32(strUserId);
        objEntityBank.BankDate = System.DateTime.Now;
        objEntityBank.BankId = Convert.ToInt32(strBnkId);
        objEntityBank.CanclReason = strReason;


        try
        {
            objBusinessbank.CancelBank(objEntityBank);

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
