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
// CREATED DATE:04/10/2016
// REVIEWED BY:
// REVIEW DATE:
/// <summary>
/// Summary description for Service_InsuranceProvider
/// </summary>
[WebService(Namespace = "http://microsoft.com/webservices/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Service_InsuranceProvider : System.Web.Services.WebService
{

    public Service_InsuranceProvider()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }



    [WebMethod]
    //Method of passing INSURANCE table data from datalayer to ui layer
    public string ReadInsuranceType()
    {//Creating objects for datalayer
        clsBusinessLayerInsuranceProvider objBusinessInsurance = new clsBusinessLayerInsuranceProvider();
        DataTable dtReadInsuranceType = new DataTable();
        dtReadInsuranceType = objBusinessInsurance.ReadInsuranceType();
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtReadInsuranceType);
        return strJson;
    }
    [WebMethod]
    //Method of passing insurance details from ui layer to datalayer for insertion
    public void AddInsuranceProvider(int NextNumber, int intCorpId, int intOrgId, int intUserId, string strInsurTypeId, int intStatus, string strProviderName, string StrProviderAddress)
    {//Creating objects for datalayer
        clsBusinessLayerInsuranceProvider objBusinessInsurance = new clsBusinessLayerInsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        List<clsEntityLayerInsuranceProvider> objEntityLayerInsuranceProviderList = new List<clsEntityLayerInsuranceProvider>();

        string[] strInsType = strInsurTypeId.Split(',');

        int ArrayCount = strInsType.Count();
        for (int count = 0; count < ArrayCount; count++)
        {
            if (strInsType[count] != "")
            {
                clsEntityLayerInsuranceProvider ObjEntityForInsType = new clsEntityLayerInsuranceProvider();
                ObjEntityForInsType.Provider_Type = Convert.ToInt32(strInsType[count]);
                objEntityLayerInsuranceProviderList.Add(ObjEntityForInsType);
            }
        }
        objEntityInsurance.NextNumber = NextNumber;
        objEntityInsurance.Corporate_id = intCorpId;
        objEntityInsurance.Organisation_id = intOrgId;
        objEntityInsurance.User_Id = intUserId;
        objEntityInsurance.Status_id = intStatus;
        objEntityInsurance.Provider_Name = strProviderName;
        objEntityInsurance.Provider_Address = StrProviderAddress;
        objBusinessInsurance.AddInsuranceProvider(objEntityInsurance, objEntityLayerInsuranceProviderList);
    }
    [WebMethod]
    //Method of passing insurance details from ui layer to datalayer for insertion
    public void UpdateInsuranceProvider(int intInsureId, int intCorpId, int intOrgId, int intUserId, string strInsurTypeId, int intStatus, string strProviderName, string StrProviderAddress)
    {//Creating objects for datalayer
        clsBusinessLayerInsuranceProvider objBusinessInsurance = new clsBusinessLayerInsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        List<clsEntityLayerInsuranceProvider> objEntityLayerInsuranceProviderList = new List<clsEntityLayerInsuranceProvider>();

        string[] strInsType = strInsurTypeId.Split(',');

        int ArrayCount = strInsType.Count();
        for (int count = 0; count < ArrayCount; count++)
        {
            if (strInsType[count] != "")
            {
                clsEntityLayerInsuranceProvider ObjEntityForInsType = new clsEntityLayerInsuranceProvider();
                ObjEntityForInsType.Provider_Type = Convert.ToInt32(strInsType[count]);
                objEntityLayerInsuranceProviderList.Add(ObjEntityForInsType);
            }
        }
        objEntityInsurance.InsuranceId = intInsureId;
        objEntityInsurance.Corporate_id = intCorpId;
        objEntityInsurance.Organisation_id = intOrgId;
        objEntityInsurance.User_Id = intUserId;
        objEntityInsurance.Status_id = intStatus;
        objEntityInsurance.Provider_Name = strProviderName;
        objEntityInsurance.Provider_Address = StrProviderAddress;
        objBusinessInsurance.UpdateInsuranceProvider(objEntityInsurance, objEntityLayerInsuranceProviderList);
    }
    [WebMethod]
    // This Method checks Product name in the database for duplication.
    public string CheckInsuranceProviderName(int intInsure_id, string Name, int intCorpId, int intOrg_id)
    {//Creating objects for datalayer
        clsBusinessLayerInsuranceProvider objBusinessInsurance = new clsBusinessLayerInsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        objEntityInsurance.InsuranceId = intInsure_id;
        objEntityInsurance.Provider_Name = Name;
        objEntityInsurance.Corporate_id = intCorpId;
        objEntityInsurance.Organisation_id = intOrg_id;
        string COUNT = objBusinessInsurance.CheckInsuranceProviderName(objEntityInsurance);
        return COUNT;
    }
    [WebMethod]
    //Method of passing INSURANCE details from datalayer to ui layer
    public string ReadInsuranceDetailById(int intInsureId)
    {//Creating objects for datalayer
        clsBusinessLayerInsuranceProvider objBusinessInsurance = new clsBusinessLayerInsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        objEntityInsurance.InsuranceId = intInsureId;
        DataTable dtReadInsuranceDetails = new DataTable();
        dtReadInsuranceDetails = objBusinessInsurance.ReadInsuranceproviderById(objEntityInsurance);
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtReadInsuranceDetails);
        return strJson;
    }
    [WebMethod]
    //Method of passing INSURANCE details from datalayer to ui layer
    public string ReadInsuranceTypeByPrvdrId(int intInsureId)
    {//Creating objects for datalayer
        clsBusinessLayerInsuranceProvider objBusinessInsurance = new clsBusinessLayerInsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        objEntityInsurance.InsuranceId = intInsureId;
        DataTable dtReadInsuranceDetails = new DataTable();
        dtReadInsuranceDetails = objBusinessInsurance.ReadInsuranceTypeByPrvdrId(objEntityInsurance);
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtReadInsuranceDetails);
        return strJson;
    }
    [WebMethod]
    //Method of reading provider list by search
    public string ReadInsuranceProviderListBySearch(int intOrg, int intCorp, int intStatus, int intCancelStatus,int IntInsTypeId)
    {//Creating objects for datalayer
        clsBusinessLayerInsuranceProvider objBusinessInsurance = new clsBusinessLayerInsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        objEntityInsurance.Organisation_id = intOrg;
        objEntityInsurance.Corporate_id = intCorp;
        objEntityInsurance.InsuranceType = IntInsTypeId;
        objEntityInsurance.Status_id = intStatus;
        objEntityInsurance.CancelStatus = intCancelStatus;
        DataTable dtReadInsuranceDetails = new DataTable();
        dtReadInsuranceDetails = objBusinessInsurance.ReadInsuranceProviderListBySearch(objEntityInsurance);
        string strJson = DataTableToJSONWithJavaScriptSerializer(dtReadInsuranceDetails);
        return strJson;
    }
    //Method for cancel Insurance Provider
    [WebMethod]
    public void CancelInsuranceProvider(int intInsureId, int intUser_Id, string strCancelReason)
    {//Creating objects for datalayer
        clsDataLayerInsuranceProvider objDataLayerInsurance = new clsDataLayerInsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        objEntityInsurance.InsuranceId = intInsureId;
        objEntityInsurance.User_Id = intUser_Id;
        objEntityInsurance.CancelReason = strCancelReason;
        objDataLayerInsurance.CancelInsuranceProvider(objEntityInsurance);
    }
    //Method for cancel Insurance Provider
    [WebMethod]
    public void RecallInsuranceProvider(int intInsureId, int intUser_Id)
    {//Creating objects for datalayer
        clsDataLayerInsuranceProvider objDataLayerInsurance = new clsDataLayerInsuranceProvider();
        clsEntityLayerInsuranceProvider objEntityInsurance = new clsEntityLayerInsuranceProvider();
        objEntityInsurance.InsuranceId = intInsureId;
        objEntityInsurance.User_Id = intUser_Id;
        objDataLayerInsurance.ReCallInsuranceProvider(objEntityInsurance);
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
