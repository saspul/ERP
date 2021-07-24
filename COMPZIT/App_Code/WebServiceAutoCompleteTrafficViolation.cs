using BL_Compzit;
using BL_Compzit.BusinessLayer_AWMS;
using EL_Compzit;
using EL_Compzit.EntityLayer_AWMS;
using CL_Compzit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
/// <summary>
/// Summary description for WebServiceAutoCompleteTrafficViolation
/// </summary>
[WebService(Namespace = "http://microsoft.com/webservices/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebServiceAutoCompleteTrafficViolation : System.Web.Services.WebService {

    public WebServiceAutoCompleteTrafficViolation () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetEmployeeDetails(string strLikeEmployee, int intOrgId, int intCorpId, int intVhclId, string strVioltnDate)
    {
        List<string> Employees = new List<string>();
        clsBusinessLayerTrafficViolation objBusinessLayerTrficVioltn = new clsBusinessLayerTrafficViolation();
        clsEntityLayerTrafficViolation objEntityTrficVioltn = new clsEntityLayerTrafficViolation();
        clsCommonLibrary objCommon = new clsCommonLibrary();
        objEntityTrficVioltn.Organisation_Id = intOrgId;
        objEntityTrficVioltn.CorpOffice_Id = intCorpId;
        objEntityTrficVioltn.VehicleId = intVhclId;
        if (strVioltnDate!="")
        {
            objEntityTrficVioltn.D_Date = objCommon.textToDateTime(strVioltnDate);

        }

        DataTable dtEmployess = objBusinessLayerTrficVioltn.ReadEmployeesWebService(strLikeEmployee.ToUpper(), objEntityTrficVioltn);





        for (int intRowCount = 0; intRowCount < dtEmployess.Rows.Count; intRowCount++)
        {
            Employees.Add(string.Format("{0}<->{1}", dtEmployess.Rows[intRowCount]["USR_ID"].ToString(), dtEmployess.Rows[intRowCount]["USR_NAME"].ToString()));
        }



        return Employees.ToArray();

    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string[] GetViolationDetails(string strLikeViolation, int intOrgId, int intCorpId)
    {
        List<string> Violation = new List<string>();
        clsBusinessLayerTrafficViolation objBusinessLayerTrficVioltn = new clsBusinessLayerTrafficViolation();
        clsEntityLayerTrafficViolation objEntityTrficVioltn = new clsEntityLayerTrafficViolation();
        objEntityTrficVioltn.Organisation_Id = intOrgId;
        objEntityTrficVioltn.CorpOffice_Id = intCorpId;



        DataTable dtViolation = objBusinessLayerTrficVioltn.ReadViolationWebService(strLikeViolation.ToUpper(), objEntityTrficVioltn);





        for (int intRowCount = 0; intRowCount < dtViolation.Rows.Count; intRowCount++)
        {
            Violation.Add(string.Format("{0}<->{1}<->{2}", dtViolation.Rows[intRowCount]["CMPLNTMSTR_ID"].ToString(), dtViolation.Rows[intRowCount]["CMPLNTMSTR_DSCPTN"].ToString(), dtViolation.Rows[intRowCount]["VIOLTN_AMNT"].ToString()));
        }



        return Violation.ToArray();

    }
    //[WebMethod]
    //string strReceiptNoCount = objBusinessLayerTrafficVltn.CheckDupReceiptNo(objEntityLayerTrafficVltn);
    //        if (strReceiptNoCount == "0")
    //        {
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string CheckDupReceiptNo(int intOrgId, int intCorpId, int intVioltnId, string strReceiptNo, decimal decReceiptAmount, string strStatus)
   {
        
        clsBusinessLayerTrafficViolation objBusinessLayerTrficVioltn = new clsBusinessLayerTrafficViolation();
        clsEntityLayerTrafficViolation objEntityTrficVioltn = new clsEntityLayerTrafficViolation();
        if (intVioltnId == 0)
        {
            objEntityTrficVioltn.TrafficVltnId = 0;
        }
        else
        {
            objEntityTrficVioltn.TrafficVltnId = intVioltnId;
        }
        objEntityTrficVioltn.Organisation_Id = intOrgId;
        objEntityTrficVioltn.CorpOffice_Id = intCorpId;
        objEntityTrficVioltn.ReceiptNumber = strReceiptNo;
        //DataTable dtReceiptDtls=objBusinessLayerTrficVioltn.CheckDupReceiptNo(objEntityTrficVioltn);
        string strNameCount = objBusinessLayerTrficVioltn.CheckDupReceiptNoByID(objEntityTrficVioltn);
        string strReceiptNoCount = "1";
        if (strNameCount == "0")
        {
             strReceiptNoCount = "0";
        }
        
       

        //1 duplicate
        return strReceiptNoCount;
    }
}
